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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace AGCSW
{

    [System.Runtime.InteropServices.GuidAttribute("A445B934-3D27-415E-A794-6F0014906C82")]
    public partial class ActiveGanttCSWCtl : UserControl
    {

        [System.ComponentModel.Browsable(false)] public clsRows Rows;
        [System.ComponentModel.Browsable(false)] public clsTasks Tasks;
        [System.ComponentModel.Browsable(false)] public clsColumns Columns;
        [System.ComponentModel.Browsable(false)] public clsStyles Styles;
        [System.ComponentModel.Browsable(false)] public clsLayers Layers;
        [System.ComponentModel.Browsable(false)] public clsPercentages Percentages;
        [System.ComponentModel.Browsable(false)] public clsTimeBlocks TimeBlocks;
        [System.ComponentModel.Browsable(false)] public clsPredecessors Predecessors;
        [System.ComponentModel.Browsable(false)] public clsViews Views;
        [System.ComponentModel.Browsable(false)] public clsSplitter Splitter;
        [System.ComponentModel.Browsable(false)] public clsPrinter Printer;
        [System.ComponentModel.Browsable(false)] public clsTreeview Treeview;
        [System.ComponentModel.Browsable(false)] public clsDrawing Drawing;
        [System.ComponentModel.Browsable(false)] public clsMath MathLib;
        [System.ComponentModel.Browsable(false)] public clsVerticalScrollBar VerticalScrollBar;
        [System.ComponentModel.Browsable(false)] public clsHorizontalScrollBar HorizontalScrollBar;
        [System.ComponentModel.Browsable(false)] public clsTierAppearance TierAppearance;
        [System.ComponentModel.Browsable(false)] public clsTierFormat TierFormat;
        [System.ComponentModel.Browsable(false)] public clsScrollBarSeparator ScrollBarSeparator;
        [System.ComponentModel.Browsable(false)] public clsTimeLineScrollBar TimeLineScrollBar;
        [System.ComponentModel.Browsable(false)] public clsProgressLine ProgressLine;
        [System.ComponentModel.Browsable(false)] public clsConfiguration Configuration;

        private string mp_sPrinterErrorMessage;
        private clsTimeBlocks tmpTimeBlocks;
        internal clsMouseKeyboardEvents MouseKeyboardEvents;
        private clsView mp_oCurrentView;
        internal clsGraphics clsG;
        private bool mp_bAllowAdd = true;
        private bool mp_bAllowEdit = true;
        private bool mp_bAllowSplitterMove = true;
        private bool mp_bAllowRowSize = true;
        private bool mp_bAllowRowMove = true;
        private bool mp_bAllowColumnSize = true;
        private bool mp_bAllowColumnMove = true;
        private bool mp_bAllowTimeLineScroll = true;
        private bool mp_bAllowPredecessorAdd = true;
        private bool mp_bDoubleBuffering = true;
        private bool mp_bPropertiesRead = false;
        private bool mp_bEnforcePredecessors = false;
        private DateTime mp_dtTimeLineStartBuffer;
        private DateTime mp_dtTimeLineEndBuffer;
        private int mp_lMinColumnWidth = 5;
        private int mp_lMinRowHeight = 5;
        private int mp_lSelectedTaskIndex = 0;
        private int mp_lSelectedColumnIndex = 0;
        private int mp_lSelectedRowIndex = 0;
        private int mp_lSelectedCellIndex = 0;
        private int mp_lSelectedPercentageIndex = 0;
        private int mp_lSelectedPredecessorIndex = 0;
        private int mp_lTreeviewColumnIndex = 0;
        private string mp_sCurrentLayer = "0";
        private string mp_sCurrentView = "";
        private E_ADDMODE mp_yAddMode = E_ADDMODE.AT_TASKADD;
        private E_INTERVAL mp_yAddDurationInterval = E_INTERVAL.IL_SECOND;
        private E_SCROLLBEHAVIOUR mp_yScrollBarBehaviour = E_SCROLLBEHAVIOUR.SB_HIDE;
        private E_TIMEBLOCKBEHAVIOUR mp_yTimeBlockBehaviour = E_TIMEBLOCKBEHAVIOUR.TBB_ROWEXTENTS;
        private E_LAYEROBJECTENABLE mp_yLayerEnableObjects = E_LAYEROBJECTENABLE.EC_INCURRENTLAYERONLY;
        private E_REPORTERRORS mp_yErrorReports = E_REPORTERRORS.RE_MSGBOX;
        private E_OBJECTSCOPE mp_yTierAppearanceScope = E_OBJECTSCOPE.OS_CONTROL;
        private E_OBJECTSCOPE mp_yTierFormatScope = E_OBJECTSCOPE.OS_CONTROL;
        private E_OBJECTSCOPE mp_yTimeLineScrollBarScope = E_OBJECTSCOPE.OS_CONTROL;
        private E_OBJECTSCOPE mp_yProgressLineScope = E_OBJECTSCOPE.OS_CONTROL;
        private E_PREDECESSORMODE mp_yPredecessorMode = E_PREDECESSORMODE.PM_CREATEWARNINGFLAG;
        private E_CONTROLTEMPLATE mp_yControlTemplate = E_CONTROLTEMPLATE.STC_NONE;
        private E_OBJECTTEMPLATE mp_yObjectTemplate = E_OBJECTTEMPLATE.STO_NONE;
        private string mp_sControlTag = "";
        internal DrawingContext mp_oGraphics;
        private System.Globalization.CultureInfo mp_oCulture;
        private string mp_sStyleIndex;
        private clsStyle mp_oStyle;
        private Image mp_oImage;
        private string mp_sImageTag;
        internal clsTextBox mp_oTextBox;
        private System.Windows.Input.Key mp_oPredecessorAddModeKey = Key.F2;
        public ToolTipEventArgs ToolTipEventArgs = new ToolTipEventArgs();
        public ObjectAddedEventArgs ObjectAddedEventArgs = new ObjectAddedEventArgs();
        public CustomTierDrawEventArgs CustomTierDrawEventArgs = new CustomTierDrawEventArgs();
        public CustomTickMarkAreaDrawEventArgs CustomTickMarkAreaDrawEventArgs = new CustomTickMarkAreaDrawEventArgs();
        public TickMarkTextDrawEventArgs TickMarkTextDrawEventArgs = new TickMarkTextDrawEventArgs();
        public MouseEventArgs MouseEventArgs = new MouseEventArgs();
        public MouseEventArgs MouseHoverEventArgs = new MouseEventArgs();
        public KeyEventArgs KeyEventArgs = new KeyEventArgs();
        public ScrollEventArgs ScrollEventArgs = new ScrollEventArgs();
        public DrawEventArgs DrawEventArgs = new DrawEventArgs();
        public PredecessorDrawEventArgs PredecessorDrawEventArgs = new PredecessorDrawEventArgs();
        public ObjectSelectedEventArgs ObjectSelectedEventArgs = new ObjectSelectedEventArgs();
        public ObjectStateChangedEventArgs ObjectStateChangedEventArgs = new ObjectStateChangedEventArgs();
        public ErrorEventArgs ErrorEventArgs = new ErrorEventArgs();
        public NodeEventArgs NodeEventArgs = new NodeEventArgs();
        public MouseWheelEventArgs MouseWheelEventArgs = new MouseWheelEventArgs();
        public TextEditEventArgs TextEditEventArgs = new TextEditEventArgs();
        public PredecessorExceptionEventArgs PredecessorExceptionEventArgs = new PredecessorExceptionEventArgs();
        public PagePrintEventArgs PagePrintEventArgs = new PagePrintEventArgs();

        private delegate void mp_RedrawEventHandler();

        //Mouse Events
        public delegate void ControlClickEventHandler(object sender, MouseEventArgs e);
        public event ControlClickEventHandler ControlClick;
        public delegate void ControlDblClickEventHandler(object sender, MouseEventArgs e);
        public event ControlDblClickEventHandler ControlDblClick;
        public delegate void ControlMouseDownEventHandler(object sender, MouseEventArgs e);
        public event ControlMouseDownEventHandler ControlMouseDown;
        public delegate void ControlMouseMoveEventHandler(object sender, MouseEventArgs e);
        public event ControlMouseMoveEventHandler ControlMouseMove;
        public delegate void ControlMouseUpEventHandler(object sender, MouseEventArgs e);
        public event ControlMouseUpEventHandler ControlMouseUp;
        public delegate void ControlMouseHoverEventHandler(object sender, MouseEventArgs e);
        public event ControlMouseHoverEventHandler ControlMouseHover;
        public delegate void ControlMouseWheelEventHandler(object sender, MouseWheelEventArgs e);
        public event ControlMouseWheelEventHandler ControlMouseWheel;

        //Keyboard Events
        public delegate void ControlKeyDownEventHandler(object sender, KeyEventArgs e);
        public event ControlKeyDownEventHandler ControlKeyDown;
        public delegate void ControlKeyPressEventHandler(object sender, KeyEventArgs e);
        public event ControlKeyPressEventHandler ControlKeyPress;
        public delegate void ControlKeyUpEventHandler(object sender, KeyEventArgs e);
        public event ControlKeyUpEventHandler ControlKeyUp;

        // Scrolling
        public delegate void ControlScrollEventHandler(object sender, ScrollEventArgs e);
        public event ControlScrollEventHandler ControlScroll;

        //Draw
        public event DrawEventHandler Draw;
        public delegate void DrawEventHandler(object sender, DrawEventArgs e);
        public event PredecessorDrawEventHandler PredecessorDraw;
        public delegate void PredecessorDrawEventHandler(object sender, PredecessorDrawEventArgs e);
        public event CustomTierDrawEventHandler CustomTierDraw;
        public delegate void CustomTierDrawEventHandler(object sender, CustomTierDrawEventArgs e);
        public event CustomTickMarkAreaDrawEventHandler CustomTickMarkAreaDraw;
        public delegate void CustomTickMarkAreaDrawEventHandler(object sender, CustomTickMarkAreaDrawEventArgs e);
        public event CustomTickMarkDrawEventHandler CustomTickMarkDraw;
        public delegate void CustomTickMarkDrawEventHandler(object sender, CustomTickMarkAreaDrawEventArgs e);
        public event TickMarkTextDrawEventHandler TickMarkTextDraw;
        public delegate void TickMarkTextDrawEventHandler(object sender, TickMarkTextDrawEventArgs e);
        public event TierTextDrawEventHandler TierTextDraw;
        public delegate void TierTextDrawEventHandler(object sender, CustomTierDrawEventArgs e);

        //Added/Selected
        public delegate void ObjectAddedEventHandler(object sender, ObjectAddedEventArgs e);
        public event ObjectAddedEventHandler ObjectAdded;
        public delegate void ObjectSelectedEventHandler(object sender, ObjectSelectedEventArgs e);
        public event ObjectSelectedEventHandler ObjectSelected;

        //Changed
        public delegate void BeginObjectChangeEventHandler(object sender, ObjectStateChangedEventArgs e);
        public event BeginObjectChangeEventHandler BeginObjectChange;
        public delegate void ObjectChangeEventHandler(object sender, ObjectStateChangedEventArgs e);
        public event ObjectChangeEventHandler ObjectChange;
        public delegate void EndObjectChangeEventHandler(object sender, ObjectStateChangedEventArgs e);
        public event EndObjectChangeEventHandler EndObjectChange;
        public delegate void CompleteObjectChangeEventHandler(object sender, ObjectStateChangedEventArgs e);
        public event CompleteObjectChangeEventHandler CompleteObjectChange;

        //Errors
        public delegate void ActiveGanttErrorEventHandler(object sender, ErrorEventArgs e);
        public event ActiveGanttErrorEventHandler ActiveGanttError;
        public delegate void PredecessorExceptionEventHandler(object sender, PredecessorExceptionEventArgs e);
        public event PredecessorExceptionEventHandler PredecessorException;

        //Treeview
        public delegate void NodeCheckedEventHandler(object sender, NodeEventArgs e);
        public event NodeCheckedEventHandler NodeChecked;
        public delegate void NodeExpandedEventHandler(object sender, NodeEventArgs e);
        public event NodeExpandedEventHandler NodeExpanded;

        //Text Edit
        public delegate void BeginTextEditHandler(object sender, TextEditEventArgs e);
        public event BeginTextEditHandler BeginTextEdit;
        public delegate void EndTextEditHandler(object sender, TextEditEventArgs e);
        public event EndTextEditHandler EndTextEdit;

        //Other
        public delegate void TimeLineChangedEventHandler(object sender, System.EventArgs e);
        public event TimeLineChangedEventHandler TimeLineChanged;
        public delegate void ControlRedrawnEventHandler(object sender, System.EventArgs e);
        public event ControlRedrawnEventHandler ControlRedrawn;
        public delegate void ControlDrawEventHandler(object sender, System.EventArgs e);
        public event ControlDrawEventHandler ControlDraw;
        public delegate void ToolTipOnMouseHoverEventHandler(object sender, ToolTipEventArgs e);
        public event ToolTipOnMouseHoverEventHandler ToolTipOnMouseHover;
        public delegate void ToolTipOnMouseMoveEventHandler(object sender, ToolTipEventArgs e);
        public event ToolTipOnMouseMoveEventHandler ToolTipOnMouseMove;
        public delegate void OnMouseHoverToolTipDrawEventHandler(object sender, ToolTipEventArgs e);
        public event OnMouseHoverToolTipDrawEventHandler OnMouseHoverToolTipDraw;
        public delegate void OnMouseMoveToolTipDrawEventHandler(object sender, ToolTipEventArgs e);
        public event OnMouseMoveToolTipDrawEventHandler OnMouseMoveToolTipDraw;

        //Printing
        public delegate void PagePrintEventHandler(object sender, PagePrintEventArgs e);
        public event PagePrintEventHandler PagePrint;

        internal void FirePredecessorException()
        {
            if (PredecessorException != null)
            {
                PredecessorException(this, PredecessorExceptionEventArgs);
            }
        }

        internal void FireBeginTextEdit()
        {
            if (BeginTextEdit != null)
            {
                BeginTextEdit(this, TextEditEventArgs);
            }
        }

        internal void FireEndTextEdit()
        {
            if (EndTextEdit != null)
            {
                EndTextEdit(this, TextEditEventArgs);
            }
        }

        internal void FireControlClick()
        {
            if (ControlClick != null)
            {
                ControlClick(this, MouseEventArgs);
            }
        }

        internal void FireControlDblClick()
        {
            if (ControlDblClick != null)
            {
                ControlDblClick(this, MouseEventArgs);
            }
        }

        internal void FireControlMouseDown()
        {
            if (ControlMouseDown != null)
            {
                ControlMouseDown(this, MouseEventArgs);
            }
        }

        internal void FireControlMouseMove()
        {
            if (ControlMouseMove != null)
            {
                ControlMouseMove(this, MouseEventArgs);
            }
        }

        internal void FireControlMouseUp()
        {
            if (ControlMouseUp != null)
            {
                ControlMouseUp(this, MouseEventArgs);
            }
        }

        internal void FireControlMouseHover()
        {
            if (ControlMouseHover != null)
            {
                ControlMouseHover(this, MouseHoverEventArgs);
            }
        }

        internal void FireControlKeyDown()
        {
            if (ControlKeyDown != null)
            {
                ControlKeyDown(this, KeyEventArgs);
            }
        }

        internal void FireControlKeyUp()
        {
            if (ControlKeyDown != null)
            {
                ControlKeyUp(this, KeyEventArgs);
            }
        }

        internal void FireControlKeyPress()
        {
            if (ControlKeyPress != null)
            {
                ControlKeyPress(this, KeyEventArgs);
            }
        }

        internal void FireControlMouseWheel()
        {
            if (ControlMouseWheel != null)
            {
                ControlMouseWheel(this, MouseWheelEventArgs);
            }
        }

        internal void FireDraw()
        {
            if (Draw != null)
            {
                Draw(this, DrawEventArgs);
            }
        }

        internal void FirePredecessorDraw()
        {
            if (PredecessorDraw != null)
            {
                PredecessorDraw(this, PredecessorDrawEventArgs);
            }
        }

        internal void FireCustomTierDraw()
        {
            if (CustomTierDraw != null)
            {
                CustomTierDraw(this, CustomTierDrawEventArgs);
            }
        }

        internal void FireCustomTickMarkAreaDraw()
        {
            if (CustomTickMarkAreaDraw != null)
            {
                CustomTickMarkAreaDraw(this, CustomTickMarkAreaDrawEventArgs);
            }
        }

        internal void FireCustomTickMarkDraw()
        {
            if (CustomTickMarkDraw != null)
            {
                CustomTickMarkDraw(this, CustomTickMarkAreaDrawEventArgs);
            }
        }

        internal void FireTickMarkTextDraw()
        {
            if (TickMarkTextDraw != null)
            {
                TickMarkTextDraw(this, TickMarkTextDrawEventArgs);
            }
        }

        internal void FireTierTextDraw()
        {
            if (TierTextDraw != null)
            {
                TierTextDraw(this, CustomTierDrawEventArgs);
            }
        }

        internal void FireObjectAdded()
        {
            if (ObjectAdded != null)
            {
                ObjectAdded(this, ObjectAddedEventArgs);
            }
        }

        internal void FireObjectSelected()
        {
            if (ObjectSelected != null)
            {
                ObjectSelected(this, ObjectSelectedEventArgs);
            }
        }

        internal void FireBeginObjectChange()
        {
            if (BeginObjectChange != null)
            {
                BeginObjectChange(this, ObjectStateChangedEventArgs);
            }
        }

        internal void FireObjectChange()
        {
            if (ObjectChange != null)
            {
                ObjectChange(this, ObjectStateChangedEventArgs);
            }
        }

        internal void FireEndObjectChange()
        {
            if (EndObjectChange != null)
            {
                EndObjectChange(this, ObjectStateChangedEventArgs);
            }
        }

        internal void FireCompleteObjectChange()
        {
            if (CompleteObjectChange != null)
            {
                CompleteObjectChange(this, ObjectStateChangedEventArgs);
            }
        }

        internal void FireActiveGanttError()
        {
            if (ActiveGanttError != null)
            {
                ActiveGanttError(this, ErrorEventArgs);
            }
        }

        internal void FireControlScroll()
        {
            if (ControlScroll != null)
            {
                ControlScroll(this, ScrollEventArgs);
            }
        }

        internal void FireNodeChecked()
        {
            if (NodeChecked != null)
            {
                NodeChecked(this, NodeEventArgs);
            }
        }

        internal void FireNodeExpanded()
        {
            if (NodeExpanded != null)
            {
                NodeExpanded(this, NodeEventArgs);
            }
        }

        internal void FireControlDraw()
        {
            if (ControlDraw != null)
            {
                ControlDraw(this, new System.EventArgs());
            }
        }

        internal void FireControlRedrawn()
        {
            if (ControlRedrawn != null)
            {
                ControlRedrawn(this, new System.EventArgs());
            }
        }

        internal void FireTimeLineChanged()
        {
            if (TimeLineChanged != null)
            {
                TimeLineChanged(this, new System.EventArgs());
            }
        }

        internal void FireToolTipOnMouseHover(E_EVENTTARGET EventTarget)
        {
            if (mp_oCurrentView.ClientArea.ToolTipsVisible == false)
            {
                return;
            }
            ToolTipEventArgs.ToolTipType = E_TOOLTIPTYPE.TPT_HOVER;
            ToolTipEventArgs.EventTarget = EventTarget;
            if (ToolTipOnMouseHover != null)
            {
                ToolTipOnMouseHover(this, ToolTipEventArgs);
            }
        }

        internal void FireToolTipOnMouseMove(E_OPERATION Operation)
        {
            if (mp_oCurrentView.ClientArea.ToolTipsVisible == false)
            {
                return;
            }
            ToolTipEventArgs.ToolTipType = E_TOOLTIPTYPE.TPT_MOVEMENT;
            ToolTipEventArgs.Operation = Operation;
            if (ToolTipOnMouseMove != null)
            {
                ToolTipOnMouseMove(this, ToolTipEventArgs);
            }
        }

        internal void FireOnMouseHoverToolTipDraw(E_EVENTTARGET EventTarget)
        {
            if (mp_oCurrentView.ClientArea.ToolTipsVisible == false)
            {
                return;
            }
            ToolTipEventArgs.X1 = ControlToolTip.Left;
            ToolTipEventArgs.Y1 = ControlToolTip.Top;
            ToolTipEventArgs.X2 = ControlToolTip.Right - 1;
            ToolTipEventArgs.Y2 = ControlToolTip.Bottom - 1;
            if (OnMouseHoverToolTipDraw != null)
            {
                OnMouseHoverToolTipDraw(this, ToolTipEventArgs);
            }
        }

        internal void FireOnMouseMoveToolTipDraw(E_OPERATION Operation)
        {
            if (mp_oCurrentView.ClientArea.ToolTipsVisible == false)
            {
                return;
            }
            ToolTipEventArgs.X1 = ControlToolTip.Left;
            ToolTipEventArgs.Y1 = ControlToolTip.Top;
            ToolTipEventArgs.X2 = ControlToolTip.Right - 1;
            ToolTipEventArgs.Y2 = ControlToolTip.Bottom - 1;
            if (OnMouseMoveToolTipDraw != null)
            {
                OnMouseMoveToolTipDraw(this, ToolTipEventArgs);
            }
        }

        internal void FirePagePrint()
        {
            if (PagePrint != null)
            {
                PagePrint(this, PagePrintEventArgs);
            }
        }

        internal clsTimeBlocks TempTimeBlocks()
        {
            return tmpTimeBlocks;
        }

        public ActiveGanttCSWCtl()
        {
            InitializeComponent();
            RenderOptions.SetEdgeMode(this, EdgeMode.Aliased);



            mp_bPropertiesRead = false;
            if (mp_bPropertiesRead == false)
            {
                Configuration = new clsConfiguration(this);
                clsG = new clsGraphics(this);
                MathLib = new clsMath(this);
                Styles = new clsStyles(this);
                mp_sStyleIndex = "DS_CONTROL";
                mp_oStyle = Styles.FItem("DS_CONTROL");
                VerticalScrollBar = new clsVerticalScrollBar(this);
                HorizontalScrollBar = new clsHorizontalScrollBar(this);
                TimeLineScrollBar = new clsTimeLineScrollBar(this);
                Rows = new clsRows(this);
                Tasks = new clsTasks(this);
                Columns = new clsColumns(this);
                Layers = new clsLayers(this);
                Percentages = new clsPercentages(this);
                TimeBlocks = new clsTimeBlocks(this);
                Predecessors = new clsPredecessors(this);
                tmpTimeBlocks = new clsTimeBlocks(this);
                try
                {
                    Printer = new clsPrinter(this);
                }
                catch (Exception ex)
                {
                    Printer = null;
                    mp_sPrinterErrorMessage = ex.Message;
                }
                Splitter = new clsSplitter(this);
                Views = new clsViews(this);
                Treeview = new clsTreeview(this);
                mp_oCurrentView = Views.FItem("0");
                MouseKeyboardEvents = new clsMouseKeyboardEvents(this);
                Drawing = new clsDrawing(this);
                mp_oCulture = (System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentCulture.Clone();
                TierAppearance = new clsTierAppearance(this);
                TierFormat = new clsTierFormat(this);
                ScrollBarSeparator = new clsScrollBarSeparator(this);
                mp_oTextBox = new clsTextBox(this);
                ProgressLine = new clsProgressLine(this);
                

                mp_oImage = null;
                mp_sImageTag = "";

                
            }
            mp_bPropertiesRead = true;
            this.Focusable = true;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        internal void ForceRender()
        {
            DrawingVisual oDrawingVisual = new DrawingVisual();
            DrawingContext oDC = oDrawingVisual.RenderOpen();
            OnRender(oDC);
            oDC.Close();
        }

        protected override void OnRender(DrawingContext oDC)
        {
            if (mp_bPropertiesRead == false)
            {
                return;
            }
            mp_oGraphics = oDC;
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == true)
            {
                mp_DrawDesignMode();
            }
            else
            {
                //mp_CHKPXPScrollButtons()
                //mp_CHKPXPLines()
                //mp_CHKPXPButtons()
                //mp_CHKPXPArrows()
                //mp_CHKPXPFigures()
                //mp_CHKPXPGradients()
                //mp_CHKPXPText()
                //mp_CHKPXPHatch()
                mp_Draw();
            }
            if (mp_oCurrentView.TimeLine.StartDate != mp_dtTimeLineStartBuffer | mp_oCurrentView.TimeLine.EndDate != mp_dtTimeLineEndBuffer)
            {
                mp_dtTimeLineStartBuffer = mp_oCurrentView.TimeLine.StartDate;
                mp_dtTimeLineEndBuffer = mp_oCurrentView.TimeLine.EndDate;
                FireTimeLineChanged();
            }
            base.OnRender(oDC);
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (mp_bPropertiesRead == false)
            {
                return;
            }
            Redraw();
        }

        private void mp_Draw()
        {
            clsG.RequiresPop = false;
            FireControlDraw();
            clsG.mp_ResetFocusRectangle();
            clsG.mp_ClipRegion(0, 0, clsG.Width(), clsG.Height(), false);
            clsG.mp_DrawItem(0, 0, clsG.Width() - 1, clsG.Height() - 1, "", "", false, this.Image, 0, 0, this.Style);
            mp_oCurrentView.TimeLine.Calculate();
            mp_PositionScrollBars();
            Columns.Position();
            Rows.InitializePosition();
            Rows.PositionRows();
            mp_oCurrentView.TimeLine.Draw();
            Columns.Draw();
            Rows.Draw();
            Treeview.Draw();
            TimeBlocks.CreateTemporaryTimeBlocks();
            TimeBlocks.Draw();
            mp_oCurrentView.ClientArea.Grid.Draw();
            mp_oCurrentView.ClientArea.Draw();
            Predecessors.Draw();
            Tasks.Draw();
            Percentages.Draw();
            mp_oCurrentView.TimeLine.ProgressLine.Draw();
            f_ProgressLine.Draw();
            Splitter.Draw();
            clsG.mp_ClipRegion(0, 0, clsG.Width(), clsG.Height(), false);
            if (VerticalScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                clsG.mp_DrawItem(VerticalScrollBar.Left, VerticalScrollBar.Top + VerticalScrollBar.Height, VerticalScrollBar.Left + 16, VerticalScrollBar.Top + VerticalScrollBar.Height + 16, "", "", false, null, 0, 0, ScrollBarSeparator.Style);
                clsG.mp_ClipRegion(0, 0, clsG.Width(), clsG.Height(), false);
            }
            else if (f_TimeLineScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                clsG.mp_DrawItem(f_TimeLineScrollBar.Left + f_TimeLineScrollBar.Width, f_TimeLineScrollBar.Top, f_TimeLineScrollBar.Left + f_TimeLineScrollBar.Width + 16, f_TimeLineScrollBar.Top + 16, "", "", false, null, 0, 0,
                ScrollBarSeparator.Style);
                clsG.mp_ClipRegion(0, 0, clsG.Width(), clsG.Height(), false);
            }
            mp_DrawDebugMetrics();
            if (VerticalScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                VerticalScrollBar.ScrollBar.Draw();
            }
            if (HorizontalScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                HorizontalScrollBar.ScrollBar.Draw();
            }
            if (f_TimeLineScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                f_TimeLineScrollBar.ScrollBar.Draw();
            }
#if DemoVersion
            if (clsG.CustomPrinting == false)
            {

                Font oFont = new Font("Arial", 12, System.Windows.FontWeights.Bold);
                System.Random rnd = null;
                rnd = new System.Random((int)System.DateTime.Now.Ticks);
                System.Windows.Media.Color oColor = new System.Windows.Media.Color();
                oColor = Color.FromArgb(255, System.Convert.ToByte(rnd.Next(0, 255)), System.Convert.ToByte(rnd.Next(0, 255)), System.Convert.ToByte(rnd.Next(0, 255)));
                clsG.mp_DrawAlignedText(20, 20, clsG.Width() - 30, clsG.Height() - 20, "ActiveGanttCSW Trial Version" +  Environment.NewLine + "For Evaluation Purposes Only", GRE_HORIZONTALALIGNMENT.HAL_RIGHT, GRE_VERTICALALIGNMENT.VAL_BOTTOM, oColor, oFont, true);
            }
#endif
            FireControlRedrawn();

            clsG.mp_ClearClipRegion();
            
        }

        private void mp_DrawDesignMode()
        {
            int lLeftBox = 0;
            int lTop = 0;
            int lRightBox = 0;
            int lBottom = 0;
            int lLeftCA = 0;
            int lRightCA = 0;
            clsG.RequiresPop = false;
            Font oFont = new Font("Arial", 8);
            clsG.mp_DrawLine(0, 0, clsG.Width(), clsG.Height(), GRE_LINETYPE.LT_FILLED, Color.FromArgb(255, 255, 255, 255), GRE_LINEDRAWSTYLE.LDS_SOLID);
            mp_oCurrentView.TimeLine.Calculate();
            mp_oCurrentView.TimeLine.Draw();
            clsG.mp_ClearClipRegion();
            lLeftBox = mt_LeftMargin;
            lTop = mt_TopMargin;
            lRightBox = Splitter.Left;
            lBottom = mp_oCurrentView.TimeLine.Bottom;
            clsG.mp_DrawEdge(lLeftBox, lTop, lRightBox, lBottom, System.Windows.Media.Color.FromArgb(255,192, 192, 192), GRE_BUTTONSTYLE.BT_NORMALWINDOWS, GRE_EDGETYPE.ET_RAISED, true, null);
            clsG.mp_DrawAlignedText(lLeftBox, lTop, lRightBox, lBottom, "Column", GRE_HORIZONTALALIGNMENT.HAL_CENTER, GRE_VERTICALALIGNMENT.VAL_CENTER, System.Windows.Media.Color.FromArgb(255, 0, 0, 0), oFont);
            lLeftBox = mt_LeftMargin;
            lTop = mp_oCurrentView.ClientArea.Top;
            lRightBox = Splitter.Left;
            lBottom = mp_oCurrentView.ClientArea.Top + 40;
            lLeftCA = Splitter.Right;
            lRightCA = mt_RightMargin;
            clsG.mp_DrawEdge(lLeftBox, lTop, lRightBox, lBottom, System.Windows.Media.Color.FromArgb(255,192, 192, 192), GRE_BUTTONSTYLE.BT_NORMALWINDOWS, GRE_EDGETYPE.ET_RAISED, true, null);
            clsG.mp_DrawAlignedText(lLeftBox, lTop, lRightBox, lBottom, "Cell", GRE_HORIZONTALALIGNMENT.HAL_CENTER, GRE_VERTICALALIGNMENT.VAL_CENTER, System.Windows.Media.Color.FromArgb(255, 0, 0, 0), oFont);
            clsG.mp_DrawLine(lLeftCA, lBottom, lRightCA, lBottom, GRE_LINETYPE.LT_NORMAL, mp_oCurrentView.ClientArea.Grid.Color, GRE_LINEDRAWSTYLE.LDS_SOLID);
            Rows.TopOffset = mp_oCurrentView.ClientArea.Top + 40;
            mp_oCurrentView.ClientArea.f_LastVisibleRow = 1;
            Splitter.Draw();
            clsG.mp_ClipRegion(0, 0, clsG.Width(), clsG.Height(), false);
            clsG.mp_DrawEdge(0, 0, clsG.Width() - 1, clsG.Height() - 1, Color.FromArgb(255, 0, 0, 0), GRE_BUTTONSTYLE.BT_NORMALWINDOWS, GRE_EDGETYPE.ET_SUNKEN, false, null);
        }

        private void mp_DrawDebugMetrics()
        {
        }

        internal Canvas f_Canvas()
        {
            return oCanvas;
        }

        internal Canvas GetGraphicsObject()
        {
            return oCanvas;
        }

        internal void f_Draw()
        {
            mp_Draw();
        }

        internal bool f_UserMode
        {
            get 
            { 
                return !System.ComponentModel.DesignerProperties.GetIsInDesignMode(this); 
            }
        }

        internal clsTimeLineScrollBar f_TimeLineScrollBar
        {
            get
            {
                if (mp_yTimeLineScrollBarScope == E_OBJECTSCOPE.OS_CONTROL)
                {
                    return TimeLineScrollBar;
                }
                else
                {
                    return CurrentViewObject.TimeLine.TimeLineScrollBar;
                }
            }
        }

        internal clsProgressLine f_ProgressLine
        {
            get
            {
                if (mp_yProgressLineScope == E_OBJECTSCOPE.OS_CONTROL)
                {
                    return ProgressLine;
                }
                else
                {
                    return CurrentViewObject.TimeLine.ProgressLine;
                }
            }
        }

        internal int mt_BorderThickness
        {
            get
            {
                switch (mp_oStyle.Appearance)
                {
                    case E_STYLEAPPEARANCE.SA_RAISED:
                        return 2;
                    case E_STYLEAPPEARANCE.SA_SUNKEN:
                        return 2;
                    case E_STYLEAPPEARANCE.SA_FLAT:
                        if (mp_oStyle.BorderStyle == GRE_BORDERSTYLE.SBR_NONE)
                        {
                            return 0;
                        }
                        else
                        {
                            return mp_oStyle.BorderWidth;
                        }
                    case E_STYLEAPPEARANCE.SA_GRAPHICAL:
                        return 0;
                }
                return 0;
            }
        }

        internal int mt_TableBottom
        {
            get
            {
                if (HorizontalScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
                {
                    return clsG.Height() - mt_BorderThickness - 1 - HorizontalScrollBar.Height;
                }
                else
                {
                    return clsG.Height() - mt_BorderThickness - 1;
                }
            }
        }

        internal int mt_TopMargin
        {
            get { return mt_BorderThickness; }
        }

        internal int mt_LeftMargin
        {
            get { return mt_BorderThickness; }
        }

        internal int mt_RightMargin
        {
            get
            {
                if (VerticalScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
                {
                    return clsG.Width() - mt_BorderThickness - 1 - VerticalScrollBar.Width;
                }
                else
                {
                    return clsG.Width() - mt_BorderThickness - 1;
                }
            }
        }

        internal int mt_BottomMargin
        {
            get { return clsG.Height() - mt_BorderThickness - 1; }
        }

        private void UserControl_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == true) return;
            MouseKeyboardEvents.OnMouseLeave();
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == true) return;
            MouseKeyboardEvents.OnMouseDown((int)e.GetPosition(oCanvas).X, (int)e.GetPosition(oCanvas).Y, e.ChangedButton);
        }

        private void UserControl_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == true) return;
            MouseKeyboardEvents.OnMouseMoveGeneral((int)e.GetPosition(oCanvas).X, (int)e.GetPosition(oCanvas).Y);
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == true) return;
            MouseKeyboardEvents.OnMouseUp((int)e.GetPosition(oCanvas).X, (int)e.GetPosition(oCanvas).Y);
            Redraw();
        }

        private void UserControl_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == true) return;
            MouseKeyboardEvents.KeyDown(e.Key);
        }

        private void UserControl_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == true) return;
            MouseKeyboardEvents.KeyUp(e.Key);
        }

        private void UserControl_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == true) return;
            MouseWheelEventArgs.Clear();
            MouseWheelEventArgs.Delta = e.Delta;
            MouseWheelEventArgs.X = System.Convert.ToInt32(e.GetPosition(this).X);
            MouseWheelEventArgs.Y = System.Convert.ToInt32(e.GetPosition(this).Y);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MouseWheelEventArgs.Button = E_MOUSEBUTTONS.BTN_LEFT;
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                MouseWheelEventArgs.Button = E_MOUSEBUTTONS.BTN_RIGHT;
            }
            else if (e.MiddleButton == MouseButtonState.Pressed)
            {
                MouseWheelEventArgs.Button = E_MOUSEBUTTONS.BTN_MIDDLE;
            }
            else if (e.XButton1 == MouseButtonState.Pressed)
            {
                MouseWheelEventArgs.Button = E_MOUSEBUTTONS.BTN_XBUTTON1;
            }
            else if (e.XButton2 == MouseButtonState.Pressed)
            {
                MouseWheelEventArgs.Button = E_MOUSEBUTTONS.BTN_XBUTTON2;
            }
            else
            {
                MouseWheelEventArgs.Button = E_MOUSEBUTTONS.BTN_NONE;
            }
            FireControlMouseWheel();
        }

        internal void VerticalScrollBar_ValueChanged(int Offset)
        {
            Redraw();
            ScrollEventArgs.Clear();
            ScrollEventArgs.ScrollBarType = E_SCROLLBAR.SCR_VERTICAL;
            ScrollEventArgs.Offset = Offset;
            FireControlScroll();
        }

        internal void HorizontalScrollBar_ValueChanged(int Offset)
        {
            Redraw();
            ScrollEventArgs.Clear();
            ScrollEventArgs.ScrollBarType = E_SCROLLBAR.SCR_HORIZONTAL1;
            ScrollEventArgs.Offset = Offset;
            FireControlScroll();
        }

        internal void TimeLineScrollBar_ValueChanged(int Offset)
        {
            Redraw();
            ScrollEventArgs.Clear();
            ScrollEventArgs.ScrollBarType = E_SCROLLBAR.SCR_HORIZONTAL2;
            ScrollEventArgs.Offset = Offset;
            FireControlScroll();
        }

        internal void mp_PositionScrollBars()
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == true | clsG.CustomPrinting == true)
            {
                VerticalScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
                HorizontalScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
                f_TimeLineScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
                return;
            }

            if (clsG.Height() <= mp_oCurrentView.ClientArea.Top)
            {
                VerticalScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
                HorizontalScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
                f_TimeLineScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
                return;
            }

            //// Determine need for HorizontalScrollBar
            int lWidth = 0;
            lWidth = Columns.Width;
            if (lWidth > Splitter.Right)
            {
                if (HorizontalScrollBar.mf_Visible == true)
                {
                    HorizontalScrollBar.State = E_SCROLLSTATE.SS_NEEDED;
                }
                else
                {
                    HorizontalScrollBar.State = E_SCROLLSTATE.SS_NOTNEEDED;
                }
            }
            else
            {
                HorizontalScrollBar.State = E_SCROLLSTATE.SS_NOTNEEDED;
            }
            if (Splitter.Right < 5)
            {
                HorizontalScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
            }

            //// Determine need for mp_oCurrentView.TimeLine.TimeLineScrollBar
            if (Splitter.Right < clsG.Width() - (18 + mt_BorderThickness))
            {
                if (f_TimeLineScrollBar.Enabled == true)
                {
                    if (f_TimeLineScrollBar.mf_Visible == true)
                    {
                        f_TimeLineScrollBar.State = E_SCROLLSTATE.SS_NEEDED;
                    }
                    else
                    {
                        f_TimeLineScrollBar.State = E_SCROLLSTATE.SS_NOTNEEDED;
                    }
                }
                else
                {
                    f_TimeLineScrollBar.State = E_SCROLLSTATE.SS_NOTNEEDED;
                }
            }
            else
            {
                f_TimeLineScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
            }

            //// Determine need for VerticalScrollBar
            if (((Rows.Height() + mp_oCurrentView.ClientArea.Top + HorizontalScrollBar.Height + mt_BorderThickness) > clsG.Height()) | (Rows.RealFirstVisibleRow > 1))
            {
                if (f_TimeLineScrollBar.State == E_SCROLLSTATE.SS_CANTDISPLAY)
                {
                    VerticalScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
                }
                else
                {
                    VerticalScrollBar.State = E_SCROLLSTATE.SS_NEEDED;
                }
            }
            else
            {
                VerticalScrollBar.State = E_SCROLLSTATE.SS_NOTNEEDED;
            }

            if (VerticalScrollBar.mf_Visible == false)
            {
                VerticalScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
            }
            if (HorizontalScrollBar.mf_Visible == false)
            {
                HorizontalScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
            }
            if (f_TimeLineScrollBar.mf_Visible == false)
            {
                f_TimeLineScrollBar.State = E_SCROLLSTATE.SS_CANTDISPLAY;
            }

            if (VerticalScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                VerticalScrollBar.Position();
            }
            if (HorizontalScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                HorizontalScrollBar.Position();
            }
            if (f_TimeLineScrollBar.State == E_SCROLLSTATE.SS_SHOWN)
            {
                f_TimeLineScrollBar.Position();
            }
        }

        public void WriteXML(string url)
        {
            clsXML oXML = new clsXML(this, "ActiveGanttCtl");
            mp_WriteXML(ref oXML);
            oXML.WriteXML(url);
        }

        public void ReadXML(string url)
        {
            clsXML oXML = new clsXML(this, "ActiveGanttCtl");
            oXML.ReadXML(url);
            mp_ReadXML(ref oXML);
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(this, "ActiveGanttCtl");
            oXML.SetXML(sXML);
            mp_ReadXML(ref oXML);
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(this, "ActiveGanttCtl");
            mp_WriteXML(ref oXML);
            return oXML.GetXML();
        }

        private void mp_WriteXML(ref clsXML oXML)
        {
            oXML.InitializeWriter();
            oXML.WriteProperty("Version", "AGCSW");
            oXML.WriteProperty("ControlTag", mp_sControlTag);
            oXML.WriteProperty("AddMode", mp_yAddMode);
            oXML.WriteProperty("AddDurationInterval", mp_yAddDurationInterval);
            oXML.WriteProperty("AllowAdd", mp_bAllowAdd);
            oXML.WriteProperty("AllowColumnMove", mp_bAllowColumnMove);
            oXML.WriteProperty("AllowColumnSize", mp_bAllowColumnSize);
            oXML.WriteProperty("AllowEdit", mp_bAllowEdit);
            oXML.WriteProperty("AllowPredecessorAdd", mp_bAllowPredecessorAdd);
            oXML.WriteProperty("AllowRowMove", mp_bAllowRowMove);
            oXML.WriteProperty("AllowRowSize", mp_bAllowRowSize);
            oXML.WriteProperty("AllowSplitterMove", mp_bAllowSplitterMove);
            oXML.WriteProperty("AllowTimeLineScroll", mp_bAllowTimeLineScroll);
            oXML.WriteProperty("EnforcePredecessors", mp_bEnforcePredecessors);
            oXML.WriteProperty("CurrentLayer", mp_sCurrentLayer);
            oXML.WriteProperty("CurrentView", mp_sCurrentView);
            oXML.WriteProperty("DoubleBuffering", mp_bDoubleBuffering);
            oXML.WriteProperty("ErrorReports", mp_yErrorReports);
            oXML.WriteProperty("LayerEnableObjects", mp_yLayerEnableObjects);
            oXML.WriteProperty("MinColumnWidth", mp_lMinColumnWidth);
            oXML.WriteProperty("MinRowHeight", mp_lMinRowHeight);
            oXML.WriteProperty("ScrollBarBehaviour", mp_yScrollBarBehaviour);
            oXML.WriteProperty("SelectedCellIndex", mp_lSelectedCellIndex);
            oXML.WriteProperty("SelectedColumnIndex", mp_lSelectedColumnIndex);
            oXML.WriteProperty("SelectedPercentageIndex", mp_lSelectedPercentageIndex);
            oXML.WriteProperty("SelectedPredecessorIndex", mp_lSelectedPredecessorIndex);
            oXML.WriteProperty("SelectedRowIndex", mp_lSelectedRowIndex);
            oXML.WriteProperty("SelectedTaskIndex", mp_lSelectedTaskIndex);
            oXML.WriteProperty("TreeviewColumnIndex", mp_lTreeviewColumnIndex);
            oXML.WriteProperty("TimeBlockBehaviour", mp_yTimeBlockBehaviour);
            oXML.WriteProperty("TierAppearanceScope", mp_yTierAppearanceScope);
            oXML.WriteProperty("TierFormatScope", mp_yTierFormatScope);
            oXML.WriteProperty("TimeLineScrollBarScope", mp_yTimeLineScrollBarScope);
            oXML.WriteProperty("ProgressLineScope", mp_yProgressLineScope);
            oXML.WriteProperty("PredecessorMode", mp_yPredecessorMode);
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteProperty("Image", ref mp_oImage);
            oXML.WriteProperty("ImageTag", mp_sImageTag);
            oXML.WriteObject(Configuration.GetXML());
            oXML.WriteObject(Styles.GetXML());
            oXML.WriteObject(Rows.GetXML());
            oXML.WriteObject(Columns.GetXML());
            oXML.WriteObject(Layers.GetXML());
            oXML.WriteObject(Tasks.GetXML());
            oXML.WriteObject(Predecessors.GetXML());
            oXML.WriteObject(TierAppearance.GetXML());////Must go before Views
            oXML.WriteObject(TierFormat.GetXML()); ////Must go before Views
            oXML.WriteObject(TimeLineScrollBar.GetXML()); ////Must go before Views
            oXML.WriteObject(ProgressLine.GetXML()); ////Must go before Views
            oXML.WriteObject(Views.GetXML()); ////*********Views
            oXML.WriteObject(TimeBlocks.GetXML());
            oXML.WriteObject(TimeBlocks.CP_GetXML());
            oXML.WriteObject(Percentages.GetXML());
            oXML.WriteObject(Splitter.GetXML());
            oXML.WriteObject(Treeview.GetXML());
            oXML.WriteObject(ScrollBarSeparator.GetXML());
            oXML.WriteObject(VerticalScrollBar.GetXML());
            oXML.WriteObject(HorizontalScrollBar.GetXML());
        }

        private void mp_ReadXML(ref clsXML oXML)
        {
            string sVersion = "";
            Clear();
            oXML.InitializeReader();
            oXML.ReadProperty("Version", ref sVersion);
            oXML.ReadProperty("ControlTag", ref mp_sControlTag);
            oXML.ReadProperty("AddMode", ref mp_yAddMode);
            oXML.ReadProperty("AddDurationInterval", ref mp_yAddDurationInterval);
            oXML.ReadProperty("AllowAdd", ref mp_bAllowAdd);
            oXML.ReadProperty("AllowColumnMove", ref mp_bAllowColumnMove);
            oXML.ReadProperty("AllowColumnSize", ref mp_bAllowColumnSize);
            oXML.ReadProperty("AllowEdit", ref mp_bAllowEdit);
            oXML.ReadProperty("AllowPredecessorAdd", ref mp_bAllowPredecessorAdd);
            oXML.ReadProperty("AllowRowMove", ref mp_bAllowRowMove);
            oXML.ReadProperty("AllowRowSize", ref mp_bAllowRowSize);
            oXML.ReadProperty("AllowSplitterMove", ref mp_bAllowSplitterMove);
            oXML.ReadProperty("AllowTimeLineScroll", ref mp_bAllowTimeLineScroll);
            oXML.ReadProperty("EnforcePredecessors", ref mp_bEnforcePredecessors);
            oXML.ReadProperty("CurrentLayer", ref mp_sCurrentLayer);
            oXML.ReadProperty("CurrentView", ref mp_sCurrentView);
            oXML.ReadProperty("DoubleBuffering", ref mp_bDoubleBuffering);
            oXML.ReadProperty("ErrorReports", ref mp_yErrorReports);
            oXML.ReadProperty("LayerEnableObjects", ref mp_yLayerEnableObjects);
            oXML.ReadProperty("MinColumnWidth", ref mp_lMinColumnWidth);
            oXML.ReadProperty("MinRowHeight", ref mp_lMinRowHeight);
            oXML.ReadProperty("ScrollBarBehaviour", ref mp_yScrollBarBehaviour);
            oXML.ReadProperty("SelectedCellIndex", ref mp_lSelectedCellIndex);
            oXML.ReadProperty("SelectedColumnIndex", ref mp_lSelectedColumnIndex);
            oXML.ReadProperty("SelectedPercentageIndex", ref mp_lSelectedPercentageIndex);
            oXML.ReadProperty("SelectedPredecessorIndex", ref mp_lSelectedPredecessorIndex);
            oXML.ReadProperty("SelectedRowIndex", ref mp_lSelectedRowIndex);
            oXML.ReadProperty("SelectedTaskIndex", ref mp_lSelectedTaskIndex);
            oXML.ReadProperty("TreeviewColumnIndex", ref mp_lTreeviewColumnIndex);
            oXML.ReadProperty("TimeBlockBehaviour", ref mp_yTimeBlockBehaviour);
            oXML.ReadProperty("TierAppearanceScope", ref mp_yTierAppearanceScope);
            oXML.ReadProperty("TierFormatScope", ref mp_yTierFormatScope);
            oXML.ReadProperty("TimeLineScrollBarScope", ref mp_yTimeLineScrollBarScope);
            oXML.ReadProperty("ProgressLineScope", ref mp_yProgressLineScope);
            oXML.ReadProperty("PredecessorMode", ref mp_yPredecessorMode);
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            oXML.ReadProperty("Image", ref mp_oImage);
            oXML.ReadProperty("ImageTag", ref mp_sImageTag);
            Configuration.SetXML(oXML.ReadObject("Configuration"));
            Styles.SetXML(oXML.ReadObject("Styles"));
            Rows.SetXML(oXML.ReadObject("Rows"));
            Columns.SetXML(oXML.ReadObject("Columns"));
            Layers.SetXML(oXML.ReadObject("Layers"));
            Tasks.SetXML(oXML.ReadObject("Tasks"));
            Predecessors.SetXML(oXML.ReadObject("Predecessors"));
            TierAppearance.SetXML(oXML.ReadObject("TierAppearance")); ////Must go before Views
            TierFormat.SetXML(oXML.ReadObject("TierFormat")); ////Must go before Views
            TimeLineScrollBar.SetXML(oXML.ReadObject("TimeLineScrollBar")); ////Must go before Views
            ProgressLine.SetXML(oXML.ReadObject("ProgressLine")); ////Must go before Views
            Views.SetXML(oXML.ReadObject("Views")); ////*********Views
            TimeBlocks.SetXML(oXML.ReadObject("TimeBlocks"));
            TimeBlocks.CP_SetXML(oXML.ReadObject("CP_TimeBlocks"));
            Percentages.SetXML(oXML.ReadObject("Percentages"));
            Splitter.SetXML(oXML.ReadObject("Splitter"));
            Treeview.SetXML(oXML.ReadObject("Treeview"));
            ScrollBarSeparator.SetXML(oXML.ReadObject("ScrollBarSeparator"));
            VerticalScrollBar.SetXML(oXML.ReadObject("VerticalScrollBar"));
            HorizontalScrollBar.SetXML(oXML.ReadObject("HorizontalScrollBar"));
            StyleIndex = mp_sStyleIndex;
            Rows.UpdateTree();
            CurrentView = mp_sCurrentView;
            mp_oCurrentView.TimeLine.Position(mp_oCurrentView.TimeLine.StartDate);
        }

        internal void mp_ErrorReport(SYS_ERRORS ErrNumber, string ErrDescription, string ErrSource)
	{
		if (mp_yErrorReports == E_REPORTERRORS.RE_MSGBOX)
        {
			MessageBox.Show(ErrNumber + ": " + ErrDescription, ErrSource, MessageBoxButton.OK, MessageBoxImage.Error);
		}
		else if (mp_yErrorReports == E_REPORTERRORS.RE_HIDE)
		{
		}
		else if (mp_yErrorReports == E_REPORTERRORS.RE_RAISE)
		{
            AGError ex = new AGError(ErrNumber.ToString() + ": " + ErrDescription + " - " + ErrSource);
            ex.ErrNumber = (int)ErrNumber;
            ex.ErrDescription = ErrDescription;
            ex.ErrSource = ErrSource;
            throw ex;
        }
        else if (mp_yErrorReports == E_REPORTERRORS.RE_RAISEEVENT)
        {
            ErrorEventArgs.Clear();
            ErrorEventArgs.Number = (int)ErrNumber;
            ErrorEventArgs.Description = ErrDescription;
            ErrorEventArgs.Source = ErrSource;
            FireActiveGanttError();
        }
	}

        public E_REPORTERRORS ErrorReports
        {
            get { return mp_yErrorReports; }
            set { mp_yErrorReports = value; }
        }

        public System.Windows.Input.Key PredecessorAddModeKey
        {
            get { return mp_oPredecessorAddModeKey; }
            set { mp_oPredecessorAddModeKey = value; }
        }

        public string CurrentLayer
        {
            get { return mp_sCurrentLayer; }
            set { mp_sCurrentLayer = value; }
        }

        public string CurrentView
        {
            get { return mp_sCurrentView; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "0";
                }
                mp_oCurrentView = Views.FItem(value);
                mp_sCurrentView = value;
            }
        }

        public clsView CurrentViewObject
        {
            get { return mp_oCurrentView; }
        }

        public clsToolTip ControlToolTip
        {
            get { return MouseKeyboardEvents.mp_oToolTip; }
        }

        public E_SCROLLBEHAVIOUR ScrollBarBehaviour
        {
            get { return mp_yScrollBarBehaviour; }
            set { mp_yScrollBarBehaviour = value; }
        }

        public E_OBJECTSCOPE TierAppearanceScope
        {
            get { return mp_yTierAppearanceScope; }
            set { mp_yTierAppearanceScope = value; }
        }

        public E_OBJECTSCOPE TierFormatScope
        {
            get { return mp_yTierFormatScope; }
            set { mp_yTierFormatScope = value; }
        }

        public E_OBJECTSCOPE TimeLineScrollBarScope
        {
            get { return mp_yTimeLineScrollBarScope; }
            set { mp_yTimeLineScrollBarScope = value; }
        }

        public E_OBJECTSCOPE ProgressLineScope
        {
            get { return mp_yProgressLineScope; }
            set { mp_yProgressLineScope = value; }
        }

        public E_TIMEBLOCKBEHAVIOUR TimeBlockBehaviour
        {
            get { return mp_yTimeBlockBehaviour; }
            set { mp_yTimeBlockBehaviour = value; }
        }

        public int SelectedTaskIndex
        {
            get { return mp_lSelectedTaskIndex; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value > Tasks.Count)
                {
                    value = Tasks.Count;
                }
                mp_lSelectedTaskIndex = value;
            }
        }

        public int SelectedColumnIndex
        {
            get { return mp_lSelectedColumnIndex; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value > Columns.Count)
                {
                    value = Columns.Count;
                }
                mp_lSelectedColumnIndex = value;
            }
        }

        public int SelectedRowIndex
        {
            get { return mp_lSelectedRowIndex; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value > Rows.Count)
                {
                    value = Rows.Count;
                }
                mp_lSelectedRowIndex = value;
            }
        }

        public int SelectedCellIndex
        {
            get { return mp_lSelectedCellIndex; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value > Columns.Count)
                {
                    value = Columns.Count;
                }
                mp_lSelectedCellIndex = value;
            }
        }

        public int SelectedPercentageIndex
        {
            get { return mp_lSelectedPercentageIndex; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value > Percentages.Count)
                {
                    value = Percentages.Count;
                }
                mp_lSelectedPercentageIndex = value;
            }
        }

        public int SelectedPredecessorIndex
        {
            get { return mp_lSelectedPredecessorIndex; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value > Percentages.Count)
                {
                    value = Percentages.Count;
                }
                mp_lSelectedPredecessorIndex = value;
            }
        }

        public int TreeviewColumnIndex
        {
            get
            {
                if (Columns.Count == 0)
                {
                    return 0;
                }
                else if (mp_lTreeviewColumnIndex > Columns.Count)
                {
                    return 0;
                }
                else if (mp_lTreeviewColumnIndex < 0)
                {
                    return 0;
                }
                else
                {
                    return mp_lTreeviewColumnIndex;
                }
            }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value > Columns.Count)
                {
                    value = Columns.Count;
                }
                mp_lTreeviewColumnIndex = value;
            }
        }

        public string StyleIndex
        {
            get
            {
                if (mp_sStyleIndex == "DS_CONTROL")
                {
                    return "";
                }
                else
                {
                    return mp_sStyleIndex;
                }
            }
            set
            {
                value = value.Trim();
                if (value.Length == 0)
                    value = "DS_CONTROL";
                mp_sStyleIndex = value;
                mp_oStyle = Styles.FItem(value);
            }
        }

        public new clsStyle Style
        {
            get { return mp_oStyle; }
        }

        public Image Image
        {
            get { return mp_oImage; }
            set { mp_oImage = value; }
        }

        public string ImageTag
        {
            get { return mp_sImageTag; }
            set { mp_sImageTag = value; }
        }

        public System.Globalization.CultureInfo Culture
        {
            get { return mp_oCulture; }
            set { mp_oCulture = value; }
        }

        public void ClearSelections()
        {
            mp_oTextBox.Terminate();
            mp_lSelectedTaskIndex = 0;
            mp_lSelectedColumnIndex = 0;
            mp_lSelectedRowIndex = 0;
            mp_lSelectedCellIndex = 0;
            mp_lSelectedPercentageIndex = 0;
            mp_lSelectedPredecessorIndex = 0;
        }

        public void Clear()
        {
            mp_oTextBox.Terminate();
            Tasks.Clear();
            Rows.Clear();
            Styles.Clear();
            Layers.Clear();
            Columns.Clear();
            TimeBlocks.Clear();
            Views.Clear();
            if (Printer != null)
            {
                Printer.Clear();
            }
        }

        public void CheckPredecessors()
        {
            int i = 0;
            clsTask oTask;
            for (i = 1; i <= Tasks.Count; i++)
            {
                oTask = (clsTask)Tasks.oCollection.m_oReturnArrayElement(i);
                oTask.mp_bWarning = false;
            }
            if (Predecessors.Count == 0)
            {
                return;
            }
            clsPredecessor oPredecessor;
            for (i = 1; i <= Predecessors.Count; i++)
            {
                oPredecessor = (clsPredecessor)Predecessors.oCollection.m_oReturnArrayElement(i);
                oPredecessor.Check(mp_yPredecessorMode);
            }
        }

        public bool EnforcePredecessors
        {
            get { return mp_bEnforcePredecessors; }
            set { mp_bEnforcePredecessors = value; }
        }

        public E_PREDECESSORMODE PredecessorMode
        {
            get { return mp_yPredecessorMode; }
            set { mp_yPredecessorMode = value; }
        }

        public void ApplyTemplate(E_CONTROLTEMPLATE ControlTemplate, E_OBJECTTEMPLATE ObjectTemplate)
        {
            mp_yControlTemplate = ControlTemplate;
            mp_yObjectTemplate = ObjectTemplate;
            Templates.g_ApplyTemplate(this, ControlTemplate, ObjectTemplate);
        }

        public void ApplyTemplateSolid(ControlTemplateSolid ControlTemplate, E_OBJECTTEMPLATE ObjectTemplate)
        {
            mp_yControlTemplate = E_CONTROLTEMPLATE.STC_NONE;
            mp_yObjectTemplate = ObjectTemplate;
            Templates.g_ApplyTemplate_Solid(this, ControlTemplate, ObjectTemplate);
        }

        public void ApplyTemplateGradient(ControlTemplateGradient ControlTemplate, E_OBJECTTEMPLATE ObjectTemplate)
        {
            mp_yControlTemplate = E_CONTROLTEMPLATE.STC_NONE;
            mp_yObjectTemplate = ObjectTemplate;
            Templates.g_ApplyTemplate_Gradient(this, ControlTemplate, ObjectTemplate);
        }

        public E_CONTROLTEMPLATE ControlTemplate
        {
            get { return mp_yControlTemplate; }
        }

        public E_OBJECTTEMPLATE ObjectTemplate
        {
            get { return mp_yObjectTemplate; }
        }


        public void ForceEndTextEdit()
        {
            mp_oTextBox.Terminate();
        }

        public string ModuleCompletePath
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().Location; }
        }

        public string Version
        {
            get
            {
                System.Reflection.Assembly ai = System.Reflection.Assembly.GetExecutingAssembly();
                return ai.GetName().Version.ToString();
            }
        }

        public void SaveToImage(string Path)
        {
            System.IO.FileStream fs = new System.IO.FileStream(Path, System.IO.FileMode.Create);
            RenderTargetBitmap bmp = new RenderTargetBitmap(clsG.Width(), clsG.Height(), 96, 96, PixelFormats.Pbgra32);
            oCanvas.Measure(new System.Windows.Size(clsG.Width(), clsG.Height()));
            //oCanvas.Arrange(New Rect(0, 0, clsG.Width, clsG.Height))
            oCanvas.UpdateLayout();
            bmp.Render(oCanvas);
            BitmapEncoder encoder = new TiffBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            encoder.Save(fs);
            fs.Close();
            //Dim oBitmap As System.Drawing.Bitmap
            //oBitmap = New System.Drawing.Bitmap(clsG.Width, clsG.Height)
            //mp_oGraphics = System.Drawing.Graphics.FromImage(oBitmap)
            //mp_Draw()
            //oBitmap.Save(Path, Format)
        }

        public void AboutBox()
        {
            fAbout oForm = new fAbout();
            oForm.ShowDialog();
        }

        internal void mp_Redraw()
        {
            this.InvalidateVisual();
        }

        internal void mp_RedrawOtherThread()
        {
            if (this.Dispatcher.HasShutdownFinished == false)
            {
                System.Diagnostics.Debug.WriteLine("Exiting before start");
                return;
            }
            System.Diagnostics.Debug.WriteLine("Starting");
            mp_RedrawEventHandler oDraw = new mp_RedrawEventHandler(mp_Redraw);
            this.Dispatcher.Invoke(oDraw);
            System.Diagnostics.Debug.WriteLine("Ending");
        }

        public void Redraw()
        {
            try
            {
                mp_Redraw();
            }
            catch 
            {
                mp_RedrawOtherThread();
            }
        }

        public string PrinterErrorMessage
        {
            get
            {
                return mp_sPrinterErrorMessage;
            }
        }

        public bool AllowSplitterMove
        {
            get { return mp_bAllowSplitterMove; }
            set { mp_bAllowSplitterMove = value; }
        }

        public bool AllowPredecessorAdd
        {
            get { return mp_bAllowPredecessorAdd; }
            set { mp_bAllowPredecessorAdd = value; }
        }

        public bool AllowAdd
        {
            get { return mp_bAllowAdd; }
            set { mp_bAllowAdd = value; }
        }

        public bool AllowEdit
        {
            get { return mp_bAllowEdit; }
            set { mp_bAllowEdit = value; }
        }

        public bool AllowColumnSize
        {
            get { return mp_bAllowColumnSize; }
            set { mp_bAllowColumnSize = value; }
        }

        public bool AllowRowSize
        {
            get { return mp_bAllowRowSize; }
            set { mp_bAllowRowSize = value; }
        }

        public bool AllowRowMove
        {
            get { return mp_bAllowRowMove; }
            set { mp_bAllowRowMove = value; }
        }

        public bool AllowColumnMove
        {
            get { return mp_bAllowColumnMove; }
            set { mp_bAllowColumnMove = value; }
        }

        public bool AllowTimeLineScroll
        {
            get { return mp_bAllowTimeLineScroll; }
            set { mp_bAllowTimeLineScroll = value; }
        }

        public E_ADDMODE AddMode
        {
            get { return mp_yAddMode; }
            set { mp_yAddMode = value; }
        }

        public E_INTERVAL AddDurationInterval
        {
            get { return mp_yAddDurationInterval; }
            set
            {
                if (!(value == E_INTERVAL.IL_SECOND | value == E_INTERVAL.IL_MINUTE | value == E_INTERVAL.IL_HOUR | value == E_INTERVAL.IL_DAY))
                {
                    mp_ErrorReport(SYS_ERRORS.INVALID_DURATION_INTERVAL, "Interval is invalid for a duration", "ActiveGanttCSWCtl.Set_AddDurationInterval");
                    return;
                }
                mp_yAddDurationInterval = value;
            }
        }

        public E_LAYEROBJECTENABLE LayerEnableObjects
        {
            get { return mp_yLayerEnableObjects; }
            set { mp_yLayerEnableObjects = value; }
        }

        public bool DoubleBuffering
        {
            get { return mp_bDoubleBuffering; }
            set { mp_bDoubleBuffering = value; }
        }

        public int MinRowHeight
        {
            get { return mp_lMinRowHeight; }
            set { mp_lMinRowHeight = value; }
        }

        public int MinColumnWidth
        {
            get { return mp_lMinColumnWidth; }
            set { mp_lMinColumnWidth = value; }
        }

        public string ControlTag
        {
            get { return mp_sControlTag; }
            set { mp_sControlTag = value; }
        }

        ////

        private void mp_CHKPXPStart(Color clrBackground)
        {
            clsG.mp_ClipRegion(0, 0, clsG.Width(), clsG.Height(), false);
            clsG.mp_DrawLine(0, 0, clsG.Width(), clsG.Height(), GRE_LINETYPE.LT_FILLED, clrBackground, GRE_LINEDRAWSTYLE.LDS_SOLID);
        }

        private void mp_CHKPXPLines()
        {
            mp_CHKPXPStart(Color.FromArgb(255, 255, 255, 255));
            clsG.mp_DrawLine(20, 10, 60, 10, GRE_LINETYPE.LT_NORMAL, Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.mp_DrawLine(30, 20, 30, 70, GRE_LINETYPE.LT_NORMAL, Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.mp_DrawLine(40, 40, 60, 60, GRE_LINETYPE.LT_BORDER, Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.mp_DrawLine(70, 70, 90, 90, GRE_LINETYPE.LT_FILLED, Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
        }

        private void mp_CHKPXPButtons()
        {
            mp_CHKPXPStart(Color.FromArgb(255, 255, 0, 0));
            //clsG.DrawButton(new Rect(20, 20, 100, 50), E_SCROLLBUTTONSTATE.BS_NORMAL);
            clsG.mp_DrawItem(50, 50, 100, 100, "", "", false, null, 100, 100,
            Styles.FItem("DS_TICKMARKAREA"));
        }

        private void mp_CHKPXPArrows()
        {
            mp_CHKPXPStart(Color.FromArgb(255, 255, 255, 255));
            clsG.mp_DrawArrow(100, 120, GRE_ARROWDIRECTION.AWD_RIGHT, 20, Color.FromArgb(255, 0, 0, 0));
            clsG.mp_DrawArrow(50, 120, GRE_ARROWDIRECTION.AWD_LEFT, 20, Color.FromArgb(255, 0, 0, 0));
            clsG.mp_DrawArrow(100, 150, GRE_ARROWDIRECTION.AWD_UP, 20, Color.FromArgb(255, 0, 0, 0));
            clsG.mp_DrawArrow(50, 170, GRE_ARROWDIRECTION.AWD_DOWN, 20, Color.FromArgb(255, 0, 0, 0));
        }

        private void mp_CHKPXPFigures()
        {
            mp_CHKPXPStart(Color.FromArgb(255, 255, 255, 255));
            clsG.mp_DrawFigure(200, 20, 20, 20, GRE_FIGURETYPE.FT_ARROWDOWN, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.mp_DrawFigure(230, 20, 20, 20, GRE_FIGURETYPE.FT_ARROWUP, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.mp_DrawFigure(200, 60, 20, 20, GRE_FIGURETYPE.FT_CIRCLEARROWDOWN, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.mp_DrawFigure(230, 60, 20, 20, GRE_FIGURETYPE.FT_CIRCLEARROWUP, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.mp_DrawFigure(200, 100, 20, 20, GRE_FIGURETYPE.FT_CIRCLETRIANGLEDOWN, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.mp_DrawFigure(230, 100, 20, 20, GRE_FIGURETYPE.FT_CIRCLETRIANGLEUP, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.mp_DrawFigure(200, 140, 20, 20, GRE_FIGURETYPE.FT_PROJECTDOWN, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.mp_DrawFigure(230, 140, 20, 20, GRE_FIGURETYPE.FT_PROJECTUP, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.mp_DrawFigure(200, 180, 20, 20, GRE_FIGURETYPE.FT_SMALLPROJECTDOWN, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.mp_DrawFigure(230, 180, 20, 20, GRE_FIGURETYPE.FT_SMALLPROJECTUP, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.mp_DrawFigure(200, 220, 20, 20, GRE_FIGURETYPE.FT_TRIANGLEDOWN, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.mp_DrawFigure(230, 220, 20, 20, GRE_FIGURETYPE.FT_TRIANGLEUP, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.mp_DrawFigure(200, 260, 20, 20, GRE_FIGURETYPE.FT_TRIANGLELEFT, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.mp_DrawFigure(230, 260, 20, 20, GRE_FIGURETYPE.FT_TRIANGLERIGHT, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.mp_DrawFigure(200, 300, 20, 20, GRE_FIGURETYPE.FT_SQUARE, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.mp_DrawFigure(230, 300, 20, 20, GRE_FIGURETYPE.FT_CIRCLE, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.mp_DrawFigure(200, 340, 20, 20, GRE_FIGURETYPE.FT_DIAMOND, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.mp_DrawFigure(230, 340, 20, 20, GRE_FIGURETYPE.FT_RECTANGLE, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);

            clsG.mp_DrawFigure(200, 380, 20, 20, GRE_FIGURETYPE.FT_NONE, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
            clsG.mp_DrawFigure(230, 380, 20, 20, GRE_FIGURETYPE.FT_NONE, Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_SOLID);
        }

        private void mp_CHKPXPGradients()
        {
            mp_CHKPXPStart(Color.FromArgb(255, 255, 255, 255));
            clsG.mp_GradientFill(20, 250, 120, 320, Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 0, 0, 255), GRE_GRADIENTFILLMODE.GDT_HORIZONTAL);
            clsG.mp_GradientFill(20, 340, 120, 400, Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 0, 0, 255), GRE_GRADIENTFILLMODE.GDT_VERTICAL);
        }

        private void mp_CHKPXPText()
        {
            mp_CHKPXPStart(Color.FromArgb(255, 255, 255, 255));
            clsTextFlags oFlags = new clsTextFlags(this);
            oFlags.HorizontalAlignment = GRE_HORIZONTALALIGNMENT.HAL_CENTER;
            oFlags.VerticalAlignment = GRE_VERTICALALIGNMENT.VAL_CENTER;
            //clsG.mp_DrawTextEx(300, 100, 400, 400, "M Hello World", oFlags, Color.FromArgb(255, 0, 0, 0), New Font("Arial", 10), True)
            clsG.mp_DrawTextEx(200, 100, 400, 300, "M Hello World", oFlags, Color.FromArgb(255, 0, 0, 0), new Font("Arial", 10), true);
        }

        private void mp_CHKPXPHatch()
        {
            mp_CHKPXPStart(Color.FromArgb(255, 255, 255, 255));
            int i = 0;
            int j = 0;
            j = 0;
            for (i = 0; i <= 9; i++)
            {
                clsG.mp_HatchFill(0, j * 30, 100, (j * 30) + 20, Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 255, 255), (GRE_HATCHSTYLE)i);
                j = j + 1;
            }
            j = 0;
            for (i = 10; i <= 19; i++)
            {
                clsG.mp_HatchFill(120, j * 30, 220, (j * 30) + 20, Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 255, 255), (GRE_HATCHSTYLE)i);
                j = j + 1;
            }

            j = 0;
            for (i = 20; i <= 29; i++)
            {
                clsG.mp_HatchFill(240, j * 30, 340, (j * 30) + 20, Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 255, 255), (GRE_HATCHSTYLE)i);
                j = j + 1;
            }
            j = 0;
            for (i = 30; i <= 39; i++)
            {
                clsG.mp_HatchFill(360, j * 30, 460, (j * 30) + 20, Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 255, 255), (GRE_HATCHSTYLE)i);
                j = j + 1;
            }
            j = 0;
            for (i = 40; i <= 49; i++)
            {
                clsG.mp_HatchFill(480, j * 30, 580, (j * 30) + 20, Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 255, 255), (GRE_HATCHSTYLE)i);
                j = j + 1;
            }
            j = 0;
            for (i = 50; i <= 52; i++)
            {
                clsG.mp_HatchFill(600, j * 30, 700, (j * 30) + 20, Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 255, 255), (GRE_HATCHSTYLE)i);
                j = j + 1;
            }
        }

        internal bool ShowAbout()
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == false)
            {
                return false;
            }
            Microsoft.Win32.RegistryKey oKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("Licenses\\BF5980F3-B7A2-4fcf-9E12-575D378FDFA7");
            if ((oKey != null))
            {
                string sDefault = (string)oKey.GetValue("");
                if ((sDefault != null))
                {
                    if (string.Compare("15EFB0FA-E747-46ed-993F-D76EFF641B02", sDefault, false) == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }


    public class AGError : Exception
    {
        private string mp_sErrDescription;
        private int mp_lErrNumber;
        private string mp_sErrSource;

        public AGError() : base() { }
        public AGError(string s) : base(s) { }
        public AGError(string s, Exception ex) : base(s, ex) { }

        public string ErrDescription
        {
            get
            {
                return mp_sErrDescription;
            }
            set
            {
                mp_sErrDescription = value;
            }
        }

        public int ErrNumber
        {
            get
            {
                return mp_lErrNumber;
            }
            set
            {
                mp_lErrNumber = value;
            }
        }

        public string ErrSource
        {
            get
            {
                return mp_sErrSource;
            }
            set
            {
                mp_sErrSource = value;
            }
        }
    }

}