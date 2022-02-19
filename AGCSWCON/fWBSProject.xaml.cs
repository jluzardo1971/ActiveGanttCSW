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
using System.Data.SqlServerCe;
using System.Data;

namespace AGCSWCON
{

    public partial class fWBSProject : Window
    {

        private DateTime mp_dtStartDate;
        private DateTime mp_dtEndDate;
        private const string mp_sFontName = "Tahoma";

        private bool mp_bBluePercentagesVisible = true;
        private bool mp_bGreenPercentagesVisible = true;
        private bool mp_bRedPercentagesVisible = true;

        internal SqlCeConnection mp_oConn;


        #region "Constructors"

        public fWBSProject()
        {
            InitializeComponent();
            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Hidden;
        }

        #endregion

        #region "Form Loaded"

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;

            mp_oConn = new SqlCeConnection(modData.g_GetConnectionString());
            mp_oConn.Open();

            mp_dtStartDate = new DateTime();
            mp_dtEndDate = new DateTime();

            this.Title = "Work Breakdown Structure (WBS) Project Management Example - ";
            this.Title = this.Title + "SQL Server CE 4.0 data source - ";
            this.Title = this.Title + "ActiveGanttCSW Version: " + ActiveGanttCSWCtl1.Version;

            clsStyle oStyle = null;
            clsView oView = null;

            //If you open the form: Styles And Templates -> Available Templates in the main menu (fTemplates.cs)
            //you can preview all available Templates.
            //Or you can also build your own:
            //fMSProject11.cs shows you how to build a Solid Template in the InitializeAG Method.
            //fMSProject14.cs shows you how to build a Gradient Template in the InitializeAG Method.
            ActiveGanttCSWCtl1.ApplyTemplate(E_CONTROLTEMPLATE.STC_CH_VGRAD_ANAKIWA_BLUE, E_OBJECTTEMPLATE.STO_DEFAULT);

            oStyle = ActiveGanttCSWCtl1.Configuration.DefaultPercentageStyle.Clone("InvisiblePercentages");
            oStyle = ActiveGanttCSWCtl1.Styles.Add("SelectedPredecessor");
            oStyle.PredecessorStyle.LineColor = Color.FromArgb(255, 0, 128, 0);

            ActiveGanttCSWCtl1.ControlTag = "WBSProject";
            ActiveGanttCSWCtl1.AllowRowMove = true;
            ActiveGanttCSWCtl1.AllowRowSize = true;
            ActiveGanttCSWCtl1.AddMode = E_ADDMODE.AT_BOTH;
            ActiveGanttCSWCtl1.Configuration.RowHighlightedBackColor = Color.FromArgb(255, 176, 196, 222);

            clsColumn oColumn;

            oColumn = ActiveGanttCSWCtl1.Columns.Add("ID", "", 30, "");
            oColumn.AllowTextEdit = true;

            oColumn = ActiveGanttCSWCtl1.Columns.Add("Task Name", "", 300, "");
            oColumn.AllowTextEdit = true;

            oColumn = ActiveGanttCSWCtl1.Columns.Add("StartDate", "", 125, "");
            oColumn.AllowTextEdit = true;

            oColumn = ActiveGanttCSWCtl1.Columns.Add("EndDate", "", 125, "");
            oColumn.AllowTextEdit = true;

            ActiveGanttCSWCtl1.TreeviewColumnIndex = 2;

            ActiveGanttCSWCtl1.Treeview.Images = true;
            ActiveGanttCSWCtl1.Treeview.CheckBoxes = true;
            ActiveGanttCSWCtl1.Treeview.TreeviewMode = E_TREEVIEWMODE.TM_EXPANDCOLLAPSEICONS;
            ActiveGanttCSWCtl1.Treeview.TreeLines = false;
            ActiveGanttCSWCtl1.Splitter.Position = 255;

            LoadTasks();

            ActiveGanttCSWCtl1.Rows.UpdateTree();

            //// Start one month before the first task:
            ActiveGanttCSWCtl1.TimeLineScrollBar.StartDate = ActiveGanttCSWCtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_MONTH, -1, mp_dtStartDate);
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

            oView = ActiveGanttCSWCtl1.Views.Add(E_INTERVAL.IL_HOUR, 24, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_NOT_VISIBLE, E_TIERTYPE.ST_MONTH);
            oView.TimeLine.TierArea.UpperTier.BackgroundMode = E_TIERBACKGROUNDMODE.ETBGM_STYLE;
            oView.TimeLine.TierArea.UpperTier.Height = 17;
            oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER;
            oView.TimeLine.TierArea.UpperTier.Factor = 1;
            oView.TimeLine.TierArea.LowerTier.BackgroundMode = E_TIERBACKGROUNDMODE.ETBGM_STYLE;
            oView.TimeLine.TierArea.LowerTier.Height = 17;
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.ClientArea.DetectConflicts = false;

            oView = oView.Clone();
            oView.Interval = E_INTERVAL.IL_HOUR;
            oView.Factor = 12;

            oView = oView.Clone();
            oView.Interval = E_INTERVAL.IL_HOUR;
            oView.Factor = 6;

            ActiveGanttCSWCtl1.CurrentView = "2";

            if (ActiveGanttCSWCtl1.Printer != null)
            {
                ActiveGanttCSWCtl1.Printer.Orientation = GRE_ORIENTATION.OT_LANDSCAPE;
                ActiveGanttCSWCtl1.Printer.MarginLeft = 50; //0.5"
                ActiveGanttCSWCtl1.Printer.MarginTop = 50; //0.5"
                ActiveGanttCSWCtl1.Printer.MarginRight = 50; //0.5"
                ActiveGanttCSWCtl1.Printer.MarginBottom = 200; //2.0"
                ActiveGanttCSWCtl1.Printer.HeadingsInEveryPage = true;
                ActiveGanttCSWCtl1.Printer.KeepRowsTogether = true;
                ActiveGanttCSWCtl1.Printer.ColumnsInEveryPage = true;
                ActiveGanttCSWCtl1.Printer.Columns = 1;
                ActiveGanttCSWCtl1.Printer.KeepColumnsTogether = true;
                ActiveGanttCSWCtl1.Printer.KeepTimeIntervalsTogether = true;
                ActiveGanttCSWCtl1.Printer.Interval = E_INTERVAL.IL_MONTH;
                ActiveGanttCSWCtl1.Printer.Factor = 1;
            }

