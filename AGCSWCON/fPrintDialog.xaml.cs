// ----------------------------------------------------------------------------------------
//                              COPYRIGHT NOTICE
// ----------------------------------------------------------------------------------------
//
// The Source Code Store LLC
// ACTIVEGANTT SCHEDULER COMPONENT FOR C# - ActiveGanttCSW
// WPF Control
// Copyright (c) 2002-2017 The Source Code Store LLC
//
// All Rights Reserved. No parts of this file may be reproduced, modified or transmitted 
// in any form or by any means without the written permission of the author.
//
// ----------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;
using System.IO;
using System.IO.Packaging;
using AGCSW;
using System.Printing;

namespace AGCSWCON
{

    public partial class fPrintDialog : Window
    {
        internal ActiveGanttCSWCtl mp_oControl;
        private bool mp_bLoaded = false;

        #region "Constructors"

        public fPrintDialog(ActiveGanttCSWCtl oControl, DateTime dtStartDate, DateTime dtEndDate)
        {
            InitializeComponent();
            mp_oControl = oControl;

            Globals.InitNumCtrl(numSDYear, 0, 3000, dtStartDate.Year);
            Globals.InitNumCtrl(numSDMonth, 1, 12, dtStartDate.Month);
            Globals.InitNumCtrl(numSDDay, 1, 31, dtStartDate.Day);
            Globals.InitNumCtrl(numSDHour, 0, 23, dtStartDate.Hour);
            Globals.InitNumCtrl(numSDMinute, 0, 59, dtStartDate.Minute);
            Globals.InitNumCtrl(numSDSecond, 0, 59, dtStartDate.Second);

            Globals.InitNumCtrl(numEDYear, 0, 3000, dtEndDate.Year);
            Globals.InitNumCtrl(numEDMonth, 1, 12, dtEndDate.Month);
            Globals.InitNumCtrl(numEDDay, 1, 31, dtEndDate.Day);
            Globals.InitNumCtrl(numEDHour, 0, 23, dtEndDate.Hour);
            Globals.InitNumCtrl(numEDMinute, 0, 59, dtEndDate.Minute);
            Globals.InitNumCtrl(numEDSecond, 0, 59, dtEndDate.Second);
        }

        #endregion

        #region "Form Load/Closed"

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int lIndex = 0;

            //// Printer Name
            LocalPrintServer oPrintServer = new LocalPrintServer();
            for (lIndex = 0; lIndex <= oPrintServer.GetPrintQueues().Count() - 1; lIndex++)
            {
                PrintQueue oQueue = oPrintServer.GetPrintQueues().ElementAtOrDefault(lIndex);
                cboPrinters.Items.Add(oQueue.Name);
                if (mp_oControl.Printer.PrinterName == oQueue.Name)
                {
                    cboPrinters.SelectedIndex = lIndex;
                }
            }

            //// Orientation
            for (lIndex = 0; lIndex <= 1; lIndex++)
            {
                GRE_ORIENTATION yOrientation = (GRE_ORIENTATION)lIndex;
                cboOrientation.Items.Add(yOrientation.ToString());
            }
            cboOrientation.SelectedIndex = System.Convert.ToInt32(mp_oControl.Printer.Orientation);

            //// Resolutions
            for (lIndex = 0; lIndex <= 4; lIndex++)
            {
                GRE_PRINTERRESOLUTION yResolution = (GRE_PRINTERRESOLUTION)lIndex;
                cboResolution.Items.Add(yResolution.ToString());
            }
            cboResolution.SelectedIndex = System.Convert.ToInt32(mp_oControl.Printer.PrinterResolution);

            //// Intervals
            for (lIndex = 0; lIndex <= 10; lIndex++)
            {
                E_INTERVAL yInterval = (E_INTERVAL)lIndex;
                cboInterval.Items.Add(yInterval.ToString());
            }
            cboInterval.SelectedIndex = System.Convert.ToInt32(mp_oControl.Printer.Interval);

            Globals.InitNumCtrl(numScale, 10, 200, System.Convert.ToInt32(mp_oControl.Printer.Scale * 100));


