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
    public class Font
    {
        private string mp_sFamily;
        public float Size = 10;
        internal bool Italic = false;
        internal bool Underline = false;
        public System.Windows.FontStyle FontStyle;
        public System.Windows.FontWeight FontWeight;
        public GRE_VERTICALALIGNMENT VerticalAlignment = GRE_VERTICALALIGNMENT.VAL_TOP;

        public GRE_HORIZONTALALIGNMENT HorizontalAlignment = GRE_HORIZONTALALIGNMENT.HAL_LEFT;
        public Font(string FamilyName, float emSize)
        {
            mp_sFamily = FamilyName;
            Size = emSize;
        }

        public Font(string FamilyName, float emSize, System.Windows.FontWeight newStyle)
        {
            mp_sFamily = FamilyName;
            Size = emSize;
            FontWeight = newStyle;
        }

        public System.Windows.Media.FontFamily GetFontFamily()
        {
            System.Windows.Media.FontFamily oFontFamily = new System.Windows.Media.FontFamily(mp_sFamily);
            return oFontFamily;
        }


        public double WPFFontSize
        {
            get { return (96 * Size / 72); }
        }

        public Font Clone()
        {
            return (Font)this.MemberwiseClone();
        }

        public string Name
        {
            get { return mp_sFamily; }
        }

        public string FamilyName
        {
            get { return mp_sFamily; }
            set { mp_sFamily = value; }
        }

        internal bool Bold
        {
            get
            {
                if (FontWeight == System.Windows.FontWeights.Bold)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}