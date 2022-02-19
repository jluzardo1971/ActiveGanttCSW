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


    public class CustomTierDrawEventArgs : System.EventArgs
	{
		
		public string Text;
		public bool CustomDraw;
		public string StyleIndex;
		public E_TIERPOSITION TierPosition;
		public DateTime StartDate;
        public DateTime EndDate;
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;
		public int LeftTrim;
		public int RightTrim;
		public DrawingContext Graphics;
        public E_INTERVAL Interval;
        public int Factor;
    
    
		internal CustomTierDrawEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
			Text = "";
			CustomDraw = false;
			StyleIndex = "";
			TierPosition = E_TIERPOSITION.SP_UPPER;
            StartDate = new DateTime();
            EndDate = new DateTime();
			Left = 0;
			Top = 0;
			Right = 0;
			Bottom = 0;
			LeftTrim = 0;
			RightTrim = 0;
			Graphics = null;
            Interval = E_INTERVAL.IL_SECOND;
            Factor = 0;
		}
	}

}