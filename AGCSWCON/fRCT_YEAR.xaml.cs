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
    /// Interaction logic for fRCT_YEAR.xaml
    /// </summary>
    public partial class fRCT_YEAR : Window
    {
        public fRCT_YEAR()
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
            oView = ActiveGanttCSWCtl1.Views.Add(E_INTERVAL.IL_DAY, 1, E_TIERTYPE.ST_YEAR, E_TIERTYPE.ST_NOT_VISIBLE, E_TIERTYPE.ST_MONTH, "View1");
            oView.TimeLine.TickMarkArea.Visible = false;

            ActiveGanttCSWCtl1.TierFormatScope = E_OBJECTSCOPE.OS_CONTROL;
            ActiveGanttCSWCtl1.TierFormat.MonthIntervalFormat = "MM";

            ActiveGanttCSWCtl1.CurrentView = "View1";

            int i = 0;
            for (i = 1; i <= 50; i++)
            {
                ActiveGanttCSWCtl1.Rows.Add("K" + i.ToString());
            }

            clsTimeBlock oTimeBlock;
            DateTime dtDate;
            dtDate = new DateTime(2000, 12, 23, 0, 0, 0);



            oTimeBlock = ActiveGanttCSWCtl1.TimeBlocks.Add("TimeBlock1");
            oTimeBlock.BaseDate = dtDate;
            oTimeBlock.DurationInterval = E_INTERVAL.IL_DAY;
            oTimeBlock.DurationFactor = 15;
            oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING;
            oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_YEAR;

            ActiveGanttCSWCtl1.Width = AGContainerGrid.ActualWidth;
            ActiveGanttCSWCtl1.Height = AGContainerGrid.ActualHeight;

            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Visible;

        }

    }
}