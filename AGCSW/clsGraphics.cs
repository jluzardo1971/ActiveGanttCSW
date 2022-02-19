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
using System.Windows.Controls;
using System.Windows;
using System.Windows.Shapes;

namespace AGCSW
{

    internal class clsGraphics
    {

        private struct T_PRECT
        {
            public int lLeft;
            public int lTop;
            public int lRight;
            public int lBottom;
        }

        private enum T_HATCHTYPE
        {
            HT_RECTANGLE = 1,
            HT_LINE = 2
        }

        private ActiveGanttCSWCtl mp_oControl;
        private T_PRECT mp_udtPreviousClipRegion;
        private System.Collections.ArrayList mp_audtActiveReversibleFrames;
        private System.Collections.ArrayList mp_audtActiveReversibleLinesStart;
        private System.Collections.ArrayList mp_audtActiveReversibleLinesEnd;
        private bool mp_bCustomPrinting;
        private DrawingContext mp_lCustomDC;
        private int mp_lPWidth;
        private int mp_lPHeight;
        private int mp_lFocusLeft;
        private int mp_lFocusTop;
        private int mp_lFocusRight;
        private int mp_lFocusBottom;
        private bool mp_bEnableClipRegions;
        internal DrawingContext mp_oToolTipGraphics = null;
        internal bool bToolTipGraphics;
        internal bool mp_bRequiresPop = false;

        private Line mp_oSelectionLine;
        private Rectangle mp_oSelectionRectangle;

        private int mp_lSelectionRectangleIndex = -1;
        private int mp_lSelectionLineIndex = -1;

        internal Rect mp_oTextFinalLayout;
        internal int mp_lX1;
        internal int mp_lY1;
        internal int mp_lX2;
        internal int mp_lY2;

        internal clsGraphics(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            mp_audtActiveReversibleFrames = new System.Collections.ArrayList();
            mp_audtActiveReversibleLinesStart = new System.Collections.ArrayList();
            mp_audtActiveReversibleLinesEnd = new System.Collections.ArrayList();
            mp_bCustomPrinting = false;
            mp_bEnableClipRegions = true;
            bToolTipGraphics = false;
            mp_oSelectionLine = new Line();
            mp_oSelectionRectangle = new Rectangle();
        }

        internal bool RequiresPop
        {
            get { return mp_bRequiresPop; }
            set { mp_bRequiresPop = value; }
        }

        internal bool EnableClipRegions
        {
            get { return mp_bEnableClipRegions; }
            set { mp_bEnableClipRegions = value; }
        }

        internal int f_FocusLeft
        {
            get { return mp_lFocusLeft; }
            set { mp_lFocusLeft = value; }
        }

        internal int f_FocusTop
        {
            get { return mp_lFocusTop; }
            set { mp_lFocusTop = value; }
        }

        internal int f_FocusRight
        {
            get { return mp_lFocusRight; }
            set { mp_lFocusRight = value; }
        }

        internal int f_FocusBottom
        {
            get { return mp_lFocusBottom; }
            set { mp_lFocusBottom = value; }
        }

        internal DrawingContext oGraphics
        {
            get
            {
                if (mp_bCustomPrinting == false)
                {
                    if (bToolTipGraphics == false)
                    {
                        return mp_oControl.mp_oGraphics;
                    }
                    else
                    {
                        return mp_oToolTipGraphics;
                    }
                }
                else
                {
                    return mp_lCustomDC;
                }
            }
        }

        internal bool CustomPrinting
        {
            get { return mp_bCustomPrinting; }
            set { mp_bCustomPrinting = value; }
        }

        internal DrawingContext CustomDC
        {
            get { return mp_lCustomDC; }
            set { mp_lCustomDC = value; }
        }

        internal int Width()
        {
            if (mp_bCustomPrinting == false)
            {
                return System.Convert.ToInt32(mp_oControl.ActualWidth);
            }
            else
            {
                return mp_lPWidth;
            }
        }

        internal int Height()
        {
            if (mp_bCustomPrinting == false)
            {
                return System.Convert.ToInt32(mp_oControl.ActualHeight);
            }
            else
            {
                return mp_lPHeight;
            }
        }

        internal int CustomWidth
        {
            get { return mp_lPWidth; }
            set { mp_lPWidth = value; }
        }

        internal int CustomHeight
        {
            get { return mp_lPHeight; }
            set { mp_lPHeight = value; }
        }

        internal void mp_DrawPolygon(Color clrColor, Point[] r_oPoints, bool bFilled)
        {
            PathFigure oPathFigure = new PathFigure();
            PathSegmentCollection oPathSegmentCollection = new PathSegmentCollection();
            PathGeometry oPathGeometry = new PathGeometry();
            int i = 0;
            oPathFigure.StartPoint = r_oPoints[0];
            for (i = 0; i <= r_oPoints.GetUpperBound(0); i++)
            {
                oPathSegmentCollection.Add(new LineSegment(r_oPoints[i], false));
            }
            oPathSegmentCollection.Add(new LineSegment(r_oPoints[0], false));
            oPathFigure.Segments = oPathSegmentCollection;
            oPathGeometry.Figures.Add(oPathFigure);

            oPathGeometry.Freeze();
            if (bFilled == false)
            {
                oGraphics.DrawGeometry(null, GetPen(clrColor), oPathGeometry);
            }
            else
            {
                oGraphics.DrawGeometry(GetBrush(clrColor), null, oPathGeometry);
            }
        }

        internal Pen GetPen(Color oColor)
        {
            SolidColorBrush oBrush = new SolidColorBrush();
            Pen oPen = new Pen();
            oBrush.Color = oColor;
            oBrush.Freeze();
            oPen.Brush = oBrush;
            oPen.Thickness = 1;
            oPen.Freeze();
            return oPen;
        }

        internal SolidColorBrush GetBrush(Color oColor)
        {
            SolidColorBrush oBrush = new SolidColorBrush(oColor);
            oBrush.Freeze();
            return oBrush;
        }

