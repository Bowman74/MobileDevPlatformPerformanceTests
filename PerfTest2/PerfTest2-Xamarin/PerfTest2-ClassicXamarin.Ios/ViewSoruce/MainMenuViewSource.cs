using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using PerfTest2Xamarin.Utilities;
using UIKit;

namespace PerfTest2Xamarin.ViewSoruce
{
    public delegate void RowIsSelectedHandler(UITableView tableView, NSIndexPath indexPath);

    public class MainMenuViewSource : UITableViewSource
    {
        public event RowIsSelectedHandler RowIsSelected;

        private string[] menuItems =
        {
            "Clean up and Prepare for Tests", 
            "Add 1,000 records to SqLite", 
            "Display all records", 
            "Display all records that contain 1", 
            "Save large file", 
            "Load and display large file"
        };

        public MainMenuViewSource()
        {
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 6;
        }


        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (RowIsSelected != null)
            {
                RowIsSelected(tableView, indexPath);
            }
        }


        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            const string simpleTableViewIdentifier = "SimpleTableItem";

            var cell = tableView.DequeueReusableCell(simpleTableViewIdentifier);
            // if there are no cells to reuse, create a new one

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, simpleTableViewIdentifier);
            }

            cell.TextLabel.Text = menuItems[indexPath.Row];
            return cell;
        }

    }
}