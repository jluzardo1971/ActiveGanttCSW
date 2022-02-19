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
using System.Text;

namespace AGCSW
{

    using System;
    using System.ComponentModel;
    using System.Reflection;

    public class MouseWheelEventArgs : System.EventArgs
    {
        public int X;
        public int Y;
        public E_MOUSEBUTTONS Button;
        public int Delta;

        internal MouseWheelEventArgs()
		{
			Clear();
		}

        internal void Clear()
        {
            X = 0;
            Y = 0;
            Button = E_MOUSEBUTTONS.BTN_NONE;
            Delta = 0;
        }



    }
}