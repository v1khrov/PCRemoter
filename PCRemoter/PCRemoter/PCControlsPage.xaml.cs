using PCRemoter.PCRemoterServer;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PCRemoter
{
	public partial class PCControlsPage : ContentPage
	{		
        RemoterServiceClient controlsClient;//объект класса клиента веб службы
        string controlAnswer = "";

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

        async void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await controlsClient.SentTextToWindow(inputText.Text);
        }

        void OnSendTextClicked (object sender, EventArgs e)
        {

        }

            async void OnControlClicked(object sender, EventArgs e)
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

            if (sender == tabBtn)
                _buttonName = "buttonTab";

            if (sender == enterBtn)
                _buttonName = "buttonEnter";

            if (sender == f5Btn)
                _buttonName = "buttonF5";

            if (sender == escBtn)
                _buttonName = "buttonEsc";

            if (sender == delBtn)
                _buttonName = "buttonDelete";

            if (sender == rightClckBtn)
                _buttonName = "clickRight";

            if (sender == leftClckBtn)
                _buttonName = "clickLeft";

            controlAnswer = await controlsClient.Controls(_buttonName);
                             
              
        }
        
    }
}
