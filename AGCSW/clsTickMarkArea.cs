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

namespace AGCSW
{
	public class clsTickMarkArea
	{

        private ActiveGanttCSWCtl mp_oControl;
		private int mp_lHeight;
		private int mp_lBigTickMarkHeight;
		private int mp_lMediumTickMarkHeight;
		private int mp_lSmallTickMarkHeight;
		private bool mp_bVisible;
		private int mp_lTextOffset;
		
		public clsTickMarks TickMarks;
		private clsTimeLine mp_oTimeLine;
		private string mp_sStyleIndex;
		private clsStyle mp_oStyle;

        internal clsTickMarkArea(ActiveGanttCSWCtl oControl, clsTimeLine oTimeLine)
        {
            mp_oControl = oControl;
            mp_oTimeLine = oTimeLine;
            TickMarks = new clsTickMarks(mp_oControl);
            Clear();
        }
    
		
		public int Height 
		{
			get { return mp_lHeight; }
			set { mp_lHeight = value; }
		}
    
		
		public int BigTickMarkHeight 
		{
			get { return mp_lBigTickMarkHeight; }
			set { mp_lBigTickMarkHeight = value; }
		}
    
		
		public int MediumTickMarkHeight 
		{
			get { return mp_lMediumTickMarkHeight; }
			set { mp_lMediumTickMarkHeight = value; }
		}
    
		
		public int SmallTickMarkHeight 
		{
			get { return mp_lSmallTickMarkHeight; }
			set { mp_lSmallTickMarkHeight = value; }
		}
    
		
		public bool Visible 
		{
			get { return mp_bVisible; }
			set { mp_bVisible = value; }
		}
    
		
		public string StyleIndex 
		{
			get 
			{
				if (mp_sStyleIndex == "DS_TICKMARKAREA") 
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
                if (value.Length == 0) { value = "DS_TICKMARKAREA"; }
				mp_sStyleIndex = value;
				mp_oStyle = mp_oControl.Styles.FItem(value);
			}
		}

        public clsStyle Style
        {
            get { return mp_oStyle; }
        }
    
		
		public int TextOffset 
		{
			get { return mp_lTextOffset; }
			set { mp_lTextOffset = value; }
		}


