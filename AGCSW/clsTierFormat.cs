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
	public class clsTierFormat
	{
        private ActiveGanttCSWCtl mp_oControl;
        private String mp_sSecondIntervalFormat;
		private String mp_sMinuteIntervalFormat;
		private String mp_sHourIntervalFormat;
		private String mp_sDayIntervalFormat;
		private String mp_sDayOfWeekIntervalFormat;
		private String mp_sDayOfYearIntervalFormat;
		private String mp_sWeekIntervalFormat;
		private String mp_sMonthIntervalFormat;
		private String mp_sQuarterIntervalFormat;
		private String mp_sYearIntervalFormat;

        internal clsTierFormat(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            Clear();
        }

		~clsTierFormat()
		{
			
		}

        public String SecondIntervalFormat
        {
            get
            {
                return mp_sSecondIntervalFormat;
            }
            set
            {
                mp_sSecondIntervalFormat = value;
            }
        }

		public String MinuteIntervalFormat 
		{
			get 
			{
				return mp_sMinuteIntervalFormat;
			}
			set 
			{
				mp_sMinuteIntervalFormat = value;
			}
		}

		public String HourIntervalFormat 
		{
			get 
			{
				return mp_sHourIntervalFormat;
			}
			set 
			{
				mp_sHourIntervalFormat = value;
			}
		}

		public String DayIntervalFormat 
		{
			get 
			{
				return mp_sDayIntervalFormat;
			}
			set 
			{
				mp_sDayIntervalFormat = value;
			}
		}

		public String DayOfWeekIntervalFormat 
		{
			get 
			{
				return mp_sDayOfWeekIntervalFormat;
			}
			set 
			{
				mp_sDayOfWeekIntervalFormat = value;
			}
		}

		public String DayOfYearIntervalFormat 
		{
			get 
			{
				return mp_sDayOfYearIntervalFormat;
			}
			set 
			{
				mp_sDayOfYearIntervalFormat = value;
			}
		}

		public String WeekIntervalFormat 
		{
			get 
			{
				return mp_sWeekIntervalFormat;
			}
			set 
			{
				mp_sWeekIntervalFormat = value;
			}
		}

		public String MonthIntervalFormat 
		{
			get 
			{
				return mp_sMonthIntervalFormat;
			}
			set 
			{
				mp_sMonthIntervalFormat = value;
			}
		}

		public String QuarterIntervalFormat 
		{
			get 
			{
				return mp_sQuarterIntervalFormat;
			}
			set 
			{
				mp_sQuarterIntervalFormat = value;
			}
		}

		public String YearIntervalFormat 
		{
			get 
			{
				return mp_sYearIntervalFormat;
			}
			set 
			{
				mp_sYearIntervalFormat = value;
			}
		}

		public String GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "TierFormat");
			oXML.InitializeWriter();
			oXML.WriteProperty("DayIntervalFormat", mp_sDayIntervalFormat);
			oXML.WriteProperty("DayOfWeekIntervalFormat", mp_sDayOfWeekIntervalFormat);
			oXML.WriteProperty("DayOfYearIntervalFormat", mp_sDayOfYearIntervalFormat);
			oXML.WriteProperty("HourIntervalFormat", mp_sHourIntervalFormat);
			oXML.WriteProperty("MinuteIntervalFormat", mp_sMinuteIntervalFormat);
            oXML.WriteProperty("SecondIntervalFormat", mp_sSecondIntervalFormat);
			oXML.WriteProperty("MonthIntervalFormat", mp_sMonthIntervalFormat);
			oXML.WriteProperty("QuarterIntervalFormat", mp_sQuarterIntervalFormat);
			oXML.WriteProperty("WeekIntervalFormat", mp_sWeekIntervalFormat);
			oXML.WriteProperty("YearIntervalFormat", mp_sYearIntervalFormat);
			return oXML.GetXML();
		}

		public void SetXML(String sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "TierFormat");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("DayIntervalFormat", ref mp_sDayIntervalFormat);
			oXML.ReadProperty("DayOfWeekIntervalFormat", ref mp_sDayOfWeekIntervalFormat);
			oXML.ReadProperty("DayOfYearIntervalFormat", ref mp_sDayOfYearIntervalFormat);
			oXML.ReadProperty("HourIntervalFormat", ref mp_sHourIntervalFormat);
			oXML.ReadProperty("MinuteIntervalFormat", ref mp_sMinuteIntervalFormat);
            oXML.ReadProperty("SecondIntervalFormat", ref mp_sSecondIntervalFormat);
			oXML.ReadProperty("MonthIntervalFormat", ref mp_sMonthIntervalFormat);
			oXML.ReadProperty("QuarterIntervalFormat", ref mp_sQuarterIntervalFormat);
			oXML.ReadProperty("WeekIntervalFormat", ref mp_sWeekIntervalFormat);
			oXML.ReadProperty("YearIntervalFormat", ref mp_sYearIntervalFormat);
		}

        public void Clear()
        {
            mp_sSecondIntervalFormat = "ss";
            mp_sMinuteIntervalFormat = "mm";
            mp_sHourIntervalFormat = "HH:mm";
            mp_sDayIntervalFormat = "d";
            mp_sDayOfWeekIntervalFormat = "dddd d";
            mp_sDayOfYearIntervalFormat = "y";
            mp_sWeekIntervalFormat = "ww";
            mp_sMonthIntervalFormat = "MMMM yyyy";
            mp_sQuarterIntervalFormat = "MMMM yyyy";
            mp_sYearIntervalFormat = "yyyy";
        }

        internal void Clone(clsTierFormat oClone)
        {
            oClone.SecondIntervalFormat = mp_sSecondIntervalFormat;
            oClone.MinuteIntervalFormat = mp_sMinuteIntervalFormat;
            oClone.HourIntervalFormat = mp_sHourIntervalFormat;
            oClone.DayIntervalFormat = mp_sDayIntervalFormat;
            oClone.DayOfWeekIntervalFormat = mp_sDayOfWeekIntervalFormat;
            oClone.DayOfYearIntervalFormat = mp_sDayOfYearIntervalFormat;
            oClone.WeekIntervalFormat = mp_sWeekIntervalFormat;
            oClone.MonthIntervalFormat = mp_sMonthIntervalFormat;
            oClone.QuarterIntervalFormat = mp_sQuarterIntervalFormat;
            oClone.YearIntervalFormat = mp_sYearIntervalFormat;
        }




	}
}