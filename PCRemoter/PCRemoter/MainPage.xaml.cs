using PCRemoter.PCRemoterServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


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

        public async Task<string> SendTextToWindow(string someText)
        {
            return await Task.Factory.FromAsync<string, string>(
                Channel.BeginSendTextToWindow,
                Channel.EndSendTextToWindow, someText, null);
        }

    }
}

namespace PCRemoter
{
    public interface IFileWorker
    {
        Task<bool> ExistsAsync(string filename); // проверка существования файла
        Task SaveTextAsync(string filename, string text);   // сохранение текста в файл
        Task<string> LoadTextAsync(string filename);  // загрузка текста из файла
        Task<IEnumerable<string>> GetFilesAsync();  // получение файлов из определнного каталога
        Task DeleteAsync(string filename);  // удаление файла
    }

    public partial class MainPage : TabbedPage
    {        
        public RemoterServiceClient client;
        string testAnswer = "";//ответ об успешности соединения
        string connectIPAddress = "http://192.168.0.37:5051/PCRemoterService";//"http://172.20.10.3:5051/PCRemoterService";/*http://192.168.0.95:5051/PCRemoterService*/ //введенный пользователем адрес хоста 
        string echoAnswer = "";//ответ от службы
       
        string controlAnswer = "";
        public MainPage()
        {            
            InitializeComponent();
            tableConnectionSection.Title = Resource.ConnectionCathegory;
            ipAddress.Label = Resource.IPAddressLabel;
            portAddress.Label = Resource.PortLabel;
            saveSwitch.Text = Resource.SwitchSaveLabel;
            buttonConnect.Text = Resource.ButtonConnectText;
            labelConnectMsg.Text = Resource.StatusStartLabel;
            connectingPage.Title = Resource.ConnectingPageTitle;
            controlsPage.Title = Resource.ControlsPageTitle;
            inputText.Placeholder = Resource.SendTextPlaceholder;
            sendBtn.Text = Resource.SendButtonText;
            leftClckBtn.Text = Resource.LeftClickText;
            rightClckBtn.Text = Resource.RightClickText;
            settingsPage.Title = Resource.SettingsPageTitle;
            testingSection.Title = Resource.TestingSectionTitle;

        }

        private async void OnButtonConnectClicked(object sender, EventArgs e)
        {
            //connectIPAddress = labelPCAddress.Text;
            string endpointAddress = /*labelPCAddress.Text;*/"http://" + ipAddress.Text + ":" + portAddress.Text + "/RemoterService";
            client = new RemoterServiceClient(RemoterServiceClient.EndpointConfiguration.NetHttpBinding_IRemoterService, endpointAddress);

            //проверка соединения
            labelConnectMsg.Text = Resource.StatusConnectingLabel;

            try
            {
                testAnswer = await client.TestConnection();
                if (!string.Equals(testAnswer, "OK", StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new Exception("Host not found!");

                }
                labelConnectMsg.Text = Resource.StatusSuccessLabel;
                Save();                
            }
            catch (Exception ex)
            {
                labelConnectMsg.Text = Resource.StatusFailLabel + ex.Message;
                await DisplayAlert("Error!", "Connecting failed! " + ex.Message, "ОK");
             }

        }

        private async void OnButtonLoadLastClicked(object sender, EventArgs e)
        {
            //LoadFromFile(labelPCAddress.Text);
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

        //-----------------------СТРАНИЦА УПРАВЛЕНИЕ ПК---------------------------------
        
        async void OnSettingsButtonClicked(object sender, EventArgs e)
        {

        }

        async void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        //отправка введенного текста в приложение на ПК
        async void OnSendTextClicked(object sender, EventArgs e)
        {
            string _textToSend = inputText.Text;
            await client.SendTextToWindow(_textToSend);
        }        

        public async void OnControlClicked(object sender, EventArgs e)
        {
            string _buttonName = "";

            if (sender == upBtn)
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

            controlAnswer = await client.Controls(_buttonName);
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();           
        }

        //сохранение пути в файл
        async void Save()
        {
            string filename = "endpointAddress.txt";
            if (String.IsNullOrEmpty(filename)) return;
            // если файл существует
            if (await DependencyService.Get<IFileWorker>().ExistsAsync(filename))
            {
                // запрашиваем разрешение на перезапись
                bool isRewrited = await DisplayAlert("Saving", "Saved path already exists, rewrite?", "Yes", "No");
                if (isRewrited == false) return;
            }
            // перезаписываем файл
            await DependencyService.Get<IFileWorker>().SaveTextAsync(filename, connectIPAddress);            
        }

        public async void LoadFromFile(string _text)
        {
            string filename = "endpointAddress.txt";
            _text = await DependencyService.Get<IFileWorker>().LoadTextAsync(filename);
        }
        async void FileSelect(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem == null) return;
            // получаем выделенный элемент
            string filename = (string)args.SelectedItem;
            // загружем текст в текстовое поле
            //labelPCAddress.Text = await DependencyService.Get<IFileWorker>().LoadTextAsync((string)args.SelectedItem);           
        }
        async void Delete(object sender, EventArgs args)
        {
            // получаем имя файла
            string filename = (string)((MenuItem)sender).BindingContext;
            // удаляем файл из списка
            await DependencyService.Get<IFileWorker>().DeleteAsync(filename);          
            
        }
        

    }
}




