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
using System.Windows.Media;


namespace AGCSW
{

	using System;
	using System.ComponentModel;
	using System.Reflection;

    public class PredecessorDrawEventArgs : System.EventArgs
	{
		
		public bool CustomDraw;
		
		public DrawingContext Graphics;
		
		public int PredecessorIndex;
		
		public int TaskIndex;
		
		public E_CONSTRAINTTYPE PredecessorType;
    
		internal PredecessorDrawEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
            CustomDraw = false;
            Graphics = null;
            PredecessorIndex = 0;
            TaskIndex = 0;
            PredecessorType = E_CONSTRAINTTYPE.PCT_END_TO_START;
		}
	}

}