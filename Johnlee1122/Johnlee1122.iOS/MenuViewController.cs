using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using Johnlee1122.iOS.Cell;
using System.Diagnostics;
using Johnlee1122.iOS.WebFlow;

namespace Johnlee1122.iOS
{
    public partial class MenuViewController : UIViewController
    {
        private User selectedUser;

        public MenuViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            ShowTable();
        }

        private void ShowTable()
        {

            var list = new List<User>
            {
                new User {Name = @"Aa", Description = @"�ϥΪ� ��", ImageUrl = ""},
                new User {Name = @"Bb", Description = @"�ϥΪ� �A", ImageUrl = @"https://"},
                new User {Name = @"Cc", Description = @"�ϥΪ� ��", ImageUrl = ""},
                new User {Name = @"Dd", Description = @"�ϥΪ� �B", ImageUrl = @"https://"}
            };

            var tableSource = new UserTableSource(list);

            //ToDo ��sotryboard���o
            var userTable = new UITableView();
            userTable.Source = tableSource;

            tableSource.UserSelected += delegate (object sender, UserSelectedEventArgs e) {



                //Debug.WriteLine(e.SelectedUser.Name);

                selectedUser = e.SelectedUser;

                InvokeOnMainThread(() =>
                {
                    PerformSegue("moveToDetailViewSegue", this);
                });

                
            };

            userTable.ReloadData();


        }


        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if ("moveToDetailViewSegue" == segue.Identifier)
            {
                if (segue.DestinationViewController is DetailViewController)
                {
                    var detailViewController = segue.DestinationViewController as DetailViewController;
                    detailViewController.SelectUser = selectedUser;
                }
            }
        }

        public class UserTableSource: UITableViewSource
        {
            const string UserViewCellIdentifier = "UserViewCell";  

            List<User> Users;

            public UserTableSource(List<User> user)
            {
                Users = new List<User>();
                Users.AddRange(user);
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return Users.Count;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                User myClass = Users[indexPath.Row];
                UserViewCell cell = tableView.DequeueReusableCell(UserViewCellIdentifier)
                        as UserViewCell;
                cell.UpdateUI(myClass);

                return cell;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                tableView.DeselectRow(indexPath, true);

                User user = Users[indexPath.Row];

                EventHandler<UserSelectedEventArgs> handle = UserSelected;

                if (handle != null)
                {
                    var args = new UserSelectedEventArgs { SelectedUser = user };

                    handle(this, args);
                }
            }

            public event EventHandler<UserSelectedEventArgs> UserSelected;
        }

        public class UserSelectedEventArgs : EventArgs
        {

            public User SelectedUser { get; set; }

        }
    }
}