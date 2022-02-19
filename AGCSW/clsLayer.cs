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
	public class clsLayer : clsItemBase
	{
        private ActiveGanttCSWCtl mp_oControl;
		private bool mp_bVisible;
		private String mp_sTag;
        private Object mp_oObjectTag;

        public clsLayer(ActiveGanttCSWCtl oControl)
		{
            mp_oControl = oControl;
			mp_bVisible = true;
			mp_sTag = "";
            mp_oObjectTag = null;
		}

		~clsLayer()
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
				mp_oControl.Layers.oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.LAYERS_SET_KEY);
			}
		}

		public bool Visible 
		{
			get 
			{
				return mp_bVisible;
			}
			set 
			{
				mp_bVisible = value;
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

		public String GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "Layer");
			oXML.InitializeWriter();
			oXML.WriteProperty("Key", mp_sKey);
			oXML.WriteProperty("Visible", mp_bVisible);
			oXML.WriteProperty("Tag", mp_sTag);
			return oXML.GetXML();
		}

		public void SetXML(String sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "Layer");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("Key", ref mp_sKey);
			oXML.ReadProperty("Visible", ref mp_bVisible);
			oXML.ReadProperty("Tag", ref mp_sTag);
		}


	}
}