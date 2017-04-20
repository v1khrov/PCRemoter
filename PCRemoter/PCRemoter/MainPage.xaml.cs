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
        string connectIPAddress = "http://172.20.10.3:5051/PCRemoterService";/*http://192.168.0.95:5051/PCRemoterService*/ //введенный пользователем адрес хоста 
        string echoAnswer = "";//ответ от службы
       
        string controlAnswer = "";
        public MainPage()
        {
            InitializeComponent();
            
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
                Save();                
            }
            catch (Exception ex)
            {
                labelConnectMsg.Text = "Connecting failed! " + ex.Message;
                await DisplayAlert("Error!", "Connecting failed! " + ex.Message, "ОK");
            }

        }

        private async void OnButtonLoadLastClicked(object sender, EventArgs e)
        {
            LoadFromFile(labelPCAddress.Text);
        }

        private void OnButtonOpenCtrlsClicked(object sender, EventArgs e)
        {
            //new PCControlsPage(client);
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
        public void SendClient(RemoterServiceClient client)
        {

        }

        async void OnSettingsButtonClicked(object sender, EventArgs e)
        {

        }

        async void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await client.SentTextToWindow(inputText.Text);
        }

        void OnSendTextClicked(object sender, EventArgs e)
        {


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
            await UpdateFileList();
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
            // обновляем список файлов
            await UpdateFileList();
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
            labelPCAddress.Text = await DependencyService.Get<IFileWorker>().LoadTextAsync((string)args.SelectedItem);           
        }
        async void Delete(object sender, EventArgs args)
        {
            // получаем имя файла
            string filename = (string)((MenuItem)sender).BindingContext;
            // удаляем файл из списка
            await DependencyService.Get<IFileWorker>().DeleteAsync(filename);
            // обновляем список файлов
            await UpdateFileList();
        }
        // обновление списка файлов
        async Task UpdateFileList()
        {
           
        }

    }
}




