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
using System.ComponentModel;
using System.Reflection;

namespace AGCSW
{

    public class MouseEventArgs : System.EventArgs
	{
		public int X;
		
		public int Y;
		
		public E_EVENTTARGET EventTarget;
		
		public E_OPERATION Operation;
		
		public E_MOUSEBUTTONS Button;
		
		public bool Cancel;

    
		internal MouseEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
            X = 0;
            Y = 0;
            EventTarget = E_EVENTTARGET.EVT_NONE;
            Operation = E_OPERATION.EO_NONE;
            Button = E_MOUSEBUTTONS.BTN_NONE;
            Cancel = false;
		}
	}
}