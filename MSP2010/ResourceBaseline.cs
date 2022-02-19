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

namespace MSP2010
{
	public class ResourceBaseline : clsItemBase
	{

		internal clsCollectionBase mp_oCollection;
		private int mp_lNumber;
		private Duration mp_oWork;
		private float mp_fCost;
		private float mp_fBCWS;
		private float mp_fBCWP;

		public ResourceBaseline()
		{
			mp_lNumber = 0;
			mp_oWork = new Duration();
			mp_fCost = 0;
			mp_fBCWS = 0;
			mp_fBCWP = 0;
		}

		public int lNumber
		{
			get
			{
				return mp_lNumber;
			}
			set
			{
				mp_lNumber = value;
			}
		}

		public Duration oWork
		{
			get
			{
				return mp_oWork;
			}
		}

		public float fCost
		{
			get
			{
				return mp_fCost;
			}
			set
			{
				mp_fCost = value;
			}
		}

		public float fBCWS
		{
			get
			{
				return mp_fBCWS;
			}
			set
			{
				mp_fBCWS = value;
			}
		}

		public float fBCWP
		{
			get
			{
				return mp_fBCWP;
			}
			set
			{
				mp_fBCWP = value;
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
			if (mp_lNumber != 0)
			{
				bReturn = false;
			}
			if (mp_oWork.IsNull() == false)
			{
				bReturn = false;
			}
			if (mp_fCost != 0)
			{
				bReturn = false;
			}
			if (mp_fBCWS != 0)
			{
				bReturn = false;
			}
			if (mp_fBCWP != 0)
			{
				bReturn = false;
			}
			return bReturn;
		}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<Baseline/>";
			}
			clsXML oXML = new clsXML("Baseline");
			oXML.InitializeWriter();
			oXML.SupportOptional = true;
			oXML.BoolsAreNumeric = true;
			oXML.WriteProperty("Number", mp_lNumber);
			oXML.WriteProperty("Work", mp_oWork);
			oXML.WriteProperty("Cost", mp_fCost);
			oXML.WriteProperty("BCWS", mp_fBCWS);
			oXML.WriteProperty("BCWP", mp_fBCWP);
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML("Baseline");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("Number", ref mp_lNumber);
			oXML.ReadProperty("Work", ref mp_oWork);
			oXML.ReadProperty("Cost", ref mp_fCost);
			oXML.ReadProperty("BCWS", ref mp_fBCWS);
			oXML.ReadProperty("BCWP", ref mp_fBCWP);
		}


	}
}