        internal void Draw()
        {
            DateTime dtBuff = new DateTime();
            clsTickMark oTickMark = null;
            int lIndex = 0;
            if (Visible == false)
            {
                return;
            }
            mp_oControl.CustomTickMarkAreaDrawEventArgs.Clear();
            mp_oControl.CustomTickMarkAreaDrawEventArgs.Graphics = mp_oControl.clsG.oGraphics;
            mp_oControl.CustomTickMarkAreaDrawEventArgs.CustomDraw = false;
            mp_oControl.CustomTickMarkAreaDrawEventArgs.Left = mp_oTimeLine.f_lStart;
            mp_oControl.CustomTickMarkAreaDrawEventArgs.Top = mp_oTimeLine.Bottom - Height;
            mp_oControl.CustomTickMarkAreaDrawEventArgs.Right = mp_oTimeLine.f_lEnd;
            mp_oControl.CustomTickMarkAreaDrawEventArgs.Bottom = mp_oTimeLine.Bottom;
            mp_oControl.FireCustomTickMarkAreaDraw();
            if (mp_oControl.CustomTickMarkAreaDrawEventArgs.CustomDraw == false)
            {
                mp_oControl.clsG.mp_DrawItem(mp_oTimeLine.f_lStart, mp_oTimeLine.Bottom - Height, mp_oTimeLine.f_lEnd, mp_oTimeLine.Bottom, "", "", false, null, mp_oTimeLine.f_lStart, mp_oTimeLine.f_lEnd,
                mp_oStyle);
            }
            mp_oControl.clsG.mp_ClipRegion(mp_oTimeLine.f_lStart, mp_oTimeLine.Bottom - Height, mp_oTimeLine.f_lEnd, mp_oTimeLine.Bottom, false);
            for (lIndex = 1; lIndex <= TickMarks.Count; lIndex++)
            {
                E_INTERVAL yInterval;
                int lFactor = 0;
                oTickMark = TickMarks.Item(lIndex.ToString());
                yInterval = oTickMark.Interval;
                lFactor = oTickMark.Factor;
                if (mp_oControl.MathLib.GetXCoordinateFromDate(mp_oControl.MathLib.DateTimeAdd(yInterval, lFactor, mp_oTimeLine.StartDate)) - mp_oControl.MathLib.GetXCoordinateFromDate(mp_oTimeLine.StartDate) < 5)
                {
                    break; // TODO: might not be correct. Was : Exit For
                }
                dtBuff = mp_oControl.MathLib.RoundDate(yInterval, lFactor, mp_oTimeLine.StartDate);
                if (mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff) >= mp_oTimeLine.f_lStart)
                {
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.Clear();
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.Graphics = mp_oControl.clsG.oGraphics;
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.Left = mp_oTimeLine.f_lStart;
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.Top = mp_oTimeLine.Bottom - Height;
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.Right = mp_oTimeLine.f_lEnd;
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.Bottom = mp_oTimeLine.Bottom;
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.oTickMark = oTickMark;
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.dtDate = dtBuff;
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.X = mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff);
                    mp_oControl.FireCustomTickMarkDraw();
                    if (mp_oControl.CustomTickMarkAreaDrawEventArgs.CustomDraw == false)
                    {
                        PaintTickMark(dtBuff, oTickMark);
                        if (oTickMark.DisplayText == true)
                        {
                            PaintText(mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff), oTickMark);
                        }
                    }
                }
                while (dtBuff < mp_oTimeLine.EndDate)
                {
                    dtBuff = mp_oControl.MathLib.DateTimeAdd(yInterval, lFactor, dtBuff);
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.Clear();
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.Graphics = mp_oControl.clsG.oGraphics;
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.Left = mp_oTimeLine.f_lStart;
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.Top = mp_oTimeLine.Bottom - Height;
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.Right = mp_oTimeLine.f_lEnd;
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.Bottom = mp_oTimeLine.Bottom;
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.oTickMark = oTickMark;
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.dtDate = dtBuff;
                    mp_oControl.CustomTickMarkAreaDrawEventArgs.X = mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff);
                    mp_oControl.FireCustomTickMarkDraw();
                    if (mp_oControl.CustomTickMarkAreaDrawEventArgs.CustomDraw == false)
                    {
                        PaintTickMark(dtBuff, oTickMark);
                        if (oTickMark.DisplayText == true)
                        {
                            PaintText(mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff), oTickMark);
                        }
                    }
                }
            }
            mp_oControl.clsG.mp_ClearClipRegion();
        }

        private void PaintTickMark(DateTime dtDate, clsTickMark oTickMark)
        {
            int fXCoordinate = 0;
            int lTickMarkHeight = 0;
            DateTime dtBuff = mp_oControl.MathLib.RoundDate(oTickMark.Interval, oTickMark.Factor, dtDate);
            fXCoordinate = mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff);
            switch (oTickMark.TickMarkType)
            {
                case E_TICKMARKTYPES.TLT_BIG:
                    lTickMarkHeight = mp_lBigTickMarkHeight;
                    break;
                case E_TICKMARKTYPES.TLT_MEDIUM:
                    lTickMarkHeight = mp_lMediumTickMarkHeight;
                    break;
                case E_TICKMARKTYPES.TLT_SMALL:
                    lTickMarkHeight = mp_lSmallTickMarkHeight;
                    break;
            }
            mp_oControl.clsG.mp_DrawLine(fXCoordinate, mp_oTimeLine.Bottom - lTickMarkHeight, fXCoordinate, mp_oTimeLine.Bottom, GRE_LINETYPE.LT_NORMAL, mp_oStyle.BorderColor, GRE_LINEDRAWSTYLE.LDS_SOLID);
        }

        private void PaintText(int fXCoordinate, clsTickMark oTickMark)
        {
            DateTime dtDateBuff;
            string sDateBuff = null;
            int lLeft = 0;
            int lTop = 0;
            int lRight = 0;
            int lBottom = 0;
            int lStringWidth = 0;
            int lStringHeight = 0;
            dtDateBuff = mp_oControl.MathLib.GetDateFromXCoordinate(fXCoordinate);
            dtDateBuff = mp_oControl.MathLib.RoundDate(oTickMark.Interval, oTickMark.Factor, dtDateBuff);
            sDateBuff = dtDateBuff.ToString(oTickMark.TextFormat);
            lStringWidth = mp_oControl.clsG.mp_lStrWidth(sDateBuff, mp_oStyle.Font);
            lStringHeight = mp_oControl.clsG.mp_lStrHeight(sDateBuff, mp_oStyle.Font);
            lLeft = fXCoordinate - (lStringWidth / 2) - 10;
            lTop = mp_oTimeLine.Bottom - mp_lTextOffset - lStringHeight;
            lRight = fXCoordinate + (lStringWidth / 2) + 10;
            lBottom = lTop + lStringHeight;
            mp_oControl.TickMarkTextDrawEventArgs.Clear();
            mp_oControl.TickMarkTextDrawEventArgs.dtDate = dtDateBuff;
            mp_oControl.TickMarkTextDrawEventArgs.Text = sDateBuff;
            mp_oControl.TickMarkTextDrawEventArgs.CustomDraw = false;
            mp_oControl.FireTickMarkTextDraw();
            if (mp_oControl.TickMarkTextDrawEventArgs.CustomDraw == false)
            {
                mp_oControl.clsG.mp_DrawAlignedText(lLeft, lTop, lRight, lBottom, sDateBuff, GRE_HORIZONTALALIGNMENT.HAL_CENTER, GRE_VERTICALALIGNMENT.VAL_CENTER, mp_oStyle.ForeColor, mp_oStyle.Font);
            }
            else
            {
                mp_oControl.clsG.mp_DrawAlignedText(lLeft, lTop, lRight, lBottom, mp_oControl.TickMarkTextDrawEventArgs.Text, GRE_HORIZONTALALIGNMENT.HAL_CENTER, GRE_VERTICALALIGNMENT.VAL_CENTER, mp_oStyle.ForeColor, mp_oStyle.Font);
            }
        }
    
		
		public string GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "TickMarkArea");
			oXML.InitializeWriter();
			oXML.WriteProperty("BigTickMarkHeight", mp_lBigTickMarkHeight);
			oXML.WriteProperty("Height", mp_lHeight);
			oXML.WriteProperty("MediumTickMarkHeight", mp_lMediumTickMarkHeight);
			oXML.WriteProperty("SmallTickMarkHeight", mp_lSmallTickMarkHeight);
			oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
			oXML.WriteProperty("TextOffset", mp_lTextOffset);
			oXML.WriteProperty("Visible", mp_bVisible);
			oXML.WriteObject(TickMarks.GetXML());
			return oXML.GetXML();
		}
    
		
		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "TickMarkArea");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("BigTickMarkHeight", ref mp_lBigTickMarkHeight);
			oXML.ReadProperty("Height", ref mp_lHeight);
			oXML.ReadProperty("MediumTickMarkHeight", ref mp_lMediumTickMarkHeight);
			oXML.ReadProperty("SmallTickMarkHeight", ref mp_lSmallTickMarkHeight);
			oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
			StyleIndex = mp_sStyleIndex;
			oXML.ReadProperty("TextOffset", ref mp_lTextOffset);
			oXML.ReadProperty("Visible", ref mp_bVisible);
			TickMarks.SetXML(oXML.ReadObject("TickMarks"));
		}

        internal void Clear()
        {
            mp_lBigTickMarkHeight = 12;
            mp_lHeight = 23;
            mp_lMediumTickMarkHeight = 9;
            mp_lSmallTickMarkHeight = 7;
            mp_sStyleIndex = "DS_TICKMARKAREA";
            mp_oStyle = mp_oControl.Styles.FItem("DS_TICKMARKAREA");
            mp_lTextOffset = 11;
            mp_bVisible = true;
            TickMarks.Clear();
        }

        internal void Clone(clsTickMarkArea oClone)
        {
            oClone.BigTickMarkHeight = mp_lBigTickMarkHeight;
            oClone.Height = mp_lHeight;
            oClone.MediumTickMarkHeight = mp_lMediumTickMarkHeight;
            oClone.SmallTickMarkHeight = mp_lSmallTickMarkHeight;
            oClone.StyleIndex = mp_sStyleIndex;
            oClone.TextOffset = mp_lTextOffset;
            oClone.Visible = mp_bVisible;
            TickMarks.Clone(oClone.TickMarks);
        }
    
	}
}