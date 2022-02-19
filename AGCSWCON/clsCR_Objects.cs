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
    public class clsCR_Objects
    {

        private clsCR_Rows mp_oRows;
        private clsCR_Tasks mp_oTasks;
        private SqlCeConnection mp_oConn;

        public clsCR_Objects(ActiveGanttCSWCtl oControl)
        {
            mp_oConn = new SqlCeConnection(modData.g_GetConnectionString());
            mp_oConn.Open();
            mp_oRows = new clsCR_Rows(oControl, mp_oConn, this);
            mp_oTasks = new clsCR_Tasks(oControl, mp_oConn, this);
        }

        ~clsCR_Objects()
        {
            mp_oConn.Close();
        }

        public SqlCeConnection Connection
        {
            get { return mp_oConn; }
        }

        public clsCR_Rows Rows
        {
            get { return mp_oRows; }
        }

        public clsCR_Tasks Tasks
        {
            get { return mp_oTasks; }
        }

        public void LoadData()
        {
            mp_oRows.Load();
            mp_oTasks.Load();
        }

    }
}