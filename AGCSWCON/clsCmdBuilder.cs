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

namespace AGCSWCON
{
    public class clsCmdBuilder
    {

        private List<string> mp_asFieldNames;
        private List<string> mp_asParams;

        public clsCmdBuilder()
        {
            mp_asFieldNames = new List<string>();
            mp_asParams = new List<string>();
        }

        public void AddParameter(string sFieldName, string sValue)
        {
            mp_asFieldNames.Add(sFieldName);
            mp_asParams.Add("'" + sValue + "'");
        }

        public void AddParameter(string sFieldName, bool bValue)
        {
            mp_asFieldNames.Add(sFieldName);
            if (bValue == true)
            {
                mp_asParams.Add("1");
            }
            else
            {
                mp_asParams.Add("0");
            }
        }

        public void AddParameter(string sFieldName, DateTime dtValue)
        {
            mp_asFieldNames.Add(sFieldName);
            mp_asParams.Add("'" + dtValue.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "'");
        }

        public void AddParameter(string sFieldName, decimal cValue)
        {
            mp_asFieldNames.Add(sFieldName);
            mp_asParams.Add(cValue.ToString());
        }

        public void AddParameter(string sFieldName, int lValue)
        {
            mp_asFieldNames.Add(sFieldName);
            mp_asParams.Add(lValue.ToString());
        }

        public string Insert(string sTableName)
        {
            int iIndex = 0;
            string sSQL = "";
            sSQL = "INSERT INTO " + sTableName + " (";
            for (iIndex = 0; iIndex <= mp_asFieldNames.Count - 1; iIndex++)
            {
                sSQL = sSQL + "[" + mp_asFieldNames[iIndex] + "],";
            }
            sSQL = sSQL.Substring(0, sSQL.Length - 1);
            sSQL = sSQL + ") VALUES (";
            for (iIndex = 0; iIndex <= mp_asParams.Count - 1; iIndex++)
            {
                sSQL = sSQL + mp_asParams[iIndex] + ",";
            }
            sSQL = sSQL.Substring(0, sSQL.Length - 1);
            sSQL = sSQL + ")";
            mp_asFieldNames = new List<string>();
            mp_asParams = new List<string>();
            return sSQL;
        }

        public string Update(string sTableName, string sWHERE)
        {
            int iIndex = 0;
            string sSQL = "";
            sSQL = "UPDATE " + sTableName + " SET ";
            for (iIndex = 0; iIndex <= mp_asFieldNames.Count - 1; iIndex++)
            {
                sSQL = sSQL + "[" + mp_asFieldNames[iIndex] + "]=" + mp_asParams[iIndex] + ",";
            }
            sSQL = sSQL.Substring(0, sSQL.Length - 1);
            sSQL = sSQL + " WHERE " + sWHERE;
            mp_asFieldNames = new List<string>();
            mp_asParams = new List<string>();
            return sSQL;
        }

    }
}