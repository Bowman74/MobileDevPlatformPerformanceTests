using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PerfTest1_XamarinForms
{
    public class App : Application
    {
		public App()
		{
			MainPage = new NavigationPage(new Forms.MainPage());
		}
    }
}