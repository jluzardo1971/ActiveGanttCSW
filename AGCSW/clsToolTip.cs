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
using System.Windows.Controls;
using System.Windows.Shapes;


namespace AGCSW
{

    public class clsToolTip
    {

        private ActiveGanttCSWCtl mp_oControl;
        private int mp_lLeft;
        private int mp_lTop;
        private int mp_lWidth;
        private int mp_lHeight;
        private string mp_sText;
        private bool mp_bVisible;
        private Font mp_oFont;
        private bool mp_bAutomaticSizing = false;
        private Color mp_clrBackColor = Color.FromArgb(255, 255, 255, 224);
        private Color mp_clrForeColor = Color.FromArgb(255, 0, 0, 0);
        private Color mp_clrBorderColor = Color.FromArgb(255, 0, 0, 0);
        private Canvas mp_oToolTipCanvas;
        private int mp_lToolTipCanvasIndex = -1;

        internal clsToolTip(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            mp_oFont = mp_oControl.Configuration.DefaultFont.Clone();
            mp_oToolTipCanvas = new Canvas();
        }

        public Font Font
        {
            get { return mp_oFont; }
            set { mp_oFont = value; }
        }

        public Color BackColor
        {
            get { return mp_clrBackColor; }
            set { mp_clrBackColor = value; }
        }

        public Color ForeColor
        {
            get { return mp_clrForeColor; }
            set { mp_clrForeColor = value; }
        }

        public Color BorderColor
        {
            get { return mp_clrBorderColor; }
            set { mp_clrBorderColor = value; }
        }

        public string Text
        {
            get { return mp_sText; }
            set
            {
                mp_sText = value;
                if (mp_bAutomaticSizing == true)
                {
                    Typeface oTypeFace = new Typeface(Font.FamilyName);
                    FormattedText oFormattedText = new FormattedText(mp_sText, mp_oControl.Culture, FlowDirection.LeftToRight, oTypeFace, Font.WPFFontSize, new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)));
                    mp_lWidth = (int)oFormattedText.Width;
                    mp_lHeight = (int)oFormattedText.Height;
                }
            }
        }

        public bool AutomaticSizing
        {
            get { return mp_bAutomaticSizing; }
            set { mp_bAutomaticSizing = value; }
        }

        public int Left
        {
            get { return mp_lLeft; }
            set { mp_lLeft = value; }
        }

        public int Right
        {
            get { return mp_lLeft + mp_lWidth; }
        }

        public int Top
        {
            get { return mp_lTop; }
            set { mp_lTop = value; }
        }

        public int Bottom
        {
            get { return mp_lTop + mp_lHeight; }
        }

        public int Width
        {
            get { return mp_lWidth; }
            set { mp_lWidth = value; }
        }

        public int Height
        {
            get { return mp_lHeight; }
            set { mp_lHeight = value; }
        }

        public bool Visible
        {
            get { return mp_bVisible; }
            set
            {
                mp_bVisible = value;
                if ((mp_lWidth == 0 | mp_lHeight == 0))
                {
                    mp_bVisible = false;
                }
                if ((mp_bVisible == true))
                {
                    Rectangle oRectangle = new Rectangle();
                    if (mp_oControl.f_Canvas().Children.Count == 0)
                    {
                        mp_oToolTipCanvas = new Canvas();
                        oRectangle = new Rectangle();
                        oRectangle.SetValue(Canvas.LeftProperty, (double)0);
                        oRectangle.SetValue(Canvas.TopProperty, (double)0);
                        oRectangle.Width = mp_lWidth;
                        oRectangle.Height = mp_lHeight;
                        oRectangle.Fill = mp_oControl.clsG.GetBrush(mp_clrBackColor);
                        oRectangle.Stroke = mp_oControl.clsG.GetBrush(mp_clrBorderColor);
                        oRectangle.StrokeThickness = 1;
                        mp_oToolTipCanvas.Children.Add(oRectangle);
                        mp_oToolTipCanvas.SetValue(Canvas.LeftProperty, (double)mp_lLeft);
                        mp_oToolTipCanvas.SetValue(Canvas.TopProperty, (double)mp_lTop);
                        mp_oToolTipCanvas.Width = mp_lWidth;
                        mp_oToolTipCanvas.Height = mp_lHeight;
                        mp_lToolTipCanvasIndex = mp_oControl.f_Canvas().Children.Add(mp_oToolTipCanvas);
                    }
                    else
                    {
                        mp_oToolTipCanvas.Children.Clear();
                        oRectangle = new Rectangle();
                        oRectangle.SetValue(Canvas.LeftProperty, (double)0);
                        oRectangle.SetValue(Canvas.TopProperty, (double)0);
                        oRectangle.Width = mp_lWidth;
                        oRectangle.Height = mp_lHeight;
                        oRectangle.Fill = mp_oControl.clsG.GetBrush(mp_clrBackColor);
                        oRectangle.Stroke = mp_oControl.clsG.GetBrush(mp_clrBorderColor);
                        oRectangle.StrokeThickness = 1;
                        mp_oToolTipCanvas.Children.Add(oRectangle);
                        mp_oToolTipCanvas.Width = mp_lWidth;
                        mp_oToolTipCanvas.Height = mp_lHeight;
                    }
                    switch (mp_oControl.ToolTipEventArgs.ToolTipType)
                    {
                        case E_TOOLTIPTYPE.TPT_HOVER:
                            mp_oControl.ToolTipEventArgs.Graphics = mp_oToolTipCanvas;
                            mp_oControl.ToolTipEventArgs.CustomDraw = false;
                            mp_oControl.FireOnMouseHoverToolTipDraw(mp_oControl.ToolTipEventArgs.EventTarget);
                            break;
                        case E_TOOLTIPTYPE.TPT_MOVEMENT:
                            mp_oControl.ToolTipEventArgs.Graphics = mp_oToolTipCanvas;
                            mp_oControl.ToolTipEventArgs.CustomDraw = false;
                            mp_oControl.FireOnMouseMoveToolTipDraw(mp_oControl.ToolTipEventArgs.Operation);
                            break;
                    }
                    if (mp_oControl.ToolTipEventArgs.CustomDraw == false)
                    {
                        //lControlGraphics.DrawString(mp_sText, mp_oFont, New SolidBrush(mp_clrForeColor), mp_lLeft, mp_lTop)
                    }
                }
                else
                {
                    mp_oControl.f_Canvas().Children.Remove(mp_oToolTipCanvas);
                    mp_lToolTipCanvasIndex = -1;
                }
            }
        }

    }

}