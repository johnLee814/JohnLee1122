using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Johnlee1122.Droid
{
	[Activity (Label = "Johnlee1122.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			var _txtAccount = FindViewById<EditText> (Resource.Id.loginflow_loginview_txtaccount);

            var _txtPassword = FindViewById<EditText>(Resource.Id.loginflow_loginview_txtpassword);


            var myButton = FindViewById<Button>(Resource.Id.myButton);
            myButton.Click += (object sender, EventArgs e) => { };

        }
    }
}