            chkKeepRowsTogether.IsChecked = mp_oControl.Printer.KeepRowsTogether;
            chkKeepColumnsTogether.IsChecked = mp_oControl.Printer.KeepColumnsTogether;
            chkKeepTimeIntervalsTogether.IsChecked = mp_oControl.Printer.KeepTimeIntervalsTogether;
            chkHeadingsInEveryPage.IsChecked = mp_oControl.Printer.HeadingsInEveryPage;

            chkColumnsInEveryPage.IsChecked = mp_oControl.Printer.ColumnsInEveryPage;
            Globals.InitNumCtrl(numColumns, 0, mp_oControl.Columns.Count, mp_oControl.Printer.Columns);

            chkShowAllColumns.IsChecked = mp_oControl.Printer.ShowAllColumns;

            Globals.InitNumCtrl(numMarginLeft, 0m, 3m, mp_oControl.Printer.MarginLeft / 100m, 0.1m, 2);
            Globals.InitNumCtrl(numMarginTop, 0m, 3m, mp_oControl.Printer.MarginTop / 100m, 0.1m, 2);
            Globals.InitNumCtrl(numMarginRight, 0m, 3m, mp_oControl.Printer.MarginRight / 100m, 0.1m, 2);
            Globals.InitNumCtrl(numMarginBottom, 0m, 3m, mp_oControl.Printer.MarginBottom / 100m, 0.1m, 2);

            Globals.InitNumCtrl(numStartRow, 1, mp_oControl.Rows.Count, 1);
            Globals.InitNumCtrl(numEndRow, 1, mp_oControl.Rows.Count, mp_oControl.Rows.Count);

            Globals.InitNumCtrl(numFactor, 1, 1000, mp_oControl.Printer.Factor);

            optAll.IsChecked = true;

            txtStartPage.Text = "1";

            if (mp_oControl.Printer.Initialize(StartDateCtrl, EndDateCtrl, System.Convert.ToInt32(numStartRow.Value), System.Convert.ToInt32(numEndRow.Value)) == true)
            {
                mp_GetNumberOfPages();
                mp_bLoaded = true;
            }
            mp_UpdateVisibility();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            mp_oControl.Printer.Terminate();
        }

        #endregion

        #region "Properties"

        private DateTime StartDateCtrl
        {
            get { return new DateTime(System.Convert.ToInt32(numSDYear.Value), System.Convert.ToInt32(numSDMonth.Value), System.Convert.ToInt32(numSDDay.Value), System.Convert.ToInt32(numSDHour.Value), System.Convert.ToInt32(numSDMinute.Value), System.Convert.ToInt32(numSDSecond.Value)); }
            set
            {
                numSDYear.Value = value.Year;
                numSDMonth.Value = value.Month;
                numSDDay.Value = value.Day;
                numSDHour.Value = value.Hour;
                numSDMinute.Value = value.Minute;
                numSDSecond.Value = value.Second;
            }
        }

        private DateTime EndDateCtrl
        {
            get { return new DateTime(System.Convert.ToInt32(numEDYear.Value), System.Convert.ToInt32(numEDMonth.Value), System.Convert.ToInt32(numEDDay.Value), System.Convert.ToInt32(numEDHour.Value), System.Convert.ToInt32(numEDMinute.Value), System.Convert.ToInt32(numEDSecond.Value)); }
            set
            {
                numEDYear.Value = value.Year;
                numEDMonth.Value = value.Month;
                numEDDay.Value = value.Day;
                numEDHour.Value = value.Hour;
                numEDMinute.Value = value.Minute;
                numEDSecond.Value = value.Second;
            }
        }


        #endregion

        #region "Functions"

        private void mp_GetNumberOfPages()
        {
            mp_oControl.Printer.Calculate();
            txtEndPage.Text = mp_oControl.Printer.Pages.ToString();
            lblNumberOfPages.Content = "Total Pages: " + mp_oControl.Printer.Pages;
        }

        #endregion

        #region "Control Updating"

