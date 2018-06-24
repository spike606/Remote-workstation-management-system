using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Client.WPF.ViewModel.Helpers
{
    /// <summary>
    /// Helper class used in order to pass parameter as reference to CommandFactory instead using value type which is copied once and not updated later
    /// </summary>
    public class UIntParameter
    {
        public UIntParameter(uint parameter)
        {
            this.Parameter = parameter;
        }

        public uint Parameter { get; set; }
    }
}
