using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aninamer.util
{
    /// <summary>
    /// 
    /// </summary>
    public static class APIResponseManager
    {
        private static RichTextBox _statusTextBox;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusTextBox"></param>
        public static void Initialize(RichTextBox statusTextBox)
        {
            _statusTextBox = statusTextBox;
        }

        /// <summary>
        /// 
        /// </summary>
        private static HttpClient sharedClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5206"),
        };
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <param name="statusTextBox"></param>
        /// <returns></returns>
        public static async Task<bool> SendGetResponse(string       req,
                                                       RichTextBox  statusTextBox)
        {
            try
            {
                HttpResponseMessage response = await sharedClient.GetAsync(req);

                if (!response.IsSuccessStatusCode)
                {
                    statusTextBox.SelectionColor = Color.Red;

                    statusTextBox.AppendText(
                        $"HTTP {(int)response.StatusCode} FAILED\n");

                    return false;
                }

                string content =
                    await response.Content.ReadAsStringAsync();

                var aliveResponse =
                    JsonConvert.DeserializeObject<ServerAliveResponse>(content);

                if (aliveResponse == null || !aliveResponse.Success)
                {
                    statusTextBox.SelectionColor = Color.Red;

                    statusTextBox.AppendText(
                        "Server not alive.\n");

                    return false;
                }

                statusTextBox.SelectionColor = Color.Green;

                statusTextBox.AppendText(
                    $"HTTP {(int)response.StatusCode} OK\n");

                return true;
            }
            catch (Exception ex)
            {
                statusTextBox.SelectionColor = Color.Red;

                statusTextBox.AppendText(
                    $"ERROR: {ex.Message}\n");

                return false;
            }
        }

        public static async void SetStatusMsg(HttpResponseMessage resp)
        {
            if (_statusTextBox == null)
                return;

            string content = await resp.Content.ReadAsStringAsync();

            _statusTextBox.Clear();
            _statusTextBox.SelectionColor = Color.Red;

            _statusTextBox.AppendText("");
            Console.WriteLine(resp.StatusCode);
            Console.WriteLine(content);
            _statusTextBox.AppendText($"HTTP {(int)resp.StatusCode}\n");
            _statusTextBox.AppendText(content);
        }
    }
}
