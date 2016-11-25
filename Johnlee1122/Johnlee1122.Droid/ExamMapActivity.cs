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
using static Johnlee1122.Droid.ExamSearchActivity;

namespace Johnlee1122.Droid
{
    [Activity(Label = "ExamMapActivity")]
    public class ExamMapActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
           


            var worker = new StorageService();

            // Create your application here
            SetContentView(Resource.Layout.examflow_mapview);
            WebView localWebView = FindViewById<WebView>(Resource.Id.examflow_mapview_viewweb);



            localWebView.SetWebViewClient(new WebViewClient()); // stops request going to Web Browser

            var btnWebClient = FindViewById<Button>(Resource.Id.examflow_mapview_btnSearch);
            btnWebClient.Click += async (sender, e) => {

                //keyword

                var latlngs = (await worker.LoadTextAsync("map.txt")).Split('&');


                var Worker = new WebWorker();
                var result = await Worker.DownloadHtmlString("https://www.google.com.tw/maps/@22.6397664,120.2999183,17z");
                localWebView.LoadDataWithBaseURL(
               null
               , result
               , "text/html"
               , "utf-8"
               , null);


            };
        }
    }
}