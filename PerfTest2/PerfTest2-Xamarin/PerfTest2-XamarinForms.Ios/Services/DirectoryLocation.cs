using System;
using Foundation;
using PerfTest2Xamarin.Interfaces;
using PerfTest2Xamarin.Services;

[assembly: Xamarin.Forms.Dependency(typeof(DirectoryLocation))]
namespace PerfTest2Xamarin.Services
{
    [Preserve(AllMembers = true)]
    public class DirectoryLocation : IDirectoryLocation
    {
        public string Directory
        {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); }
        }
    }
}