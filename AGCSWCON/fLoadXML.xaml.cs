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

    public partial class fLoadXML : Window
    {
        private bool bLoaded = false;

        public fLoadXML()
        {
            InitializeComponent();
        }

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;
        }

        private void mnuLoadXML_Click(object sender, RoutedEventArgs e)
        {
            LoadXML();
        }

        private void mnuSaveXML_Click(object sender, RoutedEventArgs e)
        {
            SaveXML();
        }

        private void cmdLoadXML_Click(object sender, RoutedEventArgs e)
        {
            LoadXML();
        }

        private void cmdSaveXML_Click(object sender, RoutedEventArgs e)
        {
            SaveXML();
        }

        private void mnuClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadXML()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                ActiveGanttCSWCtl1.ReadXML(dlg.FileName);
                bLoaded = true;
                ActiveGanttCSWCtl1.Redraw();
            }
        }

        private void SaveXML()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            if (ActiveGanttCSWCtl1.ControlTag == "WBSProject")
            {
                dlg.FileName = "AGCSW_WBSP";
            }
            else if (ActiveGanttCSWCtl1.ControlTag == "CarRental")
            {
                dlg.FileName = "AGCSW_CR";
            }
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (.xml)|*.xml";
            if (dlg.ShowDialog() == true)
            {
                ActiveGanttCSWCtl1.WriteXML(dlg.FileName);
            }
        }

        private void ActiveGanttCSWCtl1_CustomTierDraw(object sender, CustomTierDrawEventArgs e)
        {
            if (bLoaded == false)
            {
                return;
            }
            if (ActiveGanttCSWCtl1.ControlTag == "CarRental")
            {
                if (e.Interval == E_INTERVAL.IL_HOUR & e.Factor == 12)
                {
                    e.Text = e.StartDate.ToString("tt").ToUpper();
                }
                if (e.Interval == E_INTERVAL.IL_MONTH & e.Factor == 1)
                {
                    e.Text = e.StartDate.ToString("MMMM yyyy");
                }
                if (e.Interval == E_INTERVAL.IL_DAY & e.Factor == 1)
                {
                    e.Text = e.StartDate.ToString("ddd d");
                }
            }
        }

    }
}