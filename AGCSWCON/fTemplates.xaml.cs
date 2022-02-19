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
    /// Interaction logic for fTemplates.xaml
    /// </summary>
    public partial class fTemplates : Window
    {

        

        public fTemplates()
        {
            InitializeComponent();
            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;

            ActiveGanttCSWCtl1.ApplyTemplate(E_CONTROLTEMPLATE.STC_CH_VGRAD_ANAKIWA_BLUE, E_OBJECTTEMPLATE.STO_DEFAULT);

            int lIndex = 0;
            for (lIndex = 0; lIndex <= 30; lIndex++)
            {
                E_CONTROLTEMPLATE yTemplate = (E_CONTROLTEMPLATE)lIndex;
                cboControlTemplates.Items.Add(yTemplate.ToString());
            }
            cboControlTemplates.SelectedIndex = (Int32)ActiveGanttCSWCtl1.ControlTemplate;
            for (lIndex = 0; lIndex <= 6; lIndex++)
            {
                E_OBJECTTEMPLATE yTemplate = (E_OBJECTTEMPLATE)lIndex;
                cboObjectTemplates.Items.Add(yTemplate.ToString());
            }
            cboObjectTemplates.SelectedIndex = (Int32)ActiveGanttCSWCtl1.ObjectTemplate;

            clsColumn oColumn;
            oColumn = ActiveGanttCSWCtl1.Columns.Add("Object", "", 70);
            oColumn = ActiveGanttCSWCtl1.Columns.Add("Style", "", 50);
            oColumn = ActiveGanttCSWCtl1.Columns.Add("Nodes", "", 125);


            for (lIndex = 1; lIndex <= 100; lIndex++)
            {
                clsRow oRow;
                oRow = ActiveGanttCSWCtl1.Rows.Add("K" + lIndex.ToString());
                oRow.Text = "Row " + lIndex.ToString();
                if (oRow.Index % 5 == 0 | oRow.Index == 1)
                {
                    oRow.Node.Depth = 0;
                }
                else
                {
                    oRow.Node.Depth = 1;
                }
                oRow.Node.CheckBoxVisible = true;
                oRow.Height = 20;
            }
            ActiveGanttCSWCtl1.Treeview.CheckBoxes = true;
            ActiveGanttCSWCtl1.TreeviewColumnIndex = 3;
            ActiveGanttCSWCtl1.Rows.UpdateTree();

            clsTask oTask;
            clsPercentage oPercentage;
            clsPredecessor oPredecessor;
            clsTimeBlock oTimeBlock;
            mp_CaptionRow("K1", "Task", "T1");
            mp_CaptionRow("K3", "Task", "T2");
            mp_CaptionRow("K5", "Task", "T3");
            mp_CaptionRow("K7", "Task", "T4");
            mp_CaptionRow("K9", "Task", "S1");
            mp_CaptionRow("K11", "Task", "S2");
            mp_CaptionRow("K13", "Task", "S3");
            mp_CaptionRow("K15", "Task", "S4");
            mp_CaptionRow("K17", "Percentage", "P1");
            mp_CaptionRow("K19", "Percentage", "P2");
            mp_CaptionRow("K21", "Percentage", "P3");
            mp_CaptionRow("K23", "Percentage", "P4");
            mp_CaptionRow("K25", "Percentage", "SP1");
            mp_CaptionRow("K27", "Percentage", "SP2");
            mp_CaptionRow("K29", "Percentage", "SP3");
            mp_CaptionRow("K31", "Percentage", "SP4");
            mp_CaptionRow("K33", "Task", "RET1");
            mp_CaptionRow("K35", "Task", "RET2");
            mp_CaptionRow("K37", "Task", "RET3");
            mp_CaptionRow("K39", "Task", "RET4");

            oTask = ActiveGanttCSWCtl1.Tasks.Add("T1", "K1", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "T1", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("", "K2", new DateTime(2013, 1, 1, 8, 0, 0), new DateTime(2013, 1, 1, 8, 0, 0), "M1", "");
            oPredecessor = ActiveGanttCSWCtl1.Predecessors.Add("M1", "T1", E_CONSTRAINTTYPE.PCT_END_TO_START, "PD1", "");

            oTask = ActiveGanttCSWCtl1.Tasks.Add("T2", "K3", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "T2", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("", "K4", new DateTime(2013, 1, 1, 8, 0, 0), new DateTime(2013, 1, 1, 8, 0, 0), "M2", "");
            oPredecessor = ActiveGanttCSWCtl1.Predecessors.Add("M2", "T2", E_CONSTRAINTTYPE.PCT_END_TO_START, "PD2", "");

            oTask = ActiveGanttCSWCtl1.Tasks.Add("T3", "K5", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "T3", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("", "K6", new DateTime(2013, 1, 1, 8, 0, 0), new DateTime(2013, 1, 1, 8, 0, 0), "M3", "");
            oPredecessor = ActiveGanttCSWCtl1.Predecessors.Add("M3", "T3", E_CONSTRAINTTYPE.PCT_END_TO_START, "PD3", "");

            oTask = ActiveGanttCSWCtl1.Tasks.Add("T4", "K7", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "T4", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("", "K8", new DateTime(2013, 1, 1, 8, 0, 0), new DateTime(2013, 1, 1, 8, 0, 0), "M4", "");
            oPredecessor = ActiveGanttCSWCtl1.Predecessors.Add("M4", "T4", E_CONSTRAINTTYPE.PCT_END_TO_START, "PD4", "");

            oTask = ActiveGanttCSWCtl1.Tasks.Add("S1", "K9", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "S1", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("S2", "K11", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "S2", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("S3", "K13", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "S3", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("S4", "K15", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "S4", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("", "K17", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "T1P1", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("", "K19", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "T2P2", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("", "K21", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "T3P3", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("", "K23", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "T4P4", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("", "K25", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "S1SP1", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("", "K27", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "S2SP2", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("", "K29", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "S3SP3", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("", "K31", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "S4SP4", "");
            oPercentage = ActiveGanttCSWCtl1.Percentages.Add("T1P1", "", 0.5F, "P1");
            oPercentage = ActiveGanttCSWCtl1.Percentages.Add("T2P2", "", 0.5F, "P2");
            oPercentage = ActiveGanttCSWCtl1.Percentages.Add("T3P3", "", 0.5F, "P3");
            oPercentage = ActiveGanttCSWCtl1.Percentages.Add("T4P4", "", 0.5F, "P4");
            oPercentage = ActiveGanttCSWCtl1.Percentages.Add("S1SP1", "", 0.5F, "SP1");
            oPercentage = ActiveGanttCSWCtl1.Percentages.Add("S2SP2", "", 0.5F, "SP2");
            oPercentage = ActiveGanttCSWCtl1.Percentages.Add("S3SP3", "", 0.5F, "SP3");
            oPercentage = ActiveGanttCSWCtl1.Percentages.Add("S4SP4", "", 0.5F, "SP4");

            oTask = ActiveGanttCSWCtl1.Tasks.Add("RET1", "K33", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "RET1", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("RET2", "K35", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "RET2", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("RET3", "K37", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "RET3", "");
            oTask = ActiveGanttCSWCtl1.Tasks.Add("RET4", "K39", new DateTime(2013, 1, 1, 1, 0, 0), new DateTime(2013, 1, 1, 5, 0, 0), "RET4", "");

            oTimeBlock = ActiveGanttCSWCtl1.TimeBlocks.Add("TB1");
            oTimeBlock.BaseDate = new DateTime(2013, 1, 1, 9, 0, 0);
            oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR;
            oTimeBlock.DurationFactor = 3;



            mp_SetStyles();

            ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.Position(new DateTime(2013, 1, 1));

            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Visible;

        }

        private void mp_CaptionRow(string sRowKey, string sObject, string sStyle)
        {
            ActiveGanttCSWCtl1.Rows.Item(sRowKey).Cells.Item("1").Text = sObject;
            ActiveGanttCSWCtl1.Rows.Item(sRowKey).Cells.Item("2").Text = sStyle;
        }

        private void mp_SetStyles()
        {
            //Setting a template invokes the Clear method on the Styles Collection
            //and resets all StyleIndex properties of every object to ""
            if (ActiveGanttCSWCtl1.Styles.ContainsKey("T1") == true)
            {
                ActiveGanttCSWCtl1.Tasks.Item("T1").StyleIndex = "T1";
                ActiveGanttCSWCtl1.Tasks.Item("T2").StyleIndex = "T2";
                ActiveGanttCSWCtl1.Tasks.Item("T3").StyleIndex = "T3";
                ActiveGanttCSWCtl1.Tasks.Item("T4").StyleIndex = "T4";
                ActiveGanttCSWCtl1.Tasks.Item("M1").StyleIndex = "T1";
                ActiveGanttCSWCtl1.Tasks.Item("M2").StyleIndex = "T2";
                ActiveGanttCSWCtl1.Tasks.Item("M3").StyleIndex = "T3";
                ActiveGanttCSWCtl1.Tasks.Item("M4").StyleIndex = "T4";
                ActiveGanttCSWCtl1.Tasks.Item("T1P1").StyleIndex = "T1";
                ActiveGanttCSWCtl1.Tasks.Item("T2P2").StyleIndex = "T2";
                ActiveGanttCSWCtl1.Tasks.Item("T3P3").StyleIndex = "T3";
                ActiveGanttCSWCtl1.Tasks.Item("T4P4").StyleIndex = "T4";
                ActiveGanttCSWCtl1.Predecessors.Item("PD1").StyleIndex = "T1";
                ActiveGanttCSWCtl1.Predecessors.Item("PD2").StyleIndex = "T2";
                ActiveGanttCSWCtl1.Predecessors.Item("PD3").StyleIndex = "T3";
                ActiveGanttCSWCtl1.Predecessors.Item("PD4").StyleIndex = "T4";

                ActiveGanttCSWCtl1.Tasks.Item("T1").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("T2").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("T3").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("T4").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("M1").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("M2").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("M3").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("M4").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("T1P1").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("T2P2").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("T3P3").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("T4P4").Visible = true;
                ActiveGanttCSWCtl1.Predecessors.Item("PD1").Visible = true;
                ActiveGanttCSWCtl1.Predecessors.Item("PD2").Visible = true;
                ActiveGanttCSWCtl1.Predecessors.Item("PD3").Visible = true;
                ActiveGanttCSWCtl1.Predecessors.Item("PD4").Visible = true;
            }
            else
            {
                ActiveGanttCSWCtl1.Tasks.Item("T1").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("T2").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("T3").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("T4").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("M1").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("M2").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("M3").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("M4").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("T1P1").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("T2P2").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("T3P3").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("T4P4").Visible = false;
                ActiveGanttCSWCtl1.Predecessors.Item("PD1").Visible = false;
                ActiveGanttCSWCtl1.Predecessors.Item("PD2").Visible = false;
                ActiveGanttCSWCtl1.Predecessors.Item("PD3").Visible = false;
                ActiveGanttCSWCtl1.Predecessors.Item("PD4").Visible = false;
            }

            if (ActiveGanttCSWCtl1.Styles.ContainsKey("P1") == true)
            {
                ActiveGanttCSWCtl1.Percentages.Item("P1").StyleIndex = "P1";
                ActiveGanttCSWCtl1.Percentages.Item("P2").StyleIndex = "P2";
                ActiveGanttCSWCtl1.Percentages.Item("P3").StyleIndex = "P3";
                ActiveGanttCSWCtl1.Percentages.Item("P4").StyleIndex = "P4";

                ActiveGanttCSWCtl1.Percentages.Item("P1").Visible = true;
                ActiveGanttCSWCtl1.Percentages.Item("P2").Visible = true;
                ActiveGanttCSWCtl1.Percentages.Item("P3").Visible = true;
                ActiveGanttCSWCtl1.Percentages.Item("P4").Visible = true;
            }
            else
            {
                ActiveGanttCSWCtl1.Percentages.Item("P1").Visible = false;
                ActiveGanttCSWCtl1.Percentages.Item("P2").Visible = false;
                ActiveGanttCSWCtl1.Percentages.Item("P3").Visible = false;
                ActiveGanttCSWCtl1.Percentages.Item("P4").Visible = false;
            }

            if (ActiveGanttCSWCtl1.Styles.ContainsKey("S1") == true)
            {
                ActiveGanttCSWCtl1.Tasks.Item("S1").StyleIndex = "S1";
                ActiveGanttCSWCtl1.Tasks.Item("S2").StyleIndex = "S2";
                ActiveGanttCSWCtl1.Tasks.Item("S3").StyleIndex = "S3";
                ActiveGanttCSWCtl1.Tasks.Item("S4").StyleIndex = "S4";
                ActiveGanttCSWCtl1.Tasks.Item("S1SP1").StyleIndex = "S1";
                ActiveGanttCSWCtl1.Tasks.Item("S2SP2").StyleIndex = "S2";
                ActiveGanttCSWCtl1.Tasks.Item("S3SP3").StyleIndex = "S3";
                ActiveGanttCSWCtl1.Tasks.Item("S4SP4").StyleIndex = "S4";

                ActiveGanttCSWCtl1.Tasks.Item("S1").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("S2").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("S3").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("S4").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("S1SP1").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("S2SP2").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("S3SP3").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("S4SP4").Visible = true;
            }
            else
            {
                ActiveGanttCSWCtl1.Tasks.Item("S1").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("S2").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("S3").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("S4").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("S1SP1").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("S2SP2").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("S3SP3").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("S4SP4").Visible = false;
            }

            if (ActiveGanttCSWCtl1.Styles.ContainsKey("SP1") == true)
            {
                ActiveGanttCSWCtl1.Percentages.Item("SP1").StyleIndex = "SP1";
                ActiveGanttCSWCtl1.Percentages.Item("SP2").StyleIndex = "SP2";
                ActiveGanttCSWCtl1.Percentages.Item("SP3").StyleIndex = "SP3";
                ActiveGanttCSWCtl1.Percentages.Item("SP4").StyleIndex = "SP4";

                ActiveGanttCSWCtl1.Percentages.Item("SP1").Visible = true;
                ActiveGanttCSWCtl1.Percentages.Item("SP2").Visible = true;
                ActiveGanttCSWCtl1.Percentages.Item("SP3").Visible = true;
                ActiveGanttCSWCtl1.Percentages.Item("SP4").Visible = true;
            }
            else
            {
                ActiveGanttCSWCtl1.Percentages.Item("SP1").Visible = false;
                ActiveGanttCSWCtl1.Percentages.Item("SP2").Visible = false;
                ActiveGanttCSWCtl1.Percentages.Item("SP3").Visible = false;
                ActiveGanttCSWCtl1.Percentages.Item("SP4").Visible = false;
            }

            if (ActiveGanttCSWCtl1.Styles.ContainsKey("RET1") == true)
            {
                ActiveGanttCSWCtl1.Tasks.Item("RET1").StyleIndex = "RET1";
                ActiveGanttCSWCtl1.Tasks.Item("RET2").StyleIndex = "RET2";
                ActiveGanttCSWCtl1.Tasks.Item("RET3").StyleIndex = "RET3";
                ActiveGanttCSWCtl1.Tasks.Item("RET4").StyleIndex = "RET4";

                ActiveGanttCSWCtl1.Tasks.Item("RET1").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("RET2").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("RET3").Visible = true;
                ActiveGanttCSWCtl1.Tasks.Item("RET4").Visible = true;
            }
            else
            {
                ActiveGanttCSWCtl1.Tasks.Item("RET1").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("RET2").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("RET3").Visible = false;
                ActiveGanttCSWCtl1.Tasks.Item("RET4").Visible = false;
            }
        }

        private void cboControlTemplates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ActiveGanttCSWCtl1.ControlTemplate != (E_CONTROLTEMPLATE)cboControlTemplates.SelectedIndex)
            {
                ActiveGanttCSWCtl1.ApplyTemplate((E_CONTROLTEMPLATE)cboControlTemplates.SelectedIndex, (E_OBJECTTEMPLATE)cboObjectTemplates.SelectedIndex);
                mp_SetStyles();
                ActiveGanttCSWCtl1.Redraw();
            }
        }

        private void cboObjectTemplates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ActiveGanttCSWCtl1.ObjectTemplate != (E_OBJECTTEMPLATE)cboObjectTemplates.SelectedIndex)
            {
                ActiveGanttCSWCtl1.ApplyTemplate((E_CONTROLTEMPLATE)cboControlTemplates.SelectedIndex, (E_OBJECTTEMPLATE)cboObjectTemplates.SelectedIndex);
                mp_SetStyles();
                ActiveGanttCSWCtl1.Redraw();
            }
        }

        private void cmdCopy_Click(object sender, RoutedEventArgs e)
        {
            string sText = "ActiveGanttCSWCtl1.ApplyTemplate(E_CONTROLTEMPLATE." + cboControlTemplates.Text + ", E_OBJECTTEMPLATE." + cboObjectTemplates.Text + ")";
            Clipboard.SetData(DataFormats.Text, (object)sText);
            MessageBox.Show("\"" + sText + "\" has been copied to the clipboard.", "Templates", MessageBoxButton.OK);
        }






    }
}