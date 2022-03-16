using DevExpress.Xpf.LayoutControl;
using SupplySystem.BL;
using SupplySystem.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SupplySystem.PL
{
    /// <summary>
    /// Interaction logic for Sides.xaml
    /// </summary>
    public partial class Sides : UserControl, HomeInterface
    {
        int Side_Type { get; set; } = 1;
        CS_Sides op = new CS_Sides();
        int OneAddTowUpdate = 0;
        public Sides(int sidetype)
        {
            Side_Type = sidetype;
            InitializeComponent();
            ToolsEnabeld(false);
            Loaded += Sides_Loaded;
        }

        private void Sides_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }

        string fName { get; set; }
        public string FORM_NAME
        {
            get
            {
                if (Side_Type == 1)
                {
                    fName = "الجهات المقدمة للخدمة";
                }
                else if (Side_Type == 2)
                {
                    fName = "الجهات المستفيدة";
                }
                return fName;
            }
            set
            { value = fName; }
        }

        public bool HasPrint { get; set; } = false;

        public SidesModel GetFromUser()
        {
            var m = new SidesModel();
            m.SIDE_NO = int.Parse(txt_SIDE_NO.Text);
            m.SIDE_A_NAME = txt_SIDE_A_NAME.Text;
            m.SIDE_E_NAME = txt_SIDE_E_NAME.Text;
            m.SIDE_TYPE = Side_Type;
            
            m.AD_U_ID = Properties.Settings.Default.U_ID;
            m.AD_DATE = DateTime.Now;
            m.AD_TRMNL_NM = Environment.MachineName + "-" + Environment.UserName;

            if (OneAddTowUpdate==2)
            {
                m.UP_U_ID = Properties.Settings.Default.U_ID;
                m.UP_DATE = DateTime.Now;
                m.UP_TRMNL_NM = Environment.MachineName + "-" + Environment.UserName;
            }
            return m;
        }
        public void BtnDelete()
        {
            try
            {
                if (txt_SIDE_NO.Text != string.Empty)
                {
                    if (Side_Type == 1)
                    {
                        int count = op.ConfSides_SEND_TO_SIDE_NO_InSupplyBonds(GetFromUser().SIDE_NO).Rows.Count;
                        if (count > 0)
                        {
                            MessageBoxShowing.Show(FORM_NAME, "لا يمكن حذف الجهة المقدمة للخدمة لوجود حركة ", MessageBoxButton.OK);
                        }
                        else
                        {
                            op.DeleteSides(GetFromUser());
                            ClearTools();
                            BtnRefresh();
                        }
                    }
                    if (Side_Type == 2)
                    {
                        int count = op.ConfSides_NOTES_SIDE_NO_nSupplyBonds(GetFromUser().SIDE_NO).Rows.Count;
                        if (count > 0)
                        {
                            MessageBoxShowing.Show(FORM_NAME, "لا يمكن حذف الجهة المستفيدة لوجود حركة ", MessageBoxButton.OK);
                        }
                        else
                        {
                            op.DeleteSides(GetFromUser());
                            ClearTools();
                            BtnRefresh();
                        }
                    }
                }
                else
                {
                    MessageBoxShowing.Show(FORM_NAME, "لا يوجد بيانات لحذفها", MessageBoxButton.OK);
                }
            }
            catch
            {

            }
        }
        private void ClearTools()
        {
            txt_SIDE_NO.Text = txt_SIDE_A_NAME.Text = txt_SIDE_E_NAME.Text = string.Empty;
        }
        public void BtnNew()
        {
            try
            {
                OneAddTowUpdate = 1;
                ToolsEnabeld(true);
                ClearTools();
                txt_SIDE_NO.Text = op.MaxId(Side_Type).ToString();
                txt_SIDE_A_NAME.Focus();
            }
            catch
            {

            }
        }

        public void BtnRefresh()
        {
            try
            {
                List<SidesModel> list = new List<SidesModel>();
                SidesModel t;
                for (int i = 0; i < op.GetSides(Side_Type).Rows.Count; i++)
                {
                    var item = op.GetSides(Side_Type).Rows[i];
                    list.Add(new SidesModel()
                    {
                        SIDE_NO = int.Parse(item[nameof(t.SIDE_NO)].ToString()),
                        SIDE_A_NAME = item[nameof(t.SIDE_A_NAME)].ToString(),
                        SIDE_E_NAME = item[nameof(t.SIDE_E_NAME)].ToString(),
                        SIDE_TYPE = int.Parse(item[nameof(t.SIDE_TYPE)].ToString()),
                    });
                }
                dgView.ItemsSource = list;
            }
            catch { }
        }

        public void BtnUndo()
        {
            try
            {
                OneAddTowUpdate = 0;
                ToolsEnabeld(false);
                ClearTools();
            }
            catch { }
        }

        public void BtnUpdate()
        {
            try
            {
                if (txt_SIDE_NO.Text != string.Empty)
                {
                    OneAddTowUpdate = 2;
                    ToolsEnabeld(true);
                    txt_SIDE_NO.IsEnabled = false;
                    txt_SIDE_A_NAME.Focus();
                }
                else
                {
                    MessageBoxShowing.Show(FORM_NAME, "لا يوجد بيانات لتعديلها", MessageBoxButton.OK);
                }
            }
            catch { }
        }
        public void BtnSave()
        {
            try
            {
                if (OneAddTowUpdate == 1)
                {
                    txt_SIDE_NO.Text = op.MaxId(Side_Type).ToString();
                    op.InsertUpdateSides(GetFromUser(),1);
                }
                else if (OneAddTowUpdate == 2)
                {
                    op.InsertUpdateSides(GetFromUser(),2);
                }
                ToolsEnabeld(false);
            }
            catch { }
        }

        public string UserValid()
        {
            string str = string.Empty;
            if (txt_SIDE_A_NAME.Text == string.Empty || txt_SIDE_E_NAME.Text == string.Empty)
            {
                str = "يرجى تعبئة الحقول الرئيسية";
            }
            return str;
        }

        public void ToolsEnabeld(bool isenabeld)
        {
            if (isenabeld == false)
            {
                gTools.IsEnabled = false;
                dgView.IsEnabled = true;
            }
            else
            {
                gTools.IsEnabled = true;
                dgView.IsEnabled = false;
            }
        }

        private void _SetToUser(SidesModel item)
        {
            txt_SIDE_NO.Text = item.SIDE_NO.ToString();
            txt_SIDE_A_NAME.Text = item.SIDE_A_NAME;
            txt_SIDE_E_NAME.Text = item.SIDE_E_NAME;
        }

        private void dgView_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = dgView.SelectedItem as SidesModel;
                if (item != null)
                {
                    _SetToUser(item);
                }
            }
            catch
            {
            }
        }

        public void BtnNewFrom()
        {
            try
            {
                OneAddTowUpdate = 1;
                ToolsEnabeld(true);
                txt_SIDE_NO.Text = op.MaxId(Side_Type).ToString();
                txt_SIDE_A_NAME.Focus();
            }
            catch
            {

            }
        }

        public void BtnPrint()
        {
            
        }
    }
}