using System;
using System.Collections.Generic;
using System.Text;
using PerfTest2Xamarin.Forms;
using Xamarin.Forms;
#if __ANDROID__
using Android.Runtime;
#else
using Foundation;
#endif

namespace PerfTest2Xamarin
{
    [Preserve(AllMembers = true)]
    public class App: Application
    {
        public App()
        {
            var mainPage = new MainPage();
            var navigation = new NavigationPage(mainPage);
            this.MainPage = navigation;
        }
    }
}
