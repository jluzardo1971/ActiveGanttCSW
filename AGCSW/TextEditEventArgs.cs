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
using System.Linq;
using System.Text;

namespace AGCSW
{
    public class TextEditEventArgs : System.EventArgs
    {
        public E_TEXTOBJECTTYPE ObjectType;
        public int ObjectIndex;
        public int ParentObjectIndex;
        public string Text;

        internal TextEditEventArgs()
        {
            Clear();
        }

        internal void Clear()
        {
            ObjectType = E_TEXTOBJECTTYPE.TOT_TASK;
            ObjectIndex = 0;
            ParentObjectIndex = 0;
            Text = "";
        }
    }
}