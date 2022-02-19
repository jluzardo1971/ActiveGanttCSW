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
    /// Interaction logic for fMillisecondInterval.xaml
    /// </summary>
    public partial class fMillisecondInterval : Window
    {
        public fMillisecondInterval()
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

            clsView oView;
            oView = ActiveGanttCSWCtl1.Views.Add(E_INTERVAL.IL_MILLISECOND, 5, E_TIERTYPE.ST_MINUTE, E_TIERTYPE.ST_NOT_VISIBLE, E_TIERTYPE.ST_SECOND, "MSI");
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.TimeLine.TierArea.TierFormat.MinuteIntervalFormat = "MMM dd, yyyy hh:mm tt";

            ActiveGanttCSWCtl1.CurrentView = "MSI";

            int i = 0;
            ActiveGanttCSWCtl1.Columns.Add("", "C1", 125, "");
            for (i = 1; i <= 10; i++)
            {
                clsRow oRow;
                oRow = ActiveGanttCSWCtl1.Rows.Add("K" + i.ToString(), "K" + i.ToString(), true, true, "");
            }

            AddTask("K1", GetDate(15, 59, 500), GetDate(16, 0, 100));
            AddTask("K2", GetDate(15, 58, 900), GetDate(16, 1, 200));
            AddTask("K3", GetDate(16, 0, 800), GetDate(16, 1, 300));
            AddTask("K4", GetDate(15, 58, 800), GetDate(16, 2, 0));
            AddTask("K5", GetDate(15, 59, 300), GetDate(16, 1, 0));

            ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.Position(GetDate(15, 58, 0));

            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Visible;

        }

        private DateTime GetDate(int lMinute, int lSecond, int lMillisecond)
        {
            DateTime dtReturn = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, System.DateTime.Now.Hour, lMinute, lSecond, lMillisecond);
            return dtReturn;
        }

        private void AddTask(string sRowKey, DateTime dtStart, DateTime dtEnd)
        {
            string sText = "";
            sText = ActiveGanttCSWCtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_MILLISECOND, dtStart, dtEnd).ToString();
            sText = sText + "ms";
            ActiveGanttCSWCtl1.Tasks.Add(sText, sRowKey, dtStart, dtEnd, "", "", "");
        }

        private void ActiveGanttCSWCtl1_CompleteObjectChange(object sender, ObjectStateChangedEventArgs e)
        {
            if (e.EventTarget == E_EVENTTARGET.EVT_TASK)
            {
                clsTask oTask;
                string sText;
                oTask = ActiveGanttCSWCtl1.Tasks.Item(e.Index.ToString());
                sText = ActiveGanttCSWCtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_MILLISECOND, oTask.StartDate, oTask.EndDate).ToString();
                oTask.Text = sText + "ms";
            }
        }

        private void ActiveGanttCSWCtl1_ObjectAdded(object sender, ObjectAddedEventArgs e)
        {
            if (e.EventTarget == E_EVENTTARGET.EVT_TASK)
            {
                clsTask oTask;
                string sText;
                oTask = ActiveGanttCSWCtl1.Tasks.Item(e.TaskIndex.ToString());
                sText = ActiveGanttCSWCtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_MILLISECOND, oTask.StartDate, oTask.EndDate).ToString();
                oTask.Text = sText + "ms";
            }
        }

    }
}