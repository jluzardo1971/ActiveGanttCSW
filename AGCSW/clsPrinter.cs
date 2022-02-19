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
using System.Windows.Media;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Xps.Packaging;
using System.IO;
using System.IO.Packaging;
using System.Printing;
using System.Windows.Xps;

namespace AGCSW
{
    public class clsPrinter
    {

        private enum E_PRINTINGOPERATIONTYPE
        {
            PT_SINGLEPAGE = 1,
            PT_RANGE = 2,
            PT_ALL = 3
        }

        private enum E_TRANSFORMATIONTYPE
        {
            TT_TRANSLATE = 0,
            TT_SCALE = 1
        }

        private class S_Transformation
        {
            public E_TRANSFORMATIONTYPE yType;
            public double X;
            public double Y;
        }

        private ActiveGanttCSWCtl mp_oControl;
        private DateTime mp_dtStartDate;
        private DateTime mp_dtEndDate;
        private DateTime mp_dtPrintStartDateBuffer;
        private int mp_lSplitterPositionBuffer;
        private int mp_lFirstVisibleRowBuffer;
        private clsView mp_oView;
        private GRE_ORIENTATION mp_yOrientation;
        internal double mp_dPageWidth;
        internal double mp_dPageHeight;
        private double mp_dActualPageWidth;
        private double mp_dActualPageHeight;
        private int mp_lPages;
        private int mp_lPageNumber;
        private bool mp_bInitialized;
        private int mp_lStartRow;
        private int mp_lEndRow;
        private int mp_lXAxisPages;
        private int mp_lYAxisPages;
        private float mp_fScale;
        private bool mp_bKeepRowsTogether;
        private bool mp_bKeepTimeIntervalsTogether;
        private E_INTERVAL mp_yInterval;
        private int mp_lFactor;
        private bool mp_bKeepColumnsTogether;
        private bool mp_bShowAllColumns;
        private bool mp_bHeadingsInEveryPage;
        private bool mp_bColumnsInEveryPage;

        private int mp_lColumns;
        private List<int> mp_aVertical;
        private List<int> mp_aHorizontal;

        private string mp_sPrinterName;
        private GRE_PAPERTYPE mp_yPaperType;
        private GRE_PRINTERRESOLUTION mp_yPrinterResolution;
        private int mp_lHorizontalDPI;
        private int mp_lVerticalDPI;
        private int mp_lMarginLeft;
        private int mp_lMarginTop;
        private int mp_lMarginRight;
        private int mp_lMarginBottom;
        private int mp_lHardMarginX;
        private int mp_lHardMarginY;
        private PageDimensions mp_oPageDimensions;
        private List<S_Transformation> mp_aTransformations;

        internal clsPrinter(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            mp_oPageDimensions = new PageDimensions();
            mp_sPrinterName = LocalPrintServer.GetDefaultPrintQueue().Name;
            mp_aTransformations = new List<S_Transformation>();

            Clear();
        }

        //Public ReadOnly Property PrintDocument As PrintDocument
        //    Get
        //        Return mp_oPrinter
        //    End Get
        //End Property

        public string PrinterName
        {
            get { return mp_sPrinterName; }
            set
            {
                mp_sPrinterName = value;
                mp_QueryPrinter();
            }
        }

        public GRE_PRINTERRESOLUTION PrinterResolution
        {
            get { return mp_yPrinterResolution; }
            set { mp_yPrinterResolution = value; }
        }

        public int HorizontalDPI
        {
            get { return mp_lHorizontalDPI; }
            set { mp_lHorizontalDPI = value; }
        }

        public int VerticalDPI
        {
            get { return mp_lVerticalDPI; }
            set { mp_lVerticalDPI = value; }
        }

        public GRE_PAPERTYPE PaperType
        {
            get { return mp_yPaperType; }
            set
            {
                mp_yPaperType = value;
                mp_QueryPrinter();
            }
        }

        public GRE_ORIENTATION Orientation
        {
            get { return mp_yOrientation; }
            set { mp_yOrientation = value; }
        }

        public int MarginLeft
        {
            get { return mp_lMarginLeft; }
            set
            {
                mp_lMarginLeft = value;
                mp_Calculate();
            }
        }

        public int MarginTop
        {
            get { return mp_lMarginTop; }
            set
            {
                mp_lMarginTop = value;
                mp_Calculate();
            }
        }

        public int MarginRight
        {
            get { return mp_lMarginRight; }
            set
            {
                mp_lMarginRight = value;
                mp_Calculate();
            }
        }

        public int MarginBottom
        {
            get { return mp_lMarginBottom; }
            set
            {
                mp_lMarginBottom = value;
                mp_Calculate();
            }
        }

        public float Scale
        {
            get { return mp_fScale; }
            set
            {
                mp_fScale = value;
                mp_Calculate();
            }
        }

        public bool HeadingsInEveryPage
        {
            get { return mp_bHeadingsInEveryPage; }
            set
            {
                mp_bHeadingsInEveryPage = value;
                mp_Calculate();
            }
        }

        public bool ColumnsInEveryPage
        {
            get { return mp_bColumnsInEveryPage; }
            set
            {
                mp_bColumnsInEveryPage = value;
                mp_Calculate();
            }
        }

        public int Columns
        {
            get { return mp_lColumns; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                mp_lColumns = value;
                mp_Calculate();
            }
        }

        public bool KeepRowsTogether
        {
            get { return mp_bKeepRowsTogether; }
            set
            {
                mp_bKeepRowsTogether = value;
                mp_Calculate();
            }
        }

        public bool KeepColumnsTogether
        {
            get { return mp_bKeepColumnsTogether; }
            set
            {
                mp_bKeepColumnsTogether = value;
                mp_Calculate();
            }
        }

        public bool KeepTimeIntervalsTogether
        {
            get { return mp_bKeepTimeIntervalsTogether; }
            set
            {
                mp_bKeepTimeIntervalsTogether = value;
                mp_Calculate();
            }
        }

        public bool ShowAllColumns
        {
            get { return mp_bShowAllColumns; }
            set
            {
                mp_bShowAllColumns = value;
                if (mp_bShowAllColumns == true)
                {
                    if (mp_lSplitterPositionBuffer == -1)
                    {
                        mp_lSplitterPositionBuffer = mp_oControl.Splitter.Position;
                    }
                    mp_oControl.Splitter.Position = mp_oControl.Columns.Width + mp_oControl.Splitter.Offset;
                }
                else if (mp_bShowAllColumns == false)
                {
                    if (mp_lSplitterPositionBuffer != -1)
                    {
                        mp_oControl.Splitter.Position = mp_lSplitterPositionBuffer;
                        mp_lSplitterPositionBuffer = -1;
                    }
                }
                mp_Calculate();
            }
        }

        public E_INTERVAL Interval
        {
            get { return mp_yInterval; }
            set
            {
                mp_yInterval = value;
                mp_Calculate();
            }
        }

        public int Factor
        {
            get { return mp_lFactor; }
            set
            {
                if (value <= 0)
                {
                    value = 1;
                }
                mp_lFactor = value;
                mp_Calculate();
            }
        }

        public int Pages
        {
            get { return mp_lPages; }
        }

        public int XAxisPages
        {
            get { return mp_lXAxisPages; }
        }

        public int YAxisPages
        {
            get { return mp_lYAxisPages; }
        }

        public DateTime PrintAreaEndDate
        {
            get { return mp_dtEndDate; }
        }

        public DateTime PrintAreaStartDate
        {
            get { return mp_dtStartDate; }
        }

        public int StartRow
        {
            get { return mp_lStartRow; }
        }

        public int EndRow
        {
            get { return mp_lEndRow; }
        }

        public int PrintAreaWidth
        {
            get { return mp_oControl.clsG.CustomWidth; }
        }

        public int PrintAreaHeight
        {
            get { return mp_oControl.clsG.CustomHeight; }
        }

