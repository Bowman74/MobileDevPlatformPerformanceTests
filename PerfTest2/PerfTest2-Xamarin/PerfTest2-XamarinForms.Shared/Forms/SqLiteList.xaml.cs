using PerfTest2Xamarin.Enums;
using PerfTest2Xamarin.ViewModels;
using Xamarin.Forms;
#if __ANDROID__
using Android.Runtime;
#else
using Foundation;
#endif

namespace PerfTest2Xamarin.Forms
{
    [Preserve(AllMembers = true)]
	public partial class SqLiteList : ContentPage
	{
		public SqLiteList()
		{
			InitializeComponent();
            if (Device.OS == TargetPlatform.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
		}

        public void SetSqLiteDisplayType(SqLiteDisplayType displayType)
	    {
	        var viewModel = this.BindingContext as SqLiteListViewModel;
            if (Device.OS == TargetPlatform.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            if (viewModel != null)
	        {
	            viewModel.SetDisplayType(displayType);
	        }
	    }
	}
}