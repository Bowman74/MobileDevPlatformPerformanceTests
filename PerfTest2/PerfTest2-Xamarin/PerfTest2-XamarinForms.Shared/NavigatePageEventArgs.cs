using System;
using System.Collections.Generic;
using System.Text;
#if __ANDROID__
using Android.Runtime;
#else
using Foundation;
#endif
using PerfTest2Xamarin.Enums;

namespace PerfTest2Xamarin
{
    [Serializable]
    [Preserve(AllMembers = true)]
    public delegate void NavigatePageEventHandler(object sender, NavigatePageEventArgs e);

    public class NavigatePageEventArgs : EventArgs
    {
        private NavigationTarget target;

        public NavigatePageEventArgs(NavigationTarget target)
        {
            this.target = target;
        }

        public NavigationTarget Target
        {
            get { return target; }
        }
    }
}
