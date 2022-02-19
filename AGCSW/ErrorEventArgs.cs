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

    public class ErrorEventArgs : System.EventArgs
	{
		
		public int Number;
		
		public string Description;
		
		public string Source;
    
		internal ErrorEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
			Number = 0;
			Description = "";
			Source = "";
		}
	}
}