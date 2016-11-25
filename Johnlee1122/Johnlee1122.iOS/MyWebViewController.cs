using System;
using Foundation;
using UIKit;
using CoreLocation;

namespace Johnlee1122.iOS
{
    public class MyLocationService
    {
        public double Lat { get; set; }

        public double Lng { get; set; }


    }

    public partial class MyWebViewController : UIViewController
    {
        public MyLocationService displaLlocation { get; set; }

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

            var mapCenter = new CLLocationCoordinate2D(displaLlocation.Lat, displaLlocation.Lng);

            mapCenter.

            //InvokeOnMainThread(() =>
            //{
            //    PerformSegue("moveToDetailViewSegue", this);
            //});
        }

        //public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        //{
        //    base.PrepareForSegue(segue, sender);

        //    switch (segue.Identifier)
        //    {
        //        case @"moveToMapViewSegue":
        //            {
        //                var dest = segue.DestinationViewController as LoadLocalHTMLViewController;
        //                if (null != dest)
        //                {
        //                    dest.Title = features[1];
        //                }
        //            }
        //            break;

        //    }
        //}
    }
}