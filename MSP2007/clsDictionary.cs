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
using System.Collections;

namespace MSP2007
{
    internal class clsDictionary : DictionaryBase
    {
        int mp_lKey = 1;

        public clsDictionary()
        {
        }

        public void Add(int Value, String Key)
        {
            this.Dictionary.Add(Key, Value);
        }

        public void Add(String Value)
        {
            this.Dictionary.Add(mp_lKey, Value);
            mp_lKey = mp_lKey + 1;
        }

        public bool Contains(string Key)
        {
            return this.Dictionary.Contains(Key);
        }

        public String StrItem(int Index)
        {
            return (String)this.Dictionary[Index];
        }

        public int this[string Key]
        {
            get { return (int)this.Dictionary[Key]; }

            set { this.Dictionary[Key] = value; }
        }

        public System.Collections.ICollection Keys
        {
            get { return this.Dictionary.Keys; }
        }
    }
}