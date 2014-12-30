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

namespace PerfTest1Xamarin
{
    public class RegistrationAdapter : BaseAdapter
    {
        private Context context;

        private IList<Registration> registrations;

        public RegistrationAdapter(Context context, IList<Registration> registrations)
        {
            this.context = context;
            this.registrations = registrations;
        }

        public void SetRegistrations(IList<Registration> registrations)
        {
            this.registrations = registrations;
        }

        public override int Count
        {
            get { return registrations.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            // TODO Auto-generated method stub
            return null;
        }

        public override long GetItemId(int position)
        {
            // TODO Auto-generated method stub
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup viewGroup)
        {
            Registration entry = registrations[position];

            if (convertView == null)
            {
                LayoutInflater inflater = (LayoutInflater) context.GetSystemService(Context.LayoutInflaterService);
                convertView = inflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }

            TextView txtItem = (TextView) convertView.FindViewById(Android.Resource.Id.Text1);
            txtItem.Text = entry.screenname;

            return convertView;
        }

    }
}