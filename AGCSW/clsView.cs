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

namespace AGCSW
{
	public class clsView : clsItemBase
	{
        private ActiveGanttCSWCtl mp_oControl;
        public clsTimeLine TimeLine;
        public clsClientArea ClientArea;
		private String mp_sTag;
        private Object mp_oObjectTag;
        private E_INTERVAL mp_yScrollInterval;
        private E_INTERVAL mp_yInterval;
		private int mp_lFactor;

        internal clsView(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            TimeLine = new clsTimeLine(mp_oControl, this);
            ClientArea = new clsClientArea(mp_oControl, TimeLine);
            Clear();
        }

		~clsView()
		{	
		}

		public String Key 
		{
			get 
			{
				return mp_sKey;
			}
			set 
			{
				mp_oControl.Views.oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.VIEWS_SET_KEY);
			}
		}

		public String Tag 
		{
			get 
			{
				return mp_sTag;
			}
			set 
			{
				mp_sTag = value;
			}
		}

        public Object ObjectTag
        {
            get { return mp_oObjectTag; }
            set { mp_oObjectTag = value; }
        }

        internal E_INTERVAL f_ScrollInterval
        {
            get
            {
                return mp_yScrollInterval;
            }
            set
            {
                mp_yScrollInterval = value;
            }
        }

        public E_INTERVAL Interval
        {
            get
            {
                return mp_yInterval;
            }
            set
            {
                mp_yInterval = value;
                if (mp_yInterval == E_INTERVAL.IL_YEAR)
                {
                    mp_yScrollInterval = E_INTERVAL.IL_YEAR;
                }
                else
                {
                    mp_yScrollInterval = mp_yInterval + 1;
                }
            }
        }

        public int Factor
        {
            get
            {
                return mp_lFactor;
            }
            set
            {
                mp_lFactor = value;
            }
        }

		public String GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "View");
			oXML.InitializeWriter();
			oXML.WriteProperty("Interval", mp_yInterval);
			oXML.WriteProperty("Factor", mp_lFactor);
			oXML.WriteProperty("Key", mp_sKey);
			oXML.WriteProperty("Tag", mp_sTag);
			oXML.WriteObject(ClientArea.GetXML());
			oXML.WriteObject(TimeLine.GetXML());
			return oXML.GetXML();
		}

		public void SetXML(String sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "View");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("Tag", ref mp_sTag);
			oXML.ReadProperty("Interval", ref mp_yInterval);
			oXML.ReadProperty("Factor", ref mp_lFactor);
			ClientArea.SetXML(oXML.ReadObject("ClientArea"));
			TimeLine.SetXML(oXML.ReadObject("TimeLine"));
		}

        public void Clear()
        {
            mp_yInterval = E_INTERVAL.IL_SECOND;
            mp_lFactor = 1;
            mp_yScrollInterval = E_INTERVAL.IL_HOUR;
            mp_sTag = "";
            mp_oObjectTag = null;
            TimeLine.Clear();
            ClientArea.Clear();
        }

        public clsView Clone()
        {
            return Clone("");
        }

        public clsView Clone(string Key)
        {
            clsView oClone;
            oClone = mp_oControl.Views.Add(E_INTERVAL.IL_SECOND, 1, E_TIERTYPE.ST_DAYOFWEEK, E_TIERTYPE.ST_DAYOFWEEK, E_TIERTYPE.ST_DAYOFWEEK, Key);
            oClone.Interval = mp_yInterval;
            oClone.Factor = mp_lFactor;
            oClone.f_ScrollInterval = mp_yScrollInterval;
            oClone.Tag = mp_sTag;
            TimeLine.Clone(oClone.TimeLine);
            ClientArea.Clone(oClone.ClientArea);
            return oClone;
        }

	}
}