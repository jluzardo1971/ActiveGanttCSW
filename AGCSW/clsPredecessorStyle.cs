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


namespace AGCSW
{

	public class clsPredecessorStyle
	{

        private ActiveGanttCSWCtl mp_oControl;
		private int mp_lArrowSize;
		private GRE_LINEDRAWSTYLE mp_yLineStyle;
		private int mp_lLineWidth;
		private int mp_lXOffset;
		private int mp_lYOffset;
		private System.Windows.Media.Color mp_clrLineColor;

        internal clsPredecessorStyle(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            Clear();
        }
    
		
		public Color LineColor 
		{
			get { return mp_clrLineColor; }
			set { mp_clrLineColor = value; }
		}
    
		
		public int XOffset 
		{
			get { return mp_lXOffset; }
			set { mp_lXOffset = value; }
		}
    
		
		public int YOffset 
		{
			get { return mp_lYOffset; }
			set { mp_lYOffset = value; }
		}
    
		
		public int LineWidth 
		{
			get { return mp_lLineWidth; }
			set { mp_lLineWidth = value; }
		}
    
		
		public GRE_LINEDRAWSTYLE LineStyle 
		{
			get { return mp_yLineStyle; }
			set { mp_yLineStyle = value; }
		}  
		
		public int ArrowSize 
		{
			get { return mp_lArrowSize; }
			set 
			{
				if ((value < 1)) 
				{
					value = 1;
				}
				mp_lArrowSize = value;
			}
		}
    
		
		public string GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "PredecessorStyle");
			oXML.InitializeWriter();
			oXML.WriteProperty("ArrowSize", mp_lArrowSize);
			oXML.WriteProperty("LineColor", mp_clrLineColor);
			oXML.WriteProperty("LineStyle", mp_yLineStyle);
			oXML.WriteProperty("LineWidth", mp_lLineWidth);
			oXML.WriteProperty("XOffset", mp_lXOffset);
			oXML.WriteProperty("YOffset", mp_lYOffset);
			return oXML.GetXML();
		}
    
		
		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "PredecessorStyle");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("ArrowSize", ref mp_lArrowSize);
			oXML.ReadProperty("LineColor", ref mp_clrLineColor);
			oXML.ReadProperty("LineStyle", ref mp_yLineStyle);
			oXML.ReadProperty("LineWidth", ref mp_lLineWidth);
			oXML.ReadProperty("XOffset", ref mp_lXOffset);
			oXML.ReadProperty("YOffset", ref mp_lYOffset);
		}

        internal void Clear()
        {
            mp_lArrowSize = 3;
            mp_clrLineColor = Color.FromArgb(255, 0, 0, 0);
            mp_yLineStyle = GRE_LINEDRAWSTYLE.LDS_SOLID;
            mp_lLineWidth = 1;
            mp_lXOffset = 10;
            mp_lYOffset = 10;
        }

        internal void Clone(clsPredecessorStyle oClone)
        {
            oClone.ArrowSize = mp_lArrowSize;
            oClone.LineColor = mp_clrLineColor;
            oClone.LineStyle = mp_yLineStyle;
            oClone.LineWidth = mp_lLineWidth;
            oClone.XOffset = mp_lXOffset;
            oClone.YOffset = mp_lYOffset;
        }
    
	}

}