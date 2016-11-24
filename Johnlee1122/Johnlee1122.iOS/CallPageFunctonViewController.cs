using Foundation;
using System;
using System.Text;
using UIKit;

namespace Johnlee1122.iOS
{
    public partial class CallPageFunctonViewController : UIViewController
    {
        public CallPageFunctonViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            webView.LoadHtmlString(@"<html><head><title>Local String</title><style type='text/css'>p{font-family : Verdana; color : purple }</style><script language='JavaScript'> function msg( text ){alert( text );}</script></head><body><p>Hello World!</p><br /><button type='button' onclick='msg()' text='Hi'>Hi</button></body></html>", null);

        }

        partial void btnMessageClicked(NSObject sender)
        {
            var message = new StringBuilder(@"msg('");

            message.Append(txtMessage.Text);
            message.Append(@"')");

            webView.EvaluateJavascript(message.ToString());


        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}