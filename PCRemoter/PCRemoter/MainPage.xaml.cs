using PCRemoter.Web;
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
        PCRemoterService _prs = new PCRemoterService();
        PCRemoteMessages _prm = new PCRemoteMessages();
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
            _prm._message = labelMessage.Text;
            PCRemoteMessages _pranswr = new PCRemoteMessages();
            _pranswr = _prs.Echo(_prm);
            labelAnswer.Text = _pranswr._message;
		}
    }
}
