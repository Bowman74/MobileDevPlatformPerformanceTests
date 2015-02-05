#if __ANDROID__
using Android.Runtime;
#else
using Foundation;
#endif

namespace PerfTest2Xamarin.ViewModels
{
    [Preserve(AllMembers = true)]
    public class MenuItem
    {
        public int Index { get; set; }
        public string Description { get; set; }
    }
}
