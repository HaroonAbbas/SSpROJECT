using SupplySystem.BL;
using SupplySystem.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SupplySystem.PL
{
    /// <summary>
    /// Interaction logic for SpareParts.xaml
    /// </summary>
    public partial class SpareParts : UserControl, HomeInterface
    {
        CS_SpareParts op = new CS_SpareParts();
        int OneAddTowUpdate = 0;
        public SpareParts()
        {
            InitializeComponent();
            ToolsEnabeld(false);
            Loaded += SpareParts_Loaded;
        }

        private void SpareParts_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch { }
        }

        public string FORM_NAME { get; set; } = "قطع الغيار";
        public bool HasPrint { get; set; } = false;

        public SparePartsModel GetFromUser()
        {

            var m = new SparePartsModel();
            m.PieceName = txt_PieceName.Text;
            m.StorageNumber = txt_StorageNumber.Text;
         
            m.AD_U_ID = Properties.Settings.Default.U_ID;
            m.AD_DATE = DateTime.Now;
            m.AD_TRMNL_NM = Environment.MachineName + "-" + Environment.UserName;

            if (OneAddTowUpdate == 2)
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
                if (txt_StorageNumber.Text != string.Empty)
                {
                    int count = op.ConfSparePartsInSupplyBonds(GetFromUser().StorageNumber).Rows.Count;
                    if (count > 0)
                    {
                        MessageBoxShowing.Show(FORM_NAME, "لا يمكن حذف رقم التخزين لوجود حركة له", MessageBoxButton.OK);
                    }
                    else
                    {
                        op.DeleteSpareParts(GetFromUser());
                        ClearTools();
                        BtnRefresh();
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
            txt_PieceName.Text = txt_StorageNumber.Text = string.Empty;
        }
        public void BtnNew()
        {
            try
            {
                OneAddTowUpdate = 1;
                ToolsEnabeld(true);
                ClearTools();
                txt_PieceName.Focus();
            }
            catch
            {

            }
        }

        public void BtnRefresh()
        {
            try
            {
                List<SparePartsModel> list = new List<SparePartsModel>();
                SparePartsModel t;
                for (int i = 0; i < op.GetSpareParts().Rows.Count; i++)
                {
                    var item = op.GetSpareParts().Rows[i];
                    list.Add(new SparePartsModel()
                    {
                        PieceName = item[nameof(t.PieceName)].ToString(),
                        StorageNumber = item[nameof(t.StorageNumber)].ToString(),
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
                if (txt_StorageNumber.Text != string.Empty)
                {
                    OneAddTowUpdate = 2;
                    ToolsEnabeld(true);
                    txt_StorageNumber.IsEnabled = false;
                    txt_PieceName.Focus();
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
                    op.InsertUpdateSpareParts(GetFromUser(),1);

                }
                else if (OneAddTowUpdate == 2)
                {
                    op.InsertUpdateSpareParts(GetFromUser(),2);
                }
                ToolsEnabeld(false);
            }
            catch { }
        }

        public string UserValid()
        {
            string str = string.Empty;
            if (txt_PieceName.Text == string.Empty || txt_StorageNumber.Text == string.Empty)
            {
                txt_StorageNumber.Focus();
                str = "يرجى تعبئة كل الحقول";
            }
            if (OneAddTowUpdate == 1)
            {
                if (op.ConfSpareParts(GetFromUser()).Rows.Count > 0)
                {
                    str = "رقم التخزين موجود مسبقا";
                }
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

        private void _SetToUser(SparePartsModel item)
        {
            txt_PieceName.Text = item.PieceName;
            txt_StorageNumber.Text = item.StorageNumber;
        }

        private void dgView_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = dgView.SelectedItem as SparePartsModel;
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
                txt_PieceName.Focus();
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