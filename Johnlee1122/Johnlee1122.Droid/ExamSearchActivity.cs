using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using System.Threading.Tasks;
using System.Net;

namespace Johnlee1122.Droid
{
    [Activity(Label = "ExamSearchActivity")]
    public class ExamSearchActivity : Activity
    {
        public event EventHandler GetHtmlString;

        protected  override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            var worker = new StorageService();

            // Create your application here
            SetContentView(Resource.Layout.examflow_searchview);
            WebView localWebView = FindViewById<WebView>(Resource.Id.examflow_searchview_viewweb);


         
                localWebView.SetWebViewClient(new WebViewClient()); // stops request going to Web Browser

            var btnWebClient = FindViewById<Button>(Resource.Id.examflow_searchview_btnSearch);
            btnWebClient.Click += async (sender, e) => {

                //keyword

                var keyword =  await worker.LoadTextAsync("googleSearch.txt");



                var Worker = new WebWorker();
                var result = await Worker.DownloadHtmlString("https://www.google.com.tw/#q=" + keyword);
                localWebView.LoadDataWithBaseURL(
               null
               , result
               , "text/html"
               , "utf-8"
               , null);


            };
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
        public class HtmlReceivedEventArgs : EventArgs
        {
            public string Html { get; set; }
        }
    }
}