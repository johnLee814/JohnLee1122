using Foundation;
using System;

using UIKit;

namespace Johnlee1122.iOS
{
    public partial class CallNativeFunctionViewController : UIViewController
    {
        public CallNativeFunctionViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            webView.LoadHtmlString(@"
			<html>
				<head>
					<title>Local String</title>
					<style type='text/css'>p{font-family : Verdana; color : purple }</style>
					<script language='JavaScript'> 
						function msg(){ 
							window.location = 'shirly://Hi'  
						}
					</script>
				</head>
				<body>
					<p>Hello World!</p><br />
					<button type='button' onclick='msg()' text='Hi'>Hi</button>
				</body>
			</html>", null);

            webView.ShouldStartLoad =
                delegate (UIWebView webView,
                    NSUrlRequest request,
                    UIWebViewNavigationType navigationType) {

                        var requestString = request.Url.AbsoluteString;

                        var components = requestString.Split(new[] { @"://" }, StringSplitOptions.None);

                        if (components.Length > 1 && components[0].ToLower() == @"shirly".ToLower())
                        {

                            if (components[1] == @"Hi")
                            {

                                UIAlertController alert = UIAlertController.Create(@"Hi Title", @"��M�O�@�ɦn", UIAlertControllerStyle.Alert);


                                UIAlertAction okAction = UIAlertAction.Create(@"OK", UIAlertActionStyle.Default, (action) => {
                                    Console.WriteLine(@"OK");
                                });
                                alert.AddAction(okAction);


                                UIAlertAction cancelAction = UIAlertAction.Create(@"Cancel", UIAlertActionStyle.Default, (action) => {
                                    Console.WriteLine(@"Cancel");
                                });
                                alert.AddAction(cancelAction);

                                PresentViewController(alert, true, null);


                                return false;
                            }

                        }

                        return true;

                    };


        }



        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}