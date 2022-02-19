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
    /// Interaction logic for fSTL_MSP2003.xaml
    /// </summary>
    public partial class fSTL_MSP2003 : Window
    {

        private const string mp_sFontName = "Tahoma";

        public fSTL_MSP2003()
        {
            InitializeComponent();
            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;


            clsStyle oStyle = null;
            clsView oView = null;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("TimeLineTiers");
            oStyle.Font = new Font(mp_sFontName, 7, FontWeights.Regular);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_RAISED;
            oStyle.BorderColor = Color.FromArgb(255, 169, 169, 169);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("TaskStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Color.FromArgb(255, 0, 0, 255);
            oStyle.BorderColor = Color.FromArgb(255, 0, 0, 255);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.TextPlacement = E_TEXTPLACEMENT.SCP_EXTERIORPLACEMENT;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.TextXMargin = 10;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 10;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_HATCH;
            oStyle.HatchBackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.HatchForeColor = Color.FromArgb(255, 0, 0, 255);
            oStyle.HatchStyle = GRE_HATCHSTYLE.HS_PERCENT50;
            oStyle.PredecessorStyle.LineColor = Color.FromArgb(255, 0, 0, 0);
            oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND;
            oStyle.MilestoneStyle.FillColor = Color.FromArgb(255, 0, 0, 255);
            oStyle.MilestoneStyle.BorderColor = Color.FromArgb(255, 0, 0, 255);
            oStyle.PredecessorStyle.XOffset = 4;
            oStyle.PredecessorStyle.YOffset = 4;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("SummaryStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.BorderColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TextPlacement = E_TEXTPLACEMENT.SCP_EXTERIORPLACEMENT;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.TextXMargin = 10;
            oStyle.TaskStyle.StartShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.EndShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.EndFillColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.TaskStyle.EndBorderColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.TaskStyle.StartFillColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.TaskStyle.StartBorderColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.FillMode = GRE_FILLMODE.FM_UPPERHALFFILLED;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("CellStyleKeyColumn");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderColor = Color.FromArgb(255, 128, 128, 128);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.TextXMargin = 4;


            clsColumn oColumn;

            oColumn = ActiveGanttCSWCtl1.Columns.Add("ID", "", 30, "");

            oColumn = ActiveGanttCSWCtl1.Columns.Add("Task Name", "", 300, "");

            ActiveGanttCSWCtl1.TreeviewColumnIndex = 2;

            ActiveGanttCSWCtl1.Splitter.Position = 285;
            ActiveGanttCSWCtl1.Treeview.Images = true;
            ActiveGanttCSWCtl1.Treeview.CheckBoxes = true;
            ActiveGanttCSWCtl1.Treeview.TreeLines = false;

            ActiveGanttCSWCtl1.Treeview.Images = true;
            ActiveGanttCSWCtl1.Treeview.CheckBoxes = true;

            int i = 0;
            clsRow oRow;
            for (i = 1; i <= 100; i++)
            {
                oRow = ActiveGanttCSWCtl1.Rows.Add("K" + i.ToString());
                oRow.MergeCells = false;
                oRow.Node.Text = "Row: " + i.ToString();
                oRow.Cells.Item("1").Text = i.ToString();
                oRow.Cells.Item("1").StyleIndex = "CellStyleKeyColumn";
                oRow.Height = 20;
                if (oRow.Index % 5 == 0 | oRow.Index == 1)
                {
                    oRow.Node.Depth = 0;
                }
                else
                {
                    oRow.Node.CheckBoxVisible = true;
                    oRow.Node.Depth = 1;
                }
            }

            ActiveGanttCSWCtl1.Rows.UpdateTree();

            ActiveGanttCSWCtl1.TimeLineScrollBar.StartDate = new DateTime(2013, 1, 1);
            ActiveGanttCSWCtl1.TimeLineScrollBar.Interval = E_INTERVAL.IL_HOUR;
            ActiveGanttCSWCtl1.TimeLineScrollBar.Factor = 1;
            ActiveGanttCSWCtl1.TimeLineScrollBar.SmallChange = 6;
            ActiveGanttCSWCtl1.TimeLineScrollBar.LargeChange = 480;
            ActiveGanttCSWCtl1.TimeLineScrollBar.Max = 4000;
            ActiveGanttCSWCtl1.TimeLineScrollBar.Value = 0;
            ActiveGanttCSWCtl1.TimeLineScrollBar.Enabled = true;
            ActiveGanttCSWCtl1.TimeLineScrollBar.Visible = true;


            ActiveGanttCSWCtl1.TierFormat.QuarterIntervalFormat = "yyyy Q\\Q";
            ActiveGanttCSWCtl1.TierFormat.MonthIntervalFormat = "MMM";

            oView = ActiveGanttCSWCtl1.Views.Add(E_INTERVAL.IL_HOUR, 24, E_TIERTYPE.ST_QUARTER, E_TIERTYPE.ST_NOT_VISIBLE, E_TIERTYPE.ST_MONTH);
            oView.TimeLine.TierArea.UpperTier.BackgroundMode = E_TIERBACKGROUNDMODE.ETBGM_STYLE;
            oView.TimeLine.TierArea.UpperTier.StyleIndex = "TimeLineTiers";
            oView.TimeLine.TierArea.LowerTier.BackgroundMode = E_TIERBACKGROUNDMODE.ETBGM_STYLE;
            oView.TimeLine.TierArea.LowerTier.StyleIndex = "TimeLineTiers";
            oView.TimeLine.TickMarkArea.Visible = false;

            ActiveGanttCSWCtl1.CurrentView = "1";

            ActiveGanttCSWCtl1.Tasks.Add("", "K1", new DateTime(2013, 3, 1), new DateTime(2014, 3, 1), "SS", "SummaryStyle");

            ActiveGanttCSWCtl1.Tasks.Add("", "K5", new DateTime(2013, 3, 1), new DateTime(2014, 3, 1), "TS", "TaskStyle");

            ActiveGanttCSWCtl1.Redraw();

            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Visible;

        }

    }
}