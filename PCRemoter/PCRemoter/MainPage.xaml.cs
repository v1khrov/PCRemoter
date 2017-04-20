using PCRemoter.PCRemoterServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;




namespace PCRemoter
{
    public partial class MainPage : TabbedPage
    {
		
        public MainPage()
        {
            InitializeComponent();
            ConnectionPage _cpage = new ConnectionPage();
            Children.Add(_cpage);
            Children.Add(new PCControlsPage());
            Children.Add(new SettingsPage());
        }
               
       
    }
}
