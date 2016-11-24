using Foundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UIKit;

namespace Johnlee1122.iOS
{
    public partial class WebViewViewController1 : UIViewController
    {
        string[] features = { @"Load HTML from Web", @"Load HTML from Local", @"Call WebPage's function", @"Call Native function" };
        string[] segues = { @"moveToLoadRemoteWebViewSegue", @"moveToLoadLocalHTMLViewSegue", @"moveToCallPageFunctonViewSegue", @"moveToCallNativeFunctionViewSegue" };

        public WebViewViewController1(IntPtr handle) : base(handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InvokeOnMainThread(() =>
            {
                PerformSegue("moveToDetailViewSegue", this);
            });
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            base.PrepareForSegue(segue, sender);

            switch (segue.Identifier)
            {

                case @"moveToLoadRemoteWebViewSegue":
                    {
                        var dest = segue.DestinationViewController as LoadRemoteWebViewController;
                        if (null != dest)
                        {
                            dest.Title = features[0];
                        }
                    }
                    break;
                case @"moveToLoadLocalHTMLViewSegue":
                    {
                        var dest = segue.DestinationViewController as LoadLocalHTMLViewController;
                        if (null != dest)
                        {
                            dest.Title = features[1];
                        }
                    }
                    break;
                case @"moveToCallPageFunctonViewSegue":
                    {
                        var dest = segue.DestinationViewController as CallPageFunctonViewController;
                        if (null != dest)
                        {
                            dest.Title = features[2];
                        }
                    }
                    break;
                case @"moveToCallNativeFunctionViewSegue":
                    {
                        var dest = segue.DestinationViewController as CallNativeFunctionViewController;
                        if (null != dest)
                        {
                            dest.Title = features[3];
                        }
                    }
                    break;

            }
        }
    }
}