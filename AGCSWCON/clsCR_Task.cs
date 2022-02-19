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
using System.Data.SqlServerCe;
using AGCSW;

namespace AGCSWCON
{



    public enum HPE_ADDMODE
    {
        AM_RESERVATION = 0,
        AM_RENTAL = 1,
        AM_MAINTENANCE = 2
    }

    public class clsCR_Task
    {

        internal ActiveGanttCSWCtl mp_oControl;
        internal SqlCeConnection mp_oConn;
        internal clsTask mp_oAGTask;

        internal clsCR_Objects mp_oObjects;

        private HPE_ADDMODE mp_lMode;
        public string sCustomerName { get; set; }
        public string sAddress { get; set; }
        public string sCity { get; set; }
        public string sStateAbr { get; set; }
        public string sZIP { get; set; }
        public string sPhone { get; set; }
        public string sMobile { get; set; }
        public decimal cRate { get; set; }
        public decimal cALI { get; set; }
        public decimal cCRF { get; set; }
        public decimal cERF { get; set; }
        public decimal cGPS { get; set; }
        public decimal cLDW { get; set; }
        public decimal cPAI { get; set; }
        public decimal cPEP { get; set; }
        public decimal cRCFC { get; set; }
        public decimal cVLF { get; set; }
        public decimal cWTB { get; set; }
        public decimal cTax { get; set; }
        public decimal cEstimatedTotal { get; set; }
        public bool bGPS { get; set; }
        public bool bFSO { get; set; }
        public bool bLDW { get; set; }
        public bool bPAI { get; set; }
        public bool bPEP { get; set; }
        public bool bALI { get; set; }

        //// Calculated Values
        public decimal cGPSxFactor { get; set; }
        public decimal cLDWxFactor { get; set; }
        public decimal cPAIxFactor { get; set; }
        public decimal cPEPxFactor { get; set; }
        public decimal cALIxFactor { get; set; }
        public decimal cERFxFactor { get; set; }
        public decimal cWTBxFactor { get; set; }
        public decimal cRCFCxFactor { get; set; }
        public decimal cVLFxFactor { get; set; }
        public decimal cCRFxFactor { get; set; }

        public clsCR_Task(clsTask oAGTask, ActiveGanttCSWCtl oControl, SqlCeConnection oConn, clsCR_Objects oObjects)
        {
            mp_oControl = oControl;
            mp_oAGTask = oAGTask;
            mp_oConn = oConn;
            mp_oObjects = oObjects;
        }

        public int lTaskID
        {
            get { return System.Convert.ToInt32(mp_oAGTask.Key.Replace("K", "")); }
        }

        public int lRowID
        {
            get { return System.Convert.ToInt32(mp_oAGTask.RowKey.Replace("K", "")); }
        }

        public HPE_ADDMODE lMode
        {
            get { return mp_lMode; }
            set
            {
                mp_lMode = value;
                if (mp_lMode == HPE_ADDMODE.AM_MAINTENANCE)
                {
                    mp_oAGTask.StyleIndex = "RET3";
                }
                else
                {
                    if (mp_lMode == HPE_ADDMODE.AM_RESERVATION)
                    {
                        mp_oAGTask.StyleIndex = "RET2";
                    }
                    else if (mp_lMode == HPE_ADDMODE.AM_RENTAL)
                    {
                        mp_oAGTask.StyleIndex = "RET1";
                    }
                }
            }
        }

        public string sEstimatedTotal
        {
            get { return cEstimatedTotal.ToString("0.00"); }
        }

        public void UpdateCaption()
        {
            if (mp_lMode == HPE_ADDMODE.AM_MAINTENANCE)
            {
                mp_oAGTask.Text = "Scheduled Maintenance";
            }
            else
            {
                mp_oAGTask.Text = sCustomerName + Environment.NewLine + "Phone: " + sPhone + Environment.NewLine + "Estimated Total: " + sEstimatedTotal + " USD";
            }
        }

        public void TaskChanged()
        {
            GetEstimatedTotal();
            UpdateCaption();
            Update();
        }

