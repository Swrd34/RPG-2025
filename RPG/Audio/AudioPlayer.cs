using System.Media;
using System.Threading.Tasks;
using NAudio.Wave;

namespace RPG
{
    class AudioPlayerLoop // For background looping audio using SoundPlayer
    {
        private SoundPlayer _player;

        public void LoopAudioBackgroundSoundPlayer(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("Error: File path is null or empty.");
                return;
            }

            Thread backgroundSoundThread = new(() =>
            {
                try
                {
                    _player = new SoundPlayer(filePath);
                    _player.Load();
                    _player.PlayLooping(); // This method plays the audio in a loop
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            });

            backgroundSoundThread.IsBackground = true;
            backgroundSoundThread.Start();
        }
    }

    class AudioPlayerReg
    {
        private WaveOutEvent _waveOut;
        private AudioFileReader _audioFileReader;
        private CancellationTokenSource _cancellationTokenSource;

        public AudioPlayerReg()
        {
            _waveOut = new WaveOutEvent();
        }

        public async Task PlayAudioAsync(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
            {
                Console.WriteLine("Error: File path is null or empty.");
                return;
            }

            await Task.Run(() =>
            {
                try
                {
                    using var reader = new AudioFileReader(filepath);
                    _waveOut.Init(reader);
                    _waveOut.Play();

                    while (_waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        Task.Delay(100).Wait();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            });
        }

        public void LoopAudio(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
            {
                Console.WriteLine("Error: File path is null or empty.");
                return;
            }

            StopAudio();
            _cancellationTokenSource = new CancellationTokenSource();

            Task.Run(() =>
            {
                try
                {
                    while (!_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        using var reader = new AudioFileReader(filepath);
                        _waveOut.Init(reader);
                        _waveOut.Play();

                        while (_waveOut.PlaybackState == PlaybackState.Playing &&
                               !_cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            Task.Delay(100).Wait();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }, _cancellationTokenSource.Token);
        }

        public void StopAudio()
        {
            _cancellationTokenSource?.Cancel();
            _waveOut.Stop();
            _waveOut.Dispose();
        }

        public void FadeOutAndStop(int fadeDurationMs = 2000)
        {
            if (_waveOut == null || _audioFileReader == null)
                return;

            float initialVolume = _audioFileReader.Volume; // Current volume
            int fadeSteps = 20; // Number of steps to fade out
            int interval = fadeDurationMs / fadeSteps;

            for (int i = 0; i < fadeSteps; i++)
            {
                _audioFileReader.Volume = initialVolume * (1 - (float)i / fadeSteps); // Gradually reduce volume
                Thread.Sleep(interval); // Wait between steps
            }

            _audioFileReader.Volume = 0; // Ensure volume is at 0
            _waveOut.Stop(); // Stop the playback
            _audioFileReader.Dispose(); // Clean up resources
            _waveOut.Dispose();
        }


    }

}


