using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.Runtime.CompilerServices;

namespace SeriesManager
{
    public partial class MainForm : Form
    {
        private string _seriesDirectoryPath;
        private string _episodeNameListPath;
        private string _tmpSubDirPath;

        private List<string> _episodesInEpisodeSeriesDir = new List<string>();


        public MainForm()
        {
            InitializeComponent();

            this.textSeriesDirPath.Text = "Not Selected";
            this.textEpNameListFilePath.Text = "Not Selected";
        }

        private void btnSelectSeriesDir_Click(object sender, EventArgs e)
        {
            var dirPath = GetSeriesDirectoryPath();

            if (dirPath == string.Empty) { return; }

            this.textSeriesDirPath.Text = dirPath;
            _seriesDirectoryPath = dirPath;

            // FILE FORMAT: "C:\Users\honza\Downloads\test\Game.Of.Thrones.S03E01[1080p].mkv"
            _episodesInEpisodeSeriesDir = Directory.GetFiles(_seriesDirectoryPath).ToList();

            this.lblEpCounter.Text = $"Episodes Found:  {_episodesInEpisodeSeriesDir.Count}";
            this.lblEpCounter.Visible = true;
        }

        private void btnSelectEpNameListFile_Click(object sender, EventArgs e)
        {
            var filePath = GetEpisodeNamesFilePath();

            if (filePath == string.Empty) { return; }

            this.textEpNameListFilePath.Text = filePath;
            _episodeNameListPath = filePath;
        }

        private void btnSelectSubZipFile_Click(object sender, EventArgs e)
        {
            var subPath = @"C:\temp\SM_subs";
            var subtitleDir = Directory.CreateDirectory(subPath);
            _tmpSubDirPath = subtitleDir.FullName;

            var zipFile = GetSubtitlesZipFilePath();

            ZipFile.ExtractToDirectory(zipFile, subPath);
            var subFiles = Directory.GetFiles(subPath).ToList();

            if (!Parser.RenameSubtitleFiles(subtitleDir.FullName))
            {
                MessageBox.Show("Unable to find series and episode description in subtitle files.\n",
                    "Subtitles Did NOT Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DeleteSubsDir(_tmpSubDirPath);
                return;
            }
        }


        private async void btnProcess_Click(object sender, EventArgs e)
        {
            if (_seriesDirectoryPath is null)
            {
                MessageBox.Show("First you need to select Series Folder!", "Invalid Series Folder!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_episodeNameListPath is null)
            {
                var res = MessageBox.Show("You did not select Episode Name List.\nEpisodes will not be named if you click 'OK'.", "Name List Missing!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (res == DialogResult.Cancel) { return; }
            }

            ProgressBarSetup(_episodesInEpisodeSeriesDir.Count);

            await Parser.RenameAndMoveEpisodes(_episodesInEpisodeSeriesDir, progressBar);

            Parser.MoveSubsIntoEpFolder(_seriesDirectoryPath, _tmpSubDirPath);

            this.lblProgress.Text = "Finished.";
            MessageBox.Show("Everything DONE!", "Series Sorted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OpenFolderAfterFinishing();
            DeleteSubsDir(_tmpSubDirPath);
        }



        private string GetSeriesDirectoryPath()
        {
            var dirPath = string.Empty;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Console.WriteLine($"SeriesFolder: {fbd.SelectedPath}");
                    dirPath = fbd.SelectedPath;
                }
            }

            return dirPath;
        }

        private string GetEpisodeNamesFilePath()
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    Console.WriteLine($"EpisodeNameList: {filePath}");
                }
            }

            return filePath;
        }

        private string GetSubtitlesZipFilePath()
        {
            var zipFile = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "rar files (*.rar)|*.rar|zip files (*.zip)|*.zip|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    zipFile = openFileDialog.FileName;
                    Console.WriteLine($"SubsZipFile: {zipFile}");
                }
            }

            return zipFile;
        }

        private void ProgressBarSetup(int numberOfFiles)
        {
            this.lblProgress.Visible = true;

            // Display the ProgressBar control.
            this.progressBar.Visible = true;
            // Set Minimum to 1 to represent the first file being copied.
            this.progressBar.Minimum = 1;
            // Set Maximum to the total number of files to copy.
            this.progressBar.Maximum = numberOfFiles;
            // Set the initial value of the ProgressBar.
            this.progressBar.Value = 1;
            // Set the Step property to a value of 1 to represent each file being copied.
            this.progressBar.Step = 1;
        }

        private void OpenFolderAfterFinishing()
        {
            if (!this.checkBoxOpenFolderWhenDone.Checked) { return; }

            System.Diagnostics.Process.Start("explorer.exe", $"{_seriesDirectoryPath}");
        }

        private void DeleteSubsDir(string subsDirPath)
        {
            var files = Directory.GetFiles(subsDirPath);
            foreach (var file in files)
            {
                File.Delete(file);
            }
            Directory.Delete(subsDirPath);
        }



        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DeleteSubsDir(_tmpSubDirPath);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
