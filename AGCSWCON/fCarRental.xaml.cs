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


    public partial class fCarRental : Window
    {

        private HPE_ADDMODE mp_yAddMode = HPE_ADDMODE.AM_RENTAL;
        private int mp_lZoom;
        private string mp_sEditRowKey;
        private string mp_sEditTaskKey;

        private const string mp_sFontName = "Tahoma";

        private clsCR_Objects mp_oObjects;

        #region "Constructors"

        public fCarRental()
        {
            InitializeComponent();
            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Hidden;
        }

        #endregion

        #region "Form Loaded"

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;

            mp_oObjects = new clsCR_Objects(ActiveGanttCSWCtl1);

            this.Title = "Vehicle Rental/Fleet Control Roster Example - ";
            this.Title = this.Title + "SQL Server CE 4.0 data source - ";
            this.Title = this.Title + "ActiveGanttCSW Version: " + ActiveGanttCSWCtl1.Version;

            clsStyle oStyle = null;
            clsView oView = null;
            clsTimeBlock oTimeBlock = null;

            ////If you open the form: Styles And Templates -> Available Templates in the main menu (fTemplates.cs)
            ////you can preview all available Templates.
            ////Or you can also build your own:
            ////fMSProject11.cs shows you how to build a Solid Template in the InitializeAG Method.
            ////fMSProject14.cs shows you how to build a Gradient Template in the InitializeAG Method.
            ActiveGanttCSWCtl1.ApplyTemplate(E_CONTROLTEMPLATE.STC_CH_HGRAD_BLUE_BELL, E_OBJECTTEMPLATE.STO_VARIATION_1);

            oStyle = ActiveGanttCSWCtl1.Styles.Item("RET1");
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_LEFT;
            oStyle.TextAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_TOP;

            oStyle = ActiveGanttCSWCtl1.Styles.Item("RET2");
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_LEFT;
            oStyle.TextAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_TOP;

            oStyle = ActiveGanttCSWCtl1.Styles.Item("RET3");
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_LEFT;
            oStyle.TextAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_TOP;



            oStyle = ActiveGanttCSWCtl1.Configuration.DefaultColumnStyle.Clone("Branch");
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_LEFT;
            oStyle.TextAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_TOP;
            oStyle.TextXMargin = 5;
            oStyle.TextYMargin = 5;
            oStyle.BorderColor = Color.FromArgb(255, 0, 0, 0);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.ImageAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.ImageAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_BOTTOM;
            oStyle.ImageXMargin = 5;
            oStyle.ImageYMargin = 5;

            oStyle = ActiveGanttCSWCtl1.Configuration.DefaultColumnStyle.Clone("BranchCA");

            oStyle = ActiveGanttCSWCtl1.Styles.Add("SplitterStyle");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 109, 122, 136);
            oStyle.EndGradientColor = Color.FromArgb(255, 220, 220, 220);

            ActiveGanttCSWCtl1.ControlTag = "CarRental";
            ActiveGanttCSWCtl1.Columns.Add("", "", 60, "");
            ActiveGanttCSWCtl1.Columns.Add("", "", 95, "");
            ActiveGanttCSWCtl1.Columns.Add("", "", 250, "");

            ActiveGanttCSWCtl1.Splitter.Position = 380;
            ActiveGanttCSWCtl1.Splitter.Type = E_SPLITTERTYPE.SA_STYLE;
            ActiveGanttCSWCtl1.Splitter.Width = 6;
            ActiveGanttCSWCtl1.Splitter.StyleIndex = "SplitterStyle";

            ActiveGanttCSWCtl1.Culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            ActiveGanttCSWCtl1.Culture.DateTimeFormat.AMDesignator = ActiveGanttCSWCtl1.Culture.DateTimeFormat.AMDesignator.ToLower();
            ActiveGanttCSWCtl1.Culture.DateTimeFormat.PMDesignator = ActiveGanttCSWCtl1.Culture.DateTimeFormat.PMDesignator.ToLower();

            oTimeBlock = ActiveGanttCSWCtl1.TimeBlocks.Add("");
            oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING;
            oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_WEEK;
            oTimeBlock.BaseWeekDay = E_WEEKDAY.WD_FRIDAY;
            oTimeBlock.BaseDate = new DateTime(2013, 1, 1, 0, 0, 0);
            oTimeBlock.DurationFactor = 48;
            oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR;

            oView = ActiveGanttCSWCtl1.Views.Add(E_INTERVAL.IL_MINUTE, 30, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM);
            oView.TimeLine.TierArea.UpperTier.Height = 17;
            oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_MONTH;
            oView.TimeLine.TierArea.UpperTier.Factor = 1;
            oView.TimeLine.TierArea.MiddleTier.Height = 17;
            oView.TimeLine.TierArea.MiddleTier.Interval = E_INTERVAL.IL_DAY;
            oView.TimeLine.TierArea.MiddleTier.Factor = 1;
            oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_HOUR;
            oView.TimeLine.TierArea.LowerTier.Factor = 12;
            oView.TimeLine.TierArea.LowerTier.Height = 17;
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.ClientArea.Grid.VerticalLines = true;
            oView.ClientArea.Grid.SnapToGrid = true;
            ActiveGanttCSWCtl1.CurrentView = oView.Index.ToString();
            Zoom = 5;

            //// Load Data
            mp_oObjects.LoadData();

            ActiveGanttCSWCtl1.Rows.UpdateTree();

            drpMode.Items.Add("Add Reservation Mode");
            drpMode.Items.Add("Add Rental Mode");
            drpMode.Items.Add("Add Maintenance Mode");
            drpMode.SelectedIndex = 0;

            if (ActiveGanttCSWCtl1.Printer != null)
            {
                ActiveGanttCSWCtl1.Printer.Orientation = GRE_ORIENTATION.OT_LANDSCAPE;
                ActiveGanttCSWCtl1.Printer.MarginLeft = 50; //0.5"
                ActiveGanttCSWCtl1.Printer.MarginTop = 50; //0.5"
                ActiveGanttCSWCtl1.Printer.MarginRight = 50; //0.5"
                ActiveGanttCSWCtl1.Printer.MarginBottom = 50; //0.5"
                ActiveGanttCSWCtl1.Printer.HeadingsInEveryPage = false;
                ActiveGanttCSWCtl1.Printer.KeepRowsTogether = true;
                ActiveGanttCSWCtl1.Printer.ColumnsInEveryPage = false;
                ActiveGanttCSWCtl1.Printer.KeepColumnsTogether = true;
                ActiveGanttCSWCtl1.Printer.KeepTimeIntervalsTogether = false;
            }

            ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.Position(new DateTime(2009, 6, 9));

            ActiveGanttCSWCtl1.Redraw();


            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Visible;
        }

        #endregion

        #region "ActiveGantt Event Handlers"

        private void ActiveGanttCSWCtl1_CustomTierDraw(object sender, CustomTierDrawEventArgs e)
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

        private void ActiveGanttCSWCtl1_ObjectAdded(object sender, ObjectAddedEventArgs e)
        {
            switch (e.EventTarget)
            {
                case E_EVENTTARGET.EVT_TASK:
                    string sTaskKey = mp_oObjects.Tasks.Add(e.TaskIndex, Mode);
                    if (Mode == HPE_ADDMODE.AM_RESERVATION | Mode == HPE_ADDMODE.AM_RENTAL)
                    {
                        fCarRentalReservation oForm = new fCarRentalReservation(PRG_DIALOGMODE.DM_ADD, this, sTaskKey);
                        oForm.Owner = this;
                        oForm.ShowDialog();
                    }
                    else if (Mode == HPE_ADDMODE.AM_MAINTENANCE)
                    {
                        mp_oObjects.Tasks.Item(sTaskKey).UpdateCaption();
                    }
                    break;
            }
        }

        private void ActiveGanttCSWCtl1_CompleteObjectChange(object sender, ObjectStateChangedEventArgs e)
        {
            switch (e.EventTarget)
            {
                case E_EVENTTARGET.EVT_TASK:
                    string sTaskKey = ActiveGanttCSWCtl1.Tasks.Item(e.Index.ToString()).Key;
                    mp_oObjects.Tasks.Item(sTaskKey).TaskChanged();
                    break;
                case E_EVENTTARGET.EVT_ROW:
                    if (e.ChangeType == E_CHANGETYPE.CT_MOVE)
                    {
                        mp_oObjects.Rows.UpdateOrder();
                    }
                    break;
            }
        }

        private void ActiveGanttCSWCtl1_ControlMouseDown(object sender, AGCSW.MouseEventArgs e)
        {
            switch (e.EventTarget)
            {
                case E_EVENTTARGET.EVT_SELECTEDROW:
                case E_EVENTTARGET.EVT_ROW:
                    if (e.Button == E_MOUSEBUTTONS.BTN_LEFT)
                    {
                        clsRow oRow = null;
                        oRow = ActiveGanttCSWCtl1.Rows.Item(ActiveGanttCSWCtl1.MathLib.GetRowIndexByPosition(e.Y).ToString());
                        if (e.X > ActiveGanttCSWCtl1.Splitter.Position - 20 & e.X < ActiveGanttCSWCtl1.Splitter.Position - 5 & e.Y < oRow.Bottom - 5 & e.Y > oRow.Bottom - 20)
                        {
                            oRow.Node.Expanded = !oRow.Node.Expanded;
                            ActiveGanttCSWCtl1.Redraw();
                            e.Cancel = true;
                        }
                    }
                    else if (e.Button == E_MOUSEBUTTONS.BTN_RIGHT)
                    {
                        e.Cancel = true;
                        mp_sEditRowKey = ActiveGanttCSWCtl1.Rows.Item(ActiveGanttCSWCtl1.MathLib.GetRowIndexByPosition(e.Y).ToString()).Key;
                        MainGrid.ContextMenu = (ContextMenu)MainGrid.Resources["mnuRowEdit"];
                        MainGrid.ContextMenu.PlacementTarget = MainGrid;
                        MainGrid.ContextMenu.IsOpen = true;
                    }
                    break;
                case E_EVENTTARGET.EVT_SELECTEDTASK:
                case E_EVENTTARGET.EVT_TASK:
                    if (e.Button == E_MOUSEBUTTONS.BTN_RIGHT)
                    {
                        e.Cancel = true;
                        mp_sEditTaskKey = ActiveGanttCSWCtl1.Tasks.Item(ActiveGanttCSWCtl1.MathLib.GetTaskIndexByPosition(e.X, e.Y).ToString()).Key;
                        clsCR_Task oTask = mp_oObjects.Tasks.Item(mp_sEditTaskKey);
                        MainGrid.ContextMenu = (ContextMenu)MainGrid.Resources["mnuTaskEdit"];
                        MenuItem mnuEditTask = (MenuItem)MainGrid.ContextMenu.Items[0];
                        MenuItem mnuConvertToRental = (MenuItem)MainGrid.ContextMenu.Items[1];
                        if (oTask.lMode == HPE_ADDMODE.AM_RESERVATION)
                        {
                            mnuConvertToRental.Visibility = System.Windows.Visibility.Visible;
                        }
                        else
                        {
                            mnuConvertToRental.Visibility = System.Windows.Visibility.Collapsed;
                        }
                        if (oTask.lMode == HPE_ADDMODE.AM_RENTAL)
                        {
                            mnuEditTask.Visibility = System.Windows.Visibility.Collapsed;
                        }
                        else
                        {
                            mnuEditTask.Visibility = System.Windows.Visibility.Visible;
                        }
                    }
                    break;
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

        #endregion

        #region "Form Properties"

        public clsCR_Objects Objects
        {
            get { return mp_oObjects; }
        }

        public HPE_ADDMODE Mode
        {
            get
            {
                mp_yAddMode = (HPE_ADDMODE)drpMode.SelectedIndex;
                return mp_yAddMode;
            }
        }

        public string AddModeStyle
        {
            get
            {
                switch (drpMode.SelectedIndex)
                {
                    case 0:
                        return "RET2";
                    case 1:
                        return "RET1";
                    case 2:
                        return "RET3";
                }
                return "Error";
            }
        }

        private int Zoom
        {
            get { return mp_lZoom; }
            set
            {
                if (value > 5 | value < 1)
                {
                    return;
                }
                mp_lZoom = value;
                clsView oView = null;
                oView = ActiveGanttCSWCtl1.CurrentViewObject;
                switch (mp_lZoom)
                {
                    case 5:
                        oView.Interval = E_INTERVAL.IL_MINUTE;
                        oView.Factor = 30;
                        oView.ClientArea.Grid.Interval = E_INTERVAL.IL_HOUR;
                        oView.ClientArea.Grid.Factor = 12;
                        oView.TimeLine.TickMarkArea.Visible = false;
                        break;
                    case 4:
                        oView.Interval = E_INTERVAL.IL_MINUTE;
                        oView.Factor = 15;
                        oView.ClientArea.Grid.Interval = E_INTERVAL.IL_HOUR;
                        oView.ClientArea.Grid.Factor = 6;
                        oView.TimeLine.TickMarkArea.Visible = false;
                        break;
                    case 3:
                        oView.Interval = E_INTERVAL.IL_MINUTE;
                        oView.Factor = 10;
                        oView.ClientArea.Grid.Interval = E_INTERVAL.IL_HOUR;
                        oView.ClientArea.Grid.Factor = 3;
                        oView.TimeLine.TickMarkArea.Visible = false;
                        break;
                    case 2:
                        oView.Interval = E_INTERVAL.IL_MINUTE;
                        oView.Factor = 5;
                        oView.ClientArea.Grid.Interval = E_INTERVAL.IL_HOUR;
                        oView.ClientArea.Grid.Factor = 2;
                        oView.TimeLine.TickMarkArea.Visible = true;
                        oView.TimeLine.TickMarkArea.Height = 30;
                        oView.TimeLine.TickMarkArea.TickMarks.Clear();
                        oView.TimeLine.TickMarkArea.TickMarks.Add(E_INTERVAL.IL_HOUR, 6, E_TICKMARKTYPES.TLT_BIG, true, "hh:mmtt");
                        oView.TimeLine.TickMarkArea.TickMarks.Add(E_INTERVAL.IL_HOUR, 1, E_TICKMARKTYPES.TLT_SMALL, false, "h");
                        break;
                    case 1:
                        oView.Interval = E_INTERVAL.IL_MINUTE;
                        oView.Factor = 1;
                        oView.ClientArea.Grid.Interval = E_INTERVAL.IL_MINUTE;
                        oView.ClientArea.Grid.Factor = 15;
                        oView.TimeLine.TickMarkArea.Visible = true;
                        oView.TimeLine.TickMarkArea.Height = 30;
                        oView.TimeLine.TickMarkArea.TickMarks.Clear();
                        oView.TimeLine.TickMarkArea.TickMarks.Add(E_INTERVAL.IL_HOUR, 1, E_TICKMARKTYPES.TLT_BIG, true, "hh:mmtt");
                        break;
                }
                ActiveGanttCSWCtl1.Redraw();
            }
        }

        #endregion

        #region "Functions"

        #endregion

        #region "Toolbar Buttons"

        private void cmdSaveXML_Click(object sender, RoutedEventArgs e)
        {
            SaveXML();
        }

        private void cmdLoadXML_Click(object sender, RoutedEventArgs e)
        {
            LoadXML();
        }

        private void cmdPrint_Click(object sender, RoutedEventArgs e)
        {
            Print();
        }

        private void cmdZoomIn_Click(object sender, RoutedEventArgs e)
        {
            Zoom = Zoom - 1;
        }

        private void cmdZoomOut_Click(object sender, RoutedEventArgs e)
        {
            Zoom = Zoom + 1;
        }

        private void cmdAddVehicle_Click(object sender, RoutedEventArgs e)
        {
            fCarRentalVehicle oForm = new fCarRentalVehicle(PRG_DIALOGMODE.DM_ADD, this, null);
            oForm.Owner = this;
            oForm.ShowDialog();
        }

        private void cmdAddBranch_Click(object sender, RoutedEventArgs e)
        {
            fCarRentalBranch oForm = new fCarRentalBranch(PRG_DIALOGMODE.DM_ADD, this, null);
            oForm.Owner = this;
            oForm.ShowDialog();
        }

        private void cmdBack2_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.Position(ActiveGanttCSWCtl1.MathLib.DateTimeAdd(ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Grid.Interval, -10 * ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Grid.Factor, ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.StartDate));
            ActiveGanttCSWCtl1.Redraw();
        }

        private void cmdBack1_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.Position(ActiveGanttCSWCtl1.MathLib.DateTimeAdd(ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Grid.Interval, -5 * ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Grid.Factor, ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.StartDate));
            ActiveGanttCSWCtl1.Redraw();
        }

        private void cmdBack0_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.Position(ActiveGanttCSWCtl1.MathLib.DateTimeAdd(ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Grid.Interval, -1 * ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Grid.Factor, ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.StartDate));
            ActiveGanttCSWCtl1.Redraw();
        }

        private void cmdFwd0_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.Position(ActiveGanttCSWCtl1.MathLib.DateTimeAdd(ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Grid.Interval, 1 * ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Grid.Factor, ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.StartDate));
            ActiveGanttCSWCtl1.Redraw();
        }

        private void cmdFwd1_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.Position(ActiveGanttCSWCtl1.MathLib.DateTimeAdd(ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Grid.Interval, 5 * ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Grid.Factor, ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.StartDate));
            ActiveGanttCSWCtl1.Redraw();
        }

        private void cmdFwd2_Click(object sender, RoutedEventArgs e)
        {
            ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.Position(ActiveGanttCSWCtl1.MathLib.DateTimeAdd(ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Grid.Interval, 10 * ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.Grid.Factor, ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.StartDate));
            ActiveGanttCSWCtl1.Redraw();
        }

        private void cmdHelp_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            System.Diagnostics.Process.Start("http://www.sourcecodestore.com/Article.aspx?ID=16");
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

        private void mnuEditRow_Click(object sender, RoutedEventArgs e)
        {
            clsRow oRow;
            oRow = ActiveGanttCSWCtl1.Rows.Item(mp_sEditRowKey);
            if (oRow.Node.Depth == 1)
            {
                fCarRentalVehicle oForm = new fCarRentalVehicle(PRG_DIALOGMODE.DM_EDIT, this, mp_sEditRowKey);
                oForm.Owner = this;
                oForm.ShowDialog();
            }
            else if (oRow.Node.Depth == 0)
            {
                fCarRentalBranch oForm = new fCarRentalBranch(PRG_DIALOGMODE.DM_EDIT, this, mp_sEditRowKey);
                oForm.Owner = this;
                oForm.ShowDialog();
            }
        }

        private void mnuDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this item?", "Delete Row", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                mp_oObjects.Rows.Delete(mp_sEditRowKey);
                ActiveGanttCSWCtl1.Redraw();
            }
        }

        private void mnuEditTask_Click(object sender, RoutedEventArgs e)
        {
            fCarRentalReservation oForm = new fCarRentalReservation(PRG_DIALOGMODE.DM_EDIT, this, mp_sEditTaskKey);
            oForm.Owner = this;
            oForm.ShowDialog();
        }

        private void mnuConvertToRental_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this item?", "Delete Task", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                mp_oObjects.Tasks.Delete(mp_sEditTaskKey);
                ActiveGanttCSWCtl1.Redraw();
            }
        }

        private void mnuDeleteTask_Click(object sender, RoutedEventArgs e)
        {
            clsCR_Task oTask = mp_oObjects.Tasks.Item(mp_sEditTaskKey);
            oTask.lMode = HPE_ADDMODE.AM_RENTAL;
            oTask.Update();
            oTask.UpdateCaption();
            ActiveGanttCSWCtl1.Redraw();
        }

        #endregion

        #region "Toolbar Button & Menu Item Functions"

        private void SaveXML()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "AGCSW_CR";
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (.xml)|*.xml";
            if (dlg.ShowDialog() == true)
            {
                ActiveGanttCSWCtl1.WriteXML(dlg.FileName);
            }
        }

        private void Print()
        {
            if (ActiveGanttCSWCtl1.Printer != null)
            {
                fPrintDialog oForm = new fPrintDialog(ActiveGanttCSWCtl1, new DateTime(2009, 6, 1, 0, 0, 0), new DateTime(2009, 6, 30, 0, 0, 0));
                oForm.Owner = this;
                oForm.ShowDialog();
            }
        }

        private void LoadXML()
        {
            fLoadXML oForm = new fLoadXML();
            oForm.ShowDialog();
        }

        #endregion

    }
}