using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DataBinding.Modelo
{
    public class Persona : INotifyPropertyChanged
    {
        private string name;
        private string phone;
        private string address;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }
            set => phone = value;
        }
        public string Address
        {
            get
            {
                return address;
            }
            set => address = value;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string proName = null)
        {
            PropertyChanged.Invoke(this, PropertyChangedEventArgs(proName));
        }

        private PropertyChangedEventArgs PropertyChangedEventArgs(string proName)
        {
            throw new NotImplementedException();
        }
    }
}
