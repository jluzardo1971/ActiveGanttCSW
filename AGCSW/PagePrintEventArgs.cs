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
    public class PagePrintEventArgs
    {
        public int PageNumber;
        public DrawingContext Graphics;
        public int X1;
        public int Y1;
        public int X2;
        public int Y2;
        public int PageWidth;
        public int PageHeight;
        public int ActualPageHeight;

        public int ActualPageWidth;
        internal PagePrintEventArgs()
        {
            Clear();
        }

        internal void Clear()
        {
            PageNumber = 0;
            X1 = 0;
            Y1 = 0;
            X2 = 0;
            Y2 = 0;
            PageWidth = 0;
            PageHeight = 0;
            Graphics = null;
            ActualPageHeight = 0;
            ActualPageWidth = 0;
        }
    }
}