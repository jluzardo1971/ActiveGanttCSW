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
	public class clsTierColor : clsItemBase
	{
        private ActiveGanttCSWCtl mp_oControl;
		private clsTierColors mp_clsTierColors;
		private Color mp_clrBackColor;
		private Color mp_clrForeColor;
        private Color mp_clrStartGradientColor;
        private Color mp_clrEndGradientColor;
        private Color mp_clrHatchBackColor;
        private Color mp_clrHatchForeColor;

		public clsTierColor(ActiveGanttCSWCtl oControl, clsTierColors oTierColors)
		{
            mp_oControl = oControl;
			mp_clsTierColors = oTierColors;
		}

		~clsTierColor()
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
				mp_clsTierColors.oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.TIERCOLORS_SET_KEY);
			}
		}

		public Color ForeColor 
		{
			get 
			{
				return mp_clrForeColor;
			}
			set 
			{
				mp_clrForeColor = value;
			}
		}

		public Color BackColor 
		{
			get 
			{
				return mp_clrBackColor;
			}
			set 
			{
				mp_clrBackColor = value;
			}
		}

        public Color StartGradientColor
        {
            get { return mp_clrStartGradientColor; }
            set { mp_clrStartGradientColor = value; }
        }

        public Color EndGradientColor
        {
            get { return mp_clrEndGradientColor; }
            set { mp_clrEndGradientColor = value; }
        }

        public Color HatchBackColor
        {
            get { return mp_clrHatchBackColor; }
            set { mp_clrHatchBackColor = value; }
        }

        public Color HatchForeColor
        {
            get { return mp_clrHatchForeColor; }
            set { mp_clrHatchForeColor = value; }
        }

		public String GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "TierColor");
			oXML.InitializeWriter();
			oXML.WriteProperty("BackColor", mp_clrBackColor);
			oXML.WriteProperty("ForeColor", mp_clrForeColor);
            oXML.WriteProperty("StartGradientColor", mp_clrStartGradientColor);
            oXML.WriteProperty("EndGradientColor", mp_clrEndGradientColor);
            oXML.WriteProperty("HatchBackColor", mp_clrHatchBackColor);
            oXML.WriteProperty("HatchForeColor", mp_clrHatchForeColor);
			oXML.WriteProperty("Key", mp_sKey);
			return oXML.GetXML();
		}

		public void SetXML(String sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "TierColor");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("BackColor", ref mp_clrBackColor);
			oXML.ReadProperty("ForeColor", ref mp_clrForeColor);
            oXML.ReadProperty("StartGradientColor", ref mp_clrStartGradientColor);
            oXML.ReadProperty("EndGradientColor", ref mp_clrEndGradientColor);
            oXML.ReadProperty("HatchBackColor", ref mp_clrHatchBackColor);
            oXML.ReadProperty("HatchForeColor", ref mp_clrHatchForeColor);
			oXML.ReadProperty("Key", ref mp_sKey);
		}

        internal void Clone(clsTierColor oClone)
        {
            oClone.BackColor = mp_clrBackColor;
            oClone.ForeColor = mp_clrForeColor;
            oClone.StartGradientColor = mp_clrStartGradientColor;
            oClone.EndGradientColor = mp_clrEndGradientColor;
            oClone.HatchBackColor = mp_clrHatchBackColor;
            oClone.HatchForeColor = mp_clrHatchForeColor;
        }

	}
}