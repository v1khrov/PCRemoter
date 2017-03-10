using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PCRemoter
{
    public class PCRemoter
    {
        string _ipAddress = "localhost:5051";

        public string ipAddress
        {
            get { return _ipAddress; }
        }

        internal class App : Application
        {
        }
    }
}
