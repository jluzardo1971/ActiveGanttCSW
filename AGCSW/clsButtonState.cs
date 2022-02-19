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
    public class clsButtonState
    {

        private ActiveGanttCSWCtl mp_oControl;
        private string mp_sType;
        private string mp_sNormalStyleIndex;
        private string mp_sPressedStyleIndex;
        private string mp_sDisabledStyleIndex;
        private clsStyle mp_oNormalStyle;
        private clsStyle mp_oPressedStyle;
        private clsStyle mp_oDisabledStyle;

        internal clsButtonState(ActiveGanttCSWCtl oControl, string sType)
        {
            mp_oControl = oControl;
            mp_sType = sType;
            Clear();
        }

        public string NormalStyleIndex
        {
            get
            {
                if (mp_sNormalStyleIndex == "DS_SB_NORMAL")
                {
                    return "";
                }
                else
                {
                    return mp_sNormalStyleIndex;
                }
            }
            set
            {
                value = value.Trim();
                if (value.Length == 0)
                    value = "DS_SB_NORMAL";
                mp_sNormalStyleIndex = value;
                mp_oNormalStyle = mp_oControl.Styles.FItem(value);
            }
        }

        public clsStyle NormalStyle
        {
            get { return mp_oNormalStyle; }
        }

        public string PressedStyleIndex
        {
            get
            {
                if (mp_sPressedStyleIndex == "DS_SB_PRESSED")
                {
                    return "";
                }
                else
                {
                    return mp_sPressedStyleIndex;
                }
            }
            set
            {
                value = value.Trim();
                if (value.Length == 0)
                    value = "DS_SB_PRESSED";
                mp_sPressedStyleIndex = value;
                mp_oPressedStyle = mp_oControl.Styles.FItem(value);
            }
        }

        public clsStyle PressedStyle
        {
            get { return mp_oPressedStyle; }
        }

        public string DisabledStyleIndex
        {
            get
            {
                if (mp_sDisabledStyleIndex == "DS_SB_DISABLED")
                {
                    return "";
                }
                else
                {
                    return mp_sDisabledStyleIndex;
                }
            }
            set
            {
                value = value.Trim();
                if (value.Length == 0)
                    value = "DS_SB_DISABLED";
                mp_sDisabledStyleIndex = value;
                mp_oDisabledStyle = mp_oControl.Styles.FItem(value);
            }
        }

        public clsStyle DisabledStyle
        {
            get { return mp_oDisabledStyle; }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, mp_sType + "ButtonState");
            oXML.InitializeWriter();
            oXML.WriteProperty("NormalStyleIndex", mp_sNormalStyleIndex);
            oXML.WriteProperty("PressedStyleIndex", mp_sPressedStyleIndex);
            oXML.WriteProperty("DisabledStyleIndex", mp_sDisabledStyleIndex);

            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, mp_sType + "ButtonState");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("NormalStyleIndex", ref mp_sNormalStyleIndex);
            NormalStyleIndex = mp_sNormalStyleIndex;
            oXML.ReadProperty("PressedStyleIndex", ref mp_sPressedStyleIndex);
            PressedStyleIndex = mp_sPressedStyleIndex;
            oXML.ReadProperty("DisabledStyleIndex", ref mp_sDisabledStyleIndex);
            DisabledStyleIndex = mp_sDisabledStyleIndex;
        }

        internal void Clear()
        {
            mp_sNormalStyleIndex = "DS_SB_NORMAL";
            mp_oNormalStyle = mp_oControl.Styles.FItem("DS_SB_NORMAL");
            mp_sPressedStyleIndex = "DS_SB_PRESSED";
            mp_oPressedStyle = mp_oControl.Styles.FItem("DS_SB_PRESSED");
            mp_sDisabledStyleIndex = "DS_SB_DISABLED";
            mp_oDisabledStyle = mp_oControl.Styles.FItem("DS_SB_DISABLED");
        }

        internal void Clone(clsButtonState oClone)
        {
            oClone.NormalStyleIndex = mp_sNormalStyleIndex;
            oClone.PressedStyleIndex = mp_sPressedStyleIndex;
            oClone.DisabledStyleIndex = mp_sDisabledStyleIndex;
        }



    }
}