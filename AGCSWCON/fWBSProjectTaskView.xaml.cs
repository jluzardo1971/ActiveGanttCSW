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
using System.Data.SqlServerCe;
using AGCSW;
using System.Data;


namespace AGCSWCON
{

    public partial class fWBSProjectTaskView : Window
    {
        private int mp_lTaskIndex;
        private fWBSProject mp_oParent;
        private Grid mp_oGrid;


        public fWBSProjectTaskView(fWBSProject oParent, int lTaskIndex)
        {
            InitializeComponent();
            mp_oParent = oParent;
            mp_lTaskIndex = lTaskIndex;
        }

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            ColumnDefinition oColumn1 = new ColumnDefinition();
            oColumn1.Width = new System.Windows.GridLength(40);
            ColumnDefinition oColumn2 = new ColumnDefinition();
            oColumn2.Width = new System.Windows.GridLength(260);
            ColumnDefinition oColumn3 = new ColumnDefinition();
            oColumn3.Width = new System.Windows.GridLength(100);
            RowDefinition oRow = new RowDefinition();
            oRow.Height = new System.Windows.GridLength(20);
            int i = 1;

            clsTask oTask;
            oTask = mp_oParent.ActiveGanttCSWCtl1.Tasks.Item(mp_lTaskIndex.ToString());
            this.Title = oTask.Row.Text;
            txtTaskName.Text = oTask.Row.Text;

            mp_oGrid = new Grid();
            mp_oGrid.ColumnDefinitions.Add(oColumn1);
            mp_oGrid.ColumnDefinitions.Add(oColumn2);
            mp_oGrid.ColumnDefinitions.Add(oColumn3);
            mp_oGrid.RowDefinitions.Add(oRow);
            AddTextBlock("ID", 0, 0);
            AddTextBlock("Predecessor Task Name", 0, 1);
            AddTextBlock("Type", 0, 2);

            SqlCeDataReader oReader = null;
            string sSQL = "SELECT tb_GuysStThomas_Predecessors.lSuccessorTaskID, tb_GuysStThomas_Predecessors.lPredecessorTaskID, tb_GuysStThomas.sDescription AS sDescription, " +
            "  (CASE WHEN tb_GuysStThomas_Predecessors.lType=0 THEN 'End-To-Start (ES)' ELSE '' END) " +
            "+ (CASE WHEN tb_GuysStThomas_Predecessors.lType=1 THEN 'Start-To-Start (SS)' ELSE '' END) " +
            "+ (CASE WHEN tb_GuysStThomas_Predecessors.lType=2 THEN 'End-To-End (EE)' ELSE '' END) " +
            "+ (CASE WHEN tb_GuysStThomas_Predecessors.lType=3 THEN 'Start-To-End (SE)' ELSE '' END) " +
            "AS sPredecessorType FROM tb_GuysStThomas RIGHT JOIN tb_GuysStThomas_Predecessors ON tb_GuysStThomas.[lTaskID] = tb_GuysStThomas_Predecessors.[lPredecessorTaskID] WHERE tb_GuysStThomas_Predecessors.lSuccessorTaskID=" + mp_lTaskIndex.ToString();
            SqlCeCommand oCmd = new SqlCeCommand(sSQL, mp_oParent.mp_oConn);
            oReader = oCmd.ExecuteReader();
            while (oReader.Read() == true)
            {
                RowDefinition oRowD = new RowDefinition();
                oRowD.Height = new System.Windows.GridLength(20);
                mp_oGrid.RowDefinitions.Add(oRowD);
                AddTextBlock(oReader["lPredecessorTaskID"].ToString(), i, 0);
                AddTextBlock(oReader["sDescription"].ToString(), i, 1);
                AddTextBlock(oReader["sPredecessorType"].ToString(), i, 2);
                i = i + 1;
            }
            oReader.Close();
            mp_oGrid.SetValue(Canvas.LeftProperty, (double)8);
            mp_oGrid.SetValue(Canvas.TopProperty, (double)50);
            oCanvas.Children.Add(mp_oGrid);
        }

        private void AddTextBlock(string sText, int lRow, int lColumn)
        {
            Rectangle oRectangle = new Rectangle();
            oRectangle.Stroke = Brushes.Black;
            switch (lColumn)
            {
                case 0:
                    oRectangle.Width = 41;
                    oRectangle.SetValue(Canvas.LeftProperty, (double)6);
                    break;
                case 1:
                    oRectangle.Width = 261;
                    oRectangle.SetValue(Canvas.LeftProperty, (double)46);
                    break;
                case 2:
                    oRectangle.Width = 101;
                    oRectangle.SetValue(Canvas.LeftProperty, (double)306);
                    break;
            }
            oRectangle.SetValue(Canvas.TopProperty, (double)50 + (19 * lRow));
            oRectangle.Height = 20;
            TextBlock oTextBlock = new TextBlock();
            oTextBlock.Text = sText;
            oTextBlock.FontSize = 11;
            if (lRow == 0)
            {
                oRectangle.Fill = Brushes.Gray;
                oTextBlock.FontWeight = FontWeights.Bold;
            }
            else
            {
                oRectangle.Fill = Brushes.White;
            }
            Grid.SetRow(oTextBlock, lRow);
            Grid.SetColumn(oTextBlock, lColumn);
            oCanvas.Children.Add(oRectangle);
            mp_oGrid.Children.Add(oTextBlock);
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private string GetPredecessorType(int lType)
        {
            if (lType == 0)
            {
                return "End-To-Start (ES)";
            }
            else if (lType == 1)
            {
                return "Start-To-Start (SS)";
            }
            else if (lType == 2)
            {
                return "End-To-End (EE)";
            }
            else if (lType == 3)
            {
                return "Start-To-End (SE)";
            }
            return "";
        }

        private string GetTaskDescriptionByTaskKey(string sTaskKey)
        {
            foreach (clsTask oTask in mp_oParent.ActiveGanttCSWCtl1.Tasks)
            {
                if (oTask.Key == sTaskKey)
                {
                    return mp_oParent.ActiveGanttCSWCtl1.Rows.Item(oTask.RowKey).Node.Text;
                }
            }
            return "";
        }



    }
}