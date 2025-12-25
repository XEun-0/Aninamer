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
            this.anidbParentUrl = new System.Windows.Forms.TextBox();
            this.anidbParentUrlLabel = new System.Windows.Forms.Label();
            this.targetTitleTextBox = new System.Windows.Forms.TextBox();
            this.targetTitleLabel = new System.Windows.Forms.Label();
            this.prefixTitleLabel = new System.Windows.Forms.Label();
            this.prefixTitleTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.changeAllButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.targetFilesList = new Aninamer.components.SyncedListBox();
            this.extIdList = new Aninamer.components.SyncedListBox();
            this.genericErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.panel1.Controls.Add(this.targetFilesList);
            this.panel1.Controls.Add(this.extIdList);
            this.panel1.Location = new System.Drawing.Point(12, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 386);
            this.panel1.TabIndex = 2;
            // 
            // anidbParentUrl
            // 
            this.anidbParentUrl.Location = new System.Drawing.Point(85, 32);
            this.anidbParentUrl.Name = "anidbParentUrl";
            this.anidbParentUrl.Size = new System.Drawing.Size(387, 20);
            this.anidbParentUrl.TabIndex = 3;
            // 
            // anidbParentUrlLabel
            // 
            this.anidbParentUrlLabel.AutoSize = true;
            this.anidbParentUrlLabel.Location = new System.Drawing.Point(13, 35);
            this.anidbParentUrlLabel.Name = "anidbParentUrlLabel";
            this.anidbParentUrlLabel.Size = new System.Drawing.Size(66, 13);
            this.anidbParentUrlLabel.TabIndex = 4;
            this.anidbParentUrlLabel.Text = "Parent URL:";
            // 
            // targetTitleTextBox
            // 
            this.targetTitleTextBox.Location = new System.Drawing.Point(368, 3);
            this.targetTitleTextBox.Name = "targetTitleTextBox";
            this.targetTitleTextBox.Size = new System.Drawing.Size(239, 20);
            this.targetTitleTextBox.TabIndex = 5;
            // 
            // targetTitleLabel
            // 
            this.targetTitleLabel.AutoSize = true;
            this.targetTitleLabel.Location = new System.Drawing.Point(298, 6);
            this.targetTitleLabel.Name = "targetTitleLabel";
            this.targetTitleLabel.Size = new System.Drawing.Size(64, 13);
            this.targetTitleLabel.TabIndex = 6;
            this.targetTitleLabel.Text = "Target Title:";
            // 
            // prefixTitleLabel
            // 
            this.prefixTitleLabel.AutoSize = true;
            this.prefixTitleLabel.Location = new System.Drawing.Point(3, 6);
            this.prefixTitleLabel.Name = "prefixTitleLabel";
            this.prefixTitleLabel.Size = new System.Drawing.Size(33, 13);
            this.prefixTitleLabel.TabIndex = 7;
            this.prefixTitleLabel.Text = "Prefix";
            // 
            // prefixTitleTextBox
            // 
            this.prefixTitleTextBox.Location = new System.Drawing.Point(42, 3);
            this.prefixTitleTextBox.Name = "prefixTitleTextBox";
            this.prefixTitleTextBox.Size = new System.Drawing.Size(239, 20);
            this.prefixTitleTextBox.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.changeAllButton);
            this.panel2.Controls.Add(this.prefixTitleLabel);
            this.panel2.Controls.Add(this.targetTitleTextBox);
            this.panel2.Controls.Add(this.targetTitleLabel);
            this.panel2.Controls.Add(this.prefixTitleTextBox);
            this.panel2.Location = new System.Drawing.Point(12, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 46);
            this.panel2.TabIndex = 9;
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
            // targetFilesList
            // 
            this.targetFilesList.AllowDrop = true;
            this.targetFilesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.targetFilesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.targetFilesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetFilesList.FormattingEnabled = true;
            this.targetFilesList.ItemHeight = 16;
            this.targetFilesList.Location = new System.Drawing.Point(412, 0);
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
            this.extIdList.ItemHeight = 16;
            this.extIdList.Location = new System.Drawing.Point(6, 0);
            this.extIdList.Name = "extIdList";
            this.extIdList.Partner = null;
            this.extIdList.Size = new System.Drawing.Size(374, 372);
            this.extIdList.TabIndex = 0;
            this.extIdList.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // genericErrProvider
            // 
            this.genericErrProvider.ContainerControl = this;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 506);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.anidbParentUrlLabel);
            this.Controls.Add(this.anidbParentUrl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.executeButton);
            this.Name = "MainWindow";
            this.Text = "Form1";
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
        private System.Windows.Forms.TextBox anidbParentUrl;
        private Label anidbParentUrlLabel;
        private TextBox targetTitleTextBox;
        private Label targetTitleLabel;
        private Label prefixTitleLabel;
        private TextBox prefixTitleTextBox;
        private Panel panel2;
        private Button changeAllButton;
        private Button cancelButton;
        private ErrorProvider genericErrProvider;
    }
}

