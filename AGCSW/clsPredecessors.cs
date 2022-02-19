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

namespace AGCSW
{
    public class clsPredecessors : IEnumerable
	{
        private ActiveGanttCSWCtl mp_oControl;
		private clsCollectionBase mp_oCollection;

        public clsPredecessors(ActiveGanttCSWCtl oControl)
		{
            mp_oControl = oControl;
			mp_oCollection = new clsCollectionBase(mp_oControl, "Predecessor");
		}

		public int Count 
		{
			get 
			{
				return mp_oCollection.m_lCount();
			}
		}


		public clsPredecessor Item(String Index)
		{
			return (clsPredecessor) mp_oCollection.m_oItem(Index, SYS_ERRORS.PREDECESSORS_ITEM_1, SYS_ERRORS.PREDECESSORS_ITEM_2, SYS_ERRORS.PREDECESSORS_ITEM_3, SYS_ERRORS.PREDECESSORS_ITEM_4);
		}

        public clsPredecessor Item(int Index)
        {
            return (clsPredecessor)mp_oCollection.m_oReturnArrayElement(Index);
        }

        internal clsCollectionBase oCollection 
		{
			get 
			{
				return mp_oCollection;
			}
		}

        public clsPredecessor Add(String SuccessorKey, String PredecessorKey, E_CONSTRAINTTYPE PredecessorType)
        {
            return Add(SuccessorKey, PredecessorKey, PredecessorType, "", "");
        }

        public clsPredecessor Add(String SuccessorKey, String PredecessorKey, E_CONSTRAINTTYPE PredecessorType, String Key)
        {
            return Add(SuccessorKey, PredecessorKey, PredecessorType, Key, "");
        }

        public clsPredecessor Add(String SuccessorKey, String PredecessorKey, E_CONSTRAINTTYPE PredecessorType, String Key, String StyleIndex)
		{
			mp_oCollection.AddMode = true;
            clsPredecessor oPredecessor = new clsPredecessor(mp_oControl, this);
			oPredecessor.PredecessorType = PredecessorType;
			oPredecessor.PredecessorKey = PredecessorKey;
			oPredecessor.StyleIndex = StyleIndex;
			oPredecessor.Key = Key;
            oPredecessor.SuccessorKey = SuccessorKey;
			mp_oCollection.m_Add(oPredecessor, Key, SYS_ERRORS.PREDECESSORS_ADD_1, SYS_ERRORS.PREDECESSORS_ADD_2, false, SYS_ERRORS.PREDECESSORS_ADD_3);
			return oPredecessor;
		}

		public void Clear()
		{
			mp_oCollection.m_Clear();
		}

		public void Remove(String Index)
		{
			mp_oCollection.m_Remove(Index, SYS_ERRORS.PREDECESSORS_REMOVE_1, SYS_ERRORS.PREDECESSORS_REMOVE_2, SYS_ERRORS.PREDECESSORS_REMOVE_3, SYS_ERRORS.PREDECESSORS_REMOVE_4);
		}

        internal void Draw()
        {
            int lIndex = 0;
            clsPredecessor oPredecessor;
            for (lIndex = 1; lIndex <= Count; lIndex++)
            {
                oPredecessor = (clsPredecessor)mp_oCollection.m_oReturnArrayElement(lIndex);
                oPredecessor.ClearRectangles();
                if (oPredecessor.SuccessorTask.Row.Height > -1 & oPredecessor.PredecessorTask.Row.Height > -1 & oPredecessor.Visible == true)
                {
                    switch (oPredecessor.PredecessorType)
                    {
                        case E_CONSTRAINTTYPE.PCT_END_TO_END:
                            mp_DrawEndToEnd(oPredecessor);
                            break;
                        case E_CONSTRAINTTYPE.PCT_START_TO_START:
                            mp_DrawStartToStart(oPredecessor);
                            break;
                        case E_CONSTRAINTTYPE.PCT_START_TO_END:
                            mp_DrawStartToEnd(oPredecessor);
                            break;
                        case E_CONSTRAINTTYPE.PCT_END_TO_START:
                            mp_DrawEndToStart(oPredecessor);
                            break;
                    }
                }
            }
        }