        internal void mp_DrawEdge(int X1, int Y1, int X2, int Y2, Color clrBackColor, GRE_BUTTONSTYLE yButtonStyle, GRE_EDGETYPE yEdgeType, bool bFilled, clsStyle oStyle)
        {
            Color lExteriorLeftTopColor = Color.FromArgb(255, 255, 255, 255);
            Color lInteriorLeftTopColor = Color.FromArgb(255, 255, 255, 255);
            Color lExteriorRightBottomColor = Color.FromArgb(255, 255, 255, 255);
            Color lInteriorRightBottomColor = Color.FromArgb(255, 255, 255, 255);
            if (yButtonStyle == GRE_BUTTONSTYLE.BT_NORMALWINDOWS)
            {
                switch (yEdgeType)
                {
                    case GRE_EDGETYPE.ET_RAISED:
                        if (oStyle == null)
                        {
                            lExteriorLeftTopColor = Color.FromArgb(255, 240, 240, 240);
                            lInteriorLeftTopColor = Color.FromArgb(255, 192, 192, 192);
                            lInteriorRightBottomColor = Color.FromArgb(255, 128, 128, 128);
                            lExteriorRightBottomColor = Color.FromArgb(255, 64, 64, 64);
                        }
                        else
                        {
                            lExteriorLeftTopColor = oStyle.ButtonBorderStyle.RaisedExteriorLeftTopColor;
                            lInteriorLeftTopColor = oStyle.ButtonBorderStyle.RaisedInteriorLeftTopColor;
                            lInteriorRightBottomColor = oStyle.ButtonBorderStyle.RaisedInteriorRightBottomColor;
                            lExteriorRightBottomColor = oStyle.ButtonBorderStyle.RaisedExteriorRightBottomColor;
                        }
                        break;
                    case GRE_EDGETYPE.ET_SUNKEN:
                        if (oStyle == null)
                        {
                            lExteriorLeftTopColor = Color.FromArgb(255, 128, 128, 128);
                            lInteriorLeftTopColor = Color.FromArgb(255, 64, 64, 64);
                            lInteriorRightBottomColor = Color.FromArgb(255, 192, 192, 192);
                            lExteriorRightBottomColor = Color.FromArgb(255, 240, 240, 240);
                        }
                        else
                        {
                            lExteriorLeftTopColor = oStyle.ButtonBorderStyle.SunkenExteriorLeftTopColor;
                            lInteriorLeftTopColor = oStyle.ButtonBorderStyle.SunkenInteriorLeftTopColor;
                            lInteriorRightBottomColor = oStyle.ButtonBorderStyle.SunkenInteriorRightBottomColor;
                            lExteriorRightBottomColor = oStyle.ButtonBorderStyle.SunkenExteriorRightBottomColor;
                        }
                        break;
                }
                // Exterior Left
                mp_DrawLine(X1, Y1, X1, Y2, GRE_LINETYPE.LT_NORMAL, lExteriorLeftTopColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                // Exterior Top
                mp_DrawLine(X1, Y1, X2, Y1, GRE_LINETYPE.LT_NORMAL, lExteriorLeftTopColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                // Exterior Right
                mp_DrawLine(X2, Y2, X2, Y1, GRE_LINETYPE.LT_NORMAL, lExteriorRightBottomColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                // Exterior Bottom
                mp_DrawLine(X1, Y2, X2, Y2, GRE_LINETYPE.LT_NORMAL, lExteriorRightBottomColor, GRE_LINEDRAWSTYLE.LDS_SOLID);

                // Interior Left
                mp_DrawLine(X1 + 1, Y1 + 1, X1 + 1, Y2 - 1, GRE_LINETYPE.LT_NORMAL, lInteriorLeftTopColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                // Interior Top
                mp_DrawLine(X1 + 1, Y1 + 1, X2 - 1, Y1 + 1, GRE_LINETYPE.LT_NORMAL, lInteriorLeftTopColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                // Interior Right
                mp_DrawLine(X2 - 1, Y2 - 1, X2 - 1, Y1 + 1, GRE_LINETYPE.LT_NORMAL, lInteriorRightBottomColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                // Interior Bottom
                mp_DrawLine(X1 + 1, Y2 - 1, X2 - 1, Y2 - 1, GRE_LINETYPE.LT_NORMAL, lInteriorRightBottomColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                if (bFilled == true)
                {
                    mp_DrawLine(X1 + 2, Y1 + 2, X2 - 2, Y2 - 2, GRE_LINETYPE.LT_FILLED, clrBackColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                }
            }
            else
            {
                switch (yEdgeType)
                {
                    case GRE_EDGETYPE.ET_RAISED:
                        if (oStyle == null)
                        {
                            lExteriorLeftTopColor = Color.FromArgb(255, 255, 255, 255);
                            lExteriorRightBottomColor = Color.FromArgb(255, 64, 64, 64);
                        }
                        else
                        {
                            lExteriorLeftTopColor = oStyle.ButtonBorderStyle.RaisedExteriorLeftTopColor;
                            lExteriorRightBottomColor = oStyle.ButtonBorderStyle.RaisedExteriorRightBottomColor;
                        }
                        break;
                    case GRE_EDGETYPE.ET_SUNKEN:
                        if (oStyle == null)
                        {
                            lExteriorLeftTopColor = Color.FromArgb(255, 128, 128, 128);
                            lExteriorRightBottomColor = Color.FromArgb(255, 245, 245, 245);
                        }
                        else
                        {
                            lExteriorLeftTopColor = oStyle.ButtonBorderStyle.SunkenExteriorLeftTopColor;
                            lExteriorRightBottomColor = oStyle.ButtonBorderStyle.SunkenExteriorRightBottomColor;
                        }
                        break;
                }
                mp_DrawLine(X1, Y1, X2, Y1, GRE_LINETYPE.LT_NORMAL, lExteriorLeftTopColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                mp_DrawLine(X1, Y1, X1, Y2, GRE_LINETYPE.LT_NORMAL, lExteriorLeftTopColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                mp_DrawLine(X1, Y2, X2, Y2, GRE_LINETYPE.LT_NORMAL, lExteriorRightBottomColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                mp_DrawLine(X2, Y2, X2, Y1 - 1, GRE_LINETYPE.LT_NORMAL, lExteriorRightBottomColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                if (bFilled == true)
                {
                    mp_DrawLine(X1 + 1, Y1 + 1, X2 - 1, Y2 - 1, GRE_LINETYPE.LT_FILLED, clrBackColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                }
            }
        }

        internal void mp_DrawLine(int X1, int Y1, int X2, int Y2, GRE_LINETYPE yStyle, Color clrColor, GRE_LINEDRAWSTYLE yDrawStyle)
        {
            mp_DrawLine(X1, Y1, X2, Y2, yStyle, clrColor, yDrawStyle, 1, true);
        }

        internal void mp_DrawLine(int X1, int Y1, int X2, int Y2, GRE_LINETYPE yStyle, Color clrColor, GRE_LINEDRAWSTYLE yDrawStyle, int lWidth)
        {
            mp_DrawLine(X1, Y1, X2, Y2, yStyle, clrColor, yDrawStyle, lWidth, true);
        }

        internal void mp_CorrectRectCoords(ref int X1, ref int Y1, ref int X2, ref int Y2)
        {
            int iBuff = 0;
            if ((X2 - X1) < 0)
            {
                iBuff = X1;
                X1 = X2;
                X2 = iBuff;
            }
            if ((Y2 - Y1) < 0)
            {
                iBuff = Y1;
                Y1 = Y2;
                Y2 = iBuff;
            }
        }

        internal void mp_DrawLine(int X1, int Y1, int X2, int Y2, GRE_LINETYPE yStyle, Color clrColor, GRE_LINEDRAWSTYLE yDrawStyle, int lWidth, bool bCreatePens)
        {
            mp_CorrectRectCoords(ref X1, ref Y1, ref X2, ref Y2);
            switch (yStyle)
            {
                case GRE_LINETYPE.LT_NORMAL:
                    if (X1 != X2)
                    {
                        X2 = X2 + 1;
                    }

                    if (Y1 != Y2)
                    {
                        Y2 = Y2 + 1;
                    }

                    if (X1 == X2)
                    {
                        X1 = X1 + 1;
                        X2 = X2 + 1;
                    }

                    if (Y1 == Y2)
                    {
                        Y1 = Y1 + 1;
                        Y2 = Y2 + 1;
                    }

                    if (yDrawStyle == GRE_LINEDRAWSTYLE.LDS_SOLID)
                    {
                        oGraphics.DrawLine(GetPen(clrColor), new Point(X1, Y1), new Point(X2, Y2));
                    }
                    else if (yDrawStyle == GRE_LINEDRAWSTYLE.LDS_DOT)
                    {
                        Pen oPen = new Pen(GetBrush(Color.FromArgb(255, 128, 128, 128)), 1);
                        oPen.DashStyle = DashStyles.Dot;
                        oGraphics.DrawLine(oPen, new Point(X1, Y1), new Point(X2, Y2));
                    }

                    break;
                case GRE_LINETYPE.LT_BORDER:
                    if (yDrawStyle == GRE_LINEDRAWSTYLE.LDS_SOLID)
                    {
                        oGraphics.DrawRectangle(null, GetPen(clrColor), new Rect(new Point(X1 + 1, Y1 + 1), new Point(X2 + 1, Y2 + 1)));
                    }
                    else if (yDrawStyle == GRE_LINEDRAWSTYLE.LDS_DOT)
                    {
                        Pen oPen = new Pen(GetBrush(Color.FromArgb(255, 128, 128, 128)), 1);
                        oPen.DashStyle = DashStyles.Dot;
                        oGraphics.DrawRectangle(null, oPen, new Rect(new Point(X1 + 1, Y1 + 1), new Point(X2 + 1, Y2 + 1)));
                    }

                    break;
                case GRE_LINETYPE.LT_FILLED:
                    if (X1 != X2)
                    {
                        X2 = X2 - 1;
                    }

                    if (Y1 != Y2)
                    {
                        Y2 = Y2 - 1;
                    }

                    oGraphics.DrawRectangle(GetBrush(clrColor), null, new Rect(X1, Y1, X2 - X1 + 2, Y2 - Y1 + 2));
                    break;
            }
        }

        internal void mp_DrawFigure(int X, int Y, int lDx, int lDy, GRE_FIGURETYPE yFigureType, Color clrBorderColor, Color clrFillColor, GRE_LINEDRAWSTYLE yBorderStyle)
        {
            if (lDx % 2 != 0)
            {
                lDx = lDx + 1;
                lDy = lDy + 1;
            }
            switch (yFigureType)
            {
                case GRE_FIGURETYPE.FT_PROJECTUP:
                    {
                        Point[] Points = new Point[5];
                        Points[0].X = X;
                        Points[0].Y = Y;
                        Points[1].X = X + lDx / 2;
                        Points[1].Y = Y + lDy / 2;
                        Points[2].X = X + lDx / 2;
                        Points[2].Y = Y + lDy;
                        Points[3].X = X - lDx / 2;
                        Points[3].Y = Y + lDy;
                        Points[4].X = X - lDx / 2;
                        Points[4].Y = Y + lDy / 2;
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_PROJECTDOWN:
                    {
                        Point[] Points = new Point[5];
                        Points[0].X = X + lDx / 2;
                        Points[0].Y = Y;
                        Points[1].X = X + lDx / 2;
                        Points[1].Y = Y + lDy / 2;
                        Points[2].X = X;
                        Points[2].Y = Y + lDy;
                        Points[3].X = X - lDx / 2;
                        Points[3].Y = Y + lDy / 2;
                        Points[4].X = X - lDx / 2;
                        Points[4].Y = Y;
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_DIAMOND:
                    {
                        Point[] Points = new Point[4];
                        Points[0].X = X;
                        Points[0].Y = Y;
                        Points[1].X = X + lDx / 2;
                        Points[1].Y = Y + lDy / 2;
                        Points[2].X = X;
                        Points[2].Y = Y + lDy;
                        Points[3].X = X - lDx / 2;
                        Points[3].Y = Y + lDy / 2;
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_CIRCLEDIAMOND:
                    {
                        Point[] Points = new Point[4];
                        Points[0].X = X;
                        Points[0].Y = Y + lDy / 4;
                        Points[1].X = X + lDx / 4;
                        Points[1].Y = Y + lDy / 2;
                        Points[2].X = X;
                        Points[2].Y = Y + (3 * lDy) / 4;
                        Points[3].X = X - lDx / 4;
                        Points[3].Y = Y + lDy / 2;
                        mp_DrawEllipse(clrBorderColor, mp_oControl.MathLib.RoundDouble(X - lDx / 2), Y, lDx, lDy);
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_TRIANGLEUP:
                    {
                        Point[] Points = new Point[3];
                        Points[0].X = X;
                        Points[0].Y = Y;
                        Points[1].X = X + lDx / 2;
                        Points[1].Y = Y + lDy;
                        Points[2].X = X - lDx / 2;
                        Points[2].Y = Y + lDy;
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_TRIANGLEDOWN:
                    {
                        Point[] Points = new Point[3];
                        Points[0].X = X + lDx / 2;
                        Points[0].Y = Y;
                        Points[1].X = X - lDx / 2;
                        Points[1].Y = Y;
                        Points[2].X = X;
                        Points[2].Y = Y + lDy;
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_TRIANGLERIGHT:
                    {
                        Point[] Points = new Point[3];
                        Points[0].X = X;
                        Points[0].Y = Y;
                        Points[1].X = X;
                        Points[1].Y = Y + lDy;
                        Points[2].X = X + lDx;
                        Points[2].Y = Y + lDy / 2;
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_TRIANGLELEFT:
                    {
                        Point[] Points = new Point[3];
                        Points[0].X = X;
                        Points[0].Y = Y;
                        Points[1].X = X;
                        Points[1].Y = Y + lDy;
                        Points[2].X = X - lDx;
                        Points[2].Y = Y + lDy / 2;
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_CIRCLETRIANGLEUP:
                    {
                        Point[] Points = new Point[3];
                        Points[0].X = X;
                        Points[0].Y = Y + lDy / 4;
                        Points[1].X = X + lDx / 4;
                        Points[1].Y = Y + (3 * lDy) / 4;
                        Points[2].X = X - lDx / 4;
                        Points[2].Y = Y + (3 * lDy) / 4;
                        mp_DrawEllipse(clrBorderColor, mp_oControl.MathLib.RoundDouble(X - lDx / 2), Y, lDx, lDy);
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_CIRCLETRIANGLEDOWN:
                    {
                        Point[] Points = new Point[3];
                        Points[0].X = X - lDx / 4;
                        Points[0].Y = Y + lDy / 4;
                        Points[1].X = X + lDx / 4;
                        Points[1].Y = Y + lDy / 4;
                        Points[2].X = X;
                        Points[2].Y = Y + (3 * lDy) / 4;
                        mp_DrawEllipse(clrBorderColor, mp_oControl.MathLib.RoundDouble(X - lDx / 2), Y, lDx, lDy);
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_ARROWUP:
                    {
                        Point[] Points = new Point[7];
                        Points[0].X = X;
                        Points[0].Y = Y;
                        Points[1].X = X + lDx / 2;
                        Points[1].Y = Y + lDy / 2;
                        Points[2].X = X + lDx / 4;
                        Points[2].Y = Y + lDy / 2;
                        Points[3].X = X + lDx / 4;
                        Points[3].Y = Y + lDy;
                        Points[4].X = X - lDx / 4;
                        Points[4].Y = Y + lDy;
                        Points[5].X = X - lDx / 4;
                        Points[5].Y = Y + lDy / 2;
                        Points[6].X = X - lDx / 2;
                        Points[6].Y = Y + lDy / 2;
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_ARROWDOWN:
                    {
                        Point[] Points = new Point[7];
                        Points[0].X = X - lDx / 4;
                        Points[0].Y = Y;
                        Points[1].X = X + lDx / 4;
                        Points[1].Y = Y;
                        Points[2].X = X + lDx / 4;
                        Points[2].Y = Y + lDy / 2;
                        Points[3].X = X + lDx / 2;
                        Points[3].Y = Y + lDy / 2;
                        Points[4].X = X;
                        Points[4].Y = Y + lDy;
                        Points[5].X = X - lDx / 2;
                        Points[5].Y = Y + lDy / 2;
                        Points[6].X = X - lDx / 4;
                        Points[6].Y = Y + lDy / 2;
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_CIRCLEARROWUP:
                    {
                        Point[] Points = new Point[7];
                        Points[0].X = X;
                        Points[0].Y = Y + lDy / 4;
                        Points[1].X = X + lDx / 4;
                        Points[1].Y = Y + lDy / 2;
                        Points[2].X = X + lDx / 8;
                        Points[2].Y = Y + lDy / 2;
                        Points[3].X = X + lDx / 8;
                        Points[3].Y = Y + (3 * lDy) / 4;
                        Points[4].X = X - lDx / 8;
                        Points[4].Y = Y + (3 * lDy) / 4;
                        Points[5].X = X - lDx / 8;
                        Points[5].Y = Y + lDy / 2;
                        Points[6].X = X - lDx / 4;
                        Points[6].Y = Y + lDy / 2;
                        mp_DrawEllipse(clrBorderColor, mp_oControl.MathLib.RoundDouble(X - lDx / 2), Y, lDx, lDy);
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_CIRCLEARROWDOWN:
                    {
                        Point[] Points = new Point[7];
                        Points[0].X = X - lDx / 8;
                        Points[0].Y = Y + lDy / 4;
                        Points[1].X = X + lDx / 8;
                        Points[1].Y = Y + lDy / 4;
                        Points[2].X = X + lDx / 8;
                        Points[2].Y = Y + lDy / 2;
                        Points[3].X = X + lDx / 4;
                        Points[3].Y = Y + lDy / 2;
                        Points[4].X = X;
                        Points[4].Y = Y + (3 * lDy) / 4;
                        Points[5].X = X - lDx / 4;
                        Points[5].Y = Y + lDy / 2;
                        Points[6].X = X - lDx / 8;
                        Points[6].Y = Y + lDy / 2;
                        mp_DrawEllipse(clrBorderColor, mp_oControl.MathLib.RoundDouble(X - lDx / 2), Y, lDx, lDy);
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_SMALLPROJECTUP:
                    {
                        Point[] Points = new Point[5];
                        Points[0].X = X;
                        Points[0].Y = Y + lDy / 2;
                        Points[1].X = X + lDx / 4;
                        Points[1].Y = Y + (3 * lDy) / 4;
                        Points[2].X = X + lDx / 4;
                        Points[2].Y = Y + lDy;
                        Points[3].X = X - lDx / 4;
                        Points[3].Y = Y + lDy;
                        Points[4].X = X - lDx / 4;
                        Points[4].Y = Y + (3 * lDy) / 4;
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_SMALLPROJECTDOWN:
                    {
                        Point[] Points = new Point[5];
                        Points[0].X = X + lDx / 4;
                        Points[0].Y = Y;
                        Points[1].X = X + lDx / 4;
                        Points[1].Y = Y + lDy / 4;
                        Points[2].X = X;
                        Points[2].Y = Y + lDy / 2;
                        Points[3].X = X - lDx / 4;
                        Points[3].Y = Y + lDy / 4;
                        Points[4].X = X - lDx / 4;
                        Points[4].Y = Y;
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_RECTANGLE:
                    {
                        Point[] Points = new Point[4];
                        Points[0].X = X - lDx / 8;
                        Points[0].Y = Y;
                        Points[1].X = X + lDx / 8;
                        Points[1].Y = Y;
                        Points[2].X = X + lDx / 8;
                        Points[2].Y = Y + lDy;
                        Points[3].X = X - lDx / 8;
                        Points[3].Y = Y + lDy;
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_SQUARE:
                    {
                        Point[] Points = new Point[4];
                        Points[0].X = X - lDx / 4;
                        Points[0].Y = Y + lDx / 4;
                        Points[1].X = X + lDx / 4;
                        Points[1].Y = Y + lDx / 4;
                        Points[2].X = X + lDx / 4;
                        Points[2].Y = Y + (3 * lDy) / 4;
                        Points[3].X = X - lDx / 4;
                        Points[3].Y = Y + (3 * lDy) / 4;
                        mp_DrawFigureAux(clrFillColor, clrBorderColor, Points);
                    }
                    break;
                case GRE_FIGURETYPE.FT_CIRCLE:
                    mp_FillEllipse(clrFillColor, (float)X - lDx / 2, (float)Y, (float)lDx, (float)lDy);
                    break;
                default:
                    return;
            }

        }

        private void mp_DrawFigureAux(Color BrushColor, Color PenColor, Point[] oPoints)
        {
            mp_DrawPolygon(BrushColor, oPoints, true);
            mp_DrawPolygon(PenColor, oPoints, false);
        }

        private void mp_DrawEllipse(Color PenColor, float left, float Top, float width, float height)
        {
            oGraphics.DrawEllipse(null, GetPen(PenColor), new Point(left + (width / 2), Top + (height / 2)), width / 2, height / 2);
        }

        private void mp_FillEllipse(Color BrushColor, float left, float Top, float width, float height)
        {
            oGraphics.DrawEllipse(GetBrush(BrushColor), null, new Point(left + (width / 2), Top + (height / 2)), width / 2, height / 2);
        }

        internal void mp_DrawPattern(int X1, int Y1, int X2, int Y2, Color clrColor, GRE_PATTERN yDrawStyle, int lPatternFactor)
        {
            int tmp = 0;
            int c = 0;
            int c1 = 0;
            int c2 = 0;
            int i1 = 0;
            int j1 = 0;
            int i2 = 0;
            int j2 = 0;
            if (X1 > X2)
            {
                tmp = X1;
                X1 = X2;
                X2 = tmp;
            }
            if (Y1 > Y2)
            {
                tmp = Y1;
                Y1 = Y2;
                Y2 = tmp;
            }
            if (yDrawStyle == GRE_PATTERN.FP_HORIZONTALLINE | yDrawStyle == GRE_PATTERN.FP_CROSS)
            {
                for (j1 = (Y1 + lPatternFactor); j1 <= Y2; j1 += lPatternFactor)
                {
                    mp_DrawLine(X1, j1, X2, j1, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                }
            }
            if (yDrawStyle == GRE_PATTERN.FP_VERTICALLINE | yDrawStyle == GRE_PATTERN.FP_CROSS)
            {
                for (j1 = (X1 + lPatternFactor); j1 <= X2; j1 += lPatternFactor)
                {
                    mp_DrawLine(j1, Y1, j1, Y2, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                }
            }
            if (yDrawStyle == GRE_PATTERN.FP_UPWARDDIAGONAL | yDrawStyle == GRE_PATTERN.FP_DIAGONALCROSS)
            {
                c1 = System.Convert.ToInt32((Y1 + X1) / lPatternFactor + 1);
                c2 = System.Convert.ToInt32((Y2 + X2) / lPatternFactor);
                for (c = c1; c <= c2; c++)
                {
                    i1 = X1;
                    i2 = X2;
                    j1 = c * lPatternFactor - i1;
                    j2 = c * lPatternFactor - i2;
                    if (j2 < Y1)
                    {
                        i2 = c * lPatternFactor - Y1;
                        j2 = c * lPatternFactor - i2;
                    }
                    if (j1 > Y2)
                    {
                        i1 = c * lPatternFactor - Y2;
                        j1 = c * lPatternFactor - i1;
                    }
                    mp_DrawLine(i1, j1, i2, j2, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID, 1, false);
                }
            }
            if (yDrawStyle == GRE_PATTERN.FP_DOWNWARDDIAGONAL | yDrawStyle == GRE_PATTERN.FP_DIAGONALCROSS)
            {
                c1 = System.Convert.ToInt32((Y1 - X2) / lPatternFactor + 1);
                c2 = System.Convert.ToInt32((Y2 - X1) / lPatternFactor);
                for (c = c1; c <= c2; c++)
                {
                    i1 = X1;
                    i2 = X2;
                    j1 = i1 + c * lPatternFactor;
                    j2 = i2 + c * lPatternFactor;
                    if (j1 < Y1)
                    {
                        i1 = Y1 - c * lPatternFactor;
                        j1 = i1 + c * lPatternFactor;
                    }
                    if (j2 > Y2)
                    {
                        i2 = Y2 - c * lPatternFactor;
                        j2 = i2 + c * lPatternFactor;
                    }
                    mp_DrawLine(i1, j1, i2, j2, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID, 1, false);
                }
            }
            if (yDrawStyle == GRE_PATTERN.FP_LIGHT)
            {
                for (j1 = (Y1 + 1); j1 <= (Y2 - 1); j1++)
                {
                    if (j1 % 2 == 0)
                    {
                        for (j2 = (X1 + 1); j2 <= (X2 - 1); j2 += 4)
                        {
                            mp_DrawLine(j2, j1, j2 + 1, j1, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        }
                    }
                    else
                    {
                        for (j2 = (X1 + 3); j2 <= (X2 - 1); j2 += 4)
                        {
                            mp_DrawLine(j2, j1, j2 + 1, j1, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        }
                    }
                }
            }
            if (yDrawStyle == GRE_PATTERN.FP_MEDIUM)
            {
                for (j1 = (Y1 + 1); j1 <= (Y2 - 1); j1++)
                {
                    if (j1 % 2 == 0)
                    {
                        for (j2 = (X1 + 1); j2 <= (X2 - 1); j2 += 2)
                        {
                            mp_DrawLine(j2, j1, j2 + 1, j1, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        }
                    }
                    else
                    {
                        for (j2 = (X1 + 2); j2 <= (X2 - 1); j2 += 2)
                        {
                            mp_DrawLine(j2, j1, j2 + 1, j1, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        }
                    }
                }
            }
            if (yDrawStyle == GRE_PATTERN.FP_DARK)
            {
                for (j1 = (Y1 + 1); j1 <= (Y2 - 1); j1++)
                {
                    if (j1 % 2 == 0)
                    {
                        for (j2 = (X1 + 1); j2 <= (X2 - 1); j2 += 4)
                        {
                            if (j2 + 3 < X2)
                            {
                                mp_DrawLine(j2, j1, j2 + 3, j1, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                            }
                            else
                            {
                                mp_DrawLine(j2, j1, X2, j1, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                            }
                        }
                    }
                    else
                    {
                        mp_DrawLine(X1, j1, X1 + 2, j1, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        for (j2 = (X1 + 3); j2 <= (X2 - 1); j2 += 4)
                        {
                            if (j2 + 3 < X2)
                            {
                                mp_DrawLine(j2, j1, j2 + 3, j1, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                            }
                            else
                            {
                                mp_DrawLine(j2, j1, X2, j1, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                            }
                        }
                    }
                }
            }
        }

        internal void mp_DrawTextEx(int X1, int Y1, int X2, int Y2, string sParam, clsTextFlags yFlags, Color clrColor, Font oFont, bool bClip)
        {
            Typeface oTypeFace = new Typeface(oFont.FamilyName);
            FormattedText oFormattedText = new FormattedText(sParam, mp_oControl.Culture, FlowDirection.LeftToRight, oTypeFace, oFont.WPFFontSize, new SolidColorBrush(clrColor));
            int X = 0;
            int Y = 0;
            switch (yFlags.HorizontalAlignment)
            {
                case GRE_HORIZONTALALIGNMENT.HAL_LEFT:
                    X = (int)System.Convert.ToDouble(X1);
                    break;
                case GRE_HORIZONTALALIGNMENT.HAL_CENTER:
                    X = (int)System.Convert.ToDouble(((X2 - X1) - oFormattedText.Width) / 2) + X1;
                    break;
                case GRE_HORIZONTALALIGNMENT.HAL_RIGHT:
                    X = (int)System.Convert.ToDouble(X2 - oFormattedText.Width);
                    break;
            }
            switch (yFlags.VerticalAlignment)
            {
                case GRE_VERTICALALIGNMENT.VAL_TOP:
                    Y = (int)System.Convert.ToDouble(Y1);
                    break;
                case GRE_VERTICALALIGNMENT.VAL_CENTER:
                    Y = (int)System.Convert.ToDouble(((Y2 - Y1) - oFormattedText.Height) / 2) + Y1;
                    break;
                case GRE_VERTICALALIGNMENT.VAL_BOTTOM:
                    Y = (int)System.Convert.ToDouble(Y2 - oFormattedText.Height);
                    break;
            }
            oFormattedText.SetFontWeight(oFont.FontWeight);
            oGraphics.DrawText(oFormattedText, new Point(X, Y));
            if (sParam.Length > 0)
            {
                mp_oTextFinalLayout.X = X;
                mp_oTextFinalLayout.Y = Y;
                mp_oTextFinalLayout.Width = oFormattedText.Width + mp_lStrWidth("W", oFont);
                mp_oTextFinalLayout.Height = oFormattedText.Height;
            }
        }

        internal void mp_DrawAlignedText(int X1, int Y1, int X2, int Y2, string sParam, GRE_HORIZONTALALIGNMENT yHPos, GRE_VERTICALALIGNMENT yVPos, Color clrColor, Font oFont)
        {
            mp_DrawAlignedText(X1, Y1, X2, Y2, sParam, yHPos, yVPos, clrColor, oFont, true
            );
        }

        internal void mp_DrawAlignedText(int X1, int Y1, int X2, int Y2, string sParam, GRE_HORIZONTALALIGNMENT yHPos, GRE_VERTICALALIGNMENT yVPos, Color clrColor, Font oFont, bool bClip)
        {
            Typeface oTypeFace = new Typeface(oFont.FamilyName);
            FormattedText oFormattedText = new FormattedText(sParam, mp_oControl.Culture, FlowDirection.LeftToRight, oTypeFace, oFont.WPFFontSize, new SolidColorBrush(clrColor));
            int X = 0;
            int Y = 0;
            switch (yHPos)
            {
                case GRE_HORIZONTALALIGNMENT.HAL_LEFT:
                    X = X1;
                    oFormattedText.TextAlignment = TextAlignment.Left;
                    break;
                case GRE_HORIZONTALALIGNMENT.HAL_CENTER:
                    X = (int)(System.Convert.ToDouble((X2 - X1) / 2) + (double)X1);
                    oFormattedText.TextAlignment = TextAlignment.Center;
                    break;
                case GRE_HORIZONTALALIGNMENT.HAL_RIGHT:
                    X = X2;
                    oFormattedText.TextAlignment = TextAlignment.Right;
                    break;
            }
            switch (yVPos)
            {
                case GRE_VERTICALALIGNMENT.VAL_TOP:
                    Y = (int)System.Convert.ToDouble(Y1);
                    break;
                case GRE_VERTICALALIGNMENT.VAL_CENTER:
                    Y = (int)System.Convert.ToDouble(((Y2 - Y1) - oFormattedText.Height) / 2) + Y1;
                    break;
                case GRE_VERTICALALIGNMENT.VAL_BOTTOM:
                    Y = (int)System.Convert.ToDouble(Y2 - oFormattedText.Height);
                    break;
            }
            oFormattedText.SetFontWeight(oFont.FontWeight);
            oGraphics.DrawText(oFormattedText, new Point(X, Y));
            if (sParam.Length > 0)
            {
                mp_oTextFinalLayout.X = X;
                mp_oTextFinalLayout.Y = Y;
                mp_oTextFinalLayout.Width = oFormattedText.Width + mp_lStrWidth("W", oFont);
                mp_oTextFinalLayout.Height = oFormattedText.Height;
            }
        }

        internal int mp_lStrWidth(string sString, Font r_oFont)
        {
            Typeface oTypeFace = new Typeface(r_oFont.FamilyName);
            FormattedText oFormattedText = new FormattedText(sString, mp_oControl.Culture, FlowDirection.LeftToRight, oTypeFace, r_oFont.WPFFontSize, new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)));
            return System.Convert.ToInt32(oFormattedText.Width);
        }

        internal int mp_lStrHeight(string sString, Font r_oFont)
        {
            Typeface oTypeFace = new Typeface(r_oFont.FamilyName);
            FormattedText oFormattedText = new FormattedText(sString, mp_oControl.Culture, FlowDirection.LeftToRight, oTypeFace, r_oFont.WPFFontSize, new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)));
            return System.Convert.ToInt32(oFormattedText.Height);
        }

        internal void mp_ClipRegion(int X1, int Y1, int X2, int Y2, bool bStore)
        {
            if ((mp_bEnableClipRegions == false))
            {
                return;
            }
            if (mp_bRequiresPop == true)
            {
                oGraphics.Pop();
                mp_bRequiresPop = false;
            }
            mp_CorrectRectCoords(ref X1, ref Y1, ref X2, ref Y2);
            if (mp_bCustomPrinting == true)
            {
                if (X1 < mp_lX1)
                {
                    X1 = mp_lX1;
                }
                if (Y1 < mp_lY1)
                {
                    Y1 = mp_lY1;
                }
                if (X2 > mp_lX2)
                {
                    X2 = mp_lX2;
                }
                if (Y2 > mp_lY2)
                {
                    Y2 = mp_lY2;
                }
                if ((X1 > mp_lX2) | (Y1 > mp_lY2) | (X2 < mp_lX1) | (Y2 < mp_lY1))
                {
                    X1 = 0;
                    Y1 = 0;
                    X2 = 0;
                    Y2 = 0;
                }
            }
            RectangleGeometry oRectangle = new RectangleGeometry(new Rect(X1, Y1, X2 - X1 + 1, Y2 - Y1 + 1));
            oRectangle.Freeze();
            if (bStore == true)
            {
                mp_udtPreviousClipRegion.lLeft = X1;
                mp_udtPreviousClipRegion.lRight = X2;
                mp_udtPreviousClipRegion.lTop = Y1;
                mp_udtPreviousClipRegion.lBottom = Y2;
            }
            oGraphics.PushClip(oRectangle);
            mp_bRequiresPop = true;
        }

        internal void mp_ClearClipRegion()
        {
            if (mp_bRequiresPop == true)
            {
                oGraphics.Pop();
                mp_bRequiresPop = false;
            }
        }

        internal void mp_TileImageHorizontal(Image oImageHandle, int X1, int Y1, int X2, int Y2, bool bTransparent)
        {
            int XBuff = 0;
            int lImageWidth = 0;
            int lImageHeight = 0;
            lImageHeight = (int)oImageHandle.Source.Height;
            lImageWidth = (int)oImageHandle.Source.Width;
            while (XBuff < (X2 - X1))
            {
                if ((XBuff + lImageWidth) > (X2 - X1))
                {
                    mp_PaintImage(oImageHandle, X2 - lImageWidth, Y1, X2, Y1 + lImageHeight, 0, 0, bTransparent);
                }
                else
                {
                    mp_PaintImage(oImageHandle, X1 + XBuff, Y1, X1 + XBuff + lImageWidth, Y1 + lImageHeight, 0, 0, bTransparent);
                }
                XBuff = XBuff + lImageWidth;
            }
        }

        internal void mp_PaintImage(Image Image, int X1, int Y1, int X2, int Y2, int xOrigin, int yOrigin, bool bUseMask)
        {

            if (xOrigin != 0 | yOrigin != 0)
            {
            }
            else
            {

            }
            oGraphics.DrawImage(Image.Source, new Rect(X1, Y1, X2 - X1, Y2 - Y1));
        }

        internal void mp_DrawImage(Image oImage, GRE_HORIZONTALALIGNMENT yHorizontalAlignment, GRE_VERTICALALIGNMENT yVerticalAlignment, int lImageXMargin, int lImageYMargin, int X1, int X2, int Y1, int Y2, bool bTransparent)
        {
            bool bDrawImage = false;
            bool bHorizontalSmall = false;
            bool bVerticalSmall = false;
            int XOrigin = 0;
            int YOrigin = 0;
            int xDest = 0;
            int yDest = 0;
            int lxWidth = 0;
            int lyHeight = 0;
            int lImageHeight = 0;
            int lImageWidth = 0;
            if ((oImage == null))
            {
                return;
            }
            lImageHeight = (int)oImage.Source.Height;
            lImageWidth = (int)oImage.Source.Width;
            if (yHorizontalAlignment == GRE_HORIZONTALALIGNMENT.HAL_CENTER)
            {
                lImageXMargin = 0;
            }
            if (yVerticalAlignment == GRE_VERTICALALIGNMENT.VAL_CENTER)
            {
                lImageYMargin = 0;
            }
            bDrawImage = true;
            if ((X2 - X1) < (lImageWidth + lImageXMargin))
            {
                lxWidth = X2 - X1 - lImageXMargin;
                if (lxWidth <= 0) bDrawImage = false;
                bHorizontalSmall = true;
            }
            else
            {
                lxWidth = lImageWidth;
                bHorizontalSmall = false;
            }
            if ((Y2 - Y1) < (lImageHeight + lImageYMargin))
            {
                lyHeight = Y2 - Y1 - lImageYMargin;
                if (lyHeight <= 0) bDrawImage = false;
                bVerticalSmall = true;
            }
            else
            {
                lyHeight = lImageHeight;
                bVerticalSmall = false;
            }
            if (bHorizontalSmall == false)
            {
                switch (yHorizontalAlignment)
                {
                    case GRE_HORIZONTALALIGNMENT.HAL_LEFT:
                        xDest = X1 + lImageXMargin;
                        break;
                    case GRE_HORIZONTALALIGNMENT.HAL_CENTER:
                        xDest = ((X2 - X1) - lImageWidth) / 2 + X1;
                        break;
                    case GRE_HORIZONTALALIGNMENT.HAL_RIGHT:
                        xDest = X2 - lImageWidth - lImageXMargin;
                        break;
                }
                XOrigin = 0;
            }
            else
            {
                switch (yHorizontalAlignment)
                {
                    case GRE_HORIZONTALALIGNMENT.HAL_LEFT:
                        XOrigin = 0;
                        xDest = X1 + lImageXMargin;
                        break;
                    case GRE_HORIZONTALALIGNMENT.HAL_CENTER:
                        XOrigin = (lImageWidth - lxWidth) / 2;
                        xDest = X1;
                        break;
                    case GRE_HORIZONTALALIGNMENT.HAL_RIGHT:
                        XOrigin = lImageWidth - lxWidth;
                        xDest = X2 - lxWidth - lImageXMargin;
                        break;
                }
            }
            if (bVerticalSmall == false)
            {
                switch (yVerticalAlignment)
                {
                    case GRE_VERTICALALIGNMENT.VAL_TOP:
                        yDest = Y1 + lImageYMargin;
                        break;
                    case GRE_VERTICALALIGNMENT.VAL_CENTER:
                        yDest = ((Y2 - Y1) - lImageHeight) / 2 + Y1;
                        break;
                    case GRE_VERTICALALIGNMENT.VAL_BOTTOM:
                        yDest = Y2 - lImageHeight - lImageYMargin;
                        break;
                }
                YOrigin = 0;
            }
            else
            {
                switch (yVerticalAlignment)
                {
                    case GRE_VERTICALALIGNMENT.VAL_TOP:
                        YOrigin = 0;
                        yDest = Y1 + lImageYMargin;
                        break;
                    case GRE_VERTICALALIGNMENT.VAL_CENTER:
                        YOrigin = (lImageHeight - lyHeight) / 2;
                        yDest = Y1;
                        break;
                    case GRE_VERTICALALIGNMENT.VAL_BOTTOM:
                        YOrigin = lImageHeight - lyHeight;
                        yDest = Y2 - lyHeight - lImageYMargin;
                        break;
                }
            }
            if (bDrawImage == true)
            {
                mp_PaintImage(oImage, xDest, yDest, xDest + lxWidth, yDest + lyHeight, XOrigin, YOrigin, bTransparent);
            }
        }

        internal void mp_DrawFocusRectangle(int X1, int Y1, int X2, int Y2)
        {
            mp_DrawLine(X1, Y1, X2, Y2, GRE_LINETYPE.LT_BORDER, Color.FromArgb(255, 0, 0, 0), GRE_LINEDRAWSTYLE.LDS_DOT);
        }

        internal void mp_GradientFill(int X1, int Y1, int X2, int Y2, Color clrStartColor, Color clrEndColor, GRE_GRADIENTFILLMODE yGradientType)
        {
            if ((X2 - X1) <= 0)
            {
                return;
            }
            if ((Y2 - Y1) <= 0)
            {
                return;
            }
            LinearGradientBrush mp_ucBrush = null;
            if ((yGradientType == GRE_GRADIENTFILLMODE.GDT_VERTICAL))
            {
                mp_ucBrush = new LinearGradientBrush(clrStartColor, clrEndColor, 90.0);
            }
            else if ((yGradientType == GRE_GRADIENTFILLMODE.GDT_HORIZONTAL))
            {
                mp_ucBrush = new LinearGradientBrush(clrStartColor, clrEndColor, 0.0);
            }
            mp_ucBrush.Freeze();
            oGraphics.DrawRectangle(mp_ucBrush, null, new Rect(X1, Y1, X2 - X1 + 1, Y2 - Y1 + 1));
        }

        internal void mp_HatchFill(int X1, int Y1, int X2, int Y2, Color clrForeColor, Color clrBackColor, GRE_HATCHSTYLE yHatchStyle)
        {
            DrawingBrush oBrush = new DrawingBrush();
            GeometryGroup oHatchGroup = new GeometryGroup();
            GeometryGroup oHatchCtrlGroup = new GeometryGroup();
            int lWidth = 0;
            int lHeight = 0;
            T_HATCHTYPE yType = T_HATCHTYPE.HT_LINE;
            bool bAliased = true;
            int iBuff = 0;
            if ((X2 - X1) <= 0)
            {
                iBuff = X1;
                X1 = X2;
                X2 = iBuff;
            }
            if ((Y2 - Y1) <= 0)
            {
                iBuff = Y1;
                Y1 = Y2;
                Y2 = iBuff;
            }
            switch (yHatchStyle)
            {
                case GRE_HATCHSTYLE.HS_HORIZONTAL:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GLine(0, 0, 7, 0));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_VERTICAL:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GLine(0, 0, 0, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_FORWARDDIAGONAL:
                    lWidth = 16;
                    lHeight = 16;
                    oHatchGroup.Children.Add(mp_GLine(0, 12, 3, 15));
                    oHatchGroup.Children.Add(mp_GLine(0, 4, 11, 15));
                    oHatchGroup.Children.Add(mp_GLine(4, 0, 15, 11));
                    oHatchGroup.Children.Add(mp_GLine(12, 0, 15, 3));
                    System.Diagnostics.Debug.Write(oHatchGroup);
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_BACKWARDDIAGONAL:
                    lWidth = 16;
                    lHeight = 16;
                    oHatchGroup.Children.Add(mp_GLine(0, 12, 3, 15));
                    oHatchGroup.Children.Add(mp_GLine(0, 4, 11, 15));
                    oHatchGroup.Children.Add(mp_GLine(4, 0, 15, 11));
                    oHatchGroup.Children.Add(mp_GLine(12, 0, 15, 3));
                    oHatchGroup.Transform = new RotateTransform(90, 8, 8);
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_LARGEGRID:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GLine(0, 0, 7, 0));
                    oHatchGroup.Children.Add(mp_GLine(0, 0, 0, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_DIAGONALCROSS:
                    lWidth = 7;
                    lHeight = 7;
                    oHatchGroup.Children.Add(mp_GRect(1, 1, 5, 5));
                    oHatchGroup.Transform = new RotateTransform(45, 3, 3);
                    yType = T_HATCHTYPE.HT_LINE;
                    bAliased = false;
                    break;
                case GRE_HATCHSTYLE.HS_PERCENT05:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(0, 4));
                    oHatchGroup.Children.Add(mp_GPoint(4, 0));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_PERCENT10:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(0, 2));
                    oHatchGroup.Children.Add(mp_GPoint(4, 0));
                    oHatchGroup.Children.Add(mp_GPoint(0, 6));
                    oHatchGroup.Children.Add(mp_GPoint(4, 4));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_PERCENT20:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GPoint(0, 0));
                    oHatchGroup.Children.Add(mp_GPoint(2, 2));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_PERCENT25:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GPoint(0, 0));
                    oHatchGroup.Children.Add(mp_GPoint(0, 2));
                    oHatchGroup.Children.Add(mp_GPoint(2, 1));
                    oHatchGroup.Children.Add(mp_GPoint(2, 3));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_PERCENT30:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GPoint(0, 0));
                    oHatchGroup.Children.Add(mp_GPoint(1, 1));
                    oHatchGroup.Children.Add(mp_GPoint(2, 2));
                    oHatchGroup.Children.Add(mp_GPoint(3, 3));
                    oHatchGroup.Children.Add(mp_GPoint(2, 0));
                    oHatchGroup.Children.Add(mp_GPoint(0, 2));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_PERCENT40:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(0, 0));
                    oHatchGroup.Children.Add(mp_GPoint(2, 0));
                    oHatchGroup.Children.Add(mp_GPoint(4, 0));
                    oHatchGroup.Children.Add(mp_GPoint(6, 0));

                    oHatchGroup.Children.Add(mp_GPoint(3, 1));
                    oHatchGroup.Children.Add(mp_GPoint(5, 1));
                    oHatchGroup.Children.Add(mp_GPoint(7, 1));

                    oHatchGroup.Children.Add(mp_GPoint(0, 2));
                    oHatchGroup.Children.Add(mp_GPoint(2, 2));
                    oHatchGroup.Children.Add(mp_GPoint(4, 2));
                    oHatchGroup.Children.Add(mp_GPoint(6, 2));

                    oHatchGroup.Children.Add(mp_GPoint(1, 3));
                    oHatchGroup.Children.Add(mp_GPoint(3, 3));
                    oHatchGroup.Children.Add(mp_GPoint(5, 3));
                    oHatchGroup.Children.Add(mp_GPoint(7, 3));

                    oHatchGroup.Children.Add(mp_GPoint(0, 4));
                    oHatchGroup.Children.Add(mp_GPoint(2, 4));
                    oHatchGroup.Children.Add(mp_GPoint(4, 4));
                    oHatchGroup.Children.Add(mp_GPoint(6, 4));
                    oHatchGroup.Children.Add(mp_GPoint(1, 5));
                    oHatchGroup.Children.Add(mp_GPoint(3, 5));
                    oHatchGroup.Children.Add(mp_GPoint(7, 5));
                    oHatchGroup.Children.Add(mp_GPoint(0, 6));
                    oHatchGroup.Children.Add(mp_GPoint(2, 6));
                    oHatchGroup.Children.Add(mp_GPoint(4, 6));
                    oHatchGroup.Children.Add(mp_GPoint(6, 6));
                    oHatchGroup.Children.Add(mp_GPoint(1, 7));
                    oHatchGroup.Children.Add(mp_GPoint(3, 7));
                    oHatchGroup.Children.Add(mp_GPoint(5, 7));
                    oHatchGroup.Children.Add(mp_GPoint(7, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_PERCENT50:
                    lWidth = 2;
                    lHeight = 2;
                    oHatchGroup.Children.Add(mp_GPoint(0, 0));
                    oHatchGroup.Children.Add(mp_GPoint(1, 1));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_PERCENT60:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GPoint(0, 0));
                    oHatchGroup.Children.Add(mp_GPoint(2, 0));
                    oHatchGroup.Children.Add(mp_GPoint(3, 0));
                    oHatchGroup.Children.Add(mp_GPoint(1, 1));
                    oHatchGroup.Children.Add(mp_GPoint(3, 1));
                    oHatchGroup.Children.Add(mp_GPoint(0, 2));
                    oHatchGroup.Children.Add(mp_GPoint(1, 2));
                    oHatchGroup.Children.Add(mp_GPoint(2, 2));
                    oHatchGroup.Children.Add(mp_GPoint(1, 3));
                    oHatchGroup.Children.Add(mp_GPoint(3, 3));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_PERCENT70:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GPoint(1, 0));
                    oHatchGroup.Children.Add(mp_GPoint(2, 0));
                    oHatchGroup.Children.Add(mp_GPoint(3, 0));
                    oHatchGroup.Children.Add(mp_GPoint(0, 1));
                    oHatchGroup.Children.Add(mp_GPoint(1, 1));
                    oHatchGroup.Children.Add(mp_GPoint(3, 1));
                    oHatchGroup.Children.Add(mp_GPoint(1, 2));
                    oHatchGroup.Children.Add(mp_GPoint(2, 2));
                    oHatchGroup.Children.Add(mp_GPoint(3, 2));
                    oHatchGroup.Children.Add(mp_GPoint(0, 3));
                    oHatchGroup.Children.Add(mp_GPoint(1, 3));
                    oHatchGroup.Children.Add(mp_GPoint(3, 3));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_PERCENT75:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GPoint(2, 0));
                    oHatchGroup.Children.Add(mp_GPoint(0, 2));
                    mp_InvertColors(clrForeColor, clrBackColor);
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_PERCENT80:
                    lWidth = 8;
                    lHeight = 7;
                    oHatchGroup.Children.Add(mp_GPoint(3, 0));
                    oHatchGroup.Children.Add(mp_GPoint(3, 4));
                    oHatchGroup.Children.Add(mp_GPoint(7, 2));
                    oHatchGroup.Children.Add(mp_GPoint(7, 6));
                    mp_InvertColors(clrForeColor, clrBackColor);
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_PERCENT90:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(0, 5));
                    oHatchGroup.Children.Add(mp_GPoint(4, 1));
                    mp_InvertColors(clrForeColor, clrBackColor);
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_LIGHTDOWNWARDDIAGONAL:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GPoint(0, 0));
                    oHatchGroup.Children.Add(mp_GPoint(1, 1));
                    oHatchGroup.Children.Add(mp_GPoint(2, 2));
                    oHatchGroup.Children.Add(mp_GPoint(3, 3));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_LIGHTUPWARDDIAGONAL:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GPoint(0, 3));
                    oHatchGroup.Children.Add(mp_GPoint(1, 2));
                    oHatchGroup.Children.Add(mp_GPoint(2, 1));
                    oHatchGroup.Children.Add(mp_GPoint(3, 0));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_DARKDOWNWARDDIAGONAL:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GPoint(0, 3));
                    oHatchGroup.Children.Add(mp_GPoint(0, 0));
                    oHatchGroup.Children.Add(mp_GPoint(1, 1));
                    oHatchGroup.Children.Add(mp_GPoint(2, 2));
                    oHatchGroup.Children.Add(mp_GPoint(3, 3));
                    oHatchGroup.Children.Add(mp_GPoint(1, 0));
                    oHatchGroup.Children.Add(mp_GPoint(2, 1));
                    oHatchGroup.Children.Add(mp_GPoint(3, 2));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_DARKUPWARDDIAGONAL:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GPoint(0, 0));
                    oHatchGroup.Children.Add(mp_GPoint(0, 1));
                    oHatchGroup.Children.Add(mp_GPoint(1, 0));
                    oHatchGroup.Children.Add(mp_GPoint(1, 3));
                    oHatchGroup.Children.Add(mp_GPoint(2, 2));
                    oHatchGroup.Children.Add(mp_GPoint(3, 1));
                    oHatchGroup.Children.Add(mp_GPoint(2, 3));
                    oHatchGroup.Children.Add(mp_GPoint(3, 2));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_WIDEDOWNWARDDIAGONAL:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GLine(3, 0, 5, 0));
                    oHatchGroup.Children.Add(mp_GLine(4, 1, 6, 1));
                    oHatchGroup.Children.Add(mp_GLine(5, 2, 7, 2));
                    oHatchGroup.Children.Add(mp_GPoint(0, 3));
                    oHatchGroup.Children.Add(mp_GLine(6, 3, 7, 3));
                    oHatchGroup.Children.Add(mp_GLine(0, 4, 1, 4));
                    oHatchGroup.Children.Add(mp_GPoint(7, 4));
                    oHatchGroup.Children.Add(mp_GLine(0, 5, 2, 5));
                    oHatchGroup.Children.Add(mp_GLine(1, 6, 3, 6));
                    oHatchGroup.Children.Add(mp_GLine(2, 7, 4, 7));
                    oHatchCtrlGroup.Children.Add(mp_GPoint(7, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_WIDEUPWARDDIAGONAL:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GLine(4, 0, 6, 0));
                    oHatchGroup.Children.Add(mp_GLine(3, 1, 5, 1));
                    oHatchGroup.Children.Add(mp_GLine(2, 2, 4, 2));
                    oHatchGroup.Children.Add(mp_GLine(1, 3, 3, 3));
                    oHatchGroup.Children.Add(mp_GLine(0, 4, 2, 4));
                    oHatchGroup.Children.Add(mp_GLine(0, 5, 1, 5));
                    oHatchGroup.Children.Add(mp_GPoint(7, 5));
                    oHatchGroup.Children.Add(mp_GPoint(0, 6));
                    oHatchGroup.Children.Add(mp_GLine(6, 6, 7, 6));
                    oHatchGroup.Children.Add(mp_GLine(5, 7, 7, 7));
                    oHatchCtrlGroup.Children.Add(mp_GLine(0, 0, 7, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_LIGHTVERTICAL:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GLine(0, 0, 0, 3));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_LIGHTHORIZONTAL:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GLine(0, 0, 3, 0));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_NARROWVERTICAL:
                    lWidth = 2;
                    lHeight = 2;
                    oHatchGroup.Children.Add(mp_GLine(1, 0, 1, 1));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_NARROWHORIZONTAL:
                    lWidth = 2;
                    lHeight = 2;
                    oHatchGroup.Children.Add(mp_GLine(0, 1, 1, 1));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_DARKVERTICAL:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GLine(0, 0, 0, 3));
                    oHatchGroup.Children.Add(mp_GLine(1, 0, 1, 3));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_DARKHORIZONTAL:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GLine(0, 0, 3, 0));
                    oHatchGroup.Children.Add(mp_GLine(0, 1, 3, 1));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_DASHEDDOWNWARDDIAGONAL:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(0, 2));
                    oHatchGroup.Children.Add(mp_GPoint(1, 3));
                    oHatchGroup.Children.Add(mp_GPoint(2, 4));
                    oHatchGroup.Children.Add(mp_GPoint(3, 5));
                    oHatchGroup.Children.Add(mp_GPoint(4, 2));
                    oHatchGroup.Children.Add(mp_GPoint(5, 3));
                    oHatchGroup.Children.Add(mp_GPoint(6, 4));
                    oHatchGroup.Children.Add(mp_GPoint(7, 5));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_DASHEDUPWARDDIAGONAL:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(0, 7));
                    oHatchGroup.Children.Add(mp_GPoint(1, 6));
                    oHatchGroup.Children.Add(mp_GPoint(2, 5));
                    oHatchGroup.Children.Add(mp_GPoint(3, 4));
                    oHatchGroup.Children.Add(mp_GPoint(4, 7));
                    oHatchGroup.Children.Add(mp_GPoint(5, 6));
                    oHatchGroup.Children.Add(mp_GPoint(6, 5));
                    oHatchGroup.Children.Add(mp_GPoint(7, 4));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_DASHEDHORIZONTAL:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GLine(4, 0, 7, 0));
                    oHatchGroup.Children.Add(mp_GLine(0, 4, 3, 4));
                    oHatchCtrlGroup.Children.Add(mp_GPoint(7, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_DASHEDVERTICAL:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GLine(0, 0, 0, 1));
                    oHatchGroup.Children.Add(mp_GLine(0, 6, 0, 7));
                    oHatchGroup.Children.Add(mp_GLine(4, 2, 4, 5));
                    oHatchCtrlGroup.Children.Add(mp_GPoint(7, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_SMALLCONFETTI:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(0, 0));
                    oHatchGroup.Children.Add(mp_GPoint(4, 1));
                    oHatchGroup.Children.Add(mp_GPoint(1, 2));
                    oHatchGroup.Children.Add(mp_GPoint(6, 3));
                    oHatchGroup.Children.Add(mp_GPoint(3, 4));
                    oHatchGroup.Children.Add(mp_GPoint(7, 5));
                    oHatchGroup.Children.Add(mp_GPoint(2, 6));
                    oHatchGroup.Children.Add(mp_GPoint(5, 7));
                    oHatchCtrlGroup.Children.Add(mp_GPoint(7, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_LARGECONFETTI:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GLine(0, 1, 0, 2));
                    oHatchGroup.Children.Add(mp_GLine(0, 6, 0, 7));
                    oHatchGroup.Children.Add(mp_GLine(1, 6, 1, 7));
                    oHatchGroup.Children.Add(mp_GLine(2, 2, 2, 3));
                    oHatchGroup.Children.Add(mp_GLine(3, 2, 3, 3));
                    oHatchGroup.Children.Add(mp_GLine(3, 5, 3, 6));
                    oHatchGroup.Children.Add(mp_GLine(4, 0, 4, 1));
                    oHatchGroup.Children.Add(mp_GLine(4, 5, 4, 6));
                    oHatchGroup.Children.Add(mp_GLine(5, 0, 5, 1));
                    oHatchGroup.Children.Add(mp_GLine(6, 4, 6, 5));
                    oHatchGroup.Children.Add(mp_GLine(7, 1, 7, 2));
                    oHatchGroup.Children.Add(mp_GLine(7, 4, 7, 5));
                    oHatchCtrlGroup.Children.Add(mp_GPoint(7, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_ZIGZAG:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(0, 0));
                    oHatchGroup.Children.Add(mp_GPoint(1, 1));
                    oHatchGroup.Children.Add(mp_GPoint(2, 2));
                    oHatchGroup.Children.Add(mp_GLine(3, 3, 4, 3));
                    oHatchGroup.Children.Add(mp_GPoint(5, 2));
                    oHatchGroup.Children.Add(mp_GPoint(6, 1));
                    oHatchGroup.Children.Add(mp_GPoint(7, 0));

                    oHatchGroup.Children.Add(mp_GPoint(0, 4));
                    oHatchGroup.Children.Add(mp_GPoint(1, 5));
                    oHatchGroup.Children.Add(mp_GPoint(2, 6));
                    oHatchGroup.Children.Add(mp_GLine(3, 7, 4, 7));
                    oHatchGroup.Children.Add(mp_GPoint(5, 6));
                    oHatchGroup.Children.Add(mp_GPoint(6, 5));
                    oHatchGroup.Children.Add(mp_GPoint(7, 4));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_WAVE:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(2, 0));
                    oHatchGroup.Children.Add(mp_GPoint(5, 0));
                    oHatchGroup.Children.Add(mp_GPoint(7, 0));
                    oHatchGroup.Children.Add(mp_GLine(0, 2, 1, 2));

                    oHatchGroup.Children.Add(mp_GLine(3, 4, 4, 4));
                    oHatchGroup.Children.Add(mp_GPoint(2, 4));
                    oHatchGroup.Children.Add(mp_GPoint(5, 4));
                    oHatchGroup.Children.Add(mp_GPoint(7, 4));

                    oHatchGroup.Children.Add(mp_GLine(0, 6, 1, 6));
                    oHatchGroup.Children.Add(mp_GLine(3, 8, 4, 8));
                    oHatchCtrlGroup.Children.Add(mp_GPoint(0, 0));
                    oHatchCtrlGroup.Children.Add(mp_GPoint(7, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_DIAGONALBRICK:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(0, 7));
                    oHatchGroup.Children.Add(mp_GPoint(1, 6));
                    oHatchGroup.Children.Add(mp_GPoint(2, 5));
                    oHatchGroup.Children.Add(mp_GPoint(3, 4));
                    oHatchGroup.Children.Add(mp_GPoint(4, 3));
                    oHatchGroup.Children.Add(mp_GPoint(5, 2));
                    oHatchGroup.Children.Add(mp_GPoint(6, 1));
                    oHatchGroup.Children.Add(mp_GPoint(7, 0));
                    oHatchGroup.Children.Add(mp_GPoint(4, 4));
                    oHatchGroup.Children.Add(mp_GPoint(5, 5));
                    oHatchGroup.Children.Add(mp_GPoint(6, 6));
                    oHatchGroup.Children.Add(mp_GPoint(7, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_HORIZONTALBRICK:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(4, 0));
                    oHatchGroup.Children.Add(mp_GPoint(4, 1));
                    oHatchGroup.Children.Add(mp_GLine(0, 1, 0, 5));
                    oHatchGroup.Children.Add(mp_GPoint(4, 6));
                    oHatchGroup.Children.Add(mp_GPoint(4, 7));

                    oHatchGroup.Children.Add(mp_GLine(1, 2, 7, 2));
                    oHatchGroup.Children.Add(mp_GLine(1, 6, 7, 6));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_WEAVE:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(0, 0));
                    oHatchGroup.Children.Add(mp_GPoint(1, 1));
                    oHatchGroup.Children.Add(mp_GPoint(2, 2));
                    oHatchGroup.Children.Add(mp_GPoint(0, 4));
                    oHatchGroup.Children.Add(mp_GPoint(1, 3));
                    oHatchGroup.Children.Add(mp_GPoint(3, 1));
                    oHatchGroup.Children.Add(mp_GPoint(4, 0));
                    oHatchGroup.Children.Add(mp_GPoint(5, 1));
                    oHatchGroup.Children.Add(mp_GPoint(6, 2));
                    oHatchGroup.Children.Add(mp_GPoint(7, 3));
                    oHatchGroup.Children.Add(mp_GPoint(5, 3));
                    oHatchGroup.Children.Add(mp_GPoint(4, 4));
                    oHatchGroup.Children.Add(mp_GPoint(3, 5));
                    oHatchGroup.Children.Add(mp_GPoint(2, 6));
                    oHatchGroup.Children.Add(mp_GPoint(1, 7));
                    oHatchGroup.Children.Add(mp_GPoint(3, 7));
                    oHatchGroup.Children.Add(mp_GPoint(5, 5));
                    oHatchGroup.Children.Add(mp_GPoint(6, 6));
                    oHatchGroup.Children.Add(mp_GPoint(7, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_PLAID:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GLine(0, 0, 3, 0));
                    oHatchGroup.Children.Add(mp_GLine(0, 1, 3, 1));

                    oHatchGroup.Children.Add(mp_GPoint(0, 2));
                    oHatchGroup.Children.Add(mp_GPoint(2, 2));
                    oHatchGroup.Children.Add(mp_GPoint(4, 2));
                    oHatchGroup.Children.Add(mp_GPoint(6, 2));

                    oHatchGroup.Children.Add(mp_GPoint(1, 3));
                    oHatchGroup.Children.Add(mp_GPoint(3, 3));
                    oHatchGroup.Children.Add(mp_GPoint(5, 3));
                    oHatchGroup.Children.Add(mp_GPoint(7, 3));


                    oHatchGroup.Children.Add(mp_GPoint(0, 4));
                    oHatchGroup.Children.Add(mp_GPoint(2, 4));
                    oHatchGroup.Children.Add(mp_GPoint(4, 4));
                    oHatchGroup.Children.Add(mp_GPoint(6, 4));

                    oHatchGroup.Children.Add(mp_GPoint(1, 5));
                    oHatchGroup.Children.Add(mp_GPoint(3, 5));
                    oHatchGroup.Children.Add(mp_GPoint(5, 5));
                    oHatchGroup.Children.Add(mp_GPoint(7, 5));

                    oHatchGroup.Children.Add(mp_GLine(0, 6, 3, 6));
                    oHatchGroup.Children.Add(mp_GLine(0, 7, 3, 7));
                    oHatchCtrlGroup.Children.Add(mp_GPoint(7, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_DIVOT:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(0, 1));
                    oHatchGroup.Children.Add(mp_GPoint(0, 3));
                    oHatchGroup.Children.Add(mp_GPoint(3, 5));
                    oHatchGroup.Children.Add(mp_GPoint(3, 7));
                    oHatchGroup.Children.Add(mp_GPoint(4, 6));
                    oHatchGroup.Children.Add(mp_GPoint(7, 2));
                    oHatchCtrlGroup.Children.Add(mp_GPoint(7, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_DOTTEDGRID:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(1, 6));
                    oHatchGroup.Children.Add(mp_GPoint(3, 6));
                    oHatchGroup.Children.Add(mp_GPoint(5, 6));
                    oHatchGroup.Children.Add(mp_GPoint(7, 6));
                    oHatchGroup.Children.Add(mp_GPoint(7, 4));
                    oHatchGroup.Children.Add(mp_GPoint(7, 2));
                    oHatchGroup.Children.Add(mp_GPoint(7, 0));
                    oHatchCtrlGroup.Children.Add(mp_GPoint(7, 7));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_DOTTEDDIAMOND:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(0, 0));
                    oHatchGroup.Children.Add(mp_GPoint(2, 2));
                    oHatchGroup.Children.Add(mp_GPoint(4, 4));
                    oHatchGroup.Children.Add(mp_GPoint(6, 6));
                    oHatchGroup.Children.Add(mp_GPoint(2, 6));
                    oHatchGroup.Children.Add(mp_GPoint(6, 2));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_SHINGLE:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GPoint(0, 3));
                    oHatchGroup.Children.Add(mp_GPoint(1, 4));
                    oHatchGroup.Children.Add(mp_GPoint(2, 5));
                    oHatchGroup.Children.Add(mp_GPoint(3, 5));
                    oHatchGroup.Children.Add(mp_GPoint(4, 6));
                    oHatchGroup.Children.Add(mp_GPoint(5, 6));
                    oHatchGroup.Children.Add(mp_GPoint(6, 7));
                    oHatchGroup.Children.Add(mp_GPoint(4, 4));
                    oHatchGroup.Children.Add(mp_GPoint(5, 3));
                    oHatchGroup.Children.Add(mp_GPoint(6, 2));
                    oHatchGroup.Children.Add(mp_GPoint(7, 2));
                    oHatchGroup.Children.Add(mp_GPoint(7, 0));
                    oHatchGroup.Children.Add(mp_GPoint(7, 1));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_TRELLIS:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GLine(0, 0, 3, 0));
                    oHatchGroup.Children.Add(mp_GLine(1, 1, 2, 1));
                    oHatchGroup.Children.Add(mp_GLine(0, 2, 3, 2));
                    oHatchGroup.Children.Add(mp_GPoint(0, 3));
                    oHatchGroup.Children.Add(mp_GPoint(3, 3));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_SPHERE:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GLine(1, 0, 3, 0));
                    oHatchGroup.Children.Add(mp_GLine(1, 1, 3, 1));
                    oHatchGroup.Children.Add(mp_GPoint(0, 2));
                    oHatchGroup.Children.Add(mp_GPoint(4, 2));
                    oHatchGroup.Children.Add(mp_GLine(1, 3, 2, 3));
                    oHatchGroup.Children.Add(mp_GPoint(0, 6));
                    oHatchGroup.Children.Add(mp_GPoint(4, 6));
                    oHatchGroup.Children.Add(mp_GLine(1, 7, 3, 7));
                    oHatchGroup.Children.Add(mp_GLine(5, 7, 6, 7));
                    oHatchGroup.Children.Add(mp_GLine(5, 3, 7, 3));
                    oHatchGroup.Children.Add(mp_GLine(5, 4, 7, 4));
                    oHatchGroup.Children.Add(mp_GLine(5, 5, 7, 5));
                    oHatchCtrlGroup.Children.Add(mp_GPoint(7, 7));
                    mp_InvertColors(clrForeColor, clrBackColor);
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_SMALLGRID:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GLine(0, 0, 3, 0));
                    oHatchGroup.Children.Add(mp_GLine(0, 0, 0, 3));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_SMALLCHECKERBOARD:
                    lWidth = 4;
                    lHeight = 4;
                    oHatchGroup.Children.Add(mp_GRect(0, 0, 2, 2));
                    oHatchGroup.Children.Add(mp_GRect(2, 2, 2, 2));
                    yType = T_HATCHTYPE.HT_RECTANGLE;
                    break;
                case GRE_HATCHSTYLE.HS_LARGECHECKERBOARD:
                    lWidth = 8;
                    lHeight = 8;
                    oHatchGroup.Children.Add(mp_GRect(0, 0, 4, 4));
                    oHatchGroup.Children.Add(mp_GRect(4, 4, 4, 4));
                    yType = T_HATCHTYPE.HT_RECTANGLE;
                    break;
                case GRE_HATCHSTYLE.HS_OUTLINEDDIAMOND:
                    lWidth = 8;
                    lHeight = 8;

                    oHatchGroup.Children.Add(mp_GPoint(0, 4));
                    oHatchGroup.Children.Add(mp_GPoint(1, 3));
                    oHatchGroup.Children.Add(mp_GPoint(2, 2));
                    oHatchGroup.Children.Add(mp_GPoint(3, 1));
                    oHatchGroup.Children.Add(mp_GPoint(4, 0));

                    oHatchGroup.Children.Add(mp_GPoint(5, 1));
                    oHatchGroup.Children.Add(mp_GPoint(6, 2));
                    oHatchGroup.Children.Add(mp_GPoint(7, 3));

                    oHatchGroup.Children.Add(mp_GPoint(7, 5));
                    oHatchGroup.Children.Add(mp_GPoint(6, 6));
                    oHatchGroup.Children.Add(mp_GPoint(5, 7));

                    oHatchGroup.Children.Add(mp_GPoint(3, 7));
                    oHatchGroup.Children.Add(mp_GPoint(2, 6));
                    oHatchGroup.Children.Add(mp_GPoint(1, 5));
                    yType = T_HATCHTYPE.HT_LINE;
                    break;
                case GRE_HATCHSTYLE.HS_SOLIDDIAMOND:
                    lWidth = 7;
                    lHeight = 7;
                    oHatchGroup.Children.Add(mp_GRect(1, 1, 5, 5));
                    oHatchGroup.Transform = new RotateTransform(45, 3, 3);
                    yType = T_HATCHTYPE.HT_RECTANGLE;
                    break;
            }
            GeometryDrawing oBackgroundSquare = new GeometryDrawing(new SolidColorBrush(clrBackColor), null, new RectangleGeometry(new Rect(0, 0, lWidth, lHeight)));
            SolidColorBrush oHatchBrush = new SolidColorBrush(clrForeColor);
            Pen oHatchPen = new Pen(oHatchBrush, 1);
            oHatchBrush.Freeze();
            oHatchPen.Freeze();
            SolidColorBrush oHatchCtrlBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            Pen oHatchCtrlPen = new Pen(oHatchCtrlBrush, 1);
            oHatchCtrlBrush.Freeze();
            oHatchCtrlPen.Freeze();
            GeometryDrawing oHatch = null;
            GeometryDrawing oHatchCtrl = null;
            switch (yType)
            {
                case T_HATCHTYPE.HT_RECTANGLE:
                    oHatch = new GeometryDrawing(oHatchBrush, null, oHatchGroup);
                    if (oHatchCtrlGroup.Children.Count > 0)
                    {
                        oHatchCtrl = new GeometryDrawing(oHatchCtrlBrush, null, oHatchCtrlGroup);
                    }

                    break;
                case T_HATCHTYPE.HT_LINE:
                    oHatch = new GeometryDrawing(null, oHatchPen, oHatchGroup);
                    if (oHatchCtrlGroup.Children.Count > 0)
                    {
                        oHatchCtrl = new GeometryDrawing(null, oHatchCtrlPen, oHatchCtrlGroup);
                    }

                    break;
            }
            DrawingGroup oDrawingGroup = new DrawingGroup();
            if (bAliased == true)
            {
                oDrawingGroup.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            }
            if ((oHatchCtrl != null))
            {
                oDrawingGroup.Children.Add(oHatchCtrl);
            }
            oDrawingGroup.Children.Add(oBackgroundSquare);
            oDrawingGroup.Children.Add(oHatch);
            oBrush.Drawing = oDrawingGroup;
            oBrush.Stretch = Stretch.None;
            oBrush.ViewportUnits = BrushMappingMode.Absolute;
            oBrush.Viewport = new Rect(0, 0, lWidth, lHeight);
            oBrush.TileMode = TileMode.Tile;
            oBrush.Freeze();
            oGraphics.DrawRectangle(oBrush, null, new Rect(X1, Y1, X2 - X1 + 1, Y2 - Y1 + 1));
        }

        private void mp_InvertColors(Color clrForeColor, Color clrBackColor)
        {
            Color clrBuff;
            clrBuff = clrBackColor;
            clrBackColor = clrForeColor;
            clrForeColor = clrBuff;
        }

        private RectangleGeometry mp_GRect(int X, int Y, int Width, int Height)
        {
            RectangleGeometry oReturn = new RectangleGeometry(new Rect(X, Y, Width, Height));
            return oReturn;
        }

        private LineGeometry mp_GLine(int X1, int Y1, int X2, int Y2)
        {
            if (X1 != X2)
            {
                X2 = X2 + 1;
            }
            if (Y1 != Y2)
            {
                Y2 = Y2 + 1;
            }
            LineGeometry oReturn = new LineGeometry(new Point(X1, Y1), new Point(X2, Y2));
            return oReturn;
        }

        private LineGeometry mp_GPoint(int X1, int Y1)
        {
            LineGeometry oReturn = new LineGeometry(new Point(X1, Y1), new Point(X1 + 1, Y1 + 1));
            return oReturn;
        }

        internal void mp_ResetFocusRectangle()
        {
            mp_lSelectionRectangleIndex = -1;
            mp_lSelectionLineIndex = -1;
            mp_lFocusLeft = 0;
            mp_lFocusTop = 0;
            mp_lFocusRight = 0;
            mp_lFocusBottom = 0;
        }

        internal void mp_DrawReversibleFrameEx()
        {
            mp_DrawReversibleFrame(mp_lFocusLeft, mp_lFocusTop, mp_lFocusRight, mp_lFocusBottom);
        }

        internal void mp_DrawReversibleLine(int X1, int Y1, int X2, int Y2)
        {
            if (mp_lSelectionLineIndex == -1)
            {
                mp_oSelectionLine.X1 = X1;
                mp_oSelectionLine.X2 = X2;
                mp_oSelectionLine.Y1 = Y1;
                mp_oSelectionLine.Y2 = Y2;
                mp_oSelectionLine.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                mp_oSelectionLine.StrokeThickness = 1;
                mp_oSelectionLine.SnapsToDevicePixels = true;
                mp_oSelectionLine.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                mp_oSelectionLine.IsHitTestVisible = false;
                mp_oControl.f_Canvas().Children.Add(mp_oSelectionLine);
                mp_lSelectionLineIndex = mp_oControl.f_Canvas().Children.Count - 1;
            }
            else
            {
                mp_oSelectionLine.X1 = X1;
                mp_oSelectionLine.X2 = X2;
                mp_oSelectionLine.Y1 = Y1;
                mp_oSelectionLine.Y2 = Y2;
            }
        }

        internal void mp_EraseReversibleLines()
        {
            if (mp_lSelectionLineIndex > -1)
            {
                mp_oControl.f_Canvas().Children.Remove(mp_oSelectionLine);
                mp_lSelectionLineIndex = -1;
            }
        }

        internal void mp_DrawReversibleFrame(int X1, int Y1, int X2, int Y2)
        {
            if ((X2 - X1 + 1) < 1)
                return;
            if ((Y2 - Y1 + 1) < 1)
                return;
            if (mp_lSelectionRectangleIndex == -1)
            {
                mp_oSelectionRectangle.Width = X2 - X1 + 1;
                mp_oSelectionRectangle.Height = Y2 - Y1 + 1;
                mp_oSelectionRectangle.SetValue(Canvas.LeftProperty, (double)X1);
                mp_oSelectionRectangle.SetValue(Canvas.TopProperty, (double)Y1);
                mp_oSelectionRectangle.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                mp_oSelectionRectangle.StrokeThickness = 1;
                mp_oSelectionRectangle.SnapsToDevicePixels = true;
                mp_oSelectionRectangle.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                mp_oSelectionRectangle.IsHitTestVisible = false;
                mp_oControl.f_Canvas().Children.Add(mp_oSelectionRectangle);
                mp_lSelectionRectangleIndex = mp_oControl.f_Canvas().Children.Count - 1;
            }
            else
            {
                mp_oSelectionRectangle.Width = X2 - X1 + 1;
                mp_oSelectionRectangle.Height = Y2 - Y1 + 1;
                mp_oSelectionRectangle.SetValue(Canvas.LeftProperty, (double)X1);
                mp_oSelectionRectangle.SetValue(Canvas.TopProperty, (double)Y1);
            }
        }

        internal void mp_EraseReversibleFrames()
        {
            if (mp_lSelectionRectangleIndex > -1)
            {
                mp_oControl.f_Canvas().Children.Remove(mp_oSelectionRectangle);
                mp_lSelectionRectangleIndex = -1;
            }          
        }

        internal void StartPrintControl(int DestHdc, int XOrigin, int YOrigin, int XOriginExtents, int YOriginExtents, int MarginX, int MarginY, int DestScale, float FontRatio)
        {
        }

        internal void EndPrintControl()
        {
        }

        internal void mp_DrawItemI(int X1, int Y1, int X2, int Y2, string sStyleIndex, string sText, bool bSelected, Image Image, int lLeftTrim, int lRightTrim, clsStyle v_oStyle)
        {
            clsStyle oStyle;
            clsMilestoneStyle oMilestoneStyle;
            if ((v_oStyle == null))
            {
                if (Globals.g_IsNumeric(sStyleIndex))
                {
                    if (System.Convert.ToInt32(sStyleIndex) < 0 | System.Convert.ToInt32(sStyleIndex) > mp_oControl.Styles.Count)
                    {
                        mp_oControl.mp_ErrorReport(SYS_ERRORS.STYLE_INVALID_INDEX, "Style object element not found when preparing to draw, invalid index", "mp_DrawItemI");
                        return;
                    }
                }
                else
                {
                    if (mp_oControl.Styles.oCollection.m_bDoesKeyExist(sStyleIndex) == false)
                    {
                        mp_oControl.mp_ErrorReport(SYS_ERRORS.STYLE_INVALID_KEY, "Style object element not found when preparing to draw, invalid key (\"" + sStyleIndex + "\")", "mp_DrawItemI");
                        return;
                    }
                }
                oStyle = mp_oControl.Styles.FItem(sStyleIndex);
            }
            else
            {
                oStyle = v_oStyle;
            }
            switch (oStyle.Appearance)
            {
                case E_STYLEAPPEARANCE.SA_FLAT:
                    oMilestoneStyle = oStyle.MilestoneStyle;
                    mp_DrawFigure(X1 + ((X2 - X1) / 2), Y1, Y2 - Y1, Y2 - Y1, oMilestoneStyle.ShapeIndex, oMilestoneStyle.BorderColor, oMilestoneStyle.FillColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    break;
                case E_STYLEAPPEARANCE.SA_GRAPHICAL:
                    if ((oStyle.MilestoneStyle.Image != null))
                    {
                        mp_DrawImage(oStyle.MilestoneStyle.Image, oStyle.ImageAlignmentHorizontal, oStyle.ImageAlignmentVertical, oStyle.ImageXMargin, oStyle.ImageYMargin, X1, X2, Y1, Y2, oStyle.UseMask);
                    }
                    else if ((Image != null))
                    {
                        mp_DrawImage(Image, oStyle.ImageAlignmentHorizontal, oStyle.ImageAlignmentVertical, oStyle.ImageXMargin, oStyle.ImageYMargin, X1, X2, Y1, Y2, oStyle.UseMask);
                    }
                    break;
                default:
                    oMilestoneStyle = oStyle.MilestoneStyle;
                    mp_DrawFigure(X1 + ((X2 - X1) / 2), Y1, Y2 - Y1, Y2 - Y1, oMilestoneStyle.ShapeIndex, oMilestoneStyle.BorderColor, oMilestoneStyle.FillColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    break;
            }
            mp_DrawItemText(X1, Y1, X2, Y2, lLeftTrim, lRightTrim, oStyle, sText);
            if (oStyle.SelectionRectangleStyle.Visible == true & bSelected)
            {
                if (oStyle.SelectionRectangleStyle.Mode == E_SELECTIONRECTANGLEMODE.SRM_DOTTED)
                {
                    mp_DrawFocusRectangle(X1, Y1, X2, Y2);
                }
                else if (oStyle.SelectionRectangleStyle.Mode == E_SELECTIONRECTANGLEMODE.SRM_COLOR)
                {
                    mp_DrawLine(X1, Y1, X2, Y2, GRE_LINETYPE.LT_BORDER, oStyle.SelectionRectangleStyle.Color, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.SelectionRectangleStyle.BorderWidth);
                }
            }
        }

        internal void mp_DrawItemM(clsTask oTask, string sStyleIndex, bool Selected, clsStyle v_oStyle)
        {
            mp_DrawItemI(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom, oTask.StyleIndex, oTask.Text, Selected, oTask.Style.MilestoneStyle.Image, oTask.LeftTrim, oTask.RightTrim, v_oStyle);
        }

        internal void mp_DrawItemEx(int X1, int Y1, int X2, int Y2, string sText, bool bIsSelected, Image oImage, int lLeftTrim, int lRightTrim, clsStyle v_oStyle, Color clrBackColor, Color clrForeColor, Color clrStartGradientColor, Color clrEndGradientColor, Color clrHatchBackColor, Color clrHatchForeColor)
        {
            clsStyle oStyle;
            clsTaskStyle oTaskStyle;
            if ((v_oStyle == null))
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.STYLE_NULL, "Style object is null when preparing to draw.", "mp_DrawItemEx");
                return;
            }
            else
            {
                oStyle = v_oStyle;
            }
            oTaskStyle = oStyle.TaskStyle;
            switch (oStyle.Appearance)
            {
                case E_STYLEAPPEARANCE.SA_RAISED:
                    mp_DrawEdge(X1, Y1, X2, Y2, clrBackColor, oStyle.ButtonStyle, GRE_EDGETYPE.ET_RAISED, true, v_oStyle);
                    break;
                case E_STYLEAPPEARANCE.SA_SUNKEN:
                    mp_DrawEdge(X1, Y1, X2, Y2, clrBackColor, oStyle.ButtonStyle, GRE_EDGETYPE.ET_SUNKEN, true, v_oStyle);
                    break;
                case E_STYLEAPPEARANCE.SA_FLAT:
                    int lTop = 0;
                    int lBottom = 0;
                    lTop = Y1;
                    lBottom = Y2;
                    switch (oStyle.FillMode)
                    {
                        case GRE_FILLMODE.FM_COMPLETELYFILLED:
                            break;
                        case GRE_FILLMODE.FM_UPPERHALFFILLED:
                            lBottom = Y1 + ((Y2 - Y1) / 2);
                            break;
                        case GRE_FILLMODE.FM_LOWERHALFFILLED:
                            lTop = Y2 - ((Y2 - Y1) / 2);
                            break;
                    }
                    if ((oStyle.BackgroundMode == GRE_BACKGROUNDMODE.FP_SOLID))
                    {
                        mp_DrawLine(X1, lTop, X2, lBottom, GRE_LINETYPE.LT_FILLED, clrBackColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    }
                    else if ((oStyle.BackgroundMode == GRE_BACKGROUNDMODE.FP_GRADIENT))
                    {
                        mp_GradientFill(X1, lTop, X2, lBottom, clrStartGradientColor, clrEndGradientColor, oStyle.GradientFillMode);
                    }
                    else if ((oStyle.BackgroundMode == GRE_BACKGROUNDMODE.FP_PATTERN))
                    {
                        mp_DrawPattern(X1, lTop, X2, lBottom, clrBackColor, oStyle.Pattern, oStyle.PatternFactor);
                    }
                    else if ((oStyle.BackgroundMode == GRE_BACKGROUNDMODE.FP_HATCH))
                    {
                        mp_HatchFill(X1, lTop, X2, lBottom, clrHatchForeColor, clrHatchBackColor, oStyle.HatchStyle);
                    }
                    if (oStyle.BorderStyle == GRE_BORDERSTYLE.SBR_SINGLE)
                    {
                        mp_DrawLine(X1, lTop, X2, lBottom, GRE_LINETYPE.LT_BORDER, oStyle.BorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.BorderWidth);
                    }
                    else if (oStyle.BorderStyle == GRE_BORDERSTYLE.SBR_CUSTOM)
                    {
                        if (oStyle.CustomBorderStyle.Left == true)
                        {
                            mp_DrawLine(X1, lTop, X1, lBottom, GRE_LINETYPE.LT_NORMAL, oStyle.BorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.BorderWidth);
                        }
                        if (oStyle.CustomBorderStyle.Top == true)
                        {
                            mp_DrawLine(X1, lTop, X2, lTop, GRE_LINETYPE.LT_NORMAL, oStyle.BorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.BorderWidth);
                        }
                        if (oStyle.CustomBorderStyle.Right == true)
                        {
                            mp_DrawLine(X2, lTop, X2, lBottom, GRE_LINETYPE.LT_NORMAL, oStyle.BorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.BorderWidth);
                        }
                        if (oStyle.CustomBorderStyle.Bottom == true)
                        {
                            mp_DrawLine(X1, lBottom, X2, lBottom, GRE_LINETYPE.LT_NORMAL, oStyle.BorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.BorderWidth);
                        }
                    }
                    mp_DrawFigure(X2, Y1, Y2 - Y1, Y2 - Y1, oTaskStyle.EndShapeIndex, oTaskStyle.EndBorderColor, oTaskStyle.EndFillColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    mp_DrawFigure(X1, Y1, Y2 - Y1, Y2 - Y1, oTaskStyle.StartShapeIndex, oTaskStyle.StartBorderColor, oTaskStyle.StartFillColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    break;
                case E_STYLEAPPEARANCE.SA_GRAPHICAL:

                    if (oTaskStyle.MiddleImage == null | oTaskStyle.StartImage == null | oTaskStyle.EndImage == null)
                    {
                    }
                    else
                    {
                        int lImageHeight = 0;
                        int lImageWidth = 0;
                        lImageHeight = (int)oTaskStyle.MiddleImage.Height;
                        lImageWidth = (int)oTaskStyle.MiddleImage.Width;
                        mp_TileImageHorizontal(oTaskStyle.MiddleImage, X1, Y1, X2, Y2, oStyle.UseMask);
                        //// Exit if the start and end sections don't fit
                        if ((X2 - X1) > (lImageWidth * 2))
                        {
                            //// Left Section
                            mp_PaintImage(oTaskStyle.StartImage, X1, Y1, X1 + lImageWidth, Y1 + lImageHeight, 0, 0, oStyle.UseMask);
                            //// Right Section
                            mp_PaintImage(oTaskStyle.EndImage, X2 - lImageWidth, Y1, X2, Y1 + lImageHeight, 0, 0, oStyle.UseMask);
                        }
                    }
                    break;
            }
            if ((oImage != null))
            {
                mp_DrawImage(oImage, oStyle.ImageAlignmentHorizontal, oStyle.ImageAlignmentVertical, oStyle.ImageXMargin, oStyle.ImageYMargin, X1, X2, Y1, Y2, oStyle.UseMask);
            }
            mp_DrawItemText(X1, Y1, X2, Y2, lLeftTrim, lRightTrim, oStyle, sText);
            if (oStyle.SelectionRectangleStyle.Visible == true & bIsSelected)
            {
                mp_DrawSelectionRectangle(X1, Y1, X2, Y2, oStyle);
            }
        }

        internal void mp_DrawSelectionRectangle(int X1, int Y1, int X2, int Y2, clsStyle oStyle)
        {
            if (oStyle.SelectionRectangleStyle.Mode == E_SELECTIONRECTANGLEMODE.SRM_DOTTED)
            {
                mp_DrawFocusRectangle(X1 + oStyle.SelectionRectangleStyle.OffsetLeft, Y1 + oStyle.SelectionRectangleStyle.OffsetTop, X2 - oStyle.SelectionRectangleStyle.OffsetRight, Y2 - oStyle.SelectionRectangleStyle.OffsetBottom);
            }
            else if (oStyle.SelectionRectangleStyle.Mode == E_SELECTIONRECTANGLEMODE.SRM_COLOR)
            {
                mp_DrawLine(X1 + oStyle.SelectionRectangleStyle.OffsetLeft, Y1 + oStyle.SelectionRectangleStyle.OffsetTop, X2 - oStyle.SelectionRectangleStyle.OffsetRight, Y2 - oStyle.SelectionRectangleStyle.OffsetBottom, GRE_LINETYPE.LT_BORDER, oStyle.SelectionRectangleStyle.Color, GRE_LINEDRAWSTYLE.LDS_SOLID, oStyle.SelectionRectangleStyle.BorderWidth);
            }
        }

        internal void mp_DrawItemRow(int X1, int Y1, int X2, int Y2, string sText, bool bIsSelected, Image oImage, int lLeftTrim, int lRightTrim, clsStyle v_oStyle, clsRow oRow)
        {
            GRE_BACKGROUNDMODE yBackgroundMode;
            if (oRow.Highlighted == true)
            {
                mp_DrawLine(X1, Y1, X2, Y2, GRE_LINETYPE.LT_FILLED, mp_oControl.Configuration.RowHighlightedBackColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                yBackgroundMode = v_oStyle.BackgroundMode;
                if (v_oStyle.BackgroundMode != GRE_BACKGROUNDMODE.FP_TRANSPARENT)
                {
                    v_oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_TRANSPARENT;
                }
                mp_DrawItem(X1, Y1, X2, Y2, "", sText, bIsSelected, oImage, lLeftTrim, lRightTrim, v_oStyle);
                v_oStyle.BackgroundMode = yBackgroundMode;
            }
            else
            {
                if (mp_oControl.Configuration.AlternatingRowStyles == true)
                {
                    yBackgroundMode = v_oStyle.BackgroundMode;
                    if (v_oStyle.BackgroundMode != GRE_BACKGROUNDMODE.FP_TRANSPARENT)
                    {
                        v_oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_TRANSPARENT;
                    }
                    if (oRow.Index % 2 == 1)
                    {
                        ////Odd
                        mp_DrawLine(X1, Y1, X2, Y2, GRE_LINETYPE.LT_FILLED, mp_oControl.Configuration.RowOddBackColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        mp_DrawItem(X1, Y1, X2, Y2, "", sText, bIsSelected, oImage, lLeftTrim, lRightTrim,
                        v_oStyle);
                    }
                    else
                    {
                        ////Even
                        mp_DrawLine(X1, Y1, X2, Y2, GRE_LINETYPE.LT_FILLED, mp_oControl.Configuration.RowEvenBackColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        mp_DrawItem(X1, Y1, X2, Y2, "", sText, bIsSelected, oImage, lLeftTrim, lRightTrim,
                        v_oStyle);
                    }
                    v_oStyle.BackgroundMode = yBackgroundMode;
                }
                else
                {
                    mp_DrawItem(X1, Y1, X2, Y2, "", sText, bIsSelected, oImage, lLeftTrim, lRightTrim,
                    v_oStyle);
                }
            }
        }

        internal void mp_DrawItem(int X1, int Y1, int X2, int Y2, string sStyleIndex, string sText, bool bIsSelected, Image oImage, int lLeftTrim, int lRightTrim, clsStyle v_oStyle)
        {
            clsStyle oStyle;
            if ((v_oStyle == null))
            {
                if (Globals.g_IsNumeric(sStyleIndex))
                {
                    if (System.Convert.ToInt32(sStyleIndex) < 0 | System.Convert.ToInt32(sStyleIndex) > mp_oControl.Styles.Count)
                    {
                        mp_oControl.mp_ErrorReport(SYS_ERRORS.STYLE_INVALID_INDEX, "Style object element not found when preparing to draw, invalid index", "mp_DrawItem");
                        return;
                    }
                }
                else
                {
                    if (mp_oControl.Styles.oCollection.m_bDoesKeyExist(sStyleIndex) == false)
                    {
                        mp_oControl.mp_ErrorReport(SYS_ERRORS.STYLE_INVALID_KEY, "Style object element not found when preparing to draw, invalid key (\"" + sStyleIndex + "\")", "mp_DrawItem");
                        return;
                    }
                }
                oStyle = mp_oControl.Styles.FItem(sStyleIndex);
            }
            else
            {
                oStyle = v_oStyle;
            }
            mp_DrawItemEx(X1, Y1, X2, Y2, sText, bIsSelected, oImage, lLeftTrim, lRightTrim, oStyle, oStyle.BackColor, oStyle.ForeColor, oStyle.StartGradientColor, oStyle.EndGradientColor, oStyle.HatchBackColor, oStyle.HatchForeColor);
        }

        private void mp_DrawItemText(int X1, int Y1, int X2, int Y2, int lLeftTrim, int lRightTrim, clsStyle oStyle, string sText)
        {
            int lTextLeft = 0;
            int lTextRight = 0;
            int lTextTop = 0;
            int lTextBottom = 0;
            if (oStyle.TextVisible == false)
            {
                return;
            }
            if (string.IsNullOrEmpty(sText))
            {
                return;
            }
            switch (oStyle.TextPlacement)
            {
                case E_TEXTPLACEMENT.SCP_OBJECTEXTENTSPLACEMENT:
                    if ((oStyle.DrawTextInVisibleArea == false))
                    {
                        lTextLeft = X1;
                        lTextRight = X2;
                    }
                    else
                    {
                        lTextLeft = lLeftTrim;
                        lTextRight = lRightTrim;
                    }

                    lTextTop = Y1;
                    lTextBottom = Y2;
                    if (oStyle.TextAlignmentHorizontal == GRE_HORIZONTALALIGNMENT.HAL_LEFT)
                    {
                        lTextLeft = X1 + oStyle.TextXMargin;
                    }

                    if (oStyle.TextAlignmentHorizontal == GRE_HORIZONTALALIGNMENT.HAL_RIGHT)
                    {
                        lTextRight = X2 - oStyle.TextXMargin;
                    }

                    if (oStyle.TextAlignmentVertical == GRE_VERTICALALIGNMENT.VAL_TOP)
                    {
                        lTextTop = Y1 + oStyle.TextYMargin;
                    }

                    if (oStyle.TextAlignmentVertical == GRE_VERTICALALIGNMENT.VAL_BOTTOM)
                    {
                        lTextBottom = Y2 - oStyle.TextYMargin;
                    }

                    mp_DrawAlignedText(lTextLeft, lTextTop, lTextRight, lTextBottom, sText, oStyle.TextAlignmentHorizontal, oStyle.TextAlignmentVertical, oStyle.ForeColor, oStyle.Font, oStyle.ClipText
                    );
                    break;
                case E_TEXTPLACEMENT.SCP_OFFSETPLACEMENT:
                    mp_DrawTextEx(X1 + oStyle.TextFlags.OffsetLeft, Y1 + oStyle.TextFlags.OffsetTop, X2 - oStyle.TextFlags.OffsetRight, Y2 - oStyle.TextFlags.OffsetBottom, sText, oStyle.TextFlags, oStyle.ForeColor, oStyle.Font, oStyle.ClipText);
                    break;
                case E_TEXTPLACEMENT.SCP_EXTERIORPLACEMENT:
                    if (oStyle.TextAlignmentHorizontal == GRE_HORIZONTALALIGNMENT.HAL_LEFT)
                    {
                        lTextLeft = X1 - mp_lStrWidth(sText, oStyle.Font) - oStyle.TextXMargin;
                        lTextRight = X1 - oStyle.TextXMargin + 1;
                    }

                    if (oStyle.TextAlignmentHorizontal == GRE_HORIZONTALALIGNMENT.HAL_RIGHT)
                    {
                        lTextLeft = X2 + oStyle.TextXMargin;
                        lTextRight = X2 + mp_lStrWidth(sText, oStyle.Font) + oStyle.TextXMargin + 1;
                    }

                    if (oStyle.TextAlignmentHorizontal == GRE_HORIZONTALALIGNMENT.HAL_CENTER)
                    {
                        lTextLeft = X1;
                        lTextRight = X2 + 1;
                    }

                    if (oStyle.TextAlignmentVertical == GRE_VERTICALALIGNMENT.VAL_TOP)
                    {
                        lTextTop = Y1 - mp_lStrHeight(sText, oStyle.Font) - oStyle.TextYMargin;
                        lTextBottom = Y1 - oStyle.TextYMargin + 1;
                    }

                    if (oStyle.TextAlignmentVertical == GRE_VERTICALALIGNMENT.VAL_BOTTOM)
                    {
                        lTextTop = Y2 + oStyle.TextYMargin;
                        lTextBottom = Y2 + mp_lStrHeight(sText, oStyle.Font) + oStyle.TextYMargin + 1;
                    }

                    if (oStyle.TextAlignmentVertical == GRE_VERTICALALIGNMENT.VAL_CENTER)
                    {
                        lTextTop = Y1;
                        lTextBottom = Y2 + 1;
                    }
                    mp_DrawAlignedText(lTextLeft, lTextTop, lTextRight, lTextBottom, sText, GRE_HORIZONTALALIGNMENT.HAL_LEFT, GRE_VERTICALALIGNMENT.VAL_TOP, oStyle.ForeColor, oStyle.Font, oStyle.ClipText);
                    break;
            }

        }

        private void mp_DrawPoint(int X, int Y, Color clrColor)
        {
            oGraphics.DrawLine(GetPen(clrColor), new Point(X, Y), new Point(X + 1, Y + 1));
        }

        internal void mp_DrawArrow(int X, int Y, GRE_ARROWDIRECTION yArrowDirection, int lArrowSize, Color clrColor)
        {
            int i = 0;
            switch (yArrowDirection)
            {
                case GRE_ARROWDIRECTION.AWD_LEFT:
                    mp_DrawPoint(X, Y, clrColor);
                    for (i = 1; i <= lArrowSize; i++)
                    {
                        X = X + 1;
                        mp_DrawLine(X, Y - i, X, Y + i, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    }

                    break;
                case GRE_ARROWDIRECTION.AWD_RIGHT:
                    mp_DrawPoint(X, Y, clrColor);
                    for (i = 1; i <= lArrowSize; i++)
                    {
                        X = X - 1;
                        mp_DrawLine(X, Y - i, X, Y + i, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    }

                    break;
                case GRE_ARROWDIRECTION.AWD_UP:
                    mp_DrawPoint(X, Y, clrColor);
                    for (i = 1; i <= lArrowSize; i++)
                    {
                        Y = Y + 1;
                        mp_DrawLine(X - i, Y, X + i, Y, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    }

                    break;
                case GRE_ARROWDIRECTION.AWD_DOWN:
                    mp_DrawPoint(X, Y, clrColor);
                    for (i = 1; i <= lArrowSize; i++)
                    {
                        Y = Y - 1;
                        mp_DrawLine(X - i, Y, X + i, Y, GRE_LINETYPE.LT_NORMAL, clrColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                    }

                    break;
            }
        }

        internal void mp_DrawExpandIcon(int X, int Y, Color oColor, Color oDropShadowColor, Color oBackgroundColor)
        {
            oGraphics.DrawLine(new Pen(new SolidColorBrush(oColor), 1), new Point(X + 1, Y), new Point(X + 1, Y + 9));
            oGraphics.DrawLine(new Pen(new SolidColorBrush(oColor), 1), new Point(X + 1, Y + 1), new Point(X + 5, Y + 5));
            oGraphics.DrawLine(new Pen(new SolidColorBrush(oColor), 1), new Point(X + 1, Y + 8), new Point(X + 5, Y + 4));
            oGraphics.DrawLine(new Pen(new SolidColorBrush(oDropShadowColor), 1), new Point(X + 1, Y), new Point(X + 6, Y + 5));
            oGraphics.DrawLine(new Pen(new SolidColorBrush(oDropShadowColor), 1), new Point(X + 1, Y + 9), new Point(X + 6, Y + 4));
            oGraphics.DrawLine(new Pen(new SolidColorBrush(oBackgroundColor), 1), new Point(X + 2, Y + 2), new Point(X + 2, Y + 7));
            oGraphics.DrawLine(new Pen(new SolidColorBrush(oBackgroundColor), 1), new Point(X + 3, Y + 3), new Point(X + 3, Y + 6));
            oGraphics.DrawLine(new Pen(new SolidColorBrush(oBackgroundColor), 1), new Point(X + 4, Y + 4), new Point(X + 4, Y + 5));
        }

        internal void mp_DrawCollapseIcon(int X, int Y, Color oColor, Color oDropShadowColor)
        {
            oGraphics.DrawLine(new Pen(new SolidColorBrush(oColor), 1), new Point(X + 4, Y + 3), new Point(X + 6, Y + 3));
            oGraphics.DrawLine(new Pen(new SolidColorBrush(oColor), 1), new Point(X + 3, Y + 4), new Point(X + 6, Y + 4));
            oGraphics.DrawLine(new Pen(new SolidColorBrush(oColor), 1), new Point(X + 2, Y + 5), new Point(X + 6, Y + 5));
            oGraphics.DrawLine(new Pen(new SolidColorBrush(oColor), 1), new Point(X + 1, Y + 6), new Point(X + 6, Y + 6));
            oGraphics.DrawLine(new Pen(new SolidColorBrush(oColor), 1), new Point(X, Y + 7), new Point(X + 6, Y + 7));
            oGraphics.DrawLine(new Pen(new SolidColorBrush(oDropShadowColor), 1), new Point(X + 6, Y + 1), new Point(X, Y + 7));
        }

    }

}