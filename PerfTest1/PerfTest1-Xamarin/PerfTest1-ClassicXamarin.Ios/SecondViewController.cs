using System;
using System.Drawing;
using System.Collections.Generic;

using Foundation;
using UIKit;

namespace PerfTest1_ClassicXamarin.Ios
{
    public partial class SecondViewController : UIViewController
    {
        public SecondViewController(IntPtr handle)
            : base(handle)
        {
            this.Title = NSBundle.MainBundle.LocalizedString("Second", "Second");
            this.TabBarItem.Image = UIImage.FromBundle("Images/second");
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion

        partial void btnCalcPrimes_TouchUpInside(UIButton sender)
        {
            int val = 0;
            if (int.TryParse(txtMaxPrime.Text, out val))
            {
                var returnValue = PerfTest1Xamarin.PrimeNumbers.GetPrimesFromSieve(val);
                var alert = new UIAlertView("Prime Calculation Complete",
                    string.Format("Largest Prime Found: {0}", returnValue), new UIAlertViewDelegate(), "OK");
                alert.Show();
            }
            else
            {
                var alert = new UIAlertView("Prime Calculation Error",
                    string.Format("Must enter a numeric max value: {0}", txtMaxPrime.Text), new UIAlertViewDelegate(), "OK");
                alert.Show();
            }
        }
    }
}