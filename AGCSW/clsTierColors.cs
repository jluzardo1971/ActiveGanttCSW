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
using System.Windows.Media;
using System.Collections;


namespace AGCSW
{
    public class clsTierColors : IEnumerable
	{

        private ActiveGanttCSWCtl mp_oControl;
		private clsCollectionBase mp_oCollection;
		private E_TIERTYPE mp_yTierType;

		public clsTierColors(ActiveGanttCSWCtl oControl, E_TIERTYPE yTierType)
		{
            mp_oControl = oControl;
			mp_oCollection = new clsCollectionBase(mp_oControl, "TierColor");
			mp_yTierType = yTierType;
		}

		~clsTierColors()
		{
			mp_oCollection = null;
		}

		public int Count 
		{
			get 
			{
				return mp_oCollection.m_lCount();
			}
		}

		public clsTierColor Item(String Index)
		{
			return (clsTierColor) mp_oCollection.m_oItem(Index, SYS_ERRORS.TIERCOLORS_ITEM_1, SYS_ERRORS.TIERCOLORS_ITEM_2, SYS_ERRORS.TIERCOLORS_ITEM_3, SYS_ERRORS.TIERCOLORS_ITEM_4);
		}

        public clsTierColor Item(int Index)
        {
            return (clsTierColor)mp_oCollection.m_oReturnArrayElement(Index);
        }

        internal clsCollectionBase oCollection 
		{
			get 
			{
				return mp_oCollection;
			}
		}

        internal clsTierColor Add(Color BackColor, Color ForeColor, Color StartGradientColor, Color EndGradientColor, Color HatchBackColor, Color HatchForeColor)
        {
            return Add(BackColor, ForeColor, StartGradientColor, EndGradientColor, HatchBackColor, HatchForeColor, "");
        }

        internal clsTierColor Add(Color BackColor, Color ForeColor, Color StartGradientColor, Color EndGradientColor, Color HatchBackColor, Color HatchForeColor, string Key)
        {
            mp_oCollection.AddMode = true;
            clsTierColor oTierColor = new clsTierColor(mp_oControl, this);
            oTierColor.BackColor = BackColor;
            oTierColor.ForeColor = ForeColor;
            oTierColor.StartGradientColor = StartGradientColor;
            oTierColor.EndGradientColor = EndGradientColor;
            oTierColor.HatchBackColor = HatchBackColor;
            oTierColor.HatchForeColor = HatchForeColor;
            oTierColor.Key = Key;
            mp_oCollection.m_Add(oTierColor, Key, SYS_ERRORS.TIERCOLORS_ADD_1, SYS_ERRORS.TIERCOLORS_ADD_2, false, SYS_ERRORS.TIERCOLORS_ADD_3);
            return oTierColor;
        }

		private String mp_CollectionName()
		{
            if (mp_yTierType == E_TIERTYPE.ST_MICROSECOND)
            {
                return "MicrosecondColors";
            }
            else if (mp_yTierType == E_TIERTYPE.ST_MILLISECOND)
            {
                return "MillisecondColors";
            }
            else if (mp_yTierType == E_TIERTYPE.ST_SECOND)
            {
                return "SecondColors";
            }
            else if (mp_yTierType == E_TIERTYPE.ST_MINUTE)
			{
				return "MinuteColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_HOUR)
			{
				return "HourColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_DAY)
			{
				return "DayColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_DAYOFWEEK)
			{
				return "DayOfWeekColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_DAYOFYEAR)
			{
				return "DayOfYearColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_WEEK)
			{
				return "WeekColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_MONTH)
			{
				return "MonthColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_QUARTER)
			{
				return "QuarterColors";
			}
			else if (mp_yTierType == E_TIERTYPE.ST_YEAR)
			{
				return "YearColors";
			}
			return "";
		}

		public String GetXML()
		{
			int lIndex;
			clsTierColor oTierColor;
			clsXML oXML = new clsXML(mp_oControl, mp_CollectionName());
			oXML.InitializeWriter();
			for (lIndex = 1;lIndex <= Count;lIndex++) 
			{
				oTierColor = (clsTierColor) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oTierColor.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(String sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML(mp_oControl, mp_CollectionName());
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			mp_oCollection.m_Clear();
			for (lIndex = 1;lIndex <= oXML.ReadCollectionCount();lIndex++) 
			{
                clsTierColor oTierColor = new clsTierColor(mp_oControl, this);
				oTierColor.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				mp_oCollection.m_Add(oTierColor, oTierColor.Key, SYS_ERRORS.TIERCOLORS_ADD_1, SYS_ERRORS.TIERCOLORS_ADD_2, false, SYS_ERRORS.TIERCOLORS_ADD_3);
				oTierColor = null;
			}
		}

        internal void Clear()
        {
            mp_oCollection.m_Clear();
        }

        internal void Clone(clsTierColors oClone)
        {
            oClone.Clear();
            int i = 0;
            for (i = 1; i <= Count; i++)
            {
                clsTierColor oTierColor = Item(i.ToString());
                clsTierColor oTierColorClone = null;
                oTierColorClone = oClone.Add(oTierColor.BackColor, oTierColor.ForeColor, oTierColor.StartGradientColor, oTierColor.EndGradientColor, oTierColor.HatchBackColor, oTierColor.HatchForeColor, oTierColor.Key);
                oTierColor.Clone(oTierColorClone);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return mp_oCollection.mp_aoCollection.GetEnumerator();
        }



	}
}