using System;
using System.ComponentModel;
using System.Windows.Input;
using PerfTest1Xamarin;
using Xamarin.Forms;

namespace PerfTest1_XamarinForms.ViewModels
{
    public class CalcPrimesViewModel : INotifyPropertyChanged
    {
        public CalcPrimesViewModel()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event DisplayMessageEventHandler DisplayMessage;
        private string maxPrime = string.Empty;

        public string MaxPrime
        {
            get { return maxPrime; }
            set
            {
                maxPrime = value;
                OnPropertyChanged("MaxPrime");
            }
        }

        public ICommand CalcPrimes
        {
            get
            {
                return new Command(() =>
                {
                    int val = 0;
                    if (int.TryParse(maxPrime, out val))
                    {
                        var returnValue = PrimeNumbers.GetPrimesFromSieve(val);

                        if (DisplayMessage != null)
                            DisplayMessage(this, new DisplayMessageEventArgs(
                                "Prime Calculation Complete",
                                "Largest prime found: " + returnValue));
                    }
                    else
                    {
                        if (DisplayMessage != null)
                            DisplayMessage(this, new DisplayMessageEventArgs(
                                "Prime Calculation Error",
                                string.Format("{0}{1}", "Must enter a numeric max value: ", maxPrime)));
                    }

                });
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
        }
    }
}
