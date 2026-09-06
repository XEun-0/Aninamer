using AngleSharp.Text;
using Aninamer.util;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace Aninamer
{
    public partial class MainWindow : Form
    {
        private int dragOverIndex = -1;
        private object targetSave = null;
        private string currOpenDir = null;
        private string animeTitle = null;
        private string animeTitleNoAID = null;
        string[] allowed = { ".mkv", ".mp4", ".avi", ".mov" };

        private List<string> _mediaFiles = new List<string>();
        private List<EpisodeFile> _animeFiles = new List<EpisodeFile>();

        // Not used. Remove later, save for now.
        // private string anidbTitle = "";
        private string anidbAnimeID = "";

        private static HttpClient sharedClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5206"),
        };

        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            InitializeExtras();

            APIResponseManager.Initialize(statusCodeRTextBox);

            // Sync scrolling both ways
            targetFilesList.Partner = extIdList;
            extIdList.Partner = targetFilesList;

            //Console.WriteLine("Extracting Episode Number: " + FileHelper.ExtractEpisodeNumber("", 12));
        }

        private string ResolveSafeAnimeFolderName(
            string longTitle,
            string shortTitle,
            int episodeCount,
            string basePath)
        {
            const int SAFETY_MARGIN = 50; // buffer for separators + extensions
            const int MAX_PATH_ESTIMATE = 200; // safe cross-platform-ish limit

            // Estimate worst-case episode filename addition
            int episodeBuffer = 15;
            // e.g. "E01 [anidbid-12345].mkv"

            string testPath = Path.Combine(basePath, longTitle);

            int estimatedLength = testPath.Length + episodeBuffer + SAFETY_MARGIN;

            if (estimatedLength > MAX_PATH_ESTIMATE)
            {
                Console.WriteLine("[PathCheck] Too long -> using short title fallback");
                return shortTitle;
            }

            return longTitle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(aidToSearchTextBox.Text))
            {
                genericErrProvider.SetError(aidToSearchTextBox, "Please enter an AnidbID.");
                return;
            }
            else
            {
                genericErrProvider.Clear();
            }

            HttpResponseMessage response = await sharedClient.GetAsync("/api/anidb/alive");

            //statusCodeRTextBox.SelectionColor = Color.Red;


            Console.WriteLine(response.StatusCode);
            //statusCodeRTextBox.AppendText($"HTTP {(int)response.StatusCode}\n");

            APIResponseManager.SetStatusMsg(response);




            string content = await response.Content.ReadAsStringAsync();

            var aliveResponse = JsonConvert.DeserializeObject<ServerAliveResponse>(content);

            Console.WriteLine(content);

            Console.WriteLine(aliveResponse.Success);

            //==========================================================

            if (aliveResponse.Success)
            {
                HttpResponseMessage loginResponse = await sharedClient.GetAsync("/api/anidb/login/execute");

                content = await loginResponse.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                HttpResponseMessage loadAnimeResponse = await sharedClient.GetAsync("/api/anidb/aid/" + aidToSearchTextBox.Text);

                content = await loadAnimeResponse.Content.ReadAsStringAsync();
                Console.WriteLine(content);

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
                //string jsonInput = Prompt.ShowDialog("Paste JSON content here:", "Import Data");

                //if (!string.IsNullOrEmpty(jsonInput))
                const string statusURL = "/api/anidb/aid/episodes/status/0";
                const string getAnimeURL = "/api/anidb/aid/episodes/get";

                HttpResponseMessage getAnimeURLStatusResponse = await sharedClient.GetAsync(getAnimeURL);

                Console.WriteLine(getAnimeURLStatusResponse.ToString());
                await System.Threading.Tasks.Task.Delay(5000);

                while (true)
                {
                    HttpResponseMessage statusResponse = await sharedClient.GetAsync(statusURL);

                    statusResponse.EnsureSuccessStatusCode();

                    string json = await statusResponse.Content.ReadAsStringAsync();

                    var statusResponseJSON =
                        JsonConvert.DeserializeObject<AniDbResponse>(json);

                    Console.WriteLine(statusResponseJSON?.Status);
                    if (statusResponseJSON?.Status == "processing")
                    {
                        await System.Threading.Tasks.Task.Delay(6000);
                        continue;
                    }
                    else if (statusResponseJSON?.Status == "done")
                    {
                        var data = JsonConvert.DeserializeObject<AniDbResponse>(json);

                        //targetFilesList.Items.Clear();
                        //_animeFiles.Clear();

                        var animeName = "";
                        var startAirDate = "";

                        animeName = data.Data.Anime.AnimeName + " ";
                        startAirDate = "(" + data.Data.Anime.AirDateYear + ")";

                        anidbAnimeID = " [anidbid-" + data.Data.Anime.Aid + "]";

                        animeName = FileHelper.SanitizeFileName(animeName, startAirDate);
                        
                        // Delete this later
                        if (!string.IsNullOrWhiteSpace(altTitleTextBox.Text))
                        {
                            animeName = altTitleTextBox.Text;
                        }
                        // Delete the lambda portion later
                        string shortTitle = string.IsNullOrWhiteSpace(data.Data.Anime.AnimeNameShort)
                                            ? altTitleTextBox.Text
                                            : data.Data.Anime.AnimeNameShort;

                        animeTitleNoAID = ResolveSafeAnimeFolderName(
                            animeName.Trim() + " " + startAirDate,
                            shortTitle,
                            data.Data.Episodes.Count,
                            currOpenDir
                        );

                        animeTitle = FileHelper.SanitizeFileName(
                                                                    animeTitleNoAID +
                                                                    anidbAnimeID
                                                                );

                        Console.WriteLine("SANITIZED ANIME TITLE: " + animeTitle);
                        Console.WriteLine("SANITIZED ANIME TITLE2: " + animeTitleNoAID);

                        foreach (EpisodeEntry episodes in data.Data.Episodes)
                        {
                            var episodeNumber = episodes.EpisodeNumber;
                            string episodeNumberStr;

                            // Episode ID is not to be confused with Anime ID.
                            var episodeId = episodes.Eid;

                            episodeNumberStr = "E" + episodeNumber.ToString();

                            extIdList.Items.Add(episodeNumberStr + " [anidbid-" + episodeId + "]");
                        }

                        Console.WriteLine("DIFFERENCE: " + (extIdList.Items.Count - targetFilesList.Items.Count));

                        // Save targetFilesList original item count
                        int snapshotFilesCount = targetFilesList.Items.Count;
                        for (int i = 0; i < (extIdList.Items.Count - snapshotFilesCount); i++)
                        {
                            targetFilesList.Items.Add(" --- " + i);
                        }


                        executeButton.Enabled = false;
                        cancelButton.Enabled = true;
                        //anidbParentUrl.Enabled  = false;
                        changeAllButton.Enabled = true;

                        break;
                    }

                }
            }
        }
        
        #region targetFilesList event handlers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TargetFilesList_MouseDown(object sender, MouseEventArgs e)
        {
            if (targetFilesList.SelectedItem == null) return;

            targetSave = targetFilesList.SelectedItem;
            targetFilesList.DoDragDrop(targetFilesList.SelectedItem, DragDropEffects.Move);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TargetFilesList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TargetFilesList_DragOver(object sender, DragEventArgs e)
        {
            Point p = targetFilesList.PointToClient(new Point(e.X, e.Y));
            dragOverIndex = targetFilesList.IndexFromPoint(p);
            targetFilesList.Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // None, may delete
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeAllButton_Click(object sender, EventArgs e)
        {
            bool checkGood = true;
            EpisodeFile tempAnimFile;

            Console.WriteLine("ANIME TITLE IS: " + animeTitle);
            // Directory Package Creation
            // Make Anime Name + anidbid for the title
            string madeDir = DirectoryHelper.CreatePackageDirectory(currOpenDir, animeTitle);

            // Make the Season 01 folder nested inside the Anime main title folder
            string madeNestedDir = DirectoryHelper.CreatePackageDirectory(madeDir, "Season 01");

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
                        tempAnimFile.TargetFilePath = Path.Combine(
                                                                    madeNestedDir,
                                                                    animeTitleNoAID
                                                                    + " - S01"
                                                                    + extIdList.Items[extIdListIdx]
                                                                    + _animeFiles[aFileCounter].FileExt
                                                                  );

                        try
                        {
                            File.Move(fNamesPath, tempAnimFile.TargetFilePath);
                        }
                        catch
                        {
                            string altTitle = PromptForAltTitle();
                            Console.WriteLine("EXCEPTION HERE");
                            if (!string.IsNullOrEmpty(altTitle))
                            {
                                // Do something here
                                Console.WriteLine("EXCEPTION HERE");
                            }
                        }
                        

                        aFileCounter++;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void cancelButton_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = await sharedClient.GetAsync("/api/anidb/aid/clear");
            string content = await response.Content.ReadAsStringAsync();
            var clearResponse = JsonConvert.DeserializeObject<ServerAliveResponse>(content);

            Console.WriteLine(content);

            Console.WriteLine(clearResponse.Success);


            // Reenable all the buttons
            executeButton.Enabled = true;
            cancelButton.Enabled = false;
            changeAllButton.Enabled = false;

            // Clear ListBoxes
            targetFilesList.Items.Clear();
            extIdList.Items.Clear();

            // Clear AnimeFiles struct list
            _animeFiles.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoginAgainButton_Click(object sender, EventArgs e)
        {
            string httpcmd = "/api/anidb/login/execute";

            HttpResponseMessage response = await sharedClient.GetAsync(httpcmd);

            APIResponseManager.SetStatusMsg(response);

            string content = await response.Content.ReadAsStringAsync();

            var aliveResponse = JsonConvert.DeserializeObject<ServerAliveResponse>(content);

            Console.WriteLine(content);

            Console.WriteLine(aliveResponse.Success);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void getAnimeDataButton_Click(object sender, EventArgs e)
        {
            int animeAID = 0;
            
            if (string.IsNullOrEmpty(aidToSearchTextBox.Text))
            {
                genericErrProvider.SetError(aidToSearchTextBox, "Please enter an AnidbID.");
                return;
            }
            else
            {
                genericErrProvider.Clear();
            }
            animeAID = int.Parse(aidToSearchTextBox.Text);

            HttpResponseMessage response = await sharedClient.GetAsync($"/api/anidb/aid/{animeAID}");

            APIResponseManager.SetStatusMsg(response);

            string content = await response.Content.ReadAsStringAsync();

            var aliveResponse = JsonConvert.DeserializeObject<ServerAliveResponse>(content);

            Console.WriteLine(content);

            Console.WriteLine(aliveResponse.Success);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void getJobStatusButton_Click(object sender, EventArgs e)
        {
             HttpResponseMessage response = await sharedClient.GetAsync("/api/anidb/alive");

            APIResponseManager.SetStatusMsg(response);

            string content = await response.Content.ReadAsStringAsync();

            var aliveResponse = JsonConvert.DeserializeObject<ServerAliveResponse>(content);

            Console.WriteLine(content);

            Console.WriteLine(aliveResponse.Success);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void clearAnimeButton_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = await sharedClient.GetAsync("api/anidb/aid/clear");

            APIResponseManager.SetStatusMsg(response);

            string content = await response.Content.ReadAsStringAsync();

            var aliveResponse = JsonConvert.DeserializeObject<ServerAliveResponse>(content);

            Console.WriteLine(content);

            Console.WriteLine(aliveResponse.Success);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            // None
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string PromptForAltTitle()
        {
            Form dialog = new Form
            {
                Text = "Alternate Title",
                Width = 400,
                Height = 150,
                StartPosition = FormStartPosition.CenterParent
            };

            TextBox textBox = new TextBox
            {
                Left = 10,
                Top = 35,
                Width = 350
            };

            Label label = new Label
            {
                Text = "Enter an alternate title:",
                Left = 10,
                Top = 10,
                Width = 350
            };

            Button okButton = new Button
            {
                Text = "OK",
                Left = 200,
                Top = 70,
                Width = 75,
                DialogResult = DialogResult.OK
            };

            Button cancelButton = new Button
            {
                Text = "Cancel",
                Left = 285,
                Top = 70,
                Width = 75,
                DialogResult = DialogResult.Cancel
            };

            dialog.Controls.AddRange(new Control[]
            {
                label,
                textBox,
                okButton,
                cancelButton
            });

            dialog.AcceptButton = okButton;
            dialog.CancelButton = cancelButton;

            return dialog.ShowDialog() == DialogResult.OK &&
                   !string.IsNullOrWhiteSpace(textBox.Text)
                ? textBox.Text.Trim()
                : null;
        }
    }
}
