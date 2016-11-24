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
using Newtonsoft.Json;

namespace Johnlee1122.Droid
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.webview_detailview);

            var lbName = FindViewById<TextView>(Resource.Id.detailview_lbName);

            var userString = Intent.GetStringExtra("selectedUser");
            User user = JsonConvert.DeserializeObject<User>(userString);

            lbName.Text = user.Name;
        }
    }
}