using PerfTest1Xamarin;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace PerfTest1_XamarinForms.ViewModels
{
    public class AzureListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IList<Registration> registrations = new List<Registration>();

        public IList<Registration> Registrations
        {
            get { return registrations; }
            set
            {
                registrations = value;
                OnPropertyChanged("Registrations");
            }
        }

        public ICommand Clear
        {
            get
            {
                return new Command(() =>
                {
                    registrations = new List<Registration>();
                    OnPropertyChanged("Registrations");
                });
            }
        }

        public ICommand Fetch
        {
            get
            {
                return new Command(async () =>
                {
                    registrations = await AzureTable.GetRegistrationsAsync();
                    OnPropertyChanged("Registrations");
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
