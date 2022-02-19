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

    public partial class fMSProject11 : Window
    {

        private MSP2003.MP11 oMP11;
        private const string mp_sFontName = "Tahoma";
        private DateTime mp_dtStartDate;
        private DateTime mp_dtEndDate;

        #region "Constructors"

        public fMSProject11()
        {
            InitializeComponent();
            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Hidden;
        }

        #endregion

        #region "Form Loaded"

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;

            this.Title = "The Source Code Store - ActiveGantt Scheduler Control Version " + ActiveGanttCSWCtl1.Version + " - Microsoft Project 2003 integration using XML Files and the MSP2003 Integration Library";

            InitializeAG();
            ActiveGanttCSWCtl1.Redraw();

            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Visible;
        }

        #endregion

        #region "Functions"

        private void InitializeAG()
        {
            mp_dtStartDate = new DateTime();
            mp_dtEndDate = new DateTime();


            clsStyle oStyle = null;
            clsView oView = null;

            ControlTemplateSolid oTemplate = new ControlTemplateSolid();
            oTemplate.ControlBorderColor = Color.FromArgb(255, 120, 120, 120);
            oTemplate.HeadingBorderColor = Color.FromArgb(255, 255, 255, 255);
            oTemplate.HeadingForeColor = Color.FromArgb(255, 255, 255, 255);
            oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
            oTemplate.HeadingBackColor = Color.FromArgb(255, 111, 120, 156);
            oTemplate.TreeviewColor = Color.FromArgb(255, 0, 0, 0);
            oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);
            oTemplate.TimeBlockBackColor = Color.FromArgb(255, 115, 119, 135);

            ActiveGanttCSWCtl1.ApplyTemplateSolid(oTemplate, E_OBJECTTEMPLATE.STO_COLOR_HATCH);

            oStyle = ActiveGanttCSWCtl1.Styles.Item("T1");
            oStyle.TextPlacement = E_TEXTPLACEMENT.SCP_EXTERIORPLACEMENT;
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.TextXMargin = 30;

            ActiveGanttCSWCtl1.AllowRowMove = true;
            ActiveGanttCSWCtl1.AllowRowSize = true;
            ActiveGanttCSWCtl1.AddMode = E_ADDMODE.AT_BOTH;
            ActiveGanttCSWCtl1.Splitter.Position = 285;
            ActiveGanttCSWCtl1.Treeview.Images = true;
            ActiveGanttCSWCtl1.Treeview.CheckBoxes = true;
            ActiveGanttCSWCtl1.Treeview.TreeLines = false;
            ActiveGanttCSWCtl1.VerticalScrollBar.ScrollBar.TimerInterval = 50;

            clsColumn oColumn;

            oColumn = ActiveGanttCSWCtl1.Columns.Add("ID", "", 30, "");
            oColumn.AllowTextEdit = true;

            oColumn = ActiveGanttCSWCtl1.Columns.Add("Task Name", "", 255, "");
            oColumn.AllowTextEdit = true;

            ActiveGanttCSWCtl1.TreeviewColumnIndex = 2;

            oView = ActiveGanttCSWCtl1.CurrentViewObject.Clone();
            oView.Interval = E_INTERVAL.IL_HOUR;
            oView.Factor = 12;
            oView.TimeLine.TierArea.UpperTier.TierType = E_TIERTYPE.ST_CUSTOM;
            oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER;
            oView.TimeLine.TierArea.UpperTier.Factor = 1;
            oView.TimeLine.TierArea.UpperTier.Height = 17;
            oView.TimeLine.TierArea.MiddleTier.TierType = E_TIERTYPE.ST_NOT_VISIBLE;
            oView.TimeLine.TierArea.LowerTier.TierType = E_TIERTYPE.ST_CUSTOM;
            oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH;
            oView.TimeLine.TierArea.LowerTier.Factor = 1;
            oView.TimeLine.TierArea.LowerTier.Height = 17;
            oView.TimeLine.TickMarkArea.Visible = false;
            oView.TimeLine.TimeLineScrollBar.StartDate = DateTime.Now;
            oView.TimeLine.TimeLineScrollBar.Interval = E_INTERVAL.IL_HOUR;
            oView.TimeLine.TimeLineScrollBar.Factor = 1;
            oView.TimeLine.TimeLineScrollBar.SmallChange = 48;
            oView.TimeLine.TimeLineScrollBar.LargeChange = 2880;
            oView.TimeLine.TimeLineScrollBar.Max = 24000;
            oView.TimeLine.TimeLineScrollBar.Value = 0;
            oView.TimeLine.TimeLineScrollBar.Enabled = true;
            oView.TimeLine.TimeLineScrollBar.Visible = true;
            oView.ClientArea.DetectConflicts = false;
            oView.ClientArea.Grid.Color = Color.FromArgb(255, 197, 206, 216);


            oView = oView.Clone();
            oView.Interval = E_INTERVAL.IL_HOUR;
            oView.Factor = 12;

            oView = oView.Clone();
            oView.Interval = E_INTERVAL.IL_HOUR;
            oView.Factor = 6;

            oView = oView.Clone();
            oView.Interval = E_INTERVAL.IL_HOUR;
            oView.Factor = 3;

            oView = oView.Clone();
            oView.Interval = E_INTERVAL.IL_HOUR;
            oView.Factor = 1;

            if (ActiveGanttCSWCtl1.Printer != null)
            {
                ActiveGanttCSWCtl1.Printer.Orientation = GRE_ORIENTATION.OT_LANDSCAPE;
                ActiveGanttCSWCtl1.Printer.MarginLeft = 50;
                //0.5"
                ActiveGanttCSWCtl1.Printer.MarginTop = 50;
                //0.5"
                ActiveGanttCSWCtl1.Printer.MarginRight = 50;
                //0.5"
                ActiveGanttCSWCtl1.Printer.MarginBottom = 50;
                //0.5"
                ActiveGanttCSWCtl1.Printer.HeadingsInEveryPage = true;
                ActiveGanttCSWCtl1.Printer.KeepRowsTogether = true;
                ActiveGanttCSWCtl1.Printer.ColumnsInEveryPage = true;
                ActiveGanttCSWCtl1.Printer.Columns = 1;
                ActiveGanttCSWCtl1.Printer.KeepColumnsTogether = true;
                ActiveGanttCSWCtl1.Printer.KeepTimeIntervalsTogether = true;
                ActiveGanttCSWCtl1.Printer.Interval = E_INTERVAL.IL_DAY;
                ActiveGanttCSWCtl1.Printer.Factor = 1;
            }

            ActiveGanttCSWCtl1.TimeLineScrollBarScope = E_OBJECTSCOPE.OS_VIEW;

            ActiveGanttCSWCtl1.CurrentView = "1";

        }

        private void AGSetStartDate(DateTime dtStart)
        {
            foreach (clsView oView in ActiveGanttCSWCtl1.Views)
            {
                oView.TimeLine.TimeLineScrollBar.StartDate = dtStart;
            }
        }

        private void MP11_To_AG()
        {
            clsTask oAGTask;
            clsRow oAGRow;
            mp_dtStartDate = new DateTime();
            mp_dtEndDate = new DateTime();
            //// Load Project Tasks
            foreach (MSP2003.Task oMPTask in oMP11.oTasks)
            {
                oAGRow = ActiveGanttCSWCtl1.Rows.Add("K" + oMPTask.lUID.ToString());
                oAGRow.Cells.Item("1").Text = oMPTask.lUID.ToString();
                oAGRow.Cells.Item("1").StyleIndex = "CH";
                oAGRow.Height = 20;
                oAGTask = ActiveGanttCSWCtl1.Tasks.Add("", "K" + oMPTask.lUID.ToString(), Globals.FromDate(oMPTask.dtStart), Globals.FromDate(oMPTask.dtFinish), "", "", "");
                oAGTask.Key = "K" + oMPTask.lUID.ToString();
                oAGTask.AllowedMovement = E_MOVEMENTTYPE.MT_RESTRICTEDTOROW;
                oAGTask.AllowTextEdit = true;
                if (Globals.FromDate(oMPTask.dtStart) < mp_dtStartDate | (mp_dtStartDate.Ticks == 0))
                {
                    mp_dtStartDate = Globals.FromDate(oMPTask.dtStart);
                }
                if (Globals.FromDate(oMPTask.dtFinish) > mp_dtEndDate | (mp_dtEndDate.Ticks == 0))
                {
                    mp_dtEndDate = Globals.FromDate(oMPTask.dtFinish);
                }
                if (oAGTask.StartDate == oAGTask.EndDate)
                {
                    oAGTask.Text = oAGTask.StartDate.ToString("M/d");
                }
                oAGRow.Node.Depth = oMPTask.lOutlineLevel;
                oAGRow.Node.Text = oMPTask.sName;
                oAGRow.Node.AllowTextEdit = true;
                if (oMPTask.sNotes.Length > 0)
                {
                    oAGRow.Node.Image = GetImage(0);
                    oAGRow.Node.ImageVisible = true;
                }
            }
            ActiveGanttCSWCtl1.Rows.UpdateTree();
            //// Indent & set Predecessors
            foreach (MSP2003.Task oMPTask in oMP11.oTasks)
            {
                oAGRow = ActiveGanttCSWCtl1.Rows.Item("K" + oMPTask.lUID.ToString());
                oAGTask = ActiveGanttCSWCtl1.Tasks.Item("K" + oMPTask.lUID.ToString());
                if (oAGRow.Node.Children() > 0)
                {
                    oAGTask.StyleIndex = "S1";
                }
                else
                {
                    oAGTask.StyleIndex = "T1";
                }
                foreach (MSP2003.TaskPredecessorLink oMPPredecessor in oMPTask.oPredecessorLink_C)
                {
                    ActiveGanttCSWCtl1.Predecessors.Add("K" + oMPTask.lUID.ToString(), "K" + oMPPredecessor.lPredecessorUID.ToString(), GetAGPredecessorType(oMPPredecessor.yType), "", "T1");
                }
            }
            //Assignments
            foreach (MSP2003.Assignment oAssignment in oMP11.oAssignments)
            {
                oAGTask = ActiveGanttCSWCtl1.Tasks.Item("K" + oAssignment.lTaskUID);
                if (oAGTask.StartDate != oAGTask.EndDate)
                {
                    if (oAssignment.lResourceUID > 0)
                    {
                        if (oAGTask.Text.Length == 0)
                        {
                            oAGTask.Text = oMP11.oResources.Item("K" + oAssignment.lResourceUID).sName;
                        }
                        else
                        {
                            oAGTask.Text = oAGTask.Text + ", " + oMP11.oResources.Item("K" + oAssignment.lResourceUID).sName;
                        }
                    }
                }
            }
            mp_dtStartDate = ActiveGanttCSWCtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, -3, mp_dtStartDate);
            AGSetStartDate(mp_dtStartDate);
        }

        private AGCSW.E_CONSTRAINTTYPE GetAGPredecessorType(MSP2003.E_TYPE_3 MPPredecessorType)
        {
            switch (MPPredecessorType)
            {
                case MSP2003.E_TYPE_3.T_3_FF:
                    return AGCSW.E_CONSTRAINTTYPE.PCT_END_TO_END;
                case MSP2003.E_TYPE_3.T_3_FS:
                    return AGCSW.E_CONSTRAINTTYPE.PCT_END_TO_START;
                case MSP2003.E_TYPE_3.T_3_SF:
                    return AGCSW.E_CONSTRAINTTYPE.PCT_START_TO_END;
                case MSP2003.E_TYPE_3.T_3_SS:
                    return AGCSW.E_CONSTRAINTTYPE.PCT_START_TO_START;
            }
            return AGCSW.E_CONSTRAINTTYPE.PCT_END_TO_START;
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
                    oURI = new Uri("../images/WBS/projectnote2003.gif", UriKind.RelativeOrAbsolute);
                    break;
            }
            return oURI;
        }

        private void AG_To_MP11()
        {
            //Dim i As Integer
            //For i = 1 To oMP11.oTasks.Count
            //    dim 
            //    oMP11.oTasks.Item(i).dtStart = ActiveGanttCSWCtl1.Tasks.Item(oMP11.oTasks.Item(i).Key).StartDate
            //    oMP11.oTasks.Item(i).dtFinish = ActiveGanttCSWCtl1.Tasks.Item(oMP11.oTasks.Item(i).Key).EndDate
            //Next
        }

        #endregion

        #region "ActiveGantt Event Handlers"

        private void ActiveGanttCSWCtl1_CustomTierDraw(object sender, CustomTierDrawEventArgs e)
        {
            if (e.TierPosition == E_TIERPOSITION.SP_UPPER)
            {
                if (System.Convert.ToInt32(ActiveGanttCSWCtl1.CurrentView) <= 4)
                {
                    e.Text = e.StartDate.Year.ToString() + " Q" + ActiveGanttCSWCtl1.MathLib.Quarter(e.StartDate).ToString();
                }
                else
                {
                    e.Text = e.StartDate.ToString("MMMM, yyyy");
                }
            }
            else if (e.TierPosition == E_TIERPOSITION.SP_LOWER)
            {
                if (System.Convert.ToInt32(ActiveGanttCSWCtl1.CurrentView) <= 4)
                {
                    e.Text = e.StartDate.ToString("MMM");
                }
                else
                {
                    e.Text = e.StartDate.ToString("ddd");
                }
            }
        }

        private void ActiveGanttCSWCtl1_ControlMouseWheel(object sender, AGCSW.MouseWheelEventArgs e)
        {
            if ((e.Delta == 0) | (ActiveGanttCSWCtl1.VerticalScrollBar.Visible == false))
            {
                return;
            }
            int lDelta = System.Convert.ToInt32(-(e.Delta / 50));
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

        #region "Toolbar Buttons"

        private void cmdIndent_Click(object sender, RoutedEventArgs e)
        {
            Indent();
        }

        private void cmdLoadXML_Click(object sender, RoutedEventArgs e)
        {
            LoadXML();
        }

        private void cmdPrint_Click(object sender, RoutedEventArgs e)
        {
            Print();
        }

        private void cmdSaveXML_Click(object sender, RoutedEventArgs e)
        {
            SaveXML();
        }

        private void cmdZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (System.Convert.ToInt32(ActiveGanttCSWCtl1.CurrentView) < ActiveGanttCSWCtl1.Views.Count)
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

        #endregion

        #region "Menu Items"

        private void mnuClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mnuLoadXML_Click(object sender, RoutedEventArgs e)
        {
            LoadXML();
        }

        private void mnuSaveXML_Click(object sender, RoutedEventArgs e)
        {
            SaveXML();
        }

        private void mnuPrint_Click(object sender, RoutedEventArgs e)
        {
            Print();
        }

        #endregion

        #region "Toolbar Button & Menu Item Functions"

        private void LoadXML()
        {
            Microsoft.Win32.OpenFileDialog OpenFileDialog1 = new Microsoft.Win32.OpenFileDialog();
            oMP11 = new MSP2003.MP11();
            OpenFileDialog1.Title = "Load MS-Project 2003 XML File";
            OpenFileDialog1.InitialDirectory = Globals.g_GetAppLocation() + "\\MSP2003\\";
            OpenFileDialog1.FileName = "";
            OpenFileDialog1.Filter = "XML File (*.xml)|*.xml|All Files (*.*)|*.*";
            if ((OpenFileDialog1.ShowDialog(this) == true))
            {
                if (ValidateMSP2003(OpenFileDialog1.FileName) == false)
                {
                    MessageBox.Show("The file selected is not a valid Microsoft Project 2003 XML File.", "Error", MessageBoxButton.OK);
                }
                else
                {
                    this.Cursor = Cursors.Wait;
                    ActiveGanttCSWCtl1.Clear();
                    oMP11.ReadXML(OpenFileDialog1.FileName);
                    this.Cursor = Cursors.Wait;
                    InitializeAG();
                    MP11_To_AG();
                    ActiveGanttCSWCtl1.Redraw();
                    ActiveGanttCSWCtl1.VerticalScrollBar.LargeChange = ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.LastVisibleRow - ActiveGanttCSWCtl1.CurrentViewObject.ClientArea.FirstVisibleRow;
                    ActiveGanttCSWCtl1.Redraw();
                    this.Cursor = Cursors.Arrow;
                }
            }
        }

        private void SaveXML()
        {
            Microsoft.Win32.SaveFileDialog SaveFileDialog1 = new Microsoft.Win32.SaveFileDialog();
            SaveFileDialog1.Title = "Save As MS-Project 2003 XML File";
            SaveFileDialog1.InitialDirectory = Globals.g_GetAppLocation() + "\\MSP2003\\";
            SaveFileDialog1.Filter = "XML File|*.xml";
            SaveFileDialog1.OverwritePrompt = true;
            if ((SaveFileDialog1.ShowDialog(this) == true))
            {
                this.Cursor = Cursors.Wait;
                AG_To_MP11();
                oMP11.WriteXML(SaveFileDialog1.FileName);
                this.Cursor = Cursors.Arrow;
            }
        }

        private void Print()
        {
            if (ActiveGanttCSWCtl1.Printer != null)
            {
                if (ActiveGanttCSWCtl1.Rows.Count == 0)
                {
                    return;
                }
                if (mp_dtStartDate.Ticks == 0 | mp_dtEndDate.Ticks == 0)
                {
                    return;
                }
                ActiveGanttCSWCtl1.Printer.Interval = ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.TierArea.LowerTier.Interval;
                ActiveGanttCSWCtl1.Printer.Factor = ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.TierArea.LowerTier.Factor;
                fPrintDialog oForm = new fPrintDialog(ActiveGanttCSWCtl1, mp_dtStartDate, mp_dtEndDate);
                oForm.Owner = this;
                oForm.ShowDialog();
            }
        }

        private void Indent()
        {
            Microsoft.Win32.OpenFileDialog OpenFileDialog1 = new Microsoft.Win32.OpenFileDialog();
            Microsoft.Win32.SaveFileDialog SaveFileDialog1 = new Microsoft.Win32.SaveFileDialog();
            OpenFileDialog1.Title = "Load XML File";
            OpenFileDialog1.InitialDirectory = Globals.g_GetAppLocation() + "\\MSP2003\\";
            OpenFileDialog1.FileName = "";
            OpenFileDialog1.Filter = "XML File (*.xml)|*.xml|All Files (*.*)|*.*";
            if ((OpenFileDialog1.ShowDialog(this) == true))
            {
                SaveFileDialog1.Title = "Save XML File As";
                SaveFileDialog1.InitialDirectory = Globals.g_GetAppLocation() + "\\MSP2003\\";
                SaveFileDialog1.Filter = "XML File|*.xml";
                SaveFileDialog1.OverwritePrompt = true;
                if ((SaveFileDialog1.ShowDialog(this) == true))
                {
                    if ((OpenFileDialog1.FileName != SaveFileDialog1.FileName))
                    {
                        this.Cursor = Cursors.Wait;
                        System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
                        xDoc.Load(OpenFileDialog1.FileName);
                        System.Xml.XmlTextWriter oWriter = new System.Xml.XmlTextWriter(SaveFileDialog1.FileName, System.Text.Encoding.UTF8);
                        oWriter.IndentChar = '\t';
                        oWriter.Formatting = System.Xml.Formatting.Indented;
                        xDoc.Save(oWriter);
                        oWriter.Close();
                        this.Cursor = Cursors.Arrow;
                    }
                }
            }
        }

        private bool ValidateMSP2003(string sFileName)
        {
            string sFile = Globals.g_ReadFile(sFileName, false, null);
            if (sFile.Contains("<Project ") == false)
            {
                return false;
            }
            if (sFile.Contains("<SaveVersion>") == true)
            {
                return false;
            }
            return true;
        }

        #endregion

    }
}