        private void mp_UpdateVisibility()
        {
            if (chkKeepTimeIntervalsTogether.IsChecked == false)
            {
                lblInterval.Visibility = System.Windows.Visibility.Hidden;
                cboInterval.Visibility = System.Windows.Visibility.Hidden;
                lblFactor.Visibility = System.Windows.Visibility.Hidden;
                numFactor.Visibility = System.Windows.Visibility.Hidden;
            }
            if (chkKeepColumnsTogether.IsChecked == false)
            {
                chkKeepTimeIntervalsTogether.Visibility = System.Windows.Visibility.Hidden;
                lblInterval.Visibility = System.Windows.Visibility.Hidden;
                cboInterval.Visibility = System.Windows.Visibility.Hidden;
                lblFactor.Visibility = System.Windows.Visibility.Hidden;
                numFactor.Visibility = System.Windows.Visibility.Hidden;
            }
            if (chkKeepTimeIntervalsTogether.IsChecked == true & chkKeepColumnsTogether.IsChecked == true)
            {
                chkKeepTimeIntervalsTogether.Visibility = System.Windows.Visibility.Visible;
                lblInterval.Visibility = System.Windows.Visibility.Visible;
                cboInterval.Visibility = System.Windows.Visibility.Visible;
                lblFactor.Visibility = System.Windows.Visibility.Visible;
                numFactor.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void cboPrinters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mp_oControl.Printer.PrinterName != (System.String)cboPrinters.Items[cboPrinters.SelectedIndex])
            {
                mp_oControl.Printer.PrinterName = (System.String)cboPrinters.Items[cboPrinters.SelectedIndex];
                if (mp_oControl.Printer.Initialize(StartDateCtrl, EndDateCtrl, System.Convert.ToInt32(numStartRow.Value), System.Convert.ToInt32(numEndRow.Value)) == true)
                {
                    cboOrientation.SelectedIndex = System.Convert.ToInt32(mp_oControl.Printer.Orientation);
                }
            }
        }

