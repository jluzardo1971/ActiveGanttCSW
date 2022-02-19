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
	public class clsVerticalScrollBar
	{
        private ActiveGanttCSWCtl mp_oControl;
		private bool mp_bVisible;
		public clsVScrollBarTemplate ScrollBar;

        public clsVerticalScrollBar(ActiveGanttCSWCtl oControl)
		{
            mp_oControl = oControl;
			mp_bVisible = true;
            ScrollBar = new clsVScrollBarTemplate(mp_oControl);
			ScrollBar.LargeChange = 1;
			ScrollBar.SmallChange = 1;
			ScrollBar.Min = 1;
			ScrollBar.Max = 1;
			ScrollBar.Value = 1;
			this.ScrollBar.ValueChanged += new clsVScrollBarTemplate.ValueChangedEventHandler(this.oVScrollBar_ValueChanged);
		}

		public int Min 
		{
			get 
			{
				if (mp_oControl.Rows.Count == 0)
				{
					return 0;
				}
				else
				{
					return ScrollBar.Min;
				}
			}
		}

		public int Max 
		{
			get 
			{
				if (mp_oControl.Rows.Count == 0)
				{
					return 0;
				}
				else
				{
                    ScrollBar.Max = mp_oControl.Rows.Count - mp_oControl.Rows.HiddenRows();
                    return mp_oControl.Rows.Count - mp_oControl.Rows.HiddenRows();
				}
			}
		}

		public int Value 
		{
			get 
			{
				if (mp_oControl.Rows.Count == 0)
				{
					return 0;
				}
				else
				{
					return ScrollBar.Value;
				}
			}
			set 
			{
				if (mp_oControl.Rows.Count > 0)
				{
					if (value < 1)
					{
						value = 1;
					}
					if (value > mp_oControl.Rows.Count)
					{
						value = mp_oControl.Rows.Count;
					}
					ScrollBar.Value = value;
				}
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
            int lHiddenRows = mp_oControl.Rows.HiddenRows();
            if (mp_oControl.Rows.Count > 0)
            {
                if (ScrollBar.Value > (mp_oControl.Rows.Count - lHiddenRows))
                {
                    ScrollBar.Value = (mp_oControl.Rows.Count - lHiddenRows);
                }
                ScrollBar.Max = mp_oControl.Rows.Count - lHiddenRows;
            }
            else
            {
                Reset();
            }
		}

		internal void Reset()
		{
			ScrollBar.Min = 1;
			ScrollBar.Max = 1;
			ScrollBar.Value = 1;
		}

		internal void Position()
		{
			Left = mp_oControl.clsG.Width() - Width - mp_oControl.mt_BorderThickness;
			Top = mp_oControl.mt_TopMargin;
			Height = mp_oControl.clsG.Height() - (mp_oControl.mt_BorderThickness * 2) - mp_oControl.HorizontalScrollBar.Height;
			SmallChange = 1;
		}

		private void oVScrollBar_ValueChanged(Object sender, System.EventArgs e, int Offset)
		{
			mp_oControl.VerticalScrollBar_ValueChanged(Offset);
		}

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "VerticalScrollBar");
            oXML.InitializeWriter();
            oXML.WriteObject(ScrollBar.GetXML());
            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "VerticalScrollBar");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            ScrollBar.SetXML(oXML.ReadObject("ScrollBar"));
        }


	}
}