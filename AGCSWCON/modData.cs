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
using System.Data;
using System.Windows.Controls;

namespace AGCSWCON
{
    static class modData
    {

        public static string g_GetDatabaseLocation()
        {
            return AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\", "") + "\\ActiveGanttExamples.sdf";
        }

        public static string g_GetConnectionString()
        {
            return "Data Source=" + g_GetDatabaseLocation();
        }

        public static void g_FillComboBox(ComboBox oComboBox, string sSQL, string sValueMember, string sDisplayMember, SqlCeConnection oConn)
        {
            SqlCeDataAdapter oAdapter = new SqlCeDataAdapter();
            DataTable oDataTable = new DataTable();
            oAdapter.SelectCommand = new SqlCeCommand(sSQL, oConn);
            oAdapter.Fill(oDataTable);
            oComboBox.ItemsSource = oDataTable.DefaultView;
            oComboBox.DisplayMemberPath = sDisplayMember;
            oComboBox.SelectedValuePath = sValueMember;
        }

        public static string g_ConvertDate(DateTime dtDate)
        {
            string sReturn = "";
            sReturn = "'" + dtDate.ToString("yyyy/MM/dd HH:mm:ss") + "'";
            return sReturn;
        }

    }
}