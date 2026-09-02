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
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusCodeRTextBox = new System.Windows.Forms.RichTextBox();
            this.aidToSearchLabel = new System.Windows.Forms.Label();
            this.aidToSearchTextBox = new System.Windows.Forms.TextBox();
            this.clearAnimeButton = new System.Windows.Forms.Button();
            this.getAnimeDataButton = new System.Windows.Forms.Button();
            this.loginAgainButton = new System.Windows.Forms.Button();
            this.getJobStatusButton = new System.Windows.Forms.Button();
            this.changeAllButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.genericErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.jobStatusLabel = new System.Windows.Forms.Label();
            this.jobStatusIndicator = new System.Windows.Forms.Panel();
            this.altTitleLabel = new System.Windows.Forms.Label();
            this.altTitleTextBox = new System.Windows.Forms.TextBox();
            this.targetFilesList = new Aninamer.components.SyncedListBox();
            this.extIdList = new Aninamer.components.SyncedListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genericErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(765, 6);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(99, 42);
            this.executeButton.TabIndex = 0;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.ExecuteButton_Click);
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
            this.panel1.Location = new System.Drawing.Point(12, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 439);
            this.panel1.TabIndex = 2;
            // 
            // statusCodeRTextBox
            // 
            this.statusCodeRTextBox.Location = new System.Drawing.Point(756, 0);
            this.statusCodeRTextBox.Name = "statusCodeRTextBox";
            this.statusCodeRTextBox.ReadOnly = true;
            this.statusCodeRTextBox.Size = new System.Drawing.Size(198, 436);
            this.statusCodeRTextBox.TabIndex = 2;
            this.statusCodeRTextBox.Text = "";
            // 
            // aidToSearchLabel
            // 
            this.aidToSearchLabel.AutoSize = true;
            this.aidToSearchLabel.Location = new System.Drawing.Point(465, 11);
            this.aidToSearchLabel.Name = "aidToSearchLabel";
            this.aidToSearchLabel.Size = new System.Drawing.Size(48, 13);
            this.aidToSearchLabel.TabIndex = 7;
            this.aidToSearchLabel.Text = "AnidbID:";
            // 
            // aidToSearchTextBox
            // 
            this.aidToSearchTextBox.Location = new System.Drawing.Point(519, 8);
            this.aidToSearchTextBox.Name = "aidToSearchTextBox";
            this.aidToSearchTextBox.Size = new System.Drawing.Size(94, 20);
            this.aidToSearchTextBox.TabIndex = 8;
            // 
            // clearAnimeButton
            // 
            this.clearAnimeButton.Location = new System.Drawing.Point(282, 4);
            this.clearAnimeButton.Name = "clearAnimeButton";
            this.clearAnimeButton.Size = new System.Drawing.Size(84, 27);
            this.clearAnimeButton.TabIndex = 14;
            this.clearAnimeButton.Text = "Clear Anime";
            this.clearAnimeButton.UseVisualStyleBackColor = true;
            this.clearAnimeButton.Click += new System.EventHandler(this.clearAnimeButton_Click);
            // 
            // getAnimeDataButton
            // 
            this.getAnimeDataButton.Location = new System.Drawing.Point(192, 4);
            this.getAnimeDataButton.Name = "getAnimeDataButton";
            this.getAnimeDataButton.Size = new System.Drawing.Size(84, 27);
            this.getAnimeDataButton.TabIndex = 13;
            this.getAnimeDataButton.Text = "Get Anime";
            this.getAnimeDataButton.UseVisualStyleBackColor = true;
            this.getAnimeDataButton.Click += new System.EventHandler(this.getAnimeDataButton_Click);
            // 
            // loginAgainButton
            // 
            this.loginAgainButton.Location = new System.Drawing.Point(102, 4);
            this.loginAgainButton.Name = "loginAgainButton";
            this.loginAgainButton.Size = new System.Drawing.Size(84, 27);
            this.loginAgainButton.TabIndex = 12;
            this.loginAgainButton.Text = "Login";
            this.loginAgainButton.UseVisualStyleBackColor = true;
            this.loginAgainButton.Click += new System.EventHandler(this.LoginAgainButton_Click);
            // 
            // getJobStatusButton
            // 
            this.getJobStatusButton.Location = new System.Drawing.Point(12, 4);
            this.getJobStatusButton.Name = "getJobStatusButton";
            this.getJobStatusButton.Size = new System.Drawing.Size(84, 27);
            this.getJobStatusButton.TabIndex = 11;
            this.getJobStatusButton.Text = "Get Status";
            this.getJobStatusButton.UseVisualStyleBackColor = true;
            this.getJobStatusButton.Click += new System.EventHandler(this.getJobStatusButton_Click);
            // 
            // changeAllButton
            // 
            this.changeAllButton.Enabled = false;
            this.changeAllButton.Location = new System.Drawing.Point(870, 6);
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
            this.cancelButton.Location = new System.Drawing.Point(699, 6);
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
            this.jobStatusLabel.Location = new System.Drawing.Point(372, 11);
            this.jobStatusLabel.Name = "jobStatusLabel";
            this.jobStatusLabel.Size = new System.Drawing.Size(60, 13);
            this.jobStatusLabel.TabIndex = 12;
            this.jobStatusLabel.Text = "Job Status:";
            // 
            // jobStatusIndicator
            // 
            this.jobStatusIndicator.BackColor = System.Drawing.Color.LightCoral;
            this.jobStatusIndicator.Location = new System.Drawing.Point(437, 7);
            this.jobStatusIndicator.Name = "jobStatusIndicator";
            this.jobStatusIndicator.Size = new System.Drawing.Size(21, 20);
            this.jobStatusIndicator.TabIndex = 13;
            // 
            // altTitleLabel
            // 
            this.altTitleLabel.AutoSize = true;
            this.altTitleLabel.Location = new System.Drawing.Point(21, 36);
            this.altTitleLabel.Name = "altTitleLabel";
            this.altTitleLabel.Size = new System.Drawing.Size(45, 13);
            this.altTitleLabel.TabIndex = 15;
            this.altTitleLabel.Text = "Alt Title:";
            // 
            // altTitleTextBox
            // 
            this.altTitleTextBox.Location = new System.Drawing.Point(75, 33);
            this.altTitleTextBox.Name = "altTitleTextBox";
            this.altTitleTextBox.Size = new System.Drawing.Size(538, 20);
            this.altTitleTextBox.TabIndex = 16;
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
            this.targetFilesList.Location = new System.Drawing.Point(386, 0);
            this.targetFilesList.Name = "targetFilesList";
            this.targetFilesList.Partner = null;
            this.targetFilesList.Size = new System.Drawing.Size(364, 436);
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
            this.extIdList.Location = new System.Drawing.Point(0, 0);
            this.extIdList.Name = "extIdList";
            this.extIdList.Partner = null;
            this.extIdList.Size = new System.Drawing.Size(374, 436);
            this.extIdList.TabIndex = 0;
            this.extIdList.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(978, 506);
            this.Controls.Add(this.altTitleTextBox);
            this.Controls.Add(this.altTitleLabel);
            this.Controls.Add(this.aidToSearchTextBox);
            this.Controls.Add(this.aidToSearchLabel);
            this.Controls.Add(this.clearAnimeButton);
            this.Controls.Add(this.jobStatusIndicator);
            this.Controls.Add(this.getAnimeDataButton);
            this.Controls.Add(this.jobStatusLabel);
            this.Controls.Add(this.loginAgainButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.getJobStatusButton);
            this.Controls.Add(this.changeAllButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.executeButton);
            this.Name = "MainWindow";
            this.Text = "Aninamer";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panel1.ResumeLayout(false);
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
        //private FileHelper fh;
        private System.Windows.Forms.Panel panel1;
        private Aninamer.components.SyncedListBox targetFilesList;
        private Aninamer.components.SyncedListBox extIdList;
        private Label aidToSearchLabel;
        private TextBox aidToSearchTextBox;
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
        private TextBox altTitleTextBox;
        private Label altTitleLabel;
    }
}

