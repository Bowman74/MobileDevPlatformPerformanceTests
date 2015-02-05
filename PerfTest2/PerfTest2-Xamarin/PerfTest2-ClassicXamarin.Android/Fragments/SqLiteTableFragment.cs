using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using PerfTest2Xamarin.Adapters;
using PerfTest2Xamarin.Enums;

namespace PerfTest2Xamarin.Fragments
{
    public class SqLiteTableFragment : Fragment
    {
        private SqLiteDisplayType displayType;
        private string directory;

        public SqLiteTableFragment() : base()
        {
            // Required empty public constructor
        }

        public SqLiteTableFragment(string directory)
            : base()
        {
            this.directory = directory;
        }

        public override void OnStart()
        {
            base.OnStart();
            ListView lstSqLiteTable = (ListView)Activity.FindViewById(Resource.Id.lstSqLiteTable);
            var adapter = new SqLiteTableAdapter(Activity, directory, displayType);
            lstSqLiteTable.Adapter = adapter;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var bundle = this.Arguments;
            displayType = (SqLiteDisplayType)bundle.GetInt("displayType");
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_sq_lite_table, container, false);
        }

    }
}