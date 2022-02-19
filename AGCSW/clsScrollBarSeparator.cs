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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGCSW
{
    public class clsScrollBarSeparator
    {

        private ActiveGanttCSWCtl mp_oControl;
        private string mp_sStyleIndex;
        private clsStyle mp_oStyle;

        internal clsScrollBarSeparator(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            mp_sStyleIndex = "DS_SB_SEPARATOR";
            mp_oStyle = mp_oControl.Styles.FItem("DS_SB_SEPARATOR");
        }

        public string StyleIndex
        {
            get
            {
                if (mp_sStyleIndex == "DS_SB_SEPARATOR")
                {
                    return "";
                }
                else
                {
                    return mp_sStyleIndex;
                }
            }
            set
            {
                value = value.Trim();
                if (value.Length == 0)
                    value = "DS_SB_SEPARATOR";
                mp_sStyleIndex = value;
                mp_oStyle = mp_oControl.Styles.FItem(value);
            }
        }

        public clsStyle Style
        {
            get { return mp_oStyle; }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "ScrollBarSeparator");
            oXML.InitializeWriter();
            oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "ScrollBarSeparator");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
            StyleIndex = mp_sStyleIndex;
        }

    }
}