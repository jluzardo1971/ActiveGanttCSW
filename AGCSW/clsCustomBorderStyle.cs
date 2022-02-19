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
	public class clsCustomBorderStyle
	{

        private ActiveGanttCSWCtl mp_oControl;
		private bool mp_bTop;
		private bool mp_bBottom;
		private bool mp_bLeft;
		private bool mp_bRight;

        internal clsCustomBorderStyle(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            Clear();
        }
    
		
		public bool Left 
		{
			get { return mp_bLeft; }
			set { mp_bLeft = value; }
		}
    
		
		public bool Top 
		{
			get { return mp_bTop; }
			set { mp_bTop = value; }
		}
    
		
		public bool Right 
		{
			get { return mp_bRight; }
			set { mp_bRight = value; }
		}
    
		
		public bool Bottom 
		{
			get { return mp_bBottom; }
			set { mp_bBottom = value; }
		}
    
		
		public string GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "CustomBorderStyle");
			oXML.InitializeWriter();
			oXML.WriteProperty("Bottom", mp_bBottom);
			oXML.WriteProperty("Left", mp_bLeft);
			oXML.WriteProperty("Right", mp_bRight);
			oXML.WriteProperty("Top", mp_bTop);
			return oXML.GetXML();
		}
    
		
		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "CustomBorderStyle");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("Bottom", ref mp_bBottom);
			oXML.ReadProperty("Left", ref mp_bLeft);
			oXML.ReadProperty("Right", ref mp_bRight);
			oXML.ReadProperty("Top", ref mp_bTop);
		}

        internal void Clear()
        {
            mp_bBottom = true;
            mp_bLeft = true;
            mp_bRight = true;
            mp_bTop = true;
        }

        internal void Clone(clsCustomBorderStyle oClone)
        {
            oClone.Bottom = mp_bBottom;
            oClone.Left = mp_bLeft;
            oClone.Right = mp_bRight;
            oClone.Top = mp_bTop;
        }
    
	}
}