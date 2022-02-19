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
using System.Data.SqlServerCe;
using AGCSW;
using System.Data;


namespace AGCSWCON
{

    public partial class fCarRentalReservation : Window
    {

        private PRG_DIALOGMODE mp_yDialogMode;
        private fCarRental mp_oParent;
        private clsCR_Task mp_oTask;
        private clsCR_Task mp_oTaskClone;
        private string mp_sTaskKey;
        private bool mp_bBinding = false;

        #region "Constructors"

        public fCarRentalReservation(PRG_DIALOGMODE yDialogMode, fCarRental oParent, string sTaskKey)
        {
            InitializeComponent();
            mp_yDialogMode = yDialogMode;
            mp_oParent = oParent;
            mp_sTaskKey = sTaskKey;
            mp_oTask = mp_oParent.Objects.Tasks.Item(mp_sTaskKey);
        }

        #endregion

        #region "Form Loaded"

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            lblTax.Content = mp_oTask.GetRow().GetBranchStateAbr() + " Tax (" + (mp_oTask.GetStateTax() * 100).ToString("0.00") + "%):";

            picCarType.Source = Globals.g_GetImageSource("\\CarRental\\Small\\" + mp_oTask.GetRow().GetDescription() + ".jpg");
            txtRate.Text = mp_oTask.GetRate().ToString("0.00");
            txtACRISS1.Text = mp_oTask.GetRow().GetACRISSLetter(1) + " - " + mp_oTask.GetRow().GetACRISSDescription(1);
            txtACRISS2.Text = mp_oTask.GetRow().GetACRISSLetter(2) + " - " + mp_oTask.GetRow().GetACRISSDescription(2);
            txtACRISS3.Text = mp_oTask.GetRow().GetACRISSLetter(3) + " - " + mp_oTask.GetRow().GetACRISSDescription(3);
            txtACRISS4.Text = mp_oTask.GetRow().GetACRISSLetter(4) + " - " + mp_oTask.GetRow().GetACRISSDescription(4);

            if (mp_yDialogMode == PRG_DIALOGMODE.DM_ADD)
            {
                if (mp_oTask.lMode == HPE_ADDMODE.AM_RESERVATION)
                {
                    this.Title = "Add Reservation";
                    lblMode.Content = "Add Reservation";
                    lblMode.Background = new SolidColorBrush(Color.FromArgb(255, 153, 170, 194));
                }
                else if (mp_oTask.lMode == HPE_ADDMODE.AM_RENTAL)
                {
                    this.Title = "Add Rental";
                    lblMode.Content = "Add Rental";
                    lblMode.Background = new SolidColorBrush(Color.FromArgb(255, 162, 78, 50));
                }

                //// Automatically Generated Fields
                string sCityName = "";
                string sStateName = "";
                int lID = 0;
                Globals.g_GenerateRandomCity(ref sCityName, ref sStateName, ref lID, mp_oParent.Objects.Connection);
                mp_oTask.sCity = sCityName;
                mp_oTask.sCustomerName = Globals.g_GenerateRandomName(false, mp_oParent.Objects.Connection);
                mp_oTask.sStateAbr = sStateName;
                mp_oTask.sPhone = Globals.g_GenerateRandomPhone("");
                mp_oTask.sMobile = Globals.g_GenerateRandomPhone(mp_oTask.sPhone.Substring(0, 5));
                mp_oTask.sAddress = Globals.g_GenerateRandomAddress(mp_oParent.Objects.Connection);
                mp_oTask.sZIP = Globals.g_GenerateRandomZIP();

                ////Load Options
                mp_oTask.LoadRentalOptions();

            }
            else if (mp_yDialogMode == PRG_DIALOGMODE.DM_EDIT)
            {
                if (mp_oTask.lMode == HPE_ADDMODE.AM_RESERVATION)
                {
                    this.Title = "Edit Reservation";
                    lblMode.Content = "Edit Reservation";
                    lblMode.Background = new SolidColorBrush(Color.FromArgb(255, 153, 170, 194));
                }
                else if (mp_oTask.lMode == HPE_ADDMODE.AM_RENTAL)
                {
                    this.Title = "Edit Rental";
                    lblMode.Content = "Edit Rental";
                    lblMode.Background = new SolidColorBrush(Color.FromArgb(255, 162, 78, 50));
                }
                mp_oTaskClone = new clsCR_Task(mp_oTask.mp_oAGTask, mp_oTask.mp_oControl, mp_oTask.mp_oConn, mp_oTask.mp_oObjects);
                mp_oTask.Clone(mp_oTaskClone);
            }

            chkGPS.Content = chkGPS.Content + " (" + mp_oTask.cGPS.ToString("0.00") + " per day)";
            chkLDW.Content = chkLDW.Content + " (" + mp_oTask.cLDW.ToString("0.00") + " per day)";
            chkPAI.Content = chkPAI.Content + " (" + mp_oTask.cPAI.ToString("0.00") + " per day)";
            chkPEP.Content = chkPEP.Content + " (" + mp_oTask.cPEP.ToString("0.00") + " per day)";
            chkALI.Content = chkALI.Content + " (" + mp_oTask.cALI.ToString("0.00") + " per day)";

