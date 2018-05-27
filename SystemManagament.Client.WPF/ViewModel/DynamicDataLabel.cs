using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Client.WPF.ViewModel
{

    public class DynamicDataLabel : INotifyPropertyChanged
    {
        private string value;
        private string name;
        private string unit;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        public string Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
                this.OnPropertyChanged("Value");
            }
        }

        public string Unit
        {
            get
            {
                return this.unit;
            }

            set
            {
                this.unit = value;
                this.OnPropertyChanged("Unit");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
