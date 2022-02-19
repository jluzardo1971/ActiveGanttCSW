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
using System.Collections;

namespace MSP2010
{
	public class TaskBaseline_C : IEnumerable
	{

		private clsCollectionBase mp_oCollection;

		public TaskBaseline_C()
		{
			mp_oCollection = new clsCollectionBase("TaskBaseline");
		}

		public int Count
		{
			get
			{
				return mp_oCollection.m_lCount();
			}
		}

		public TaskBaseline Item(string Index)
		{
			return (TaskBaseline) mp_oCollection.m_oItem(Index, SYS_ERRORS.MP_ITEM_1, SYS_ERRORS.MP_ITEM_2, SYS_ERRORS.MP_ITEM_3, SYS_ERRORS.MP_ITEM_4);
		}

		public TaskBaseline Add()
		{
			mp_oCollection.AddMode = true;
			TaskBaseline oTaskBaseline = new TaskBaseline();
			oTaskBaseline.mp_oCollection = mp_oCollection;
			mp_oCollection.m_Add(oTaskBaseline, "", SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
			return oTaskBaseline;
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
					TaskBaseline oTaskBaseline = new TaskBaseline();
					oTaskBaseline.SetXML(oXML.ReadCollectionObject(lIndex));
					mp_oCollection.AddMode = true;
					string sKey = "";
					oTaskBaseline.mp_oCollection = mp_oCollection;
					mp_oCollection.m_Add(oTaskBaseline, sKey, SYS_ERRORS.MP_ADD_1, SYS_ERRORS.MP_ADD_2, false, SYS_ERRORS.MP_ADD_3);
					oTaskBaseline = null;
				}
			}
		}

		internal void WriteObjectProtected(ref clsXML oXML)
		{
			int lIndex;
			TaskBaseline oTaskBaseline;
			for (lIndex = 1; lIndex <= Count; lIndex++)
			{
				oTaskBaseline = (TaskBaseline) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oTaskBaseline.GetXML());
			}
		}

		public IEnumerator GetEnumerator()
		{
			return mp_oCollection.mp_aoCollection.GetEnumerator();
		}

	}
}