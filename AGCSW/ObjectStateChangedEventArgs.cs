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


    public class ObjectStateChangedEventArgs : System.EventArgs
	{
		
		public E_EVENTTARGET EventTarget;	
		public int Index;
		public bool Cancel;
		public int DestinationIndex;
		public int InitialRowIndex;
		public int FinalRowIndex;
		public int InitialColumnIndex;
		public int FinalColumnIndex;
        public DateTime StartDate;
        public DateTime EndDate;
        public E_CHANGETYPE ChangeType;
    
		internal ObjectStateChangedEventArgs()
		{
			Clear();
		}
    
		internal void Clear()
		{
            EventTarget = E_EVENTTARGET.EVT_NONE;
            Index = 0;
            StartDate = new DateTime();
            EndDate = new DateTime();
            Cancel = false;
            DestinationIndex = 0;
            InitialRowIndex = 0;
            FinalRowIndex = 0;
            InitialColumnIndex = 0;
            FinalColumnIndex = 0;
            ChangeType = E_CHANGETYPE.CT_MOVE;
		}
	}
}