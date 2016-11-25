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

namespace Johnlee1122.Droid
{
    [Activity(Label = "ExamMainActivity")]
    public class ExamMainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.examflow_mainview);

            var worker = new StorageService();

            //var btnSearch = FindViewById<Button>(Resource.Id.examflow_mainview_btnSearch);
            //btnSearch.Click += async (object sender, EventArgs e) => {
               
              
            //    await worker.SaveTextAsync("googleSearch.txt", "123");

            //    Intent nextActivity = new Intent(this, typeof(ExamSearchActivity));
            //    StartActivity(nextActivity);
            //};


            var btnMap = FindViewById<Button>(Resource.Id.examflow_mainview_btnMap);
            btnMap.Click += async (object sender, EventArgs e) => {


                await worker.SaveTextAsync("map.txt", "123&456");

                Intent nextActivity = new Intent(this, typeof(ExamMapActivity));
                StartActivity(nextActivity);
            };
        }
        
    }
}