using Aninamer.components;
using Aninamer.util;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Aninamer
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.executeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusCodeRTextBox = new System.Windows.Forms.RichTextBox();
            this.targetFilesList = new Aninamer.components.SyncedListBox();
            this.extIdList = new Aninamer.components.SyncedListBox();
            this.serverURL = new System.Windows.Forms.TextBox();
            this.anidbParentUrlLabel = new System.Windows.Forms.Label();
            this.targetTitleTextBox = new System.Windows.Forms.TextBox();
            this.aidToSearchLabel = new System.Windows.Forms.Label();
            this.aidToSearchTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.getAnimeDataButton = new System.Windows.Forms.Button();
            this.loginAgainButton = new System.Windows.Forms.Button();
            this.getJobStatusButton = new System.Windows.Forms.Button();
            this.changeAllButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.genericErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.jobStatusLabel = new System.Windows.Forms.Label();
            this.jobStatusIndicator = new System.Windows.Forms.Panel();
            this.clearAnimeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genericErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(689, 10);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(99, 42);
            this.executeButton.TabIndex = 0;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "<select folder>";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.statusCodeRTextBox);
            this.panel1.Controls.Add(this.targetFilesList);
            this.panel1.Controls.Add(this.extIdList);
            this.panel1.Location = new System.Drawing.Point(12, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 386);
            this.panel1.TabIndex = 2;
            // 
            // statusCodeRTextBox
            // 
            this.statusCodeRTextBox.Location = new System.Drawing.Point(756, 3);
            this.statusCodeRTextBox.Name = "statusCodeRTextBox";
            this.statusCodeRTextBox.ReadOnly = true;
            this.statusCodeRTextBox.Size = new System.Drawing.Size(198, 369);
            this.statusCodeRTextBox.TabIndex = 2;
            this.statusCodeRTextBox.Text = "";
            // 
            // targetFilesList
            // 
            this.targetFilesList.AllowDrop = true;
            this.targetFilesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.targetFilesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.targetFilesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetFilesList.FormattingEnabled = true;
            this.targetFilesList.HorizontalExtent = 2000;
            this.targetFilesList.HorizontalScrollbar = true;
            this.targetFilesList.ItemHeight = 16;
            this.targetFilesList.Location = new System.Drawing.Point(387, 0);
            this.targetFilesList.Name = "targetFilesList";
            this.targetFilesList.Partner = null;
            this.targetFilesList.Size = new System.Drawing.Size(364, 372);
            this.targetFilesList.TabIndex = 1;
            this.targetFilesList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TargetFilesList_DrawItem);
            this.targetFilesList.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            this.targetFilesList.DragDrop += new System.Windows.Forms.DragEventHandler(this.TargetFilesList_DragDrop);
            this.targetFilesList.DragEnter += new System.Windows.Forms.DragEventHandler(this.TargetFilesList_DragEnter);
            this.targetFilesList.DragOver += new System.Windows.Forms.DragEventHandler(this.TargetFilesList_DragOver);
            this.targetFilesList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TargetFilesList_MouseDown);
            // 
            // extIdList
            // 
            this.extIdList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.extIdList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extIdList.FormattingEnabled = true;
            this.extIdList.HorizontalExtent = 2000;
            this.extIdList.HorizontalScrollbar = true;
            this.extIdList.ItemHeight = 16;
            this.extIdList.Location = new System.Drawing.Point(7, 0);
            this.extIdList.Name = "extIdList";
            this.extIdList.Partner = null;
            this.extIdList.Size = new System.Drawing.Size(374, 372);
            this.extIdList.TabIndex = 0;
            this.extIdList.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // serverURL
            // 
            this.serverURL.Location = new System.Drawing.Point(85, 32);
            this.serverURL.Name = "serverURL";
            this.serverURL.Size = new System.Drawing.Size(225, 20);
            this.serverURL.TabIndex = 3;
            // 
            // anidbParentUrlLabel
            // 
            this.anidbParentUrlLabel.AutoSize = true;
            this.anidbParentUrlLabel.Location = new System.Drawing.Point(13, 35);
            this.anidbParentUrlLabel.Name = "anidbParentUrlLabel";
            this.anidbParentUrlLabel.Size = new System.Drawing.Size(66, 13);
            this.anidbParentUrlLabel.TabIndex = 4;
            this.anidbParentUrlLabel.Text = "Server URL:";
            // 
            // targetTitleTextBox
            // 
            this.targetTitleTextBox.Enabled = false;
            this.targetTitleTextBox.Location = new System.Drawing.Point(416, 32);
            this.targetTitleTextBox.Name = "targetTitleTextBox";
            this.targetTitleTextBox.Size = new System.Drawing.Size(197, 20);
            this.targetTitleTextBox.TabIndex = 5;
            // 
            // aidToSearchLabel
            // 
            this.aidToSearchLabel.AutoSize = true;
            this.aidToSearchLabel.Location = new System.Drawing.Point(3, 6);
            this.aidToSearchLabel.Name = "aidToSearchLabel";
            this.aidToSearchLabel.Size = new System.Drawing.Size(48, 13);
            this.aidToSearchLabel.TabIndex = 7;
            this.aidToSearchLabel.Text = "AnidbID:";
            // 
            // aidToSearchTextBox
            // 
            this.aidToSearchTextBox.Location = new System.Drawing.Point(73, 3);
            this.aidToSearchTextBox.Name = "aidToSearchTextBox";
            this.aidToSearchTextBox.Size = new System.Drawing.Size(68, 20);
            this.aidToSearchTextBox.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.clearAnimeButton);
            this.panel2.Controls.Add(this.getAnimeDataButton);
            this.panel2.Controls.Add(this.loginAgainButton);
            this.panel2.Controls.Add(this.getJobStatusButton);
            this.panel2.Controls.Add(this.changeAllButton);
            this.panel2.Controls.Add(this.aidToSearchLabel);
            this.panel2.Controls.Add(this.aidToSearchTextBox);
            this.panel2.Location = new System.Drawing.Point(12, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 46);
            this.panel2.TabIndex = 9;
            // 
            // getAnimeDataButton
            // 
            this.getAnimeDataButton.Location = new System.Drawing.Point(460, 4);
            this.getAnimeDataButton.Name = "getAnimeDataButton";
            this.getAnimeDataButton.Size = new System.Drawing.Size(84, 42);
            this.getAnimeDataButton.TabIndex = 13;
            this.getAnimeDataButton.Text = "Get Anime Data";
            this.getAnimeDataButton.UseVisualStyleBackColor = true;
            this.getAnimeDataButton.Click += new System.EventHandler(this.getAnimeDataButton_Click);
            // 
            // loginAgainButton
            // 
            this.loginAgainButton.Location = new System.Drawing.Point(370, 4);
            this.loginAgainButton.Name = "loginAgainButton";
            this.loginAgainButton.Size = new System.Drawing.Size(84, 42);
            this.loginAgainButton.TabIndex = 12;
            this.loginAgainButton.Text = "Login";
            this.loginAgainButton.UseVisualStyleBackColor = true;
            this.loginAgainButton.Click += new System.EventHandler(this.LoginAgainButton_Click);
            // 
            // getJobStatusButton
            // 
            this.getJobStatusButton.Location = new System.Drawing.Point(280, 3);
            this.getJobStatusButton.Name = "getJobStatusButton";
            this.getJobStatusButton.Size = new System.Drawing.Size(84, 42);
            this.getJobStatusButton.TabIndex = 11;
            this.getJobStatusButton.Text = "Get Status";
            this.getJobStatusButton.UseVisualStyleBackColor = true;
            this.getJobStatusButton.Click += new System.EventHandler(this.getJobStatusButton_Click);
            // 
            // changeAllButton
            // 
            this.changeAllButton.Enabled = false;
            this.changeAllButton.Location = new System.Drawing.Point(677, 3);
            this.changeAllButton.Name = "changeAllButton";
            this.changeAllButton.Size = new System.Drawing.Size(99, 42);
            this.changeAllButton.TabIndex = 10;
            this.changeAllButton.Text = "Change All";
            this.changeAllButton.UseVisualStyleBackColor = true;
            this.changeAllButton.Click += new System.EventHandler(this.ChangeAllButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(623, 10);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(60, 42);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // genericErrProvider
            // 
            this.genericErrProvider.ContainerControl = this;
            // 
            // jobStatusLabel
            // 
            this.jobStatusLabel.AutoSize = true;
            this.jobStatusLabel.Location = new System.Drawing.Point(316, 35);
            this.jobStatusLabel.Name = "jobStatusLabel";
            this.jobStatusLabel.Size = new System.Drawing.Size(60, 13);
            this.jobStatusLabel.TabIndex = 12;
            this.jobStatusLabel.Text = "Job Status:";
            // 
            // jobStatusIndicator
            // 
            this.jobStatusIndicator.BackColor = System.Drawing.Color.LightCoral;
            this.jobStatusIndicator.Location = new System.Drawing.Point(388, 32);
            this.jobStatusIndicator.Name = "jobStatusIndicator";
            this.jobStatusIndicator.Size = new System.Drawing.Size(21, 20);
            this.jobStatusIndicator.TabIndex = 13;
            // 
            // clearAnimeButton
            // 
            this.clearAnimeButton.Location = new System.Drawing.Point(550, 4);
            this.clearAnimeButton.Name = "clearAnimeButton";
            this.clearAnimeButton.Size = new System.Drawing.Size(84, 42);
            this.clearAnimeButton.TabIndex = 14;
            this.clearAnimeButton.Text = "Clear Anime";
            this.clearAnimeButton.UseVisualStyleBackColor = true;
            this.clearAnimeButton.Click += new System.EventHandler(this.clearAnimeButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 506);
            this.Controls.Add(this.jobStatusIndicator);
            this.Controls.Add(this.jobStatusLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.targetTitleTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.anidbParentUrlLabel);
            this.Controls.Add(this.serverURL);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.executeButton);
            this.Name = "MainWindow";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genericErrProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void InitializeExtras()
        {
            //this.fh = new FileHelper();
        }

        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Label label1;
        //private FileHelper fh;
        private System.Windows.Forms.Panel panel1;
        private Aninamer.components.SyncedListBox targetFilesList;
        private Aninamer.components.SyncedListBox extIdList;
        private System.Windows.Forms.TextBox serverURL;
        private Label anidbParentUrlLabel;
        private TextBox targetTitleTextBox;
        private Label aidToSearchLabel;
        private TextBox aidToSearchTextBox;
        private Panel panel2;
        private Button changeAllButton;
        private Button cancelButton;
        private ErrorProvider genericErrProvider;
        private Label jobStatusLabel;
        private Button getJobStatusButton;
        private Panel jobStatusIndicator;
        private Button getAnimeDataButton;
        private Button loginAgainButton;
        private RichTextBox statusCodeRTextBox;
        private Button clearAnimeButton;
    }
}

