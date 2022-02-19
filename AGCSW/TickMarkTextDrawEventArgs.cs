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
    public class TickMarkTextDrawEventArgs
    {

        public string Text;
        public bool CustomDraw;

        public DateTime dtDate;
        internal TickMarkTextDrawEventArgs()
        {
            Clear();
        }

        internal void Clear()
        {
            CustomDraw = false;
            Text = "";
            dtDate = new DateTime();
        }

    }
}