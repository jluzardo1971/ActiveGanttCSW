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
	public class clsTierAppearance
	{

        private ActiveGanttCSWCtl mp_oControl;
        public clsTierColors SecondColors;
		public clsTierColors MinuteColors;
		public clsTierColors HourColors;
		public clsTierColors DayColors;
		public clsTierColors DayOfWeekColors;
		public clsTierColors DayOfYearColors;
		public clsTierColors WeekColors;
		public clsTierColors MonthColors;
		public clsTierColors QuarterColors;
		public clsTierColors YearColors;

        internal clsTierAppearance(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            SecondColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_SECOND);
            MinuteColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_MINUTE);
            HourColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_HOUR);
            DayColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_DAY);
            DayOfWeekColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_DAYOFWEEK);
            DayOfYearColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_DAYOFYEAR);
            WeekColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_WEEK);
            MonthColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_MONTH);
            QuarterColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_QUARTER);
            YearColors = new clsTierColors(mp_oControl, E_TIERTYPE.ST_YEAR);
            Clear();
        }
    
		
		public string GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "TierAppearance");
			oXML.InitializeWriter();
			oXML.WriteObject(DayColors.GetXML());
			oXML.WriteObject(DayOfWeekColors.GetXML());
			oXML.WriteObject(DayOfYearColors.GetXML());
			oXML.WriteObject(HourColors.GetXML());
			oXML.WriteObject(MinuteColors.GetXML());
            oXML.WriteObject(SecondColors.GetXML());
			oXML.WriteObject(MonthColors.GetXML());
			oXML.WriteObject(QuarterColors.GetXML());
			oXML.WriteObject(WeekColors.GetXML());
			oXML.WriteObject(YearColors.GetXML());
			return oXML.GetXML();
		}
    
		
		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "TierAppearance");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			DayColors.SetXML(oXML.ReadObject("DayColors"));
			DayOfWeekColors.SetXML(oXML.ReadObject("DayOfWeekColors"));
			DayOfYearColors.SetXML(oXML.ReadObject("DayOfYearColors"));
			HourColors.SetXML(oXML.ReadObject("HourColors"));
			MinuteColors.SetXML(oXML.ReadObject("MinuteColors"));
            SecondColors.SetXML(oXML.ReadObject("SecondColors"));
			MonthColors.SetXML(oXML.ReadObject("MonthColors"));
			QuarterColors.SetXML(oXML.ReadObject("QuarterColors"));
			WeekColors.SetXML(oXML.ReadObject("WeekColors"));
			YearColors.SetXML(oXML.ReadObject("YearColors"));
		}

        public void Clear()
        {
            SecondColors.Clear();
            SecondColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            SecondColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            SecondColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            SecondColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            SecondColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            SecondColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            SecondColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            SecondColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            SecondColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            SecondColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            MinuteColors.Clear();
            MinuteColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            MinuteColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            MinuteColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            MinuteColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            MinuteColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            MinuteColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            MinuteColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            MinuteColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            MinuteColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            MinuteColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            HourColors.Clear();
            HourColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            HourColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            HourColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            HourColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            HourColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            HourColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            HourColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            HourColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            HourColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            HourColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            DayColors.Clear();
            DayColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            DayColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            DayColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            DayColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            DayColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            DayColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            DayColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            DayColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            DayColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            DayColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            DayOfWeekColors.Clear();
            DayOfWeekColors.Add(Color.FromArgb(255, 100, 149, 237), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 100, 149, 237), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 100, 149, 237), Color.FromArgb(255, 0, 0, 0), "Sunday");
            DayOfWeekColors.Add(Color.FromArgb(255, 123, 104, 238), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 123, 104, 238), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 123, 104, 238), Color.FromArgb(255, 0, 0, 0), "Monday");
            DayOfWeekColors.Add(Color.FromArgb(255, 106, 90, 205), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 106, 90, 205), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 106, 90, 205), Color.FromArgb(255, 0, 0, 0), "Tuesday");
            DayOfWeekColors.Add(Color.FromArgb(255, 65, 105, 225), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 65, 105, 225), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 65, 105, 225), Color.FromArgb(255, 0, 0, 0), "Wednesday");
            DayOfWeekColors.Add(Color.FromArgb(255, 70, 130, 180), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 70, 130, 180), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 70, 130, 180), Color.FromArgb(255, 0, 0, 0), "Thursday");
            DayOfWeekColors.Add(Color.FromArgb(255, 95, 158, 160), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 95, 158, 160), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 95, 158, 160), Color.FromArgb(255, 0, 0, 0), "Friday");
            DayOfWeekColors.Add(Color.FromArgb(255, 30, 144, 255), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 30, 144, 255), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 30, 144, 255), Color.FromArgb(255, 0, 0, 0), "Saturday");
            DayOfYearColors.Clear();
            DayOfYearColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            DayOfYearColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            DayOfYearColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            DayOfYearColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            DayOfYearColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            DayOfYearColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            DayOfYearColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            DayOfYearColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            DayOfYearColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            DayOfYearColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            WeekColors.Clear();
            WeekColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            WeekColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            WeekColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            WeekColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            WeekColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            WeekColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            WeekColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            WeekColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            WeekColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            WeekColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            MonthColors.Clear();
            MonthColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), "January");
            MonthColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), "February");
            MonthColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), "March");
            MonthColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), "April");
            MonthColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), "May");
            MonthColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), "June");
            MonthColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), "July");
            MonthColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), "August");
            MonthColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), "September");
            MonthColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), "October");
            MonthColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), "November");
            MonthColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), "December");
            QuarterColors.Clear();
            QuarterColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            QuarterColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            QuarterColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            QuarterColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            YearColors.Clear();
            YearColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            YearColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            YearColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            YearColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            YearColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            YearColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
            YearColors.Add(Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 0, 0, 0));
            YearColors.Add(Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 192, 192, 192), Color.FromArgb(255, 0, 0, 0));
            YearColors.Add(Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 0, 0, 0));
            YearColors.Add(Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 0, 0, 0));
        }

        internal void Clone(clsTierAppearance oClone)
        {
            SecondColors.Clone(oClone.SecondColors);
            MinuteColors.Clone(oClone.MinuteColors);
            HourColors.Clone(oClone.HourColors);
            DayColors.Clone(oClone.DayColors);
            DayOfWeekColors.Clone(oClone.DayOfWeekColors);
            DayOfYearColors.Clone(oClone.DayOfYearColors);
            WeekColors.Clone(oClone.WeekColors);
            MonthColors.Clone(oClone.MonthColors);
            QuarterColors.Clone(oClone.QuarterColors);
            YearColors.Clone(oClone.YearColors);
        }
    
	}
}