using Android.App;
using Android.Runtime;
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
            get { return Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads).Path + "/"; }
        }
    }
}