        private void mp_DrawEndToEnd(clsPredecessor oPredecessor)
        {
            clsTask oPredecessorTask;
            clsTask oSuccessorTask;
            int lPredecessorCtr = 0;
            int lSuccessorCtr = 0;
            int lXOffset = 0;
            int lYOffset = 0;
            clsPredecessorStyle oStyle;
            oStyle = mp_GetPredecessorStyle(oPredecessor);
            lXOffset = oStyle.XOffset;
            lYOffset = oStyle.YOffset;
            oPredecessorTask = oPredecessor.PredecessorTask;
            oSuccessorTask = oPredecessor.SuccessorTask;
            if (mp_DrawPredecessor(oPredecessorTask, oSuccessorTask) == false)
            {
                return;
            }
            lPredecessorCtr = oPredecessorTask.Top + ((oPredecessorTask.Bottom - oPredecessorTask.Top) / 2);
            lSuccessorCtr = oSuccessorTask.Top + ((oSuccessorTask.Bottom - oSuccessorTask.Top) / 2);
            if (oPredecessorTask.Right >= oSuccessorTask.Right)
            {
                S_Point[] oPoints = new S_Point[4];
                oPoints[0].X = oPredecessorTask.Right;
                oPoints[0].Y = lPredecessorCtr;
                oPoints[1].X = oPredecessorTask.Right + lXOffset;
                oPoints[1].Y = lPredecessorCtr;
                oPoints[2].X = oPredecessorTask.Right + lXOffset;
                oPoints[2].Y = lSuccessorCtr;
                oPoints[3].X = oSuccessorTask.Right;
                oPoints[3].Y = lSuccessorCtr;
                mp_DrawPredecessorLines(oPoints, oPredecessor);
                mp_oControl.clsG.mp_DrawArrow(oPoints[3].X + 1, oPoints[3].Y, GRE_ARROWDIRECTION.AWD_LEFT, oStyle.ArrowSize, oStyle.LineColor);
            }
            else
            {
                S_Point[] oPoints = new S_Point[4];
                oPoints[0].X = oSuccessorTask.Right;
                oPoints[0].Y = lSuccessorCtr;
                oPoints[1].X = oSuccessorTask.Right + lXOffset;
                oPoints[1].Y = lSuccessorCtr;
                oPoints[2].X = oSuccessorTask.Right + lXOffset;
                oPoints[2].Y = lPredecessorCtr;
                oPoints[3].X = oPredecessorTask.Right;
                oPoints[3].Y = lPredecessorCtr;
                mp_DrawPredecessorLines(oPoints, oPredecessor);
                mp_oControl.clsG.mp_DrawArrow(oPoints[0].X + 1, oPoints[0].Y, GRE_ARROWDIRECTION.AWD_LEFT, oStyle.ArrowSize, oStyle.LineColor);
            }
        }

