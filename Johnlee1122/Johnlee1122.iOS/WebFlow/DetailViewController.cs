using System;

using UIKit;

namespace Johnlee1122.iOS.WebFlow
{
    public partial class DetailViewController : UIViewController
    {


        public DetailViewController(IntPtr handle) : base(handle)
        {
        }

        public User SelectUser { get; internal set; }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            //ToDo ¥ÑStoryBoard¨ú±o
            UILabel label = new UILabel();
            label.Text = SelectUser.Name;
        }
    }
}