using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using PerfTest2Xamarin.ViewSoruce;
using UIKit;

namespace PerfTest2Xamarin
{
    [Register("FileViewController")]
    public class FileViewController : UITableViewController
    {

        public string DbPath { get; set; }

        public FileViewController(IntPtr p)
            : base(p)
        {
        }

        public override void ViewDidLoad()
        {
            var source = new FileViewSource(DbPath);
            this.TableView.Source = source;
        }

    }
}