        private void mp_DrawStartToStart(clsPredecessor oPredecessor)
        {
            clsTask oPredecessorTask;
            clsTask oSuccessorTask;
            int lPredecessorCtr = 0;
            int lSuccessorCtr = 0;
            int lXOffset = 0;
            int lYOffset = 0;
            clsPredecessorStyle oStyle;
            oStyle = mp_GetPredecessorStyle(oPredecessor);
            lXOffset = oStyle.XOffset;
            lYOffset = oStyle.YOffset;
            oPredecessorTask = oPredecessor.PredecessorTask;
            oSuccessorTask = oPredecessor.SuccessorTask;
            if (mp_DrawPredecessor(oPredecessorTask, oSuccessorTask) == false)
            {
                return;
            }
            lPredecessorCtr = oPredecessorTask.Top + ((oPredecessorTask.Bottom - oPredecessorTask.Top) / 2);
            lSuccessorCtr = oSuccessorTask.Top + ((oSuccessorTask.Bottom - oSuccessorTask.Top) / 2);
            if (oPredecessorTask.Left <= oSuccessorTask.Left)
            {
                S_Point[] oPoints = new S_Point[4];
                oPoints[0].X = oPredecessorTask.Left;
                oPoints[0].Y = lPredecessorCtr;
                oPoints[1].X = oPredecessorTask.Left - lXOffset;
                oPoints[1].Y = lPredecessorCtr;
                oPoints[2].X = oPredecessorTask.Left - lXOffset;
                oPoints[2].Y = lSuccessorCtr;
                oPoints[3].X = oSuccessorTask.Left;
                oPoints[3].Y = lSuccessorCtr;
                mp_DrawPredecessorLines(oPoints, oPredecessor);
                mp_oControl.clsG.mp_DrawArrow(oPoints[3].X - 1, oPoints[3].Y, GRE_ARROWDIRECTION.AWD_RIGHT, oStyle.ArrowSize, oStyle.LineColor);
            }
            else
            {
                S_Point[] oPoints = new S_Point[4];
                oPoints[0].X = oSuccessorTask.Left;
                oPoints[0].Y = lSuccessorCtr;
                oPoints[1].X = oSuccessorTask.Left - lXOffset;
                oPoints[1].Y = lSuccessorCtr;
                oPoints[2].X = oSuccessorTask.Left - lXOffset;
                oPoints[2].Y = lPredecessorCtr;
                oPoints[3].X = oPredecessorTask.Left;
                oPoints[3].Y = lPredecessorCtr;
                mp_DrawPredecessorLines(oPoints, oPredecessor);
                mp_oControl.clsG.mp_DrawArrow(oPoints[0].X - 1, oPoints[0].Y, GRE_ARROWDIRECTION.AWD_RIGHT, oStyle.ArrowSize, oStyle.LineColor);
            }
        }

        private void mp_DrawStartToEnd(clsPredecessor oPredecessor)
        {
            clsTask oPredecessorTask;
            clsTask oSuccessorTask;
            int lPredecessorCtr = 0;
            int lSuccessorCtr = 0;
            int lXOffset = 0;
            int lYOffset = 0;
            clsPredecessorStyle oStyle;
            oStyle = mp_GetPredecessorStyle(oPredecessor);
            lXOffset = oStyle.XOffset;
            lYOffset = oStyle.YOffset;
            oPredecessorTask = oPredecessor.PredecessorTask;
            oSuccessorTask = oPredecessor.SuccessorTask;
            if (mp_DrawPredecessor(oPredecessorTask, oSuccessorTask) == false)
            {
                return;
            }
            lPredecessorCtr = oPredecessorTask.Top + ((oPredecessorTask.Bottom - oPredecessorTask.Top) / 2);
            lSuccessorCtr = oSuccessorTask.Top + ((oSuccessorTask.Bottom - oSuccessorTask.Top) / 2);

            //Down
            if (lPredecessorCtr < lSuccessorCtr)
            {
                S_Point[] oPoints = new S_Point[6];
                oPoints[0].X = oPredecessorTask.Left;
                oPoints[0].Y = lPredecessorCtr;
                oPoints[1].X = oPredecessorTask.Left - lXOffset;
                oPoints[1].Y = lPredecessorCtr;
                oPoints[2].X = oPredecessorTask.Left - lXOffset;
                oPoints[2].Y = oPredecessorTask.Bottom + lYOffset;
                oPoints[3].X = oSuccessorTask.Right + lXOffset;
                oPoints[3].Y = oPredecessorTask.Bottom + lYOffset;
                oPoints[4].X = oSuccessorTask.Right + lXOffset;
                oPoints[4].Y = lSuccessorCtr;
                oPoints[5].X = oSuccessorTask.Right;
                oPoints[5].Y = lSuccessorCtr;
                mp_DrawPredecessorLines(oPoints, oPredecessor);
                mp_oControl.clsG.mp_DrawArrow(oPoints[5].X + 1, oPoints[5].Y, GRE_ARROWDIRECTION.AWD_LEFT, oStyle.ArrowSize, oStyle.LineColor);
            }
            else
            {
                S_Point[] oPoints = new S_Point[6];
                oPoints[0].X = oPredecessorTask.Left;
                oPoints[0].Y = lPredecessorCtr;
                oPoints[1].X = oPredecessorTask.Left - lXOffset;
                oPoints[1].Y = lPredecessorCtr;
                oPoints[2].X = oPredecessorTask.Left - lXOffset;
                oPoints[2].Y = oPredecessorTask.Top - lYOffset;
                oPoints[3].X = oSuccessorTask.Right + lXOffset;
                oPoints[3].Y = oPredecessorTask.Top - lYOffset;
                oPoints[4].X = oSuccessorTask.Right + lXOffset;
                oPoints[4].Y = lSuccessorCtr;
                oPoints[5].X = oSuccessorTask.Right;
                oPoints[5].Y = lSuccessorCtr;
                mp_DrawPredecessorLines(oPoints, oPredecessor);
                mp_oControl.clsG.mp_DrawArrow(oPoints[5].X + 1, oPoints[5].Y, GRE_ARROWDIRECTION.AWD_LEFT, oStyle.ArrowSize, oStyle.LineColor);
            }
        }

