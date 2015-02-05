using System;
using Android.App;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace PerfTest2Xamarin
{
    [Activity(Label = "PerfTest2_XamarinForms.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}

