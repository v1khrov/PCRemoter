using PCRemoter.PCRemoterServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCRemoter.PCRemoterServer
{
    public partial class RemoterServiceClient : ClientBase<IRemoterService>, IRemoterService
    {
        public async Task<string> TestConnection()
        {
            return await Task.Factory.FromAsync<string>(
                Channel.BeginTestConnection,
                Channel.EndTestConnection, null);
        }

        public async Task<string> Echo(string message)
        {
            return await Task.Factory.FromAsync<string, string>(
                Channel.BeginEcho,
                Channel.EndEcho, message, null);
        }

        public async Task<string> Controls(string buttonName)
        {
            return await Task.Factory.FromAsync<string, string>(
                Channel.BeginControls,
                Channel.EndControls, buttonName, null);
        }

        public async Task<string> SentTextToWindow(string someText)
        {
            return await Task.Factory.FromAsync<string, string>(
                Channel.BeginSendTextToWindow,
                Channel.EndSendTextToWindow, someText, null);
        }

    }
}

namespace PCRemoter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectionPage : ContentPage
    {
        PCRemoterViewModel _prvm = new PCRemoterViewModel();
        static public RemoterServiceClient client;
        string testAnswer = "";//ответ об успешности соединения
        string connectIPAddress = "http://192.168.0.95:5051/PCRemoterService";//введенный пользователем адрес хоста 
        string echoAnswer = "";//ответ от службы
        public ConnectionPage()
        {
            InitializeComponent();
            BindingContext = _prvm;
        }
        private async void OnButtonConnectClicked(object sender, EventArgs e)
        {
            connectIPAddress = labelPCAddress.Text;
            client = new RemoterServiceClient(0, connectIPAddress);

            //проверка соединения
            labelConnectMsg.Text = "Connecting to service...";

            try
            {
                testAnswer = await client.TestConnection();
                if (!string.Equals(testAnswer, "OK", StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new Exception("Host not found!");

                }
                labelConnectMsg.Text = "Connecting successed!";
            }
            catch (Exception ex)
            {
                labelConnectMsg.Text = "Connecting failed! " + ex.Message;
                await DisplayAlert("Error!", "Connecting failed! " + ex.Message, "ОK");
            }

        }

        private async void OnButtonOpenCtrlsClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new PCControlsPage(client));
        }

        async void OnButtonEchoClicked(object sender, EventArgs e)
        {
            try
            {
                echoAnswer = await client.Echo(labelMessage.Text);
                labelAnswer.Text = echoAnswer;
                if (echoAnswer == "")
                {
                    throw new Exception("Host didn't answer.");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error!", ex.Message, "ОK");
            }

        }
    }
}
