using System;
using UIKit;
using static System.Console;
namespace Johnlee1122.iOS.WebFlow
{
    public partial class MyWebViewController : UIViewController
    {
        public MyWebViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIKeyboard.Notifications.ObserveWillChangeFrame((sender, e) =>
            {

                var beginRect = e.FrameBegin;
                var endRect = e.FrameEnd;

                //ToDo:由storyboard取得
                WriteLine($"ObserveWillChangeFrame endRect:{endRect.Height}");

                InvokeOnMainThread(() =>
                {

                    UIView.Animate(1, () =>
                      {                         
                      //ToDo:由storyboard取得
                      //btnGoBottomConstraint.Constant = endRect.Height  5;
                      //    View.LayoutIfNeeded();

                      });
                });

            });
        }
    }
}