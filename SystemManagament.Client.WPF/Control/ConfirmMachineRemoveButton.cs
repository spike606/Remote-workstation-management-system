using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SystemManagament.Client.WPF.Control
{
    public class ConfirmMachineRemoveButton : Button
    {
        protected override void OnClick()
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure? This will remove machine from the list, configuration data will be lost.",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                base.OnClick();
            }
        }
    }
}
