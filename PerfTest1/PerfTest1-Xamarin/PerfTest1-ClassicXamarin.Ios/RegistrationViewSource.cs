using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace PerfTest1Xamarin
{
    public class RegistrationViewSource : UITableViewSource
    {
        private IList<Registration> data;

        public RegistrationViewSource(IList<Registration> data)
        {
            this.SetSource(data);
        }

        public void SetSource(IList<Registration> data)
        {
            this.data = data;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return data.Count();
        }


        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            const string simpleTableViewIdentifier = "SimpleTableItem";

            var cell = tableView.DequeueReusableCell(simpleTableViewIdentifier);
            // if there are no cells to reuse, create a new one

            if(cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, simpleTableViewIdentifier);                
            }

            cell.TextLabel.Text = data[indexPath.Row].screenname;
            return cell;
        }
    }
}