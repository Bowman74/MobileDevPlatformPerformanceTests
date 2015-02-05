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
using PerfTest2Xamarin.Utilities;

namespace PerfTest2Xamarin.Adapters
{
    public class FileTableAdapter : BaseAdapter<string>
    {
        private Context context;
        private string directory;
        private IList<string> records;

        public FileTableAdapter(Context context, string directory)
        {
            this.context = context;
            this.directory = directory;
            LoadRecords();
        }

        private void LoadRecords()
        {
            FileUtilities utilities;

            utilities = new FileUtilities(this.directory);
            try
            {
                records = utilities.ReadFileContents();
            }
            catch (Exception ex)
            {
                // Bah, it's not production code... 
            }
        }

        public override string this[int position]
        {
            get { return records[position]; }
        }

        public override int Count
        {
            get { return records.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                convertView = inflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }

            TextView txtItem = (TextView)convertView.FindViewById(Android.Resource.Id.Text1);
            txtItem.Text = records[position];

            return convertView;
        }
    }
}