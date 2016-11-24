using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace Johnlee1122.iOS.Cell
{
    public partial class UserViewCell : UITableViewCell
    {
        protected UserViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void UpdateUI(User user)
        {
            
        }
    }
}
