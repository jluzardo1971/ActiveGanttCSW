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
using System.Windows.Controls;


namespace AGCSW
{

	using System;
	using System.ComponentModel;
	using System.Reflection;


    public class ToolTipEventArgs : System.EventArgs
	{
		
		public int InitialRowIndex;
		
		public int FinalRowIndex;
		
		public int TaskIndex;
		
		public int MilestoneIndex;
		
		public int PercentageIndex;
		
		public int RowIndex;
		
		public int CellIndex;
		
		public int ColumnIndex;
		
		public DateTime InitialStartDate;

        public DateTime InitialEndDate;

        public DateTime StartDate;

        public DateTime EndDate;
		
		public int XStart;
		
		public int XEnd;
		
		public E_OPERATION Operation;
		
		public E_EVENTTARGET EventTarget;
		
		public string TaskPosition;
		
		public string PredecessorPosition;
		
		public int X;
		
		public int Y;
		
		public int X1;
		
		public int Y1;
		
		public int X2;
		
		public int Y2;
		
		public bool CustomDraw;
		
		public Canvas Graphics;
		
		public E_TOOLTIPTYPE ToolTipType;
    
		internal ToolTipEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
            InitialRowIndex = 0;
            FinalRowIndex = 0;
            RowIndex = 0;
            TaskIndex = 0;
            MilestoneIndex = 0;
            PercentageIndex = 0;
            CellIndex = 0;
            ColumnIndex = 0;
            StartDate = new DateTime();
            EndDate = new DateTime();
            InitialStartDate = new DateTime();
            InitialEndDate = new DateTime();
            XStart = 0;
            XEnd = 0;
            X = 0;
            Y = 0;
            X1 = 0;
            Y1 = 0;
            X2 = 0;
            Y2 = 0;
            Operation = E_OPERATION.EO_NONE;
            EventTarget = E_EVENTTARGET.EVT_NONE;
            ToolTipType = E_TOOLTIPTYPE.TPT_HOVER;
		}
	}
}