        public void Clear()
        {
            mp_dtStartDate = new DateTime();
            mp_dtEndDate = new DateTime();
            mp_dtPrintStartDateBuffer = new DateTime();
            mp_lSplitterPositionBuffer = -1;
            mp_lFirstVisibleRowBuffer = -1;
            mp_oView = null;
            mp_yOrientation = GRE_ORIENTATION.OT_PORTRAIT;
            mp_dPageWidth = 0;
            mp_dPageHeight = 0;
            mp_dActualPageWidth = 0;
            mp_dActualPageHeight = 0;
            mp_lPages = 0;
            mp_lPageNumber = 0;
            mp_bInitialized = false;
            if (mp_oControl.Rows.Count > 0)
            {
                mp_lStartRow = 1;
                mp_lEndRow = mp_oControl.Rows.Count;
            }
            else
            {
                mp_lStartRow = -1;
                mp_lEndRow = -1;
            }
            mp_lXAxisPages = 0;
            mp_lYAxisPages = 0;
            mp_fScale = 1f;
            mp_bKeepRowsTogether = true;
            mp_bKeepTimeIntervalsTogether = false;
            mp_yInterval = E_INTERVAL.IL_MONTH;
            mp_lFactor = 1;
            mp_bKeepColumnsTogether = true;
            mp_bShowAllColumns = true;
            mp_bHeadingsInEveryPage = false;
            mp_bColumnsInEveryPage = false;
            mp_lColumns = 1;
            mp_aVertical = new List<int>();
            mp_aHorizontal = new List<int>();
            //mp_oPrinter = New PrintDocument()
            mp_lMarginLeft = 100;
            mp_lMarginTop = 100;
            mp_lMarginRight = 100;
            mp_lMarginBottom = 100;

            mp_lHorizontalDPI = 600;
            mp_lVerticalDPI = 600;

            mp_QueryPrinter();
        }

