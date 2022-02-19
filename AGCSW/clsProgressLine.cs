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
using System.Collections;
using System.Collections.Generic;

namespace AGCSW
{
    public class clsProgressLine
    {

        private ActiveGanttCSWCtl mp_oControl;
        private Color mp_clrForeColor;
        private DateTime mp_dtPosition;
        private E_PROGRESSLINELENGTH mp_yLength;
        private E_PROGRESSLINETYPE mp_yLineType;
        private int mp_lWidth;
        private E_PROGRESSLINESTYLE mp_yLineStyle;
        internal List<Color> mp_aColors;
        private string mp_sStyleIndex;
        private clsStyle mp_oStyle;

        internal clsProgressLine(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            mp_aColors = new List<Color>();
            Clear();
        }

        public E_PROGRESSLINESTYLE LineStyle
        {
            get { return mp_yLineStyle; }
            set { mp_yLineStyle = value; }
        }

        public string StyleIndex
        {
            get
            {
                if (mp_sStyleIndex == "DS_PROGRESSLINE")
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
                    value = "DS_PROGRESSLINE";
                mp_sStyleIndex = value;
                mp_oStyle = mp_oControl.Styles.FItem(value);
            }
        }

        public clsStyle Style
        {
            get { return mp_oStyle; }
        }

