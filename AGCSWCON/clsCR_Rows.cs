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
    public class clsCR_Rows
    {

        internal ActiveGanttCSWCtl mp_oControl;
        internal SqlCeConnection mp_oConn;
        private List<clsCR_Row> mp_oCR_Rows;
        internal clsCR_Objects mp_oObjects;

        public clsCR_Rows(ActiveGanttCSWCtl oControl, SqlCeConnection oConn, clsCR_Objects oObjects)
        {
            mp_oControl = oControl;
            mp_oConn = oConn;
            mp_oCR_Rows = new List<clsCR_Row>();
            mp_oObjects = oObjects;
        }

        public void Load()
        {
            SqlCeCommand oCmd = new SqlCeCommand("SELECT * FROM tb_CR_Rows ORDER BY lOrder", mp_oConn);
            SqlCeDataReader oReader = oCmd.ExecuteReader();
            while (oReader.Read() == true)
            {
                clsRow oAGRow = default(clsRow);
                string sRowID = "K" + System.Convert.ToString(oReader["lRowID"]);
                oAGRow = mp_oControl.Rows.Add(sRowID);
                clsCR_Row oVehicleBranch = new clsCR_Row(oAGRow, mp_oControl, mp_oConn, mp_oObjects);
                oVehicleBranch.lDepth = System.Convert.ToInt32(oReader["lDepth"]);
                oVehicleBranch.lOrder = System.Convert.ToInt32(oReader["lOrder"]);
                if (oVehicleBranch.lDepth == 0)
                {
                    //// Branch
                    oVehicleBranch.sCity = System.Convert.ToString(oReader["sCity"]);
                    oVehicleBranch.sBranchName = System.Convert.ToString(oReader["sBranchName"]);
                    oVehicleBranch.sStateAbr = System.Convert.ToString(oReader["sStateAbr"]);
                    oVehicleBranch.sPhone = System.Convert.ToString(oReader["sPhone"]);
                    oVehicleBranch.sManagerName = System.Convert.ToString(oReader["sManagerName"]);
                    oVehicleBranch.sManagerMobile = System.Convert.ToString(oReader["sManagerMobile"]);
                    oVehicleBranch.sAddress = System.Convert.ToString(oReader["sAddress"]);
                    oVehicleBranch.sZIP = System.Convert.ToString(oReader["sZIP"]);
                }
                else if (oVehicleBranch.lDepth == 1)
                {
                    ////Vehicle
                    oVehicleBranch.sLicensePlates = System.Convert.ToString(oReader["sLicensePlates"]);
                    oVehicleBranch.lCarTypeID = System.Convert.ToInt32(oReader["lCarTypeID"]);
                    oVehicleBranch.sNotes = System.Convert.ToString(oReader["sNotes"]);
                    oVehicleBranch.cRate = System.Convert.ToDecimal(oReader["cRate"]);
                    oVehicleBranch.sACRISSCode = System.Convert.ToString(oReader["sACRISSCode"]);
                }
                oVehicleBranch.UpdateCaption();
                mp_oCR_Rows.Add(oVehicleBranch);
            }
            oReader.Close();
        }

        public string Add(int lDepth)
        {
            clsRow oAGRow = mp_oControl.Rows.Add("TR1");
            clsCR_Row oVehicleBranch = new clsCR_Row(oAGRow, mp_oControl, mp_oConn, mp_oObjects);
            oVehicleBranch.lDepth = lDepth;
            oVehicleBranch.lOrder = GetlOrderMax() + 1;
            int lRowKey = oVehicleBranch.Insert();
            oVehicleBranch.mp_oAGRow.Key = "K" + lRowKey.ToString();
            mp_oCR_Rows.Add(oVehicleBranch);
            return oVehicleBranch.mp_oAGRow.Key;
        }

        public clsCR_Row Item(string sRowKey)
        {
            int i = 0;
            for (i = 0; i <= mp_oCR_Rows.Count - 1; i++)
            {
                if (mp_oCR_Rows[i].mp_oAGRow.Key == sRowKey)
                {
                    return mp_oCR_Rows[i];
                }
            }
            return null;
        }

        public void Delete(string sRowKey)
        {
            int i = 0;
            bool bExists = false;
            for (i = 0; i <= mp_oCR_Rows.Count - 1; i++)
            {
                if (mp_oCR_Rows[i].mp_oAGRow.Key == sRowKey)
                {
                    bExists = true;
                    break;
                }
            }
            if (bExists == true)
            {
                mp_oObjects.Tasks.RowDelete(sRowKey);
                SqlCeCommand oCmd = new SqlCeCommand("DELETE FROM tb_CR_Rows WHERE lRowID = " + sRowKey.Replace("K", ""), mp_oConn);
                oCmd.ExecuteNonQuery();
                mp_oCR_Rows.RemoveAt(i);
                mp_oControl.Rows.Remove(sRowKey);
            }
        }

        public void UpdateOrder()
        {
            int i = 0;
            for (i = 0; i <= mp_oCR_Rows.Count - 1; i++)
            {
                SqlCeCommand oCmd = new SqlCeCommand("UPDATE tb_CR_Rows SET lOrder = " + mp_oCR_Rows[i].mp_oAGRow.Index + " WHERE lRowID = " + mp_oCR_Rows[i].lRowID.ToString(), mp_oConn);
                oCmd.ExecuteNonQuery();
            }
        }

        public int GetlOrderMax()
        {
            int lReturn = 0;
            SqlCeCommand oCmd = new SqlCeCommand("SELECT MAX(lOrder) As lMax FROM tb_CR_Rows", mp_oConn);
            SqlCeDataReader oReader = oCmd.ExecuteReader();
            if (oReader.Read() == true)
            {
                lReturn = System.Convert.ToInt32(oReader["lMax"]);
            }
            oReader.Close();
            return lReturn;
        }

    }
}