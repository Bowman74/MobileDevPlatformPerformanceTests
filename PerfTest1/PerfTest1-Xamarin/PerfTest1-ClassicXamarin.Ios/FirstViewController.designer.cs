// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PerfTest1_ClassicXamarin.Ios
{
	[Register ("FirstViewController")]
	partial class FirstViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnClear { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnFetch { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView grdRegistrations { get; set; }

		[Action ("btnClear_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnClear_TouchUpInside (UIButton sender);

		[Action ("btnFetch_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnFetch_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnClear != null) {
				btnClear.Dispose ();
				btnClear = null;
			}
			if (btnFetch != null) {
				btnFetch.Dispose ();
				btnFetch = null;
			}
			if (grdRegistrations != null) {
				grdRegistrations.Dispose ();
				grdRegistrations = null;
			}
		}
	}
}
