using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.Win32;
using SupplySystem.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SupplySystem.PL
{
    /// <summary>
    /// Interaction logic for BackUpDB.xaml
    /// </summary>
    public partial class BackUpDB : Window
    {
        DAL.DataAccessLayer access = new DAL.DataAccessLayer();

        public string FORM_NAME { get; private set; } = "النسخ الاحتياطي";

        public BackUpDB()
        {
            InitializeComponent();
            txt_path.DefaultButtonClick += Btn_Path_DefaultButtonClick;
        }
        private void Btn_Path_DefaultButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "حدد مسار واسم النسخة";
                //dialog.AddExtension = true;
                dialog.FileName = "SSDB" + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".bak";
                dialog.DefaultExt = "bak";
                dialog.Filter = "BackUp Database (*.bak)|*.bak";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == true)
                {
                    txt_path.Text = dialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBoxShowing.Show(FORM_NAME, ex.Message, MessageBoxButton.OKCancel);
            }
        }
        private void btnBackUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_path.Text != string.Empty)
                {
                    access.BackUpDatabase(txt_path.Text);
                }
                else
                {
                    MessageBoxShowing.Show(FORM_NAME, "من فضلك حدد مسار النسخة", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBoxShowing.Show(FORM_NAME,ex.Message,MessageBoxButton.OKCancel);
            }
        }
        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "حدد مسار واسم النسخة";
                //dialog.AddExtension = true;
                dialog.Filter = "Restore Database (*.bak)|*.bak";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;
                //access.CloseAllConnection();
                if (dialog.ShowDialog() == true)
                {
                    txt_path.Text = dialog.FileName;


                    access.RestoreDatabase(dialog.FileName);

                }
            }
            catch (Exception ex)
            {
                MessageBoxShowing.Show(FORM_NAME, ex.Message, MessageBoxButton.OKCancel);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch {}
        }
    }
}