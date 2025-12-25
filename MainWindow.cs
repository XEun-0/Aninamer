using AngleSharp.Attributes;
using AngleSharp.Text;
using Aninamer.util;
using HtmlAgilityPack;
using Microsoft.WindowsAPICodePack.Dialogs;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Script;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Aninamer
{
    public partial class MainWindow : Form
    {        
        private int dragOverIndex = -1;
        private object targetSave = null;
        private string currOpenDir = null;
        string[] allowed = { ".mkv", ".mp4", ".avi", ".mov" };

        private List<string> _mediaFiles = new List<string>();
        private List<AnimeFile> _animeFiles = new List<AnimeFile>();

        /**
         * MainWindow
         * 
         * MainWindow constructor function
         */
        public MainWindow()
        {
            InitializeComponent();
            InitializeExtras();

            // Sync scrolling both ways
            targetFilesList.Partner = extIdList;
            extIdList.Partner = targetFilesList;
        }

        /**
         * TargetFilesList_MouseDown
         * 
         * Event handler for MouseDown event for TargetFilesList
         */
        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // Clear existing items in the listBox
                targetFilesList.Items.Clear();

                // Get all files in the selected directory
                currOpenDir = dialog.FileName;
                _mediaFiles = Directory
                    .EnumerateFiles(currOpenDir)
                    .Where(f => allowed.Contains(Path.GetExtension(f).ToLower()))
                    .ToList();

                // Extract only file names and add to targetFilesList
                int fileCounter = 0;

                foreach (var file in _mediaFiles)
                {
                    targetFilesList.Items.Add(Path.GetFileNameWithoutExtension(file));

                    // Create an anime file for each episode
                    var tempAFile = FileHelper.CreateAnimeFile(
                                            file.ToString(), 
                                            Path.GetDirectoryName(file), 
                                            Path.GetExtension(file),
                                            fileCounter
                                        );

                    tempAFile.CurrIdx = fileCounter;
                    tempAFile.CurrentFileRef = Path.GetFileNameWithoutExtension(file);
                    _animeFiles.Add(tempAFile);

                    fileCounter++;
                }
            }

            var driver = BrowserManager.Instance.Driver;
            string anidbParentUrlString = anidbParentUrl.Text;

            if (!string.IsNullOrEmpty(anidbParentUrlString))
            {
                try
                {
                    driver.Navigate().GoToUrl(anidbParentUrlString);
                    var episodeLinks = driver.FindElements(By.CssSelector("td.id.eid a[href^='/episode/']"));
                    var animeTitle = driver.FindElement(By.CssSelector("td.value span[itemprop='name']")).Text;

                    Console.WriteLine("ANIME TITLE: " + animeTitle);
                    Console.WriteLine("SANITEZED: " + FileHelper.SanitizeFileName(animeTitle));

                    foreach (var link in episodeLinks)
                    {
                        var href = link.GetAttribute("href");
                        var epNumElement = link.FindElement(By.CssSelector("td.id.eid abbr[itemprop='episodeNumber']"));

                        var episodeNumber = epNumElement.Text.Trim();
                        string episodeNumberStr;

                        // Episode ID is not to be confused with Anime ID.
                        var episodeId = href.Split('/').Last();

                        if (episodeNumber.ToInteger(0) == 0)
                        {
                            episodeNumberStr = episodeNumber;
                        }
                        else if (episodeNumber.ToInteger(0) < 10)
                        {
                            episodeNumberStr = "E0" + episodeNumber.ToString();
                        } 
                        else
                        {
                            episodeNumberStr = "E" + episodeNumber.ToString();
                        }

                            extIdList.Items.Add(episodeNumberStr + " [anidbid-" + episodeId + "]");
                        //targetFilesList.Items.Add("E" + episodeNumber + " [anidbid-" + episodeId + "]");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error scraping AniDB page: " + ex.Message);
                }
            }

            Console.WriteLine("DIFFERENCE: " + (extIdList.Items.Count - targetFilesList.Items.Count));
            
            // Save targetFilesList original item count
            int snapshotFilesCount = targetFilesList.Items.Count;
            for(int i = 0; i < (extIdList.Items.Count - snapshotFilesCount); i++)
            {
                targetFilesList.Items.Add(" --- " + i);
            }

            executeButton.Enabled   = false;
            cancelButton.Enabled    = true;
            anidbParentUrl.Enabled  = false;
            changeAllButton.Enabled = true;
        }

        #region targetFilesList event handlers

        /**
         * TargetFilesList_MouseDown
         * 
         * Event handler for MouseDown event for TargetFilesList
         */
        private void TargetFilesList_MouseDown(object sender, MouseEventArgs e)
        {
            if (targetFilesList.SelectedItem == null) return;

            targetSave = targetFilesList.SelectedItem;
            targetFilesList.DoDragDrop(targetFilesList.SelectedItem, DragDropEffects.Move);
        }

        /**
         * TargetFilesList_DragEnter
         * 
         * Event handler for DragEnter event for TargetFilesList
         */
        private void TargetFilesList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /**
         * TargetFilesList_DragOver
         * 
         * Event handler for DragOver event for TargetFilesList
         */
        private void TargetFilesList_DragOver(object sender, DragEventArgs e)
        {
            Point p = targetFilesList.PointToClient(new Point(e.X, e.Y));
            dragOverIndex = targetFilesList.IndexFromPoint(p);
            targetFilesList.Invalidate();
        }

        /**
         * TargetFilesList_DragDrop
         * 
         * Event handler for DragDrop event for TargetFilesList
         */
        private void TargetFilesList_DragDrop(object sender, DragEventArgs e)
        {
            Point p = targetFilesList.PointToClient(new Point(e.X, e.Y));
            int index = targetFilesList.IndexFromPoint(p);
            if (index < 0) index = targetFilesList.Items.Count - 1;

            object data = e.Data.GetData(typeof(string));
            targetFilesList.Items.Remove(data);
            targetFilesList.Items.Insert(index, data);
            targetFilesList.SelectedIndex = index;

            dragOverIndex = -1;
            targetFilesList.Invalidate();
        }

        /**
         * TargetFilesList_DrawItem
         * 
         * Event handler for DrawItem event for TargetFilesList
         */
        private void TargetFilesList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Draw the background (handles selected & normal)
            e.DrawBackground();

            string text = targetFilesList.Items[e.Index].ToString();

            // Choose text color based on selection
            Brush textBrush =
                (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? Brushes.White     // selected text
                : Brushes.Black;    // normal text

            // Draw the text
            e.Graphics.DrawString(
                text,
                e.Font,
                textBrush,
                e.Bounds
            );

            // Draw the drag-over indicator if needed
            if (e.Index == dragOverIndex)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawLine(pen,
                    e.Bounds.Left, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Top);
                }
            }

            e.DrawFocusRectangle();
        }

        /**
         * ListBox_SelectedIndexChanged
         * 
         * Event handler for ListBox for SelectedIndexChanged
         */
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is ListBox senderCast))
            {
                return;
            }

            if (senderCast == targetFilesList && senderCast.Focused)
            {
                if (senderCast.SelectedIndex != -1)
                {
                    Console.WriteLine(targetSave.ToString() + " index: " + senderCast.SelectedIndex);
                    
                    // Get files from curr open directory
                    //Console.WriteLine(Directory.GetFiles(currOpenDir)[senderCast.SelectedIndex]);

                    if (extIdList.SelectedIndex != senderCast.SelectedIndex)
                    {
                        extIdList.SetSelected(senderCast.SelectedIndex, true);
                    }
                }
            }
            else if (senderCast == extIdList && senderCast.Focused)
            {
                Console.WriteLine(senderCast.SelectedItem.ToString() + " index: " + senderCast.SelectedIndex);

                //if (targetFilesList.SelectedIndex != -1)
                //{
                    if (senderCast.SelectedIndex != targetFilesList.SelectedIndex)
                    {
                        targetFilesList.SetSelected(extIdList.SelectedIndex, true);
                    }
                //}
                    
            }
        }
        #endregion

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ChangeAllButton_Click(object sender, EventArgs e)
        {
            bool checkGood = true;
            AnimeFile tempAnimFile;

            // Show Tooltips if fields are empty
            if (string.IsNullOrWhiteSpace(targetTitleTextBox.Text))
            {
                genericErrProvider.SetError(targetTitleLabel, "Please enter the anime title");
                checkGood = false;
            }

            // Remove future
            //if (string.IsNullOrWhiteSpace(prefixTitleTextBox.Text))
            //{
            //    genericErrProvider.SetError(prefixTitleLabel, "Please enter anime name");
            //    checkGood = false;
            //}

            // Update the AnimeFiles
            if (Directory.Exists(currOpenDir) && checkGood)
            {
                Console.WriteLine("Opened " + currOpenDir);

                for (int aFileCount = 0; aFileCount < _animeFiles.Count; aFileCount++)
                {
                    tempAnimFile = _animeFiles[aFileCount];

                    // Future update probably want to update index during DragDrop event
                    // This will do for now
                    tempAnimFile.CurrIdx = targetFilesList.Items.IndexOf(tempAnimFile.CurrentFileRef);

                    _animeFiles[aFileCount] = tempAnimFile;

                    Console.WriteLine("INDEX: " + tempAnimFile.CurrIdx + "\n" + tempAnimFile.ToString());
                }

                int aFileCounter = 0;
                foreach (var fNamesPath in _mediaFiles)
                {
                    if (File.Exists(fNamesPath))
                    {
                        int extIdListIdx = _animeFiles[aFileCounter].CurrIdx;
                        tempAnimFile = _animeFiles[aFileCounter];
                        
                        // The hardcoded S01 is if you like splitting seasons into it's own
                        // media and not under the same base anime
                        tempAnimFile.TargetFilePath = _animeFiles[aFileCounter].FileDir + "\\"
                                                                        + targetTitleTextBox.Text
                                                                        + " - S01"
                                                                        + extIdList.Items[extIdListIdx]
                                                                        + _animeFiles[aFileCounter].FileExt;

                        // Keep for debugging
                        //Console.WriteLine(tempAnimFile.TargetFilePath);
                        //Console.WriteLine(fNamesPath);

                        File.Move(fNamesPath, tempAnimFile.TargetFilePath);
                        
                        aFileCounter++;
                    }
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            executeButton.Enabled   = true;
            anidbParentUrl.Enabled  = true;
            cancelButton.Enabled    = false;
            changeAllButton.Enabled = false;

            targetFilesList.Items.Clear();
            extIdList.Items.Clear();
        }
    }
}
