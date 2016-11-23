using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Johnlee1122.iOS.LoginFlow
{
    public class HtmlReceivedEventArgs : EventArgs
    {
        public string Html { get; set; }
    }

    public class WebWorker
    {
        private WebClient MyWebClient { get; set; }

        public WebWorker()
        {
            MyWebClient = new WebClient();
        }

        public async Task<string> DownloadHtmlString(string url)
        {
            var task = MyWebClient.DownloadStringTaskAsync(url);
            var result = await task;

            EventHandler<HtmlReceivedEventArgs> handler = HtmlStringReceived;
            var args = new HtmlReceivedEventArgs { Html = result };
            if (null != handler)
            {
                handler(this, args);
            }

            return result;
        }
        public event EventHandler<HtmlReceivedEventArgs> HtmlStringReceived;
    }

}
