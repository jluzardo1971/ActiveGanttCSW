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
	public class clsTier
	{

        private ActiveGanttCSWCtl mp_oControl;
		private bool mp_bVisible;
		private int mp_lFactor;
		private int mp_lHeight;
        private E_INTERVAL mp_yInterval;
		private string mp_sTag;
        private Object mp_oObjectTag;
		private E_TIERTYPE mp_yTierType;
		private E_TIERPOSITION mp_yTierPosition;
		private string mp_sTierPosition;
		private clsTierArea mp_oTierArea;
        private string mp_sStyleIndex;
        private clsStyle mp_oStyle;
        private E_TIERBACKGROUNDMODE mp_yBackgroundMode;

        internal clsTier(ActiveGanttCSWCtl oControl, clsTierArea oTierArea, E_TIERPOSITION yTierPosition)
        {
            mp_oControl = oControl;
            mp_oTierArea = oTierArea;
            mp_yTierPosition = yTierPosition;
            switch (mp_yTierPosition)
            {
                case E_TIERPOSITION.SP_UPPER:
                    mp_sTierPosition = "UpperTier";
                    break;
                case E_TIERPOSITION.SP_MIDDLE:
                    mp_sTierPosition = "MiddleTier";
                    break;
                case E_TIERPOSITION.SP_LOWER:
                    mp_sTierPosition = "LowerTier";
                    break;
            }
            Clear();
        }

		
		public bool Visible 
		{
            get
            {
                if (mp_yTierType == E_TIERTYPE.ST_NOT_VISIBLE)
                {
                    return false;
                }
                else
                {
                    return mp_bVisible;
                }
            }
			set { mp_bVisible = value; }
		}

		
		public string Tag 
		{
			get { return mp_sTag; }
			set { mp_sTag = value; }
		}

        public Object ObjectTag
        {
            get { return mp_oObjectTag; }
            set { mp_oObjectTag = value; }
        }


        public E_INTERVAL Interval
        {
            get
            {
                return mp_yInterval;
            }
            set
            {
                mp_yInterval = value;
                mp_yTierType = E_TIERTYPE.ST_CUSTOM;
            }
        }

        public int Factor
        {
            get
            {
                return mp_lFactor;
            }
            set
            {
                mp_lFactor = value;
            }
        }


        public E_TIERTYPE TierType
        {
            get { return mp_yTierType; }
            set
            {
                mp_yTierType = value;
                switch (mp_yTierType)
                {
                    case E_TIERTYPE.ST_NOT_VISIBLE:
                        mp_yInterval = E_INTERVAL.IL_HOUR;
                        mp_lFactor = 1;
                        break;
                    case E_TIERTYPE.ST_YEAR:
                        mp_yInterval = E_INTERVAL.IL_YEAR;
                        mp_lFactor = 1;
                        break;
                    case E_TIERTYPE.ST_QUARTER:
                        mp_yInterval = E_INTERVAL.IL_QUARTER;
                        mp_lFactor = 1;
                        break;
                    case E_TIERTYPE.ST_MONTH:
                        mp_yInterval = E_INTERVAL.IL_MONTH;
                        mp_lFactor = 1;
                        break;
                    case E_TIERTYPE.ST_WEEK:
                        mp_yInterval = E_INTERVAL.IL_WEEK;
                        mp_lFactor = 1;
                        break;
                    case E_TIERTYPE.ST_DAYOFWEEK:
                        mp_yInterval = E_INTERVAL.IL_DAY;
                        mp_lFactor = 1;
                        break;
                    case E_TIERTYPE.ST_DAY:
                        mp_yInterval = E_INTERVAL.IL_DAY;
                        mp_lFactor = 1;
                        break;
                    case E_TIERTYPE.ST_DAYOFYEAR:
                        mp_yInterval = E_INTERVAL.IL_DAY;
                        mp_lFactor = 1;
                        break;
                    case E_TIERTYPE.ST_HOUR:
                        mp_yInterval = E_INTERVAL.IL_HOUR;
                        mp_lFactor = 1;
                        break;
                    case E_TIERTYPE.ST_MINUTE:
                        mp_yInterval = E_INTERVAL.IL_MINUTE;
                        mp_lFactor = 1;
                        break;
                    case E_TIERTYPE.ST_SECOND:
                        mp_yInterval = E_INTERVAL.IL_SECOND;
                        mp_lFactor = 1;
                        break;
                }
            }
        }

		
		public int Height 
		{
			get { return mp_lHeight; }
			set { mp_lHeight = value; }
		}

        internal void Position()
        {
            if (Visible == false)
            {
                return;
            }
            DateTime dtStart = new DateTime();
            DateTime dtEnd = new DateTime();
            int lTop = 0;
            int lBottom = 0;
            int lTierHeight = 0;
            lTierHeight = Height;
            lTop = mp_oTierArea.TimeLine.TiersTickMarksPosition(mp_sTierPosition);
            lBottom = lTop + lTierHeight - 1;
            if ((mp_oControl.MathLib.GetXCoordinateFromDate(mp_oControl.MathLib.DateTimeAdd(mp_yInterval, mp_lFactor, mp_oTierArea.TimeLine.StartDate)) - mp_oControl.MathLib.GetXCoordinateFromDate(mp_oTierArea.TimeLine.StartDate) > 5))
            {
                dtEnd = mp_oControl.MathLib.RoundDate(mp_yInterval, mp_lFactor, mp_oTierArea.TimeLine.StartDate);
                if ((mp_oControl.MathLib.GetXCoordinateFromDate(dtEnd) >= mp_oTierArea.TimeLine.f_lStart))
                {
                    dtStart = mp_oControl.MathLib.DateTimeAdd(mp_yInterval, -mp_lFactor, dtEnd);
                    dtStart = mp_oControl.MathLib.RoundDate(mp_yInterval, mp_lFactor, dtStart);
                    Draw(dtStart, dtEnd, lTop, lBottom);
                }
                while ((dtEnd < mp_oTierArea.TimeLine.EndDate))
                {
                    dtStart = dtEnd;
                    dtEnd = mp_oControl.MathLib.DateTimeAdd(mp_yInterval, mp_lFactor, dtEnd);
                    dtStart = mp_oControl.MathLib.RoundDate(mp_yInterval, mp_lFactor, dtStart);
                    dtEnd = mp_oControl.MathLib.RoundDate(mp_yInterval, mp_lFactor, dtEnd);
                    Draw(dtStart, dtEnd, lTop, lBottom);
                }
            }
        }

        private void Draw(DateTime dtStart, DateTime dtEnd, int lTop, int lBottom)
        {
            int lStart = 0;
            int lEnd = 0;
            int lStartTrim = 0;
            int lEndTrim = 0;

            string sText = null;
            int lTextWidth = 0;

            Color clrForeColor = Color.FromArgb(255, 255, 255, 255);
            Color clrBackColor = Color.FromArgb(255, 255, 255, 255);
            Color clrStartGradientColor = Color.FromArgb(255, 255, 255, 255);
            Color clrEndGradientColor = Color.FromArgb(255, 255, 255, 255);
            Color clrHatchBackColor = Color.FromArgb(255, 255, 255, 255);
            Color clrHatchForeColor = Color.FromArgb(255, 255, 255, 255);


            lStart = mp_oControl.MathLib.GetXCoordinateFromDate(dtStart);
            lEnd = mp_oControl.MathLib.GetXCoordinateFromDate(dtEnd) - 1;
            if ((lStart < mp_oTierArea.TimeLine.f_lStart))
            {
                lStartTrim = mp_oTierArea.TimeLine.f_lStart;
            }
            else
            {
                lStartTrim = lStart;
            }
            if ((lEnd > mp_oTierArea.TimeLine.f_lEnd))
            {
                lEndTrim = mp_oTierArea.TimeLine.f_lEnd;
            }
            else
            {
                lEndTrim = lEnd;
            }
            sText = "";
            if ((mp_yTierType == E_TIERTYPE.ST_CUSTOM))
            {
                mp_oControl.CustomTierDrawEventArgs.Clear();
                mp_oControl.CustomTierDrawEventArgs.TierPosition = mp_yTierPosition;
                mp_oControl.CustomTierDrawEventArgs.StartDate = dtStart;
                mp_oControl.CustomTierDrawEventArgs.EndDate = dtEnd;
                mp_oControl.CustomTierDrawEventArgs.Left = lStart;
                mp_oControl.CustomTierDrawEventArgs.Top = lTop;
                mp_oControl.CustomTierDrawEventArgs.Right = lEnd;
                mp_oControl.CustomTierDrawEventArgs.Bottom = lBottom;
                mp_oControl.CustomTierDrawEventArgs.LeftTrim = lStartTrim;
                mp_oControl.CustomTierDrawEventArgs.RightTrim = lEndTrim;
                mp_oControl.CustomTierDrawEventArgs.Graphics = mp_oControl.clsG.oGraphics;
                mp_oControl.CustomTierDrawEventArgs.Text = sText;
                mp_oControl.CustomTierDrawEventArgs.StyleIndex = "";
                mp_oControl.CustomTierDrawEventArgs.Interval = Interval;
                mp_oControl.CustomTierDrawEventArgs.Factor = Factor;
                mp_oControl.FireCustomTierDraw();
                if (!(mp_oControl.CustomTierDrawEventArgs.StyleIndex.Length == 0))
                {
                    mp_oControl.clsG.mp_DrawItem(lStart, lTop, lEnd, lBottom, mp_oControl.CustomTierDrawEventArgs.StyleIndex, mp_oControl.CustomTierDrawEventArgs.Text, false, null, lStartTrim, lEndTrim, null);
                }
                else
                {
                    mp_oControl.clsG.mp_DrawItem(lStart, lTop, lEnd, lBottom, "", mp_oControl.CustomTierDrawEventArgs.Text, false, null, lStartTrim, lEndTrim, mp_oControl.Configuration.DefaultTierStyle);
                }
            }
            else
            {
                clsTierAppearance oTierAppearance = null;
                clsTierFormat oTierFormat = null;
                if ((mp_oControl.TierAppearanceScope == E_OBJECTSCOPE.OS_CONTROL))
                {
                    oTierAppearance = mp_oControl.TierAppearance;
                }
                else if ((mp_oControl.TierAppearanceScope == E_OBJECTSCOPE.OS_VIEW))
                {
                    oTierAppearance = mp_oTierArea.TierAppearance;
                }
                if ((mp_oControl.TierFormatScope == E_OBJECTSCOPE.OS_CONTROL))
                {
                    oTierFormat = mp_oControl.TierFormat;
                }
                else if ((mp_oControl.TierFormatScope == E_OBJECTSCOPE.OS_VIEW))
                {
                    oTierFormat = mp_oTierArea.TierFormat;
                }
                if ((mp_yInterval == E_INTERVAL.IL_YEAR))
                {
                    clrForeColor = oTierAppearance.YearColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.Year)).ForeColor;
                    clrBackColor = oTierAppearance.YearColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.Year)).BackColor;
                    clrStartGradientColor = oTierAppearance.YearColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.Year)).StartGradientColor;
                    clrEndGradientColor = oTierAppearance.YearColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.Year)).EndGradientColor;
                    clrHatchBackColor = oTierAppearance.YearColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.Year)).HatchBackColor;
                    clrHatchForeColor = oTierAppearance.YearColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.Year)).HatchForeColor;
                    sText = dtStart.ToString(oTierFormat.YearIntervalFormat, mp_oControl.Culture);
                }
                else if ((mp_yInterval == E_INTERVAL.IL_QUARTER))
                {
                    clrForeColor = oTierAppearance.QuarterColors.Item(mp_oControl.MathLib.Quarter(dtStart).ToString()).ForeColor;
                    clrBackColor = oTierAppearance.QuarterColors.Item(mp_oControl.MathLib.Quarter(dtStart).ToString()).BackColor;
                    clrStartGradientColor = oTierAppearance.QuarterColors.Item(mp_oControl.MathLib.Quarter(dtStart).ToString()).StartGradientColor;
                    clrEndGradientColor = oTierAppearance.QuarterColors.Item(mp_oControl.MathLib.Quarter(dtStart).ToString()).EndGradientColor;
                    clrHatchBackColor = oTierAppearance.QuarterColors.Item(mp_oControl.MathLib.Quarter(dtStart).ToString()).HatchBackColor;
                    clrHatchForeColor = oTierAppearance.QuarterColors.Item(mp_oControl.MathLib.Quarter(dtStart).ToString()).HatchForeColor;
                    sText = dtStart.ToString(oTierFormat.QuarterIntervalFormat, mp_oControl.Culture);
                }
                else if ((mp_yInterval == E_INTERVAL.IL_MONTH))
                {
                    clrForeColor = oTierAppearance.MonthColors.Item(dtStart.Month.ToString()).ForeColor;
                    clrBackColor = oTierAppearance.MonthColors.Item(dtStart.Month.ToString()).BackColor;
                    clrStartGradientColor = oTierAppearance.MonthColors.Item(dtStart.Month.ToString()).StartGradientColor;
                    clrEndGradientColor = oTierAppearance.MonthColors.Item(dtStart.Month.ToString()).EndGradientColor;
                    clrHatchBackColor = oTierAppearance.MonthColors.Item(dtStart.Month.ToString()).HatchBackColor;
                    clrHatchForeColor = oTierAppearance.MonthColors.Item(dtStart.Month.ToString()).HatchForeColor;
                    sText = dtStart.ToString(oTierFormat.MonthIntervalFormat, mp_oControl.Culture);
                }
                else if ((mp_yInterval == E_INTERVAL.IL_WEEK))
                {
                    clrForeColor = oTierAppearance.WeekColors.Item(mp_oControl.MathLib.GetTierIndex(mp_oControl.MathLib.Week(dtStart))).ForeColor;
                    clrBackColor = oTierAppearance.WeekColors.Item(mp_oControl.MathLib.GetTierIndex(mp_oControl.MathLib.Week(dtStart))).BackColor;
                    clrStartGradientColor = oTierAppearance.WeekColors.Item(mp_oControl.MathLib.GetTierIndex(mp_oControl.MathLib.Week(dtStart))).StartGradientColor;
                    clrEndGradientColor = oTierAppearance.WeekColors.Item(mp_oControl.MathLib.GetTierIndex(mp_oControl.MathLib.Week(dtStart))).EndGradientColor;
                    clrHatchBackColor = oTierAppearance.WeekColors.Item(mp_oControl.MathLib.GetTierIndex(mp_oControl.MathLib.Week(dtStart))).HatchBackColor;
                    clrHatchForeColor = oTierAppearance.WeekColors.Item(mp_oControl.MathLib.GetTierIndex(mp_oControl.MathLib.Week(dtStart))).HatchForeColor;
                    sText = dtStart.ToString(oTierFormat.WeekIntervalFormat, mp_oControl.Culture);
                }
                else if ((mp_yInterval == E_INTERVAL.IL_DAY))
                {
                    if ((mp_yTierType == E_TIERTYPE.ST_DAYOFWEEK))
                    {
                        clrBackColor = oTierAppearance.DayOfWeekColors.Item(mp_oControl.MathLib.NumericDayOfWeek(dtStart).ToString()).BackColor;
                        clrForeColor = oTierAppearance.DayOfWeekColors.Item(mp_oControl.MathLib.NumericDayOfWeek(dtStart).ToString()).ForeColor;
                        clrStartGradientColor = oTierAppearance.DayOfWeekColors.Item(mp_oControl.MathLib.NumericDayOfWeek(dtStart).ToString()).StartGradientColor;
                        clrEndGradientColor = oTierAppearance.DayOfWeekColors.Item(mp_oControl.MathLib.NumericDayOfWeek(dtStart).ToString()).EndGradientColor;
                        clrHatchBackColor = oTierAppearance.DayOfWeekColors.Item(mp_oControl.MathLib.NumericDayOfWeek(dtStart).ToString()).HatchBackColor;
                        clrHatchForeColor = oTierAppearance.DayOfWeekColors.Item(mp_oControl.MathLib.NumericDayOfWeek(dtStart).ToString()).HatchForeColor;
                        sText = dtStart.ToString(oTierFormat.DayOfWeekIntervalFormat, mp_oControl.Culture);
                    }
                    else if ((mp_yTierType == E_TIERTYPE.ST_DAY))
                    {
                        clrBackColor = oTierAppearance.DayColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.Day)).BackColor;
                        clrForeColor = oTierAppearance.DayColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.Day)).ForeColor;
                        clrStartGradientColor = oTierAppearance.DayColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.Day)).StartGradientColor;
                        clrEndGradientColor = oTierAppearance.DayColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.Day)).EndGradientColor;
                        clrHatchBackColor = oTierAppearance.DayColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.Day)).HatchBackColor;
                        clrHatchForeColor = oTierAppearance.DayColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.Day)).HatchForeColor;
                        sText = dtStart.ToString(oTierFormat.DayIntervalFormat, mp_oControl.Culture);
                    }
                    else if ((mp_yTierType == E_TIERTYPE.ST_DAYOFYEAR))
                    {
                        clrBackColor = oTierAppearance.DayOfYearColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.DayOfYear)).BackColor;
                        clrForeColor = oTierAppearance.DayOfYearColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.DayOfYear)).ForeColor;
                        clrStartGradientColor = oTierAppearance.DayOfYearColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.DayOfYear)).StartGradientColor;
                        clrEndGradientColor = oTierAppearance.DayOfYearColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.DayOfYear)).EndGradientColor;
                        clrHatchBackColor = oTierAppearance.DayOfYearColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.DayOfYear)).HatchBackColor;
                        clrHatchForeColor = oTierAppearance.DayOfYearColors.Item(mp_oControl.MathLib.GetTierIndex(dtStart.DayOfYear)).HatchForeColor;
                        sText = dtStart.ToString(oTierFormat.DayOfYearIntervalFormat, mp_oControl.Culture);
                    }
                }
                else if ((mp_yInterval == E_INTERVAL.IL_HOUR))
                {
                    clrBackColor = oTierAppearance.HourColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Hour))).BackColor;
                    clrForeColor = oTierAppearance.HourColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Hour))).ForeColor;
                    clrStartGradientColor = oTierAppearance.HourColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Hour))).StartGradientColor;
                    clrEndGradientColor = oTierAppearance.HourColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Hour))).EndGradientColor;
                    clrHatchBackColor = oTierAppearance.HourColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Hour))).HatchBackColor;
                    clrHatchForeColor = oTierAppearance.HourColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Hour))).HatchForeColor;
                    sText = dtStart.ToString(oTierFormat.HourIntervalFormat, mp_oControl.Culture);
                }
                else if ((mp_yInterval == E_INTERVAL.IL_MINUTE))
                {
                    clrBackColor = oTierAppearance.MinuteColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Minute))).BackColor;
                    clrForeColor = oTierAppearance.MinuteColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Minute))).ForeColor;
                    clrStartGradientColor = oTierAppearance.MinuteColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Minute))).StartGradientColor;
                    clrEndGradientColor = oTierAppearance.MinuteColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Minute))).EndGradientColor;
                    clrHatchBackColor = oTierAppearance.MinuteColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Minute))).HatchBackColor;
                    clrHatchForeColor = oTierAppearance.MinuteColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Minute))).HatchForeColor;
                    sText = dtStart.ToString(oTierFormat.MinuteIntervalFormat, mp_oControl.Culture);
                }
                else if ((mp_yInterval == E_INTERVAL.IL_SECOND))
                {
                    clrBackColor = oTierAppearance.SecondColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Second))).BackColor;
                    clrForeColor = oTierAppearance.SecondColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Second))).ForeColor;
                    clrStartGradientColor = oTierAppearance.SecondColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Second))).StartGradientColor;
                    clrEndGradientColor = oTierAppearance.SecondColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Second))).EndGradientColor;
                    clrHatchBackColor = oTierAppearance.SecondColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Second))).HatchBackColor;
                    clrHatchForeColor = oTierAppearance.SecondColors.Item((mp_oControl.MathLib.GetTierIndex(dtStart.Second))).HatchForeColor;
                    sText = dtStart.ToString(oTierFormat.SecondIntervalFormat, mp_oControl.Culture);
                }
                if (lEnd > mp_oTierArea.TimeLine.f_lEnd)
                {
                    lEnd = mp_oTierArea.TimeLine.f_lEnd;
                }
                lTextWidth = mp_oControl.clsG.mp_lStrWidth(sText, mp_oStyle.Font);
                if ((lEnd - lStart) > lTextWidth)
                {
                    mp_oControl.CustomTierDrawEventArgs.Clear();
                    mp_oControl.CustomTierDrawEventArgs.TierPosition = mp_yTierPosition;
                    mp_oControl.CustomTierDrawEventArgs.Text = sText;
                    mp_oControl.CustomTierDrawEventArgs.StartDate = dtStart;
                    mp_oControl.FireTierTextDraw();
                    if (mp_yBackgroundMode == E_TIERBACKGROUNDMODE.ETBGM_TIERAPPEARANCE)
                    {
                        mp_oControl.clsG.mp_DrawItemEx(lStart, lTop, lEnd, lBottom, sText, false, null, lStartTrim, lEndTrim, mp_oStyle, clrBackColor, clrForeColor, clrStartGradientColor, clrEndGradientColor, clrHatchBackColor, clrHatchForeColor);
                    }
                    else if (mp_yBackgroundMode == E_TIERBACKGROUNDMODE.ETBGM_STYLE)
                    {
                        mp_oControl.clsG.mp_DrawItem(lStart, lTop, lEnd, lBottom, "", sText, false, null, lStartTrim, lEndTrim, mp_oStyle);
                    }
                }
                else
                {
                    if (mp_yBackgroundMode == E_TIERBACKGROUNDMODE.ETBGM_TIERAPPEARANCE)
                    {
                        mp_oControl.clsG.mp_DrawItemEx(lStart, lTop, lEnd, lBottom, "", false, null, lStartTrim, lEndTrim, mp_oStyle, clrBackColor, clrForeColor, clrStartGradientColor, clrEndGradientColor, clrHatchBackColor, clrHatchForeColor);
                    }
                    else if (mp_yBackgroundMode == E_TIERBACKGROUNDMODE.ETBGM_STYLE)
                    {
                        mp_oControl.clsG.mp_DrawItem(lStart, lTop, lEnd, lBottom, "", "", false, null, lStartTrim, lEndTrim, mp_oStyle);
                    }
                }
            }
        }

        public string StyleIndex
        {
            get
            {
                if (mp_sStyleIndex == "DS_TIER")
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
                    value = "DS_TIER";
                mp_sStyleIndex = value;
                mp_oStyle = mp_oControl.Styles.FItem(value);
            }
        }

        public clsStyle Style
        {
            get { return mp_oStyle; }
        }

        public E_TIERBACKGROUNDMODE BackgroundMode
        {
            get { return mp_yBackgroundMode; }
            set { mp_yBackgroundMode = value; }
        }

		
		public string GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, mp_sTierPosition);
			oXML.InitializeWriter();
			oXML.WriteProperty("yTierPosition", mp_yTierPosition);
			oXML.WriteProperty("sTierPosition", mp_sTierPosition);
			oXML.WriteProperty("Height", mp_lHeight);
			oXML.WriteProperty("Interval", mp_yInterval);
			oXML.WriteProperty("Factor", mp_lFactor);
			oXML.WriteProperty("Tag", mp_sTag);
			oXML.WriteProperty("TierType", mp_yTierType);
			oXML.WriteProperty("Visible", mp_bVisible);
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            oXML.WriteProperty("BackgroundMode", mp_yBackgroundMode);
			return oXML.GetXML();
		}

		
		public void SetXML(string sXML)
		{
			clsXML oXML = null;
			oXML = new clsXML(mp_oControl, mp_sTierPosition);
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("yTierPosition", ref mp_yTierPosition);
			oXML.ReadProperty("sTierPosition", ref mp_sTierPosition);
			oXML.ReadProperty("Height", ref mp_lHeight);
			oXML.ReadProperty("Interval", ref mp_yInterval);
			oXML.ReadProperty("Factor", ref mp_lFactor);
			oXML.ReadProperty("Tag", ref mp_sTag);
			oXML.ReadProperty("TierType", ref mp_yTierType);
			oXML.ReadProperty("Visible", ref mp_bVisible);
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            StyleIndex = mp_sStyleIndex;
            oXML.ReadProperty("BackgroundMode", ref mp_yBackgroundMode);
		}

        internal void Clear()
        {
            mp_lHeight = 14;
            mp_yInterval = E_INTERVAL.IL_WEEK;
            mp_lFactor = 1;
            mp_sTag = "";
            mp_oObjectTag = null;
            mp_yTierType = E_TIERTYPE.ST_DAYOFWEEK;
            mp_bVisible = true;
            mp_sStyleIndex = "DS_TIER";
            mp_oStyle = mp_oControl.Styles.FItem("DS_TIER");
            mp_yBackgroundMode = E_TIERBACKGROUNDMODE.ETBGM_TIERAPPEARANCE;
        }

        internal void Clone(clsTier oClone)
        {
            oClone.Height = mp_lHeight;
            oClone.Interval = mp_yInterval;
            oClone.Factor = mp_lFactor;
            oClone.Tag = mp_sTag;
            oClone.TierType = mp_yTierType;
            oClone.Visible = mp_bVisible;
            oClone.StyleIndex = mp_sStyleIndex;
            oClone.BackgroundMode = mp_yBackgroundMode;
        }

	}

}