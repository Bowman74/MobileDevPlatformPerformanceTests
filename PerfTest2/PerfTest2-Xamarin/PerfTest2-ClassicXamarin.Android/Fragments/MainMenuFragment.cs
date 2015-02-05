using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PerfTest2Xamarin.Fragments
{
    public class MainMenuFragment : Fragment
    {
        public override void OnStart()
        {
            base.OnStart();

            ListView lstMainMenu = (ListView)this.Activity.FindViewById(Resource.Id.lstMainMenu);
            lstMainMenu.Adapter = new Adapters.MainMenuAdapter(this.Activity);
            lstMainMenu.OnItemClickListener = ((AdapterView.IOnItemClickListener)this.Activity);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_fragment_main_menu, container, false);
        }
    }
}