            //txtPickup.Text = mp_oTask.mp_oAGTask.StartDate.ToString("dddd',' MMMM d',' yyyy h':'ss tt");
            //txtReturn.Text = mp_oTask.mp_oAGTask.EndDate.ToString("dddd',' MMMM d',' yyyy h':'ss tt");

            mp_bBinding = true;
            txtAddress.Text = mp_oTask.sAddress;
            txtCity.Text = mp_oTask.sCity;
            txtCustomerName.Text = mp_oTask.sCustomerName;
            txtMobile.Text = mp_oTask.sMobile;
            txtPhone.Text = mp_oTask.sPhone;
            txtStateAbr.Text = mp_oTask.sStateAbr;
            txtZIP.Text = mp_oTask.sZIP;
            chkALI.IsChecked = mp_oTask.bALI;
            chkFSO.IsChecked = mp_oTask.bFSO;
            chkGPS.IsChecked = mp_oTask.bGPS;
            chkLDW.IsChecked = mp_oTask.bLDW;
            chkPAI.IsChecked = mp_oTask.bPAI;
            chkPEP.IsChecked = mp_oTask.bPEP;
            mp_bBinding = false;

            mp_UpdateControls();
        }

        #endregion

        #region "Form Closed"

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window1_Unloaded(object sender, RoutedEventArgs e)
        {
            if (this.DialogResult == true)
            {
                mp_oTask.Update();
                mp_oTask.UpdateCaption();
                mp_oParent.ActiveGanttCSWCtl1.Redraw();
            }
            else
            {
                if (mp_yDialogMode == PRG_DIALOGMODE.DM_ADD)
                {
                    mp_oParent.Objects.Tasks.Delete(mp_sTaskKey);
                }
                else if (mp_yDialogMode == PRG_DIALOGMODE.DM_EDIT)
                {
                    mp_oTaskClone.Clone(mp_oTask);
                }
            }
        }

        #endregion


        #region "Rental / Reservation Controls"


        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oTask.sAddress = txtAddress.Text;
        }

        private void txtCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oTask.sCity = txtCity.Text;
        }

        private void txtCustomerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oTask.sCustomerName = txtCustomerName.Text;
        }

        private void txtMobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oTask.sMobile = txtMobile.Text;
        }

        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oTask.sPhone = txtPhone.Text;
        }

        private void txtStateAbr_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oTask.sStateAbr = txtStateAbr.Text;
        }

        private void txtZIP_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oTask.sZIP = txtZIP.Text;
        }

        private void chkALI_Click(object sender, RoutedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oTask.bALI = (bool)chkALI.IsChecked;
            mp_UpdateControls();
        }

        private void chkFSO_Click(object sender, RoutedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oTask.bFSO = (bool)chkFSO.IsChecked;
            mp_UpdateControls();
        }

        private void chkGPS_Click(object sender, RoutedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oTask.bGPS = (bool)chkGPS.IsChecked;
            mp_UpdateControls();
        }

        private void chkLDW_Click(object sender, RoutedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oTask.bLDW = (bool)chkLDW.IsChecked;
            mp_UpdateControls();
        }

        private void chkPAI_Click(object sender, RoutedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oTask.bPAI = (bool)chkPAI.IsChecked;
            mp_UpdateControls();
        }

        private void chkPEP_Click(object sender, RoutedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oTask.bPEP = (bool)chkPEP.IsChecked;
            mp_UpdateControls();
        }

        private void mp_UpdateControls()
        {
            mp_oTask.GetEstimatedTotal();
            txtGPS.Text = mp_oTask.cGPSxFactor.ToString("0.00");
            txtLDW.Text = mp_oTask.cLDWxFactor.ToString("0.00");
            txtPAI.Text = mp_oTask.cPAIxFactor.ToString("0.00");
            txtPEP.Text = mp_oTask.cPEPxFactor.ToString("0.00");
            txtALI.Text = mp_oTask.cALIxFactor.ToString("0.00");
            txtCRF.Text = mp_oTask.cCRFxFactor.ToString("0.00");
            txtRCFC.Text = mp_oTask.cRCFCxFactor.ToString("0.00");
            txtERF.Text = mp_oTask.cERFxFactor.ToString("0.00");
            txtVLF.Text = mp_oTask.cVLFxFactor.ToString("0.00");
            txtWTB.Text = mp_oTask.cWTBxFactor.ToString("0.00");
            txtSurcharge.Text = mp_oTask.cSurcharge.ToString("0.00");
            txtTax.Text = mp_oTask.cTax.ToString("0.00");
            txtEstimatedTotal.Text = mp_oTask.sEstimatedTotal;
        }

        #endregion



    }
}