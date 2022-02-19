﻿// ----------------------------------------------------------------------------------------
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
	public class AssignmentExtendedAttribute : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private string mp_sFieldID;
		private string mp_sValue;
		private int mp_lValueGUID;
		private E_DURATIONFORMAT mp_yDurationFormat;

		public AssignmentExtendedAttribute()
		{
			mp_sFieldID = "";
			mp_sValue = "";
			mp_lValueGUID = 0;
			mp_yDurationFormat = E_DURATIONFORMAT.DF_M;
		}

		public string sFieldID
		{
			get
			{
				return mp_sFieldID;
			}
			set
			{
				mp_sFieldID = value;
			}
		}

		public string sValue
		{
			get
			{
				return mp_sValue;
			}
			set
			{
				mp_sValue = value;
			}
		}

		public int lValueGUID
		{
			get
			{
				return mp_lValueGUID;
			}
			set
			{
				mp_lValueGUID = value;
			}
		}

		public E_DURATIONFORMAT yDurationFormat
		{
			get
			{
				return mp_yDurationFormat;
			}
			set
			{
				mp_yDurationFormat = value;
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
			if (mp_sFieldID != "")
			{
				bReturn = false;
			}
			if (mp_sValue != "")
			{
				bReturn = false;
			}
			if (mp_lValueGUID != 0)
			{
				bReturn = false;
			}
			if (mp_yDurationFormat != E_DURATIONFORMAT.DF_M)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<ExtendedAttribute/>";
			}
			clsXML oXML = new clsXML("ExtendedAttribute");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			if (mp_sFieldID != "")
			{
				oXML.WriteProperty("FieldID", mp_sFieldID);
			}
			if (mp_sValue != "")
			{
				oXML.WriteProperty("Value", mp_sValue);
			}
			oXML.WriteProperty("ValueGUID", mp_lValueGUID);
			oXML.WriteProperty("DurationFormat", mp_yDurationFormat);
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("ExtendedAttribute");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("FieldID", ref mp_sFieldID);
			oXML.ReadProperty("Value", ref mp_sValue);
			oXML.ReadProperty("ValueGUID", ref mp_lValueGUID);
			oXML.ReadProperty("DurationFormat", ref mp_yDurationFormat);
		}


	}
}