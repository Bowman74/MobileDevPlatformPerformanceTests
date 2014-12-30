using PerfTest1_XamarinForms.ViewModels;

namespace PerfTest1_XamarinForms.Forms
{
	public partial class CalcPrimes
	{
		public CalcPrimes()
		{
			InitializeComponent();

		    var viewModel = new CalcPrimesViewModel();
		    this.BindingContext = viewModel;
            viewModel.DisplayMessage += ViewModelOnDisplayMessage;
		}

	    private void ViewModelOnDisplayMessage(object sender, DisplayMessageEventArgs eventArgs)
	    {
	        this.DisplayAlert(eventArgs.Title, eventArgs.Message, "OK", "Cancel");
	    }
	}
}
