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
    public class clsTasks : IEnumerable
	{

        private ActiveGanttCSWCtl mp_oControl;
		private clsCollectionBase mp_oCollection;

        internal clsTasks(ActiveGanttCSWCtl oControl)
		{
            mp_oControl = oControl;
			mp_oCollection = new clsCollectionBase(mp_oControl, "Task");
		}

		public int Count 
		{
			get { return mp_oCollection.m_lCount(); }
		}

		public clsTask Item(string Index)
		{
			return (clsTask) mp_oCollection.m_oItem(Index, SYS_ERRORS.TASKS_ITEM_1, SYS_ERRORS.TASKS_ITEM_2, SYS_ERRORS.TASKS_ITEM_3, SYS_ERRORS.TASKS_ITEM_4);
		}

        public clsTask Item(int Index)
        {
            return (clsTask)mp_oCollection.m_oReturnArrayElement(Index);
        }

        internal clsCollectionBase oCollection 
		{
			get { return mp_oCollection; }
		}

        public clsTask Add(string Text, string RowKey, DateTime StartDate, DateTime EndDate)
        {
            return Add(Text, RowKey, StartDate, EndDate, "", "", "0");
        }

        public clsTask Add(string Text, string RowKey, DateTime StartDate, DateTime EndDate, string Key)
        {
            return Add(Text, RowKey, StartDate, EndDate, Key, "", "0");
        }

        public clsTask Add(string Text, string RowKey, DateTime StartDate, DateTime EndDate, string Key, string StyleIndex)
        {
            return Add(Text, RowKey, StartDate, EndDate, Key, StyleIndex, "0");
        }

		public clsTask Add(string Text, string RowKey, DateTime StartDate, DateTime EndDate, string Key, string StyleIndex,	string LayerIndex)
		{
			mp_oCollection.AddMode = true;
            clsTask oTask = new clsTask(mp_oControl);
			Key = Globals.g_Trim(Key);
			Text = Globals.g_Trim(Text);
			RowKey = Globals.g_Trim(RowKey);
			oTask.Text = Text;
			oTask.RowKey = RowKey;
			oTask.StartDate = StartDate;
			oTask.EndDate = EndDate;
			oTask.Key = Key;
			oTask.StyleIndex = StyleIndex;
			oTask.LayerIndex = LayerIndex;
			mp_oCollection.m_Add(oTask, Key, SYS_ERRORS.TASKS_ADD_1, SYS_ERRORS.TASKS_ADD_2, false, SYS_ERRORS.TASKS_ADD_3);
			return oTask;
		}

        public clsTask DAdd(string RowKey, DateTime StartDate, E_INTERVAL DurationInterval, int DurationFactor)
        {
            return DAdd(RowKey, StartDate, DurationInterval, DurationFactor, "", "", "", "0");
        }

        public clsTask DAdd(string RowKey, DateTime StartDate, E_INTERVAL DurationInterval, int DurationFactor, string Text)
        {
            return DAdd(RowKey, StartDate, DurationInterval, DurationFactor, Text, "", "", "0");
        }

        public clsTask DAdd(string RowKey, DateTime StartDate, E_INTERVAL DurationInterval, int DurationFactor, string Text, string Key)
        {
            return DAdd(RowKey, StartDate, DurationInterval, DurationFactor, Text, Key, "", "0");
        }

        public clsTask DAdd(string RowKey, DateTime StartDate, E_INTERVAL DurationInterval, int DurationFactor, string Text, string Key, string StyleIndex)
        {
            return DAdd(RowKey, StartDate, DurationInterval, DurationFactor, Text, Key, StyleIndex, "0");
        }

        public clsTask DAdd(string RowKey, DateTime StartDate, E_INTERVAL DurationInterval, int DurationFactor, string Text, string Key, string StyleIndex, string LayerIndex)
        {
            mp_oCollection.AddMode = true;
            clsTask oTask = new clsTask(mp_oControl);
            oTask.TaskType = E_TASKTYPE.TT_DURATION;
            Key = Globals.g_Trim(Key);
            Text = Globals.g_Trim(Text);
            RowKey = Globals.g_Trim(RowKey);
            oTask.Text = Text;
            oTask.RowKey = RowKey;
            oTask.StartDate = StartDate;
            oTask.DurationInterval = DurationInterval;
            oTask.DurationFactor = DurationFactor;
            oTask.Key = Key;
            oTask.StyleIndex = StyleIndex;
            oTask.LayerIndex = LayerIndex;
            mp_oCollection.m_Add(oTask, Key, SYS_ERRORS.TASKS_ADD_1, SYS_ERRORS.TASKS_ADD_2, false, SYS_ERRORS.TASKS_ADD_3);
            return oTask;
        }

		public void Clear()
		{
            mp_oControl.Predecessors.Clear();
			mp_oControl.Percentages.Clear();
			mp_oCollection.m_Clear();
			mp_oControl.SelectedTaskIndex = 0;
		}

		public void Remove(string Index)
		{
			int lIndex = 0;
			string sRIndex = "";
			string sRKey = "";
            clsPredecessor oPredecessor = null;
			mp_oCollection.m_GetKeyAndIndex(Index, ref sRKey, ref sRIndex);
			mp_oControl.Percentages.oCollection.m_CollectionRemoveWhere("TaskKey", sRKey, sRIndex);
            if (sRKey.Length > 0)
            {
                for (lIndex = mp_oControl.Predecessors.Count; lIndex >= 1; lIndex--)
                {
                    oPredecessor = (clsPredecessor)mp_oControl.Predecessors.oCollection.m_oReturnArrayElement(lIndex);
                    if (oPredecessor.SuccessorKey == sRKey | oPredecessor.PredecessorKey == sRKey)
                    {
                        mp_oControl.Predecessors.Remove(lIndex.ToString());
                    }
                }
            }
			mp_oCollection.m_Remove(Index, SYS_ERRORS.TASKS_REMOVE_1, SYS_ERRORS.TASKS_REMOVE_2, SYS_ERRORS.TASKS_REMOVE_3, SYS_ERRORS.TASKS_REMOVE_4);
			mp_oControl.SelectedTaskIndex = 0;
		}

		public void Sort(string PropertyName, bool Descending, E_SORTTYPE SortType, int StartIndex, int EndIndex)
		{
			if (StartIndex == -1) 
			{
				StartIndex = 1;
			}
			if (EndIndex == -1) 
			{
				EndIndex = Count;
			}
			if (Count == 0) return; 
			if (StartIndex < 1 | StartIndex > Count) 
			{
				return;
			}
			if (EndIndex < 1 | EndIndex > Count) 
			{
				return;
			}
			if (EndIndex == StartIndex) 
			{
				return;
			}
			mp_oCollection.m_Sort(PropertyName, Descending, SortType, StartIndex, EndIndex);
		}

		internal void Draw()
		{
			int lIndex = 0;
			clsTask oTask = null;
			if (Count == 0) 
			{
				return;
			}
			for (lIndex = 1; lIndex <= Count; lIndex++) 
			{
				oTask = (clsTask) mp_oCollection.m_oReturnArrayElement(lIndex);
                if (oTask.Visible == true & oTask.InsideVisibleTimeLineArea == true) 
				{
					mp_oControl.DrawEventArgs.Clear();
					mp_oControl.DrawEventArgs.CustomDraw = false;
					mp_oControl.DrawEventArgs.EventTarget = E_EVENTTARGET.EVT_TASK;
					mp_oControl.DrawEventArgs.ObjectIndex = lIndex;
					mp_oControl.DrawEventArgs.ParentObjectIndex = 0;
					mp_oControl.DrawEventArgs.Graphics = mp_oControl.clsG.oGraphics;
					mp_oControl.FireDraw();
					if (mp_oControl.DrawEventArgs.CustomDraw == false) 
					{
						if (oTask.Type == E_OBJECTTYPE.OT_MILESTONE) 
						{
                            mp_oControl.clsG.mp_DrawItemM(oTask, "", lIndex == mp_oControl.SelectedTaskIndex, mp_GetTaskStyle(oTask));
						}
						else 
						{
                            mp_oControl.clsG.mp_DrawItem(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom, "", oTask.Text, (lIndex == mp_oControl.SelectedTaskIndex), oTask.Image, oTask.LeftTrim, oTask.RightTrim, mp_GetTaskStyle(oTask));
						}
                        if (oTask.Text.Length > 0)
                        {
                            oTask.mp_lTextLeft = mp_oControl.clsG.mp_oTextFinalLayout.Left;
                            oTask.mp_lTextTop = mp_oControl.clsG.mp_oTextFinalLayout.Top;
                            oTask.mp_lTextRight = mp_oControl.clsG.mp_oTextFinalLayout.Left + mp_oControl.clsG.mp_oTextFinalLayout.Width - 1;
                            oTask.mp_lTextBottom = mp_oControl.clsG.mp_oTextFinalLayout.Top + mp_oControl.clsG.mp_oTextFinalLayout.Height - 1;
                        }
                        else
                        {
                            if (oTask.Style.TextPlacement == E_TEXTPLACEMENT.SCP_EXTERIORPLACEMENT)
                            {
                                if (oTask.Style.TextAlignmentHorizontal == GRE_HORIZONTALALIGNMENT.HAL_LEFT)
                                {
                                    oTask.mp_lTextLeft = oTask.Left - mp_oControl.clsG.mp_lStrWidth("WWWWW", oTask.Style.Font) - oTask.Style.TextXMargin;
                                    oTask.mp_lTextRight = oTask.Left - oTask.Style.TextXMargin + 1;
                                }
                                if (oTask.Style.TextAlignmentHorizontal == GRE_HORIZONTALALIGNMENT.HAL_RIGHT)
                                {
                                    oTask.mp_lTextLeft = oTask.Right + oTask.Style.TextXMargin;
                                    oTask.mp_lTextRight = oTask.Right + mp_oControl.clsG.mp_lStrWidth("WWWWW", oTask.Style.Font) + oTask.Style.TextXMargin + 1;
                                }
                                if (oTask.Style.TextAlignmentHorizontal == GRE_HORIZONTALALIGNMENT.HAL_CENTER)
                                {
                                    oTask.mp_lTextLeft = oTask.Left;
                                    oTask.mp_lTextRight = oTask.Right + 1;
                                }
                                if (oTask.Style.TextAlignmentVertical == GRE_VERTICALALIGNMENT.VAL_TOP)
                                {
                                    oTask.mp_lTextTop = oTask.Top - mp_oControl.clsG.mp_lStrHeight("WWWWW", oTask.Style.Font) - oTask.Style.TextYMargin;
                                    oTask.mp_lTextBottom = oTask.Top - oTask.Style.TextYMargin + 3;
                                }
                                if (oTask.Style.TextAlignmentVertical == GRE_VERTICALALIGNMENT.VAL_BOTTOM)
                                {
                                    oTask.mp_lTextTop = oTask.Bottom + oTask.Style.TextYMargin;
                                    oTask.mp_lTextBottom = oTask.Bottom + mp_oControl.clsG.mp_lStrHeight("WWWWW", oTask.Style.Font) + oTask.Style.TextYMargin + 3;
                                }
                                if (oTask.Style.TextAlignmentVertical == GRE_VERTICALALIGNMENT.VAL_CENTER)
                                {
                                    oTask.mp_lTextTop = oTask.Top;
                                    oTask.mp_lTextBottom = oTask.Bottom + 3;
                                }
                            }
                            else
                            {
                                oTask.mp_lTextLeft = oTask.Left;
                                oTask.mp_lTextTop = oTask.Top;
                                oTask.mp_lTextRight = oTask.Right;
                                oTask.mp_lTextBottom = oTask.Bottom;
                            }

                        }
					}
				}
			}
		}

        private clsStyle mp_GetTaskStyle(clsTask oTask)
        {
            clsStyle oStyle;
            if (oTask.mp_bWarning == true)
            {
                oStyle = oTask.WarningStyle;
            }
            else
            {
                oStyle = oTask.Style;
            }
            return oStyle;
        }

		public string GetXML()
		{
			int lIndex = 0;
			clsTask oTask = null;
			clsXML oXML = new clsXML(mp_oControl, "Tasks");
			oXML.InitializeWriter();
			for (lIndex = 1; lIndex <= Count; lIndex++) 
			{
				oTask = (clsTask) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oTask.GetXML());
			}
			return oXML.GetXML();
		}
		
		public void SetXML(string sXML)
		{
			int lIndex = 0;
			clsXML oXML = new clsXML(mp_oControl, "Tasks");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			mp_oCollection.m_Clear();
			for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++) 
			{
                clsTask oTask = new clsTask(mp_oControl);
				oTask.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				mp_oCollection.m_Add(oTask, oTask.Key, SYS_ERRORS.TASKS_ADD_1, SYS_ERRORS.TASKS_ADD_2, false, SYS_ERRORS.TASKS_ADD_3);
				oTask = null;
			}
		}

        public IEnumerator GetEnumerator()
        {
            return mp_oCollection.mp_aoCollection.GetEnumerator();
        }


	}

}