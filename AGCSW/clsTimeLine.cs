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

namespace AGCSW
{
	public class clsTimeLine
	{

        private ActiveGanttCSWCtl mp_oControl;
		private clsView mp_oView;
		
		public clsTimeLineScrollBar TimeLineScrollBar;
		
		public clsTierArea TierArea;
		
		public clsTickMarkArea TickMarkArea;
		private string mp_sStyleIndex;
		private System.Windows.Media.Color mp_clrForeColor;
		
		public clsProgressLine ProgressLine;
		private DateTime mp_dtStartDate;
		private int mp_lEnd;
		private int mp_lStart;
		private clsStyle mp_oStyle;


        internal clsTimeLine(ActiveGanttCSWCtl oControl, clsView oView)
        {
            mp_oControl = oControl;
            mp_oView = oView;
            TimeLineScrollBar = new clsTimeLineScrollBar(mp_oControl);
            TierArea = new clsTierArea(mp_oControl, this);
            TickMarkArea = new clsTickMarkArea(mp_oControl, this);
            ProgressLine = new clsProgressLine(mp_oControl);
            Clear();
        }
    
		
		public string StyleIndex 
		{
			get 
			{
				if (mp_sStyleIndex == "DS_TIMELINE") 
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
                if (value.Length == 0) { value = "DS_TIMELINE"; }
				mp_sStyleIndex = value;
				mp_oStyle = mp_oControl.Styles.FItem(value);
			}
		}
    
		
		public clsStyle Style 
		{
			get { return mp_oStyle; }
		}
    
		
		public Color ForeColor 
		{
			get { return mp_clrForeColor; }
			set { mp_clrForeColor = value; }
		}


        public DateTime EndDate
        {
            get
            {
                Calculate();
                return mp_oControl.MathLib.DateTimeAdd(mp_oView.Interval, (mp_lEnd - mp_lStart) * mp_oView.Factor, mp_dtStartDate);
            }
        }


        public DateTime StartDate 
		{
			get { return mp_dtStartDate; }
		}

        internal DateTime f_StartDate 
		{
			set 
			{
				mp_dtStartDate = value;
				Calculate();
			}
		}
    
		internal int f_lStart 
		{
			get { return mp_lStart; }
		}
    
		internal int f_lEnd 
		{
			get { return mp_lEnd; }
		}


        public void Move(E_INTERVAL Interval, int Factor)
        {
            f_StartDate = mp_oControl.MathLib.DateTimeAdd(Interval, Factor, mp_dtStartDate);
        }


        public void Position(DateTime TimeLineStartDate)
		{
			f_StartDate = TimeLineStartDate;
		}
    
		
		public int Height 
		{
			get { return Bottom - Top; }
		}
    
		
		public int Top 
		{
			get { return mp_oControl.mt_BorderThickness; }
		}
    
		
		public int Bottom 
		{
			get 
			{
				int lReturn = 0;
				int lUpperTierHeight = 0;
				int lMiddleTierHeight = 0;
				int lLowerTierHeight = 0;
				int lTickMarkAreaHeight = 0;
				if ((TierArea.UpperTier.Visible == true)) 
				{
					lUpperTierHeight = TierArea.UpperTier.Height;
				}
				if ((TierArea.MiddleTier.Visible == true)) 
				{
					lMiddleTierHeight = TierArea.MiddleTier.Height;
				}
				if ((TierArea.LowerTier.Visible == true)) 
				{
					lLowerTierHeight = TierArea.LowerTier.Height;
				}
				if ((TickMarkArea.Visible == true)) 
				{
					lTickMarkAreaHeight = TickMarkArea.Height;
				}
				lReturn = lUpperTierHeight + lMiddleTierHeight + lLowerTierHeight + lTickMarkAreaHeight;
				lReturn = lReturn + mp_oControl.mt_BorderThickness;
				return lReturn;
			}
		}

        internal void Calculate()
        {
            if (mp_oControl.f_TimeLineScrollBar.Enabled == true)
            {
                mp_dtStartDate = mp_oControl.MathLib.DateTimeAdd(mp_oControl.f_TimeLineScrollBar.Interval, mp_oControl.f_TimeLineScrollBar.Value * mp_oControl.f_TimeLineScrollBar.Factor, mp_oControl.f_TimeLineScrollBar.StartDate);
            }
            mp_dtStartDate = mp_oControl.MathLib.RoundDate(mp_oView.Interval, mp_oView.Factor, mp_dtStartDate);
            mp_lStart = mp_oControl.Splitter.Right;
            mp_lEnd = mp_oControl.mt_RightMargin;
            if (mp_oStyle.Appearance == E_STYLEAPPEARANCE.SA_RAISED)
            {
                if (mp_oStyle.ButtonStyle == GRE_BUTTONSTYLE.BT_NORMALWINDOWS)
                {
                    mp_lStart = mp_oControl.Splitter.Right + 1;
                    mp_lEnd = mp_oControl.mt_RightMargin - 1;
                }
                else if (mp_oStyle.ButtonStyle == GRE_BUTTONSTYLE.BT_LIGHTWEIGHT)
                {
                    mp_lStart = mp_oControl.Splitter.Right + 2;
                    mp_lEnd = mp_oControl.mt_RightMargin - 2;
                }
            }
            else
            {
                mp_lStart = mp_oControl.Splitter.Right;
                mp_lEnd = mp_oControl.mt_RightMargin;
            }
        }
    