        private void mp_AddParameters(clsCmdBuilder oCmdBuilder)
        {
            oCmdBuilder.AddParameter("lRowID", lRowID);
            oCmdBuilder.AddParameter("lMode", System.Convert.ToInt32(lMode));
            oCmdBuilder.AddParameter("sCustomerName", sCustomerName);
            oCmdBuilder.AddParameter("sAddress", sAddress);
            oCmdBuilder.AddParameter("sCity", sCity);
            oCmdBuilder.AddParameter("sStateAbr", sStateAbr);
            oCmdBuilder.AddParameter("sZIP", sZIP);
            oCmdBuilder.AddParameter("sPhone", sPhone);
            oCmdBuilder.AddParameter("sMobile", sMobile);
            oCmdBuilder.AddParameter("dtPickUp", mp_oAGTask.StartDate);
            oCmdBuilder.AddParameter("dtReturn", mp_oAGTask.EndDate);
            oCmdBuilder.AddParameter("cRate", cRate);
            oCmdBuilder.AddParameter("cALI", cALI);
            oCmdBuilder.AddParameter("cCRF", cCRF);
            oCmdBuilder.AddParameter("cERF", cERF);
            oCmdBuilder.AddParameter("cGPS", cGPS);
            oCmdBuilder.AddParameter("cLDW", cLDW);
            oCmdBuilder.AddParameter("cPAI", cPAI);
            oCmdBuilder.AddParameter("cPEP", cPEP);
            oCmdBuilder.AddParameter("cRCFC", cRCFC);
            oCmdBuilder.AddParameter("cVLF", cVLF);
            oCmdBuilder.AddParameter("cWTB", cWTB);
            oCmdBuilder.AddParameter("cTax", cTax);
            oCmdBuilder.AddParameter("cEstimatedTotal", cEstimatedTotal);
            oCmdBuilder.AddParameter("bGPS", bGPS);
            oCmdBuilder.AddParameter("bFSO", bFSO);
            oCmdBuilder.AddParameter("bLDW", bLDW);
            oCmdBuilder.AddParameter("bPAI", bPAI);
            oCmdBuilder.AddParameter("bPEP", bPEP);
            oCmdBuilder.AddParameter("bALI", bALI);
        }

        public void Update()
        {
            clsCmdBuilder oCmdBuilder = new clsCmdBuilder();
            mp_AddParameters(oCmdBuilder);
            string sSQL = oCmdBuilder.Update("tb_CR_Rentals", "lTaskID = " + lTaskID.ToString());
            SqlCeCommand oCmd = new SqlCeCommand(sSQL, mp_oConn);
            oCmd.ExecuteNonQuery();
        }

