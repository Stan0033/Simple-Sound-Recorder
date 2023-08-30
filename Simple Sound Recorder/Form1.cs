using NAudio.CoreAudioApi;
using NAudio.Utils;
using NAudio.Wave;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Simple_Sound_Recorder
{
    public partial class Form1 : Form
    {
        string currentRecordingDevice;
        public Form1()
        {
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Recordings"))){ Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Recordings")); }
            InitializeComponent();
            PopulateRecordingDevices();
            InitializePlaybackTimer();
            InitializeRecordingTimer();
            currentEnumeration = GetNextAvailableRecordingNumber();


        }
        private static WaveInEvent waveIn;
        private static WaveFileWriter waveWriter;
        private static bool isRecording = false;
        private static WaveOutEvent waveOut; // Added WaveOutEvent for playback
        private static bool isPaused = false; // Added variable to track playback pause/resume
        private Timer playbackTimer;
        private Timer recordingTimer;
        private TimeSpan lastPlaybackPosition = TimeSpan.Zero;
        private bool userIsSeeking = false;
        private AudioFileReader audioFile;
        int currentEnumeration = 0;
        private bool isPlaybackPaused = false;
        private TimeSpan playbackPosition = TimeSpan.Zero; // Add this field
        string mostRecentRecording;
        string CurrentSoundFile;

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private int GetNextAvailableRecordingNumber()
        {
            string[] wavFiles = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "Recordings"), "recording*.wav")
                .Select(Path.GetFileNameWithoutExtension)
                .ToArray();

            int maxEnumeration = 0;

            foreach (string fileName in wavFiles)
            {
                if (int.TryParse(fileName.Substring("recording".Length), out int enumeration))
                {
                    maxEnumeration = Math.Max(maxEnumeration, enumeration);
                }
            }

             
            CurrentSoundFile = Path.Combine(Environment.CurrentDirectory, $"Recording{maxEnumeration+1}");
           // MessageBox.Show(CurrentSoundFile);
            return maxEnumeration + 1; ;
        }
        private void InitializeRecordingTimer()
        {
            recordingTimer = new Timer();
            recordingTimer.Interval = 100; // Update every 100 milliseconds
            recordingTimer.Tick += RecordingTimer_Tick;
        }

        private void InitializePlaybackTimer()
        {
            playbackTimer = new Timer();
            playbackTimer.Interval = 100; // Update every 100 milliseconds
            playbackTimer.Tick += PlaybackTimer_Tick;
        }
        private void RecordingTimer_Tick(object sender, EventArgs e)
        {
            if (isRecording)
            {
                TimeSpan currentTime = TimeSpan.FromSeconds((double)waveWriter.Length / waveWriter.WaveFormat.AverageBytesPerSecond);
                label_recordingCurrentTime.Text = currentTime.ToString(@"m\:ss\:fff");
            }
        }
        private void PopulateRecordingDevices()
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDeviceCollection devices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);

            foreach (MMDevice device in devices)
            {
                comboBox1.Items.Add(device.FriendlyName);
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0; // Set the selected item to the first device
                currentRecordingDevice = comboBox1.Text;
            }
            else
            {
                MessageBox.Show( "No recording devices found. Closing app.");
                Environment.Exit( 0 );
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
            
                if (userIsSeeking && waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    var audioFile = new AudioFileReader("output.wav");
                    var trackbarPosition = (double)trackBar1.Value / trackBar1.Maximum;
                    var newPosition = trackbarPosition * audioFile.TotalTime.TotalSeconds;
                    audioFile.CurrentTime = TimeSpan.FromSeconds(newPosition);
                }
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
             StartRecording(comboBox1.SelectedIndex);
        }
        public void StartRecording(int selectedDeviceIndex)
        {
            if (selectedDeviceIndex < 0 || selectedDeviceIndex >= WaveInEvent.DeviceCount)
            {
                MessageBox.Show("Selected recording device is not available.");
                return;
            }

            if (isRecording)
            {
                MessageBox.Show("Recording is already in progress.");
                return;
            }

            int nextRecordingNumber = GetNextAvailableRecordingNumber();

            string recordingsFolderPath = Path.Combine(Environment.CurrentDirectory, "Recordings");
            Directory.CreateDirectory(recordingsFolderPath); // Ensure the directory exists

            string outputPath = Path.Combine(recordingsFolderPath, $"recording{nextRecordingNumber}.wav");
            CurrentSoundFile = outputPath;

            waveIn = new WaveInEvent();
            waveIn.DeviceNumber = selectedDeviceIndex;
            waveIn.WaveFormat = new WaveFormat(44100, 1);

            waveWriter = new WaveFileWriter(outputPath, waveIn.WaveFormat);

            waveIn.DataAvailable += (sender, e) =>
            {
                if (waveWriter != null)
                {
                    waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
                }
            };

            waveIn.RecordingStopped += (sender, e) =>
            {
                if (waveWriter != null)
                {
                    waveWriter.Close();
                    waveWriter.Dispose();
                    waveWriter = null;
                }
            };

            waveIn.StartRecording();
            isRecording = true;
            recordingTimer.Start();
        }

        public static void StopRecording()
        {
            if (isRecording)
            {
                waveIn.StopRecording();
                waveWriter?.Dispose();
                waveWriter = null;
                isRecording = false;
            }
        }
        public static void SaveRecording(string folderPath, string fileName)
        {
            if (isRecording)
            {
                MessageBox.Show("Stop recording before saving.");
                return;
            }

            if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
                System.Threading.Thread.Sleep(100); // Add a short delay
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                MessageBox.Show("Please provide a file name.");
                return;
            }

            if (!fileName.EndsWith(".wav", StringComparison.OrdinalIgnoreCase))
            {
                fileName += ".wav"; // Ensure .wav extension
            }

            string fullPath = System.IO.Path.Combine(folderPath, fileName);

            if (System.IO.File.Exists("output.wav"))
            {
                if (waveWriter != null)
                {
                    waveWriter.Close(); // Close the writer before copying
                    waveWriter.Dispose();
                    waveWriter = null;
                }

                System.IO.File.Copy("output.wav", fullPath, true);
               // System.IO.File.Delete("output.wav");
            }
        }







        private void StartPlayback()
        {
            if (waveOut != null)
            {
                if (isPlaybackPaused)
                {
                    // Resume playback from the last position if it was paused
                    waveOut.Play();
                    isPlaybackPaused = false;
                    return;
                }
                else if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    // Pause playback if it's playing
                    waveOut.Pause();
                    isPlaybackPaused = true;
                    return;
                }
                else
                {
                    // Stop and dispose of the waveOut instance if it's not paused or playing
                    waveOut.Stop();
                    waveOut.Dispose();
                    waveOut = null;
                    playbackPosition = TimeSpan.Zero;
                    playbackTimer.Stop();
                }
            }

            string[] recordingFiles = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "Recordings"), "recording*.wav");

            if (recordingFiles.Length > 0)
            {
                string mostRecentRecording = recordingFiles.OrderBy(file => file).Last(); // Get the most recent recording
                audioFile = new AudioFileReader(mostRecentRecording); // Open the audio file once
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);

                // Adjust the trackbar's maximum value to match the audio's length in milliseconds
                trackBar1.Maximum = (int)audioFile.TotalTime.TotalMilliseconds;

                playbackPosition = TimeSpan.Zero; // Reset the playback position
                waveOut.Play();
                playbackTimer.Start();
            }
            else
            {
                MessageBox.Show("No recorded audio to play.");
            }
        }
        public int TurnTimeToMilliseconds(double time) { int n = (int)(time * 1000); return n; }
        private void PlaybackTimer_Tick(object sender, EventArgs e)
        {
            if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing && audioFile != null)
            {
                playbackPosition = audioFile.CurrentTime;

                // Update the trackbar value to match the current playback position
                int trackbarValue = (int)(playbackPosition.TotalMilliseconds);
                if (trackbarValue <= trackBar1.Maximum)
                {
                    trackBar1.Value = trackbarValue;
                }
            }
        }

        





        private string FormatMilliseconds(int milliseconds)
    {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(milliseconds);
            return timeSpan.ToString(@"m\:ss\:fff");
        }


        private void PausePlayback()
        {
            if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
            {
                waveOut.Pause();
                isPlaybackPaused = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StartPlayback();
        }

        private void button_pause_Click(object sender, EventArgs e)
        {
            PausePlayback();
        }

        private void button_stoprecording_Click(object sender, EventArgs e)
        {
            StopRecording();
            label_recordingCurrentTime.Text = string.Empty;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Environment.CurrentDirectory);
        }
    }
}
