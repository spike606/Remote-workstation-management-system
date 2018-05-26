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

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

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

        public string Unit { get; set; }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
