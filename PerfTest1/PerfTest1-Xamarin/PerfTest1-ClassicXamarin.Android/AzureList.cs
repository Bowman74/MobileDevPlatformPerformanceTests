using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace PerfTest1Xamarin
{
    public class AzureList : Fragment
    {

        public AzureList()
        {
            // Required empty public constructor
        }

        public override void OnStart()
        {
            base.OnStart();
            Button btnClear = (Button) this.Activity.FindViewById(Resource.Id.btnClear);
            Button btnFetch = (Button) this.Activity.FindViewById(Resource.Id.btnFetch);

            btnClear.SetOnClickListener((View.IOnClickListener) this.Activity);
            btnFetch.SetOnClickListener((View.IOnClickListener) this.Activity);

            ListView lstRegistrations = (ListView) this.Activity.FindViewById(Resource.Id.lstRegistrations);
            lstRegistrations.Adapter = new RegistrationAdapter(this.Activity, new List<Registration>());
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState)
        {
            // Inflate the layout for this fragment
            return inflater.Inflate(Resource.Layout.fragment_azure_list, container, false);
        }

        public override void OnDetach()
        {
            base.OnDetach();
            Button btnClear = (Button) this.Activity.FindViewById(Resource.Id.btnClear);
            Button btnFetch = (Button) this.Activity.FindViewById(Resource.Id.btnFetch);

            if (btnClear != null)
            {
                btnClear.SetOnClickListener(null);
            }
            if (btnFetch != null)
            {
                btnFetch.SetOnClickListener(null);
            }
        }
    }
}