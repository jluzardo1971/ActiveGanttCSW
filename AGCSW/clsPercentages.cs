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

namespace AGCSW
{
    public class clsPercentages : IEnumerable
	{
        private ActiveGanttCSWCtl mp_oControl;
		private clsCollectionBase mp_oCollection;

        public clsPercentages(ActiveGanttCSWCtl oControl)
		{
            mp_oControl = oControl;
			mp_oCollection = new clsCollectionBase(mp_oControl, "Percentage");			
		}

		~clsPercentages()
		{
		}

		public int Count 
		{
			get 
			{
				return mp_oCollection.m_lCount();
			}
		}

		public clsPercentage Item(String Index)
		{
			return (clsPercentage) mp_oCollection.m_oItem(Index, SYS_ERRORS.PERCENTAGES_ITEM_1, SYS_ERRORS.PERCENTAGES_ITEM_2, SYS_ERRORS.PERCENTAGES_ITEM_3, SYS_ERRORS.PERCENTAGES_ITEM_4);
		}

        public clsPercentage Item(int Index)
        {
            return (clsPercentage)mp_oCollection.m_oReturnArrayElement(Index);
        }

        internal clsCollectionBase oCollection 
		{
			get 
			{
				return mp_oCollection;
			}
		}

        public clsPercentage Add(String TaskKey, String StyleIndex, float Percent)
        {
            return Add(TaskKey, StyleIndex, Percent, "");
        }

		public clsPercentage Add(String TaskKey, String StyleIndex, float Percent, String Key)
		{
			mp_oCollection.AddMode = true;
            clsPercentage oPercentage = new clsPercentage(mp_oControl);
            Key = Globals.g_Trim(Key);
            TaskKey = Globals.g_Trim(TaskKey);
            oPercentage.Key = Key;
			oPercentage.TaskKey = TaskKey;
			oPercentage.Percent = Percent;
			oPercentage.StyleIndex = StyleIndex;
			mp_oCollection.m_Add(oPercentage, Key, SYS_ERRORS.PERCENTAGES_ADD_1, SYS_ERRORS.PERCENTAGES_ADD_2, false, SYS_ERRORS.PERCENTAGES_ADD_3);
			return oPercentage;
		}

		public void Clear()
		{
			mp_oCollection.m_Clear();
		}

		public void Remove(String Index)
		{
			mp_oCollection.m_Remove(Index, SYS_ERRORS.PERCENTAGES_REMOVE_1, SYS_ERRORS.PERCENTAGES_REMOVE_2, SYS_ERRORS.PERCENTAGES_REMOVE_3, SYS_ERRORS.PERCENTAGES_REMOVE_4);
		}

		internal void Draw()
		{
			int lIndex;
			clsPercentage oPercentage;
			clsTask oTask;
			clsRow oRow;
			clsStyle oStyle;
			bool bDraw;
			if (Count == 0)
			{
				return;
			}
			if (Count == 0)
			{
				return;
			}
			for (lIndex = 1;lIndex <= Count;lIndex++) 
			{
				oPercentage = (clsPercentage) mp_oCollection.m_oReturnArrayElement(lIndex);
				if (oPercentage.Visible == true)
				{
					mp_oControl.clsG.mp_ClipRegion(oPercentage.LeftTrim, oPercentage.Top, oPercentage.RightTrim, oPercentage.Bottom, true);
					oTask = (clsTask) mp_oControl.Tasks.oCollection.m_oReturnArrayElementKey(oPercentage.TaskKey);
					oRow = (clsRow) mp_oControl.Rows.oCollection.m_oReturnArrayElementKey(oTask.RowKey);
					oStyle = mp_oControl.Styles.FItem(oPercentage.StyleIndex);
					bDraw = false;
					//*mp_oControl.FireDraw(E_EVENTTARGET.EVT_PERCENTAGE, ref bDraw, lIndex, 0, mp_oControl.clsG.oGraphics);
					if (bDraw == false)
					{
                        mp_oControl.clsG.mp_DrawItem(oPercentage.Left, oPercentage.Top, oPercentage.Right, oPercentage.Bottom, oPercentage.StyleIndex, oPercentage.ToString(), false, null, oPercentage.LeftTrim, oPercentage.RightTrim, null);
					}
				}
			}
		}

		public String GetXML()
		{
			int lIndex;
			clsPercentage oPercentage;
			clsXML oXML = new clsXML(mp_oControl, "Percentages");
			oXML.InitializeWriter();
			for (lIndex = 1;lIndex <= Count;lIndex++) 
			{
				oPercentage = (clsPercentage) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oPercentage.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(String sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML(mp_oControl, "Percentages");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			mp_oCollection.m_Clear();
			for (lIndex = 1;lIndex <= oXML.ReadCollectionCount();lIndex++) 
			{
                clsPercentage oPercentage = new clsPercentage(mp_oControl);
				oPercentage.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				mp_oCollection.m_Add(oPercentage, oPercentage.Key, SYS_ERRORS.PERCENTAGES_ADD_1, SYS_ERRORS.PERCENTAGES_ADD_2, false, SYS_ERRORS.PERCENTAGES_ADD_3);
				oPercentage = null;
			}
		}

        public IEnumerator GetEnumerator()
        {
            return mp_oCollection.mp_aoCollection.GetEnumerator();
        }


	}
}