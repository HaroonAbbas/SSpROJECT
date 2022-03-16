using DevExpress.Xpf.Core;
using DevExpress.Xpf.LayoutControl;
using SupplySystem.BL;
using SupplySystem.Models;
using SupplySystem.PL;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SupplySystem
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeInterface homeInterface { get; set; }
        public List<int> istabNew = new List<int>();
        CS_Units cS_Units = new CS_Units();
        CS_Users cS_Users = new CS_Users();
        public HomeWindow()
        {
            InitializeComponent();
            btnMenu.IsChecked = true;
            WindowState = WindowState.Maximized;
            stkBtns.Visibility = Visibility.Collapsed;
            tabControl.TabRemoved += TabControl_TabRemoved;
            tabControl.SelectionChanged += TabControl_SelectionChanged;
            this.Closing += HomeWindow_Closing;
            this.Loaded += HomeWindow_Loaded;
        }

        private void HomeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cS_Units.GetUnits().Rows.Count > 0)
                {
                    var dt = cS_Units.GetUnits().Rows[0];
                    UnitsModel t;
                    txt_UnitIdName.Text = dt[nameof(t.UnitIdName)].ToString();
                    txt_UnitName.Text = dt[nameof(t.UnitName)].ToString();
                    lbl_OrizonorUnitName.Content = dt[nameof(t.UnitName)].ToString();
                }
                if (cS_Users.GetUserById(Properties.Settings.Default.U_ID).Rows.Count > 0)
                {
                    var dt = cS_Users.GetUserById(Properties.Settings.Default.U_ID).Rows[0];
                    UsersModel t;
                    lbl_UserName.Content = dt[nameof(t.U_NAME)].ToString();
                    lbl_UserEmail.Content = dt[nameof(t.EMAIL)].ToString();
                }
            }
            catch { }
        }

        private void HomeWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();

                System.Windows.Application app = new System.Windows.Application()
                {
                    ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown
                };
                app.Shutdown();
            }
            catch { }
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();

                System.Windows.Application app = new System.Windows.Application()
                {
                    ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown
                };
                app.Shutdown();
            }
            catch { }
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WindowState == WindowState.Normal)
                    WindowState = WindowState.Maximized;
                else
                    WindowState = WindowState.Normal;
            }
            catch
            {

            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            try { WindowState = WindowState.Minimized; } catch { }
        }


        private void btnBackUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BackUpDB back = new BackUpDB();
                back.ShowDialog();
            }
            catch { }
        }
        /// <summary>
        /// سندات التموين
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupplyBonds_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               AddUserControl(new SupplyBonds());
            }
            catch
            {

            }
        }
        /// <summary>
        /// قطع الغيار
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpareParts_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               AddUserControl(new SpareParts());
            }
            catch
            {

            }
        }
        /// <summary>
        /// الجهات المقدمة للخدمة -يرسل الى
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServiceProviders_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddUserControl(new Sides(1));
            }
            catch
            {

            }
        }
        /// <summary>
        ///الجهات المستفيدة - ملاحظات
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBeneficiaries_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddUserControl(new Sides(2));
            }
            catch
            {

            }
        }
        private void TabControl_SelectionChanged(object sender, TabControlSelectionChangedEventArgs e)
        {
            try
            {
                if (tabControl.Items.Count > 0 )
                {
                    var stabItem = tabControl.SelectedItem as DXTabItem;
                    homeInterface = stabItem.Content as HomeInterface;
                    HasPrint();
                    if (istabNew.Contains(stabItem.TabIndex))
                    {
                        AfterAnyNewOrUpdate();
                    }
                    else if (!istabNew.Contains(stabItem.TabIndex))
                    {
                        BeforAnyNewOrUpdate();
                    }
                }
            }
            catch { }
        }

        private void TabControl_TabRemoved(object sender, TabControlTabRemovedEventArgs e)
        {
            try
            {
                int index = tabControl.Items.Count;
                if (index == 0)
                {
                    stkBtns.Visibility = Visibility.Collapsed;
                }

                var stabItem = tabControl.SelectedItem as DXTabItem;
                if (stabItem != null)
                {
                    istabNew.Remove(stabItem.TabIndex);
                }
            }
            catch { }
        }

        public void BeforAnyNewOrUpdate()
        {
            BtnNew.IsEnabled = true;
            BtnUpdate.IsEnabled = true;
            BtnDelete.IsEnabled = true;
            BtnSearch.IsEnabled = true;
            BtnPrint.IsEnabled = true;

            BtnSave.IsEnabled = false;
            BtnUndo.IsEnabled = false;
        }
        public void AfterAnyNewOrUpdate()
        {
            BtnNew.IsEnabled = false;
            BtnUpdate.IsEnabled = false;
            BtnDelete.IsEnabled = false;
            BtnSearch.IsEnabled = false;
            BtnPrint.IsEnabled = false;

            BtnSave.IsEnabled = true;
            BtnUndo.IsEnabled = true;
        }
        private void HasPrint()
        {
            if (homeInterface.HasPrint==true)
            {
                BtnPrint.Visibility = Visibility.Visible;
            }
            else if(homeInterface.HasPrint ==false)
                BtnPrint.Visibility = Visibility.Collapsed;
        }
        public void AddUserControl(UserControl userControl)
        {
            try
            {
                homeInterface = userControl as HomeInterface;
                if (homeInterface != null)
                {
                    tabControl.Items.Add(new DXTabItem
                    {
                        Header = homeInterface.FORM_NAME,
                        Content = homeInterface,
                        IsSelected = true,
                    });

                    if (stkBtns.Visibility == Visibility.Collapsed)
                    {
                        stkBtns.Visibility = Visibility.Visible;
                    }
                    BeforAnyNewOrUpdate();
                    HasPrint();
                }
            }
            catch
            {

            }
        }
        private void tabControl_TabAdding(object sender, TabControlTabAddingEventArgs e)
        {
            //try
            //{
            //    e.Cancel = true;
            //    var dXTabItem = tabControl.SelectedItem as DXTabItem;
            //    if (dXTabItem != null)
            //    {
            //        if (dXTabItem.Content is SupplyBonds)
            //        {
            //            tabControl.Items.Add(new DXTabItem
            //            {
            //                Header = "سندات التموين",
            //                Content = new SupplyBonds(),
            //                IsSelected = true,
            //            });
            //        }
            //        if (dXTabItem.Content is SpareParts)
            //        {
            //            tabControl.Items.Add(new DXTabItem
            //            {
            //                Header = "قطع الغيار",
            //                Content = new SpareParts(),
            //                IsSelected = true,
            //            });
            //        }
            //    }
            //    if (stkBtns.Visibility == Visibility.Collapsed)
            //    {
            //        stkBtns.Visibility = Visibility.Visible;
            //    }
            //}
            //catch
            //{
            //}
        }


        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AfterAnyNewOrUpdate();
                homeInterface.BtnNew();

                var stabItem = tabControl.SelectedItem as DXTabItem;
                if (stabItem != null)
                {
                    istabNew.Add(stabItem.TabIndex);
                }
            }
            catch
            {

            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AfterAnyNewOrUpdate();
                homeInterface.BtnUpdate();
                var stabItem = tabControl.SelectedItem as DXTabItem;
                if (stabItem != null)
                {
                    istabNew.Add(stabItem.TabIndex);
                }
            }
            catch
            {

            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBoxShowing.Show(homeInterface.FORM_NAME,
                    "هل تريد الحذف", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                    homeInterface.BtnDelete();
                }
            }
            catch
            {

            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                homeInterface.BtnRefresh();
            }
            catch
            {

            }
        }

        private void BtnUndo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BeforAnyNewOrUpdate();
                homeInterface.BtnUndo();

                var stabItem = tabControl.SelectedItem as DXTabItem;
                if (stabItem != null)
                {
                    istabNew.Remove(stabItem.TabIndex);
                }
            }
            catch
            {

            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string message = homeInterface.UserValid();
                if (message == string.Empty)
                {
                    homeInterface.BtnSave();
                    MessageBoxShowing.Show(homeInterface.FORM_NAME, "تمت العملية بنجاح", MessageBoxButton.OK);
                    BeforAnyNewOrUpdate(); 
                    
                    var stabItem = tabControl.SelectedItem as DXTabItem;
                    if (stabItem != null)
                    {
                        istabNew.Remove(stabItem.TabIndex);
                    }

                }
                else
                {
                    MessageBoxShowing.Show(homeInterface.FORM_NAME, message, MessageBoxButton.OKCancel);
                }
            }
            catch (Exception ex)
            {
                MessageBoxShowing.Show(homeInterface.FORM_NAME, ex.Message, MessageBoxButton.OK);
            }
        }

        private void BtnNewFrom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AfterAnyNewOrUpdate();
                homeInterface.BtnNewFrom();

                var stabItem = tabControl.SelectedItem as DXTabItem;
                if (stabItem != null)
                {
                    istabNew.Add(stabItem.TabIndex);
                }
            }
            catch
            {

            }
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                homeInterface.BtnPrint();
            }
            catch { }
        }
    }
}