            ActiveGanttCSWCtl1.Redraw();

            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Visible;

        }

        #endregion

        #region "ActiveGantt Event Handlers"

        private void ActiveGanttCSWCtl1_CustomTierDraw(object sender, CustomTierDrawEventArgs e)
        {
            if (e.Interval == E_INTERVAL.IL_QUARTER)
            {
                e.Text = e.StartDate.Year.ToString() + " Q" + ActiveGanttCSWCtl1.MathLib.Quarter(e.StartDate).ToString();
            }
        }

        private void ActiveGanttCSWCtl1_NodeChecked(object sender, NodeEventArgs e)
        {
            clsRow oRow;
            oRow = ActiveGanttCSWCtl1.Rows.Item(e.Index.ToString());
            oRow.Highlighted = oRow.Node.Checked;
        }

        private void ActiveGanttCSWCtl1_ControlMouseDown(object sender, AGCSW.MouseEventArgs e)
        {
            if ((e.EventTarget == E_EVENTTARGET.EVT_TASK | e.EventTarget == E_EVENTTARGET.EVT_SELECTEDTASK) & e.Button == E_MOUSEBUTTONS.BTN_RIGHT)
            {
                fWBSProjectTaskView oForm = new fWBSProjectTaskView(this, ActiveGanttCSWCtl1.MathLib.GetTaskIndexByPosition(e.X, e.Y));
                oForm.ShowDialog();
                oForm.Owner = this;
                e.Cancel = true;
            }
        }

        private void ActiveGanttCSWCtl1_ObjectAdded(object sender, ObjectAddedEventArgs e)
        {
            switch (e.EventTarget)
            {
                case E_EVENTTARGET.EVT_TASK:
                case E_EVENTTARGET.EVT_MILESTONE:
                    clsTask oTask;
                    oTask = GetTaskByRowKey(ActiveGanttCSWCtl1.Tasks.Item(e.TaskIndex.ToString()).RowKey);
                    oTask.StartDate = ActiveGanttCSWCtl1.Tasks.Item(e.TaskIndex.ToString()).StartDate;
                    oTask.EndDate = ActiveGanttCSWCtl1.Tasks.Item(e.TaskIndex.ToString()).EndDate;
                    UpdateTask(oTask.Index);
                    ActiveGanttCSWCtl1.Tasks.Remove(e.TaskIndex.ToString());
                    break;
                case E_EVENTTARGET.EVT_PREDECESSOR:
                    ActiveGanttCSWCtl1.Predecessors.Item(e.PredecessorObjectIndex.ToString()).StyleIndex = "T1";
                    ActiveGanttCSWCtl1.Predecessors.Item(e.PredecessorObjectIndex.ToString()).WarningStyleIndex = "TW1";
                    ActiveGanttCSWCtl1.Predecessors.Item(e.PredecessorObjectIndex.ToString()).SelectedStyleIndex = "SelectedPredecessor";
                    InsertPredecessor(e.PredecessorObjectIndex);
                    break;
            }
        }

        private void ActiveGanttCSWCtl1_CompleteObjectChange(object sender, ObjectStateChangedEventArgs e)
        {
            switch (e.EventTarget)
            {
                case E_EVENTTARGET.EVT_TASK:
                    UpdateTask(e.Index);
                    break;
                case E_EVENTTARGET.EVT_PERCENTAGE:
                    int lTaskIndex = 0;
                    lTaskIndex = ActiveGanttCSWCtl1.Tasks.Item(ActiveGanttCSWCtl1.Percentages.Item(e.Index.ToString()).TaskKey).Index;
                    UpdateTask(lTaskIndex);
                    break;
            }
        }

        private void ActiveGanttCSWCtl1_ToolTipOnMouseHover(object sender, AGCSW.ToolTipEventArgs e)
        {
            switch (e.EventTarget)
            {
                case E_EVENTTARGET.EVT_TASK:
                case E_EVENTTARGET.EVT_SELECTEDTASK:
                case E_EVENTTARGET.EVT_PERCENTAGE:
                    TaskToolTipCalculateDim(e);
                    return;
            }
            ActiveGanttCSWCtl1.ControlToolTip.Visible = false;
        }

        private void ActiveGanttCSWCtl1_OnMouseHoverToolTipDraw(object sender, AGCSW.ToolTipEventArgs e)
        {
            switch (e.EventTarget)
            {
                case E_EVENTTARGET.EVT_TASK:
                case E_EVENTTARGET.EVT_SELECTEDTASK:
                case E_EVENTTARGET.EVT_PERCENTAGE:
                case E_EVENTTARGET.EVT_SELECTEDPERCENTAGE:
                    TaskToolTipDraw(e);
                    e.CustomDraw = true;
                    return;
            }
        }

        private void ActiveGanttCSWCtl1_ToolTipOnMouseMove(object sender, AGCSW.ToolTipEventArgs e)
        {
            switch (e.Operation)
            {
                case E_OPERATION.EO_PERCENTAGESIZING:
                case E_OPERATION.EO_TASKMOVEMENT:
                case E_OPERATION.EO_TASKSTRETCHLEFT:
                case E_OPERATION.EO_TASKSTRETCHRIGHT:
                    TaskToolTipCalculateDim(e);
                    return;
            }
            ActiveGanttCSWCtl1.ControlToolTip.Visible = false;
        }

        private void ActiveGanttCSWCtl1_OnMouseMoveToolTipDraw(object sender, AGCSW.ToolTipEventArgs e)
        {
            switch (e.Operation)
            {
                case E_OPERATION.EO_PERCENTAGESIZING:
                case E_OPERATION.EO_TASKMOVEMENT:
                case E_OPERATION.EO_TASKSTRETCHLEFT:
                case E_OPERATION.EO_TASKSTRETCHRIGHT:
                    TaskToolTipDraw(e);
                    e.CustomDraw = true;
                    return;
            }
        }

        private void ActiveGanttCSWCtl1_ControlMouseWheel(object sender, AGCSW.MouseWheelEventArgs e)
        {
            if ((e.Delta == 0) | (ActiveGanttCSWCtl1.VerticalScrollBar.Visible == false))
            {
                return;
            }
            int lDelta = System.Convert.ToInt32(-(e.Delta / 100));
            int lInitialValue = ActiveGanttCSWCtl1.VerticalScrollBar.Value;
            if ((ActiveGanttCSWCtl1.VerticalScrollBar.Value + lDelta < 1))
            {
                ActiveGanttCSWCtl1.VerticalScrollBar.Value = 1;
            }
            else if ((((ActiveGanttCSWCtl1.VerticalScrollBar.Value + lDelta) > ActiveGanttCSWCtl1.VerticalScrollBar.Max)))
            {
                ActiveGanttCSWCtl1.VerticalScrollBar.Value = ActiveGanttCSWCtl1.VerticalScrollBar.Max;
            }
            else
            {
                ActiveGanttCSWCtl1.VerticalScrollBar.Value = ActiveGanttCSWCtl1.VerticalScrollBar.Value + lDelta;
            }
            ActiveGanttCSWCtl1.Redraw();
        }

        private void ActiveGanttCSWCtl1_EndTextEdit(object sender, TextEditEventArgs e)
        {
            if (e.ObjectType == E_TEXTOBJECTTYPE.TOT_NODE)
            {
                clsRow oRow;
                string sRowKey = null;
                oRow = ActiveGanttCSWCtl1.Rows.Item(e.ObjectIndex.ToString());
                sRowKey = oRow.Key;
                sRowKey = sRowKey.Replace("K", "");
                SqlCeCommand oCmd = null;
                string sSQL = "UPDATE tb_GuysStThomas SET Description='" + e.Text + "' WHERE ID = " + sRowKey;
                oCmd = new SqlCeCommand(sSQL, mp_oConn);
                oCmd.ExecuteNonQuery();
            }
        }

        private void ActiveGanttCSWCtl1_PagePrint(object sender, PagePrintEventArgs e)
        {
            Font oFont = new Font("Arial", 8);


            Color oColor;
            int X2 = 0;
            oColor = ActiveGanttCSWCtl1.Configuration.DefaultControlStyle.BorderColor;
            if ((e.X2 - e.X1) < System.Convert.ToInt32(e.PageWidth * 0.85))
            {
                X2 = System.Convert.ToInt32(e.PageWidth - ActiveGanttCSWCtl1.Printer.MarginRight);
            }
            else
            {
                X2 = e.X2;
            }

            ActiveGanttCSWCtl1.Drawing.DrawLine(e.X1, e.PageHeight - 190, X2, e.PageHeight - 190, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID, 1);
            ActiveGanttCSWCtl1.Drawing.DrawAlignedText(e.X1 + 10, e.PageHeight - 190, e.X1 + 290, e.PageHeight - 70, "ActiveGanttCSW Scheduler Component" + Environment.NewLine + "WBS Project Example", GRE_HORIZONTALALIGNMENT.HAL_LEFT, GRE_VERTICALALIGNMENT.VAL_CENTER, Color.FromArgb(255, 0, 0, 0), oFont);

            int lLine = e.PageHeight - 180;
            ActiveGanttCSWCtl1.Drawing.DrawAlignedText(e.X1 + 310, lLine, e.X1 + 400, lLine + 10, "Red Summary", GRE_HORIZONTALALIGNMENT.HAL_LEFT, GRE_VERTICALALIGNMENT.VAL_CENTER, Color.FromArgb(255, 0, 0, 0), oFont);
            ActiveGanttCSWCtl1.Drawing.DrawObject(e.X1 + 450, lLine, e.X1 + 600, lLine + 10, "S3", "", false, null, GRE_DRAWINGOBJECT.DO_GENERAL);
            ActiveGanttCSWCtl1.Drawing.DrawObject(e.X1 + 450, lLine, e.X1 + 525, lLine + 5, "SP3", "", false, null, GRE_DRAWINGOBJECT.DO_GENERAL);

            lLine = e.PageHeight - 160;
            ActiveGanttCSWCtl1.Drawing.DrawAlignedText(e.X1 + 310, lLine, e.X1 + 400, lLine + 10, "Green Summary", GRE_HORIZONTALALIGNMENT.HAL_LEFT, GRE_VERTICALALIGNMENT.VAL_CENTER, Color.FromArgb(255, 0, 0, 0), oFont);
            ActiveGanttCSWCtl1.Drawing.DrawObject(e.X1 + 450, lLine, e.X1 + 600, lLine + 10, "S2", "", false, null, GRE_DRAWINGOBJECT.DO_GENERAL);
            ActiveGanttCSWCtl1.Drawing.DrawObject(e.X1 + 450, lLine, e.X1 + 525, lLine + 5, "SP2", "", false, null, GRE_DRAWINGOBJECT.DO_GENERAL);

            lLine = e.PageHeight - 140;
            ActiveGanttCSWCtl1.Drawing.DrawAlignedText(e.X1 + 310, lLine, e.X1 + 400, lLine + 10, "Task", GRE_HORIZONTALALIGNMENT.HAL_LEFT, GRE_VERTICALALIGNMENT.VAL_CENTER, Color.FromArgb(255, 0, 0, 0), oFont);
            ActiveGanttCSWCtl1.Drawing.DrawObject(e.X1 + 445, lLine, e.X1 + 605, lLine + 10, "T1", "", false, null, GRE_DRAWINGOBJECT.DO_GENERAL);
            ActiveGanttCSWCtl1.Drawing.DrawObject(e.X1 + 445, lLine + 3, e.X1 + 525, lLine + 7, "P1", "", false, null, GRE_DRAWINGOBJECT.DO_GENERAL);

            lLine = e.PageHeight - 120;
            ActiveGanttCSWCtl1.Drawing.DrawAlignedText(e.X1 + 310, lLine, e.X1 + 400, lLine + 10, "Milestone", GRE_HORIZONTALALIGNMENT.HAL_LEFT, GRE_VERTICALALIGNMENT.VAL_CENTER, Color.FromArgb(255, 0, 0, 0), oFont);
            ActiveGanttCSWCtl1.Drawing.DrawObject(e.X1 + 450, lLine, e.X1 + 450, lLine + 10, "T1", "", false, null, GRE_DRAWINGOBJECT.DO_MILESTONE);

            ActiveGanttCSWCtl1.Drawing.DrawLine(e.X1 + 300, e.PageHeight - 190, e.X1 + 300, e.PageHeight - 70, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID, 1);

            ActiveGanttCSWCtl1.Drawing.DrawLine(e.X1, e.PageHeight - 70, X2, e.PageHeight - 70, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID, 1);
            ActiveGanttCSWCtl1.Drawing.DrawAlignedText(e.X1, e.PageHeight - 70, X2, e.PageHeight - 50, "Page " + e.PageNumber, GRE_HORIZONTALALIGNMENT.HAL_CENTER, GRE_VERTICALALIGNMENT.VAL_CENTER, Color.FromArgb(255, 0, 0, 0), oFont);


            ActiveGanttCSWCtl1.Drawing.DrawBorder(e.X1, e.Y1, X2, e.PageHeight - 50, oColor, GRE_LINEDRAWSTYLE.LDS_SOLID, 1);
        }

        #endregion

        #region "Tooltips"

        private void TaskToolTipCalculateDim(AGCSW.ToolTipEventArgs e)
        {
            int Index = ActiveGanttCSWCtl1.MathLib.GetTaskIndexByPosition(e.X, e.Y);
            clsToolTip oToolTip = ActiveGanttCSWCtl1.ControlToolTip;
            string sRowKey = null;
            if (Index == -1)
            {
                sRowKey = ActiveGanttCSWCtl1.Rows.Item(ActiveGanttCSWCtl1.MathLib.GetRowIndexByPosition(e.Y).ToString()).Key;
            }
            else
            {
                sRowKey = ActiveGanttCSWCtl1.Tasks.Item(Index.ToString()).RowKey;
            }
            string sRowText = ActiveGanttCSWCtl1.Rows.Item(sRowKey).Text;
            Typeface oTypeFace = new Typeface(ActiveGanttCSWCtl1.ControlToolTip.Font.FamilyName);
            FormattedText oFormattedText = new FormattedText(sRowText, ActiveGanttCSWCtl1.Culture, FlowDirection.LeftToRight, oTypeFace, ActiveGanttCSWCtl1.ControlToolTip.Font.WPFFontSize, new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)));
            oFormattedText.MaxTextWidth = 275;
            oToolTip.AutomaticSizing = false;
            oToolTip.Left = e.X + 20;
            oToolTip.Top = e.Y - (System.Convert.ToInt32(oFormattedText.Height) + 60) - 20;
            oToolTip.Width = 300;
            oToolTip.Height = System.Convert.ToInt32(oFormattedText.Height) + 60;
            if (ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Width < oToolTip.Width)
            {
                oToolTip.Visible = false;
                return;
            }
            if (ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Height < oToolTip.Height)
            {
                oToolTip.Visible = false;
                return;
            }
            if (oToolTip.Left < ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Left)
            {
                oToolTip.Left = ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Left;
            }
            if (oToolTip.Top < ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Top)
            {
                oToolTip.Top = ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Top;
            }
            if (ActiveGanttCSWCtl1.ControlToolTip.Left + ActiveGanttCSWCtl1.ControlToolTip.Width > ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Right)
            {
                ActiveGanttCSWCtl1.ControlToolTip.Left = ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Right - oToolTip.Width;
            }
            if (oToolTip.Top + oToolTip.Height > ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Bottom)
            {
                oToolTip.Top = ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Bottom - oToolTip.Height;
            }
            oToolTip.Visible = true;
        }

        private void TaskToolTipDraw(AGCSW.ToolTipEventArgs e)
        {
            int Index = 0;
            string sRowKey = null;
            string sTaskKey = null;
            DateTime dtStartDate;
            DateTime dtEndDate;
            float fPercentage = 0;
            clsPercentage oPercentage = null;
            clsTask oTask;
            if (e.ToolTipType == E_TOOLTIPTYPE.TPT_HOVER)
            {
                Index = ActiveGanttCSWCtl1.MathLib.GetTaskIndexByPosition(e.X, e.Y);
                if (Index < 1)
                {
                    return;
                }
                oTask = ActiveGanttCSWCtl1.Tasks.Item(Index.ToString());
                sRowKey = oTask.RowKey;
                dtStartDate = oTask.StartDate;
                dtEndDate = oTask.EndDate;
                sTaskKey = oTask.Key;
                oPercentage = GetPercentageByTaskKey(sTaskKey);
                if ((oPercentage != null))
                {
                    fPercentage = GetPercentageByTaskKey(sTaskKey).Percent * 100;
                }
            }
            else
            {
                Index = e.TaskIndex;
                if (e.Operation == E_OPERATION.EO_TASKMOVEMENT)
                {
                    sRowKey = ActiveGanttCSWCtl1.Rows.Item(e.InitialRowIndex.ToString()).Key;
                }
                else
                {
                    sRowKey = ActiveGanttCSWCtl1.Rows.Item(e.RowIndex.ToString()).Key;
                }
                dtStartDate = e.StartDate;
                dtEndDate = e.EndDate;
                sTaskKey = ActiveGanttCSWCtl1.Tasks.Item(Index.ToString()).Key;
                if (e.Operation == E_OPERATION.EO_PERCENTAGESIZING)
                {
                    fPercentage = (e.X - e.XStart) / (e.XEnd - e.XStart) * 100;
                }
                else
                {
                    if ((oPercentage != null))
                    {
                        fPercentage = oPercentage.Percent * 100;
                    }
                }
            }
            string sStartDate = dtStartDate.ToString("ddd MMM d, yyyy");
            string sEndDate = dtEndDate.ToString("ddd MMM d, yyyy");
            string sFrom = "From: " + sStartDate + " To " + sEndDate;
            string sDuration = "Duration: " + ActiveGanttCSWCtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_DAY, dtStartDate, dtEndDate) + " days";
            string sRowText = ActiveGanttCSWCtl1.Rows.Item(sRowKey).Text;
            string sPercentage = fPercentage.ToString("00.00");

            Image oImage = new Image();
            oImage.Source = ActiveGanttCSWCtl1.Rows.Item(sRowKey).Node.Image.Source;
            oImage.SetValue(Canvas.LeftProperty, (double)3);
            oImage.SetValue(Canvas.TopProperty, (double)3);
            e.Graphics.Children.Add(oImage);

            Typeface oTypeFace = new Typeface(ActiveGanttCSWCtl1.ControlToolTip.Font.FamilyName);
            FormattedText oFormattedText = new FormattedText(sRowText, ActiveGanttCSWCtl1.Culture, FlowDirection.LeftToRight, oTypeFace, ActiveGanttCSWCtl1.ControlToolTip.Font.WPFFontSize, new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)));
            oFormattedText.MaxTextWidth = 275;

            TextBlock oTitle = new TextBlock();
            oTitle.Text = sRowText;
            oTitle.FontFamily = ActiveGanttCSWCtl1.ControlToolTip.Font.GetFontFamily();
            oTitle.FontSize = ActiveGanttCSWCtl1.ControlToolTip.Font.WPFFontSize;
            oTitle.SetValue(Canvas.LeftProperty, (double)25);
            oTitle.SetValue(Canvas.TopProperty, (double)2);
            oTitle.Width = 275;
            oTitle.TextWrapping = TextWrapping.Wrap;
            oTitle.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            e.Graphics.Children.Add(oTitle);

            Line oLine = new Line();
            oLine.X1 = 0;
            oLine.Y1 = oFormattedText.Height + 10;
            oLine.X2 = 300;
            oLine.Y2 = oFormattedText.Height + 10;
            oLine.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            oLine.StrokeThickness = 2;
            e.Graphics.Children.Add(oLine);

            TextBlock oDuration = new TextBlock();
            oDuration.Text = sDuration;
            oDuration.FontFamily = ActiveGanttCSWCtl1.ControlToolTip.Font.GetFontFamily();
            oDuration.FontSize = ActiveGanttCSWCtl1.ControlToolTip.Font.WPFFontSize;
            oDuration.SetValue(Canvas.LeftProperty, (double)2);
            oDuration.SetValue(Canvas.TopProperty, (double)oFormattedText.Height + 15);
            oDuration.Width = 300;
            oDuration.TextWrapping = TextWrapping.Wrap;
            oDuration.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            e.Graphics.Children.Add(oDuration);

            TextBlock oInterval = new TextBlock();
            oInterval.Text = sFrom;
            oInterval.FontFamily = ActiveGanttCSWCtl1.ControlToolTip.Font.GetFontFamily();
            oInterval.FontSize = ActiveGanttCSWCtl1.ControlToolTip.Font.WPFFontSize;
            oInterval.SetValue(Canvas.LeftProperty, (double)2);
            oInterval.SetValue(Canvas.TopProperty, (double)(oFormattedText.Height + 15) + 15);
            oInterval.Width = 300;
            oInterval.TextWrapping = TextWrapping.Wrap;
            oInterval.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            e.Graphics.Children.Add(oInterval);

            TextBlock oCompleted = new TextBlock();
            oCompleted.Text = "Percent Completed: " + sPercentage + "%";
            oCompleted.FontFamily = ActiveGanttCSWCtl1.ControlToolTip.Font.GetFontFamily();
            oCompleted.FontSize = ActiveGanttCSWCtl1.ControlToolTip.Font.WPFFontSize;
            oCompleted.SetValue(Canvas.LeftProperty, (double)2);
            oCompleted.SetValue(Canvas.TopProperty, (double)(oFormattedText.Height + 15) + 30);
            oCompleted.Width = 300;
            oCompleted.TextWrapping = TextWrapping.Wrap;
            oCompleted.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            e.Graphics.Children.Add(oCompleted);
        }

        #endregion

        #region "Form Properties"

        #endregion

        #region "Functions"

        private void UpdateTask(int Index)
        {
            AGCSW.clsPercentage oPercentage = GetPercentageByTaskKey(ActiveGanttCSWCtl1.Tasks.Item(Index.ToString()).Key);
            clsTask oTask;
            oTask = ActiveGanttCSWCtl1.Tasks.Item(Index.ToString());
            SetTaskGridColumns(oTask);
            string sRowKey = oTask.RowKey;
            DateTime dtStartDate = oTask.StartDate;
            DateTime dtEndDate = oTask.EndDate;
            clsNode oNode = ActiveGanttCSWCtl1.Rows.Item(sRowKey).Node;
            SqlCeCommand oCmd = null;
            string sSQL = "UPDATE tb_GuysStThomas SET " + "dtStartDate = " + modData.g_ConvertDate(dtStartDate) + ", dtEndDate = " + modData.g_ConvertDate(dtEndDate) + ", fPercentCompleted = " + oPercentage.Percent + " WHERE lTaskID = " + sRowKey.Replace("K", "");
            oCmd = new SqlCeCommand(sSQL, mp_oConn);
            oCmd.ExecuteNonQuery();
            UpdateSummary(ref oNode);
        }

        private void InsertPredecessor(int PredecessorObjectIndex)
        {
            clsPredecessor oPredecessor;
            string sPredecessorTaskKey = null;
            string sSuccessorTaskKey = null;
            oPredecessor = ActiveGanttCSWCtl1.Predecessors.Item(PredecessorObjectIndex.ToString());
            sPredecessorTaskKey = oPredecessor.PredecessorTask.Key.Replace("T", "");
            sSuccessorTaskKey = oPredecessor.SuccessorTask.Key.Replace("T", "");
            SqlCeCommand oCmd = null;
            string sSQL = "INSERT INTO tb_GuysStThomas_Predecessors (lPredecessorTaskID, lSuccessorTaskID, lType, lLagFactor, lLagInterval) VALUES (" + sPredecessorTaskKey + "," + sSuccessorTaskKey + "," + System.Convert.ToInt32(oPredecessor.PredecessorType).ToString() + "," + oPredecessor.LagFactor.ToString() + "," + System.Convert.ToInt32(oPredecessor.LagInterval).ToString() + ")";
            oCmd = new SqlCeCommand(sSQL, mp_oConn);
            oCmd.ExecuteNonQuery();
        }

        private void UpdateSummary(ref clsNode oNode)
        {
            SqlCeCommand oCmd = null;
            string sSQL = "";
            clsNode oParentNode = null;
            clsTask oSummaryTask = null;
            clsPercentage oSummaryPercentage = null;
            oParentNode = oNode.Parent();
            while ((oParentNode != null))
            {
                oSummaryTask = GetTaskByRowKey(oParentNode.Row.Key);
                oSummaryPercentage = GetPercentageByTaskKey(oSummaryTask.Key);
                if ((oSummaryTask != null))
                {
                    clsTask oChildTask = null;
                    clsPercentage oChildPercentage = null;
                    clsNode oChildNode = null;
                    DateTime dtSumStartDate = new DateTime();
                    DateTime dtSumEndDate = new DateTime();
                    int lPercentagesCount = 0;
                    float fPercentagesSum = 0;
                    float fPercentageAvg = 0;
                    oChildNode = oParentNode.Child();
                    while ((oChildNode != null))
                    {
                        oChildTask = GetTaskByRowKey(oChildNode.Row.Key);
                        oChildPercentage = GetPercentageByTaskKey(oChildTask.Key);
                        lPercentagesCount = lPercentagesCount + 1;
                        fPercentagesSum = fPercentagesSum + oChildPercentage.Percent;
                        if ((oChildTask != null))
                        {
                            if (dtSumStartDate.Ticks == 0)
                            {
                                dtSumStartDate = oChildTask.StartDate;
                            }
                            else
                            {
                                if (oChildTask.StartDate < dtSumStartDate)
                                {
                                    dtSumStartDate = oChildTask.StartDate;
                                }
                            }
                            if (dtSumEndDate.Ticks == 0)
                            {
                                dtSumEndDate = oChildTask.EndDate;
                            }
                            else
                            {
                                if (oChildTask.EndDate > dtSumEndDate)
                                {
                                    dtSumEndDate = oChildTask.EndDate;
                                }
                            }
                        }
                        oChildNode = oChildNode.NextSibling();
                    }
                    fPercentageAvg = fPercentagesSum / lPercentagesCount;
                    oSummaryTask.StartDate = dtSumStartDate;
                    oSummaryTask.EndDate = dtSumEndDate;
                    SetTaskGridColumns(oSummaryTask);
                    oSummaryPercentage.Percent = fPercentageAvg;
                    sSQL = "UPDATE tb_GuysStThomas SET " + "dtStartDate = " + modData.g_ConvertDate(dtSumStartDate) + ", dtEndDate = " + modData.g_ConvertDate(dtSumEndDate) + ", fPercentCompleted = " + oSummaryPercentage.Percent + " WHERE lTaskID = " + oSummaryTask.RowKey.Replace("K", "");
                    oCmd = new SqlCeCommand(sSQL, mp_oConn);
                    oCmd.ExecuteNonQuery();
                }
                oParentNode = oParentNode.Parent();
            }
        }

        private clsTask GetTaskByRowKey(string sRowKey)
        {
            foreach (clsTask oTask in ActiveGanttCSWCtl1.Tasks)
            {
                if (oTask.RowKey == sRowKey)
                {
                    return oTask;
                }
            }
            return null;
        }

        private clsPercentage GetPercentageByTaskKey(string sTaskKey)
        {
            foreach (clsPercentage oPercentage in ActiveGanttCSWCtl1.Percentages)
            {
                if (oPercentage.TaskKey == sTaskKey)
                {
                    return oPercentage;
                }
            }
            return null;
        }

        private Image GetImage(int ImageIndex)
        {
            GifBitmapDecoder oDecoder = new GifBitmapDecoder(GetURI(ImageIndex), BitmapCreateOptions.None, BitmapCacheOption.None);
            BitmapSource oBitmap = oDecoder.Frames[0];
            Image oReturn = new Image();
            oReturn.Source = oBitmap;
            return oReturn;
        }

        private Uri GetURI(int ImageIndex)
        {
            Uri oURI = null;
            switch (ImageIndex)
            {
                case 0:
                    oURI = new Uri("../Images/WBS/folderclosed.gif", UriKind.RelativeOrAbsolute);
                    break;
                case 1:
                    oURI = new Uri("../Images/WBS/folderopen.gif", UriKind.RelativeOrAbsolute);
                    break;
                case 2:
                    oURI = new Uri("../Images/WBS/modules.gif", UriKind.RelativeOrAbsolute);
                    break;
                case 3:
                    oURI = new Uri("../Images/WBS/task.gif", UriKind.RelativeOrAbsolute);
                    break;
            }
            return oURI;
        }

        #endregion

        #region "Toolbar Buttons"

        private void cmdLoadXML_Click(object sender, RoutedEventArgs e)
        {
            LoadXML();
        }

        private void cmdSaveXML_Click(object sender, RoutedEventArgs e)
        {
            SaveXML();
        }

        private void cmdPrint_Click(object sender, RoutedEventArgs e)
        {
            Print();
        }

        private void cmdZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (System.Convert.ToInt32(ActiveGanttCSWCtl1.CurrentView) < 3)
            {
                ActiveGanttCSWCtl1.CurrentView = System.Convert.ToString(System.Convert.ToInt32(ActiveGanttCSWCtl1.CurrentView) + 1);
                ActiveGanttCSWCtl1.Redraw();
            }
        }

        private void cmdZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (System.Convert.ToInt32(ActiveGanttCSWCtl1.CurrentView) > 1)
            {
                ActiveGanttCSWCtl1.CurrentView = System.Convert.ToString(System.Convert.ToInt32(ActiveGanttCSWCtl1.CurrentView) - 1);
                ActiveGanttCSWCtl1.Redraw();
            }
        }

        private void cmdBluePercentages_Click(object sender, RoutedEventArgs e)
        {
            mp_bBluePercentagesVisible = !mp_bBluePercentagesVisible;
            foreach (clsPercentage oPercentage in ActiveGanttCSWCtl1.Percentages)
            {
                if (oPercentage.StyleIndex == "P1")
                {
                    oPercentage.Visible = mp_bBluePercentagesVisible;
                }
            }
            ActiveGanttCSWCtl1.Redraw();
        }

        private void cmdGreenPercentages_Click(object sender, RoutedEventArgs e)
        {
            mp_bGreenPercentagesVisible = !mp_bGreenPercentagesVisible;
            foreach (clsPercentage oPercentage in ActiveGanttCSWCtl1.Percentages)
            {
                if (oPercentage.StyleIndex == "SP2")
                {
                    oPercentage.Visible = mp_bGreenPercentagesVisible;
                }
            }
            ActiveGanttCSWCtl1.Redraw();
        }

        private void cmdRedPercentages_Click(object sender, RoutedEventArgs e)
        {
            mp_bRedPercentagesVisible = !mp_bRedPercentagesVisible;
            foreach (clsPercentage oPercentage in ActiveGanttCSWCtl1.Percentages)
            {
                if (oPercentage.StyleIndex == "SP3")
                {
                    oPercentage.Visible = mp_bRedPercentagesVisible;
                }
            }
            ActiveGanttCSWCtl1.Redraw();
        }

        private void cmdProperties_Click(object sender, RoutedEventArgs e)
        {
            fWBSPProperties oForm = new fWBSPProperties(this);
            oForm.Owner = this;
            oForm.ShowDialog();
        }

        private void cmdCheck_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSWCtl1.CheckPredecessors();
            ActiveGanttCSWCtl1.Redraw();
        }

        private void cmdTooltip_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.ToolTipsVisible = !ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.ToolTipsVisible;
            ActiveGanttCSWCtl1.Redraw();
        }

        private void cmdHelp_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            System.Diagnostics.Process.Start("http://www.sourcecodestore.com/Article.aspx?ID=17");
            this.Cursor = Cursors.Arrow;
        }

        #endregion

        #region "Menu Items"

        private void mnuSaveXML_Click(object sender, RoutedEventArgs e)
        {
            SaveXML();
        }

        private void mnuLoadXML_Click(object sender, RoutedEventArgs e)
        {
            LoadXML();
        }

        private void mnuPrint_Click(object sender, RoutedEventArgs e)
        {
            Print();
        }

        private void mnuClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mnuCheckBoxes_Click(object sender, RoutedEventArgs e)
        {
            mnuCheckBoxes.IsChecked = !(!mnuCheckBoxes.IsChecked);
            ActiveGanttCSWCtl1.Treeview.CheckBoxes = mnuCheckBoxes.IsChecked;
            ActiveGanttCSWCtl1.Redraw();
        }

        private void mnuImages_Click(object sender, RoutedEventArgs e)
        {
            mnuImages.IsChecked = !(!mnuImages.IsChecked);
            ActiveGanttCSWCtl1.Treeview.Images = mnuImages.IsChecked;
            ActiveGanttCSWCtl1.Redraw();
        }

        private void mnuFullColumnSelect_Click(object sender, RoutedEventArgs e)
        {
            mnuFullColumnSelect.IsChecked = !(!mnuFullColumnSelect.IsChecked);
            ActiveGanttCSWCtl1.Treeview.FullColumnSelect = mnuFullColumnSelect.IsChecked;
            ActiveGanttCSWCtl1.Redraw();
        }

        #endregion

        #region "Toolbar Button & Menu Item Functions"

        private void Print()
        {
            if (ActiveGanttCSWCtl1.Printer != null)
            {
                fPrintDialog oForm = new fPrintDialog(ActiveGanttCSWCtl1, new DateTime(2006, 8, 1, 0, 0, 0), new DateTime(2010, 1, 1, 0, 0, 0));
                oForm.Owner = this;
                oForm.ShowDialog();
            }
        }

        private void SaveXML()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "AGCSW_WBSP";
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (.xml)|*.xml";
            if (dlg.ShowDialog() == true)
            {
                ActiveGanttCSWCtl1.WriteXML(dlg.FileName);
            }
        }

        private void LoadXML()
        {
            fLoadXML oForm = new fLoadXML();
            oForm.ShowDialog();
        }

        #endregion

        #region "Load Data"

        public void LoadTasks()
        {
            clsRow oRow = null;
            clsTask oTask = null;
            using (SqlCeConnection oConn = new SqlCeConnection(modData.g_GetConnectionString()))
            {
                SqlCeCommand oCmd = null;
                SqlCeDataReader oReader = null;
                oConn.Open();
                oCmd = new SqlCeCommand("SELECT * FROM tb_GuysStThomas", oConn);
                oReader = oCmd.ExecuteReader();
                while (oReader.Read() == true)
                {
                    oRow = ActiveGanttCSWCtl1.Rows.Add("K" + oReader["lTaskID"].ToString(), oReader["sDescription"].ToString());
                    oRow.Cells.Item("1").Text = Convert.ToString(oReader["lTaskID"]);
                    oRow.Cells.Item("1").StyleIndex = "CH";
                    oRow.Height = 20;
                    oRow.Node.AllowTextEdit = true;
                    if (oReader["sTaskType"].ToString() == "F")
                    {
                        if ((System.Int32)oReader["lDepth"] == 0)
                        {
                            oRow.Node.Image = GetImage(0);
                            oRow.Node.ExpandedImage = GetImage(1);
                            oRow.Node.StyleIndex = "NB";
                        }
                        else
                        {
                            oRow.Node.Image = GetImage(2);
                            oRow.Node.StyleIndex = "NR";
                        }
                    }
                    else if (oReader["sTaskType"].ToString() == "A")
                    {
                        oRow.Node.StyleIndex = "NR";
                        oRow.Node.Image = GetImage(3);
                        oRow.Node.CheckBoxVisible = true;
                    }
                    oRow.Node.Depth = (System.Int32)oReader["lDepth"];
                    oRow.Node.ImageVisible = true;
                    oRow.Node.AllowTextEdit = true;
                    if ((!Convert.IsDBNull(oReader["dtStartDate"]) & !Convert.IsDBNull(oReader["dtEndDate"])))
                    {
                        if ((mp_dtStartDate.Ticks == 0))
                        {
                            mp_dtStartDate = Globals.FromDate((System.DateTime)oReader["dtStartDate"]);
                        }
                        else
                        {
                            if ((Globals.FromDate((System.DateTime)oReader["dtStartDate"]) < mp_dtStartDate))
                            {
                                mp_dtStartDate = Globals.FromDate((System.DateTime)oReader["dtStartDate"]);
                            }
                        }
                        if ((mp_dtEndDate.Ticks == 0))
                        {
                            mp_dtEndDate = Globals.FromDate((System.DateTime)oReader["dtEndDate"]);
                        }
                        else
                        {
                            if ((Globals.FromDate((System.DateTime)oReader["dtEndDate"]) > mp_dtEndDate))
                            {
                                mp_dtEndDate = Globals.FromDate((System.DateTime)oReader["dtEndDate"]);
                            }
                        }
                        oTask = ActiveGanttCSWCtl1.Tasks.Add("", "K" + oReader["lTaskID"].ToString(), Globals.FromDate((System.DateTime)oReader["dtStartDate"]), Globals.FromDate((System.DateTime)oReader["dtEndDate"]), "T" + oReader["lTaskID"].ToString(), "", "");
                        SetTaskGridColumns(oTask);
                        if ((System.Boolean)oReader["bSummary"] == true)
                        {
                            //// Prevent user from moving/sizing summary tasks
                            oTask.AllowedMovement = E_MOVEMENTTYPE.MT_MOVEMENTDISABLED;
                            oTask.AllowStretchLeft = false;
                            oTask.AllowStretchRight = false;
                            //// Prevent user from adding tasks in these Rows
                            oRow.Container = false;
                            //// Apply Summary Style 
                            if (oRow.Node.Depth == 0)
                            {
                                oTask.StyleIndex = "S3";
                                ActiveGanttCSWCtl1.Percentages.Add("T" + oReader["lTaskID"].ToString(), "SP3", (System.Single)oReader["fPercentCompleted"], "");
                            }
                            else if (oRow.Node.Depth == 1)
                            {
                                oTask.StyleIndex = "S2";
                                ActiveGanttCSWCtl1.Percentages.Add("T" + oReader["lTaskID"].ToString(), "SP2", (System.Single)oReader["fPercentCompleted"], "");
                            }
                            ActiveGanttCSWCtl1.Percentages.Item(ActiveGanttCSWCtl1.Percentages.Count.ToString()).AllowSize = false;
                        }
                        else
                        {
                            oTask.AllowedMovement = E_MOVEMENTTYPE.MT_RESTRICTEDTOROW;
                            oTask.StyleIndex = "T1";
                            oTask.WarningStyleIndex = "TW1";
                            if ((System.Boolean)oReader["bHasTasks"] == false)
                            {
                                oTask.Visible = false;
                                //// Prevent user from adding tasks in these rows
                                oRow.Container = false;
                                ActiveGanttCSWCtl1.Percentages.Add("T" + oReader["lTaskID"].ToString(), "InvisiblePercentages", (System.Single)oReader["fPercentCompleted"], "");
                                ActiveGanttCSWCtl1.Percentages.Item(ActiveGanttCSWCtl1.Percentages.Count.ToString()).AllowSize = false;
                            }
                            else
                            {
                                ActiveGanttCSWCtl1.Percentages.Add("T" + oReader["lTaskID"].ToString(), "P1", (System.Single)oReader["fPercentCompleted"], "");
                            }
                        }
                    }
                }
                oReader.Close();
                oCmd = new SqlCeCommand("SELECT * FROM tb_GuysStThomas_Predecessors", oConn);
                oReader = oCmd.ExecuteReader();
                while (oReader.Read())
                {
                    clsPredecessor oPredecessor;
                    oPredecessor = ActiveGanttCSWCtl1.Predecessors.Add("T" + oReader["lSuccessorTaskID"].ToString(), "T" + oReader["lPredecessorTaskID"].ToString(), (E_CONSTRAINTTYPE)oReader["lType"], "", "T1");
                    oPredecessor.LagFactor = (int)oReader["lLagFactor"];
                    oPredecessor.LagInterval = (E_INTERVAL)oReader["lLagInterval"];
                    oPredecessor.WarningStyleIndex = "TW1";
                    oPredecessor.SelectedStyleIndex = "SelectedPredecessor";
                }
                oConn.Close();
            }
        }

        public void AddPredecessor(int lPredecessorID, int lSuccessorID, E_CONSTRAINTTYPE yType, int lLagFactor, E_INTERVAL yLagInterval)
        {
            clsPredecessor oPredecessor;
            oPredecessor = ActiveGanttCSWCtl1.Predecessors.Add("T" + lSuccessorID.ToString(), "T" + lPredecessorID.ToString(), yType, "", "T1");
            oPredecessor.WarningStyleIndex = "TW1";
            oPredecessor.SelectedStyleIndex = "SelectedPredecessor";
            oPredecessor.LagFactor = lLagFactor;
            oPredecessor.LagInterval = yLagInterval;
        }

        private void SetTaskGridColumns(clsTask oTask)
        {
            oTask.Row.Cells.Item("3").Text = oTask.StartDate.ToString("MM/dd/yyyy");
            oTask.Row.Cells.Item("4").Text = oTask.EndDate.ToString("MM/dd/yyyy");
        }

        #endregion


    }
}