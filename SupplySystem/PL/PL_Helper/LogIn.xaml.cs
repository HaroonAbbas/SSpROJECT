using SupplySystem.BL;
using SupplySystem.Models;
using SupplySystem.PL.PL_Helper;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {

        CS_Units cS_Units = new CS_Units();
        CS_Users cS_Users = new CS_Users();
        public LogIn()
        {
            InitializeComponent();
            
            if (cS_Units.GetUnits().Rows.Count > 0)
            {

                txt_HelloorLogin.Text = "تسجيل الدخول";
                btnLogin.Content = "دخول";
                DataTable dt = cS_Units.GetUnits();

                lbl_UnitNameId.Text = dt.Rows[0][1].ToString() + "-" + dt.Rows[0][2].ToString();

                // تغير االى حالة المستخدمين
                {
                    icon_UnitName_and_UserNo.Kind = MaterialDesignThemes.Wpf.PackIconKind.User;
                    icon_UnitidName_and_UserPassword.Kind = MaterialDesignThemes.Wpf.PackIconKind.Password;

                    txt_UnitidName.Visibility = Visibility.Collapsed;
                    txt_Password.Visibility = Visibility.Visible;
                }

                txt_UnitName_and_UserNo.Text = Properties.Settings.Default.U_ID.ToString();
                txt_Password.Focus();
            }
            else
            {
                lbl_UnitNameId.Text = "";
                txt_HelloorLogin.Text = "ادخال بيانات الوحدة";
                btnLogin.Content = "اضافة";
                txt_UnitName_and_UserNo.NullText = "ادخل اسم الوحدة";
                txt_UnitidName.NullText = "ادخل رمز الوحدة";

                txt_UnitidName.IsEnabled = txt_UnitName_and_UserNo.IsEnabled = true;

            }

        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cS_Units.GetUnits().Rows.Count == 0)
                {
                    UnitsModel units = new UnitsModel();
                    units.UnitId = 1;
                    units.UnitName = txt_UnitName_and_UserNo.Text;
                    units.UnitIdName = txt_UnitidName.Text;

                    if (txt_UnitName_and_UserNo.Text == string.Empty || txt_UnitidName.Text == string.Empty)
                    {
                        MessageBoxShowing.Show("بيانات الوحدات", " من فضلك قم بتعبئة البيانات بشكل صحيح", MessageBoxButton.OK);
                    }
                    else
                    {
                        cS_Units.InsertUnit(units);

                        MessageBoxShowing.Show("بيانات الوحدات", "تمت العملية بنجاح", MessageBoxButton.OK);

                        if (cS_Units.GetUnits().Rows.Count > 0)
                        {
                            txt_HelloorLogin.Text = "تسجيل الدخول";
                            btnLogin.Content = "دخول";
                            DataTable dt = cS_Units.GetUnits();

                            lbl_UnitNameId.Text = dt.Rows[0][1].ToString() + "-" + dt.Rows[0][2].ToString();

                            // تغير االى حالة المستخدمين
                            {
                                icon_UnitName_and_UserNo.Kind = MaterialDesignThemes.Wpf.PackIconKind.User;
                                icon_UnitidName_and_UserPassword.Kind = MaterialDesignThemes.Wpf.PackIconKind.Password;

                                txt_UnitidName.Visibility = Visibility.Collapsed;
                                txt_Password.Visibility = Visibility.Visible;

                                txt_UnitidName.Text = txt_UnitName_and_UserNo.Text = string.Empty;
                            }

                        }
                    }
                }

                else if (cS_Units.GetUnits().Rows.Count > 0)
                {
                    if (string.IsNullOrEmpty(txt_UnitName_and_UserNo.Text)
                        || string.IsNullOrEmpty(txt_Password.Text))
                    {
                        MessageBoxShowing.Show("بيانات المستخدم", "اسم المستخدم او كلمة المرور غير صالحة ", MessageBoxButton.OK);
                    }
                    int userid = int.Parse(txt_UnitName_and_UserNo.Text);
                    if (cS_Users.ConfUser(userid,txt_Password.Text).Rows.Count == 0)
                    {
                        MessageBoxShowing.Show("بيانات المستخدم", "اسم المستخدم او كلمة المرور غير صالحة ", MessageBoxButton.OK);
                    }
                    if (cS_Users.IsInavtive(userid, txt_Password.Text).Rows.Count > 0)
                    {
                        MessageBoxShowing.Show("بيانات المستخدم", "المستخدم موقف", MessageBoxButton.OK);
                    }
                   else if (cS_Users.ConfUser(userid,txt_Password.Text).Rows.Count > 0)
                    {
                        Properties.Settings.Default.U_ID = userid;
                        Properties.Settings.Default.Save();
                        
                        this.Hide();
                        HomeWindow home = new HomeWindow();
                        home.ShowDialog();
                    }
                }
            }
            catch
            {

            }
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try { Application.Current.Shutdown(); } catch { }
        }

        private void txt_Password_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key==Key.Enter)
                {
                    btnLogin_Click(sender, e);
                }
            }
            catch { }
        }
    }
}