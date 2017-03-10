using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PCRemoter
{
	public partial class PCControlsPage : ContentPage
	{
		PCRemoterViewModel _prvm = new PCRemoterViewModel();
		public PCControlsPage()
		{
			InitializeComponent();
			BindingContext = _prvm;
		}
		void OnSettingsButtonClicked(object sender, EventArgs e)
		{

		}

		void OnControlClicked(object sender, EventArgs e)
		{

		}
	}
}
