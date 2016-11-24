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
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : Activity
    {
        private ListView _myListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.menulayout);


            _myListView = FindViewById<ListView>(Resource.Id.myListView);

            LoadData();
        }


        private void LoadData()
        {

            var list = new List<User>
            {
                new User {Name = @"Aa", Description = @"�ϥΪ� ��", ImageUrl = ""},
                new User {Name = @"Bb", Description = @"�ϥΪ� �A", ImageUrl = @"https://"},
                new User {Name = @"Cc", Description = @"�ϥΪ� ��", ImageUrl = ""},
                new User {Name = @"Dd", Description = @"�ϥΪ� �B", ImageUrl = @"https://"}
            };

            RunOnUiThread(
                () =>
                {

                    _myListView.Adapter = new UserListAdapter(list, this);
                    _myListView.ItemClick += (sender, args) =>
                    {
                        User user = list[args.Position];

                        Intent nextActivity = new Intent(this, typeof(DetailActivity));

                        string jsonString = JsonConvert.SerializeObject(user);

                        nextActivity.PutExtra("selectedUser", jsonString);

                        StartActivity(nextActivity);

                    };

                }
            );

        }


        /// <summary>
        /// �нƻs������O��A����ƥH��
        /// </summary>
        public class UserListAdapter : BaseAdapter<User>
        {
            private Activity context;

            private List<User> Users { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:XamarinTableView.Droid.MainActivity.UserListAdapter"/> class.
            /// �ǤJ��ƥH�έt�dø�Ϫ� Context
            /// </summary>
            /// <param name="users">Users.</param>
            /// <param name="context">Context.</param>
            public UserListAdapter(IEnumerable<User> users, Activity context)
            {
                this.context = context;

                Users = new List<User>();
                Users.AddRange(users);
            }

            /// <summary>
            /// ���@�~�t�ΤF�ѻݭn�ǳƦh�ְO����
            /// </summary>
            /// <value>��Ƶ���</value>
            public override int Count => Users.Count;

            /// <summary>
            /// �b��ƦC���ǻP��ܶ��Ǥ��P�ɡA�o��n���B�z�C
            /// 
            /// </summary>
            /// <returns>The item identifier.</returns>
            /// <param name="position">Position.</param>
            public override long GetItemId(int position)
            {
                return position;
            }

            /// <summary>
            /// �^�� UI 
            /// </summary>
            /// <returns>The view.</returns>
            /// <param name="position">Position.</param>
            /// <param name="convertView">Convert view.</param>
            /// <param name="parent">Parent.</param>
            public override View GetView(int position, View convertView, ViewGroup parent)
            {


                // UI Binding
                var view = convertView;

                if (null == view)
                {
                    view = context.LayoutInflater.Inflate(Resource.Layout.myclass_listview_itemview, parent, false);

                }

                // Data Binding
                User user = Users[position];

                view.FindViewById<TextView>(Resource.Id.myListView_itemview_txtName).Text = user.Name;
                view.FindViewById<TextView>(Resource.Id.myListView_itemview_txtDescription).Text = user.Description;

                return view;
            }


            /// <summary>
            /// Gets the <see cref="T:XamarinTableView.Droid.MainActivity.UserListAdapter"/> with the specified position.
            /// </summary>
            /// <param name="position">Position.</param>
            public override User this[int position] => Users[position];
        }
    }
}