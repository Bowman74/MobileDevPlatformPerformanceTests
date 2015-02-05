using Xamarin.Forms;
#if __ANDROID__
using Android.Runtime;
#else
using Foundation;
#endif

namespace PerfTest2Xamarin.Forms
{
    [Preserve(AllMembers = true)]
	public partial class FileList : ContentPage
	{
		public FileList()
		{
			InitializeComponent();
            if (Device.OS == TargetPlatform.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
		}
	}
}
