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
    public class clsButtonBorderStyle
    {

        private ActiveGanttCSWCtl mp_oControl;
        private Color mp_clrRaisedExteriorLeftTopColor;
        private Color mp_clrRaisedInteriorLeftTopColor;
        private Color mp_clrRaisedExteriorRightBottomColor;
        private Color mp_clrRaisedInteriorRightBottomColor;
        private Color mp_clrSunkenExteriorLeftTopColor;
        private Color mp_clrSunkenInteriorLeftTopColor;
        private Color mp_clrSunkenExteriorRightBottomColor;
        private Color mp_clrSunkenInteriorRightBottomColor;

        internal clsButtonBorderStyle(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            Clear();
        }

        public Color RaisedExteriorLeftTopColor
        {
            get { return mp_clrRaisedExteriorLeftTopColor; }
            set { mp_clrRaisedExteriorLeftTopColor = value; }
        }

        public Color RaisedInteriorLeftTopColor
        {
            get { return mp_clrRaisedInteriorLeftTopColor; }
            set { mp_clrRaisedInteriorLeftTopColor = value; }
        }

        public Color RaisedExteriorRightBottomColor
        {
            get { return mp_clrRaisedExteriorRightBottomColor; }
            set { mp_clrRaisedExteriorRightBottomColor = value; }
        }

        public Color RaisedInteriorRightBottomColor
        {
            get { return mp_clrRaisedInteriorRightBottomColor; }
            set { mp_clrRaisedInteriorRightBottomColor = value; }
        }

        public Color SunkenExteriorLeftTopColor
        {
            get { return mp_clrSunkenExteriorLeftTopColor; }
            set { mp_clrSunkenExteriorLeftTopColor = value; }
        }

        public Color SunkenInteriorLeftTopColor
        {
            get { return mp_clrSunkenInteriorLeftTopColor; }
            set { mp_clrSunkenInteriorLeftTopColor = value; }
        }

        public Color SunkenExteriorRightBottomColor
        {
            get { return mp_clrSunkenExteriorRightBottomColor; }
            set { mp_clrSunkenExteriorRightBottomColor = value; }
        }

        public Color SunkenInteriorRightBottomColor
        {
            get { return mp_clrSunkenInteriorRightBottomColor; }
            set { mp_clrSunkenInteriorRightBottomColor = value; }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "ButtonBorderStyle");
            oXML.InitializeWriter();
            oXML.WriteProperty("RaisedExteriorLeftTopColor", mp_clrRaisedExteriorLeftTopColor);
            oXML.WriteProperty("RaisedInteriorLeftTopColor", mp_clrRaisedInteriorLeftTopColor);
            oXML.WriteProperty("RaisedExteriorRightBottomColor", mp_clrRaisedExteriorRightBottomColor);
            oXML.WriteProperty("RaisedInteriorRightBottomColor", mp_clrRaisedInteriorRightBottomColor);
            oXML.WriteProperty("SunkenExteriorLeftTopColor", mp_clrSunkenExteriorLeftTopColor);
            oXML.WriteProperty("SunkenInteriorLeftTopColor", mp_clrSunkenInteriorLeftTopColor);
            oXML.WriteProperty("SunkenExteriorRightBottomColor", mp_clrSunkenExteriorRightBottomColor);
            oXML.WriteProperty("SunkenInteriorRightBottomColor", mp_clrSunkenInteriorRightBottomColor);
            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "ButtonBorderStyle");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("RaisedExteriorLeftTopColor", ref mp_clrRaisedExteriorLeftTopColor);
            oXML.ReadProperty("RaisedInteriorLeftTopColor", ref mp_clrRaisedInteriorLeftTopColor);
            oXML.ReadProperty("RaisedExteriorRightBottomColor", ref mp_clrRaisedExteriorRightBottomColor);
            oXML.ReadProperty("RaisedInteriorRightBottomColor", ref mp_clrRaisedInteriorRightBottomColor);
            oXML.ReadProperty("SunkenExteriorLeftTopColor", ref mp_clrSunkenExteriorLeftTopColor);
            oXML.ReadProperty("SunkenInteriorLeftTopColor", ref mp_clrSunkenInteriorLeftTopColor);
            oXML.ReadProperty("SunkenExteriorRightBottomColor", ref mp_clrSunkenExteriorRightBottomColor);
            oXML.ReadProperty("SunkenInteriorRightBottomColor", ref mp_clrSunkenInteriorRightBottomColor);
        }

        internal void Clear()
        {
            mp_clrRaisedExteriorLeftTopColor = Color.FromArgb(255, 240, 240, 240);
            mp_clrRaisedInteriorLeftTopColor = Color.FromArgb(255, 192, 192, 192);
            mp_clrRaisedExteriorRightBottomColor = Color.FromArgb(255, 128, 128, 128);
            mp_clrRaisedInteriorRightBottomColor = Color.FromArgb(255, 64, 64, 64);
            mp_clrSunkenExteriorLeftTopColor = Color.FromArgb(255, 128, 128, 128);
            mp_clrSunkenInteriorLeftTopColor = Color.FromArgb(255, 64, 64, 64);
            mp_clrSunkenExteriorRightBottomColor = Color.FromArgb(255, 240, 240, 240);
            mp_clrSunkenInteriorRightBottomColor = Color.FromArgb(255, 192, 192, 192);
        }

        internal void Clone(clsButtonBorderStyle oClone)
        {
            oClone.RaisedExteriorLeftTopColor = mp_clrRaisedExteriorLeftTopColor;
            oClone.RaisedInteriorLeftTopColor = mp_clrRaisedInteriorLeftTopColor;
            oClone.RaisedExteriorRightBottomColor = mp_clrRaisedExteriorRightBottomColor;
            oClone.RaisedInteriorRightBottomColor = mp_clrRaisedInteriorRightBottomColor;
            oClone.SunkenExteriorLeftTopColor = mp_clrSunkenExteriorLeftTopColor;
            oClone.SunkenInteriorLeftTopColor = mp_clrSunkenInteriorLeftTopColor;
            oClone.SunkenExteriorRightBottomColor = mp_clrSunkenExteriorRightBottomColor;
            oClone.SunkenInteriorRightBottomColor = mp_clrSunkenInteriorRightBottomColor;
        }

    }
}