using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using Johnlee1122.iOS.Cell;

namespace Johnlee1122.iOS
{
    public partial class MenuViewController : UIViewController
    {
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
        }

        public class UserTableSource: UITableViewSource
        {
            const string UserViewCellIdentifier = "UserViewCell";  

            List<User> Users;

            UserTableSource()
            {
                Users = new List<User>();
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