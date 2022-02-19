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
	public class clsTickMark : clsItemBase
	{

        private ActiveGanttCSWCtl mp_oControl;
		private bool mp_bDisplayText;
		private clsTickMarks mp_clsTickMarks;
		private string mp_sTextFormat;
		private string mp_sTag;
        private Object mp_oObjectTag;
		private E_TICKMARKTYPES mp_yTickMarkType;
        private E_INTERVAL mp_yInterval;
		private int mp_lFactor;

        internal clsTickMark(ActiveGanttCSWCtl oControl, clsTickMarks oTickMarks)
        {
            mp_oControl = oControl;
            mp_clsTickMarks = oTickMarks;
            Clear();
        }
    
		
		public string Key 
		{
			get { return mp_sKey; }
			set { mp_clsTickMarks.oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.TICKMARKS_SET_KEY); }
		}
    
		
		public bool DisplayText 
		{
			get { return mp_bDisplayText; }
			set { mp_bDisplayText = value; }
		}
    
		
		public string TextFormat 
		{
			get { return mp_sTextFormat; }
			set { mp_sTextFormat = value; }
		}
    
		
		public string Tag 
		{
			get { return mp_sTag; }
			set { mp_sTag = value; }
		}

        public Object ObjectTag
        {
            get { return mp_oObjectTag; }
            set { mp_oObjectTag = value; }
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
    
		
		public E_TICKMARKTYPES TickMarkType 
		{
			get { return mp_yTickMarkType; }
			set { mp_yTickMarkType = value; }
		}
    
		
		public string GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "TickMark");
			oXML.InitializeWriter();
			oXML.WriteProperty("DisplayText", mp_bDisplayText);
			oXML.WriteProperty("Interval", mp_yInterval);
			oXML.WriteProperty("Factor", mp_lFactor);
			oXML.WriteProperty("Key", mp_sKey);
			oXML.WriteProperty("Tag", mp_sTag);
			oXML.WriteProperty("TextFormat", mp_sTextFormat);
			oXML.WriteProperty("TickMarkType", mp_yTickMarkType);
			return oXML.GetXML();
		}
    
		
		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "TickMark");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("DisplayText", ref mp_bDisplayText);
			oXML.ReadProperty("Interval", ref mp_yInterval);
			oXML.ReadProperty("Factor", ref mp_lFactor);
			oXML.ReadProperty("Key", ref mp_sKey);
			oXML.ReadProperty("Tag", ref mp_sTag);
			oXML.ReadProperty("TextFormat", ref mp_sTextFormat);
			oXML.ReadProperty("TickMarkType", ref mp_yTickMarkType);
		}

        internal void Clear()
        {
            mp_bDisplayText = false;
            mp_yInterval = E_INTERVAL.IL_SECOND;
            mp_lFactor = 1;
            mp_sTag = "";
            mp_oObjectTag = null;
            mp_sTextFormat = "";
            mp_yTickMarkType = E_TICKMARKTYPES.TLT_SMALL;
        }

        internal void Clone(clsTickMark oClone)
        {
            oClone.DisplayText = mp_bDisplayText;
            oClone.Interval = mp_yInterval;
            oClone.Factor = mp_lFactor;
            oClone.Tag = mp_sTag;
            oClone.TextFormat = mp_sTextFormat;
            oClone.TickMarkType = mp_yTickMarkType;
        }
    
    
    
    
	}
}