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

namespace AGCSW
{
	using System;
	using System.ComponentModel;
	using System.Reflection;

    public class ObjectSelectedEventArgs : System.EventArgs
	{
		
		public E_EVENTTARGET EventTarget;
		
		public int ObjectIndex;
		
		public int ParentObjectIndex;
    
		internal ObjectSelectedEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
            EventTarget = E_EVENTTARGET.EVT_NONE;
            ObjectIndex = 0;
            ParentObjectIndex = 0;
		}
	}
}