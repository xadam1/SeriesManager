namespace SeriesManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectSeriesDir = new System.Windows.Forms.Button();
            this.textSeriesDirPath = new System.Windows.Forms.TextBox();
            this.lblSeriesFolder = new System.Windows.Forms.Label();
            this.textEpNameListFilePath = new System.Windows.Forms.TextBox();
            this.lblEpNameListFile = new System.Windows.Forms.Label();
            this.btnSelectEpNameListFile = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblEpCounter = new System.Windows.Forms.Label();
            this.lblEpNamesCounter = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.checkBoxOpenFolderWhenDone = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textSubZipFile = new System.Windows.Forms.TextBox();
            this.lblSubZipFile = new System.Windows.Forms.Label();
            this.btnSelectSubZipFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectSeriesDir
            // 
            this.btnSelectSeriesDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectSeriesDir.Font = new System.Drawing.Font("Montserrat", 10F);
            this.btnSelectSeriesDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.btnSelectSeriesDir.Location = new System.Drawing.Point(676, 35);
            this.btnSelectSeriesDir.Name = "btnSelectSeriesDir";
            this.btnSelectSeriesDir.Size = new System.Drawing.Size(80, 25);
            this.btnSelectSeriesDir.TabIndex = 22;
            this.btnSelectSeriesDir.Text = "Select";
            this.btnSelectSeriesDir.UseVisualStyleBackColor = true;
            this.btnSelectSeriesDir.Click += new System.EventHandler(this.btnSelectSeriesDir_Click);
            // 
            // textSeriesDirPath
            // 
            this.textSeriesDirPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.textSeriesDirPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSeriesDirPath.Font = new System.Drawing.Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSeriesDirPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.textSeriesDirPath.Location = new System.Drawing.Point(173, 39);
            this.textSeriesDirPath.MaxLength = 50;
            this.textSeriesDirPath.Name = "textSeriesDirPath";
            this.textSeriesDirPath.Size = new System.Drawing.Size(487, 21);
            this.textSeriesDirPath.TabIndex = 24;
            // 
            // lblSeriesFolder
            // 
            this.lblSeriesFolder.AutoSize = true;
            this.lblSeriesFolder.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeriesFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.lblSeriesFolder.Location = new System.Drawing.Point(12, 41);
            this.lblSeriesFolder.Name = "lblSeriesFolder";
            this.lblSeriesFolder.Size = new System.Drawing.Size(112, 19);
            this.lblSeriesFolder.TabIndex = 23;
            this.lblSeriesFolder.Text = "Series Folder";
            // 
            // textEpNameListFilePath
            // 
            this.textEpNameListFilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.textEpNameListFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEpNameListFilePath.Font = new System.Drawing.Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEpNameListFilePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.textEpNameListFilePath.Location = new System.Drawing.Point(173, 76);
            this.textEpNameListFilePath.MaxLength = 50;
            this.textEpNameListFilePath.Name = "textEpNameListFilePath";
            this.textEpNameListFilePath.Size = new System.Drawing.Size(487, 21);
            this.textEpNameListFilePath.TabIndex = 27;
            // 
            // lblEpNameListFile
            // 
            this.lblEpNameListFile.AutoSize = true;
            this.lblEpNameListFile.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpNameListFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.lblEpNameListFile.Location = new System.Drawing.Point(12, 78);
            this.lblEpNameListFile.Name = "lblEpNameListFile";
            this.lblEpNameListFile.Size = new System.Drawing.Size(153, 19);
            this.lblEpNameListFile.TabIndex = 26;
            this.lblEpNameListFile.Text = "Episode NameList";
            // 
            // btnSelectEpNameListFile
            // 
            this.btnSelectEpNameListFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectEpNameListFile.Font = new System.Drawing.Font("Montserrat", 10F);
            this.btnSelectEpNameListFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.btnSelectEpNameListFile.Location = new System.Drawing.Point(676, 72);
            this.btnSelectEpNameListFile.Name = "btnSelectEpNameListFile";
            this.btnSelectEpNameListFile.Size = new System.Drawing.Size(80, 25);
            this.btnSelectEpNameListFile.TabIndex = 25;
            this.btnSelectEpNameListFile.Text = "Select";
            this.btnSelectEpNameListFile.UseVisualStyleBackColor = true;
            this.btnSelectEpNameListFile.Click += new System.EventHandler(this.btnSelectEpNameListFile_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Montserrat", 14.25F);
            this.btnProcess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.btnProcess.Location = new System.Drawing.Point(333, 333);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(100, 41);
            this.btnProcess.TabIndex = 28;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(150, 493);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(487, 23);
            this.progressBar.TabIndex = 29;
            this.progressBar.Visible = false;
            // 
            // lblEpCounter
            // 
            this.lblEpCounter.AutoSize = true;
            this.lblEpCounter.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.lblEpCounter.Location = new System.Drawing.Point(12, 233);
            this.lblEpCounter.Name = "lblEpCounter";
            this.lblEpCounter.Size = new System.Drawing.Size(145, 19);
            this.lblEpCounter.TabIndex = 30;
            this.lblEpCounter.Text = "Episodes Found: ";
            this.lblEpCounter.Visible = false;
            // 
            // lblEpNamesCounter
            // 
            this.lblEpNamesCounter.AutoSize = true;
            this.lblEpNamesCounter.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpNamesCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.lblEpNamesCounter.Location = new System.Drawing.Point(12, 276);
            this.lblEpNamesCounter.Name = "lblEpNamesCounter";
            this.lblEpNamesCounter.Size = new System.Drawing.Size(225, 19);
            this.lblEpNamesCounter.TabIndex = 31;
            this.lblEpNamesCounter.Text = "Names of Episodes Found: ";
            this.lblEpNamesCounter.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.lblProgress.Location = new System.Drawing.Point(343, 455);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(90, 19);
            this.lblProgress.TabIndex = 32;
            this.lblProgress.Text = "Progress...";
            this.lblProgress.Visible = false;
            // 
            // checkBoxOpenFolderWhenDone
            // 
            this.checkBoxOpenFolderWhenDone.AutoSize = true;
            this.checkBoxOpenFolderWhenDone.Checked = true;
            this.checkBoxOpenFolderWhenDone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOpenFolderWhenDone.Location = new System.Drawing.Point(256, 182);
            this.checkBoxOpenFolderWhenDone.Name = "checkBoxOpenFolderWhenDone";
            this.checkBoxOpenFolderWhenDone.Size = new System.Drawing.Size(15, 14);
            this.checkBoxOpenFolderWhenDone.TabIndex = 33;
            this.checkBoxOpenFolderWhenDone.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label1.Location = new System.Drawing.Point(12, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 19);
            this.label1.TabIndex = 34;
            this.label1.Text = "Open Folder After Finishing";
            // 
            // textSubZipFile
            // 
            this.textSubZipFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.textSubZipFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSubZipFile.Font = new System.Drawing.Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSubZipFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.textSubZipFile.Location = new System.Drawing.Point(173, 117);
            this.textSubZipFile.MaxLength = 50;
            this.textSubZipFile.Name = "textSubZipFile";
            this.textSubZipFile.Size = new System.Drawing.Size(487, 21);
            this.textSubZipFile.TabIndex = 37;
            // 
            // lblSubZipFile
            // 
            this.lblSubZipFile.AutoSize = true;
            this.lblSubZipFile.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubZipFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.lblSubZipFile.Location = new System.Drawing.Point(12, 119);
            this.lblSubZipFile.Name = "lblSubZipFile";
            this.lblSubZipFile.Size = new System.Drawing.Size(142, 19);
            this.lblSubZipFile.TabIndex = 36;
            this.lblSubZipFile.Text = "Subtitles Zip File";
            // 
            // btnSelectSubZipFile
            // 
            this.btnSelectSubZipFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectSubZipFile.Font = new System.Drawing.Font("Montserrat", 10F);
            this.btnSelectSubZipFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.btnSelectSubZipFile.Location = new System.Drawing.Point(676, 113);
            this.btnSelectSubZipFile.Name = "btnSelectSubZipFile";
            this.btnSelectSubZipFile.Size = new System.Drawing.Size(80, 25);
            this.btnSelectSubZipFile.TabIndex = 35;
            this.btnSelectSubZipFile.Text = "Select";
            this.btnSelectSubZipFile.UseVisualStyleBackColor = true;
            this.btnSelectSubZipFile.Click += new System.EventHandler(this.btnSelectSubZipFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.textSubZipFile);
            this.Controls.Add(this.lblSubZipFile);
            this.Controls.Add(this.btnSelectSubZipFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxOpenFolderWhenDone);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblEpNamesCounter);
            this.Controls.Add(this.lblEpCounter);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.textEpNameListFilePath);
            this.Controls.Add(this.lblEpNameListFile);
            this.Controls.Add(this.btnSelectEpNameListFile);
            this.Controls.Add(this.textSeriesDirPath);
            this.Controls.Add(this.lblSeriesFolder);
            this.Controls.Add(this.btnSelectSeriesDir);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectSeriesDir;
        private System.Windows.Forms.TextBox textSeriesDirPath;
        private System.Windows.Forms.Label lblSeriesFolder;
        private System.Windows.Forms.TextBox textEpNameListFilePath;
        private System.Windows.Forms.Label lblEpNameListFile;
        private System.Windows.Forms.Button btnSelectEpNameListFile;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblEpCounter;
        private System.Windows.Forms.Label lblEpNamesCounter;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.CheckBox checkBoxOpenFolderWhenDone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textSubZipFile;
        private System.Windows.Forms.Label lblSubZipFile;
        private System.Windows.Forms.Button btnSelectSubZipFile;
    }
}

