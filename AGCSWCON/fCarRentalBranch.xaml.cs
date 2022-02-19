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
using AGCSW;
using System.Data;

namespace AGCSWCON
{

    public partial class fCarRentalBranch : Window
    {

        private PRG_DIALOGMODE mp_yDialogMode;
        private fCarRental mp_oParent;
        private clsCR_Row mp_oRow;
        private clsCR_Row mp_oRowClone;
        private string mp_sRowKey;
        private bool mp_bBinding = false;

        #region "Constructors"

        public fCarRentalBranch(PRG_DIALOGMODE yDialogMode, fCarRental oParent, string sRowKey)
        {
            InitializeComponent();
            mp_yDialogMode = yDialogMode;
            mp_oParent = oParent;
            if (mp_yDialogMode == PRG_DIALOGMODE.DM_ADD)
            {
                mp_sRowKey = oParent.Objects.Rows.Add(0);
            }
            else if (mp_yDialogMode == PRG_DIALOGMODE.DM_EDIT)
            {
                mp_sRowKey = sRowKey;
            }
            mp_oRow = mp_oParent.Objects.Rows.Item(mp_sRowKey);
        }

        #endregion

        #region "Form Loaded"

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            if (mp_yDialogMode == PRG_DIALOGMODE.DM_ADD)
            {
                this.Title = "Add New Branch";

                //// Automatically Generated Fields
                string sCityName = "";
                string sStateName = "";
                int lID = 0;
                Globals.g_GenerateRandomCity(ref sCityName, ref sStateName, ref lID, mp_oParent.Objects.Connection);
                mp_oRow.sCity = sCityName;
                mp_oRow.sBranchName = sCityName;
                mp_oRow.sStateAbr = sStateName;
                mp_oRow.sPhone = Globals.g_GenerateRandomPhone("");
                mp_oRow.sManagerName = Globals.g_GenerateRandomName(false, mp_oParent.Objects.Connection);
                mp_oRow.sManagerMobile = Globals.g_GenerateRandomPhone(mp_oRow.sPhone.Substring(0, 5));
                mp_oRow.sAddress = Globals.g_GenerateRandomAddress(mp_oParent.Objects.Connection);
                mp_oRow.sZIP = Globals.g_GenerateRandomZIP();
            }
            else
            {
                this.Title = "Edit Branch";
                mp_oRowClone = new clsCR_Row(mp_oRow.mp_oAGRow, mp_oRow.mp_oControl, mp_oRow.mp_oConn, mp_oRow.mp_oObjects);
                mp_oRow.Clone(mp_oRowClone);
            }

            mp_bBinding = true;
            txtCity.Text = mp_oRow.sCity;
            txtBranchName.Text = mp_oRow.sBranchName;
            txtStateAbr.Text = mp_oRow.sStateAbr;
            txtPhone.Text = mp_oRow.sPhone;
            txtManagerName.Text = mp_oRow.sManagerName;
            txtManagerMobile.Text = mp_oRow.sManagerMobile;
            txtAddress.Text = mp_oRow.sAddress;
            txtZIP.Text = mp_oRow.sZIP;
            mp_bBinding = false;
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
                mp_oRow.Update();
                mp_oRow.UpdateCaption();
                if (mp_yDialogMode == PRG_DIALOGMODE.DM_ADD)
                {
                    int l = 0;
                    l = System.Convert.ToInt32(System.Math.Floor(System.Convert.ToDecimal(mp_oParent.ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Height) / 41M));
                    if (((mp_oParent.ActiveGanttCSWCtl1.Rows.Count - l + 2) > 0))
                    {
                        mp_oParent.ActiveGanttCSWCtl1.VerticalScrollBar.Value = (mp_oParent.ActiveGanttCSWCtl1.Rows.Count - l + 2);
                    }
                }
                mp_oParent.ActiveGanttCSWCtl1.Redraw();
            }
            else
            {
                if (mp_yDialogMode == PRG_DIALOGMODE.DM_ADD)
                {
                    mp_oParent.Objects.Rows.Delete(mp_sRowKey);
                }
                else if (mp_yDialogMode == PRG_DIALOGMODE.DM_EDIT)
                {
                    mp_oRowClone.Clone(mp_oRow);
                }
            }
        }

        #endregion

        #region "Branch Controls"

        private void txtCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oRow.sCity = txtCity.Text;
        }

        private void txtBranchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oRow.sBranchName = txtBranchName.Text;
        }

        private void txtStateAbr_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oRow.sStateAbr = txtStateAbr.Text;
        }

        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oRow.sPhone = txtPhone.Text;
        }

        private void txtManagerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oRow.sManagerName = txtManagerName.Text;
        }

        private void txtManagerMobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oRow.sManagerMobile = txtManagerMobile.Text;
        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oRow.sAddress = txtAddress.Text;
        }

        private void txtZIP_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mp_bBinding == true)
            {
                return;
            }
            mp_oRow.sZIP = txtZIP.Text;
        }

        #endregion



    }
}