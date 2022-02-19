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

	public class clsTaskStyle
	{

        private ActiveGanttCSWCtl mp_oControl;
		private System.Windows.Media.Color mp_clrEndBorderColor;
		private System.Windows.Media.Color mp_clrEndFillColor;
		private System.Windows.Media.Color mp_clrStartBorderColor;
		private System.Windows.Media.Color mp_clrStartFillColor;
    
		private GRE_FIGURETYPE mp_yEndShapeIndex;
		private GRE_FIGURETYPE mp_yStartShapeIndex;
    
		private Image mp_oStartImage;
		private Image mp_oMiddleImage;
		private Image mp_oEndImage;

        private string mp_sStartImageTag;
        private string mp_sMiddleImageTag;
        private string mp_sEndImageTag;

        internal clsTaskStyle(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            Clear();
        }
    
		
		public Color EndBorderColor 
		{
			get { return mp_clrEndBorderColor; }
			set { mp_clrEndBorderColor = value; }
		}
    
		
		public Color EndFillColor 
		{
			get { return mp_clrEndFillColor; }
			set { mp_clrEndFillColor = value; }
		}
    
		
		public Color StartBorderColor 
		{
			get { return mp_clrStartBorderColor; }
			set { mp_clrStartBorderColor = value; }
		}
    
		
		public Color StartFillColor 
		{
			get { return mp_clrStartFillColor; }
			set { mp_clrStartFillColor = value; }
		}
    
		
		public Image StartImage 
		{
			get { return mp_oStartImage; }
			set { mp_oStartImage = value; }
		}
    
		
		public Image MiddleImage 
		{
			get { return mp_oMiddleImage; }
			set { mp_oMiddleImage = value; }
		}
    
		
		public Image EndImage 
		{
			get { return mp_oEndImage; }
			set { mp_oEndImage = value; }
		}
    
		
		public GRE_FIGURETYPE StartShapeIndex 
		{
			get { return mp_yStartShapeIndex; }
			set { mp_yStartShapeIndex = value; }
		}
    
		
		public GRE_FIGURETYPE EndShapeIndex 
		{
			get { return mp_yEndShapeIndex; }
			set { mp_yEndShapeIndex = value; }
		}

        public string StartImageTag
        {
            get { return mp_sStartImageTag; }
            set { mp_sStartImageTag = value; }
        }

        public string MiddleImageTag
        {
            get { return mp_sMiddleImageTag; }
            set { mp_sMiddleImageTag = value; }
        }

        public string EndImageTag
        {
            get { return mp_sEndImageTag; }
            set { mp_sEndImageTag = value; }
        }
    
		
		public string GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "TaskStyle");
			oXML.InitializeWriter();
			oXML.WriteProperty("EndBorderColor", mp_clrEndBorderColor);
			oXML.WriteProperty("EndFillColor", mp_clrEndFillColor);
			oXML.WriteProperty("EndImage", ref mp_oEndImage);
			oXML.WriteProperty("EndShapeIndex", mp_yEndShapeIndex);
			oXML.WriteProperty("MiddleImage", ref mp_oMiddleImage);
			oXML.WriteProperty("StartBorderColor", mp_clrStartBorderColor);
			oXML.WriteProperty("StartFillColor", mp_clrStartFillColor);
			oXML.WriteProperty("StartImage", ref mp_oStartImage);
			oXML.WriteProperty("StartShapeIndex", mp_yStartShapeIndex);
            oXML.WriteProperty("StartImageTag", mp_sStartImageTag);
            oXML.WriteProperty("MiddleImageTag", mp_sMiddleImageTag);
            oXML.WriteProperty("EndImageTag", mp_sEndImageTag);
			return oXML.GetXML();
		}
    
		
		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "TaskStyle");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("EndBorderColor", ref mp_clrEndBorderColor);
			oXML.ReadProperty("EndFillColor", ref mp_clrEndFillColor);
			oXML.ReadProperty("EndImage", ref mp_oEndImage);
			oXML.ReadProperty("EndShapeIndex", ref mp_yEndShapeIndex);
			oXML.ReadProperty("MiddleImage", ref mp_oMiddleImage);
			oXML.ReadProperty("StartBorderColor", ref mp_clrStartBorderColor);
			oXML.ReadProperty("StartFillColor", ref mp_clrStartFillColor);
			oXML.ReadProperty("StartImage", ref mp_oStartImage);
			oXML.ReadProperty("StartShapeIndex", ref mp_yStartShapeIndex);
            oXML.ReadProperty("StartImageTag", ref mp_sStartImageTag);
            oXML.ReadProperty("MiddleImageTag", ref mp_sMiddleImageTag);
            oXML.ReadProperty("EndImageTag", ref mp_sEndImageTag);
		}

        internal void Clear()
        {
            mp_clrEndBorderColor = Color.FromArgb(255, 0, 0, 0);
            mp_clrEndFillColor = Color.FromArgb(255, 0, 0, 0);
            mp_oEndImage = null;
            mp_yEndShapeIndex = GRE_FIGURETYPE.FT_NONE;
            mp_oMiddleImage = null;
            mp_clrStartBorderColor = Color.FromArgb(255, 0, 0, 0);
            mp_clrStartFillColor = Color.FromArgb(255, 0, 0, 0);
            mp_oStartImage = null;
            mp_yStartShapeIndex = GRE_FIGURETYPE.FT_NONE;
            mp_sStartImageTag = "";
            mp_sMiddleImageTag = "";
            mp_sEndImageTag = "";
        }

        internal void Clone(clsTaskStyle oClone)
        {
            oClone.EndBorderColor = mp_clrEndBorderColor;
            oClone.EndFillColor = mp_clrEndFillColor;
            oClone.EndImage = mp_oEndImage;
            oClone.EndShapeIndex = mp_yEndShapeIndex;
            oClone.MiddleImage = mp_oMiddleImage;
            oClone.StartBorderColor = mp_clrStartBorderColor;
            oClone.StartFillColor = mp_clrStartFillColor;
            oClone.StartImage = mp_oStartImage;
            oClone.StartShapeIndex = mp_yStartShapeIndex;
            oClone.StartImageTag = mp_sStartImageTag;
            oClone.MiddleImageTag = mp_sMiddleImageTag;
            oClone.EndImageTag = mp_sEndImageTag;
        }
    
	}
}