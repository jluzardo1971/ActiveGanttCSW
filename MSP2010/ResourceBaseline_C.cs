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
	public class ResourceBaseline_C : IEnumerable
	{

		private clsCollectionBase mp_oCollection;

		public ResourceBaseline_C()
		{
			mp_oCollection = new clsCollectionBase("ResourceBaseline");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public ResourceBaseline Item(string Index)
		{
			return (ResourceBaseline) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public ResourceBaseline Add()
		{
			mp_oCollection.AddMode = true;
			ResourceBaseline oResourceBaseline = new ResourceBaseline();
			oResourceBaseline.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oResourceBaseline, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oResourceBaseline;
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

		internal void ReadObjectProtected(ref clsXML oXML)
		{
			int lIndex;
			for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++)
			{
				if (oXML.GetCollectionObjectName(lIndex) == "Baseline")
				{
					ResourceBaseline oResourceBaseline = new ResourceBaseline();
					oResourceBaseline.SetXML(oXML.ReadCollectionObject(lIndex));
					mp_oCollection.AddMode = true;
					string sKey = "";
					oResourceBaseline.mp_oCollection = mp_oCollection;
					mp_oCollection.m_Add(oResourceBaseline, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
					oResourceBaseline = null;
				}
			}
		}

		internal void WriteObjectProtected(ref clsXML oXML)
		{
			int lIndex;
			ResourceBaseline oResourceBaseline;
			for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oResourceBaseline = (ResourceBaseline) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oResourceBaseline.GetXML());
			}
		}

		public IEnumerator GetEnumerator()
		{
			return mp_oCollection.mp_aoCollection.GetEnumerator();
		}

	}
}