        public void GetPagePosition(int PageNumber, ref int Column, ref int Row)
        {
            if (PageNumber < 1 | PageNumber > Pages)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_PAGE, "Invalid PageNumber. PageNumber must be greater than 1 and less than the value of the Pages property.", "ActiveGanttCSWCtl.clsPrinter.GetPagePosition");
                return;
            }
            mp_GetPagePosition(PageNumber, ref Column, ref Row);
            Column = Column + 1;
            Row = Row + 1;
        }

        public int GetPageNumber(int Column, int Row)
        {
            if (Column < 1 | Column > mp_lXAxisPages)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_COLUMN, "Invalid column index. Index must be greater than 1 and less than the value of the XAxisPages property.", "ActiveGanttCSWCtl.clsPrinter.GetPageNumber");
                return -1;
            }
            if (Row < 1 | Row > mp_lYAxisPages)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_COLUMN, "Invalid row index. Index must be greater than 1 and less than the value of the YAxisPages property.", "ActiveGanttCSWCtl.clsPrinter.GetPageNumber");
                return -1;
            }
            if (Row == 1)
            {
                return Column;
            }
            else
            {
                return ((Row - 1) * mp_lXAxisPages) + Column;
            }
        }

        public bool Initialize(DateTime StartDate, DateTime EndDate)
        {
            return Initialize(StartDate, EndDate, -1, -1);
        }

        public bool Initialize(DateTime StartDate, DateTime EndDate, int StartRow = -1)
        {
            return Initialize(StartDate, EndDate, StartRow, -1);
        }

        public bool Initialize(DateTime StartDate, DateTime EndDate, int StartRow = -1, int EndRow = -1)
        {
            mp_oView = mp_oControl.CurrentViewObject;
            mp_dtStartDate = StartDate;
            mp_dtEndDate = EndDate;

            mp_lStartRow = StartRow;
            mp_lEndRow = EndRow;

            if (mp_oControl.Rows.Count == 0)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_NO_ROWS, "No rows to print.", "ActiveGanttCSWCtl.clsPrinter.Initialize");
                return false;
            }

            if ((mp_lStartRow < 0 & mp_lEndRow < 0))
            {
                mp_lStartRow = 1;
                mp_lEndRow = mp_oControl.Rows.Count;
            }

            if (mp_lStartRow <= 0)
            {
                mp_lStartRow = 1;
            }

            if ((mp_lEndRow > mp_oControl.Rows.Count) | EndRow <= -1)
            {
                mp_lEndRow = mp_oControl.Rows.Count;
            }

            if (mp_lEndRow < mp_lStartRow)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_ROW_RANGE, "Invalid Row Range. EndRow cannot be smaller than StartRow.", "ActiveGanttCSWCtl.clsPrinter.Initialize");
                return false;
            }

            if ((StartDate == EndDate) | (EndDate < StartDate))
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_DATE_RANGE, "Invalid Date Range. EndDate must be greater than StartDate.", "ActiveGanttCSWCtl.clsPrinter.Initialize");
                return false;
            }

            if (mp_CalculatePageDimensions() == false)
            {
                return false;
            }
            if (mp_CheckRows() == false)
            {
                return false;
            }
            if (mp_CheckColumns() == false)
            {
                return false;
            }
            if (mp_CheckTimeIntervals() == false)
            {
                return false;
            }

            if (mp_bShowAllColumns == true)
            {
                if (mp_lSplitterPositionBuffer == -1)
                {
                    mp_lSplitterPositionBuffer = mp_oControl.Splitter.Position;
                }
                mp_oControl.Splitter.Position = mp_oControl.Columns.Width + mp_oControl.Splitter.Offset;
            }

            if (mp_oControl.f_TimeLineScrollBar.Enabled == false)
            {
                mp_dtPrintStartDateBuffer = mp_oView.TimeLine.StartDate;
                mp_oView.TimeLine.f_StartDate = mp_dtStartDate;
            }
            else
            {
                mp_dtPrintStartDateBuffer = mp_oControl.f_TimeLineScrollBar.StartDate;
                mp_oControl.f_TimeLineScrollBar.StartDate = mp_dtStartDate;
            }
            if (mp_lFirstVisibleRowBuffer == -1)
            {
                mp_lFirstVisibleRowBuffer = mp_oView.ClientArea.FirstVisibleRow;
            }
            mp_oView.ClientArea.FirstVisibleRow = 1;

            mp_oControl.clsG.CustomWidth = System.Convert.ToInt32(mp_oControl.MathLib.DateTimeDiff(mp_oView.Interval, StartDate, EndDate) / mp_oView.Factor) + mp_oControl.Splitter.Right;
            mp_oControl.clsG.CustomHeight = mp_oControl.Rows.Height() + mp_oControl.CurrentViewObject.TimeLine.Height;

            mp_bInitialized = true;
            mp_Calculate();
            return true;
        }

        public void Terminate()
        {
            if (mp_bInitialized == true)
            {
                if (mp_oControl.f_TimeLineScrollBar.Enabled == false)
                {
                    mp_oView.TimeLine.f_StartDate = mp_dtPrintStartDateBuffer;
                }
                else
                {
                    mp_oControl.f_TimeLineScrollBar.StartDate = mp_dtPrintStartDateBuffer;
                }
                if (mp_lSplitterPositionBuffer != -1)
                {
                    mp_oControl.Splitter.Position = mp_lSplitterPositionBuffer;
                    mp_lSplitterPositionBuffer = -1;
                }
                if (mp_lFirstVisibleRowBuffer != -1)
                {
                    mp_oView.ClientArea.FirstVisibleRow = mp_lFirstVisibleRowBuffer;
                    mp_lFirstVisibleRowBuffer = -1;
                }
                mp_Calculate();
            }
        }

        public void Calculate()
        {
            mp_Calculate();
        }

        public void PrintAll()
        {
            if (mp_bInitialized == true)
            {
                mp_PrintXPSDocument(1, Pages);
            }
        }

        public void PrintRange(int StartPage, int EndPage)
        {
            if (mp_bInitialized == true)
            {
                if ((StartPage < 1) | (EndPage > Pages))
                {
                    mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_PAGE, "Invalid PageNumber. StartPage and EndPage must be greater than 1 and less than the value of the Pages property.", "ActiveGanttCSWCtl.clsPrinter.PrintRange");
                    return;
                }
                if (EndPage < StartPage)
                {
                    mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_PAGE_RANGE, "Invalid Page range. EndPage must be greater than or equal to StartPage.", "ActiveGanttCSWCtl.clsPrinter.PrintRange");
                    return;
                }
                mp_PrintXPSDocument(StartPage, EndPage);
            }
        }

        public void PrintPage(int PageNumber)
        {
            if ((PageNumber < 1) | (PageNumber > Pages))
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_PAGE, "Invalid PageNumber. PageNumber must be greater than 1 and less than the value of the Pages property.", "ActiveGanttCSWCtl.clsPrinter.PrintRange");
                return;
            }
            if (mp_bInitialized == true)
            {
                mp_Calculate();
                mp_lPageNumber = PageNumber;
                mp_PrintXPSDocument(PageNumber, PageNumber);
            }
        }

        public void PreviewPage(DrawingContext oGraphics, int PageNumber, float Scale, int X, int Y)
        {
            if (Scale <= 0)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_SCALE, "Invalid scale, scale must be greater than 0.", "ActiveGanttCSWCtl.clsPrinter.PreviewPage");
                return;
            }
            if ((PageNumber < 1) | (PageNumber > Pages))
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_PAGE, "Invalid PageNumber. PageNumber must be greater than 1 and less than the value of the Pages property.", "ActiveGanttCSWCtl.clsPrinter.PreviewPage");
                return;
            }
            int lMarginLeft = System.Convert.ToInt32(MarginLeft * mp_fScaleInvMultp());
            int lMarginTop = System.Convert.ToInt32(MarginTop * mp_fScaleInvMultp());
            int X1 = System.Convert.ToInt32(X * mp_fScaleInvMultp());
            int Y1 = System.Convert.ToInt32(Y * mp_fScaleInvMultp());

            mp_oControl.clsG.CustomPrinting = true;
            mp_oControl.mp_PositionScrollBars();
            mp_oControl.clsG.CustomDC = oGraphics;


            mp_ScaleTransform(Scale, Scale, oGraphics);
            mp_TranslateTransform((1 / Scale * X) - X, (1 / Scale * Y) - Y, oGraphics);

            if (mp_yOrientation == GRE_ORIENTATION.OT_PORTRAIT)
            {
                oGraphics.DrawRectangle(Brushes.White, null, new Rect(X, Y, System.Convert.ToInt32(mp_dPageWidth), System.Convert.ToInt32(mp_dPageHeight)));
            }
            else if (mp_yOrientation == GRE_ORIENTATION.OT_LANDSCAPE)
            {
                oGraphics.DrawRectangle(Brushes.White, null, new Rect(X, Y, System.Convert.ToInt32(mp_dPageHeight), System.Convert.ToInt32(mp_dPageWidth)));
            }

            mp_Draw(oGraphics, PageNumber, lMarginLeft, lMarginTop, X1, Y1, false);

            mp_oControl.clsG.CustomPrinting = false;
            mp_oControl.mp_PositionScrollBars();
        }

        #region "Functions"

        private void mp_PrintPage(DrawingContext oGraphics)
        {
            int lMarginLeft = System.Convert.ToInt32(MarginLeft * mp_fScaleInvMultp()) - System.Convert.ToInt32(mp_lHardMarginX * mp_fScaleInvMultp());
            int lMarginTop = System.Convert.ToInt32(MarginTop * mp_fScaleInvMultp()) - System.Convert.ToInt32(mp_lHardMarginY * mp_fScaleInvMultp());

            mp_oControl.clsG.CustomPrinting = true;
            mp_oControl.mp_PositionScrollBars();
            mp_oControl.clsG.CustomDC = oGraphics;

            mp_Draw(oGraphics, mp_lPageNumber, lMarginLeft, lMarginTop, 0, 0, true);

            mp_oControl.clsG.CustomPrinting = false;
            mp_oControl.mp_PositionScrollBars();
        }

        private void mp_Draw(DrawingContext oGraphics, int PageNumber, int lMarginLeft, int lMarginTop, int X1, int Y1, bool bToPrinter)
        {
            int lColumn = -1;
            int lRow = -1;
            List<S_Transformation> aBackupTransform = null;
            float WPFFactor = 0;
            if (bToPrinter == true)
            {
                WPFFactor = 0.96F;
            }
            else
            {
                WPFFactor = 1;
            }

            lMarginLeft = lMarginLeft + X1;
            lMarginTop = lMarginTop + Y1;

            aBackupTransform = mp_SaveTransform();
            mp_GetPagePosition(PageNumber, ref lColumn, ref lRow);

            mp_ScaleTransform(mp_fScale * WPFFactor, mp_fScale * WPFFactor, oGraphics);

            if (mp_bHeadingsInEveryPage == true | lRow == 0)
            {
                mp_TranslateTransform(-mp_aX(lColumn) + lMarginLeft + mp_lColumnsWidth(lColumn), lMarginTop, oGraphics);
                mp_oControl.clsG.mp_lX1 = mp_aX(lColumn);
                mp_oControl.clsG.mp_lY1 = 0;
                mp_oControl.clsG.mp_lX2 = mp_aX(lColumn + 1);
                mp_oControl.clsG.mp_lY2 = mp_lTimeLineHeight();
                mp_oControl.f_Draw();
                mp_ClearTransform(oGraphics);
            }
            if (mp_bColumnsInEveryPage == true & mp_lColumns > 0 & lColumn > 0)
            {
                if (mp_bHeadingsInEveryPage == true | lRow == 0)
                {
                    //// Column Headings
                    mp_TranslateTransform(lMarginLeft, lMarginTop, oGraphics);
                    mp_oControl.clsG.mp_lX1 = 0;
                    mp_oControl.clsG.mp_lY1 = 0;
                    mp_oControl.clsG.mp_lX2 = mp_lColumnsWidth(lColumn);
                    mp_oControl.clsG.mp_lY2 = mp_lTimeLineHeight();
                    //mp_oControl.clsG.mp_ClipRegion(0, 0, mp_lColumnsWidth(lColumn), mp_lTimeLineHeight, False)
                    //mp_oControl.clsG.mp_DrawItem(0, 0, mp_oControl.clsG.Width - 1, mp_oControl.clsG.Height - 1, "", "", False, mp_oControl.Image, 0, 0, mp_oControl.Style)
                    //mp_oControl.Columns.Position()
                    //mp_oControl.Columns.Draw()
                    mp_oControl.f_Draw();
                    mp_ClearTransform(oGraphics);
                }

                //// Columns
                if (mp_bHeadingsInEveryPage == true | lRow == 0)
                {
                    mp_TranslateTransform(lMarginLeft, -mp_aY(lRow) + lMarginTop - mp_lRowsHeight(), oGraphics);
                }
                else
                {
                    mp_TranslateTransform(lMarginLeft, -mp_aY(lRow) + lMarginTop - mp_lTimeLineHeight() - mp_lRowsHeight(), oGraphics);
                }
                mp_oControl.clsG.mp_lX1 = 0;
                mp_oControl.clsG.mp_lY1 = mp_aY(lRow) + mp_lTimeLineHeight() + mp_lRowsHeight();
                mp_oControl.clsG.mp_lX2 = mp_lColumnsWidth(lColumn);
                mp_oControl.clsG.mp_lY2 = mp_aY(lRow + 1) + mp_lTimeLineHeight() + mp_lRowsHeight();
                mp_oControl.f_Draw();
                mp_ClearTransform(oGraphics);
            }

            if (mp_bHeadingsInEveryPage == true | lRow == 0)
            {
                mp_TranslateTransform(-mp_aX(lColumn) + lMarginLeft + mp_lColumnsWidth(lColumn), -mp_aY(lRow) + lMarginTop - mp_lRowsHeight(), oGraphics);
            }
            else
            {
                mp_TranslateTransform(-mp_aX(lColumn) + lMarginLeft + mp_lColumnsWidth(lColumn), -mp_aY(lRow) + lMarginTop - mp_lTimeLineHeight() - mp_lRowsHeight(), oGraphics);
            }
            mp_oControl.clsG.mp_lX1 = mp_aX(lColumn);
            mp_oControl.clsG.mp_lY1 = mp_aY(lRow) + mp_lTimeLineHeight() + mp_lRowsHeight();
            mp_oControl.clsG.mp_lX2 = mp_aX(lColumn + 1);
            mp_oControl.clsG.mp_lY2 = mp_aY(lRow + 1) + mp_lTimeLineHeight() + mp_lRowsHeight();
            mp_oControl.f_Draw();

            mp_ResetTransform(oGraphics);

            if (bToPrinter == false)
            {
                mp_RestoreTransform(aBackupTransform, oGraphics);
                mp_TranslateTransform(X1 * mp_fScale, Y1 * mp_fScale, oGraphics);
            }
            else
            {
                mp_ScaleTransform(WPFFactor, WPFFactor, oGraphics);
                mp_TranslateTransform(-System.Convert.ToInt32(mp_lHardMarginX), -System.Convert.ToInt32(mp_lHardMarginY), oGraphics);
            }
            mp_oControl.PagePrintEventArgs.Clear();
            mp_oControl.PagePrintEventArgs.X1 = MarginLeft;
            mp_oControl.PagePrintEventArgs.Y1 = MarginTop;
            mp_oControl.PagePrintEventArgs.X2 = MarginLeft + System.Convert.ToInt32((mp_aHorizontal[lColumn] + mp_lColumnsWidth(lColumn)) * mp_fScale);
            mp_oControl.PagePrintEventArgs.Y2 = MarginTop + System.Convert.ToInt32((mp_aVertical[lRow] + mp_lTimeLineHeight(lRow)) * mp_fScale);

            if (mp_yOrientation == GRE_ORIENTATION.OT_PORTRAIT)
            {
                mp_oControl.PagePrintEventArgs.PageWidth = System.Convert.ToInt32(mp_dPageWidth);
                mp_oControl.PagePrintEventArgs.PageHeight = System.Convert.ToInt32(mp_dPageHeight);
            }
            else if (mp_yOrientation == GRE_ORIENTATION.OT_LANDSCAPE)
            {
                mp_oControl.PagePrintEventArgs.PageWidth = System.Convert.ToInt32(mp_dPageHeight);
                mp_oControl.PagePrintEventArgs.PageHeight = System.Convert.ToInt32(mp_dPageWidth);
            }

            mp_oControl.PagePrintEventArgs.ActualPageHeight = mp_aVertical[lRow];
            mp_oControl.PagePrintEventArgs.ActualPageWidth = mp_aHorizontal[lColumn];

            mp_oControl.PagePrintEventArgs.Graphics = oGraphics;
            mp_oControl.PagePrintEventArgs.PageNumber = PageNumber;

            mp_oControl.clsG.mp_lX1 = 0;
            mp_oControl.clsG.mp_lY1 = 0;
            mp_oControl.clsG.mp_lX2 = mp_oControl.clsG.CustomWidth;
            mp_oControl.clsG.mp_lY2 = mp_oControl.clsG.CustomHeight;

            mp_oControl.FirePagePrint();

            mp_ResetTransform(oGraphics);

        }

        private int mp_lTimeLineHeight(int lRow)
        {
            if (mp_bHeadingsInEveryPage == true | lRow == 0)
            {
                return mp_oControl.CurrentViewObject.TimeLine.Height + mp_oControl.mt_BorderThickness;
            }
            else
            {
                return 0;
            }
        }

        private int mp_lRowsHeight()
        {
            return mp_oControl.Rows.Height(mp_lStartRow - 1);
        }

        private int mp_lTimeLineHeight()
        {
            return mp_oControl.CurrentViewObject.TimeLine.Height + mp_oControl.mt_BorderThickness;
        }

        private int mp_aX(int lIndex)
        {
            if (lIndex == 0)
            {
                return 0;
            }
            else
            {
                int lReturn = 0;
                int i = 0;
                for (i = 0; i <= lIndex - 1; i++)
                {
                    lReturn = lReturn + mp_aHorizontal[i];
                }
                return lReturn;
            }
        }

        private int mp_aY(int lIndex)
        {
            if (lIndex == 0)
            {
                return 0;
            }
            else
            {
                int lReturn = 0;
                int i = 0;
                for (i = 0; i <= lIndex - 1; i++)
                {
                    lReturn = lReturn + mp_aVertical[i];
                }
                return lReturn;
            }
        }

        private void mp_QueryPrinter()
        {
            mp_dPageWidth = System.Convert.ToDouble(mp_oPageDimensions.GetWidth(mp_yPaperType));
            mp_dPageHeight = System.Convert.ToDouble(mp_oPageDimensions.GetHeight(mp_yPaperType));
            mp_Calculate();
        }

        private void mp_Calculate()
        {
            mp_CalculatePageDimensions();
            if (mp_bInitialized == true)
            {
                mp_CalculateColumns();
                mp_CalculateRows();
                mp_lPages = mp_lXAxisPages * mp_lYAxisPages;
            }
            else
            {
                mp_oControl.clsG.CustomWidth = 0;
                mp_oControl.clsG.CustomHeight = 0;
                mp_dtStartDate = new DateTime();
                mp_dtEndDate = new DateTime();
                mp_lXAxisPages = 0;
                mp_lYAxisPages = 0;
                mp_lPages = 0;
            }
        }

        private int mp_lActualPageHeight(int lRow)
        {
            int lTimeLineHeight = mp_oControl.CurrentViewObject.TimeLine.Height + mp_oControl.mt_BorderThickness;
            if (mp_bHeadingsInEveryPage == true | lRow == 0)
            {
                return System.Convert.ToInt32((mp_dActualPageHeight - lTimeLineHeight) * mp_fScaleInvMultp());
            }
            else
            {
                return System.Convert.ToInt32(mp_dActualPageHeight * mp_fScaleInvMultp());
            }
        }

        private void mp_CalculateRows()
        {
            mp_aVertical = new List<int>();
            if (mp_bKeepRowsTogether == true)
            {
                int lRow = 0;
                int YBuff = 0;
                lRow = mp_lStartRow;
                while (lRow <= mp_lEndRow)
                {
                    if ((YBuff + mp_oControl.Rows.Item(lRow.ToString()).Height + 1) < mp_lActualPageHeight(mp_aVertical.Count))
                    {
                        YBuff = YBuff + mp_oControl.Rows.Item(lRow.ToString()).Height + 1;
                        lRow = lRow + 1;
                    }
                    else
                    {
                        mp_aVertical.Add(YBuff);
                        YBuff = 0;
                    }
                }
                if (YBuff > 0)
                {
                    mp_aVertical.Add(YBuff);
                    YBuff = 0;
                }
                mp_lYAxisPages = mp_aVertical.Count;
            }
            else if (mp_bKeepRowsTogether == false)
            {
                int lRowsHeight = mp_oControl.Rows.Height(mp_lEndRow) - mp_oControl.Rows.Height(mp_lStartRow);
                int yBuff = 0;
                while (yBuff <= lRowsHeight)
                {
                    int lActualPageHeight = mp_lActualPageHeight(mp_aVertical.Count);
                    yBuff = yBuff + lActualPageHeight;
                    if (lActualPageHeight + mp_aY(mp_aVertical.Count) < lRowsHeight)
                    {
                        mp_aVertical.Add(lActualPageHeight);
                    }
                    else
                    {
                        int lRowsHeight1 = 0;
                        if (mp_lEndRow < mp_oControl.Rows.Count)
                        {
                            lRowsHeight1 = mp_oControl.Rows.Height(mp_lEndRow + 1) - mp_oControl.Rows.Height(mp_lStartRow);
                        }
                        else
                        {
                            lRowsHeight1 = mp_oControl.Rows.Height() - mp_oControl.Rows.Height(mp_lStartRow);
                        }
                        mp_aVertical.Add(lRowsHeight1 - mp_aY(mp_aVertical.Count));
                    }

                }
                mp_lYAxisPages = mp_aVertical.Count;
            }
        }

        private void mp_CalculateColumns()
        {
            int lColumn = 0;
            mp_aHorizontal = new List<int>();
            if (mp_bKeepColumnsTogether == true)
            {
                int XBuff = 0;
                lColumn = 1;
                if (mp_bShowAllColumns == true)
                {
                    while (lColumn <= mp_oControl.Columns.Count)
                    {
                        if ((XBuff + mp_oControl.Columns.Item(lColumn.ToString()).Width + 1) < mp_lActualPageWidth(mp_aHorizontal.Count))
                        {
                            XBuff = XBuff + mp_oControl.Columns.Item(lColumn.ToString()).Width;
                            lColumn = lColumn + 1;
                        }
                        else
                        {
                            mp_aHorizontal.Add(XBuff - mp_lColumnsWidth(mp_aHorizontal.Count));
                            XBuff = 0;
                        }
                    }
                }
                else if (mp_bShowAllColumns == false)
                {
                    XBuff = mp_oControl.Splitter.Right;
                }
                if (mp_bKeepTimeIntervalsTogether == true)
                {
                    int lCustomWidth = 0;
                    int XDelta = 0;
                    DateTime dtBuff;
                    mp_dtStartDate = mp_oControl.MathLib.RoundDate(mp_yInterval, mp_lFactor, mp_dtStartDate);
                    mp_dtEndDate = mp_oControl.MathLib.RoundDate(mp_yInterval, mp_lFactor, mp_dtEndDate);
                    mp_oControl.clsG.CustomWidth = System.Convert.ToInt32((mp_oControl.MathLib.DateTimeDiff(mp_oView.Interval, mp_dtStartDate, mp_dtEndDate) / mp_oView.Factor) + mp_oControl.Splitter.Right);
                    lCustomWidth = mp_oControl.clsG.CustomWidth;
                    dtBuff = mp_dtStartDate;
                    while ((dtBuff < mp_dtEndDate))
                    {
                        XDelta = mp_oControl.MathLib.GetXCoordinateFromDate(mp_oControl.MathLib.DateTimeAdd(mp_yInterval, mp_lFactor, dtBuff)) - mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff);
                        if (((XBuff + XDelta) < mp_lActualPageWidth(mp_aHorizontal.Count)))
                        {
                            XBuff = XBuff + XDelta;
                            dtBuff = mp_oControl.MathLib.DateTimeAdd(mp_yInterval, mp_lFactor, dtBuff);
                        }
                        else
                        {
                            mp_aHorizontal.Add(XBuff);
                            XBuff = 0;
                        }
                    }
                    if (XBuff > 0)
                    {
                        mp_aHorizontal.Add(XBuff);
                        XBuff = 0;
                    }
                }
                else if (mp_bKeepTimeIntervalsTogether == false)
                {
                    if (mp_bColumnsInEveryPage == true & mp_lColumns > 0)
                    {
                        mp_lXAxisPages = System.Convert.ToInt32(System.Math.Ceiling(((double)mp_oControl.clsG.CustomWidth - (double)mp_lColumnsWidth(-1)) / (double)mp_lActualPageWidth(-1)));
                    }
                    else if (mp_bColumnsInEveryPage == false | mp_lColumns == 0)
                    {
                        mp_lXAxisPages = System.Convert.ToInt32(System.Math.Ceiling((double)mp_oControl.clsG.CustomWidth / (double)mp_lActualPageWidth()));
                    }
                    for (lColumn = 1; lColumn <= mp_lXAxisPages; lColumn++)
                    {
                        mp_aHorizontal.Add(System.Convert.ToInt32((mp_dActualPageWidth * mp_fScaleInvMultp()) - mp_lColumnsWidth(lColumn - 1)));
                    }
                }
                mp_lXAxisPages = mp_aHorizontal.Count;
            }
            else if (mp_bKeepColumnsTogether == false)
            {
                if (mp_bColumnsInEveryPage == true & mp_lColumns > 0)
                {
                    mp_lXAxisPages = System.Convert.ToInt32(System.Math.Ceiling(((double)mp_oControl.clsG.CustomWidth - (double)mp_lColumnsWidth(-1)) / (double)mp_lActualPageWidth(-1)));
                }
                else if (mp_bColumnsInEveryPage == false | mp_lColumns == 0)
                {
                    mp_lXAxisPages = System.Convert.ToInt32(System.Math.Ceiling((double)mp_oControl.clsG.CustomWidth / (double)mp_lActualPageWidth()));
                }
                for (lColumn = 1; lColumn <= mp_lXAxisPages; lColumn++)
                {
                    mp_aHorizontal.Add(System.Convert.ToInt32((mp_dActualPageWidth * mp_fScaleInvMultp()) - mp_lColumnsWidth(lColumn - 1)));
                }
            }
        }

        private float mp_fScaleInvMultp()
        {
            return 1 / mp_fScale;
        }

        private int mp_lActualPageWidth()
        {
            if (mp_bColumnsInEveryPage == false | mp_lColumns == 0)
            {
                return System.Convert.ToInt32(mp_dActualPageWidth * mp_fScaleInvMultp());
            }
            else
            {
                System.Diagnostics.Debugger.Break();
                return 0;
            }
        }

        private int mp_lActualPageWidth(int lColumn)
        {
            if (mp_bColumnsInEveryPage == true & mp_lColumns > 0)
            {
                return System.Convert.ToInt32((mp_dActualPageWidth - mp_lColumnsWidth(lColumn)) * mp_fScaleInvMultp());
            }
            else if (lColumn == -1)
            {
                return System.Convert.ToInt32((mp_dActualPageWidth - mp_lColumnsWidth(-1)) * mp_fScaleInvMultp());
            }
            else if (mp_bColumnsInEveryPage == false | mp_lColumns == 0)
            {
                return System.Convert.ToInt32(mp_dActualPageWidth * mp_fScaleInvMultp());
            }
            else
            {
                System.Diagnostics.Debugger.Break();
                return 0;
            }
        }

        private int mp_lColumnsWidth(int lColumn)
        {
            int lReturn = 0;
            if (lColumn == 0)
            {
                return 0;
            }
            if (mp_bColumnsInEveryPage == true & mp_lColumns > 0 & mp_bShowAllColumns == false)
            {
                lReturn = mp_oControl.Splitter.Right - mp_oControl.mt_BorderThickness;
            }
            else if (mp_bColumnsInEveryPage == true & mp_lColumns > 0 & mp_bShowAllColumns == true)
            {
                int i = 0;
                for (i = 1; i <= mp_lColumns; i++)
                {
                    if (mp_oControl.Columns.Item(i.ToString()).Visible == true)
                    {
                        lReturn = lReturn + mp_oControl.Columns.Item(i.ToString()).Width;
                    }
                }
            }
            return lReturn + mp_oControl.mt_BorderThickness;
        }

        private void mp_GetPagePosition(int lPageNumber, ref int lColumn, ref int lRow)
        {
            lRow = System.Convert.ToInt32(System.Math.Ceiling((double)lPageNumber / (double)XAxisPages)) - 1;
            lColumn = lPageNumber - (lRow * XAxisPages) - 1;
        }

        #region "WPF Transforms"

        private void mp_TranslateTransform(double OffsetX, double OffsetY, DrawingContext oDC)
        {
            oDC.PushTransform(new TranslateTransform(OffsetX, OffsetY));
            S_Transformation oTransformation = new S_Transformation();
            oTransformation.yType = E_TRANSFORMATIONTYPE.TT_TRANSLATE;
            oTransformation.X = OffsetX;
            oTransformation.Y = OffsetY;
            mp_aTransformations.Add(oTransformation);
        }

        private void mp_ScaleTransform(double ScaleX, double ScaleY, DrawingContext oDC)
        {
            oDC.PushTransform(new ScaleTransform(ScaleX, ScaleY));
            S_Transformation oTransformation = new S_Transformation();
            oTransformation.yType = E_TRANSFORMATIONTYPE.TT_SCALE;
            oTransformation.X = ScaleX;
            oTransformation.Y = ScaleY;
            mp_aTransformations.Add(oTransformation);
        }

        private List<S_Transformation> mp_SaveTransform()
        {
            List<S_Transformation> oReturn = new List<S_Transformation>();
            int i = 0;
            for (i = 0; i <= mp_aTransformations.Count - 1; i++)
            {
                S_Transformation oTransformation = mp_aTransformations[i];
                oReturn.Add(oTransformation);
            }
            return oReturn;
        }

        private void mp_RestoreTransform(List<S_Transformation> oTransform, DrawingContext oDC)
        {
            mp_ResetTransform(oDC);
            int i = 0;
            for (i = 0; i <= oTransform.Count - 1; i++)
            {
                S_Transformation oTransformation = oTransform[i];
                if (oTransformation.yType == E_TRANSFORMATIONTYPE.TT_TRANSLATE)
                {
                    mp_TranslateTransform(oTransformation.X, oTransformation.Y, oDC);
                }
                else if (oTransformation.yType == E_TRANSFORMATIONTYPE.TT_SCALE)
                {
                    mp_ScaleTransform(oTransformation.X, oTransformation.Y, oDC);
                }
            }
        }

        private void mp_ClearTransform(DrawingContext oDC)
        {
            if (mp_aTransformations.Count > 0)
            {
                mp_aTransformations.RemoveAt(mp_aTransformations.Count - 1);
                oDC.Pop();
            }
            else
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        private void mp_ResetTransform(DrawingContext oDC)
        {
            int i = 0;
            for (i = mp_aTransformations.Count - 1; i >= 0; i += -1)
            {
                mp_aTransformations.RemoveAt(i);
                oDC.Pop();
            }
        }

        #endregion

        #region "XPS"

        private void mp_PrintXPSDocument(int StartPage, int EndPage)
        {
            if (EndPage >= StartPage)
            {
                LocalPrintServer oPrintServer = new LocalPrintServer();
                PrintQueue oPrintQueue = oPrintServer.GetPrintQueue(mp_sPrinterName);
                PrintTicket oPrintTicket = mp_GetPrintTicket();
                XpsDocumentWriter oWriter = PrintQueue.CreateXpsDocumentWriter(oPrintQueue);
                int i = 0;
                VisualsToXpsDocument oMultipleVisualsDoc = (VisualsToXpsDocument)oWriter.CreateVisualsCollator(oPrintTicket, oPrintTicket);
                for (i = StartPage; i <= EndPage; i++)
                {
                    DrawingVisual oVisual = new DrawingVisual();
                    DrawingContext oDC = oVisual.RenderOpen();
                    mp_lPageNumber = i;
                    mp_PrintPage(oDC);
                    oDC.Close();
                    oMultipleVisualsDoc.Write(oVisual, oPrintTicket);
                }
                oMultipleVisualsDoc.EndBatchWrite();
            }
        }

        public XpsDocument GetXPSDocument(int StartPage, int EndPage)
        {
            if (EndPage >= StartPage)
            {
                PrintTicket oPrintTicket = mp_GetPrintTicket();
                string sURI = "memorystream://Preview.xps";
                Uri oURI = null;
                oURI = new Uri(sURI);
                System.IO.MemoryStream oStream = new System.IO.MemoryStream();
                Package oPackage = Package.Open(oStream, FileMode.Create);
                PackageStore.AddPackage(oURI, oPackage);
                XpsDocument oXPSDoc = new XpsDocument(oPackage, CompressionOption.Maximum, sURI);
                XpsDocumentWriter oWriter = XpsDocument.CreateXpsDocumentWriter(oXPSDoc);
                int i = 0;
                VisualsToXpsDocument oMultipleVisualsDoc = (VisualsToXpsDocument)oWriter.CreateVisualsCollator(oPrintTicket, oPrintTicket);
                for (i = StartPage; i <= EndPage; i++)
                {
                    DrawingVisual oVisual = new DrawingVisual();
                    DrawingContext oDC = oVisual.RenderOpen();
                    mp_lPageNumber = i;
                    mp_PrintPage(oDC);
                    oDC.Close();
                    oMultipleVisualsDoc.Write(oVisual, oPrintTicket);
                }
                oMultipleVisualsDoc.EndBatchWrite();
                return oXPSDoc;
            }
            else
            {
                return null;
            }
        }

        private PrintTicket mp_GetPrintTicket()
        {
            PrintTicket oPrintTicket = new PrintTicket();
            if (mp_yOrientation == GRE_ORIENTATION.OT_PORTRAIT)
            {
                oPrintTicket.PageOrientation = PageOrientation.Portrait;
                oPrintTicket.PageMediaSize = new PageMediaSize((mp_oPageDimensions.GetWidth(mp_yPaperType) / 100) * 96, (mp_oPageDimensions.GetHeight(mp_yPaperType) / 100) * 96);
            }
            else if (mp_yOrientation == GRE_ORIENTATION.OT_LANDSCAPE)
            {
                oPrintTicket.PageOrientation = PageOrientation.Landscape;
                oPrintTicket.PageMediaSize = new PageMediaSize((mp_oPageDimensions.GetHeight(mp_yPaperType) / 100) * 96, (mp_oPageDimensions.GetWidth(mp_yPaperType) / 100) * 96);
            }
            switch (mp_yPrinterResolution)
            {
                case GRE_PRINTERRESOLUTION.PR_HIGH:
                    oPrintTicket.PageResolution = new PageResolution(PageQualitativeResolution.High);
                    break;
                case GRE_PRINTERRESOLUTION.PR_MEDIUM:
                    oPrintTicket.PageResolution = new PageResolution(PageQualitativeResolution.Normal);
                    break;
                case GRE_PRINTERRESOLUTION.PR_LOW:
                    oPrintTicket.PageResolution = new PageResolution(PageQualitativeResolution.Draft);
                    break;
                case GRE_PRINTERRESOLUTION.PR_DRAFT:
                    oPrintTicket.PageResolution = new PageResolution(PageQualitativeResolution.Draft);
                    break;
                case GRE_PRINTERRESOLUTION.PR_CUSTOM:
                    oPrintTicket.PageResolution = new PageResolution(mp_lHorizontalDPI, mp_lVerticalDPI, PageQualitativeResolution.Other);
                    break;
            }
            return oPrintTicket;
        }

        public void SaveXPSToFile(int StartPage, int EndPage, string sFilename)
        {
            Package oPackage = Package.Open(sFilename, FileMode.Create);
            PrintTicket oPrintTicket = mp_GetPrintTicket();
            XpsDocument oXPSDoc = new XpsDocument(oPackage);
            XpsDocumentWriter oWriter = XpsDocument.CreateXpsDocumentWriter(oXPSDoc);
            int i = 0;
            VisualsToXpsDocument oMultipleVisualsDoc = (VisualsToXpsDocument)oWriter.CreateVisualsCollator(oPrintTicket, oPrintTicket);
            for (i = StartPage; i <= EndPage; i++)
            {
                DrawingVisual oVisual = new DrawingVisual();
                DrawingContext oDC = oVisual.RenderOpen();
                mp_lPageNumber = i;
                mp_PrintPage(oDC);
                oDC.Close();
                oMultipleVisualsDoc.Write(oVisual, oPrintTicket);
            }
            oMultipleVisualsDoc.EndBatchWrite();
            oXPSDoc.Close();
            oPackage.Close();
        }

        #endregion

        #endregion

        #region "Check"

        private bool mp_CalculatePageDimensions()
        {
            if (mp_yOrientation == GRE_ORIENTATION.OT_PORTRAIT)
            {
                mp_dActualPageWidth = mp_dPageWidth - (MarginLeft + MarginRight);
                mp_dActualPageHeight = mp_dPageHeight - (MarginTop + MarginBottom);
            }
            else if (mp_yOrientation == GRE_ORIENTATION.OT_LANDSCAPE)
            {
                mp_dActualPageWidth = mp_dPageHeight - (MarginLeft + MarginRight);
                mp_dActualPageHeight = mp_dPageWidth - (MarginTop + MarginBottom);
            }
            if (mp_dActualPageWidth <= 0 | mp_dActualPageHeight <= 0)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_SPECS_MARGINS, "Invalid printing specifications, page printing area cannot be 0. Reduce the margins.", "ActiveGanttCSWCtl.clsPrinter.Initialize");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool mp_CheckRows()
        {
            int i = 0;
            int lActualPageHeight = System.Convert.ToInt32(mp_dActualPageHeight * mp_fScaleInvMultp()) - System.Convert.ToInt32(mp_oControl.CurrentViewObject.TimeLine.Height * mp_fScaleInvMultp());
            if (mp_bKeepRowsTogether == true)
            {
                for (i = 1; i <= mp_oControl.Rows.Count; i++)
                {
                    if ((mp_oControl.Rows.Item(i.ToString()).Height + 1) > lActualPageHeight)
                    {
                        mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_SPECS_HEIGHT, "Invalid printing specifications, reduce the top or bottom margin, set the KeepRowsTogether property to false or reduce the scale.", "ActiveGanttCSWCtl.clsPrinter.Initialize");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool mp_CheckColumns()
        {
            int i = 0;
            int lActualPageWidth = 0;
            lActualPageWidth = System.Convert.ToInt32(mp_dActualPageWidth * mp_fScaleInvMultp()) - System.Convert.ToInt32(mp_lColumnsInEveryPageWidth() * mp_fScaleInvMultp());
            if (lActualPageWidth <= 0)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_SPECS_COLUMNSINEVERYPAGE, "Invalid printing specifications, reduce the number of Columns in every page, set the ColumnsInEveryPage property to false, reduce the left or right margin or reduce the scale.", "ActiveGanttCSWCtl.clsPrinter.Initialize");
                return false;
            }
            if (mp_bKeepColumnsTogether == true)
            {
                for (i = 1; i <= mp_oControl.Columns.Count; i++)
                {
                    if ((mp_oControl.Columns.Item(i.ToString()).Width + 1) > lActualPageWidth)
                    {
                        mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_SPECS_COLUMNS, "Invalid printing specifications, reduce the left or right margin, set the KeepColumnsTogether property to false or reduce the scale.", "ActiveGanttCSWCtl.clsPrinter.Initialize");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool mp_CheckTimeIntervals()
        {
            int lActualPageWidth = 0;
            lActualPageWidth = System.Convert.ToInt32(mp_dActualPageWidth * mp_fScaleInvMultp()) - System.Convert.ToInt32(mp_lColumnsInEveryPageWidth() * mp_fScaleInvMultp());
            if (mp_bKeepTimeIntervalsTogether == true & mp_bKeepColumnsTogether == true)
            {
                DateTime dtStartDate = mp_oView.TimeLine.StartDate;
                DateTime dtEndDate = mp_oControl.MathLib.DateTimeAdd(mp_yInterval, mp_lFactor, dtStartDate);
                int lIntervalLength = System.Convert.ToInt32((mp_oControl.MathLib.GetXCoordinateFromDate(dtEndDate) - mp_oControl.MathLib.GetXCoordinateFromDate(dtStartDate)) * mp_fScaleInvMultp());
                if (lIntervalLength > lActualPageWidth)
                {
                    mp_oControl.mp_ErrorReport(SYS_ERRORS.PRINTER_INVALID_SPECS_INTERVAL, "Invalid printing specifications, reduce the left or right margin, set the KeepTimeIntervalsTogether property to false or reduce the scale.", "ActiveGanttCSWCtl.clsPrinter.Initialize");
                    return false;
                }
            }
            return true;
        }

        private int mp_lColumnsInEveryPageWidth()
        {
            if (mp_bColumnsInEveryPage == true & mp_lColumns > 0)
            {
                int i = 0;
                int lReturn = 0;
                for (i = 1; i <= mp_lColumns; i++)
                {
                    if (mp_oControl.Columns.Item(i.ToString()).Visible == true)
                    {
                        lReturn = lReturn + mp_oControl.Columns.Item(i.ToString()).Width;
                    }
                }
                return lReturn;
            }
            else
            {
                return 0;
            }
        }

        #endregion

    }

    internal class PageDimensions
    {

        private enum E_UNITS
        {
            U_INCHES = 0,
            U_MILLIMETER = 1
        }

        private struct S_PageDimension
        {
            public GRE_PAPERTYPE Index;
            public double Width;
            public double Height;
            public E_UNITS Unit;
        }

        private int mp_lCustomWidth;

        private int mp_lCustomHeight;

        private System.Collections.Generic.List<S_PageDimension> mp_oPageDimensions;
        internal PageDimensions()
        {
            mp_lCustomWidth = 850;
            mp_lCustomHeight = 1100;
            mp_oPageDimensions = new System.Collections.Generic.List<S_PageDimension>();
            Add(1, 8.5, 11, E_UNITS.U_INCHES);
            Add(2, 8.5, 11, E_UNITS.U_INCHES);
            Add(3, 11, 17, E_UNITS.U_INCHES);
            Add(4, 17, 11, E_UNITS.U_INCHES);
            Add(5, 8.5, 14, E_UNITS.U_INCHES);
            Add(6, 5.5, 8.5, E_UNITS.U_INCHES);
            Add(7, 7.25, 10.5, E_UNITS.U_INCHES);
            Add(8, 297, 420, E_UNITS.U_MILLIMETER);
            Add(9, 210, 297, E_UNITS.U_MILLIMETER);
            Add(10, 210, 297, E_UNITS.U_MILLIMETER);
            Add(11, 148, 210, E_UNITS.U_MILLIMETER);
            Add(12, 250, 354, E_UNITS.U_MILLIMETER);
            Add(13, 182, 257, E_UNITS.U_MILLIMETER);
            Add(14, 8.5, 13, E_UNITS.U_INCHES);
            Add(15, 215, 275, E_UNITS.U_MILLIMETER);
            Add(16, 10, 14, E_UNITS.U_INCHES);
            Add(17, 11, 17, E_UNITS.U_INCHES);
            Add(18, 8.5, 11, E_UNITS.U_INCHES);
            Add(19, 3.875, 8.875, E_UNITS.U_INCHES);
            Add(20, 4.125, 9.5, E_UNITS.U_INCHES);
            Add(21, 4.5, 10.375, E_UNITS.U_INCHES);
            Add(22, 4.276, 11, E_UNITS.U_INCHES);
            Add(23, 5, 11.5, E_UNITS.U_INCHES);
            //24  /* C size sheet                       
            //25  /* D size sheet                       
            //26  /* E size sheet                       
            Add(27, 110, 220, E_UNITS.U_MILLIMETER);
            Add(28, 162, 229, E_UNITS.U_MILLIMETER);
            Add(29, 324, 458, E_UNITS.U_MILLIMETER);
            Add(30, 229, 324, E_UNITS.U_MILLIMETER);
            Add(31, 114, 162, E_UNITS.U_MILLIMETER);
            Add(32, 114, 229, E_UNITS.U_MILLIMETER);
            Add(33, 250, 353, E_UNITS.U_MILLIMETER);
            Add(34, 176, 250, E_UNITS.U_MILLIMETER);
            Add(35, 176, 125, E_UNITS.U_MILLIMETER);
            Add(36, 110, 230, E_UNITS.U_MILLIMETER);
            Add(37, 3.875, 7.5, E_UNITS.U_INCHES);
            Add(38, 3.625, 6.5, E_UNITS.U_INCHES);
            Add(39, 14.875, 11, E_UNITS.U_INCHES);
            Add(40, 8.5, 12, E_UNITS.U_INCHES);
            Add(41, 8.5, 13, E_UNITS.U_INCHES);
            Add(42, 250, 353, E_UNITS.U_MILLIMETER);
            Add(43, 100, 148, E_UNITS.U_MILLIMETER);
            Add(44, 9, 11, E_UNITS.U_INCHES);
            Add(45, 10, 11, E_UNITS.U_INCHES);
            Add(46, 15, 11, E_UNITS.U_INCHES);
            Add(47, 220, 220, E_UNITS.U_MILLIMETER);
            //48  /* RESERVED--DO NOT USE               
            //49  /* RESERVED--DO NOT USE               
            Add(50, 9.275, 12, E_UNITS.U_INCHES);
            Add(51, 9.275, 15, E_UNITS.U_INCHES);
            Add(52, 11.69, 18, E_UNITS.U_INCHES);
            Add(53, 9.27, 12.69, E_UNITS.U_INCHES);
            Add(54, 8.275, 11, E_UNITS.U_INCHES);
            Add(55, 210, 297, E_UNITS.U_MILLIMETER);
            Add(56, 9.275, 12, E_UNITS.U_INCHES);
            Add(57, 227, 356, E_UNITS.U_MILLIMETER);
            Add(58, 305, 487, E_UNITS.U_MILLIMETER);
            Add(59, 8.5, 12.69, E_UNITS.U_INCHES);
            Add(60, 210, 330, E_UNITS.U_MILLIMETER);
            Add(61, 148, 210, E_UNITS.U_MILLIMETER);
            Add(62, 182, 257, E_UNITS.U_MILLIMETER);
            Add(63, 322, 445, E_UNITS.U_MILLIMETER);
            Add(64, 174, 235, E_UNITS.U_MILLIMETER);
            Add(65, 201, 276, E_UNITS.U_MILLIMETER);
            Add(66, 420, 594, E_UNITS.U_MILLIMETER);
            Add(67, 297, 420, E_UNITS.U_MILLIMETER);
            Add(68, 322, 445, E_UNITS.U_MILLIMETER);
            Add(69, 200, 148, E_UNITS.U_MILLIMETER);
            Add(70, 105, 148, E_UNITS.U_MILLIMETER);
            Add(71, 240, 332, E_UNITS.U_MILLIMETER);
            Add(72, 216, 277, E_UNITS.U_MILLIMETER);
            Add(73, 120, 235, E_UNITS.U_MILLIMETER);
            Add(74, 90, 205, E_UNITS.U_MILLIMETER);
            Add(75, 11, 8.5, E_UNITS.U_INCHES);
            Add(76, 420, 297, E_UNITS.U_MILLIMETER);
            Add(77, 297, 210, E_UNITS.U_MILLIMETER);
            Add(78, 210, 148, E_UNITS.U_MILLIMETER);
            Add(79, 364, 257, E_UNITS.U_MILLIMETER);
            Add(80, 257, 182, E_UNITS.U_MILLIMETER);
            Add(81, 148, 100, E_UNITS.U_MILLIMETER);
            Add(82, 148, 200, E_UNITS.U_MILLIMETER);
            Add(83, 148, 105, E_UNITS.U_MILLIMETER);
            Add(84, 332, 240, E_UNITS.U_MILLIMETER);
            Add(85, 277, 216, E_UNITS.U_MILLIMETER);
            Add(86, 235, 120, E_UNITS.U_MILLIMETER);
            Add(87, 205, 90, E_UNITS.U_MILLIMETER);
            Add(88, 128, 182, E_UNITS.U_MILLIMETER);
            Add(89, 182, 128, E_UNITS.U_MILLIMETER);
            Add(90, 12, 11, E_UNITS.U_INCHES);
            Add(91, 235, 105, E_UNITS.U_MILLIMETER);
            Add(92, 105, 235, E_UNITS.U_MILLIMETER);
            Add(93, 146, 215, E_UNITS.U_MILLIMETER);
            Add(94, 97, 151, E_UNITS.U_MILLIMETER);
            Add(95, 97, 151, E_UNITS.U_MILLIMETER);
            Add(96, 102, 165, E_UNITS.U_MILLIMETER);
            Add(97, 102, 176, E_UNITS.U_MILLIMETER);
            Add(98, 125, 176, E_UNITS.U_MILLIMETER);
            Add(99, 110, 208, E_UNITS.U_MILLIMETER);
            Add(100, 110, 220, E_UNITS.U_MILLIMETER);
            Add(101, 120, 230, E_UNITS.U_MILLIMETER);
            Add(102, 160, 230, E_UNITS.U_MILLIMETER);
            Add(103, 120, 309, E_UNITS.U_MILLIMETER);
            Add(104, 229, 324, E_UNITS.U_MILLIMETER);
            Add(105, 324, 458, E_UNITS.U_MILLIMETER);
            Add(106, 215, 146, E_UNITS.U_MILLIMETER);
            Add(107, 151, 97, E_UNITS.U_MILLIMETER);
            Add(108, 151, 97, E_UNITS.U_MILLIMETER);
            Add(109, 165, 102, E_UNITS.U_MILLIMETER);
            Add(110, 176, 102, E_UNITS.U_MILLIMETER);
            Add(111, 176, 125, E_UNITS.U_MILLIMETER);
            Add(112, 208, 110, E_UNITS.U_MILLIMETER);
            Add(113, 220, 110, E_UNITS.U_MILLIMETER);
            Add(114, 230, 120, E_UNITS.U_MILLIMETER);
            Add(115, 230, 160, E_UNITS.U_MILLIMETER);
            Add(116, 309, 120, E_UNITS.U_MILLIMETER);
            Add(117, 324, 229, E_UNITS.U_MILLIMETER);
            Add(118, 458, 324, E_UNITS.U_MILLIMETER);
        }

        private void Add(int Index, double Width, double Height, E_UNITS Unit)
        {
            S_PageDimension oPageDimension = new S_PageDimension();
            oPageDimension.Index = (GRE_PAPERTYPE)Index;
            oPageDimension.Width = Width;
            oPageDimension.Height = Height;
            oPageDimension.Unit = Unit;
            mp_oPageDimensions.Add(oPageDimension);
        }

        public int GetWidth(GRE_PAPERTYPE yPageType)
        {
            int i = 0;
            int lReturn = -1;
            for (i = 0; i <= mp_oPageDimensions.Count - 1; i++)
            {
                if (mp_oPageDimensions[i].Index == yPageType)
                {
                    if (mp_oPageDimensions[i].Unit == E_UNITS.U_INCHES)
                    {
                        lReturn = System.Convert.ToInt32(mp_oPageDimensions[i].Width * 100);
                        break;
                    }
                    else if (mp_oPageDimensions[i].Unit == E_UNITS.U_MILLIMETER)
                    {
                        lReturn = System.Convert.ToInt32(mp_oPageDimensions[i].Width * (1 / 2.54) * 10);
                        break;
                    }
                }
                
            }
            if (lReturn == -1)
            {
                return mp_lCustomWidth;
            }
            else
            {
                return lReturn;
            }
        }

        public int GetHeight(GRE_PAPERTYPE yPageType)
        {
            int i = 0;
            int lReturn = -1;
            for (i = 0; i <= mp_oPageDimensions.Count - 1; i++)
            {
                if (mp_oPageDimensions[i].Index == yPageType)
                {
                    if (mp_oPageDimensions[i].Unit == E_UNITS.U_INCHES)
                    {
                        lReturn = System.Convert.ToInt32(mp_oPageDimensions[i].Height * 100);
                    }
                    else if (mp_oPageDimensions[i].Unit == E_UNITS.U_MILLIMETER)
                    {
                        lReturn = System.Convert.ToInt32(mp_oPageDimensions[i].Height * (1 / 2.54) * 10);
                    }
                    break;
                }
            }
            if (lReturn == -1)
            {
                return mp_lCustomHeight;
            }
            else
            {
                return lReturn;
            }
        }

        public int CustomWidth
        {
            get { return mp_lCustomWidth; }
            set { mp_lCustomWidth = value; }
        }

        public int CustomHeight
        {
            get { return mp_lCustomHeight; }
            set { mp_lCustomHeight = value; }
        }

    }

}