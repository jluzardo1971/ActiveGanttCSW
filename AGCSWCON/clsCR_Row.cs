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
using AGCSW;
using System.Data.SqlServerCe;
using System.Windows.Controls;

namespace AGCSWCON
{
    public class clsCR_Row
    {

        internal ActiveGanttCSWCtl mp_oControl;
        internal SqlCeConnection mp_oConn;
        internal clsRow mp_oAGRow;

        internal clsCR_Objects mp_oObjects;

        private int mp_lDepth;
        private int mp_lCarTypeID;
        public int lOrder { get; set; }

        public string sLicensePlates { get; set; }

        public string sNotes { get; set; }
        public decimal cRate { get; set; }
        public string sACRISSCode { get; set; }

        public string sCity { get; set; }
        public string sBranchName { get; set; }
        public string sStateAbr { get; set; }
        public string sPhone { get; set; }
        public string sManagerName { get; set; }
        public string sManagerMobile { get; set; }
        public string sAddress { get; set; }
        public string sZIP { get; set; }

        public clsCR_Row(clsRow oAGRow, ActiveGanttCSWCtl oControl, SqlCeConnection oConn, clsCR_Objects oObjects)
        {
            mp_oControl = oControl;
            mp_oAGRow = oAGRow;
            mp_oConn = oConn;
            mp_oObjects = oObjects;
        }

        public int lRowID
        {
            get { return System.Convert.ToInt32(mp_oAGRow.Key.Replace("K", "")); }
        }

        public int lDepth
        {
            get { return mp_lDepth; }
            set
            {
                mp_lDepth = value;
                if (mp_lDepth == 0)
                {
                    mp_oAGRow.MergeCells = true;
                    mp_oAGRow.Container = false;
                    mp_oAGRow.StyleIndex = "Branch";
                    mp_oAGRow.ClientAreaStyleIndex = "BranchCA";
                    mp_oAGRow.Node.Depth = 0;
                    mp_oAGRow.UseNodeImages = true;
                    mp_oAGRow.Node.ExpandedImage = Globals.g_GetImage("\\CarRental\\minus.jpg");
                    mp_oAGRow.Node.Image = Globals.g_GetImage("\\CarRental\\plus.jpg");
                    mp_oAGRow.AllowMove = false;
                    mp_oAGRow.AllowSize = false;
                }
                else if (mp_lDepth == 1)
                {
                    mp_oAGRow.Node.Depth = 1;
                }
            }
        }

        public int lCarTypeID
        {
            get { return mp_lCarTypeID; }
            set
            {
                mp_lCarTypeID = value;
                SqlCeCommand oCmd = new SqlCeCommand("SELECT sACRISSCode, cStdRate FROM tb_CR_Car_Types WHERE lCarTypeID = " + mp_lCarTypeID.ToString(), mp_oConn);
                SqlCeDataReader oReader = oCmd.ExecuteReader();
                if (oReader.Read() == true)
                {
                    sACRISSCode = System.Convert.ToString(oReader["sACRISSCode"]);
                    cRate = System.Convert.ToDecimal(oReader["cStdRate"]);
                }
                oReader.Close();
            }
        }

        public string sRate
        {
            get { return cRate.ToString("0.00"); }
        }

        public string GetDescription()
        {
            string sReturn = "";
            SqlCeCommand oCmd = new SqlCeCommand("SELECT sDescription FROM tb_CR_Car_Types WHERE lCarTypeID = " + lCarTypeID, mp_oConn);
            SqlCeDataReader oReader = oCmd.ExecuteReader();
            if (oReader.Read() == true)
            {
                sReturn = System.Convert.ToString(oReader["sDescription"]);
            }
            oReader.Close();
            return sReturn;
        }

        public string GetACRISSLetter(int lPosition)
        {
            lPosition = lPosition - 1;
            return sACRISSCode.Substring(lPosition, 1);
        }

        public string GetACRISSDescription(int lPosition)
        {
            string sReturn = "";
            SqlCeCommand oCmd = new SqlCeCommand("SELECT sDescription FROM tb_CR_ACRISS_Codes WHERE lPosition = " + lPosition.ToString() + " AND sLetter='" + GetACRISSLetter(lPosition) + "'", mp_oConn);
            SqlCeDataReader oReader = oCmd.ExecuteReader();
            if (oReader.Read() == true)
            {
                sReturn = System.Convert.ToString(oReader["sDescription"]);
            }
            oReader.Close();
            return sReturn;
        }

        public void UpdateCaption()
        {
            if (lDepth == 0)
            {
                mp_oAGRow.Text = sBranchName + ", " + sStateAbr + Environment.NewLine + "Phone: " + sPhone;
            }
            else if (lDepth == 1)
            {
                mp_oAGRow.Cells.Item("1").Text = sLicensePlates;
                mp_oAGRow.Cells.Item("2").Image = Globals.g_GetImage("\\CarRental\\Small\\" + GetDescription() + ".jpg");
                mp_oAGRow.Cells.Item("3").Text = GetDescription() + Environment.NewLine + sACRISSCode + " - " + sRate + " USD";
            }
        }