		internal int TiersTickMarksPosition(string v_yTier)
		{
			int lReturn = 0;
			int lUpperTierHeight = 0;
			int lMiddleTierHeight = 0;
			int lLowerTierHeight = 0;
			int lTickMarkAreaHeight = 0;
			lReturn = 0;
			lUpperTierHeight = 0;
			lLowerTierHeight = 0;
			lTickMarkAreaHeight = 0;
			if ((TierArea.UpperTier.Visible == true)) 
			{
				lUpperTierHeight = TierArea.UpperTier.Height;
			}
			if ((TierArea.MiddleTier.Visible == true)) 
			{
				lMiddleTierHeight = TierArea.MiddleTier.Height;
			}
			if ((TierArea.LowerTier.Visible == true)) 
			{
				lLowerTierHeight = TierArea.LowerTier.Height;
			}
			if ((TickMarkArea.Visible == true)) 
			{
				lTickMarkAreaHeight = TickMarkArea.Height;
			}
			lReturn = lUpperTierHeight + lMiddleTierHeight + lLowerTierHeight + lTickMarkAreaHeight;
			lReturn = lReturn + mp_oControl.mt_BorderThickness;
			switch ((v_yTier)) 
			{
				case "UpperTier":
					lReturn = lReturn - lUpperTierHeight - lMiddleTierHeight - lLowerTierHeight - lTickMarkAreaHeight;
					break;
				case "MiddleTier":
					lReturn = lReturn - lMiddleTierHeight - lLowerTierHeight - lTickMarkAreaHeight;
					break;
				case "LowerTier":
					lReturn = lReturn - lLowerTierHeight - lTickMarkAreaHeight;
					break;
				case "TickMarkArea":
					lReturn = lReturn - lTickMarkAreaHeight;
					break;
				default:
					//Interaction.MsgBox("TiersTickMarksPosition Error");
					break;
			}
			return lReturn;
		}
    
		internal void Draw()
		{
			int lBottom = 0;
			int lTop = 0;
			int lLeft = 0;
			int lRight = 0;
			if ((Height == 0)) 
			{
				return;
			}
			lBottom = Bottom;
			lTop = Top;
			lLeft = mp_oControl.Splitter.Right;
			lRight = mp_oControl.mt_RightMargin;
			mp_oControl.clsG.mp_ClipRegion(lLeft, lTop, lRight, lBottom, true);
            mp_oControl.clsG.mp_DrawItem(lLeft, lTop, lRight, lBottom, "", "", false, null, 0, 0, mp_oStyle);
			if (mp_oStyle.Appearance == E_STYLEAPPEARANCE.SA_RAISED) 
			{
				if (mp_oStyle.ButtonStyle == GRE_BUTTONSTYLE.BT_NORMALWINDOWS) 
				{
					mp_oControl.clsG.mp_ClipRegion(lLeft + 2, lTop + 2, lRight - 2, lBottom - 2, true);
				}
				else if (mp_oStyle.ButtonStyle == GRE_BUTTONSTYLE.BT_LIGHTWEIGHT) 
				{
					mp_oControl.clsG.mp_ClipRegion(lLeft + 1, lTop + 1, lRight - 1, lBottom - 1, true);
				}
			}
			TierArea.UpperTier.Position();
			TierArea.MiddleTier.Position();
			TierArea.LowerTier.Position();
			TickMarkArea.Draw();
		}
    
		
		public string GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "TimeLine");
			oXML.InitializeWriter();
			oXML.WriteProperty("ForeColor", mp_clrForeColor);
			oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteProperty("StartDate", mp_dtStartDate);
			oXML.WriteObject(ProgressLine.GetXML());
			oXML.WriteObject(TimeLineScrollBar.GetXML());
			oXML.WriteObject(TickMarkArea.GetXML());
			oXML.WriteObject(TierArea.GetXML());
			return oXML.GetXML();
		}
    
		
		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "TimeLine");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("ForeColor", ref mp_clrForeColor);
			oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            oXML.ReadProperty("StartDate", ref mp_dtStartDate);
			StyleIndex = mp_sStyleIndex;
			Calculate();
			ProgressLine.SetXML(oXML.ReadObject("ProgressLine"));
			TimeLineScrollBar.SetXML(oXML.ReadObject("TimeLineScrollBar"));
			TickMarkArea.SetXML(oXML.ReadObject("TickMarkArea"));
			TierArea.SetXML(oXML.ReadObject("TierArea"));
		}

        internal void Clear()
        {
            mp_clrForeColor = Color.FromArgb(255, 0, 0, 0);
            mp_sStyleIndex = "DS_TIMELINE";
            mp_oStyle = mp_oControl.Styles.FItem("DS_TIMELINE");
            DateTime dtTimeNow = new DateTime();
            dtTimeNow = DateTime.Now;
            f_StartDate = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_HOUR, -3, dtTimeNow);
            ProgressLine.Clear();
            TimeLineScrollBar.Clear();
            TickMarkArea.Clear();
            TierArea.Clear();
        }

        internal void Clone(clsTimeLine oClone)
        {
            oClone.ForeColor = mp_clrForeColor;
            oClone.StyleIndex = mp_sStyleIndex;
            oClone.f_StartDate = mp_dtStartDate;
            ProgressLine.Clone(oClone.ProgressLine);
            TimeLineScrollBar.Clone(oClone.TimeLineScrollBar);
            TickMarkArea.Clone(oClone.TickMarkArea);
            TierArea.Clone(oClone.TierArea);
        }
    
	}
}