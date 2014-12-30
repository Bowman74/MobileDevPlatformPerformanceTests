using Foundation;
using PerfTest1Xamarin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;

namespace PerfTest1_ClassicXamarin.Ios
{
    public partial class FirstViewController : UIViewController
    {
 
        public FirstViewController(IntPtr handle)
            : base(handle)
        {
            this.Title = NSBundle.MainBundle.LocalizedString("First", "First");
            this.TabBarItem.Image = UIImage.FromBundle("Images/first");
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

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();

            // Clear any references to subviews of the main view in order to
            // allow the Garbage Collector to collect them sooner.
            //
            // e.g. myOutlet.Dispose (); myOutlet = null;

            ReleaseDesignerOutlets();
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

        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            // Return true for supported orientations
            return true;
        }

        partial void btnClear_TouchUpInside(UIButton sender)
        {
            SetViewSourceIfNeeded();
            ((RegistrationViewSource)grdRegistrations.Source).SetSource(new List<Registration>());
            grdRegistrations.ReloadData();
        }

        partial void btnFetch_TouchUpInside(UIButton sender)
        {
            SetViewSourceIfNeeded();
            Task.Run(async ()=> await LoadListAsync());
        }

        private void SetViewSourceIfNeeded()
        {
            if (grdRegistrations.Source == null)
            {
                this.grdRegistrations.Source = new RegistrationViewSource(new List<Registration>());
            }
        }

        private async Task LoadListAsync()
        {
            try
            {
                //Line needed so platform specific DLL is included.
                var platform = new Microsoft.WindowsAzure.MobileServices.CurrentPlatform();
                var registrations = await AzureTable.GetRegistrationsAsync();
                    InvokeOnMainThread ( () => {
                        ((RegistrationViewSource)grdRegistrations.Source).SetSource(registrations);
                        grdRegistrations.ReloadData();
                    });
            }
            catch (Exception ex)
            {
                var alert = new UIAlertView("Error!",
                    string.Format("We don't like errors but there it is: {0}", ex.Message), new UIAlertViewDelegate(), "OK");
                alert.Show();
            }
        }
    }
}