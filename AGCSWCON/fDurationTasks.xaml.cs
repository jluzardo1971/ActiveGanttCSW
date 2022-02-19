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
using System.Diagnostics;

namespace AGCSWCON
{
    /// <summary>
    /// Interaction logic for fDurationTasks.xaml
    /// </summary>
    public partial class fDurationTasks : Window
    {
        public fDurationTasks()
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

            ActiveGanttCSWCtl1.AddMode = E_ADDMODE.AT_DURATION_BOTH;
            ActiveGanttCSWCtl1.AddDurationInterval = E_INTERVAL.IL_HOUR;

            clsView oView;
            oView = ActiveGanttCSWCtl1.Views.Add(E_INTERVAL.IL_MINUTE, 10, E_TIERTYPE.ST_MONTH, E_TIERTYPE.ST_NOT_VISIBLE, E_TIERTYPE.ST_DAYOFWEEK, "View1");
            oView.TimeLine.TickMarkArea.Visible = false;

            ActiveGanttCSWCtl1.CurrentView = "View1";

            int i = 0;
            for (i = 0; i <= 110; i++)
            {
                ActiveGanttCSWCtl1.Rows.Add("K" + i.ToString());
            }

            clsTimeBlock oTimeBlock;

            //Note: non-working overlapping TimeBlock objects are combined for duration calculation purposes.


            // TimeBlock starts at 6:00pm and ends on 7:00am next day (13 Hours)
            // This TimeBlock is repeated every day.
            oTimeBlock = ActiveGanttCSWCtl1.TimeBlocks.Add("TB_OutOfOfficeHours");
            oTimeBlock.NonWorking = true;
            oTimeBlock.BaseDate = new DateTime(2000, 1, 1, 18, 0, 0);
            oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR;
            oTimeBlock.DurationFactor = 13;
            oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING;
            oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_DAY;

            // TimeBlock starts at 12:00pm (noon) and ends at 1:30pm (90 Minutes)
            // This TimeBlock is repeated every day. 
            oTimeBlock = ActiveGanttCSWCtl1.TimeBlocks.Add("TB_LunchBreak");
            oTimeBlock.NonWorking = true;
            oTimeBlock.BaseDate = new DateTime(2000, 1, 1, 12, 0, 0);
            oTimeBlock.DurationInterval = E_INTERVAL.IL_MINUTE;
            oTimeBlock.DurationFactor = 90;
            oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING;
            oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_DAY;

            // Timeblock starts at 12:00am Saturday and ends on 12:00am Monday (48 Hours)
            // This TimeBlock is repeated every week.
            oTimeBlock = ActiveGanttCSWCtl1.TimeBlocks.Add("TB_Weekend");
            oTimeBlock.NonWorking = true;
            oTimeBlock.BaseDate = new DateTime(2000, 1, 1, 0, 0, 0);
            oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR;
            oTimeBlock.DurationFactor = 48;
            oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING;
            oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_WEEK;
            oTimeBlock.BaseWeekDay = E_WEEKDAY.WD_SATURDAY;

            // Arbitrary holiday that starts at 12:00am January 8th and ends on 12:00am January 9th (24 hours)
            // This TimeBlock is repeated every year.
            oTimeBlock = ActiveGanttCSWCtl1.TimeBlocks.Add("TB_Jan8");
            oTimeBlock.NonWorking = true;
            oTimeBlock.BaseDate = new DateTime(2000, 1, 8, 0, 0, 0);
            oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR;
            oTimeBlock.DurationFactor = 24;
            oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING;
            oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_YEAR;

            ActiveGanttCSWCtl1.TimeBlocks.IntervalStart = new DateTime(2012, 1, 1);
            ActiveGanttCSWCtl1.TimeBlocks.IntervalEnd = new DateTime(2023, 6, 1);
            ActiveGanttCSWCtl1.TimeBlocks.IntervalType = E_TBINTERVALTYPE.TBIT_MANUAL;
            ActiveGanttCSWCtl1.TimeBlocks.CalculateInterval();


            clsTask oTask;
            for (i = 0; i <= 100; i++)
            {
                oTask = ActiveGanttCSWCtl1.Tasks.DAdd("K" + i.ToString(), new DateTime(2013, 1, 1), E_INTERVAL.IL_HOUR, i, i.ToString(), "", "", "0");

                DateTime dtStartDate;
                DateTime dtEndDate;

                dtStartDate = oTask.StartDate;
                dtEndDate = oTask.EndDate;

                int lDuration = 0;
                lDuration = ActiveGanttCSWCtl1.MathLib.CalculateDuration(ref dtStartDate, ref dtEndDate, oTask.DurationInterval);
                if (lDuration != oTask.DurationFactor)
                {
                    Debug.WriteLine("Error: " + i.ToString());
                    Debug.WriteLine("  Task Duration Factor: " + oTask.DurationFactor.ToString());
                    Debug.WriteLine("  Calculated Duration: " + lDuration.ToString());
                    Debug.WriteLine("  Task:");
                    Debug.WriteLine("    " + oTask.StartDate.ToString("yyyy/MM/dd HH:mm:ss"));
                    Debug.WriteLine("    " + oTask.EndDate.ToString("yyyy/MM/dd HH:mm:ss"));
                    Debug.WriteLine("  Calculated:");
                    Debug.WriteLine("    " + dtStartDate.ToString("yyyy/MM/dd HH:mm:ss"));
                    Debug.WriteLine("    " + dtEndDate.ToString("yyyy/MM/dd HH:mm:ss"));
                }

            }

            ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.Position(new DateTime(2013, 1, 1));

            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Visible;

        }

    }
}