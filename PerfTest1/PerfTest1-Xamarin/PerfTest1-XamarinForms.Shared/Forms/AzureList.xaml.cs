using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfTest1_XamarinForms.ViewModels;

namespace PerfTest1_XamarinForms.Forms
{
	public partial class AzureList
	{
		public AzureList()
		{
			InitializeComponent();

		    var viewModel = new AzureListViewModel();

		    this.BindingContext = viewModel;
		}
	}
}
