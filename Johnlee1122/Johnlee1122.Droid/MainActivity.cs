using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Newtonsoft.Json;
using Android.Webkit;
using Java.Util.Regex;
using System.Text.RegularExpressions;
using Java.Interop;


namespace Johnlee1122.Droid
{
    [Activity(Label = "Johnlee1122.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Intent nextActivity = new Intent(this, typeof(ExamMainActivity));

            StartActivity(nextActivity);

            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.loginflow_loginview);

            ///////////////////
            //var txtAccount = FindViewById<EditText>(Resource.Id.loginflow_loginview_txtaccount);

            //var txtPassword = FindViewById<EditText>(Resource.Id.loginflow_loginview_txtpassword);


            //var btnLogin = FindViewById<Button>(Resource.Id.loginflow_loginview_btnlogin);
            //btnLogin.Click += (object sender, EventArgs e) =>
            //{
            //    Intent nextActivity = new Intent(this, typeof(MenuActivity));

            //    StartActivity(nextActivity);
            //};

            //var btnWebview = FindViewById<Button>(Resource.Id.loginflow_loginview_btnwebview);
            //btnWebview.Click += (object sender, EventArgs e) =>
            //{
            //    Intent nextActivity = new Intent(this, typeof(WebViewActivity));

            //    StartActivity(nextActivity);
            //};

            //var btnMapview = FindViewById<Button>(Resource.Id.loginflow_loginview_btnmapview);
            //btnMapview.Click += (object sender, EventArgs e) =>
            //{
            //    Intent nextActivity = new Intent(this, typeof(MapViewActivity));

            //    StartActivity(nextActivity);
            //};
        }






    }
}


