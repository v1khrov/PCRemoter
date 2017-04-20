using PCRemoter.PCRemoterServer;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PCRemoter
{
	public partial class PCControlsPage : ContentPage
	{		
        RemoterServiceClient controlsClient;//объект класса клиента веб службы
        string _endpoint="";
        ConnectionPage _cp;
        string controlAnswer = "";

        public PCControlsPage()
		{
            //controlsClient = ConnectionPage.client;
            //ConnectionPage.ShareClient(out controlsClient);
            InitializeComponent();
           // _cp = new ConnectionPage();
            
        }

        //конструктор с передачей клиента
        public PCControlsPage(RemoterServiceClient client)
        {
            InitializeComponent();
            controlsClient = client;           
        }

        public void SendClient(RemoterServiceClient client)
        {

        }

        async void OnSettingsButtonClicked(object sender, EventArgs e)
		{
            LoadFromFile(_endpoint);
            controlsClient = new RemoterServiceClient(0, _endpoint);
        }

        async void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await controlsClient.SentTextToWindow(inputText.Text);
        }

        void OnSendTextClicked (object sender, EventArgs e)
        {


        }

        public async void LoadFromFile(string _text)
        {
            string filename = "endpointAddress.txt";
            _text = await DependencyService.Get<IFileWorker>().LoadTextAsync(filename);
            //return _text;
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

            if (sender == chwinBtn)
                _buttonName = "buttonChangeWindow";

            controlAnswer = await controlsClient.Controls(_buttonName);
                             
              
        }
        
    }
}
