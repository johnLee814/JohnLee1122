using System;

using UIKit;
using static System.Console;

namespace Johnlee1122.iOS.LoginFlow
{
    public partial class LoginViewController : UIViewController
    {
        private WebWorker Worker { get; set; }

        public LoginViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            Worker = new WebWorker();

            Worker.HtmlStringReceived += (sender, e) =>
           {
               WriteLine(e.Html);

               //ToDo:由storyboard取得
               PerformSegue("moveToMenuViewSegue", this);


           };

            //ToDo:由storyboard取得
            UIButton btnLogin = new UIButton();
            btnLogin.TouchUpInside += async (sender, e) =>
            {
                var result = await Worker.DownloadHtmlString("https://stackoverflow.com");

                WriteLine($"Result: { result.Length }");

            };
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
        }


    }
}