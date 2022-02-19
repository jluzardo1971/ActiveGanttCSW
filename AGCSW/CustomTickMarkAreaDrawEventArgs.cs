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
using System.Windows.Media;

namespace AGCSW
{
    public class CustomTickMarkAreaDrawEventArgs
    {
        public bool CustomDraw;
        public DrawingContext Graphics;
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
        public DateTime dtDate;
        public clsTickMark oTickMark;

        public int X;
        internal CustomTickMarkAreaDrawEventArgs()
        {
            Clear();
        }

        internal void Clear()
        {
            CustomDraw = false;
            Left = 0;
            Top = 0;
            Right = 0;
            Bottom = 0;
            Graphics = null;
            oTickMark = null;
            dtDate = new DateTime();
            X = 0;
        }

    }
}