// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;

namespace Johnlee1122.iOS
{
    [Register("CallPageFunctonViewController")]
    partial class CallPageFunctonViewController
    {
        [Outlet]
        UIKit.UITextField txtMessage { get; set; }

        [Outlet]
        UIKit.UIWebView webView { get; set; }

        [Action("btnMessageClicked:")]
        partial void btnMessageClicked(Foundation.NSObject sender);

        void ReleaseDesignerOutlets()
        {
            if (webView != null)
            {
                webView.Dispose();
                webView = null;
            }

            if (txtMessage != null)
            {
                txtMessage.Dispose();
                txtMessage = null;
            }
        }
    }
}