        public string GetBranchStateAbr()
        {
            clsNode oParent = null;
            oParent = mp_oAGRow.Node.Parent();
            if (oParent == null)
            {
                return "NO STATE";
            }
            else
            {
                return mp_oObjects.Rows.Item(oParent.Row.Key).sStateAbr;
            }
        }

        private void mp_AddParameters(clsCmdBuilder oCmdBuilder)
        {
            oCmdBuilder.AddParameter("lDepth", lDepth);
            oCmdBuilder.AddParameter("lOrder", lOrder);

            oCmdBuilder.AddParameter("sLicensePlates", sLicensePlates);
            oCmdBuilder.AddParameter("lCarTypeID", lCarTypeID);
            oCmdBuilder.AddParameter("sNotes", sNotes);
            oCmdBuilder.AddParameter("cRate", cRate);
            oCmdBuilder.AddParameter("sACRISSCode", sACRISSCode);

            oCmdBuilder.AddParameter("sCity", sCity);
            oCmdBuilder.AddParameter("sBranchName", sBranchName);
            oCmdBuilder.AddParameter("sStateAbr", sStateAbr);
            oCmdBuilder.AddParameter("sPhone", sPhone);
            oCmdBuilder.AddParameter("sManagerName", sManagerName);
            oCmdBuilder.AddParameter("sManagerMobile", sManagerMobile);
            oCmdBuilder.AddParameter("sAddress", sAddress);
            oCmdBuilder.AddParameter("sZIP", sZIP);
        }

        public void Update()
        {
            clsCmdBuilder oCmdBuilder = new clsCmdBuilder();
            mp_AddParameters(oCmdBuilder);
            string sSQL = oCmdBuilder.Update("tb_CR_Rows", "lRowID = " + lRowID.ToString());
            SqlCeCommand oCmd = new SqlCeCommand(sSQL, mp_oConn);
            oCmd.ExecuteNonQuery();
        }

        public int Insert()
        {
            int lReturn = 0;
            clsCmdBuilder oCmdBuilder = new clsCmdBuilder();
            mp_AddParameters(oCmdBuilder);
            string sSQL = oCmdBuilder.Insert("tb_CR_Rows");
            SqlCeCommand oCmd = new SqlCeCommand(sSQL, mp_oConn);
            oCmd.ExecuteNonQuery();
            oCmd = new SqlCeCommand("SELECT @@IDENTITY AS NewID", mp_oConn);
            SqlCeDataReader oReader = oCmd.ExecuteReader();
            if (oReader.Read() == true)
            {
                lReturn = System.Convert.ToInt32(oReader["NewID"]);
            }
            oReader.Close();
            return lReturn;
        }


        public void Clone(clsCR_Row oClone)
        {
            oClone.sLicensePlates = sLicensePlates;
            oClone.lCarTypeID = lCarTypeID;
            oClone.sNotes = sNotes;
            oClone.cRate = cRate;
            oClone.sACRISSCode = sACRISSCode;

            oClone.sCity = sCity;
            oClone.sBranchName = sBranchName;
            oClone.sStateAbr = sStateAbr;
            oClone.sPhone = sPhone;
            oClone.sManagerName = sManagerName;
            oClone.sManagerMobile = sManagerMobile;
            oClone.sAddress = sAddress;
            oClone.sZIP = sZIP;

        }

        #region "Vehicle Controls"

        public void FillVehicleComboBoxes(ComboBox drpCarTypeID, ComboBox drpACRISS1, ComboBox drpACRISS2, ComboBox drpACRISS3, ComboBox drpACRISS4)
        {
            modData.g_FillComboBox(drpCarTypeID, "SELECT * FROM tb_CR_Car_Types", "lCarTypeID", "sDescription", mp_oConn);
            modData.g_FillComboBox(drpACRISS1, "SELECT * FROM tb_CR_ACRISS_Codes WHERE [lPosition] = 1", "sLetter", "sDescription", mp_oConn);
            modData.g_FillComboBox(drpACRISS2, "SELECT * FROM tb_CR_ACRISS_Codes WHERE [lPosition] = 2", "sLetter", "sDescription", mp_oConn);
            modData.g_FillComboBox(drpACRISS3, "SELECT * FROM tb_CR_ACRISS_Codes WHERE [lPosition] = 3", "sLetter", "sDescription", mp_oConn);
            modData.g_FillComboBox(drpACRISS4, "SELECT * FROM tb_CR_ACRISS_Codes WHERE [lPosition] = 4", "sLetter", "sDescription", mp_oConn);
        }

        #endregion

    }
}