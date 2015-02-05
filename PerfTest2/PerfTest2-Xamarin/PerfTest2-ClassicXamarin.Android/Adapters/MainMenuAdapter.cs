using System;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace PerfTest2Xamarin.Adapters
{
    public class MainMenuAdapter : BaseAdapter<string>
    {
        private Context context;
        private String[] myMenuItems = new String[6];

        public const int CLEAN_UP_TEST = 0;
        public const int ADD_SQL_RECORDS = 1;
        public const int DISPLAY_ALL_RECORDS = 2;
        public const int DISPLAY_RECORDS_WITH_WHERE = 3;
        public const int SAVE_LARGE_FILE = 4;
        public const int DISPLAY_LARGE_FILE = 5;

        public MainMenuAdapter(Context context)
        {
            this.context = context;
            myMenuItems[CLEAN_UP_TEST] = "Clean up and prepare for tests";
            myMenuItems[ADD_SQL_RECORDS] = "Add 1,000 records to SQLite";
            myMenuItems[DISPLAY_ALL_RECORDS] = "Display all records";
            myMenuItems[DISPLAY_RECORDS_WITH_WHERE] = "Display all records that contain 1";
            myMenuItems[SAVE_LARGE_FILE] = "Save large file";
            myMenuItems[DISPLAY_LARGE_FILE] = "Load and display large file";
        }

        public override string this[int position]
        {
            get { return myMenuItems[position - 1]; }
        }

        public override int Count
        {
            get { return myMenuItems.Length; }
        }

        public override long GetItemId(int position)
        {
            return position - 1;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                convertView = inflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }

            TextView txtItem = (TextView)convertView.FindViewById(Android.Resource.Id.Text1);
            txtItem.Text = myMenuItems[position];

            return convertView;
        }
    }
}