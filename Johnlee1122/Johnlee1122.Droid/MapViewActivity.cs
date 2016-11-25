using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Resource;
using Android.Webkit;

namespace Johnlee1122.Droid
{
    [Activity(Label = "MapActivity")]
    public class MapViewActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            
            SetContentView(Resource.Layout.mapview);


      
        }
    }
}