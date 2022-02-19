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
    /// Interaction logic for fSortRows.xaml
    /// </summary>
    public partial class fSortRows : Window
    {

        private bool mp_bDescending = false;

        public fSortRows()
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

            int i = 0;
            ActiveGanttCSWCtl1.Columns.Add("", "C1", 125, "");
            for (i = 1; i <= 10; i++)
            {
                string si = null;
                si = i.ToString();
                while (si.Length < 2)
                {
                    si = "0" + si;
                }
                ActiveGanttCSWCtl1.Rows.Add("K" + si, "K" + si, true, true, "");
            }

            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Visible;
        }

        private void cmdSortRows_Click(object sender, RoutedEventArgs e)
        {
            mp_bDescending = !mp_bDescending;
            ActiveGanttCSWCtl1.Rows.SortRows("Text", mp_bDescending, E_SORTTYPE.ES_STRING, -1, -1);
            ActiveGanttCSWCtl1.Redraw();
        }

    }
}