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
    public class clsTickMarks : IEnumerable
	{
        private ActiveGanttCSWCtl mp_oControl;
		private clsCollectionBase mp_oCollection;

        public clsTickMarks(ActiveGanttCSWCtl oControl)
		{
            mp_oControl = oControl;
			mp_oCollection = new clsCollectionBase(mp_oControl, "TickMark");
		}

		~clsTickMarks()
		{	
		}

		public int Count 
		{
			get 
			{
				return mp_oCollection.m_lCount();
			}
		}

		public clsTickMark Item(String Index)
		{
			return (clsTickMark) mp_oCollection.m_oItem(Index, SYS_ERRORS.TICKMARKS_ITEM_1, SYS_ERRORS.TICKMARKS_ITEM_2, SYS_ERRORS.TICKMARKS_ITEM_3, SYS_ERRORS.TICKMARKS_ITEM_4);
		}

        public clsTickMark Item(int Index)
        {
            return (clsTickMark)mp_oCollection.m_oReturnArrayElement(Index);
        }

        internal clsCollectionBase oCollection 
		{
			get 
			{
				return mp_oCollection;
			}
		}

        public clsTickMark Add(E_INTERVAL Interval, int Factor, E_TICKMARKTYPES TickMarkType)
        {
            return Add(Interval, Factor, TickMarkType, false, "", "");
        }

        public clsTickMark Add(E_INTERVAL Interval, int Factor, E_TICKMARKTYPES TickMarkType, bool DisplayText, string TextFormat)
        {
            return Add(Interval, Factor, TickMarkType, DisplayText, TextFormat, "");
        }

        public clsTickMark Add(E_INTERVAL Interval, int Factor, E_TICKMARKTYPES TickMarkType, bool DisplayText, String TextFormat, String Key)
        {
            mp_oCollection.AddMode = true;
            clsTickMark oTickMark = new clsTickMark(mp_oControl, this);
            oTickMark.Interval = Interval;
            oTickMark.Factor = Factor;
            oTickMark.TickMarkType = TickMarkType;
            oTickMark.DisplayText = DisplayText;
            oTickMark.TextFormat = TextFormat;
            oTickMark.Key = Key;
            mp_oCollection.m_Add(oTickMark, Key, SYS_ERRORS.TICKMARKS_ADD_1, SYS_ERRORS.TICKMARKS_ADD_2, false, SYS_ERRORS.TICKMARKS_ADD_3);
            return oTickMark;
        }

		public void Remove(String Index)
		{
			mp_oCollection.m_Remove(Index, SYS_ERRORS.TICKMARKS_REMOVE_1, SYS_ERRORS.TICKMARKS_REMOVE_2, SYS_ERRORS.TICKMARKS_REMOVE_3, SYS_ERRORS.TICKMARKS_REMOVE_4);
		}

		public String GetXML()
		{
			int lIndex;
			clsTickMark oTickMark;
			clsXML oXML = new clsXML(mp_oControl, "TickMarks");
			oXML.InitializeWriter();
			for (lIndex = 1;lIndex <= Count;lIndex++) 
			{
				oTickMark = (clsTickMark) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oTickMark.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(String sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML(mp_oControl, "TickMarks");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			mp_oCollection.m_Clear();
			for (lIndex = 1;lIndex <= oXML.ReadCollectionCount();lIndex++) 
			{
                clsTickMark oTickMark = new clsTickMark(mp_oControl, this);
				oTickMark.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				mp_oCollection.m_Add(oTickMark, oTickMark.Key, SYS_ERRORS.TICKMARKS_ADD_1, SYS_ERRORS.TICKMARKS_ADD_2, false, SYS_ERRORS.TICKMARKS_ADD_3);
				oTickMark = null;
			}
		}

        public void Clear()
        {
            mp_oCollection.m_Clear();
        }

        internal void Clone(clsTickMarks oClone)
        {
            oClone.Clear();
            int i = 0;
            for (i = 1; i <= Count; i++)
            {
                clsTickMark oTickMark = Item(i.ToString());
                clsTickMark oTickMarkClone = null;
                oTickMarkClone = oClone.Add(oTickMark.Interval, oTickMark.Factor, oTickMark.TickMarkType);
                oTickMark.Clone(oTickMarkClone);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return mp_oCollection.mp_aoCollection.GetEnumerator();
        }


	}
}