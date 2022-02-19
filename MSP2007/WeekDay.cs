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

namespace MSP2007
{
	public class WeekDay : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private E_DAYTYPE mp_yDayType;
		private bool mp_bDayWorking;

		public WeekDay()
		{
			mp_yDayType = E_DAYTYPE.DT_EXCEPTION;
			mp_bDayWorking = false;
		}

		public E_DAYTYPE yDayType
		{
			get
			{
				return mp_yDayType;
			}
			set
			{
				mp_yDayType = value;
			}
		}

		public bool bDayWorking
		{
			get
			{
				return mp_bDayWorking;
			}
			set
			{
				mp_bDayWorking = value;
			}
		}
		public string Key
		{
			get { return mp_sKey; }
			set { mp_oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.MP_SET_KEY); }
		}

		public bool IsNull()
		{
			bool bReturn = true;
			if (mp_yDayType != E_DAYTYPE.DT_EXCEPTION)
			{
				bReturn = false;
			}
			if (mp_bDayWorking != false)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<WeekDay/>";
			}
			clsXML oXML = new clsXML("WeekDay");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			oXML.WriteProperty("DayType", mp_yDayType);
			oXML.WriteProperty("DayWorking", mp_bDayWorking);
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("WeekDay");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("DayType", ref mp_yDayType);
			oXML.ReadProperty("DayWorking", ref mp_bDayWorking);
		}


	}
}