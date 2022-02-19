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
    public class clsTimeBlocks : IEnumerable
	{

        private ActiveGanttCSWCtl mp_oControl;
		private clsCollectionBase mp_oCollection;
        internal ArrayList mp_aTimeBlocks;
        private DateTime mp_dtIntervalStart;
        private DateTime mp_dtIntervalEnd;
        private E_TBINTERVALTYPE mp_yIntervalType;

        internal clsTimeBlocks(ActiveGanttCSWCtl oControl)
		{
            mp_oControl = oControl;
			mp_oCollection = new clsCollectionBase(mp_oControl, "TimeBlock");
            mp_dtIntervalStart = new DateTime();
            mp_dtIntervalEnd = new DateTime();
            mp_yIntervalType = E_TBINTERVALTYPE.TBIT_AUTOMATIC;
		}
    
		
		public int Count 
		{
			get { return mp_oCollection.m_lCount(); }
		}
    
		
		public clsTimeBlock Item(string Index)
		{
			return (clsTimeBlock)mp_oCollection.m_oItem(Index, SYS_ERRORS.TIMEBLOCKS_ITEM_1, SYS_ERRORS.TIMEBLOCKS_ITEM_2, SYS_ERRORS.TIMEBLOCKS_ITEM_3, SYS_ERRORS.TIMEBLOCKS_ITEM_4);
		}

        public clsTimeBlock Item(int Index)
        {
            return (clsTimeBlock)mp_oCollection.m_oReturnArrayElement(Index);
        }

        internal clsCollectionBase oCollection 
		{
			get { return mp_oCollection; }
		}
    
		public clsTimeBlock Add(string Key)
		{
			mp_oCollection.AddMode = true;
            clsTimeBlock oTimeBlock = new clsTimeBlock(mp_oControl);
			Key = Globals.g_Trim(Key);
			oTimeBlock.Key = Key;
			mp_oCollection.m_Add(oTimeBlock, Key, SYS_ERRORS.TIMEBLOCKS_ADD_1, SYS_ERRORS.TIMEBLOCKS_ADD_2, false, SYS_ERRORS.TIMEBLOCKS_ADD_3);
			return oTimeBlock;
		}
    
		
		public void Clear()
		{
			mp_oCollection.m_Clear();
		}
    
		
		public void Remove(string Index)
		{
			mp_oCollection.m_Remove(Index, SYS_ERRORS.TIMEBLOCKS_REMOVE_1, SYS_ERRORS.TIMEBLOCKS_REMOVE_2, SYS_ERRORS.TIMEBLOCKS_REMOVE_3, SYS_ERRORS.TIMEBLOCKS_REMOVE_4);
		}

        internal void CreateTemporaryTimeBlocks()
        {
            int lIndex = 0;
            mp_oControl.TempTimeBlocks().Clear();

            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                clsTimeBlock oTimeBlock = null;
                clsTimeBlock oTempTimeBlock = null;
                DateTime dtTimeLineStart = new DateTime();
                DateTime dtTimeLineEnd = new DateTime();
                DateTime dtCurrent = new DateTime();
                DateTime dtStartBuff = new DateTime();
                DateTime dtEndBuff = new DateTime();
                DateTime dtBase;
                DateTime dtStartDate = new DateTime();
                DateTime dtEndDate = new DateTime();
                oTimeBlock = (clsTimeBlock)mp_oCollection.m_oReturnArrayElement(lIndex);
                if (oTimeBlock.TimeBlockType == E_TIMEBLOCKTYPE.TBT_RECURRING)
                {
                    dtTimeLineStart = mp_oControl.CurrentViewObject.TimeLine.StartDate;
                    dtTimeLineEnd = mp_oControl.CurrentViewObject.TimeLine.EndDate;
                    switch (oTimeBlock.RecurringType)
                    {
                        case E_RECURRINGTYPE.RCT_DAY:
                            dtTimeLineStart = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, -1, dtTimeLineStart);
                            dtCurrent = new DateTime(dtTimeLineStart.Year, dtTimeLineStart.Month, dtTimeLineStart.Day, 0, 0, 0);
                            while (dtCurrent < dtTimeLineEnd)
                            {
                                dtBase = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day, oTimeBlock.BaseDate.Hour, oTimeBlock.BaseDate.Minute, oTimeBlock.BaseDate.Second);
                                dtCurrent = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                if (mp_oControl.MathLib.mp_DateBlockVisible(dtTimeLineStart, dtTimeLineEnd, dtBase, oTimeBlock.DurationInterval, oTimeBlock.DurationFactor))
                                {
                                    oTempTimeBlock = mp_oControl.TempTimeBlocks().Add("");
                                    oTempTimeBlock.BaseDate = dtBase;
                                    oTempTimeBlock.DurationInterval = oTimeBlock.DurationInterval;
                                    oTempTimeBlock.DurationFactor = oTimeBlock.DurationFactor;
                                    CopyTimeBlock(oTempTimeBlock, oTimeBlock);
                                }
                            }
                            break;
                        case E_RECURRINGTYPE.RCT_WEEK:
                            dtTimeLineStart = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, -7, dtTimeLineStart);
                            dtCurrent = new DateTime(dtTimeLineStart.Year, dtTimeLineStart.Month, dtTimeLineStart.Day, 0, 0, 0);
                            while (dtCurrent < dtTimeLineEnd)
                            {
                                dtBase = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day, oTimeBlock.BaseDate.Hour, oTimeBlock.BaseDate.Minute, oTimeBlock.BaseDate.Second);
                                dtCurrent = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                if (System.Convert.ToInt32(oTimeBlock.BaseWeekDay) == System.Convert.ToInt32(dtBase.DayOfWeek))
                                {
                                    if (mp_oControl.MathLib.mp_DateBlockVisible(dtTimeLineStart, dtTimeLineEnd, dtBase, oTimeBlock.DurationInterval, oTimeBlock.DurationFactor))
                                    {
                                        oTempTimeBlock = mp_oControl.TempTimeBlocks().Add("");
                                        oTempTimeBlock.BaseDate = dtBase;
                                        oTempTimeBlock.DurationInterval = oTimeBlock.DurationInterval;
                                        oTempTimeBlock.DurationFactor = oTimeBlock.DurationFactor;
                                        CopyTimeBlock(oTempTimeBlock, oTimeBlock);
                                    }
                                }
                            }
                            break;
                        case E_RECURRINGTYPE.RCT_MONTH:
                            dtTimeLineStart = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_MONTH, -1, dtTimeLineStart);
                            dtCurrent = new DateTime(dtTimeLineStart.Year, dtTimeLineStart.Month, dtTimeLineStart.Day, 0, 0, 0);
                            while (dtCurrent < dtTimeLineEnd)
                            {
                                if (oTimeBlock.BaseDate.Day == dtCurrent.Day)
                                {
                                    dtBase = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day, oTimeBlock.BaseDate.Hour, oTimeBlock.BaseDate.Minute, oTimeBlock.BaseDate.Second);
                                    dtCurrent = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                    if (mp_oControl.MathLib.mp_DateBlockVisible(dtTimeLineStart, dtTimeLineEnd, dtBase, oTimeBlock.DurationInterval, oTimeBlock.DurationFactor))
                                    {
                                        oTempTimeBlock = mp_oControl.TempTimeBlocks().Add("");
                                        oTempTimeBlock.BaseDate = dtBase;
                                        oTempTimeBlock.DurationInterval = oTimeBlock.DurationInterval;
                                        oTempTimeBlock.DurationFactor = oTimeBlock.DurationFactor;
                                        CopyTimeBlock(oTempTimeBlock, oTimeBlock);
                                    }
                                }
                                else
                                {
                                    dtCurrent = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                }
                            }
                            break;
                        case E_RECURRINGTYPE.RCT_YEAR:
                            dtTimeLineStart = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_YEAR, -1, dtTimeLineStart);
                            dtCurrent = new DateTime(dtTimeLineStart.Year, dtTimeLineStart.Month, dtTimeLineStart.Day, 0, 0, 0);
                            while (dtCurrent < dtTimeLineEnd)
                            {
                                if (oTimeBlock.BaseDate.Month == dtCurrent.Month)
                                {
                                    if (oTimeBlock.BaseDate.Day == dtCurrent.Day)
                                    {
                                        dtBase = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day, oTimeBlock.BaseDate.Hour, oTimeBlock.BaseDate.Minute, oTimeBlock.BaseDate.Second);
                                        dtCurrent = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                        if (mp_oControl.MathLib.mp_DateBlockVisible(dtTimeLineStart, dtTimeLineEnd, dtBase, oTimeBlock.DurationInterval, oTimeBlock.DurationFactor))
                                        {
                                            oTempTimeBlock = mp_oControl.TempTimeBlocks().Add("");
                                            oTempTimeBlock.BaseDate = dtBase;
                                            oTempTimeBlock.DurationInterval = oTimeBlock.DurationInterval;
                                            oTempTimeBlock.DurationFactor = oTimeBlock.DurationFactor;
                                            CopyTimeBlock(oTempTimeBlock, oTimeBlock);
                                        }
                                    }
                                    else
                                    {
                                        dtCurrent = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, 1, dtCurrent);
                                    }
                                }
                                else
                                {
                                    dtCurrent = mp_oControl.MathLib.DateTimeAdd(E_INTERVAL.IL_MONTH, 1, dtCurrent);
                                }
                            }
                            break;
                    }
                }
            }
        }
    
		private void CopyTimeBlock(clsTimeBlock oDestination, clsTimeBlock oOriginal)
		{
			oDestination.TimeBlockType = E_TIMEBLOCKTYPE.TBT_SINGLE_OCURRENCE;
			oDestination.StyleIndex = oOriginal.StyleIndex;
			oDestination.GenerateConflict = oOriginal.GenerateConflict;
			oDestination.Tag = oOriginal.Tag;
            oDestination.NonWorking = oOriginal.NonWorking;
			oDestination.f_Visible = oOriginal.f_Visible;
		}
    
		internal void Draw()
		{
			DrawClass(this);
			DrawClass(mp_oControl.TempTimeBlocks());
		}
    
		internal void DrawClass(clsTimeBlocks oTimeBlocks)
		{
			int lIndex = 0;
			clsTimeBlock oTimeBlock = null;
			if (oTimeBlocks.Count == 0) 
			{
				return;
			}
			mp_oControl.clsG.mp_ClipRegion(mp_oControl.Splitter.Right, mp_oControl.CurrentViewObject.ClientArea.Top, mp_oControl.mt_RightMargin, mp_oControl.CurrentViewObject.ClientArea.Bottom, true);
			for (lIndex = 1; lIndex <= oTimeBlocks.Count; lIndex++) 
			{
				oTimeBlock = (clsTimeBlock)oTimeBlocks.mp_oCollection.m_oReturnArrayElement(lIndex);
				if (oTimeBlock.Visible == true) 
				{
					mp_oControl.DrawEventArgs.Clear();
					mp_oControl.DrawEventArgs.CustomDraw = false;
					mp_oControl.DrawEventArgs.EventTarget = E_EVENTTARGET.EVT_TIMEBLOCK;
					mp_oControl.DrawEventArgs.ObjectIndex = lIndex;
					mp_oControl.DrawEventArgs.ParentObjectIndex = 0;
					mp_oControl.DrawEventArgs.Graphics = mp_oControl.clsG.oGraphics;
					mp_oControl.FireDraw();
					if (mp_oControl.DrawEventArgs.CustomDraw == false) 
					{
                        if ((oTimeBlock.Right - oTimeBlock.Left) >= 1)
                        {
                            mp_oControl.clsG.mp_DrawItem(oTimeBlock.Left, oTimeBlock.Top, oTimeBlock.Right, oTimeBlock.Bottom, "", "", false, null, oTimeBlock.LeftTrim, oTimeBlock.RightTrim, oTimeBlock.Style);
                        }
					}
				}
			}
		}

        public DateTime IntervalStart
        {
            get { return mp_dtIntervalStart; }
            set { mp_dtIntervalStart = value; }
        }

        public DateTime IntervalEnd
        {
            get { return mp_dtIntervalEnd; }
            set { mp_dtIntervalEnd = value; }
        }

        public E_TBINTERVALTYPE IntervalType
        {
            get { return mp_yIntervalType; }
            set { mp_yIntervalType = value; }
        }

        public void CalculateInterval()
        {
            if (mp_yIntervalType == E_TBINTERVALTYPE.TBIT_AUTOMATIC)
            {
                return;
            }
            mp_aTimeBlocks = new ArrayList();
            mp_oControl.MathLib.mp_GenerateTimeBlocks(ref mp_aTimeBlocks, mp_dtIntervalStart, mp_dtIntervalEnd);
        }


        public string CP_GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "CP_TimeBlocks");
            oXML.InitializeWriter();
            oXML.WriteProperty("IntervalStart", mp_dtIntervalStart);
            oXML.WriteProperty("IntervalEnd", mp_dtIntervalEnd);
            oXML.WriteProperty("IntervalType", mp_yIntervalType);
            return oXML.GetXML();
        }

        public void CP_SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "CP_TimeBlocks");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("IntervalStart", ref mp_dtIntervalStart);
            oXML.ReadProperty("IntervalEnd", ref mp_dtIntervalEnd);
            oXML.ReadProperty("IntervalType", ref mp_yIntervalType);
        }

        public string GetXML()
        {
            int lIndex = 0;
            clsTimeBlock oTimeBlock = null;
            clsXML oXML = new clsXML(mp_oControl, "TimeBlocks");
            oXML.InitializeWriter();
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                oTimeBlock = (clsTimeBlock)mp_oCollection.m_oReturnArrayElement(lIndex);
                oXML.WriteObject(oTimeBlock.GetXML());
            }
            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            int lIndex = 0;
            clsXML oXML = new clsXML(mp_oControl, "TimeBlocks");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            mp_oCollection.m_Clear();
            for (lIndex = 1; lIndex <= oXML.ReadCollectionCount(); lIndex++)
            {
                clsTimeBlock oTimeBlock = new clsTimeBlock(mp_oControl);
                oTimeBlock.SetXML(oXML.ReadCollectionObject(lIndex));
                mp_oCollection.AddMode = true;
                mp_oCollection.m_Add(oTimeBlock, oTimeBlock.Key, SYS_ERRORS.TIMEBLOCKS_ADD_1, SYS_ERRORS.TIMEBLOCKS_ADD_2, false, SYS_ERRORS.TIMEBLOCKS_ADD_3);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return mp_oCollection.mp_aoCollection.GetEnumerator();
        }
    
	}
}