namespace OsuDump
{
    partial class Extractor
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.StopExportButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HashCountLabel = new System.Windows.Forms.Label();
            this.CollectionsCountLabel = new System.Windows.Forms.Label();
            this.CollectionsPathBox = new System.Windows.Forms.TextBox();
            this.CollectionsBrowseButton = new System.Windows.Forms.Button();
            this.SongsPathBox = new System.Windows.Forms.TextBox();
            this.SongsBrowseButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.CollectionsList = new System.Windows.Forms.CheckedListBox();
            this.OutputPathBox = new System.Windows.Forms.TextBox();
            this.OutputBrowseButton = new System.Windows.Forms.Button();
            this.OpenDataButton = new System.Windows.Forms.Button();
            this.DumpIndividualSubfolders = new System.Windows.Forms.CheckBox();
            this.LoadCacheButton = new System.Windows.Forms.Button();
            this.SaveCacheButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CacheCount = new System.Windows.Forms.Label();
            this.CacheBrowseButton = new System.Windows.Forms.Button();
            this.CachePathBox = new System.Windows.Forms.TextBox();
            this.ExportSongsButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CachelessParse = new System.Windows.Forms.Button();
            this.StopParseButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(636, 506);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(136, 23);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // StopExportButton
            // 
            this.StopExportButton.Enabled = false;
            this.StopExportButton.Location = new System.Drawing.Point(293, 506);
            this.StopExportButton.Name = "StopExportButton";
            this.StopExportButton.Size = new System.Drawing.Size(136, 23);
            this.StopExportButton.TabIndex = 1;
            this.StopExportButton.Text = "Stop";
            this.StopExportButton.UseVisualStyleBackColor = true;
            this.StopExportButton.Click += new System.EventHandler(this.StopExportButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HashCountLabel);
            this.groupBox1.Controls.Add(this.CollectionsCountLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 56);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Collections";
            // 
            // HashCountLabel
            // 
            this.HashCountLabel.AutoSize = true;
            this.HashCountLabel.Location = new System.Drawing.Point(7, 36);
            this.HashCountLabel.Name = "HashCountLabel";
            this.HashCountLabel.Size = new System.Drawing.Size(110, 13);
            this.HashCountLabel.TabIndex = 1;
            this.HashCountLabel.Text = "Total Song Hashes: 0";
            // 
            // CollectionsCountLabel
            // 
            this.CollectionsCountLabel.AutoSize = true;
            this.CollectionsCountLabel.Location = new System.Drawing.Point(7, 20);
            this.CollectionsCountLabel.Name = "CollectionsCountLabel";
            this.CollectionsCountLabel.Size = new System.Drawing.Size(122, 13);
            this.CollectionsCountLabel.TabIndex = 0;
            this.CollectionsCountLabel.Text = "Number of Collections: 0";
            // 
            // CollectionsPathBox
            // 
            this.CollectionsPathBox.Location = new System.Drawing.Point(6, 19);
            this.CollectionsPathBox.Name = "CollectionsPathBox";
            this.CollectionsPathBox.Size = new System.Drawing.Size(222, 20);
            this.CollectionsPathBox.TabIndex = 3;
            this.CollectionsPathBox.Text = "C:\\Program Files (x86)\\osu!\\collection.db";
            // 
            // CollectionsBrowseButton
            // 
            this.CollectionsBrowseButton.Location = new System.Drawing.Point(234, 16);
            this.CollectionsBrowseButton.Name = "CollectionsBrowseButton";
            this.CollectionsBrowseButton.Size = new System.Drawing.Size(35, 23);
            this.CollectionsBrowseButton.TabIndex = 4;
            this.CollectionsBrowseButton.Text = "...";
            this.CollectionsBrowseButton.UseVisualStyleBackColor = true;
            this.CollectionsBrowseButton.Click += new System.EventHandler(this.CollectionsBrowseButton_Click);
            // 
            // SongsPathBox
            // 
            this.SongsPathBox.Location = new System.Drawing.Point(6, 46);
            this.SongsPathBox.Name = "SongsPathBox";
            this.SongsPathBox.Size = new System.Drawing.Size(222, 20);
            this.SongsPathBox.TabIndex = 5;
            this.SongsPathBox.Text = "C:\\Program Files (x86)\\osu!\\Songs";
            // 
            // SongsBrowseButton
            // 
            this.SongsBrowseButton.Location = new System.Drawing.Point(234, 44);
            this.SongsBrowseButton.Name = "SongsBrowseButton";
            this.SongsBrowseButton.Size = new System.Drawing.Size(35, 23);
            this.SongsBrowseButton.TabIndex = 6;
            this.SongsBrowseButton.Text = "...";
            this.SongsBrowseButton.UseVisualStyleBackColor = true;
            this.SongsBrowseButton.Click += new System.EventHandler(this.SongsBrowseButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LogBox);
            this.groupBox2.Location = new System.Drawing.Point(294, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 487);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // LogBox
            // 
            this.LogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogBox.Location = new System.Drawing.Point(3, 16);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogBox.Size = new System.Drawing.Size(472, 468);
            this.LogBox.TabIndex = 0;
            // 
            // CollectionsList
            // 
            this.CollectionsList.Enabled = false;
            this.CollectionsList.FormattingEnabled = true;
            this.CollectionsList.Items.AddRange(new object[] {
            "[Osu Collections]"});
            this.CollectionsList.Location = new System.Drawing.Point(12, 318);
            this.CollectionsList.Name = "CollectionsList";
            this.CollectionsList.ScrollAlwaysVisible = true;
            this.CollectionsList.Size = new System.Drawing.Size(275, 124);
            this.CollectionsList.TabIndex = 9;
            // 
            // OutputPathBox
            // 
            this.OutputPathBox.Location = new System.Drawing.Point(12, 476);
            this.OutputPathBox.Name = "OutputPathBox";
            this.OutputPathBox.Size = new System.Drawing.Size(234, 20);
            this.OutputPathBox.TabIndex = 11;
            this.OutputPathBox.Text = "./Output/";
            // 
            // OutputBrowseButton
            // 
            this.OutputBrowseButton.Location = new System.Drawing.Point(252, 474);
            this.OutputBrowseButton.Name = "OutputBrowseButton";
            this.OutputBrowseButton.Size = new System.Drawing.Size(35, 23);
            this.OutputBrowseButton.TabIndex = 12;
            this.OutputBrowseButton.Text = "...";
            this.OutputBrowseButton.UseVisualStyleBackColor = true;
            this.OutputBrowseButton.Click += new System.EventHandler(this.OutputBrowseButton_Click);
            // 
            // OpenDataButton
            // 
            this.OpenDataButton.Location = new System.Drawing.Point(12, 93);
            this.OpenDataButton.Name = "OpenDataButton";
            this.OpenDataButton.Size = new System.Drawing.Size(275, 23);
            this.OpenDataButton.TabIndex = 13;
            this.OpenDataButton.Text = "Parse Collections.db";
            this.OpenDataButton.UseVisualStyleBackColor = true;
            this.OpenDataButton.Click += new System.EventHandler(this.OpenDataButton_Click);
            // 
            // DumpIndividualSubfolders
            // 
            this.DumpIndividualSubfolders.AutoSize = true;
            this.DumpIndividualSubfolders.Checked = true;
            this.DumpIndividualSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DumpIndividualSubfolders.Location = new System.Drawing.Point(12, 448);
            this.DumpIndividualSubfolders.Name = "DumpIndividualSubfolders";
            this.DumpIndividualSubfolders.Size = new System.Drawing.Size(189, 17);
            this.DumpIndividualSubfolders.TabIndex = 14;
            this.DumpIndividualSubfolders.Text = "Dump into individual subdirectories";
            this.DumpIndividualSubfolders.UseVisualStyleBackColor = true;
            // 
            // LoadCacheButton
            // 
            this.LoadCacheButton.Location = new System.Drawing.Point(6, 41);
            this.LoadCacheButton.Name = "LoadCacheButton";
            this.LoadCacheButton.Size = new System.Drawing.Size(112, 23);
            this.LoadCacheButton.TabIndex = 15;
            this.LoadCacheButton.Text = "Load Cache";
            this.LoadCacheButton.UseVisualStyleBackColor = true;
            this.LoadCacheButton.Click += new System.EventHandler(this.LoadCacheButton_Click);
            // 
            // SaveCacheButton
            // 
            this.SaveCacheButton.Location = new System.Drawing.Point(6, 68);
            this.SaveCacheButton.Name = "SaveCacheButton";
            this.SaveCacheButton.Size = new System.Drawing.Size(112, 23);
            this.SaveCacheButton.TabIndex = 16;
            this.SaveCacheButton.Text = "Save Cache File";
            this.SaveCacheButton.UseVisualStyleBackColor = true;
            this.SaveCacheButton.Click += new System.EventHandler(this.SaveCacheButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.CacheCount);
            this.groupBox3.Controls.Add(this.CacheBrowseButton);
            this.groupBox3.Controls.Add(this.SaveCacheButton);
            this.groupBox3.Controls.Add(this.CachePathBox);
            this.groupBox3.Controls.Add(this.LoadCacheButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 99);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Song Data / Cache";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(157, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Refresh Cache";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CacheCount
            // 
            this.CacheCount.AutoSize = true;
            this.CacheCount.Location = new System.Drawing.Point(124, 46);
            this.CacheCount.Name = "CacheCount";
            this.CacheCount.Size = new System.Drawing.Size(89, 13);
            this.CacheCount.TabIndex = 20;
            this.CacheCount.Text = "Songs Cached: 0";
            // 
            // CacheBrowseButton
            // 
            this.CacheBrowseButton.Location = new System.Drawing.Point(234, 13);
            this.CacheBrowseButton.Name = "CacheBrowseButton";
            this.CacheBrowseButton.Size = new System.Drawing.Size(35, 23);
            this.CacheBrowseButton.TabIndex = 19;
            this.CacheBrowseButton.Text = "...";
            this.CacheBrowseButton.UseVisualStyleBackColor = true;
            this.CacheBrowseButton.Click += new System.EventHandler(this.CacheBrowseButton_Click);
            // 
            // CachePathBox
            // 
            this.CachePathBox.Location = new System.Drawing.Point(6, 15);
            this.CachePathBox.Name = "CachePathBox";
            this.CachePathBox.Size = new System.Drawing.Size(222, 20);
            this.CachePathBox.TabIndex = 19;
            this.CachePathBox.Text = "./songdata.cache";
            // 
            // ExportSongsButton
            // 
            this.ExportSongsButton.Location = new System.Drawing.Point(12, 506);
            this.ExportSongsButton.Name = "ExportSongsButton";
            this.ExportSongsButton.Size = new System.Drawing.Size(275, 23);
            this.ExportSongsButton.TabIndex = 18;
            this.ExportSongsButton.Text = "Export Songs";
            this.ExportSongsButton.UseVisualStyleBackColor = true;
            this.ExportSongsButton.Click += new System.EventHandler(this.ExportSongsButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CollectionsPathBox);
            this.groupBox4.Controls.Add(this.CollectionsBrowseButton);
            this.groupBox4.Controls.Add(this.SongsPathBox);
            this.groupBox4.Controls.Add(this.SongsBrowseButton);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(275, 75);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Files / Directories";
            // 
            // CachelessParse
            // 
            this.CachelessParse.Location = new System.Drawing.Point(12, 289);
            this.CachelessParse.Name = "CachelessParse";
            this.CachelessParse.Size = new System.Drawing.Size(189, 23);
            this.CachelessParse.TabIndex = 19;
            this.CachelessParse.Text = "Parse Song Data - No Cache";
            this.CachelessParse.UseVisualStyleBackColor = true;
            this.CachelessParse.Click += new System.EventHandler(this.CachelessParse_Click);
            // 
            // StopParseButton
            // 
            this.StopParseButton.Enabled = false;
            this.StopParseButton.Location = new System.Drawing.Point(207, 289);
            this.StopParseButton.Name = "StopParseButton";
            this.StopParseButton.Size = new System.Drawing.Size(80, 23);
            this.StopParseButton.TabIndex = 20;
            this.StopParseButton.Text = "Stop";
            this.StopParseButton.UseVisualStyleBackColor = true;
            this.StopParseButton.Click += new System.EventHandler(this.StopParseButton_Click);
            // 
            // Extractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 540);
            this.Controls.Add(this.StopParseButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OpenDataButton);
            this.Controls.Add(this.CachelessParse);
            this.Controls.Add(this.OutputBrowseButton);
            this.Controls.Add(this.OutputPathBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.ExportSongsButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.DumpIndividualSubfolders);
            this.Controls.Add(this.CollectionsList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.StopExportButton);
            this.Controls.Add(this.ExitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Extractor";
            this.Text = "Osu Song Extractor";
            this.Load += new System.EventHandler(this.Extractor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button StopExportButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CollectionsPathBox;
        private System.Windows.Forms.Button CollectionsBrowseButton;
        private System.Windows.Forms.TextBox SongsPathBox;
        private System.Windows.Forms.Button SongsBrowseButton;
        private System.Windows.Forms.Label HashCountLabel;
        private System.Windows.Forms.Label CollectionsCountLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox CollectionsList;
        private System.Windows.Forms.TextBox OutputPathBox;
        private System.Windows.Forms.Button OutputBrowseButton;
        private System.Windows.Forms.Button OpenDataButton;
        private System.Windows.Forms.CheckBox DumpIndividualSubfolders;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Button LoadCacheButton;
        private System.Windows.Forms.Button SaveCacheButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button CacheBrowseButton;
        private System.Windows.Forms.TextBox CachePathBox;
        private System.Windows.Forms.Button ExportSongsButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button CachelessParse;
        private System.Windows.Forms.Button StopParseButton;
        private System.Windows.Forms.Label CacheCount;
        private System.Windows.Forms.Button button1;
    }
}

