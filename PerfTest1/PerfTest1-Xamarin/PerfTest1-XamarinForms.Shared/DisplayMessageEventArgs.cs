using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PerfTest1_XamarinForms
{
    [Serializable]
    [ComVisible(true)]
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
