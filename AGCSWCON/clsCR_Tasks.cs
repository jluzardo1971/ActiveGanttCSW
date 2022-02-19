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

namespace AGCSWCON
{
    public class clsCR_Tasks
    {

        private ActiveGanttCSWCtl mp_oControl;
        private SqlCeConnection mp_oConn;
        private List<clsCR_Task> mp_oCR_Tasks;
        internal clsCR_Objects mp_oObjects;

        public clsCR_Tasks(ActiveGanttCSWCtl oControl, SqlCeConnection oConn, clsCR_Objects oObjects)
        {
            mp_oControl = oControl;
            mp_oConn = oConn;
            mp_oCR_Tasks = new List<clsCR_Task>();
            mp_oObjects = oObjects;
        }

        public void Load()
        {
            SqlCeCommand oCmd = new SqlCeCommand("SELECT * FROM tb_CR_Rentals", mp_oConn);
            SqlCeDataReader oReader = oCmd.ExecuteReader();
            while (oReader.Read() == true)
            {
                clsTask oTask = default(clsTask);
                oTask = mp_oControl.Tasks.Add("", "K" + System.Convert.ToString(oReader["lRowID"]), Globals.FromDate(System.Convert.ToDateTime(oReader["dtPickUp"])), Globals.FromDate(System.Convert.ToDateTime(oReader["dtReturn"])), "K" + System.Convert.ToString(oReader["lTaskID"]));
                clsCR_Task oRental = new clsCR_Task(oTask, mp_oControl, mp_oConn, mp_oObjects);
                oRental.lMode = (HPE_ADDMODE)System.Convert.ToInt32(oReader["lMode"]);
                if (oRental.lMode != HPE_ADDMODE.AM_MAINTENANCE)
                {
                    oRental.sCustomerName = System.Convert.ToString(oReader["sCustomerName"]);
                    oRental.sAddress = System.Convert.ToString(oReader["sAddress"]);
                    oRental.sCity = System.Convert.ToString(oReader["sCity"]);
                    oRental.sStateAbr = System.Convert.ToString(oReader["sStateAbr"]);
                    oRental.sZIP = System.Convert.ToString(oReader["sZIP"]);
                    oRental.sPhone = System.Convert.ToString(oReader["sPhone"]);
                    oRental.sMobile = System.Convert.ToString(oReader["sMobile"]);
                    oRental.cRate = System.Convert.ToDecimal(oReader["cRate"]);
                    oRental.cALI = System.Convert.ToDecimal(oReader["cALI"]);
                    oRental.cCRF = System.Convert.ToDecimal(oReader["cCRF"]);
                    oRental.cERF = System.Convert.ToDecimal(oReader["cERF"]);
                    oRental.cGPS = System.Convert.ToDecimal(oReader["cGPS"]);
                    oRental.cLDW = System.Convert.ToDecimal(oReader["cLDW"]);
                    oRental.cPAI = System.Convert.ToDecimal(oReader["cPAI"]);
                    oRental.cPEP = System.Convert.ToDecimal(oReader["cPEP"]);
                    oRental.cRCFC = System.Convert.ToDecimal(oReader["cRCFC"]);
                    oRental.cVLF = System.Convert.ToDecimal(oReader["cVLF"]);
                    oRental.cWTB = System.Convert.ToDecimal(oReader["cWTB"]);
                    oRental.cTax = System.Convert.ToDecimal(oReader["cTax"]);
                    oRental.cEstimatedTotal = System.Convert.ToDecimal(oReader["cEstimatedTotal"]);
                    oRental.bGPS = System.Convert.ToBoolean(oReader["bGPS"]);
                    oRental.bFSO = System.Convert.ToBoolean(oReader["bFSO"]);
                    oRental.bLDW = System.Convert.ToBoolean(oReader["bLDW"]);
                    oRental.bPAI = System.Convert.ToBoolean(oReader["bPAI"]);
                    oRental.bPEP = System.Convert.ToBoolean(oReader["bPEP"]);
                    oRental.bALI = System.Convert.ToBoolean(oReader["bALI"]);
                }
                oRental.UpdateCaption();
                mp_oCR_Tasks.Add(oRental);
            }
            oReader.Close();
        }

        public string Add(int lTaskIndex, HPE_ADDMODE lMode)
        {
            clsTask oTask = mp_oControl.Tasks.Item(lTaskIndex.ToString());
            clsCR_Task oRental = new clsCR_Task(oTask, mp_oControl, mp_oConn, mp_oObjects);
            oRental.lMode = lMode;
            int lTaskKey = oRental.Insert();
            oRental.mp_oAGTask.Key = "K" + lTaskKey.ToString();
            mp_oCR_Tasks.Add(oRental);
            return oRental.mp_oAGTask.Key;
        }

        public clsCR_Task Item(string sTaskKey)
        {
            int i = 0;
            for (i = 0; i <= mp_oCR_Tasks.Count - 1; i++)
            {
                if (mp_oCR_Tasks[i].mp_oAGTask.Key == sTaskKey)
                {
                    return mp_oCR_Tasks[i];
                }
            }
            return null;
        }

        public void Delete(string sTaskKey)
        {
            int i = 0;
            bool bExists = false;
            for (i = 0; i <= mp_oCR_Tasks.Count - 1; i++)
            {
                if (mp_oCR_Tasks[i].mp_oAGTask.Key == sTaskKey)
                {
                    bExists = true;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            if (bExists == true)
            {
                SqlCeCommand oCmd = new SqlCeCommand("DELETE FROM tb_CR_Rentals WHERE lTaskID = " + sTaskKey.Replace("K", ""), mp_oConn);
                oCmd.ExecuteNonQuery();
                mp_oCR_Tasks.RemoveAt(i);
                mp_oControl.Tasks.Remove(sTaskKey);
            }
        }

        public void RowDelete(string sRowKey)
        {
            int i = 0;
            List<int> oTaskIDsToDelete = new List<int>();
            List<int> oIndexesToDelete = new List<int>();
            for (i = 0; i <= mp_oCR_Tasks.Count - 1; i++)
            {
                if (mp_oCR_Tasks[i].mp_oAGTask.RowKey == sRowKey)
                {
                    oTaskIDsToDelete.Add(mp_oCR_Tasks[i].lTaskID);
                    oIndexesToDelete.Add(i);
                }
            }
            for (i = 0; i <= oTaskIDsToDelete.Count - 1; i++)
            {
                SqlCeCommand oCmd = new SqlCeCommand("DELETE FROM tb_CR_Rentals WHERE lTaskID = " + oTaskIDsToDelete[i], mp_oConn);
                oCmd.ExecuteNonQuery();
                mp_oCR_Tasks.RemoveAt(oIndexesToDelete[i]);
                mp_oControl.Tasks.Remove("K" + oTaskIDsToDelete[i].ToString());
            }
        }

    }
}