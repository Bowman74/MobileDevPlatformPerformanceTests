using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using PerfTest2Xamarin.Utilities;
using UIKit;

namespace PerfTest2Xamarin.ViewSoruce
{
    public class FileViewSource : UITableViewSource
    {
        public string path;
        private IList<string> records;

        private FileViewSource()
        { }

        public FileViewSource(string path)
        {
            this.path = path;
            LoadRecords();
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return records.Count;
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

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, simpleTableViewIdentifier);
            }

            cell.TextLabel.Text = records[indexPath.Row];
            return cell;
        }
        
        private void LoadRecords()
        {
            FileUtilities utilities;

            utilities = new FileUtilities(this.path);
            try
            {
                records = utilities.ReadFileContents();
            }
            catch (Exception ex)
            {
                // Bah, it's not production code... 
            }
        }
    }
}