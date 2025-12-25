using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aninamer.util
{
    public sealed class BrowserManager : IDisposable
    {
        private static readonly Lazy<BrowserManager> _instance =
            new Lazy<BrowserManager>(() => new BrowserManager());

        public static BrowserManager Instance => _instance.Value;

        public ChromeDriver Driver { get; private set; }

        private BrowserManager()
        {
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            var options = new ChromeOptions();
            options.AddArgument("--headless");

            Driver = new ChromeDriver(service, options);
        }

        public void Dispose()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}