        private void mp_DrawEndToStart(clsPredecessor oPredecessor)
        {
            clsTask oPredecessorTask = null;
            clsTask oSuccessorTask = null;
            int lPredecessorCtr = 0;
            int lSuccessorCtr = 0;
            int lXOffset = 0;
            int lYOffset = 0;
            clsPredecessorStyle oStyle = null;
            oStyle = mp_GetPredecessorStyle(oPredecessor);
            lXOffset = oStyle.XOffset;
            lYOffset = oStyle.YOffset;
            oPredecessorTask = oPredecessor.PredecessorTask;
            oSuccessorTask = oPredecessor.SuccessorTask;
            if (mp_DrawPredecessor(oPredecessorTask, oSuccessorTask) == false)
            {
                return;
            }
            lPredecessorCtr = oPredecessorTask.Top + ((oPredecessorTask.Bottom - oPredecessorTask.Top) / 2);
            lSuccessorCtr = oSuccessorTask.Top + ((oSuccessorTask.Bottom - oSuccessorTask.Top) / 2);
            if (oPredecessor.PredecessorTask.Right <= oPredecessor.SuccessorTask.Left)
            {
                ////With Lag
                ////Down
                if (lPredecessorCtr < lSuccessorCtr)
                {
                    S_Point[] oPoints = new S_Point[3];
                    oPoints[0].X = oPredecessorTask.Right;
                    oPoints[0].Y = lPredecessorCtr;
                    if (oSuccessorTask.Type == E_OBJECTTYPE.OT_TASK)
                    {
                        oPoints[1].X = oSuccessorTask.Left + lXOffset;
                        oPoints[1].Y = lPredecessorCtr;
                        oPoints[2].X = oSuccessorTask.Left + lXOffset;
                        oPoints[2].Y = oSuccessorTask.Top;
                    }
                    else
                    {
                        oPoints[1].X = mp_oControl.MathLib.GetXCoordinateFromDate(oSuccessorTask.StartDate);
                        oPoints[1].Y = lPredecessorCtr;
                        oPoints[2].X = mp_oControl.MathLib.GetXCoordinateFromDate(oSuccessorTask.StartDate);
                        oPoints[2].Y = oSuccessorTask.Top;
                    }
                    mp_DrawPredecessorLines(oPoints, oPredecessor);
                    mp_oControl.clsG.mp_DrawArrow(oPoints[2].X, oPoints[2].Y - 1, GRE_ARROWDIRECTION.AWD_DOWN, oStyle.ArrowSize, oStyle.LineColor);
                }
                else
                {
                    S_Point[] oPoints = new S_Point[3];
                    oPoints[0].X = oPredecessorTask.Right;
                    oPoints[0].Y = lPredecessorCtr;
                    if (oSuccessorTask.Type == E_OBJECTTYPE.OT_TASK)
                    {
                        oPoints[1].X = oSuccessorTask.Left + lXOffset;
                        oPoints[1].Y = lPredecessorCtr;
                        oPoints[2].X = oSuccessorTask.Left + lXOffset;
                        oPoints[2].Y = oSuccessorTask.Bottom;
                    }
                    else
                    {
                        oPoints[1].X = mp_oControl.MathLib.GetXCoordinateFromDate(oSuccessorTask.StartDate);
                        oPoints[1].Y = lPredecessorCtr;
                        oPoints[2].X = mp_oControl.MathLib.GetXCoordinateFromDate(oSuccessorTask.StartDate);
                        oPoints[2].Y = oSuccessorTask.Bottom;
                    }
                    mp_DrawPredecessorLines(oPoints, oPredecessor);
                    mp_oControl.clsG.mp_DrawArrow(oPoints[2].X, oPoints[2].Y + 1, GRE_ARROWDIRECTION.AWD_UP, oStyle.ArrowSize, oStyle.LineColor);
                }
            }
            else
            {
                ////With Lead
                ////Down
                if (lPredecessorCtr < lSuccessorCtr)
                {
                    S_Point[] oPoints = new S_Point[6];
                    oPoints[0].X = oPredecessorTask.Right;
                    oPoints[0].Y = lPredecessorCtr;
                    oPoints[1].X = oPredecessorTask.Right + lXOffset;
                    oPoints[1].Y = lPredecessorCtr;
                    oPoints[2].X = oPredecessorTask.Right + lXOffset;
                    oPoints[2].Y = lSuccessorCtr - lYOffset;
                    oPoints[3].X = oSuccessorTask.Left - lXOffset;
                    oPoints[3].Y = lSuccessorCtr - lYOffset;
                    oPoints[4].X = oSuccessorTask.Left - lXOffset;
                    oPoints[4].Y = lSuccessorCtr;
                    oPoints[5].X = oSuccessorTask.Left;
                    oPoints[5].Y = lSuccessorCtr;
                    mp_DrawPredecessorLines(oPoints, oPredecessor);
                    mp_oControl.clsG.mp_DrawArrow(oPoints[5].X - 1, oPoints[5].Y, GRE_ARROWDIRECTION.AWD_RIGHT, oStyle.ArrowSize, oStyle.LineColor);
                    //// Up
                }
                else
                {
                    S_Point[] oPoints = new S_Point[6];
                    oPoints[0].X = oPredecessorTask.Right;
                    oPoints[0].Y = lPredecessorCtr;
                    oPoints[1].X = oPredecessorTask.Right + lXOffset;
                    oPoints[1].Y = lPredecessorCtr;
                    oPoints[2].X = oPredecessorTask.Right + lXOffset;
                    oPoints[2].Y = lSuccessorCtr + lYOffset;
                    oPoints[3].X = oSuccessorTask.Left - lXOffset;
                    oPoints[3].Y = lSuccessorCtr + lYOffset;
                    oPoints[4].X = oSuccessorTask.Left - lXOffset;
                    oPoints[4].Y = lSuccessorCtr;
                    oPoints[5].X = oSuccessorTask.Left;
                    oPoints[5].Y = lSuccessorCtr;
                    mp_DrawPredecessorLines(oPoints, oPredecessor);
                    mp_oControl.clsG.mp_DrawArrow(oPoints[5].X - 1, oPoints[5].Y, GRE_ARROWDIRECTION.AWD_RIGHT, oStyle.ArrowSize, oStyle.LineColor);
                }
            }
        }

