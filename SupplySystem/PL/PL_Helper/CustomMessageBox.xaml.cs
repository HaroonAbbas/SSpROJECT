using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SupplySystem.PL.PL_Helper
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public static bool IsOk = false;
        public CustomMessageBox()
        {
            InitializeComponent();
        }
        public void Show(string header, string body, MessageBoxButton messageBoxButton)
        {
            if (messageBoxButton==MessageBoxButton.OK)
            {
                btnCencel.Visibility = Visibility.Collapsed;
            }
            lbl_Left.Content = "}";
            lbl_Right.Content = "{";
            lbl_HeaderOfMessage.Content = header;
            lbl_BodyOfMessge.Text = body;
            btnOK.Focus();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
        private void btnClipboard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clipboard.SetText( "عنوان الرسالة :  "+lbl_HeaderOfMessage.Content
                    + "\n" + "نص الرسالة : "+                    
                    lbl_BodyOfMessge.Text);
            }
            catch
            {

            }
        }


        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IsOk = true;
                Close();
            }
            catch { }
        }
        private void btnCencel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IsOk = false;
                Close();
            }
            catch { }
        }
    }
}
