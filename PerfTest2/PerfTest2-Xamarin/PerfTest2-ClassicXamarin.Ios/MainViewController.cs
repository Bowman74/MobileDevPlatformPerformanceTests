using System;
using UIKit;
using Foundation;
using PerfTest2Xamarin.Enums;
using PerfTest2Xamarin.ViewSoruce;
using PerfTest2Xamarin.Utilities;

namespace PerfTest2Xamarin
{

    [Register("MainViewController")]
    public class MainViewController : UITableViewController
    {

        private const int menuCleanUp = 0;
        private const int menuAddRecords = 1;
        private const int menuDisplayAll = 2;
        private const int menuDisplayWithWhere = 3;
        private const int menuSaveLargeFile = 4;
        private const int menuLoadAndDisplayFile = 5;

        private SqLiteDisplayType navigationQueryType;
        private string dbPath;

        public MainViewController(): base()
        {
        }

        public MainViewController(IntPtr p)
            : base(p)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            dbPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var source = new MainMenuViewSource();
            source.RowIsSelected += RowIsSelected;
            this.TableView.Source = source;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            if (segue.Identifier == "squToSqLiteTableView")
            {
                var destinationViewController = (SqLiteTableViewController)segue.DestinationViewController;
                destinationViewController.TableQueryType = navigationQueryType;
                destinationViewController.DbPath = dbPath;
            }
            else if (segue.Identifier == "sguToFileTableView")
            {
                var destinationViewController = (FileViewController)segue.DestinationViewController;
                destinationViewController.DbPath = dbPath;
            }
        }

        private void RowIsSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Row == menuCleanUp)
            {
                CleanUp();
            }
            else if (indexPath.Row == menuAddRecords)
            {
                AddRecords();
            }
            else if (indexPath.Row == menuDisplayAll)
            {
                ShowAllRecords();
            }
            else if (indexPath.Row == menuDisplayWithWhere)
            {
                ShowRecordsWith();
            }
            else if (indexPath.Row == menuSaveLargeFile)
            {
                SaveLargeFile();
            }
            else if (indexPath.Row == menuLoadAndDisplayFile)
            {
                LoadAndDisplayFile();
            }
        }

        private void CleanUp()
        {
            var sqlUtilities = new SqLiteUtilities(dbPath);

            try
            {
                sqlUtilities.DeleteFile();
                sqlUtilities.OpenConnection();
                sqlUtilities.CreateTable();
                sqlUtilities.CloseConnection();

                using (var fUtilities = new FileUtilities(dbPath))
                {
                    fUtilities.DeleteFile();

                    fUtilities.CreateFile();

                    fUtilities.CloseFile();
                }
            }
            catch (Exception ex)
            {
                var dlgException = new UIAlertView("Error",
                        string.Format("An error has occurred: " + ex.Message),
                        new UIAlertViewDelegate(),
                        "OK");
                dlgException.Show();
                return;
            }

            var dlgAlert = new UIAlertView("Cleanup and Prepare for Tests Successful",
                string.Format("Completed test setup"),
                new UIAlertViewDelegate(),
                "OK");
            dlgAlert.Show();
            return;
        }

        private void AddRecords()
        {
            SqLiteUtilities utilities;
            int maxValue = 999;

            utilities = new SqLiteUtilities(dbPath);

            try
            {
                utilities.OpenConnection();

                for (int i = 0; i <= maxValue; i++)
                {
                    utilities.AddRecord("test", "person", i, "12345678901234567890123456789012345678901234567890");
                }
                utilities.CloseConnection();
            }
            catch (Exception ex)
            {

                var dlgException = new UIAlertView("Error",
                    string.Format("An error has occurred adding records: " + ex.Message),
                    new UIAlertViewDelegate(),
                    "OK");
                dlgException.Show();
                return;
            }
            var dlgAlert = new UIAlertView("Success",
                string.Format("All records written to database"),
                new UIAlertViewDelegate(),
                "OK");
            dlgAlert.Show();
            return;
        }

        private void ShowAllRecords()
        {
            navigationQueryType = SqLiteDisplayType.ShowAll;
            PerformSegue("squToSqLiteTableView", this);
        }

        private void ShowRecordsWith()
        {
            navigationQueryType = SqLiteDisplayType.ShowContaining1;
            PerformSegue("squToSqLiteTableView", this);
        }

        private void SaveLargeFile()
        {
            int maxValue = 999;

            try
            {
                using (var utilities = new FileUtilities(dbPath))
                {
                    utilities.OpenFile();

                    for (int i = 0; i <= maxValue; i++)
                    {
                        utilities.WriteLineToFile("Writing line to file at index: " + i);
                    }
                    utilities.CloseFile();
                }
            }
            catch (Exception ex)
            {
                var dlgException = new UIAlertView("Error",
                    string.Format("An error has occurred adding lines to file: " + ex.Message),
                    new UIAlertViewDelegate(),
                    "OK");
                dlgException.Show();
                return;
            }

            var dlgAlert = new UIAlertView("Success",
                string.Format("All lines written to filee"),
                new UIAlertViewDelegate(),
                "OK");
            dlgAlert.Show();
            return;
        }

        private void LoadAndDisplayFile()
        {
            PerformSegue("sguToFileTableView", this);
        }
    }
}