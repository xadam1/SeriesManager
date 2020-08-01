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

namespace SeriesManager
{
    public partial class MainForm : Form
    {
        private string SeriesDirectoryPath;
        private string EpisodeNameListPath;

        private Parser parser = new Parser();

        private List<string> filesInDir = new List<string>();
        private List<string> episodeNamesFromFile = new List<string>();


        public MainForm()
        {
            InitializeComponent();

            this.textSeriesDirPath.Text = "Not Selected";
            this.textEpNameListFilePath.Text = "Not Selected";
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

        private void btnSelectSeriesDir_Click(object sender, EventArgs e)
        {
            var dirPath = GetSeriesDirectoryPath();

            if (dirPath == string.Empty) { return; }

            this.textSeriesDirPath.Text = dirPath;
            SeriesDirectoryPath = dirPath;

            // FILE FORMAT: "C:\Users\honza\Downloads\test\Game.Of.Thrones.S03E01[1080p].mkv"
            filesInDir = Directory.GetFiles(SeriesDirectoryPath).ToList();

            this.lblEpCounter.Text = $"Episodes Found:  {filesInDir.Count}";
            this.lblEpCounter.Visible = true;
        }

        private void btnSelectEpNameListFile_Click(object sender, EventArgs e)
        {
            var filePath = GetEpisodeNamesFilePath();

            if (filePath == string.Empty) { return; }

            this.textEpNameListFilePath.Text = filePath;
            EpisodeNameListPath = filePath;


            // EPISODE FORMAT: "S02E01-The_North_Remembers"
            episodeNamesFromFile = parser.ExtractEpNamesFromFile(EpisodeNameListPath);

            this.lblEpNamesCounter.Text = $"Names of Episodes Found:  {episodeNamesFromFile.Count}";
            this.lblEpNamesCounter.Visible = true;
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            if (SeriesDirectoryPath is null)
            {
                MessageBox.Show("First you need to select Series Folder!", "Invalid Series Folder!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EpisodeNameListPath is null)
            {
                var res = MessageBox.Show("You did not select Episode Name List.\nEpisodes will not be named if you click 'OK'.", "Name List Missing!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (res == DialogResult.Cancel) { return; }
            }

            ProgressBarSetup(filesInDir.Count);
            await parser.RenameAndMoveEpisodes(filesInDir, episodeNamesFromFile, progressBar);

        }

        private void ProgressBarSetup(int numberOfFiles)
        {
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
    }
}
