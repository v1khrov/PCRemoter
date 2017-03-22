using PCRemoter.PCRemoterServer;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PCRemoter
{
	public partial class PCControlsPage : ContentPage
	{		
        RemoterServiceClient controlsClient;//объект класса клиента веб службы
        static string controlAnswer = "";

        public PCControlsPage()
		{
			InitializeComponent();			
		}

        //конструктор с передачей клиента
        public PCControlsPage(RemoterServiceClient client)
        {
            controlsClient = client;
            InitializeComponent();
        }

		void OnSettingsButtonClicked(object sender, EventArgs e)
		{

		}

		void OnControlClicked(object sender, EventArgs e)
		{
            string _buttonName = "";
           
            if(sender == upBtn)
                _buttonName = "buttonUp";

            if (sender == downBtn)
                _buttonName = "buttonDown";

            if (sender == leftBtn)
                _buttonName = "buttonLeft";

            if (sender == rightBtn)
                _buttonName = "buttonRight";
            

            try
            {
                controlsClient.ControlAsync(_buttonName);
                controlsClient.ControlCompleted += new EventHandler<ControlCompletedEventArgs>(ControlCallback);

                if(controlAnswer=="")
                {
                    throw new Exception("Host didn't answer.");
                }

                controlAnswer = "";
            }
            catch (Exception ex)
            {
                DisplayAlert("Error!", ex.Message, "ОK");
            }
            
               
        }

        static void ControlCallback(object sender, ControlCompletedEventArgs e)
        {
            controlAnswer = e.Result;
        }
    }
}
