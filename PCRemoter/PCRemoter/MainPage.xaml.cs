using PCRemoter.PCRemoterServer;
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
        RemoterServiceClient client;
        static string testAnswer = "";//ответ об успешности соединения
        string connectIPAddress = "http://192.168.0.95:5051/PCRemoterService";//введенный пользователем адрес хоста 
        static string echoAnswer = "";//ответ от службы
        public MainPage()
        {
            InitializeComponent();
			BindingContext = _prvm;
        }

		private void OnButtonConnectClicked(object sender, EventArgs e)
		{           
            connectIPAddress = labelPCAddress.Text;
            client = new RemoterServiceClient(0, connectIPAddress);

            try
            {
                //проверка соединения
                labelConnectMsg.Text = "Connecting to service...";

                
                client.TestConnectionCompleted += new EventHandler<TestConnectionCompletedEventArgs>(TestConnectionCallback);
                client.TestConnectionAsync();

                if (!string.Equals(testAnswer, "OK", StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new Exception("Host not found!");                   

                }
                labelConnectMsg.Text = "Connecting successed!";
            }
            catch (Exception ex)
            {
                labelConnectMsg.Text = "Connecting failed! " + ex.Message;
                DisplayAlert("Error!", "Connecting failed! " + ex.Message, "ОK");
            }               

		}

        private async void OnButtonOpenCtrlsClicked (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PCControlsPage(client));
        }

        void OnButtonEchoClicked(object sender, EventArgs e)
		{
            try
            {
                client.EchoAsync(labelMessage.Text);
                client.EchoCompleted += new EventHandler<EchoCompletedEventArgs>(EchoCallback);
                labelAnswer.Text = echoAnswer;
                if(echoAnswer=="")
                {
                    throw new Exception("Host didn't answer.");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error!", ex.Message, "ОK");
            }
            
		}

        static void TestConnectionCallback(object sender, TestConnectionCompletedEventArgs e)
        {
            testAnswer = e.Result;
        }

        static void  EchoCallback(object sender, EchoCompletedEventArgs e)
        {
            echoAnswer = e.Result;
        }
    }
}
