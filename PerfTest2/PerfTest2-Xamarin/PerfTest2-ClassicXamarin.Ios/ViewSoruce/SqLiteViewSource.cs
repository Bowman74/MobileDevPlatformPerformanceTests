using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using PerfTest2Xamarin.Enums;
using PerfTest2Xamarin.Utilities;
using UIKit;

namespace PerfTest2Xamarin.ViewSoruce
{
    public class SqLiteViewSource : UITableViewSource
    {
        public string dbPath;
        private SqLiteDisplayType displayType;
        private IList<string> records;

        private SqLiteViewSource()
        { }

        public SqLiteViewSource(string dbPath, SqLiteDisplayType displayType)
        {
            this.dbPath = dbPath;
            this.displayType = displayType;
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
            SqLiteUtilities utilities;

            utilities = new SqLiteUtilities(this.dbPath);
            try
            {
                utilities.OpenConnection();
                if (displayType == SqLiteDisplayType.ShowAll)
                {
                    records = utilities.GetAllRecords();
                }
                else
                {
                    records = utilities.GetRecordsWith1();
                }
                utilities.CloseConnection();
            }
            catch (Exception ex)
            {
                // Bah, it's not production code... 
            }
        }
    }
}