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
using System.Windows.Controls;


namespace AGCSW
{

	public class clsMilestoneStyle
	{
        private ActiveGanttCSWCtl mp_oControl;
		private System.Windows.Media.Color mp_clrBorderColor;
		private System.Windows.Media.Color mp_clrFillColor;
		private GRE_FIGURETYPE mp_yShapeIndex;
        private Image mp_oImage;
        private string mp_sImageTag;

        internal clsMilestoneStyle(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            Clear();
        }

		~clsMilestoneStyle()
		{
			
		}

		public Color BorderColor 
		{
			get 
			{
				return mp_clrBorderColor;
			}
			set 
			{
				mp_clrBorderColor = value;
			}
		}

		public Color FillColor 
		{
			get 
			{
				return mp_clrFillColor;
			}
			set 
			{
				mp_clrFillColor = value;
			}
		}

		public GRE_FIGURETYPE ShapeIndex 
		{
			get 
			{
				return mp_yShapeIndex;
			}
			set 
			{
				mp_yShapeIndex = value;
			}
		}

        public Image Image
        {
            get { return mp_oImage; }
            set { mp_oImage = value; }
        }

        public string ImageTag
        {
            get { return mp_sImageTag; }
            set { mp_sImageTag = value; }
        }

		public String GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "MilestoneStyle");
			oXML.InitializeWriter();
			oXML.WriteProperty("BorderColor", mp_clrBorderColor);
			oXML.WriteProperty("FillColor", mp_clrFillColor);
			oXML.WriteProperty("ShapeIndex", mp_yShapeIndex);
            oXML.WriteProperty("Image", ref mp_oImage);
            oXML.WriteProperty("ImageTag", mp_sImageTag);
			return oXML.GetXML();
		}

		public void SetXML(String sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "MilestoneStyle");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("BorderColor", ref mp_clrBorderColor);
			oXML.ReadProperty("FillColor", ref mp_clrFillColor);
			oXML.ReadProperty("ShapeIndex", ref mp_yShapeIndex);
            oXML.ReadProperty("Image", ref mp_oImage);
            oXML.ReadProperty("ImageTag", ref mp_sImageTag);
		}

        internal void Clear()
        {
            mp_clrBorderColor = Color.FromArgb(255, 0, 0, 0);
            mp_clrFillColor = Color.FromArgb(255, 0, 0, 0);
            mp_yShapeIndex = GRE_FIGURETYPE.FT_NONE;
            mp_oImage = null;
            mp_sImageTag = "";
        }

        internal void Clone(clsMilestoneStyle oClone)
        {
            oClone.BorderColor = mp_clrBorderColor;
            oClone.FillColor = mp_clrFillColor;
            oClone.ShapeIndex = mp_yShapeIndex;
            oClone.mp_oImage = mp_oImage;
            oClone.ImageTag = mp_sImageTag;
        }

	}
}