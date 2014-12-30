using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PerfTest1Xamarin;
using System.Threading.Tasks;

namespace PerfTest1_ClassicXamarin.Android
{
    [Activity(Label = "PerfTest1_ClassicXamarin.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, View.IOnClickListener
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (this.ActionBar != null)
            {
                this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            }

            SetContentView(Resource.Layout.activity_main);

            var tabListener = new MainTabListener();

            var tab = this.ActionBar.NewTab();
            tab.SetText("Azure List");
            tab.SetTabListener(tabListener);
            this.ActionBar.AddTab(tab);

            tab = this.ActionBar.NewTab();
            tab.SetText("Calc Primes");
            tab.SetTabListener(tabListener);
            this.ActionBar.AddTab(tab);

        }

        public void OnClick(View view)
        {
            if (view != null)
            {
                if (view.Id == Resource.Id.btnCalcPrimes)
                {
                    this.CalcPrimes();
                }
                else if (view.Id == Resource.Id.btnClear)
                {
                    this.ClearList();
                }
                else if (view.Id == Resource.Id.btnFetch)
                {
                    Task.Run(async () => await this.FillListAsync());
                }
            }
        }

        private async Task FillListAsync()
        {
            var registrations = await AzureTable.GetRegistrationsAsync();
            RunOnUiThread(() => ResetList(registrations));
        }

        private void ResetList(IList<Registration> registrations)
        {
            ListView lstRegistrations = (ListView)this.FindViewById(Resource.Id.lstRegistrations);
            if (lstRegistrations != null)
            {
                var adapter = ((RegistrationAdapter)lstRegistrations.Adapter);
                adapter.SetRegistrations(registrations);
                adapter.NotifyDataSetChanged();
                //lstRegistrations.RefreshDrawableState();
            }
        }

        private void ClearList()
        {
            ResetList(new List<Registration>());
        }

        private void CalcPrimes()
        {
            EditText txtMaxPrime = (EditText)this.FindViewById(Resource.Id.txtMaxPrime);

            int val = 0;
            if (int.TryParse(txtMaxPrime.Text, out val))
            {
                var returnValue = PerfTest1Xamarin.PrimeNumbers.GetPrimesFromSieve(val);

                AlertDialog.Builder dlgAlert = new AlertDialog.Builder(this);
                dlgAlert.SetMessage("Largest prime found: " + returnValue);
                dlgAlert.SetTitle("Prime Calculation Complete");
                dlgAlert.SetPositiveButton("OK", (sender, args) => {  });
                dlgAlert.SetCancelable(true);
                dlgAlert.Create().Show();
            }
            else
            {
                AlertDialog.Builder dlgAlert = new AlertDialog.Builder(this);
                dlgAlert.SetMessage(string.Format("{0}{1}", "Must enter a numeric max value: ", txtMaxPrime.Text));
                dlgAlert.SetTitle("Prime Calculation Error");
                dlgAlert.SetPositiveButton("OK", (sender, args) => { });
                dlgAlert.SetCancelable(true);
                dlgAlert.Create().Show();

            }            
        }
    }
}

