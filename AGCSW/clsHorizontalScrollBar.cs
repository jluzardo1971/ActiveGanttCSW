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


	public class clsHorizontalScrollBar
	{
        private ActiveGanttCSWCtl mp_oControl;
		private bool mp_bVisible;
		public clsHScrollBarTemplate ScrollBar;

        public clsHorizontalScrollBar(ActiveGanttCSWCtl oControl)
		{
            mp_oControl = oControl;
			mp_bVisible = true;
            ScrollBar = new clsHScrollBarTemplate(mp_oControl);
			ScrollBar.LargeChange = 1;
			ScrollBar.SmallChange = 1;
			ScrollBar.Min = 0;
			ScrollBar.Max = 0;
			ScrollBar.Value = 0;
			this.ScrollBar.ValueChanged += new clsHScrollBarTemplate.ValueChangedEventHandler(this.oHScrollBar_ValueChanged);
		}

		public int Min 
		{
			get 
			{
				return 0;
			}
		}

		public int Max 
		{
			get 
			{
				return ScrollBar.Max;
			}
		}

		public int Value 
		{
			get 
			{
				return ScrollBar.Value;
			}
			set 
			{
				ScrollBar.Value = value;
			}
		}

        internal bool mf_Visible
        {
            get
            {
                return mp_bVisible;
            }
        }

		public bool Visible 
		{
			get 
			{
                if (ScrollBar.State != E_SCROLLSTATE.SS_SHOWN)
                {
                    return false;
                }
                else
                {
                    return mp_bVisible;
                }
			}
			set 
			{
				mp_bVisible = value;
			}
		}

		internal E_SCROLLSTATE State 
		{
			get 
			{
				return ScrollBar.State;
			}
			set 
			{
				ScrollBar.State = value;
			}
		}

		internal int Width 
		{
			get 
			{
				return ScrollBar.Width;
			}
			set 
			{
				ScrollBar.Width = value;
			}
		}

		internal int Height 
		{
			get 
			{
				return ScrollBar.Height;
			}
			set 
			{
				ScrollBar.Height = value;
			}
		}

		internal int Left 
		{
			get 
			{
				return ScrollBar.Left;
			}
			set 
			{
				ScrollBar.Left = value;
			}
		}

		internal int Top 
		{
			get 
			{
				return ScrollBar.Top;
			}
			set 
			{
				ScrollBar.Top = value;
			}
		}

		public int SmallChange 
		{
			get 
			{
				return ScrollBar.SmallChange;
			}
			set 
			{
				ScrollBar.SmallChange = value;
			}
		}

		public int LargeChange 
		{
			get 
			{
				return ScrollBar.LargeChange;
			}
			set 
			{
				ScrollBar.LargeChange = value;
			}
		}

		internal void Update()
		{

		}

		internal void Reset()
		{
			ScrollBar.Min = 0;
			ScrollBar.Max = 0;
			ScrollBar.Value = 0;
		}

		internal void Position()
		{
			Left = mp_oControl.mt_BorderThickness;
			Top = mp_oControl.clsG.Height() - Height - mp_oControl.mt_BorderThickness;
			if (mp_oControl.Splitter.Left > 0)
			{
				Width = mp_oControl.Splitter.Left;
			}
			ScrollBar.Max = mp_oControl.Columns.Width - mp_oControl.Splitter.Position;
		}

		private void oHScrollBar_ValueChanged(Object sender, System.EventArgs e, int Offset)
		{
			mp_oControl.HorizontalScrollBar_ValueChanged(Offset);
		}

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "HorizontalScrollBar");
            oXML.InitializeWriter();
            oXML.WriteObject(ScrollBar.GetXML());
            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "HorizontalScrollBar");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            ScrollBar.SetXML(oXML.ReadObject("ScrollBar"));
        }


	}
}