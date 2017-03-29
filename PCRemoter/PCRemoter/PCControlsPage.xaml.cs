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

            if (sender == rightClckBtn)
                _buttonName = "clickRight";

            if (sender == leftClckBtn)
                _buttonName = "clickLeft"; 
            

            try
            {
                controlsClient.ControlsAsync(_buttonName);
                controlsClient.ControlsCompleted += new EventHandler<ControlsCompletedEventArgs>(ControlsCallback);

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

        static void ControlsCallback(object sender, ControlsCompletedEventArgs e)
        {
            controlAnswer = e.Result;
        }
    }
}
