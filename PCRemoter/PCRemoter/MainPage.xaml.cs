using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PCRemoter
{
    public partial class MainPage : ContentPage
    {
		PCRemoterViewModel _prvm = new PCRemoterViewModel();
        public MainPage()
        {
            InitializeComponent();
			BindingContext = _prvm;
        }

		private async void OnButtonConnectClicked(object sender, EventArgs e)
		{
			//labelPCAddress.Text = "Click";

			await Navigation.PushAsync(new PCControlsPage());

		}

		void OnButtonEchoClicked(object sender, EventArgs e)
		{
			
		}
    }
}