        public int Insert()
        {
            int lReturn = 0;
            clsCmdBuilder oCmdBuilder = new clsCmdBuilder();
            mp_AddParameters(oCmdBuilder);
            string sSQL = oCmdBuilder.Insert("tb_CR_Rentals");
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

        public decimal cSurcharge
        {
            get { return cERFxFactor + cWTBxFactor + cRCFCxFactor + cVLFxFactor + cCRFxFactor; }
        }

        public void GetEstimatedTotal()
        {
            decimal cFactor = default(decimal);
            decimal cOptions = default(decimal);
            decimal cSubTotal = default(decimal);

            if (lMode == HPE_ADDMODE.AM_MAINTENANCE)
            {
                cEstimatedTotal = 0;
            }

            cFactor = Convert.ToDecimal(mp_oControl.MathLib.DateTimeDiff(E_INTERVAL.IL_HOUR, mp_oAGTask.StartDate, mp_oAGTask.EndDate) / 24);

            if (bGPS == true)
            {
                cGPSxFactor = cGPS * cFactor;
            }
            else
            {
                cGPSxFactor = 0;
            }
            if (bLDW == true)
            {
                cLDWxFactor = cLDW * cFactor;
            }
            else
            {
                cLDWxFactor = 0;
            }
            if (bPAI == true)
            {
                cPAIxFactor = cPAI * cFactor;
            }
            else
            {
                cPAIxFactor = 0;
            }
            if (bPEP == true)
            {
                cPEPxFactor = cPEP * cFactor;
            }
            else
            {
                cPEPxFactor = 0;
            }
            if (bALI == true)
            {
                cALIxFactor = cALI * cFactor;
            }
            else
            {
                cALIxFactor = 0;
            }
            cRate = GetRate();
            cERFxFactor = cERF * cFactor;
            cWTBxFactor = cWTB * cFactor;
            cRCFCxFactor = cRCFC * cFactor;
            cVLFxFactor = cVLF * cFactor;
            cCRFxFactor = cCRF * cRate * cFactor;
            cOptions = cGPSxFactor + cLDWxFactor + cPAIxFactor + cPEPxFactor + cALIxFactor;
            cSubTotal = cSurcharge + (cRate * cFactor);
            cTax = cSubTotal * GetStateTax();
            cEstimatedTotal = cSubTotal + cTax + cOptions;
        }

        public decimal GetRate()
        {
            return GetRow().cRate;
        }

        public clsCR_Row GetRow()
        {
            return mp_oObjects.Rows.Item(mp_oAGTask.RowKey);
        }

        public decimal GetStateTax()
        {
            clsNode oNode = null;
            decimal cCarRentalTax = 0;
            string sRowStateAbr = "";
            oNode = mp_oAGTask.Row.Node.Parent();
            if (oNode == null)
            {
                return 0.1M;
            }
            else
            {
                SqlCeCommand oCmd = new SqlCeCommand("SELECT sStateAbr FROM tb_CR_Rows WHERE lRowID = " + oNode.Row.Key.Replace("K", ""), mp_oConn);
                SqlCeDataReader oReader = oCmd.ExecuteReader();
                if (oReader.Read() == true)
                {
                    sRowStateAbr = System.Convert.ToString(oReader["sStateAbr"]);
                }
                oReader.Close();
                oCmd = new SqlCeCommand("SELECT cCarRentalTax FROM tb_CR_US_States WHERE sStateAbr = '" + sRowStateAbr + "'", mp_oConn);
                oReader = oCmd.ExecuteReader();
                if (oReader.Read() == true)
                {
                    cCarRentalTax = System.Convert.ToDecimal(oReader["cCarRentalTax"]);
                }
                oReader.Close();
            }
            return cCarRentalTax;
        }

        public void Clone(clsCR_Task oClone)
        {
            oClone.sCustomerName = sCustomerName;
            oClone.sAddress = sAddress;
            oClone.sCity = sCity;
            oClone.sStateAbr = sStateAbr;
            oClone.sZIP = sZIP;
            oClone.sPhone = sPhone;
            oClone.sMobile = sMobile;
            oClone.cRate = cRate;
            oClone.cALI = cALI;
            oClone.cCRF = cCRF;
            oClone.cERF = cERF;
            oClone.cGPS = cGPS;
            oClone.cLDW = cLDW;
            oClone.cPAI = cPAI;
            oClone.cPEP = cPEP;
            oClone.cRCFC = cRCFC;
            oClone.cVLF = cVLF;
            oClone.cWTB = cWTB;
            oClone.cTax = cTax;
            oClone.cEstimatedTotal = cEstimatedTotal;
            oClone.bGPS = bGPS;
            oClone.bFSO = bFSO;
            oClone.bLDW = bLDW;
            oClone.bPAI = bPAI;
            oClone.bPEP = bPEP;
            oClone.bALI = bALI;
        }

        public void LoadRentalOptions()
        {
            SqlCeCommand oCmd = new SqlCeCommand("SELECT * FROM tb_CR_Taxes_Surcharges_Options", mp_oConn);
            SqlCeDataReader oReader = oCmd.ExecuteReader();
            while (oReader.Read() == true)
            {
                if (System.Convert.ToString(oReader["sID"]) == "ALI")
                {
                    cALI = System.Convert.ToDecimal(oReader["cRate"]);
                }
                if (System.Convert.ToString(oReader["sID"]) == "CRF")
                {
                    cCRF = System.Convert.ToDecimal(oReader["cRate"]);
                }
                if (System.Convert.ToString(oReader["sID"]) == "ERF")
                {
                    cERF = System.Convert.ToDecimal(oReader["cRate"]);
                }
                if (System.Convert.ToString(oReader["sID"]) == "GPS")
                {
                    cGPS = System.Convert.ToDecimal(oReader["cRate"]);
                }
                if (System.Convert.ToString(oReader["sID"]) == "LDW")
                {
                    cLDW = System.Convert.ToDecimal(oReader["cRate"]);
                }
                if (System.Convert.ToString(oReader["sID"]) == "PAI")
                {
                    cPAI = System.Convert.ToDecimal(oReader["cRate"]);
                }
                if (System.Convert.ToString(oReader["sID"]) == "PEP")
                {
                    cPEP = System.Convert.ToDecimal(oReader["cRate"]);
                }
                if (System.Convert.ToString(oReader["sID"]) == "RCFC")
                {
                    cRCFC = System.Convert.ToDecimal(oReader["cRate"]);
                }
                if (System.Convert.ToString(oReader["sID"]) == "VLF")
                {
                    cVLF = System.Convert.ToDecimal(oReader["cRate"]);
                }
                if (System.Convert.ToString(oReader["sID"]) == "WTB")
                {
                    cWTB = System.Convert.ToDecimal(oReader["cRate"]);
                }
            }
            oReader.Close();
        }

    }


}