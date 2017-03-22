using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace PCRemoter
{
    class PCRemoterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        PCRemoterConnect _pcr = new PCRemoterConnect();

        public PCRemoterViewModel()
        {

        }

        public string ipAddress
        {
            get { return _pcr.ipAddress; }
            set { OnPropertyChanged(); }
        }

        private void OnPropertyChanged([CallerMemberName] string PropName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropName));
        }
    }
}
