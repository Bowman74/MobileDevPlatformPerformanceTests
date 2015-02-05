using System;
using System.Collections.Generic;
using System.Windows.Input;
using PerfTest2Xamarin.Enums;
using PerfTest2Xamarin.Interfaces;
using PerfTest2Xamarin.Utilities;
using Xamarin.Forms;
#if __ANDROID__
using Android.Runtime;
#else
using Foundation;
#endif

namespace PerfTest2Xamarin.ViewModels
{
    [Preserve(AllMembers = true)]
    public class MainMenuViewModel
    {
        public event DisplayMessageEventHandler DisplayMessage;
        public event NavigatePageEventHandler NavigatePage;

        private IList<MenuItem> menuItems = new List<MenuItem>();

        public const int CLEAN_UP_TEST = 0;
        public const int ADD_SQL_RECORDS = 1;
        public const int DISPLAY_ALL_RECORDS = 2;
        public const int DISPLAY_RECORDS_WITH_WHERE = 3;
        public const int SAVE_LARGE_FILE = 4;
        public const int DISPLAY_LARGE_FILE = 5;

        public MainMenuViewModel()
        {
            menuItems.Add(new MenuItem { Index = CLEAN_UP_TEST, Description = "Clean up and prepare for tests" });
            menuItems.Add(new MenuItem { Index = ADD_SQL_RECORDS, Description = "Add 1,000 records to SQLite" });
            menuItems.Add(new MenuItem { Index = DISPLAY_ALL_RECORDS, Description = "Display all records" });
            menuItems.Add(new MenuItem { Index = DISPLAY_RECORDS_WITH_WHERE, Description = "Display all records that contain 1" });
            menuItems.Add(new MenuItem { Index = SAVE_LARGE_FILE, Description = "Save large file" });
            menuItems.Add(new MenuItem { Index = DISPLAY_LARGE_FILE, Description = "Load and display large file" });
        }
        
        public IList<MenuItem> MenuItems
        {
            get { return menuItems; }
        }

        public ICommand SelectMenuItem
        {
            get
            {
                return new Command<int>((int id) =>
                {
                    if (id == CLEAN_UP_TEST)
                    {
                        CleanUp();
                    }
                    else if (id == ADD_SQL_RECORDS)
                    {
                        AddRecords();
                    }
                    else if (id == DISPLAY_ALL_RECORDS)
                    {
                        ShowAllRecords();
                    }
                    else if (id == DISPLAY_RECORDS_WITH_WHERE)
                    {
                        ShowRecordsWith();
                    }
                    else if (id == SAVE_LARGE_FILE)
                    {
                        SaveLargeFile();
                    }
                    else if (id == DISPLAY_LARGE_FILE)
                    {
                        LoadAndDisplayFile();
                    }
                });
            }
        }

        private void CleanUp()
        {
            var directory = DependencyService.Get<IDirectoryLocation>().Directory;
            var sqlUtilities = new SqLiteUtilities(directory);

            try
            {
                sqlUtilities.DeleteFile();
                sqlUtilities.OpenConnection();
                sqlUtilities.CreateTable();
                sqlUtilities.CloseConnection();

                using (var fUtilities = new FileUtilities(directory))
                {
                    fUtilities.DeleteFile();

                    fUtilities.CreateFile();

                    fUtilities.CloseFile();
                }
            }
            catch (Exception ex)
            {
                if (DisplayMessage != null)
                    DisplayMessage(this, new DisplayMessageEventArgs(
                        "Error",
                        string.Format("An error has occurred: {0}", ex.Message)));
                return;
            }

            if (DisplayMessage != null)
                DisplayMessage(this, new DisplayMessageEventArgs(
                    "Cleanup and Prepare for Tests Successful",
                    "Completed test setup"));
            return;
        }

        private void AddRecords()
        {
            var directory = DependencyService.Get<IDirectoryLocation>().Directory;
            SqLiteUtilities utilities;
            int maxValue = 999;

            utilities = new SqLiteUtilities(directory);

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
                if (DisplayMessage != null)
                {
                    DisplayMessage(this, new DisplayMessageEventArgs(
                        "Error",
                        string.Format("An error has occurred adding records: {0}", ex.Message)));                    
                }
                return;
            }

            if (DisplayMessage != null)
            {
                DisplayMessage(this, new DisplayMessageEventArgs(
                    "Success",
                    "All records written to database"));                
            }
            return;
        }

        private void ShowAllRecords()
        {
            if (NavigatePage != null)
            {
                NavigatePage(this, new NavigatePageEventArgs(NavigationTarget.SqLiteDisplayAll));
            }
        }

        private void ShowRecordsWith()
        {
            NavigatePage(this, new NavigatePageEventArgs(NavigationTarget.SqLiteDisplayWhere));
        }

        private void SaveLargeFile()
        {
            int maxValue = 999;
            var directory = DependencyService.Get<IDirectoryLocation>().Directory;

            try
            {
                using (var utilities = new FileUtilities(directory))
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
                if (DisplayMessage != null)
                {
                    DisplayMessage(this, new DisplayMessageEventArgs(
                        "Error",
                        string.Format("An error has occurred adding lines to file: {0}", ex.Message)));
                }
                return;
            }

            if (DisplayMessage != null)
            {
                DisplayMessage(this, new DisplayMessageEventArgs(
                    "Success",
                    "All lines written to file"));
            }
            return;
        }

        private void LoadAndDisplayFile()
        {
            if (NavigatePage != null)
            {
                NavigatePage(this, new NavigatePageEventArgs(NavigationTarget.FileList));
            }           
        }
    }
}