        private void mp_DrawPredecessorLines(S_Point[] oPoints, clsPredecessor oPredecessor)
        {
            int i = 0;
            for (i = 0; i <= oPoints.GetUpperBound(0) - 1; i++)
            {
                clsPredecessorStyle oStyle;
                oStyle = mp_GetPredecessorStyle(oPredecessor);
                mp_oControl.clsG.mp_DrawLine(oPoints[i].X, oPoints[i].Y, oPoints[i + 1].X, oPoints[i + 1].Y, GRE_LINETYPE.LT_NORMAL, oStyle.LineColor, oStyle.LineStyle, oStyle.LineWidth);
                S_Rectangle oRectangle = new S_Rectangle();
                ////Vertical Line
                if (oPoints[i].X == oPoints[i + 1].X)
                {
                    oRectangle.X1 = oPoints[i].X - mp_oControl.CurrentViewObject.ClientArea.PredecessorSelectionOffset;
                    oRectangle.X2 = oPoints[i + 1].X + mp_oControl.CurrentViewObject.ClientArea.PredecessorSelectionOffset;
                    if (oPoints[i].Y < oPoints[i + 1].Y)
                    {
                        oRectangle.Y1 = oPoints[i].Y;
                        oRectangle.Y2 = oPoints[i + 1].Y;
                    }
                    else
                    {
                        oRectangle.Y1 = oPoints[i + 1].Y;
                        oRectangle.Y2 = oPoints[i].Y;
                    }
                    ////Horizontal Line
                }
                else if (oPoints[i].Y == oPoints[i + 1].Y)
                {
                    oRectangle.Y1 = oPoints[i].Y - mp_oControl.CurrentViewObject.ClientArea.PredecessorSelectionOffset;
                    oRectangle.Y2 = oPoints[i + 1].Y + mp_oControl.CurrentViewObject.ClientArea.PredecessorSelectionOffset;
                    if (oPoints[i].X < oPoints[i + 1].X)
                    {
                        oRectangle.X1 = oPoints[i].X;
                        oRectangle.X2 = oPoints[i + 1].X;
                    }
                    else
                    {
                        oRectangle.X1 = oPoints[i + 1].X;
                        oRectangle.X2 = oPoints[i].X;
                    }
                }
                oPredecessor.AddRectangle(oRectangle);
            }
        }

