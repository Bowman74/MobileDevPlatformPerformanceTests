using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace PerfTest1Xamarin
{
    public class CalcPrimes : Fragment
    {

        public CalcPrimes()
        {
            // Required empty public constructor
        }

        public override void OnStart()
        {
            base.OnStart();
            Button btnCalcPrimes = (Button) this.Activity.FindViewById(Resource.Id.btnCalcPrimes);

            btnCalcPrimes.SetOnClickListener((View.IOnClickListener) this.Activity);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState)
        {
            // Inflate the layout for this fragment
            return inflater.Inflate(Resource.Layout.fragment_calc_primes, container, false);
        }

        public override void OnDetach()
        {
            base.OnDetach();
            Button btnCalcPrimes = (Button) this.Activity.FindViewById(Resource.Id.btnCalcPrimes);

            if (btnCalcPrimes != null)
            {
                btnCalcPrimes.SetOnClickListener(null);
            }
        }
    }
}