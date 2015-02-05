using System.Collections.Generic;
using System.ComponentModel;
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
    public class FileListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IList<string> listItems = new List<string>();

        public FileListViewModel()
        {
            var directory = DependencyService.Get<IDirectoryLocation>().Directory;

            using (var utilities = new FileUtilities(directory))
            {
                ListItems = utilities.ReadFileContents();
            }
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
