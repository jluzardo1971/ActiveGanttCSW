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
using System.Collections;

namespace MSP2010
{
	public class OutlineCodes : IEnumerable
	{

		private clsCollectionBase mp_oCollection;

		public OutlineCodes()
		{
			mp_oCollection = new clsCollectionBase("OutlineCode");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public OutlineCode Item(string Index)
		{
			return (OutlineCode) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public OutlineCode Add()
		{
			mp_oCollection.AddMode = true;
			OutlineCode oOutlineCode = new OutlineCode();
			oOutlineCode.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oOutlineCode, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oOutlineCode;
		}

		public void Clear()
		{
			mp_oCollection.m_Clear();
		}

		public void Remove(string Index)
		{
			mp_oCollection.m_Remove(Index, SYS_ERRORS.MP_REMOVE_1, SYS_ERRORS.MP_REMOVE_2, SYS_ERRORS.MP_REMOVE_3, SYS_ERRORS.MP_REMOVE_4);
		}

	public bool IsNull()
	{
		bool bReturn = true;
		if (Count > 0)
		{
			bReturn = false;
		}
		return bReturn;
	}

		public string GetXML()
		{
			if (IsNull() == true)
			{
				return "<OutlineCodes/>";
			}
			int lIndex;
			OutlineCode oOutlineCode;
			clsXML oXML = new clsXML("OutlineCodes");
			oXML.BoolsAreNumeric = true;
			oXML.InitializeWriter();
				for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oOutlineCode = (OutlineCode) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oOutlineCode.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(string sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML("OutlineCodes");
			oXML.SupportOptional = true;
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			mp_oCollection.m_Clear();
			if (oXML.ReadCollectionCount() == 0)
			{
				return;
			}
			for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++)
			{
				OutlineCode oOutlineCode = new OutlineCode();
				oOutlineCode.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				string sKey = "";
				oOutlineCode.mp_oCollection = mp_oCollection;
				mp_oCollection.m_Add(oOutlineCode, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
				oOutlineCode = null;
			}
		}

		public IEnumerator GetEnumerator()
		{
			return mp_oCollection.mp_aoCollection.GetEnumerator();
		}

	}
}