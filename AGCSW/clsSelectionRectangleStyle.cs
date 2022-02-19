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
using System.Windows.Media;

namespace AGCSW
{
    public class clsSelectionRectangleStyle
    {

        private ActiveGanttCSWCtl mp_oControl;
        private int mp_lOffsetBottom;
        private int mp_lOffsetLeft;
        private int mp_lOffsetRight;
        private int mp_lOffsetTop;
        private bool mp_bVisible;
        private E_SELECTIONRECTANGLEMODE mp_yMode;
        private int mp_lBorderWidth;

        private Color mp_clrColor;

        internal clsSelectionRectangleStyle(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            Clear();
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

        public bool Visible
        {
            get { return mp_bVisible; }
            set { mp_bVisible = value; }
        }

        public E_SELECTIONRECTANGLEMODE Mode
        {
            get { return mp_yMode; }
            set { mp_yMode = value; }
        }

        public int BorderWidth
        {
            get { return mp_lBorderWidth; }
            set { mp_lBorderWidth = value; }
        }

        public Color Color
        {
            get { return mp_clrColor; }
            set { mp_clrColor = value; }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "SelectionRectangleStyle");
            oXML.InitializeWriter();
            oXML.WriteProperty("OffsetBottom", mp_lOffsetBottom);
            oXML.WriteProperty("OffsetLeft", mp_lOffsetLeft);
            oXML.WriteProperty("OffsetRight", mp_lOffsetRight);
            oXML.WriteProperty("OffsetTop", mp_lOffsetTop);
            oXML.WriteProperty("Visible", mp_bVisible);
            oXML.WriteProperty("Mode", mp_yMode);
            oXML.WriteProperty("BorderWidth", mp_lBorderWidth);
            oXML.WriteProperty("Color", mp_clrColor);

            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "SelectionRectangleStyle");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("OffsetBottom", ref mp_lOffsetBottom);
            oXML.ReadProperty("OffsetLeft", ref mp_lOffsetLeft);
            oXML.ReadProperty("OffsetRight", ref mp_lOffsetRight);
            oXML.ReadProperty("OffsetTop", ref mp_lOffsetTop);
            oXML.ReadProperty("Visible", ref mp_bVisible);
            oXML.ReadProperty("Mode", ref mp_yMode);
            oXML.ReadProperty("BorderWidth", ref mp_lBorderWidth);
            oXML.ReadProperty("Color", ref mp_clrColor);
        }

        internal void Clear()
        {
            mp_lOffsetBottom = 3;
            mp_lOffsetLeft = 3;
            mp_lOffsetRight = 3;
            mp_lOffsetTop = 3;
            mp_bVisible = true;
            mp_yMode = E_SELECTIONRECTANGLEMODE.SRM_DOTTED;
            mp_lBorderWidth = 1;
            mp_clrColor = Color.FromArgb(255, 0, 0, 0);
        }

        internal void Clone(clsSelectionRectangleStyle oClone)
        {
            oClone.OffsetBottom = mp_lOffsetBottom;
            oClone.OffsetLeft = mp_lOffsetLeft;
            oClone.OffsetRight = mp_lOffsetRight;
            oClone.OffsetTop = mp_lOffsetTop;
            oClone.Visible = mp_bVisible;
            oClone.Mode = mp_yMode;
            oClone.BorderWidth = mp_lBorderWidth;
            oClone.Color = mp_clrColor;
        }

    }
}