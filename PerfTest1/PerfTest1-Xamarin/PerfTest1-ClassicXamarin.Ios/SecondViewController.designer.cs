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
	[Register ("SecondViewController")]
	partial class SecondViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnCalcPrimes { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtMaxPrime { get; set; }

		[Action ("btnCalcPrimes_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnCalcPrimes_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnCalcPrimes != null) {
				btnCalcPrimes.Dispose ();
				btnCalcPrimes = null;
			}
			if (txtMaxPrime != null) {
				txtMaxPrime.Dispose ();
				txtMaxPrime = null;
			}
		}
	}
}
