#if __ANDROID__
using Android.Runtime;
#else
using Foundation;
#endif

namespace PerfTest2Xamarin.Interfaces
{
    [Preserve(AllMembers = true)]
    interface IDirectoryLocation
    {
        string Directory { get; }
    }
}
