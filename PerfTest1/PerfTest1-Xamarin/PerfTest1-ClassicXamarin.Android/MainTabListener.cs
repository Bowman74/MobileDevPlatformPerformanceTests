using Android.App;

namespace PerfTest1Xamarin
{
    public class MainTabListener : Java.Lang.Object, ActionBar.ITabListener
    {
        private Fragment currentFragment;

        public MainTabListener()
        {
        }

        public void OnTabSelected(ActionBar.Tab tab, FragmentTransaction ft)
        {
            currentFragment = null;
            if (tab.Position == 0)
            {
                currentFragment = new AzureList();
                ft.Replace(Resource.Id.main_area, currentFragment);
            }
            else if (tab.Position == 1)
            {
                currentFragment = new CalcPrimes();
                ft.Replace(Resource.Id.main_area, currentFragment);
            }
        }

        public void OnTabReselected(ActionBar.Tab tab, FragmentTransaction ft)
        {
        }

        public void OnTabUnselected(ActionBar.Tab tab, FragmentTransaction ft)
        {
            ft.Remove(currentFragment);
        }
    }
}