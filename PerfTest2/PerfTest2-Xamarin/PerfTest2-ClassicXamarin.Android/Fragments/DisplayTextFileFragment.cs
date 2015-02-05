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
using PerfTest2Xamarin.Adapters;

namespace PerfTest2Xamarin.Fragments
{
    public class DisplayTextFileFragment : Fragment
    {
        private string directory;

        public DisplayTextFileFragment(string directory)
            : base()
        {
            this.directory = directory;
        }
    
        public override void OnStart()
        {
            base.OnStart();
            ListView lstFileContents = (ListView)this.Activity.FindViewById(Resource.Id.lstFileContents);
            var adapter = new FileTableAdapter(this.Activity, directory);
            lstFileContents.Adapter = adapter;

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_display_text_file, container, false);
        }
    }
}