using System;

using UIKit;

namespace Johnlee1122.iOS
{
    public partial class LoadLocalHTMLViewController : UIViewController
    {
        public LoadLocalHTMLViewController(IntPtr handle) : base(handle)
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
				<script language='JavaScript'> function msg(){alert('Hi !');}</script>
				</head>
				<body>
				<p>Hello World!</p><br />
				<button type='button' onclick='msg()' text='Hi'>Hi</button>
				</body>
			</html>", null);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}