using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using PerfTest2Xamarin.Enums;
using PerfTest2Xamarin.ViewSoruce;
using UIKit;

namespace PerfTest2Xamarin
{
    [Register("SqLiteTableViewController")]
    public class SqLiteTableViewController : UITableViewController
    {
        public SqLiteDisplayType TableQueryType { get; set; }
        public string DbPath { get; set; }

        public SqLiteTableViewController(IntPtr p)
            : base(p)
        {
        }

        public override void ViewDidLoad()
        {
            var source = new SqLiteViewSource(DbPath, TableQueryType);
            this.TableView.Source = source;
        }
    }
}