        public void SetColor(int Index, Color oColor)
        {
            Index = Index - 1;
            if (mp_yLineStyle != E_PROGRESSLINESTYLE.PLT_USERDEFINED)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PROGRESSLINE_INVALIDOP, "Invalid Operation", "ActiveGanttCSWCtl.clsProgressLine.SetColor");
                return;
            }
            if (Index < 0)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PROGRESSLINE_INVALID_INDEX, "Invalid Index", "ActiveGanttCSWCtl.clsProgressLine.SetColor");
                return;
            }
            if (Index > mp_aColors.Count - 1)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PROGRESSLINE_INVALID_INDEX, "Invalid Index", "ActiveGanttCSWCtl.clsProgressLine.SetColor");
                return;
            }
            mp_aColors[Index] = oColor;
        }

        public Nullable<Color> GetColor(int Index)
        {
            Index = Index - 1;
            if (mp_yLineStyle != E_PROGRESSLINESTYLE.PLT_USERDEFINED)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PROGRESSLINE_INVALIDOP, "Invalid Operation", "ActiveGanttCSWCtl.clsProgressLine.GetColor");
                return null;
            }
            if (Index < 0)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PROGRESSLINE_INVALID_INDEX, "Invalid Index", "ActiveGanttCSWCtl.clsProgressLine.GetColor");
                return null;
            }
            if (Index > mp_aColors.Count - 1)
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.PROGRESSLINE_INVALID_INDEX, "Invalid Index", "ActiveGanttCSWCtl.clsProgressLine.GetColor");
                return null;
            }
            return (Color)mp_aColors[Index];
        }

        public int Width
        {
            get
            {
                if (mp_yLineStyle == E_PROGRESSLINESTYLE.PLT_STANDARD)
                {
                    return 1;
                }
                else
                {
                    return mp_lWidth;
                }
            }
            set
            {
                if (mp_yLineStyle == E_PROGRESSLINESTYLE.PLT_STANDARD)
                {
                    mp_lWidth = 1;
                }
                else
                {
                    if (value < 0)
                    {
                        mp_oControl.mp_ErrorReport(SYS_ERRORS.PROGRESSLINE_INVALID_WIDTH, "Invalid Width Value", "ActiveGanttCSWCtl.clsProgressLine.Width");
                        return;
                    }
                    mp_lWidth = value;
                }
                int i = 0;
                mp_aColors.Clear();
                for (i = 0; i <= mp_lWidth - 1; i++)
                {
                    mp_aColors.Add(Color.FromArgb(255, 255, 255, 255));
                }
            }
        }

        public DateTime Position
        {
            get { return mp_dtPosition; }
            set { mp_dtPosition = value; }
        }

        public Color ForeColor
        {
            get { return mp_clrForeColor; }
            set { mp_clrForeColor = value; }
        }

        public E_PROGRESSLINELENGTH Length
        {
            get { return mp_yLength; }
            set { mp_yLength = value; }
        }

        public E_PROGRESSLINETYPE LineType
        {
            get { return mp_yLineType; }
            set { mp_yLineType = value; }
        }

        private clsTimeLine mp_oTimeLine()
        {
            return mp_oControl.CurrentViewObject.TimeLine;
        }

        internal void Draw()
        {
            int lX1 = 0;
            int lX2 = 0;
            E_PROGRESSLINELENGTH yTimeLineMarkerLength;
            DateTime dtDate = new DateTime();
            int lTop = 0;
            int lBottom = 0;
            if (mp_yLineType == E_PROGRESSLINETYPE.TLMT_SYSTEMTIME)
            {
                dtDate = DateTime.Now;
            }
            else
            {
                dtDate = mp_dtPosition;
            }
            if (dtDate >= mp_oTimeLine().StartDate & dtDate <= mp_oTimeLine().EndDate)
            {
                yTimeLineMarkerLength = mp_yLength;
                lX1 = mp_oControl.MathLib.GetXCoordinateFromDate(mp_dtPosition);
                if (mp_oTimeLine().TickMarkArea.Visible == false & yTimeLineMarkerLength == E_PROGRESSLINELENGTH.TLMA_CA_TICKMARKAREA)
                {
                    yTimeLineMarkerLength = E_PROGRESSLINELENGTH.TLMA_CLIENTAREA;
                }
                if (mp_oTimeLine().TickMarkArea.Visible == false & yTimeLineMarkerLength == E_PROGRESSLINELENGTH.TLMA_TICKMARKAREA)
                {
                    return;
                }
                if (mp_oTimeLine().TickMarkArea.Visible == false & yTimeLineMarkerLength == E_PROGRESSLINELENGTH.TLMA_TIMELINE & mp_oTimeLine().TierArea.LowerTier.Visible == false & mp_oTimeLine().TierArea.MiddleTier.Visible == false & mp_oTimeLine().TierArea.UpperTier.Visible == false)
                {
                    return;
                }
                switch (yTimeLineMarkerLength)
                {
                    case E_PROGRESSLINELENGTH.TLMA_TICKMARKAREA:
                        lTop = mp_oTimeLine().TiersTickMarksPosition("TickMarkArea");
                        lBottom = mp_oTimeLine().Bottom;
                        break;
                    case E_PROGRESSLINELENGTH.TLMA_CA_TIMELINE:
                        lTop = mp_oTimeLine().Top;
                        lBottom = mp_oControl.CurrentViewObject.ClientArea.Bottom;
                        break;
                    case E_PROGRESSLINELENGTH.TLMA_CLIENTAREA:
                        lTop = mp_oControl.CurrentViewObject.ClientArea.Top;
                        lBottom = mp_oControl.CurrentViewObject.ClientArea.Bottom;
                        break;
                    case E_PROGRESSLINELENGTH.TLMA_CA_TICKMARKAREA:
                        lTop = mp_oTimeLine().TiersTickMarksPosition("TickMarkArea");
                        lBottom = mp_oControl.CurrentViewObject.ClientArea.Bottom;
                        break;
                    case E_PROGRESSLINELENGTH.TLMA_NONE:
                        return;
                }
                mp_oControl.clsG.mp_ClipRegion(mp_oTimeLine().f_lStart, lTop, mp_oTimeLine().f_lEnd, lBottom, true);
                switch (mp_yLineStyle)
                {
                    case E_PROGRESSLINESTYLE.PLT_STANDARD:
                        mp_oControl.clsG.mp_DrawLine(lX1, lTop, lX1, lBottom, GRE_LINETYPE.LT_NORMAL, mp_clrForeColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
                        break;
                    case E_PROGRESSLINESTYLE.PLT_USERDEFINED:
                        lX1 = lX1 - System.Convert.ToInt32(System.Math.Floor((double)mp_lWidth / 2));
                        int i = 0;
                        for (i = 0; i <= mp_aColors.Count - 1; i++)
                        {
                            mp_oControl.clsG.mp_DrawLine(lX1 + i, lTop, lX1 + i, lBottom, GRE_LINETYPE.LT_NORMAL, (Color)mp_aColors[i], GRE_LINEDRAWSTYLE.LDS_SOLID);
                        }

                        break;
                    case E_PROGRESSLINESTYLE.PLT_STYLE:
                        if (mp_lWidth > 1)
                        {
                            lX1 = lX1 - System.Convert.ToInt32(System.Math.Floor((double)mp_lWidth / 2));
                            lX2 = lX1 + mp_lWidth - 1;
                        }
                        else
                        {
                            lX2 = lX1 + 1;
                        }
                        mp_oControl.clsG.mp_DrawItem(lX1, lTop, lX2, lBottom, "", "", false, null, 0, 0,
                        this.Style);
                        break;
                }
                mp_oControl.clsG.mp_ClearClipRegion();
            }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "ProgressLine");
            oXML.InitializeWriter();
            oXML.WriteProperty("ForeColor", mp_clrForeColor);
            oXML.WriteProperty("Length", mp_yLength);
            oXML.WriteProperty("LineType", mp_yLineType);
            oXML.WriteProperty("LineStyle", mp_yLineStyle);
            oXML.WriteProperty("Position", mp_dtPosition);
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteProperty("Width", mp_lWidth);
            if (mp_yLineStyle == E_PROGRESSLINESTYLE.PLT_USERDEFINED)
            {
                oXML.WriteProperty("ColorCount", mp_aColors.Count);
                int i = 0;
                for (i = 0; i <= mp_aColors.Count - 1; i++)
                {
                    oXML.WriteProperty("Color" + i.ToString(), mp_aColors[i]);
                }
            }
            else
            {
                oXML.WriteProperty("ColorCount", 0);
            }
            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "ProgressLine");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("ForeColor", ref mp_clrForeColor);
            oXML.ReadProperty("Length", ref mp_yLength);
            oXML.ReadProperty("LineType", ref mp_yLineType);
            oXML.ReadProperty("LineStyle", ref mp_yLineStyle);
            oXML.ReadProperty("Position", ref mp_dtPosition);
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            StyleIndex = mp_sStyleIndex;
            oXML.ReadProperty("Width", ref mp_lWidth);
            mp_aColors.Clear();
            int lColorCount = 0;
            oXML.ReadProperty("ColorCount", ref lColorCount);
            if (lColorCount > 0)
            {
                int i = 0;
                for (i = 0; i <= lColorCount - 1; i++)
                {
                    Color oColor = Color.FromArgb(255, 255, 255, 255);
                    oXML.ReadProperty("Color" + i.ToString(), ref oColor);
                    mp_aColors.Add(oColor);
                }
            }
            StyleIndex = mp_sStyleIndex;
        }

        internal void Clear()
        {
            mp_clrForeColor = Color.FromArgb(255, 255, 0, 0);
            mp_yLength = E_PROGRESSLINELENGTH.TLMA_TICKMARKAREA;
            mp_yLineType = E_PROGRESSLINETYPE.TLMT_SYSTEMTIME;
            mp_yLineStyle = E_PROGRESSLINESTYLE.PLT_STANDARD;
            mp_dtPosition = new DateTime();
            mp_dtPosition = DateTime.Now;
            mp_sStyleIndex = "DS_PROGRESSLINE";
            mp_oStyle = mp_oControl.Styles.FItem("DS_PROGRESSLINE");
            mp_lWidth = 1;
            mp_aColors.Clear();
        }

        internal void Clone(clsProgressLine oClone)
        {
            oClone.ForeColor = mp_clrForeColor;
            oClone.Length = mp_yLength;
            oClone.LineType = mp_yLineType;
            oClone.LineStyle = mp_yLineStyle;
            oClone.Position = mp_dtPosition;
            oClone.StyleIndex = mp_sStyleIndex;
            oClone.Width = mp_lWidth;
            oClone.mp_aColors.Clear();
            int i = 0;
            for (i = 0; i <= mp_aColors.Count - 1; i++)
            {
                oClone.mp_aColors.Add(mp_aColors[i]);
            }
        }

    }
}