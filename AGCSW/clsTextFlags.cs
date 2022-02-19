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

	public class clsTextFlags
	{

        private ActiveGanttCSWCtl mp_oControl;
		private GRE_VERTICALALIGNMENT mp_yVerticalAlignment;
		private GRE_HORIZONTALALIGNMENT mp_yHorizontalAlignment;
		private bool mp_bWordWrap;
		private bool mp_bRightToLeft;
		private int mp_lOffsetBottom;
		private int mp_lOffsetLeft;
		private int mp_lOffsetRight;
		private int mp_lOffsetTop;

        internal clsTextFlags(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            Clear();
        }

        public clsTextFlags()
        {
            mp_oControl = null;
            Clear();
        }   
		
		public GRE_VERTICALALIGNMENT VerticalAlignment 
		{
			get { return mp_yVerticalAlignment; }
			set { mp_yVerticalAlignment = value; }
		}
    
		
		public GRE_HORIZONTALALIGNMENT HorizontalAlignment 
		{
			get { return mp_yHorizontalAlignment; }
			set { mp_yHorizontalAlignment = value; }
		}
    
		
		public bool WordWrap 
		{
			get { return mp_bWordWrap; }
			set { mp_bWordWrap = value; }
		}
    
		
		public bool RightToLeft 
		{
			get { return mp_bRightToLeft; }
			set { mp_bRightToLeft = value; }
		}
    
		
		public int OffsetBottom 
		{
			get { return mp_lOffsetBottom; }
			set { mp_lOffsetBottom = value; }
		}
    
		
		public int OffsetLeft 
		{
			get { return mp_lOffsetLeft; }
			set { mp_lOffsetLeft = value; }
		}
    
		
		public int OffsetRight 
		{
			get { return mp_lOffsetRight; }
			set { mp_lOffsetRight = value; }
		}
    
		
		public int OffsetTop 
		{
			get { return mp_lOffsetTop; }
			set { mp_lOffsetTop = value; }
		}
    
		
		public string GetXML()
		{
            if (mp_oControl == null)
            {
                return "";
            }
			clsXML oXML = new clsXML(mp_oControl, "TextFlags");
			oXML.InitializeWriter();
			oXML.WriteProperty("HorizontalAlignment", mp_yHorizontalAlignment);
			oXML.WriteProperty("OffsetBottom", mp_lOffsetBottom);
			oXML.WriteProperty("OffsetLeft", mp_lOffsetLeft);
			oXML.WriteProperty("OffsetRight", mp_lOffsetRight);
			oXML.WriteProperty("OffsetTop", mp_lOffsetTop);
			oXML.WriteProperty("RightToLeft", mp_bRightToLeft);
			oXML.WriteProperty("VerticalAlignment", mp_yVerticalAlignment);
			oXML.WriteProperty("WordWrap", mp_bWordWrap);
			return oXML.GetXML();
		}
    
		
		public void SetXML(string sXML)
		{
            if (mp_oControl == null)
            {
                return;
            }
			clsXML oXML = new clsXML(mp_oControl, "TextFlags");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("HorizontalAlignment", ref mp_yHorizontalAlignment);
			oXML.ReadProperty("OffsetBottom", ref mp_lOffsetBottom);
			oXML.ReadProperty("OffsetLeft", ref mp_lOffsetLeft);
			oXML.ReadProperty("OffsetRight", ref mp_lOffsetRight);
			oXML.ReadProperty("OffsetTop", ref mp_lOffsetTop);
			oXML.ReadProperty("RightToLeft", ref mp_bRightToLeft);
			oXML.ReadProperty("VerticalAlignment", ref mp_yVerticalAlignment);
			oXML.ReadProperty("WordWrap", ref mp_bWordWrap);
		}

        internal void Clear()
        {
            mp_yHorizontalAlignment = GRE_HORIZONTALALIGNMENT.HAL_LEFT;
            mp_lOffsetBottom = 0;
            mp_lOffsetLeft = 0;
            mp_lOffsetRight = 0;
            mp_lOffsetTop = 0;
            mp_bRightToLeft = false;
            mp_yVerticalAlignment = GRE_VERTICALALIGNMENT.VAL_TOP;
            mp_bWordWrap = false;
        }

        internal void Clone(clsTextFlags oClone)
        {
            oClone.HorizontalAlignment = mp_yHorizontalAlignment;
            oClone.OffsetBottom = mp_lOffsetBottom;
            oClone.OffsetLeft = mp_lOffsetLeft;
            oClone.OffsetRight = mp_lOffsetRight;
            oClone.OffsetTop = mp_lOffsetTop;
            oClone.RightToLeft = mp_bRightToLeft;
            oClone.VerticalAlignment = mp_yVerticalAlignment;
            oClone.WordWrap = mp_bWordWrap;
        }
    
	}
}