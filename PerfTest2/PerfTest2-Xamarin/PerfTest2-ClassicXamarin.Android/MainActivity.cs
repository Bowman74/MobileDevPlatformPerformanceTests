
using Android.App;
using Android.OS;
using Android.Widget;
using System;
using PerfTest2Xamarin.Adapters;
using PerfTest2Xamarin.Enums;
using PerfTest2Xamarin.Fragments;
using PerfTest2Xamarin.Utilities;

namespace PerfTest2Xamarin
{
    [Activity(Label = "PerfTest2_ClassicXamarin.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, Android.Widget.AdapterView.IOnItemClickListener
    {
        Fragment currentFragment;
        private string directory;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            currentFragment = new MainMenuFragment();
            FragmentTransaction trans = this.FragmentManager.BeginTransaction();
            trans.Add(Resource.Id.main_area, currentFragment);
            trans.AddToBackStack(null);
            trans.Commit();
        }

        protected override void OnResume()
        {
            base.OnResume();
            directory = this.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads).Path + "/";
        }


        public void OnItemClick(Android.Widget.AdapterView parent, Android.Views.View view, int position, long id)
        {
            var lstMainMenu = (ListView)this.FindViewById(Resource.Id.lstMainMenu);

            if (position == MainMenuAdapter.CLEAN_UP_TEST)
            {
                CleanUp();
            }
            else if (position == MainMenuAdapter.ADD_SQL_RECORDS)
            {
                AddRecords();
            }
            else if (position == MainMenuAdapter.DISPLAY_ALL_RECORDS)
            {
                ShowAllRecords();
            }
            else if (position == MainMenuAdapter.DISPLAY_RECORDS_WITH_WHERE)
            {
                ShowRecordsWith();
            }
            else if (position == MainMenuAdapter.SAVE_LARGE_FILE)
            {
                SaveLargeFile();
            }
            else if (position == MainMenuAdapter.DISPLAY_LARGE_FILE)
            {
                LoadAndDisplayFile();
            }
        }

        private void CleanUp()
        {
            var sqlUtilities = new SqLiteUtilitiesAlt(this);

            try
            {
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
                var dlgException = new AlertDialog.Builder(this);
                dlgException.SetMessage("An error has occurred: " + ex.Message);
                dlgException.SetTitle("Error");
                dlgException.SetPositiveButton("OK", (sender, args) => { });
                dlgException.SetCancelable(true);
                dlgException.Create().Show();
                return;
            }

            var dlgAlert = new AlertDialog.Builder(this);
            dlgAlert.SetMessage("Completed test setup");
            dlgAlert.SetTitle("Cleanup and Prepare for Tests Successful");
            dlgAlert.SetPositiveButton("OK", (sender, args) => { });
            dlgAlert.SetCancelable(true);
            dlgAlert.Create().Show();
            return;
        }

        private void AddRecords()
        {
            SqLiteUtilitiesAlt utilities;
            int maxValue = 999;

            utilities = new SqLiteUtilitiesAlt(this);

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
                AlertDialog.Builder dlgException = new AlertDialog.Builder(this);
                dlgException.SetMessage("An error has occurred adding records: " + ex.Message);
                dlgException.SetTitle("Error");
                dlgException.SetPositiveButton("OK", (sender, args) => { });
                dlgException.SetCancelable(true);
                dlgException.Create().Show();
                return;
            }

            AlertDialog.Builder dlgAlert = new AlertDialog.Builder(this);
            dlgAlert.SetMessage("All records written to database");
            dlgAlert.SetTitle("Success");
            dlgAlert.SetPositiveButton("OK", (sender, args) => { });
            dlgAlert.SetCancelable(true);
            dlgAlert.Create().Show();
            return;
        }

        private void ShowAllRecords()
        {
            var fragmentTransaction = FragmentManager.BeginTransaction();
            var fragment = new SqLiteTableFragment(directory);
            Bundle bundle = new Bundle();
            bundle.PutInt("displayType", (int)SqLiteDisplayType.ShowAll);
            fragment.Arguments = bundle;
            fragmentTransaction.Replace(Resource.Id.main_area, fragment);
            fragmentTransaction.AddToBackStack(null);
            fragmentTransaction.Commit();
        }

        private void ShowRecordsWith()
        {
            var fragmentTransaction = FragmentManager.BeginTransaction();
            var fragment = new SqLiteTableFragment(directory);
            Bundle bundle = new Bundle();
            bundle.PutInt("displayType", (int)SqLiteDisplayType.ShowContaining1);
            fragment.Arguments = bundle;
            fragmentTransaction.Replace(Resource.Id.main_area, fragment);
            fragmentTransaction.AddToBackStack(null);
            fragmentTransaction.Commit();
        }

        private void SaveLargeFile()
        {
            int maxValue = 999;

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
                AlertDialog.Builder dlgException = new AlertDialog.Builder(this);
                dlgException.SetMessage("An error has occurred adding lines to file: " + ex.Message);
                dlgException.SetTitle("Error");
                dlgException.SetPositiveButton("OK", (sender, args) => { });
                dlgException.SetCancelable(true);
                dlgException.Create().Show();
                return;
            }

            AlertDialog.Builder dlgAlert = new AlertDialog.Builder(this);
            dlgAlert.SetMessage("All lines written to file");
            dlgAlert.SetTitle("Success");
            dlgAlert.SetPositiveButton("OK", (sender, args) => { });
            dlgAlert.SetCancelable(true);
            dlgAlert.Create().Show();
            return;
        }

        private void LoadAndDisplayFile()
        {
            FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
            DisplayTextFileFragment fragment = new DisplayTextFileFragment(directory);
            fragmentTransaction.Replace(Resource.Id.main_area, fragment);
            fragmentTransaction.AddToBackStack(null);
            fragmentTransaction.Commit();
        }
    }
}

