using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System.Text.RegularExpressions;
using Android.Webkit;
using Debug = System.Diagnostics.Debug;
using Android.Views.InputMethods;

namespace Johnlee1122.Droid
{
    [Activity(Label = "WebViewActivity")]
    public class WebViewActivity : Activity
    {
        private WebView MyWebView { get; set; }
        private EditText TxtUrl { get; set; }
        private Button BtnGo { get; set; }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.webflow_mywebview);

            #region WebView

            var client = new ContentWebViewClient();

            client.WebViewLocaitonChanged += (object sender, ContentWebViewClient.WebViewLocaitonChangedEventArgs e) => {

                Debug.WriteLine(e.CommandString);      
            };

            client.WebViewLoadCompleted += (object sender, ContentWebViewClient.WebViewLoadCompletedEventArgs e) => {

                RunOnUiThread(() => {

                    //AndHUD.Shared.Dismiss(this);
                    Debug.WriteLine("WebViewLoad");
                });

            };


            MyWebView = FindViewById<WebView>(Resource.Id.webflow_webview_viewweb);
            // NOTICE : �������@�몺 WebViewClient
            //MyWebView.SetWebViewClient(client);
            MyWebView.SetWebViewClient(new MyWebClient());

            MyWebView.Settings.JavaScriptEnabled = true;
            MyWebView.Settings.UserAgentString = @"Android";

            // �t�d�P�������q - WebView -> Native
            MyJSInterface myJSInterface = new MyJSInterface(this);

            MyWebView.AddJavascriptInterface(myJSInterface, "TP");
            myJSInterface.CallFromPageReceived += delegate (object sender, MyJSInterface.CallFromPageReceivedEventArgs e) {

                //MyWebView.LoadUrl("http://developer.xamarin.com");

                Debug.WriteLine(e.Result);
            };

            // �t�d�P�������q - Native -> WebView
            JavaScriptResult callResult = new JavaScriptResult();
            callResult.JavaScriptResultReceived += (object sender, JavaScriptResult.JavaScriptResultReceivedEventArgs e) => {
                Debug.WriteLine(e.Result);
            };


            // ���J�@�����
            //MyWebView.LoadUrl ("http://stackoverflow.com/");
            // ���J�H�U�{���X�i�椬��

            MyWebView.LoadDataWithBaseURL(
                null
                , @"<html>
						<head>
							<title>Local String</title>
							<style type='text/css'>p{font-family : Verdana; color : purple }</style>
							<script language='JavaScript'> 
								var lookup = '����T��'
								function msg(){ window.location = 'callfrompage://Hi'  }
							</script>
						</head>
						<body><p>Hello World!</p><br />
							<button type='button' onclick='TP.CallFromPage(lookup)' text='Hi From Page'>Hi From Page</button>
						</body>
					</html>"
                , "text/html"
                , "utf-8"
                , null);



            #endregion

            BtnGo = FindViewById<Button>(Resource.Id.webflow_webview_btngo);
            BtnGo.Click += (object sender, EventArgs e) => {

                RunOnUiThread(() => {

                    MyWebView.EvaluateJavascript(@"msg();", callResult);
                });

                /*
				var url = TxtUrl.Text.Trim() ;

				AlertDialog.Builder alert = new AlertDialog.Builder (this);
				alert.SetTitle (url);
				alert.SetNegativeButton( "����", (senderAlert, args) =>{


				});
				alert.SetPositiveButton( "�T�{", (senderAlert, args) =>{

					RunOnUiThread(
						()=>{
							AndHUD.Shared.Show(this, "Status Message", -1, MaskType.Clear);
						}

					);

					MyWebView.LoadUrl (url);

				});

				RunOnUiThread (() => {
					alert.Show();
				} );

				// 
				_InputMethodManager.HideSoftInputFromWindow( 
					TxtUrl.WindowToken, 
					HideSoftInputFlags.None );
				*/
            };
        }

        private bool IsUrl(string inputString)
        {

            Regex urlchk = new Regex(@"((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,15})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return urlchk.IsMatch(inputString);
        }

        // Call from Page
        public class MyJSInterface : Java.Lang.Object
        {
            Context Context { get; set; }

            public MyJSInterface(Context context)
            {
                this.Context = context;
            }

            [Java.Interop.Export]
            [JavascriptInterface]
            public void CallFromPage(string parameter)
            {
                Debug.WriteLine($"CallFromPage:{parameter}");

                EventHandler<CallFromPageReceivedEventArgs> handler =
                    CallFromPageReceived;

                if (null != handler)
                {
                    handler(this,
                        new CallFromPageReceivedEventArgs
                        {
                            Result = parameter
                        });
                }
            }

            public event EventHandler<CallFromPageReceivedEventArgs> CallFromPageReceived;

            public class CallFromPageReceivedEventArgs : EventArgs
            {
                public string Result { get; set; }
            }
        }


        // Call Page
        public class JavaScriptResult : Java.Lang.Object, IValueCallback
        {

            public void OnReceiveValue(Java.Lang.Object result)
            {
                Java.Lang.String json = (Java.Lang.String)result;

                var resultString = json.ToString();

                EventHandler<JavaScriptResultReceivedEventArgs> handler =
                    JavaScriptResultReceived;

                if (null != handler)
                {
                    handler(this,
                        new JavaScriptResultReceivedEventArgs
                        {
                            Result = resultString ?? ""
                        });
                }


            }

            public event EventHandler<JavaScriptResultReceivedEventArgs> JavaScriptResultReceived;

            public class JavaScriptResultReceivedEventArgs : EventArgs
            {
                public string Result { get; set; }
            }

        }

        public class MyWebClient : WebViewClient { }

        public class ContentWebViewClient : WebViewClient
        {

            public event EventHandler<WebViewLocaitonChangedEventArgs> WebViewLocaitonChanged;

            public event EventHandler<WebViewLoadCompletedEventArgs> WebViewLoadCompleted;

            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                EventHandler<WebViewLocaitonChangedEventArgs> handler =
                    WebViewLocaitonChanged;

                if (null != handler)
                {
                    handler(this,
                        new WebViewLocaitonChangedEventArgs
                        {
                            CommandString = url
                        });
                }

                return base.ShouldOverrideUrlLoading(view, url);

            }


            public override void OnPageFinished(WebView view, string url)
            {
                base.OnPageFinished(view, url);

                EventHandler<WebViewLoadCompletedEventArgs> handler =
                    WebViewLoadCompleted;

                if (null != handler)
                {
                    handler(this,
                        new WebViewLoadCompletedEventArgs());
                }
            }

            public class WebViewLocaitonChangedEventArgs : EventArgs
            {

                public string CommandString { get; set; }
            }

            public class WebViewLoadCompletedEventArgs : EventArgs
            {

            }
        }
    }
}