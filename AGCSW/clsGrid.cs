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

	public class clsGrid
	{
        private ActiveGanttCSWCtl mp_oControl;
		private bool mp_bVerticalLines;
		private bool mp_bSnapToGrid;
		private bool mp_bSnapToGridOnSelection;
		private System.Windows.Media.Color mp_clrColor;
        private E_INTERVAL mp_yInterval;
		private int mp_lFactor;
		private clsTimeLine mp_oTimeLine;

        internal clsGrid(ActiveGanttCSWCtl oControl, clsTimeLine oTimeLine)
        {
            mp_oControl = oControl;
            mp_oTimeLine = oTimeLine;
            Clear();
        }

		~clsGrid()
		{

		}

		public bool VerticalLines 
		{
			get 
			{
				return mp_bVerticalLines;
			}
			set 
			{
				mp_bVerticalLines = value;
			}
		}

		public bool SnapToGrid 
		{
			get 
			{
				return mp_bSnapToGrid;
			}
			set 
			{
				mp_bSnapToGrid = value;
			}
		}

		public bool SnapToGridOnSelection 
		{
			get 
			{
				return mp_bSnapToGridOnSelection;
			}
			set 
			{
				mp_bSnapToGridOnSelection = value;
			}
		}

		public Color Color 
		{
			get 
			{
				return mp_clrColor;
			}
			set 
			{
				mp_clrColor = value;
			}
		}

        public E_INTERVAL Interval
        {
            get
            {
                return mp_yInterval;
            }
            set
            {
                mp_yInterval = value;
            }
        }

        public int Factor
        {
            get
            {
                return mp_lFactor;
            }
            set
            {
                mp_lFactor = value;
            }
        }

        internal void Draw()
        {
            DateTime dtBuff;
            if (mp_bVerticalLines == false)
            {
                return;
            }
            if (mp_oControl.MathLib.GetXCoordinateFromDate(mp_oControl.MathLib.DateTimeAdd(mp_yInterval, mp_lFactor, mp_oTimeLine.StartDate)) - mp_oControl.MathLib.GetXCoordinateFromDate(mp_oTimeLine.StartDate) < 5)
            {
                return;
            }
            mp_oControl.clsG.mp_ClipRegion(mp_oTimeLine.f_lStart, mp_oControl.CurrentViewObject.ClientArea.Top, mp_oTimeLine.f_lEnd, mp_oControl.CurrentViewObject.ClientArea.Bottom, true);
            dtBuff = mp_oControl.MathLib.RoundDate(mp_yInterval, mp_lFactor, mp_oTimeLine.StartDate);
            if (mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff) >= mp_oTimeLine.f_lStart)
            {
                mp_PaintVerticalGridLine(mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff), GRE_LINEDRAWSTYLE.LDS_SOLID);
            }
            while (dtBuff < mp_oTimeLine.EndDate)
            {
                dtBuff = mp_oControl.MathLib.DateTimeAdd(mp_yInterval, mp_lFactor, dtBuff);
                mp_PaintVerticalGridLine(mp_oControl.MathLib.GetXCoordinateFromDate(dtBuff), GRE_LINEDRAWSTYLE.LDS_SOLID);
            }
        }

		private void mp_PaintVerticalGridLine(int fXCoordinate, GRE_LINEDRAWSTYLE v_lDrawStyle)
		{
            if (mp_bVerticalLines == true)
            {
                mp_oControl.clsG.mp_DrawLine(fXCoordinate, mp_oControl.CurrentViewObject.ClientArea.Top, fXCoordinate, mp_oControl.Rows.TopOffset, GRE_LINETYPE.LT_NORMAL, mp_clrColor, v_lDrawStyle, 1, true);
            }
		}

		public String GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "Grid");
			oXML.InitializeWriter();
			oXML.WriteProperty("Color", mp_clrColor);
			oXML.WriteProperty("Interval", mp_yInterval);
			oXML.WriteProperty("Factor", mp_lFactor);
			oXML.WriteProperty("SnapToGrid", mp_bSnapToGrid);
			oXML.WriteProperty("SnapToGridOnSelection", mp_bSnapToGridOnSelection);
			oXML.WriteProperty("VerticalLines", mp_bVerticalLines);
			return oXML.GetXML();
		}

		public void SetXML(String sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "Grid");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("VerticalLines", ref mp_bVerticalLines);
			oXML.ReadProperty("SnapToGrid", ref mp_bSnapToGrid);
			oXML.ReadProperty("SnapToGridOnSelection", ref mp_bSnapToGridOnSelection);
			oXML.ReadProperty("Color", ref mp_clrColor);
			oXML.ReadProperty("Interval", ref mp_yInterval);
			oXML.ReadProperty("Factor", ref mp_lFactor);
		}

        internal void Clear()
        {
            mp_clrColor = Color.FromArgb(255, 192, 192, 192);
            mp_yInterval = E_INTERVAL.IL_MINUTE;
            mp_lFactor = 15;
            mp_bSnapToGrid = false;
            mp_bSnapToGridOnSelection = true;
            mp_bVerticalLines = false;
        }

        internal void Clone(clsGrid oClone)
        {
            oClone.Color = mp_clrColor;
            oClone.Interval = mp_yInterval;
            oClone.Factor = mp_lFactor;
            oClone.SnapToGrid = mp_bSnapToGrid;
            oClone.SnapToGridOnSelection = mp_bSnapToGridOnSelection;
            oClone.VerticalLines = mp_bVerticalLines;
        }

	}
}