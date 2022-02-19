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
    public class clsScrollBarStyle
    {

        private ActiveGanttCSWCtl mp_oControl;
        private Color mp_clrArrowColor;
        private Color mp_clrDropShadowArrowColor;
        private bool mp_bDropShadow;
        private int mp_lLeftX;
        private int mp_lLeftY;
        private int mp_lUpX;
        private int mp_lUpY;
        private int mp_lRightX;
        private int mp_lRightY;
        private int mp_lDownX;
        private int mp_lDownY;
        private int mp_lDropShadowLeftX;
        private int mp_lDropShadowLeftY;
        private int mp_lDropShadowUpX;
        private int mp_lDropShadowUpY;
        private int mp_lDropShadowRightX;
        private int mp_lDropShadowRightY;
        private int mp_lDropShadowDownX;
        private int mp_lDropShadowDownY;
        private int mp_lArrowSize;

        internal clsScrollBarStyle(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            Clear();
        }

        public Color ArrowColor
        {
            get { return mp_clrArrowColor; }
            set { mp_clrArrowColor = value; }
        }

        public Color DropShadowArrowColor
        {
            get { return mp_clrDropShadowArrowColor; }
            set { mp_clrDropShadowArrowColor = value; }
        }

        public bool DropShadow
        {
            get { return mp_bDropShadow; }
            set { mp_bDropShadow = value; }
        }

        public int ArrowSize
        {
            get { return mp_lArrowSize; }
            set { mp_lArrowSize = value; }
        }

        public int LeftX
        {
            get { return mp_lLeftX; }
            set { mp_lLeftX = value; }
        }

        public int LeftY
        {
            get { return mp_lLeftY; }
            set { mp_lLeftY = value; }
        }

        public int UpX
        {
            get { return mp_lUpX; }
            set { mp_lUpX = value; }
        }

        public int UpY
        {
            get { return mp_lUpY; }
            set { mp_lUpY = value; }
        }

        public int RightX
        {
            get { return mp_lRightX; }
            set { mp_lRightX = value; }
        }

        public int RightY
        {
            get { return mp_lRightY; }
            set { mp_lRightY = value; }
        }

        public int DownX
        {
            get { return mp_lDownX; }
            set { mp_lDownX = value; }
        }

        public int DownY
        {
            get { return mp_lDownY; }
            set { mp_lDownY = value; }
        }

        //

        public int DropShadowLeftX
        {
            get { return mp_lDropShadowLeftX; }
            set { mp_lDropShadowLeftX = value; }
        }

        public int DropShadowLeftY
        {
            get { return mp_lDropShadowLeftY; }
            set { mp_lDropShadowLeftY = value; }
        }

        public int DropShadowUpX
        {
            get { return mp_lDropShadowUpX; }
            set { mp_lDropShadowUpX = value; }
        }

        public int DropShadowUpY
        {
            get { return mp_lDropShadowUpY; }
            set { mp_lDropShadowUpY = value; }
        }

        public int DropShadowRightX
        {
            get { return mp_lDropShadowRightX; }
            set { mp_lDropShadowRightX = value; }
        }

        public int DropShadowRightY
        {
            get { return mp_lDropShadowRightY; }
            set { mp_lDropShadowRightY = value; }
        }

        public int DropShadowDownX
        {
            get { return mp_lDropShadowDownX; }
            set { mp_lDropShadowDownX = value; }
        }

        public int DropShadowDownY
        {
            get { return mp_lDropShadowDownY; }
            set { mp_lDropShadowDownY = value; }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "ScrollBarStyle");
            oXML.InitializeWriter();
            oXML.WriteProperty("ArrowColor", mp_clrArrowColor);
            oXML.WriteProperty("DropShadowArrowColor", mp_clrDropShadowArrowColor);
            oXML.WriteProperty("DropShadow", mp_bDropShadow);
            oXML.WriteProperty("ArrowSize", mp_lArrowSize);
            oXML.WriteProperty("LeftX", mp_lLeftX);
            oXML.WriteProperty("LeftY", mp_lLeftY);
            oXML.WriteProperty("UpX", mp_lUpX);
            oXML.WriteProperty("UpY", mp_lUpY);
            oXML.WriteProperty("RightX", mp_lRightX);
            oXML.WriteProperty("RightY", mp_lRightY);
            oXML.WriteProperty("DownX", mp_lDownX);
            oXML.WriteProperty("DownY", mp_lDownY);
            oXML.WriteProperty("DropShadowLeftX", mp_lDropShadowLeftX);
            oXML.WriteProperty("DropShadowLeftY", mp_lDropShadowLeftY);
            oXML.WriteProperty("DropShadowUpX", mp_lDropShadowUpX);
            oXML.WriteProperty("DropShadowUpY", mp_lDropShadowUpY);
            oXML.WriteProperty("DropShadowRightX", mp_lDropShadowRightX);
            oXML.WriteProperty("DropShadowRightY", mp_lDropShadowRightY);
            oXML.WriteProperty("DropShadowDownX", mp_lDropShadowDownX);
            oXML.WriteProperty("DropShadowDownY", mp_lDropShadowDownY);

            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "ScrollBarStyle");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("ArrowColor", ref mp_clrArrowColor);
            oXML.ReadProperty("DropShadowArrowColor", ref mp_clrDropShadowArrowColor);
            oXML.ReadProperty("DropShadow", ref mp_bDropShadow);
            oXML.ReadProperty("ArrowSize", ref mp_lArrowSize);
            oXML.ReadProperty("LeftX", ref mp_lLeftX);
            oXML.ReadProperty("LeftY", ref mp_lLeftY);
            oXML.ReadProperty("UpX", ref mp_lUpX);
            oXML.ReadProperty("UpY", ref mp_lUpY);
            oXML.ReadProperty("RightX", ref mp_lRightX);
            oXML.ReadProperty("RightY", ref mp_lRightY);
            oXML.ReadProperty("DownX", ref mp_lDownX);
            oXML.ReadProperty("DownY", ref mp_lDownY);
            oXML.ReadProperty("DropShadowLeftX", ref mp_lDropShadowLeftX);
            oXML.ReadProperty("DropShadowLeftY", ref mp_lDropShadowLeftY);
            oXML.ReadProperty("DropShadowUpX", ref mp_lDropShadowUpX);
            oXML.ReadProperty("DropShadowUpY", ref mp_lDropShadowUpY);
            oXML.ReadProperty("DropShadowRightX", ref mp_lDropShadowRightX);
            oXML.ReadProperty("DropShadowRightY", ref mp_lDropShadowRightY);
            oXML.ReadProperty("DropShadowDownX", ref mp_lDropShadowDownX);
            oXML.ReadProperty("DropShadowDownY", ref mp_lDropShadowDownY);
        }

        internal void Clear()
        {
            mp_clrArrowColor = Color.FromArgb(255, 0, 0, 0);
            mp_clrDropShadowArrowColor = Color.FromArgb(255, 192, 192, 192);
            mp_bDropShadow = false;
            mp_lArrowSize = 3;
            mp_lLeftX = 6;
            mp_lLeftY = 8;
            mp_lUpX = 8;
            mp_lUpY = 6;
            mp_lRightX = 10;
            mp_lRightY = 8;
            mp_lDownX = 8;
            mp_lDownY = 10;
            mp_lDropShadowLeftX = 5;
            mp_lDropShadowLeftY = 7;
            mp_lDropShadowUpX = 7;
            mp_lDropShadowUpY = 5;
            mp_lDropShadowRightX = 9;
            mp_lDropShadowRightY = 7;
            mp_lDropShadowDownX = 7;
            mp_lDropShadowDownY = 9;
        }

        internal void Clone(clsScrollBarStyle oClone)
        {
            oClone.ArrowColor = mp_clrArrowColor;
            oClone.DropShadowArrowColor = mp_clrDropShadowArrowColor;
            oClone.DropShadow = mp_bDropShadow;
            oClone.ArrowSize = mp_lArrowSize;
            oClone.LeftX = mp_lLeftX;
            oClone.LeftY = mp_lLeftY;
            oClone.UpX = mp_lUpX;
            oClone.UpY = mp_lUpY;
            oClone.RightX = mp_lRightX;
            oClone.RightY = mp_lRightY;
            oClone.DownX = mp_lDownX;
            oClone.DownY = mp_lDownY;
            oClone.DropShadowLeftX = mp_lDropShadowLeftX;
            oClone.DropShadowLeftY = mp_lDropShadowLeftY;
            oClone.DropShadowUpX = mp_lDropShadowUpX;
            oClone.DropShadowUpY = mp_lDropShadowUpY;
            oClone.DropShadowRightX = mp_lDropShadowRightX;
            oClone.DropShadowRightY = mp_lDropShadowRightY;
            oClone.DropShadowDownX = mp_lDropShadowDownX;
            oClone.DropShadowDownY = mp_lDropShadowDownY;
        }

    }
}