using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows.Resources;
using System.Windows;

namespace PROG6212_POE_ST10071737.MVVM.Model
{
    public sealed class AudioPlayerSingletonModel
    {

        private static AudioPlayerSingletonModel instance;
        private SoundPlayer player;
        private List<string> playlist;
        private int currentIndex = 0;
        private bool isPlaying = false;

        private AudioPlayerSingletonModel()
        {
            player = new SoundPlayer();
            playlist = new List<string>();
            this.AddToPlaylist();
        }

        public static AudioPlayerSingletonModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AudioPlayerSingletonModel();
                }
                return instance;
            }
        }

        public void AddToPlaylist()
        {
            playlist.Add("Black-Sabbath-Paranoid-.wav");
            playlist.Add("ShootToThrill.wav");
            playlist.Add("WarPigs.wav");
        }

        public void Play()
        {
            if (playlist.Count == 0)
            {
                MessageBox.Show("Playlist is empty. Add audio files to the playlist first.");
                return;
            }

            if (!isPlaying)
            {
                if (currentIndex >= 0 && currentIndex < playlist.Count)
                {
                    Play(playlist[currentIndex]);
                }
                else
                {
                    currentIndex = 0;
                    Play(playlist[currentIndex]);
                }
            }
            else
            {
                Pause();
            }
        }

        public void Next()
        {
            if (playlist.Count == 0)
            {
                MessageBox.Show("Playlist is empty. Add audio files to the playlist first.");
                return;
            }

            currentIndex++;
            if (currentIndex >= playlist.Count)
            {
                currentIndex = 0;
            }

            Play();
        }

        public void Previous()
        {
            if (playlist.Count == 0)
            {
                MessageBox.Show("Playlist is empty. Add audio files to the playlist first.");
                return;
            }

            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = playlist.Count - 1;
            }

            Play();
        }

        public void Play(string audioFilePath)
        {
            try
            {
                player.SoundLocation = audioFilePath;
                player.Load();
                player.Play();
                isPlaying = true;
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., file not found, unsupported format, etc.
                MessageBox.Show($"Error playing audio: {ex.Message}");
            }
        }

        public void Pause()
        {
            player.Stop();
            isPlaying = false;
        }

        public void Stop()
        {
            player.Stop();
            isPlaying = false;
        }
    }
}

//____________________________________EOF_________________________________________________________________________