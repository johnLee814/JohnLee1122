using System;
using System.Threading.Tasks;
using UIKit;

namespace Johnlee1122.iOS.WebFlow
{
    public partial class ViewController1 : UIViewController
    {
        public ViewController1(IntPtr handle) : base(handle)
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

            Task.Run(() =>
            {
                Task.Delay(2000);

                InvokeOnMainThread(() =>
                {
                    //ToDo:¥Ñstoryboard¨ú±o
                    PerformSegue("moveToLoginViewSegue", this);
                });
            });
        }
    }
}