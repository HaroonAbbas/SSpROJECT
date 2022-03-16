using SupplySystem.PL.PL_Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SupplySystem.Models
{
    public static class MessageBoxShowing
    {
        static MessageBoxResult result;
        public static MessageBoxResult Show(string header, string body, MessageBoxButton messageBoxButton)
        {
           
            if (body != string.Empty)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox();
                customMessageBox.Show(
                    header, body, messageBoxButton);
                customMessageBox.ShowDialog();
            }
            if (CustomMessageBox.IsOk==true)
            {
                result = MessageBoxResult.OK;
            }
            else if (CustomMessageBox.IsOk == false)
            {
                result = MessageBoxResult.Cancel;
            }
            return result;
        }
    }
}