        private clsPredecessorStyle mp_GetPredecessorStyle(clsPredecessor oPredecessor)
        {
            clsPredecessorStyle oStyle;
            if (oPredecessor.mp_bWarning == false)
            {
                if (oPredecessor.Index == mp_oControl.SelectedPredecessorIndex)
                {
                    oStyle = oPredecessor.SelectedStyle.PredecessorStyle;
                }
                else
                {
                    oStyle = oPredecessor.Style.PredecessorStyle;
                }
            }
            else
            {
                oStyle = oPredecessor.WarningStyle.PredecessorStyle;
            }
            return oStyle;
        }

        private bool mp_DrawPredecessor(clsTask oTask1, clsTask oTask2)
        {
            if (oTask1.Row.ClientAreaVisibility == E_CLIENTAREAVISIBILITY.VS_ABOVEVISIBLEAREA & oTask2.Row.ClientAreaVisibility == E_CLIENTAREAVISIBILITY.VS_ABOVEVISIBLEAREA)
            {
                return false;
            }
            if (oTask1.Row.ClientAreaVisibility == E_CLIENTAREAVISIBILITY.VS_BELOWVISIBLEAREA & oTask2.Row.ClientAreaVisibility == E_CLIENTAREAVISIBILITY.VS_BELOWVISIBLEAREA)
            {
                return false;
            }
            if (oTask1.ClientAreaVisiblity == E_CLIENTAREAVISIBILITY.VS_RIGHTOFVISIBLEAREA & oTask2.ClientAreaVisiblity == E_CLIENTAREAVISIBILITY.VS_RIGHTOFVISIBLEAREA)
            {
                return false;
            }
            if (oTask1.ClientAreaVisiblity == E_CLIENTAREAVISIBILITY.VS_LEFTOFVISIBLEAREA & oTask2.ClientAreaVisiblity == E_CLIENTAREAVISIBILITY.VS_LEFTOFVISIBLEAREA)
            {
                return false;
            }
            return true;
        }

		public String GetXML()
		{
			int lIndex;
			clsPredecessor oPredecessor;
			clsXML oXML = new clsXML(mp_oControl, "Predecessors");
			oXML.InitializeWriter();
			for (lIndex = 1;lIndex <= Count;lIndex++) 
			{
				oPredecessor = (clsPredecessor) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oPredecessor.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(String sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML(mp_oControl, "Predecessors");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			mp_oCollection.m_Clear();
			for (lIndex = 1;lIndex <= oXML.ReadCollectionCount();lIndex++) 
			{
                clsPredecessor oPredecessor = new clsPredecessor(mp_oControl, this);
				oPredecessor.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				mp_oCollection.m_Add(oPredecessor, oPredecessor.Key, SYS_ERRORS.PREDECESSORS_ADD_1, SYS_ERRORS.PREDECESSORS_ADD_2, false, SYS_ERRORS.PREDECESSORS_ADD_3);
				oPredecessor = null;
			}
		}

        public IEnumerator GetEnumerator()
        {
            return mp_oCollection.mp_aoCollection.GetEnumerator();
        }


	}
}