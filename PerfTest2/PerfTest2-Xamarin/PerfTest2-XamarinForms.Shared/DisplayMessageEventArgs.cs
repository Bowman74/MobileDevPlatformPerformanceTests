using System;
#if __ANDROID__
using Android.Runtime;
#else
using Foundation;
#endif

namespace PerfTest2Xamarin
{
    [Serializable]
    [Preserve(AllMembers = true)]
    public delegate void DisplayMessageEventHandler(object sender, DisplayMessageEventArgs e);

    public class DisplayMessageEventArgs : EventArgs
    {
        private string title = string.Empty;
        private string message = string.Empty;

        public DisplayMessageEventArgs(string title, string message)
        {
            this.title = title;
            this.message = message;
        }

        public string Title
        {
            get { return title; }
        }

        public string Message
        {
            get { return message; }
        }
    }
}