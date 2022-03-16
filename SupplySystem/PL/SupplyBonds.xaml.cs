using DevExpress.XtraPrinting.Caching;
using SupplySystem.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Printing;
using SupplySystem.BL;
using System.Linq;
using DevExpress.Xpf.Editors;

namespace SupplySystem.PL
{
    /// <summary>
    /// Interaction logic for SupplyBonds.xaml
    /// </summary>
    public partial class SupplyBonds : UserControl, HomeInterface
    {
        CS_Sides side_op = new CS_Sides();
        CS_SpareParts _spareParts_op = new CS_SpareParts();
        CS_SupplyBonds _SupplyBonds_op = new CS_SupplyBonds();
        int OneAddTowUpdate = 0;
        public SupplyBonds()
        {
            InitializeComponent();
            //DataContext = this;
            ToolsEnabeld(false);
            this.Loaded += SupplyBonds_Loaded;
            txt_REQUIRED_QTY.EditValueChanged += Txt_REQUIRED_QTY_EditValueChanged;
            txt_RECEIVED_QTY.EditValueChanged += Txt_REQUIRED_QTY_EditValueChanged;
        }

        private void Txt_REQUIRED_QTY_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            try
            {
                int req_qty = txt_REQUIRED_QTY.Text != "" ? int.Parse(txt_REQUIRED_QTY.Text) : 0;
                int rec_qty = txt_RECEIVED_QTY.Text != "" ? int.Parse(txt_RECEIVED_QTY.Text) : 0;

                txt_WAITING_ENTRY_QTY.Text = (req_qty - rec_qty).ToString();
            }
            catch
            {

            }
        }

