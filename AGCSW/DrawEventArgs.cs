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

    public class DrawEventArgs : System.EventArgs
	{
		
		public E_EVENTTARGET EventTarget;
		
		public bool CustomDraw;
		
		public int ObjectIndex;
		
		public int ParentObjectIndex;

        public DrawingContext Graphics;
    
		internal DrawEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
            EventTarget = E_EVENTTARGET.EVT_NONE;
			CustomDraw = false;
			ObjectIndex = 0;
			ParentObjectIndex = 0;
			Graphics = null;
		}
	}


}