        private void cboOrientation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mp_oControl.Printer.Orientation != (GRE_ORIENTATION)cboOrientation.SelectedIndex)
            {
                mp_oControl.Printer.Orientation = (GRE_ORIENTATION)cboOrientation.SelectedIndex;
                mp_GetNumberOfPages();
            }
        }

        private void cboResolution_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((GRE_PRINTERRESOLUTION)cboResolution.SelectedIndex == GRE_PRINTERRESOLUTION.PR_CUSTOM)
            {
                lblDPIX.Visibility = System.Windows.Visibility.Visible;
                lblDPIY.Visibility = System.Windows.Visibility.Visible;
                numDPIX.Visibility = System.Windows.Visibility.Visible;
                numDPIY.Visibility = System.Windows.Visibility.Visible;
                numDPIX.Value = mp_oControl.Printer.HorizontalDPI;
                numDPIY.Value = mp_oControl.Printer.VerticalDPI;
            }
            else
            {
                lblDPIX.Visibility = System.Windows.Visibility.Hidden;
                lblDPIY.Visibility = System.Windows.Visibility.Hidden;
                numDPIX.Visibility = System.Windows.Visibility.Hidden;
                numDPIY.Visibility = System.Windows.Visibility.Hidden;
            }
            if (mp_oControl.Printer.PrinterResolution != (GRE_PRINTERRESOLUTION)cboResolution.SelectedIndex)
            {
                mp_oControl.Printer.PrinterResolution = (GRE_PRINTERRESOLUTION)cboResolution.SelectedIndex;
            }
        }

        private void cboInterval_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mp_oControl.Printer.Interval != (E_INTERVAL)cboInterval.SelectedIndex)
            {
                mp_oControl.Printer.Interval = (E_INTERVAL)cboInterval.SelectedIndex;
                mp_GetNumberOfPages();
            }
        }

        private void numFactor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (mp_oControl.Printer.Factor != System.Convert.ToInt32(numFactor.Value))
            {
                mp_oControl.Printer.Factor = System.Convert.ToInt32(numFactor.Value);
                mp_GetNumberOfPages();
            }
        }

        private void numDPIX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (mp_oControl.Printer.HorizontalDPI != System.Convert.ToInt32(numDPIX.Value))
            {
                mp_oControl.Printer.HorizontalDPI = System.Convert.ToInt32(numDPIX.Value);
            }
        }

        private void numDPIY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (mp_oControl.Printer.VerticalDPI != System.Convert.ToInt32(numDPIY.Value))
            {
                mp_oControl.Printer.VerticalDPI = System.Convert.ToInt32(numDPIY.Value);
            }
        }

        private void numScale_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (mp_oControl.Printer.Scale != (numScale.Value / 100))
            {
                mp_oControl.Printer.Scale = (float)numScale.Value / 100f;
                mp_GetNumberOfPages();
            }
        }

        private void chkKeepRowsTogether_Click(object sender, RoutedEventArgs e)
        {
            if (mp_oControl.Printer.KeepRowsTogether != chkKeepRowsTogether.IsChecked)
            {
                mp_oControl.Printer.KeepRowsTogether = (bool)chkKeepRowsTogether.IsChecked;
                mp_GetNumberOfPages();
            }
        }

        private void chkKeepColumnsTogether_Click(object sender, RoutedEventArgs e)
        {
            if (mp_oControl.Printer.KeepColumnsTogether != chkKeepColumnsTogether.IsChecked)
            {
                mp_oControl.Printer.KeepColumnsTogether = (bool)chkKeepColumnsTogether.IsChecked;
                mp_GetNumberOfPages();
            }
            mp_UpdateVisibility();
        }

        private void chkKeepTimeIntervalsTogether_Click(object sender, RoutedEventArgs e)
        {
            if (mp_oControl.Printer.KeepTimeIntervalsTogether != chkKeepTimeIntervalsTogether.IsChecked)
            {
                mp_oControl.Printer.KeepTimeIntervalsTogether = (bool)chkKeepTimeIntervalsTogether.IsChecked;
                mp_GetNumberOfPages();
            }
            mp_UpdateVisibility();
        }

        private void chkHeadingsInEveryPage_Click(object sender, RoutedEventArgs e)
        {
            if (mp_oControl.Printer.HeadingsInEveryPage != chkHeadingsInEveryPage.IsChecked)
            {
                mp_oControl.Printer.HeadingsInEveryPage = (bool)chkHeadingsInEveryPage.IsChecked;
                mp_GetNumberOfPages();
            }
        }

        private void chkColumnsInEveryPage_Click(object sender, RoutedEventArgs e)
        {
            if (mp_oControl.Printer.ColumnsInEveryPage != chkColumnsInEveryPage.IsChecked)
            {
                mp_oControl.Printer.ColumnsInEveryPage = (bool)chkColumnsInEveryPage.IsChecked;
                mp_GetNumberOfPages();
            }
        }

        private void numColumns_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (mp_oControl.Printer.Columns != numColumns.Value)
            {
                mp_oControl.Printer.Columns = System.Convert.ToInt32(numColumns.Value);
                mp_GetNumberOfPages();
            }
        }

        private void chkShowAllColumns_Click(object sender, RoutedEventArgs e)
        {
            if (mp_oControl.Printer.ShowAllColumns != chkShowAllColumns.IsChecked)
            {
                mp_oControl.Printer.ShowAllColumns = (bool)chkShowAllColumns.IsChecked;
                mp_GetNumberOfPages();
            }
        }

        private void txtStartPage_GotFocus(object sender, RoutedEventArgs e)
        {
            optFrom.IsChecked = true;
        }

        private void txtEndPage_GotFocus(object sender, RoutedEventArgs e)
        {
            optFrom.IsChecked = true;
        }

        private void numMarginLeft_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (mp_oControl.Printer.MarginLeft != System.Convert.ToInt32(numMarginLeft.Value * 100))
            {
                mp_oControl.Printer.MarginLeft = System.Convert.ToInt32(numMarginLeft.Value * 100);
            }
        }

        private void numMarginTop_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (mp_oControl.Printer.MarginTop != System.Convert.ToInt32(numMarginTop.Value * 100))
            {
                mp_oControl.Printer.MarginTop = System.Convert.ToInt32(numMarginTop.Value * 100);
            }
        }

        private void numMarginRight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (mp_oControl.Printer.MarginRight != System.Convert.ToInt32(numMarginRight.Value * 100))
            {
                mp_oControl.Printer.MarginRight = System.Convert.ToInt32(numMarginRight.Value * 100);
            }
        }

        private void numMarginBottom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (mp_oControl.Printer.MarginBottom != System.Convert.ToInt32(numMarginBottom.Value * 100))
            {
                mp_oControl.Printer.MarginBottom = System.Convert.ToInt32(numMarginBottom.Value * 100);
            }
        }

        private void numStartRow_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (mp_bLoaded == false)
                return;
            if (mp_oControl.Printer.Initialize(StartDateCtrl, EndDateCtrl, System.Convert.ToInt32(numStartRow.Value), System.Convert.ToInt32(numEndRow.Value)) == true)
            {
                mp_GetNumberOfPages();
            }
        }

        private void numEndRow_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (mp_bLoaded == false)
                return;
            if (mp_oControl.Printer.Initialize(StartDateCtrl, EndDateCtrl, System.Convert.ToInt32(numStartRow.Value), System.Convert.ToInt32(numEndRow.Value)) == true)
            {
                mp_GetNumberOfPages();
            }
        }

        #endregion

        #region "Buttons"

        private void cmdPreview_Click(object sender, RoutedEventArgs e)
        {
            if (mp_oControl.Printer.Initialize(StartDateCtrl, EndDateCtrl, System.Convert.ToInt32(numStartRow.Value), System.Convert.ToInt32(numEndRow.Value)) == true)
            {
                fPrintPreview oForm = new fPrintPreview();
                oForm.mp_oParent = this;
                oForm.ShowDialog();
            }
        }

        private void cmdXPSPreview_Click(object sender, RoutedEventArgs e)
        {
            if (mp_oControl.Printer.Initialize(StartDateCtrl, EndDateCtrl, System.Convert.ToInt32(numStartRow.Value), System.Convert.ToInt32(numEndRow.Value)) == true)
            {
                fPrintPreviewXPS oForm = new fPrintPreviewXPS();
                Mouse.OverrideCursor = Cursors.Wait;
                if (optAll.IsChecked == true)
                {
                    oForm.oXPSDoc = mp_oControl.Printer.GetXPSDocument(1, mp_oControl.Printer.Pages);
                }
                else if (optFrom.IsChecked == false)
                {
                    oForm.oXPSDoc = mp_oControl.Printer.GetXPSDocument(System.Convert.ToInt32(txtStartPage.Text), System.Convert.ToInt32(txtEndPage.Text));
                }
                Mouse.OverrideCursor = Cursors.Arrow;
                if ((oForm.oXPSDoc != null))
                {
                    //oForm.oURI = oURI
                    oForm.ShowDialog();
                }
            }
        }

        private void cmdSaveXPS_Click(object sender, RoutedEventArgs e)
        {
            if (mp_oControl.Printer.Initialize(StartDateCtrl, EndDateCtrl, System.Convert.ToInt32(numStartRow.Value), System.Convert.ToInt32(numEndRow.Value)) == true)
            {
                Microsoft.Win32.SaveFileDialog oForm = new Microsoft.Win32.SaveFileDialog();
                oForm.FileName = "ActiveGanttCSW";
                oForm.DefaultExt = ".xps";
                oForm.Filter = "XPS documents (.xps)|*.xps";
                if (oForm.ShowDialog() == true)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    if (optAll.IsChecked == true)
                    {
                        mp_oControl.Printer.SaveXPSToFile(1, mp_oControl.Printer.Pages, oForm.FileName);
                    }
                    else if (optFrom.IsChecked == true)
                    {
                        mp_oControl.Printer.SaveXPSToFile(System.Convert.ToInt32(txtStartPage.Text), System.Convert.ToInt32(txtEndPage.Text), oForm.FileName);
                    }
                    Mouse.OverrideCursor = Cursors.Arrow;
                }
            }
            this.Close();
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            if (mp_oControl.Printer.Initialize(StartDateCtrl, EndDateCtrl, System.Convert.ToInt32(numStartRow.Value), System.Convert.ToInt32(numEndRow.Value)) == true)
            {
                if (optAll.IsChecked == true)
                {
                    mp_oControl.Printer.PrintAll();
                }
                else if (optFrom.IsChecked == true)
                {
                    mp_oControl.Printer.PrintRange(System.Convert.ToInt32(txtStartPage.Text), System.Convert.ToInt32(txtEndPage.Text));
                }
            }
            this.Close();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion


    }
}