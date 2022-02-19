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
    /// Interaction logic for fSTL_Anakiwa_Blue.xaml
    /// </summary>
    public partial class fSTL_Anakiwa_Blue : Window
    {

        private const string mp_sFontName = "Tahoma";

        public fSTL_Anakiwa_Blue()
        {
            InitializeComponent();
            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;

            clsStyle oStyle = null;
            clsView oView = null;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("ControlStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.BorderColor = Color.FromArgb(255, 100, 145, 204);
            oStyle.BackColor = Color.FromArgb(255, 240, 240, 240);

            oStyle = ActiveGanttCSWCtl1.Styles.Add("ScrollBar");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 150, 150, 150);

            oStyle = ActiveGanttCSWCtl1.Styles.Add("ArrowButtons");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 150, 150, 150);

            oStyle = ActiveGanttCSWCtl1.Styles.Add("ThumbButtonH");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 240, 240, 240);
            oStyle.EndGradientColor = Color.FromArgb(255, 165, 186, 207);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 138, 145, 153);

            oStyle = ActiveGanttCSWCtl1.Styles.Add("ThumbButtonV");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 240, 240, 240);
            oStyle.EndGradientColor = Color.FromArgb(255, 165, 186, 207);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 138, 145, 153);

            oStyle = ActiveGanttCSWCtl1.Styles.Add("ThumbButtonHP");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 165, 186, 207);
            oStyle.EndGradientColor = Color.FromArgb(255, 240, 240, 240);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 138, 145, 153);

            oStyle = ActiveGanttCSWCtl1.Styles.Add("ThumbButtonVP");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 165, 186, 207);
            oStyle.EndGradientColor = Color.FromArgb(255, 240, 240, 240);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 138, 145, 153);

            oStyle = ActiveGanttCSWCtl1.Styles.Add("ColumnStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.StartGradientColor = Color.FromArgb(255, 179, 206, 235);
            oStyle.EndGradientColor = Color.FromArgb(255, 161, 193, 232);
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Right = true;
            oStyle.CustomBorderStyle.Bottom = true;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.BorderColor = Color.FromArgb(255, 100, 145, 204);

            oStyle = ActiveGanttCSWCtl1.Styles.Add("ScrollBarSeparatorStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = Color.FromArgb(255, 150, 150, 150);

            oStyle = ActiveGanttCSWCtl1.Styles.Add("TimeLineTiers");
            oStyle.Font = new Font(mp_sFontName, 7, FontWeights.Regular);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_TRANSPARENT;
            oStyle.CustomBorderStyle.Left = true;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Right = false;
            oStyle.CustomBorderStyle.Bottom = true;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.BorderColor = Color.FromArgb(255, 197, 206, 216);

            oStyle = ActiveGanttCSWCtl1.Styles.Add("TimeLine");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.StartGradientColor = Color.FromArgb(255, 179, 206, 235);
            oStyle.EndGradientColor = Color.FromArgb(255, 161, 193, 232);
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_NONE;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("NodeRegular");
            oStyle.Font = new Font(mp_sFontName, 8, FontWeights.Regular);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("NodeBold");
            oStyle.Font = new Font(mp_sFontName, 8, FontWeights.Bold);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("NormalTask");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Color.FromArgb(255, 100, 145, 204);
            oStyle.BorderColor = Color.FromArgb(255, 0, 0, 255);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 10;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.StartGradientColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.EndGradientColor = Color.FromArgb(255, 100, 145, 204);
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.PredecessorStyle.LineColor = Color.FromArgb(255, 100, 145, 204);
            oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("GreenSummary");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.BorderColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 10;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.StartGradientColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.EndGradientColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND;
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TaskStyle.EndFillColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.TaskStyle.EndBorderColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.TaskStyle.StartFillColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.TaskStyle.StartBorderColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.TaskStyle.StartShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.EndShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.FillMode = GRE_FILLMODE.FM_UPPERHALFFILLED;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("RedSummary");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Color.FromArgb(255, 255, 0, 0);
            oStyle.BorderColor = Color.FromArgb(255, 255, 0, 0);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 10;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.StartGradientColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.EndGradientColor = Color.FromArgb(255, 255, 0, 0);
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND;
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TaskStyle.EndFillColor = Color.FromArgb(255, 255, 0, 0);
            oStyle.TaskStyle.EndBorderColor = Color.FromArgb(255, 255, 0, 0);
            oStyle.TaskStyle.StartFillColor = Color.FromArgb(255, 255, 0, 0);
            oStyle.TaskStyle.StartBorderColor = Color.FromArgb(255, 255, 0, 0);
            oStyle.TaskStyle.StartShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.EndShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.FillMode = GRE_FILLMODE.FM_UPPERHALFFILLED;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("BluePercentages");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Color.FromArgb(255, 0, 0, 255);
            oStyle.BorderColor = Color.FromArgb(255, 0, 0, 255);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.OffsetTop = 8;
            oStyle.OffsetBottom = 4;
            oStyle.SelectionRectangleStyle.Visible = true;
            oStyle.TextVisible = false;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("GreenPercentages");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.BorderColor = Color.FromArgb(255, 0, 128, 0);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 5;
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TextVisible = false;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("RedPercentages");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BackColor = Color.FromArgb(255, 255, 0, 0);
            oStyle.BorderColor = Color.FromArgb(255, 255, 0, 0);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 5;
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TextVisible = false;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("ClientAreaStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.CustomBorderStyle.Right = false;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("CellStyleKeyColumn");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.TextXMargin = 4;

            oStyle = ActiveGanttCSWCtl1.Styles.Add("CellStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;


            ActiveGanttCSWCtl1.StyleIndex = "ControlStyle";
            ActiveGanttCSWCtl1.ScrollBarSeparator.StyleIndex = "ScrollBarSeparatorStyle";

            clsColumn oColumn;

            oColumn = ActiveGanttCSWCtl1.Columns.Add("ID", "", 30, "");
            oColumn.StyleIndex = "ColumnStyle";

            oColumn = ActiveGanttCSWCtl1.Columns.Add("Task Name", "", 300, "");
            oColumn.StyleIndex = "ColumnStyle";

            oColumn = ActiveGanttCSWCtl1.Columns.Add("StartDate", "", 125, "");
            oColumn.StyleIndex = "ColumnStyle";

            oColumn = ActiveGanttCSWCtl1.Columns.Add("EndDate", "", 125, "");
            oColumn.StyleIndex = "ColumnStyle";

            ActiveGanttCSWCtl1.TreeviewColumnIndex = 2;

            ActiveGanttCSWCtl1.Treeview.Images = true;
            ActiveGanttCSWCtl1.Treeview.CheckBoxes = true;
            ActiveGanttCSWCtl1.Treeview.PlusMinusBorderColor = Color.FromArgb(255, 100, 145, 204);
            ActiveGanttCSWCtl1.Treeview.PlusMinusSignColor = Color.FromArgb(255, 100, 145, 204);
            ActiveGanttCSWCtl1.Treeview.CheckBoxBorderColor = Color.FromArgb(255, 100, 145, 204);
            ActiveGanttCSWCtl1.Treeview.TreeLineColor = Color.FromArgb(255, 100, 145, 204);

            ActiveGanttCSWCtl1.Splitter.Type = E_SPLITTERTYPE.SA_USERDEFINED;
            ActiveGanttCSWCtl1.Splitter.Width = 1;
            ActiveGanttCSWCtl1.Splitter.SetColor(1, Color.FromArgb(255, 100, 145, 204));
            ActiveGanttCSWCtl1.Splitter.Position = 255;

            ActiveGanttCSWCtl1.VerticalScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            ActiveGanttCSWCtl1.VerticalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            ActiveGanttCSWCtl1.VerticalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            ActiveGanttCSWCtl1.VerticalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            ActiveGanttCSWCtl1.VerticalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonV";
            ActiveGanttCSWCtl1.VerticalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonVP";
            ActiveGanttCSWCtl1.VerticalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonV";

            ActiveGanttCSWCtl1.HorizontalScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            ActiveGanttCSWCtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            ActiveGanttCSWCtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            ActiveGanttCSWCtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            ActiveGanttCSWCtl1.HorizontalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonH";
            ActiveGanttCSWCtl1.HorizontalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonHP";
            ActiveGanttCSWCtl1.HorizontalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH";

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
                    oRow.Node.StyleIndex = "NodeBold";
                    oRow.Node.Depth = 0;
                }
                else
                {
                    oRow.Node.StyleIndex = "NodeRegular";
                    oRow.Node.CheckBoxVisible = true;
                    oRow.Node.Depth = 1;
                }
                oRow.ClientAreaStyleIndex = "ClientAreaStyle";
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
            ActiveGanttCSWCtl1.TimeLineScrollBar.ScrollBar.StyleIndex = "ScrollBar";
            ActiveGanttCSWCtl1.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons";
            ActiveGanttCSWCtl1.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons";
            ActiveGanttCSWCtl1.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons";
            ActiveGanttCSWCtl1.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonH";
            ActiveGanttCSWCtl1.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonHP";
            ActiveGanttCSWCtl1.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH";

            ActiveGanttCSWCtl1.TierFormat.QuarterIntervalFormat = "yyyy Q\\Q";
            ActiveGanttCSWCtl1.TierFormat.MonthIntervalFormat = "MMM";

            oView = ActiveGanttCSWCtl1.Views.Add(E_INTERVAL.IL_HOUR, 24, E_TIERTYPE.ST_QUARTER, E_TIERTYPE.ST_NOT_VISIBLE, E_TIERTYPE.ST_MONTH);
            oView.TimeLine.TierArea.UpperTier.BackgroundMode = E_TIERBACKGROUNDMODE.ETBGM_STYLE;
            oView.TimeLine.TierArea.UpperTier.StyleIndex = "TimeLineTiers";
            oView.TimeLine.TierArea.UpperTier.Height = 17;
            oView.TimeLine.TierArea.LowerTier.BackgroundMode = E_TIERBACKGROUNDMODE.ETBGM_STYLE;
            oView.TimeLine.TierArea.LowerTier.StyleIndex = "TimeLineTiers";
            oView.TimeLine.TierArea.LowerTier.Height = 17;
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.TimeLine.StyleIndex = "TimeLine";

            ActiveGanttCSWCtl1.CurrentView = "1";

            ActiveGanttCSWCtl1.Tasks.Add("", "K1", new DateTime(2013, 3, 1), new DateTime(2014, 3, 1), "RS", "RedSummary");
            ActiveGanttCSWCtl1.Percentages.Add("RS", "RedPercentages", 0.5F);

            ActiveGanttCSWCtl1.Tasks.Add("", "K5", new DateTime(2013, 3, 1), new DateTime(2014, 3, 1), "GS", "GreenSummary");
            ActiveGanttCSWCtl1.Percentages.Add("GS", "GreenPercentages", 0.5F);

            ActiveGanttCSWCtl1.Tasks.Add("", "K11", new DateTime(2013, 3, 1), new DateTime(2014, 3, 1), "NT", "NormalTask");
            ActiveGanttCSWCtl1.Percentages.Add("NT", "BluePercentages", 0.5F);

            ActiveGanttCSWCtl1.Redraw();

            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Visible;
        }

    }
}