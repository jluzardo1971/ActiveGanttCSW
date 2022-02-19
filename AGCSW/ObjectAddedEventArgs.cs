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


    public class ObjectAddedEventArgs : System.EventArgs
	{
		
		public int TaskIndex;
		
		public int PredecessorObjectIndex;
		
		public int PredecessorTaskIndex;
		
		public E_CONSTRAINTTYPE PredecessorType;
		
		public string TaskKey;
		
		public string PredecessorTaskKey;
		
		public E_EVENTTARGET EventTarget;
    
		internal ObjectAddedEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
            TaskIndex = 0;
            PredecessorObjectIndex = 0;
            PredecessorTaskIndex = 0;
            PredecessorType = E_CONSTRAINTTYPE.PCT_END_TO_START;
            TaskKey = "";
            PredecessorTaskKey = "";
            EventTarget = E_EVENTTARGET.EVT_NONE;
		}
	}
}