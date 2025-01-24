using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Discord_AFK_System.Threads
{
    internal class AFKThreads
    {
        private static WaveOutEvent outputDevice;
        private static AudioFileReader audioFile;

        public static int timeUntilNextPlay;
        public static int totalTime;

        private static Form1 _form;

        public static void PlayAudio(string filePath, CancellationTokenSource token)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                try
                {
                    outputDevice.DeviceNumber = GetVirtualCableDeviceNumber();
                }
                catch
                {
                    DialogResult result = MessageBox.Show("VB-Audio Virtual Cable or VB-Audio Hi-Fi Cable is required to run Discord AFK System.\n\nWould you like to visit the VB-Audio download page?", "Cannot start Discord AFK System", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);

                    if (result == DialogResult.Yes)
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = "https://vb-audio.com/Cable/",
                            UseShellExecute = true
                        });

                    Environment.Exit(1);
                }

            }

            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                outputDevice.Stop();
            }

            audioFile = new AudioFileReader(filePath);

            try
            {
                outputDevice.Init(audioFile);
                audioFile.Seek(0, SeekOrigin.Begin);
                outputDevice.Play();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error playing audio: " + ex);
                token.Cancel();
                MessageBox.Show("An error occurred while trying to play the audio.\nThis is likely because your virtual audio cable is already being used.\nPlease press stop to reset.\n\nTechy mumbo jumbo:\n" + ex.Message, "Cannot play audio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void StartClock(string filePath, float time, CancellationTokenSource token)
        {
            Thread t = new Thread(() => QueueAudio(filePath, time, token));
            t.IsBackground = true;
            t.Start();
            while (!token.IsCancellationRequested)
            {
                // nothing. chill out. hold your horses.
            }

            if (token.IsCancellationRequested)
            {
                Debug.WriteLine("Cancelling");
                outputDevice.Stop();
                audioFile.Seek(0, SeekOrigin.Begin);
                outputDevice.Dispose();
            }

        }

        public static void QueueAudio(string filePath, float time, CancellationTokenSource token)
        {
            while (!token.IsCancellationRequested)
            {
                PlayAudio(filePath, token);
                timeUntilNextPlay = totalTime;
                for (int i = (int)time; i > 0; i--)
                {
                    if (!token.IsCancellationRequested)
                    {
                        timeUntilNextPlay--;
                        _form.TotalTimeRemaining = timeUntilNextPlay + 1;
                        Sleeb(1);
                    }
                }
                QueueAudio(filePath, time, token);
            }

        }

        public Thread StartAudioThread(string filePath, float time, CancellationTokenSource token, Form1 form)
        {
            _form = form;
            totalTime = (int)time;

            var t = new Thread(() => StartClock(filePath, time, token));
            t.IsBackground = true;
            t.Start();
            return t;
        }

        public static void Sleeb(double time)
        {
            Thread.Sleep((int)(time * 1000));
        }

        public static int GetVirtualCableDeviceNumber()
        {
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                var capabilities = WaveOut.GetCapabilities(i);
                if (capabilities.ProductName.Contains("VB-Audio Hi-Fi Cable") || capabilities.ProductName.Contains("VB-Audio Virtual Cable"))
                {
                    return i;
                }
            }



            throw new Exception("Virtual audio cable not found");
        }
    }
}
