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


namespace AGCSWCON
{
    /// <summary>
    /// Interaction logic for fFastLoading.xaml
    /// </summary>
    public partial class fFastLoading : Window
    {
        public fFastLoading()
        {
            InitializeComponent();
            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;

            //If you open the form: Styles And Templates -> Available Templates in the main menu (fTemplates.cs)
            //you can preview all available Templates.
            //Or you can also build your own:
            //fMSProject11.cs shows you how to build a Solid Template in the InitializeAG Method.
            //fMSProject14.cs shows you how to build a Gradient Template in the InitializeAG Method.
            ActiveGanttCSWCtl1.ApplyTemplate(E_CONTROLTEMPLATE.STC_CH_VGRAD_ANAKIWA_BLUE, E_OBJECTTEMPLATE.STO_DEFAULT);

            System.DateTime dtStart = System.DateTime.Now;


            int i = 0;
            ActiveGanttCSWCtl1.Columns.Add("Tasks", "", 200, "");
            ActiveGanttCSWCtl1.TreeviewColumnIndex = 1;
            clsRow oRow = default(clsRow);
            clsTask oTask = default(clsTask);
            int lCurrentDepth = 0;
            DateTime dtStartDate = default(DateTime);
            DateTime dtEndDate = default(DateTime);
            for (i = 0; i <= 10000; i++)
            {
                oRow = ActiveGanttCSWCtl1.Rows.Add("K" + i.ToString(), "Task K" + i.ToString(), true, true, "", false);
                oRow.Height = 20;
                oRow.Node.Depth = lCurrentDepth;
                dtStartDate = ActiveGanttCSWCtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_HOUR, Globals.GetRnd(0, 5), DateTime.Now);
                dtEndDate = ActiveGanttCSWCtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_HOUR, Globals.GetRnd(2, 7), dtStartDate);
                oTask = ActiveGanttCSWCtl1.Tasks.Add("K" + i.ToString(), "K" + i.ToString(), dtStartDate, dtEndDate);
                lCurrentDepth = lCurrentDepth + Globals.GetRnd(-1, 2);
                if (lCurrentDepth < 0)
                {
                    lCurrentDepth = 0;
                }
            }
            ActiveGanttCSWCtl1.Rows.UpdateScrollBar();
            ActiveGanttCSWCtl1.Rows.UpdateTree();

            System.DateTime dtEnd = System.DateTime.Now;

            TimeSpan oTimeSpan = dtEnd.Subtract(dtStart);

            System.Diagnostics.Debug.WriteLine(oTimeSpan.TotalMilliseconds);

            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Visible;
        }

    }
}