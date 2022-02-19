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

namespace AGCSWCON
{
    /// <summary>
    /// Interaction logic for fWBSPProperties.xaml
    /// </summary>
    public partial class fWBSPProperties : Window
    {
        fWBSProject mp_oParent;

        public fWBSPProperties(fWBSProject oParent)
        {
            InitializeComponent();
            mp_oParent = oParent;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            chkEnforcePredecessors.IsChecked = mp_oParent.ActiveGanttCSWCtl1.EnforcePredecessors;
            cboPredecessorMode.SelectedValue = System.Convert.ToInt32(mp_oParent.ActiveGanttCSWCtl1.PredecessorMode).ToString();
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            mp_oParent.ActiveGanttCSWCtl1.EnforcePredecessors = (bool)chkEnforcePredecessors.IsChecked;
            mp_oParent.ActiveGanttCSWCtl1.PredecessorMode = (AGCSW.E_PREDECESSORMODE)System.Convert.ToInt32(cboPredecessorMode.SelectedValue);
            this.Close();
        }


    }
}