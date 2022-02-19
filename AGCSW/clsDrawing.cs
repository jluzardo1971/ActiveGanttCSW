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
using System.Windows.Controls;


namespace AGCSW
{
	public class clsDrawing
	{

        private ActiveGanttCSWCtl mp_oControl;

        internal clsDrawing(ActiveGanttCSWCtl oControl)
		{
            mp_oControl = oControl;
		}
    
		
		public DrawingContext GraphicsInfo()
		{
			return mp_oControl.clsG.oGraphics;
		}
    
		
		public void DrawLine(int X1, int Y1, int X2, int Y2, Color LineColor, GRE_LINEDRAWSTYLE LineStyle, int LineWidth)
		{
			mp_oControl.clsG.mp_DrawLine(X1, Y1, X2, Y2, GRE_LINETYPE.LT_NORMAL, LineColor, LineStyle, LineWidth, true);
		}
    
		
		public void DrawBorder(int X1, int Y1, int X2, int Y2, Color LineColor, GRE_LINEDRAWSTYLE LineStyle, int LineWidth)
		{
			mp_oControl.clsG.mp_DrawLine(X1, Y1, X2, Y2, GRE_LINETYPE.LT_BORDER, LineColor, LineStyle, LineWidth, true);
		}
    
		
		public void DrawRectangle(int X1, int Y1, int X2, int Y2, Color LineColor, GRE_LINEDRAWSTYLE LineStyle, int LineWidth)
		{
			mp_oControl.clsG.mp_DrawLine(X1, Y1, X2, Y2, GRE_LINETYPE.LT_FILLED, LineColor, LineStyle, LineWidth, true);
		}


        public void DrawText(int X1, int Y1, int X2, int Y2, string Text, clsTextFlags TextFlags, Color TextColor, Font TextFont)
		{
			mp_oControl.clsG.mp_DrawTextEx(X1, Y1, X2, Y2, Text, TextFlags, TextColor, TextFont, true);
		}
    
		
		public void DrawAlignedText(int X1, int Y1, int X2, int Y2, string Text, GRE_HORIZONTALALIGNMENT HorizontalAlignment, GRE_VERTICALALIGNMENT VerticalAlignment, Color TextColor, Font TextFont)
		{
			mp_oControl.clsG.mp_DrawAlignedText(X1, Y1, X2, Y2, Text, HorizontalAlignment, VerticalAlignment, TextColor, TextFont, true);
		}
    
		
		public void PaintImage(Image Image, int X1, int Y1, int X2, int Y2)
		{
			mp_oControl.clsG.mp_PaintImage(Image, X1, Y1, X2, Y2, 0, 0, true);
		}

        public void DrawObject(int X1, int Y1, int X2, int Y2, string StyleIndex, string Text, bool Selected, Image Image, GRE_DRAWINGOBJECT ObjectType)
        {
            if (ObjectType == GRE_DRAWINGOBJECT.DO_GENERAL)
            {
                mp_oControl.clsG.mp_DrawItem(X1, Y1, X2, Y2, StyleIndex, Text, Selected, Image, 0, 0,
                null);
            }
            else if (ObjectType == GRE_DRAWINGOBJECT.DO_MILESTONE)
            {
                mp_oControl.clsG.mp_DrawItemI(X1, Y1, X2, Y2, StyleIndex, Text, Selected, Image, 0, 0,
                null);
            }
        }
    
		//Public Sub mp_ClearClipRegion()
		// mp_oControl.clsG.mp_ClearClipRegion()
		//End Sub
    
	}
}