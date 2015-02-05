using System;
using System.Collections.Generic;
using System.ComponentModel;
using PerfTest2Xamarin.Enums;
using PerfTest2Xamarin.Interfaces;
using PerfTest2Xamarin.Utilities;
using Xamarin.Forms;
#if __ANDROID__
using Android.Runtime;
#else
using Foundation;
#endif

namespace PerfTest2Xamarin.ViewModels
{
    [Preserve(AllMembers = true)]
    public class SqLiteListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IList<string> listItems = new List<string>();

        public void SetDisplayType(SqLiteDisplayType displayType)
        {
            var directory = DependencyService.Get<IDirectoryLocation>().Directory;
            var utilities = new SqLiteUtilities(directory);
            utilities.OpenConnection();
            switch (displayType)
            {
                case SqLiteDisplayType.ShowAll:
                    ListItems = utilities.GetAllRecords();
                    break;
                case SqLiteDisplayType.ShowContaining1:
                    ListItems = utilities.GetRecordsWith1();
                    break;
                default:
                    throw new NotImplementedException("Invalid SqLiteDisplayType");
            }
            utilities.CloseConnection();
        }

        public IList<string> ListItems
        {
            get { return listItems; }
            private set
            {
                listItems = value;
                OnPropertyChanged("ListItems");
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