        private void SupplyBonds_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                comb_SEND_TO_SIDE_NO.ItemsSource = side_op.GetSides(1);
                comb_NOTES_SIDE_NO.ItemsSource = side_op.GetSides(2);
                comb_StorageNumber.ItemsSource = _spareParts_op.GetSpareParts();
            }
            catch { }
        }

        public string FORM_NAME
        {
            get;
            set;
        } = "سندات التموين";
        public bool HasPrint { get; set; } = true;

        private void GetJulianDate()
        {
            int year = date_OP_DATE.DateTime.Year % 10;
            int dayofYear = date_OP_DATE.DateTime.DayOfYear;
            string result = string.Empty;
            if (dayofYear <= 99 || dayofYear >= 10)
            {
                result = year.ToString() + "0" + dayofYear;
            }
            if (dayofYear > 99)
            {
                result = year.ToString() + dayofYear;
            }
            if (dayofYear < 10)
            {
                result = year.ToString() + "00" + dayofYear;
            }
            txt_JULIAN_DATE.Text = result;
        }
        public void BtnDelete()
        {
            try
            {
                if (txt_OP_ID.Text != string.Empty)
                {
                    _SupplyBonds_op.DeleteSides(int.Parse(txt_OP_ID.Text));
                    ClearTools();
                    BtnRefresh();
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
        private void GetMaxSerial()
        {
            int max = _SupplyBonds_op.GetSerialNoByDate(txt_JULIAN_DATE.Text);
            string result = string.Empty;
            if (max <= 99 || max >= 10)
            {
                result = "0" + max;
            }
            if (max > 99)
            {
                result = max.ToString();
            }
            if (max < 10)
            {
                result = "00" + max;
            }
            txt_SERIAL_NO.Text = result;
        }
        private void GetData()
        {
            date_OP_DATE.EditValue = DateTime.Now;
            txt_OP_ID.Text = _SupplyBonds_op.MaxId().ToString();
            GetJulianDate();
            GetMaxSerial();
        }

        public void BtnNew()
        {
            try
            {
                ClearTools();
                GetData();
                OneAddTowUpdate = 1;
                ToolsEnabeld(true);
                comb_SEND_TO_SIDE_NO.Focus();
            }
            catch
            {

            }
        }

        public void BtnRefresh()
        {
            try
            {
                List<SupplyBondsModel> list = new List<SupplyBondsModel>();
                SupplyBondsModel t;
                for (int i = 0; i < _SupplyBonds_op.GetSupplyBonds().Rows.Count; i++)
                {
                    var item = _SupplyBonds_op.GetSupplyBonds().Rows[i];
                    list.Add(new SupplyBondsModel()
                    {
                        SERIAL_NO = item[nameof(t.SERIAL_NO)].ToString(),
                        JULIAN_DATE = item[nameof(t.JULIAN_DATE)].ToString(),
                        OP_DATE = DateTime.Parse(item[nameof(t.OP_DATE)].ToString()),
                        OP_ID = int.Parse(item[nameof(t.OP_ID)].ToString()),
                    });
                }
                dgView.ItemsSource = list.OrderByDescending(i => i.JULIAN_DATE);
                dgView.RefreshData();
            }
            catch { }
        }
        public SupplyBondsModel GetFromUser()
        {
            var m = new SupplyBondsModel();
            m.COMPLETION_DATE = txt_COMPLETION_DATE.Text;
            m.FIELD_PRIORITY = txt_FIELD_PRIORITY.Text;
            m.FOLLOW_UP_DATE = txt_FOLLOW_UP_DATE.Text;
            m.INITIAL_SIGNATURE = txt_INITIAL_SIGNATURE.Text;
            m.JULIAN_DATE = txt_JULIAN_DATE.Text;
            m.NOTES_SIDE_NO = int.Parse(comb_NOTES_SIDE_NO.EditValue.ToString());
            m.OP_DATE = DateTime.Parse(date_OP_DATE.EditValue.ToString());
            m.OP_ID = int.Parse(txt_OP_ID.Text);
            m.RECEIVED_QTY = int.Parse(txt_RECEIVED_QTY.Text);
            m.REQUEST_FOR = txt_REQUEST_FOR.Text;
            m.REQUIRED_QTY = int.Parse(txt_REQUIRED_QTY.Text);
            m.SEND_TO_SIDE_NO = int.Parse(comb_SEND_TO_SIDE_NO.EditValue.ToString());
            m.SERIAL_NO = txt_SERIAL_NO.Text;
            m.StorageNumber = comb_StorageNumber.EditValue.ToString();
            m.WAITING_ENTRY_QTY = int.Parse(txt_WAITING_ENTRY_QTY.Text);

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

        private void ClearTools()
        {
            foreach (var item in AllSystemTools.FindVisualChildren<TextEdit>(this))
            {
                item.Text = "";
            }
            comb_NOTES_SIDE_NO.Text = comb_SEND_TO_SIDE_NO.Text = comb_StorageNumber.Text;
            date_OP_DATE.Text = "";
        }

        public void BtnSave()
        {
            try
            {
                if (OneAddTowUpdate == 1)
                {
                    _SupplyBonds_op.InsertUpdateSupplyBonds(GetFromUser(), 1);
                }
                else if (OneAddTowUpdate == 2)
                {
                    _SupplyBonds_op.InsertUpdateSupplyBonds(GetFromUser(), 2);
                }
                ToolsEnabeld(false);
            }
            catch (Exception ex)
            {
                MessageBoxShowing.Show(FORM_NAME, ex.Message, MessageBoxButton.OK);
            }
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
                if (txt_OP_ID.Text != string.Empty)
                {
                    OneAddTowUpdate = 2;
                    ToolsEnabeld(true);
                    comb_SEND_TO_SIDE_NO.Focus();
                }
                else
                {
                    MessageBoxShowing.Show(FORM_NAME, "لا يوجد بيانات لتعديلها", MessageBoxButton.OK);
                }
            }
            catch { }
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

        public string UserValid()
        {
            string str = string.Empty;
            if (comb_SEND_TO_SIDE_NO.Text == string.Empty || comb_NOTES_SIDE_NO.Text == string.Empty)
            {
                str = "يرجى تعبئة الحقول الرئيسية";
            }
            return str;
        }

        private void dgView_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = dgView.SelectedItem as SupplyBondsModel;
                if (item != null)
                {
                    _SetToUser(item);
                }
            }
            catch
            {
            }
        }
        private void _SetToUser(SupplyBondsModel s)
        {
            for (int i = 0; i < _SupplyBonds_op.GetSupplyBondsById(s.OP_ID).Rows.Count; i++)
            {
                SupplyBondsModel t;
                var item = _SupplyBonds_op.GetSupplyBondsById(s.OP_ID).Rows[i];
                txt_COMPLETION_DATE.Text = item[nameof(t.COMPLETION_DATE)].ToString();
                txt_FIELD_PRIORITY.Text = item[nameof(t.FIELD_PRIORITY)].ToString();
                txt_FOLLOW_UP_DATE.Text = item[nameof(t.FOLLOW_UP_DATE)].ToString();
                txt_INITIAL_SIGNATURE.Text = item[nameof(t.INITIAL_SIGNATURE)].ToString();
                txt_JULIAN_DATE.Text = item[nameof(t.JULIAN_DATE)].ToString();
                comb_NOTES_SIDE_NO.EditValue = item[nameof(t.NOTES_SIDE_NO)];
                date_OP_DATE.EditValue = item[nameof(t.OP_DATE)].ToString();
                txt_OP_ID.Text = item[nameof(t.OP_ID)].ToString();
                txt_RECEIVED_QTY.Text = item[nameof(t.RECEIVED_QTY)].ToString();
                txt_REQUEST_FOR.Text = item[nameof(t.REQUEST_FOR)].ToString();
                txt_REQUIRED_QTY.Text = item[nameof(t.REQUIRED_QTY)].ToString();
                comb_SEND_TO_SIDE_NO.EditValue = item[nameof(t.SEND_TO_SIDE_NO)];
                txt_SERIAL_NO.Text = item[nameof(t.SERIAL_NO)].ToString();
                comb_StorageNumber.EditValue = item[nameof(t.StorageNumber)].ToString();
                txt_WAITING_ENTRY_QTY.Text = item[nameof(t.WAITING_ENTRY_QTY)].ToString();
            }
        }
    
        public void BtnNewFrom()
        {
            try
            {
                GetData();
                OneAddTowUpdate = 1;
                ToolsEnabeld(true);
                comb_SEND_TO_SIDE_NO.Focus();
            }
            catch
            {

            }
        }
        private void comb_SEND_TO_SIDE_NO_PopupOpened(object sender, RoutedEventArgs e)
        {
            try
            {
                var g = comb_SEND_TO_SIDE_NO.GetGridControl();
                if (g != null)
                {
                    SidesModel t;
                    g.Columns[nameof(t.SIDE_NO)].Header = "رقم الجهة";
                    g.Columns[nameof(t.SIDE_A_NAME)].Header = "اسم الجهة عربي";
                    g.Columns[nameof(t.SIDE_E_NAME)].Header = "اسم الجهة انجليزي";

                    comb_SEND_TO_SIDE_NO.ItemsSource = side_op.GetSides(1);
                }
            }
            catch { }
        }

        private void comb_StorageNumber_PopupOpened(object sender, RoutedEventArgs e)
        {
            try
            {
                var g = comb_StorageNumber.GetGridControl();
                if (g != null)
                {
                    SparePartsModel t;
                    g.Columns[nameof(t.StorageNumber)].Header = "رقم التخزين";
                    g.Columns[nameof(t.PieceName)].Header = "اسم القطعة";

                    comb_StorageNumber.ItemsSource = _spareParts_op.GetSpareParts();
                }
            }
            catch { }
        }

        private void comb_NOTES_SIDE_NO_PopupOpened(object sender, RoutedEventArgs e)
        {
            try
            {
                var g = comb_NOTES_SIDE_NO.GetGridControl();
                if (g != null)
                {
                    SidesModel t;
                    g.Columns[nameof(t.SIDE_NO)].Header = "رقم الجهة";
                    g.Columns[nameof(t.SIDE_A_NAME)].Header = "اسم الجهة عربي";
                    g.Columns[nameof(t.SIDE_E_NAME)].Header = "اسم الجهة انجليزي";

                    comb_NOTES_SIDE_NO.ItemsSource = side_op.GetSides(2);
                }
            }
            catch { }
        }

        public void BtnPrint()
        {
            try
            {
                var storg = new MemoryDocumentStorage();
                RPT.RPTSupplyBonds report = new RPT.RPTSupplyBonds();
                report.ShowPrintStatusDialog = true;

                for (int i = 0; i < report.Parameters.Count; i++)
                {
                    report.Parameters[i].Visible = false;
                }
                report.JulianDate.Value = txt_JULIAN_DATE.Text;
             
                var cache = new CachedReportSource(report, storg);
                PrintHelper.ShowPrintPreview(this, cache).WindowState = WindowState.Maximized;
            }
            catch { }
        }
    }
}