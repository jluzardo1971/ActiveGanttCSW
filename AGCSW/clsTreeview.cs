﻿// ----------------------------------------------------------------------------------------
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
	public class clsTreeview
	{
    
		private struct S_CHECKBOXCLICK
		{
			public int lNodeIndex;
			public void Clear()
			{
				lNodeIndex = 0;
			}
		}
    
		private struct S_SIGNCLICK
		{
			public int lNodeIndex;
			public void Clear()
			{
				lNodeIndex = 0;
			}
		}
    
		private struct S_ROWMOVEMENT
		{
			public int lRowIndex;
			public int lDestinationRowIndex;
			public void Clear()
			{
				lRowIndex = 0;
				lDestinationRowIndex = 0;
			}
		}
    
		private struct S_ROWSIZING
		{
			public int lRowIndex;
			public void Clear()
			{
				lRowIndex = 0;
			}
		}
    
		private struct S_ROWSELECTION
		{
			public int lRowIndex;
			public int lCellIndex;
			public void Clear()
			{
				lRowIndex = 0;
				lCellIndex = 0;
			}
		}

        private ActiveGanttCSWCtl mp_oControl;
		private int mp_lLastVisibleNode;
		private int mp_lIndentation;
		private Color mp_clrBackColor;
		private Color mp_clrCheckBoxBorderColor;
        private Color mp_clrCheckBoxBackColor;
		private Color mp_clrCheckBoxMarkColor;
        private GRE_BACKGROUNDMODE mp_yCheckBoxBackgroundMode;
		private Color mp_clrSelectedBackColor;
		private Color mp_clrSelectedForeColor;
		private Color mp_clrTreeLineColor;
		private Color mp_clrPlusMinusBorderColor;
		private Color mp_clrPlusMinusSignColor;
        private Color mp_clrPlusMinusBackColor;
        private GRE_BACKGROUNDMODE mp_yPlusMinusBackgroundMode;
        private Color mp_clrExpandIconForeColor;
        private Color mp_clrExpandIconBackColor;
        private Color mp_clrExpandIconDropShadowColor;
        private Color mp_clrCollapseIconForeColor;
        private Color mp_clrCollapseIconDropShadowColor;
		private bool mp_bCheckBoxes;
		private bool mp_bTreeLines;
		private bool mp_bImages;
        private E_TREEVIEWMODE mp_yTreeviewMode;
		private bool mp_bFullColumnSelect;
		private bool mp_bExpansionOnSelection;
		private string mp_sPathSeparator;
		private E_OPERATION mp_yOperation;
		private S_CHECKBOXCLICK s_chkCLK;
		private S_SIGNCLICK s_sgnCLK;
		private S_ROWMOVEMENT s_rowMVT;
		private S_ROWSIZING s_rowSZ;
		private S_ROWSELECTION s_rowSEL;

        public clsTreeview(ActiveGanttCSWCtl oControl)
		{
            mp_oControl = oControl;
			mp_lLastVisibleNode = 0;
			mp_lIndentation = 20;
			mp_clrBackColor = Color.FromArgb(255, 255, 255, 255);
			mp_clrCheckBoxBorderColor = Color.FromArgb(255, 128, 128, 128);
            mp_clrCheckBoxBackColor = Color.FromArgb(255, 255, 255, 255);
			mp_clrCheckBoxMarkColor = Color.FromArgb(255, 0, 0, 0);
			mp_clrSelectedBackColor = Color.FromArgb(255, 0, 0, 255);
			mp_clrSelectedForeColor = Color.FromArgb(255, 255, 255, 255);
			mp_clrTreeLineColor = Color.FromArgb(255, 128, 128, 128);
			mp_clrPlusMinusBorderColor = Color.FromArgb(255, 128, 128, 128);
			mp_clrPlusMinusSignColor = Color.FromArgb(255, 0, 0, 0);
            mp_clrPlusMinusBackColor = Color.FromArgb(255, 255, 255, 255);
            mp_clrExpandIconForeColor = Color.FromArgb(255, 0, 0, 0);
            mp_clrExpandIconBackColor = Color.FromArgb(255, 255, 255, 255);
            mp_clrExpandIconDropShadowColor = Color.FromArgb(255, 211, 211, 211);
            mp_clrCollapseIconForeColor = Color.FromArgb(255, 0, 0, 0);
            mp_clrCollapseIconDropShadowColor = Color.FromArgb(255, 128, 128, 128);
			mp_bCheckBoxes = false;
			mp_bTreeLines = true;
			mp_bImages = true;
            mp_yTreeviewMode = E_TREEVIEWMODE.TM_PLUSMINUSSIGNS;
			mp_bFullColumnSelect = false;
			mp_bExpansionOnSelection = false;
			mp_sPathSeparator = "/";
			mp_yOperation = E_OPERATION.EO_NONE;
            mp_yCheckBoxBackgroundMode = GRE_BACKGROUNDMODE.FP_TRANSPARENT;
            mp_yPlusMinusBackgroundMode = GRE_BACKGROUNDMODE.FP_TRANSPARENT;
		}
    
		internal bool OverControl(int X, int Y)
		{
			clsRow oRow = null;
			int lIndex = 0;
            if (mp_oControl.TreeviewColumnIndex == 0) 
			{
				return false;
			}
            if (!(X >= LeftTrim & X <= RightTrim)) 
			{
				return false;
			}
			for (lIndex = 1; lIndex <= mp_oControl.Rows.Count; lIndex++) 
			{
				oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
				if (oRow.Visible == true) 
				{
					if (Y >= oRow.Top & Y <= oRow.Bottom) 
					{
						return true;
					}
				}
			}
			return false;
		}
    
		internal void OnMouseHover(int X, int Y)
		{
			switch (CursorPosition(X, Y)) 
			{
				case E_EVENTTARGET.EVT_TREEVIEWCHECKBOX:
					mp_EO_CHECKBOXCLICK(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
					break;
				case E_EVENTTARGET.EVT_TREEVIEWSIGN:
					mp_EO_SIGNCLICK(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
					break;
				case E_EVENTTARGET.EVT_SELECTEDROW:
                    if (mp_bCursorEditTextNode(X, Y) == true)
                    {
                        return;
                    }
                    switch (mp_oControl.MouseKeyboardEvents.mp_yRowArea(X, Y))
                    {
                        case E_AREA.EA_BOTTOM:
                            mp_EO_ROWSIZING(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                            break;
                        case E_AREA.EA_CENTER:
                            mp_EO_ROWMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
                            break;
                    }
					break;
				case E_EVENTTARGET.EVT_ROW:
					mp_EO_ROWSELECTION(E_MOUSEKEYBOARDEVENTS.MouseHover, X, Y);
					break;
			}
			System.Diagnostics.Debug.Assert(mp_yOperation == E_OPERATION.EO_NONE);
		}
    
		internal void OnMouseDown(int X, int Y)
		{
			System.Diagnostics.Debug.Assert(mp_yOperation == E_OPERATION.EO_NONE);
			switch (CursorPosition(X, Y)) 
			{
				case E_EVENTTARGET.EVT_TREEVIEWCHECKBOX:
					mp_EO_CHECKBOXCLICK(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
					mp_yOperation = E_OPERATION.EO_CHECKBOXCLICK;
					break;
				case E_EVENTTARGET.EVT_TREEVIEWSIGN:
					mp_EO_SIGNCLICK(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
					mp_yOperation = E_OPERATION.EO_SIGNCLICK;
					break;
				case E_EVENTTARGET.EVT_SELECTEDROW:
                    if (mp_bShowEditTextNode(X, Y) == true)
                    {
                        return;
                    }
                    switch (mp_oControl.MouseKeyboardEvents.mp_yRowArea(X, Y))
                    {
                        case E_AREA.EA_BOTTOM:
                            mp_EO_ROWSIZING(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                            mp_yOperation = E_OPERATION.EO_ROWSIZING;
                            break;
                        case E_AREA.EA_CENTER:
                            mp_EO_ROWMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
                            mp_yOperation = E_OPERATION.EO_ROWMOVEMENT;
                            break;
                    }
					break;
				case E_EVENTTARGET.EVT_ROW:
					mp_EO_ROWSELECTION(E_MOUSEKEYBOARDEVENTS.MouseDown, X, Y);
					mp_yOperation = E_OPERATION.EO_ROWSELECTION;
					break;
			}
		}
    
		internal void OnMouseMove(int X, int Y)
		{
			E_OPERATION yOperation = mp_yOperation;
			switch (mp_yOperation) 
			{
				case E_OPERATION.EO_CHECKBOXCLICK:
					mp_EO_CHECKBOXCLICK(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
					break;
				case E_OPERATION.EO_SIGNCLICK:
					mp_EO_SIGNCLICK(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
					break;
				case E_OPERATION.EO_ROWMOVEMENT:
					mp_EO_ROWMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
					break;
				case E_OPERATION.EO_ROWSIZING:
					mp_EO_ROWSIZING(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
					break;
				case E_OPERATION.EO_ROWSELECTION:
					mp_EO_ROWSELECTION(E_MOUSEKEYBOARDEVENTS.MouseMove, X, Y);
					break;
			}
			System.Diagnostics.Debug.Assert(yOperation == mp_yOperation);
		}
    
		internal void OnMouseUp(int X, int Y)
		{
			switch (mp_yOperation) 
			{
				case E_OPERATION.EO_CHECKBOXCLICK:
					mp_EO_CHECKBOXCLICK(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
					break;
				case E_OPERATION.EO_SIGNCLICK:
					mp_EO_SIGNCLICK(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
					break;
				case E_OPERATION.EO_ROWMOVEMENT:
					mp_EO_ROWMOVEMENT(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
					break;
				case E_OPERATION.EO_ROWSIZING:
					mp_EO_ROWSIZING(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
					break;
				case E_OPERATION.EO_ROWSELECTION:
					mp_EO_ROWSELECTION(E_MOUSEKEYBOARDEVENTS.MouseUp, X, Y);
					break;
			}
			mp_yOperation = E_OPERATION.EO_NONE;
		}
    
		private E_EVENTTARGET CursorPosition(int X, int Y)
		{
			if (mp_bOverCheckBox(X, Y) == true) 
			{
				return E_EVENTTARGET.EVT_TREEVIEWCHECKBOX;
			}
			else if (mp_bOverPlusMinusSign(X, Y) == true) 
			{
				return E_EVENTTARGET.EVT_TREEVIEWSIGN;
			}
			else if (mp_oControl.MouseKeyboardEvents.mp_bOverSelectedRow(X, Y) == true) 
			{
				return E_EVENTTARGET.EVT_SELECTEDROW;
			}
			else if (mp_oControl.MouseKeyboardEvents.mp_bOverRow(X, Y) == true) 
			{
				return E_EVENTTARGET.EVT_ROW;
			}
			return E_EVENTTARGET.EVT_NONE;
		}
    
		private void mp_EO_CHECKBOXCLICK(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
		{
			clsRow oRow = null;
			clsNode oNode = null;
			switch (yMouseKeyBoardEvent) 
			{
				case E_MOUSEKEYBOARDEVENTS.MouseHover:
					mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseDown:
					s_chkCLK.lNodeIndex = mp_oControl.MathLib.GetNodeIndexByCheckBoxPosition(X, Y);
					oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_chkCLK.lNodeIndex);
					oNode = oRow.Node;
					oNode.Checked = !oNode.Checked;
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseMove:
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseUp:
					mp_oControl.NodeEventArgs.Clear();
					mp_oControl.NodeEventArgs.Index = s_chkCLK.lNodeIndex;
					mp_oControl.FireNodeChecked();
					mp_oControl.Redraw();
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseClick:
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseWheel:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyDown:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyUp:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyPress:
					break;
			}
		}
    
		private void mp_EO_SIGNCLICK(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
		{
			clsRow oRow = null;
			clsNode oNode = null;
			switch (yMouseKeyBoardEvent) 
			{
				case E_MOUSEKEYBOARDEVENTS.MouseHover:
					mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseDown:
					s_sgnCLK.lNodeIndex = mp_oControl.MathLib.GetNodeIndexBySignPosition(X, Y);
					oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_sgnCLK.lNodeIndex);
					oNode = oRow.Node;
					oNode.Expanded = !oNode.Expanded;
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseMove:
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseUp:
					mp_oControl.NodeEventArgs.Clear();
					mp_oControl.NodeEventArgs.Index = s_sgnCLK.lNodeIndex;
					mp_oControl.FireNodeExpanded();
					mp_oControl.Redraw();
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseClick:
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseWheel:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyDown:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyUp:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyPress:
					break;
			}
		}
    
		private void mp_EO_ROWMOVEMENT(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
		{
			clsRow oDestinationRow = null;
			if (mp_oControl.AllowRowMove == false) 
			{
				return;
			}
			switch (yMouseKeyBoardEvent) 
			{
				case E_MOUSEKEYBOARDEVENTS.MouseHover:
					mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_MOVEROW);
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseDown:
					s_rowMVT.lRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
					System.Diagnostics.Debug.Assert(s_rowMVT.lRowIndex >= 1);
					mp_oControl.ObjectStateChangedEventArgs.Clear();
					mp_oControl.ObjectStateChangedEventArgs.EventTarget = E_EVENTTARGET.EVT_ROW;
					mp_oControl.ObjectStateChangedEventArgs.Index = s_rowMVT.lRowIndex;
					mp_oControl.ObjectStateChangedEventArgs.Cancel = false;
                    mp_oControl.ObjectStateChangedEventArgs.ChangeType = E_CHANGETYPE.CT_MOVE;
                    mp_oControl.FireBeginObjectChange();
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseMove:
					if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false) 
					{
						mp_oControl.clsG.mp_EraseReversibleFrames();
						mp_oControl.MouseKeyboardEvents.mp_DynamicRowMove(Y);
						s_rowMVT.lDestinationRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
						if (s_rowMVT.lDestinationRowIndex >= 1) 
						{
							mp_oControl.clsG.mp_EraseReversibleFrames();
							mp_oControl.ObjectStateChangedEventArgs.DestinationIndex = s_rowMVT.lDestinationRowIndex;
                            mp_oControl.FireObjectChange();
							if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false) 
							{
								oDestinationRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_rowMVT.lDestinationRowIndex);
								mp_oControl.MouseKeyboardEvents.mp_DrawMovingReversibleFrame(oDestinationRow.Left, oDestinationRow.Top, oDestinationRow.Right, oDestinationRow.Bottom, E_FOCUSTYPE.FCT_NORMAL);
							}
						}
					}

					break;
				case E_MOUSEKEYBOARDEVENTS.MouseUp:
					if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false) 
					{
						mp_oControl.clsG.mp_EraseReversibleFrames();
                        mp_oControl.FireEndObjectChange();
						if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false) 
						{
							s_rowMVT.lDestinationRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
							if (s_rowMVT.lDestinationRowIndex >= 1 & (s_rowMVT.lRowIndex != s_rowMVT.lDestinationRowIndex)) 
							{
								clsRow oRow = null;
								oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_rowMVT.lRowIndex);
								oDestinationRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_rowMVT.lDestinationRowIndex);
								oRow.Node.Depth = oDestinationRow.Node.Depth;
								mp_oControl.SelectedRowIndex = mp_oControl.Rows.oCollection.m_lCopyAndMoveItems(s_rowMVT.lRowIndex, s_rowMVT.lDestinationRowIndex);
                                mp_oControl.FireCompleteObjectChange();
							}
						}
					}

					mp_oControl.Redraw();
					mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseClick:
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseWheel:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyDown:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyUp:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyPress:
					break;
			}
		}
    
		private void mp_EO_ROWSIZING(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
		{
			clsRow oRow = null;
			if (mp_oControl.AllowRowSize == false) 
			{
				return;
			}
			switch (yMouseKeyBoardEvent) 
			{
				case E_MOUSEKEYBOARDEVENTS.MouseHover:
					mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_ROWHEIGHT);
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseDown:
					s_rowSZ.lRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
					System.Diagnostics.Debug.Assert(s_rowSZ.lRowIndex >= 1);
					mp_oControl.ObjectStateChangedEventArgs.Clear();
					mp_oControl.ObjectStateChangedEventArgs.EventTarget = E_EVENTTARGET.EVT_ROW;
					mp_oControl.ObjectStateChangedEventArgs.Index = s_rowSZ.lRowIndex;
					mp_oControl.ObjectStateChangedEventArgs.Cancel = false;
                    mp_oControl.ObjectStateChangedEventArgs.ChangeType = E_CHANGETYPE.CT_SIZE;
                    mp_oControl.FireBeginObjectChange();
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseMove:
					if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false) 
					{
						mp_oControl.clsG.mp_EraseReversibleFrames();
                        mp_oControl.FireObjectChange();
						if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false) 
						{
							mp_oControl.MouseKeyboardEvents.mp_DrawMovingReversibleFrame(0, Y, mp_oControl.clsG.Width(), Y + 2, E_FOCUSTYPE.FCT_NORMAL);
						}
					}

					break;
				case E_MOUSEKEYBOARDEVENTS.MouseUp:
					if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false) 
					{
						mp_oControl.clsG.mp_EraseReversibleFrames();
                        mp_oControl.FireEndObjectChange();
						if (mp_oControl.ObjectStateChangedEventArgs.Cancel == false) 
						{
							oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(s_rowSZ.lRowIndex);
							oRow.Height = oRow.Height + (Y - oRow.Bottom);
							if (oRow.Height < mp_oControl.MinRowHeight) 
							{
								oRow.Height = mp_oControl.MinRowHeight;
							}
                            mp_oControl.FireCompleteObjectChange();
						}
					}

					mp_oControl.Redraw();
					mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseClick:
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseWheel:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyDown:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyUp:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyPress:
					break;
			}
		}
    
		private void mp_EO_ROWSELECTION(E_MOUSEKEYBOARDEVENTS yMouseKeyBoardEvent, int X, int Y)
		{
			clsRow oRow = null;
			switch (yMouseKeyBoardEvent) 
			{
				case E_MOUSEKEYBOARDEVENTS.MouseHover:
					mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseDown:
					s_rowSEL.lRowIndex = mp_oControl.MathLib.GetRowIndexByPosition(Y);
					s_rowSEL.lCellIndex = mp_oControl.MathLib.GetCellIndexByPosition(X);
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseMove:
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseUp:
					mp_oControl.SelectedRowIndex = s_rowSEL.lRowIndex;
					mp_oControl.SelectedCellIndex = s_rowSEL.lCellIndex;
					oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(mp_oControl.SelectedRowIndex);
					mp_oControl.ObjectSelectedEventArgs.Clear();
					mp_oControl.ObjectSelectedEventArgs.EventTarget = E_EVENTTARGET.EVT_ROW;
					mp_oControl.ObjectSelectedEventArgs.ObjectIndex = mp_oControl.SelectedRowIndex;
					mp_oControl.FireObjectSelected();
					mp_oControl.Redraw();
					mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseClick:
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseDblClick:
					break;
				case E_MOUSEKEYBOARDEVENTS.MouseWheel:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyDown:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyUp:
					break;
				case E_MOUSEKEYBOARDEVENTS.KeyPress:
					break;
			}
		}
    
		private bool mp_bOverCheckBox(int X, int Y)
		{
			int lIndex = 0;
			clsNode oNode = null;
			clsRow oRow = null;
			bool bReturn = false;
			if (mp_bCheckBoxes == false) 
			{
				return false;
			}
			bReturn = false;
			for (lIndex = 1; lIndex <= mp_oControl.Rows.Count; lIndex++) 
			{
				oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
				oNode = oRow.Node;
                if (oRow.ClientAreaVisibility == E_CLIENTAREAVISIBILITY.VS_INSIDEVISIBLEAREA & X >= (oNode.CheckBoxLeft) & X <= (oNode.CheckBoxLeft + 13) & Y <= (oNode.YCenter + 6) & Y >= (oNode.YCenter - 7)) 
				{
					bReturn = true;
				}
			}
			return bReturn;
		}
    
		private bool mp_bOverPlusMinusSign(int X, int Y)
		{
			int lIndex = 0;
			clsNode oNode = null;
			clsRow oRow = null;
			bool bReturn = false;
            if (mp_yTreeviewMode == E_TREEVIEWMODE.TM_NONE)
			{
				return false;
			}
			bReturn = false;
			for (lIndex = 1; lIndex <= mp_oControl.Rows.Count; lIndex++) 
			{
				oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
				oNode = oRow.Node;
                if (oRow.ClientAreaVisibility == E_CLIENTAREAVISIBILITY.VS_INSIDEVISIBLEAREA & X >= (oNode.Left - 5) & X <= (oNode.Left + 5) & Y <= (oNode.YCenter + 5) & Y >= (oNode.YCenter - 5)) 
				{
					bReturn = true;
				}
			}
			return bReturn;
		}
    
		internal void Draw()
		{
            if (mp_oControl.TreeviewColumnIndex == 0)
            {
                return;
            }
            if (mp_oControl.Columns.Item(mp_oControl.TreeviewColumnIndex.ToString()).Visible == false)
            {
                return;
            }
            mp_oControl.clsG.mp_ClipRegion(LeftTrim, mp_oControl.CurrentViewObject.ClientArea.Top, RightTrim, mp_oControl.clsG.Height() - mt_BorderThickness - 1, false);
            mp_oControl.Rows.NodesDrawBackground();
            mp_oControl.clsG.mp_ClipRegion(LeftTrim, mp_oControl.CurrentViewObject.ClientArea.Top, RightTrim - 2, mp_oControl.clsG.Height() - mt_BorderThickness - 1, false);
            mp_oControl.Rows.NodesDraw();
            mp_oControl.Rows.NodesDrawTreeLines();
            mp_oControl.Rows.NodesDrawElements();
            mp_oControl.clsG.mp_ClearClipRegion();
		}
    
		internal int f_FirstVisibleNode 
		{
			get 
			{
				if (mp_oControl.Rows.Count == 0) 
				{
					return 0;
				}
				else 
				{
					return mp_oControl.VerticalScrollBar.Value;
				}
			}
		}
		
		public int FirstVisibleNode 
		{
			get 
			{
				if (mp_oControl.Rows.Count == 0) 
				{
					return 0;
				}
				else 
				{
					return mp_oControl.Rows.RealFirstVisibleRow;
				}
			}
			set 
			{
				if (value < 1) 
				{
					value = 1;
				}
				else if (((value > mp_oControl.Rows.Count) & (mp_oControl.Rows.Count != 0))) 
				{
					value = mp_oControl.Rows.Count;
				}
				mp_oControl.VerticalScrollBar.Value = value;
			}
		}
    
		
		public int LastVisibleNode 
		{
			get { return mp_lLastVisibleNode; }
		}
    
		internal int f_LastVisibleNode 
		{
			set { mp_lLastVisibleNode = value; }
		}
    
		internal int mt_BorderThickness 
		{
			get { return mp_oControl.mt_BorderThickness; }
		}
    
		
		public int Indentation 
		{
			get { return mp_lIndentation; }
			set { mp_lIndentation = value; }
		}
    
		
		public void ClearSelections()
		{
			mp_oControl.SelectedRowIndex = 0;
		}
    
		
		public Color CheckBoxBorderColor 
		{
			get { return mp_clrCheckBoxBorderColor; }
			set { mp_clrCheckBoxBorderColor = value; }
		}


        public Color CheckBoxBackColor 
		{
            get { return mp_clrCheckBoxBackColor; }
            set { mp_clrCheckBoxBackColor = value; }
		}

        public GRE_BACKGROUNDMODE CheckBoxBackgroundMode
        {
            get { return mp_yCheckBoxBackgroundMode; }
            set
            {
                if (value != GRE_BACKGROUNDMODE.FP_SOLID | value != GRE_BACKGROUNDMODE.FP_TRANSPARENT)
                {
                    value = GRE_BACKGROUNDMODE.FP_SOLID;
                }
                mp_yCheckBoxBackgroundMode = value;
            }
        }
    
		
		public Color CheckBoxMarkColor 
		{
			get { return mp_clrCheckBoxMarkColor; }
			set { mp_clrCheckBoxMarkColor = value; }
		}
    
		
		public Color BackColor 
		{
			get { return mp_clrBackColor; }
			set { mp_clrBackColor = value; }
		}
    
		
		public string PathSeparator 
		{
			get { return mp_sPathSeparator; }
			set { mp_sPathSeparator = value; }
		}
    
		
		public bool TreeLines 
		{
			get { return mp_bTreeLines; }
			set { mp_bTreeLines = value; }
		}


        public E_TREEVIEWMODE TreeviewMode
        {
            get { return mp_yTreeviewMode; }
            set { mp_yTreeviewMode = value; }
        }
    
		
		public bool Images 
		{
			get { return mp_bImages; }
			set { mp_bImages = value; }
		}
    
		
		public bool CheckBoxes 
		{
			get { return mp_bCheckBoxes; }
			set { mp_bCheckBoxes = value; }
		}
    
		
		public bool FullColumnSelect 
		{
			get { return mp_bFullColumnSelect; }
			set { mp_bFullColumnSelect = value; }
		}
    
		
		public bool ExpansionOnSelection 
		{
			get { return mp_bExpansionOnSelection; }
			set { mp_bExpansionOnSelection = value; }
		}
		
		public Color SelectedBackColor 
		{
			get { return mp_clrSelectedBackColor; }
			set { mp_clrSelectedBackColor = value; }
		}
    
		
		public Color SelectedForeColor 
		{
			get { return mp_clrSelectedForeColor; }
			set { mp_clrSelectedForeColor = value; }
		}
    
		
		public Color TreeLineColor 
		{
			get { return mp_clrTreeLineColor; }
			set { mp_clrTreeLineColor = value; }
		}

        public Color PlusMinusBackColor
        {
            get { return mp_clrPlusMinusBackColor; }
            set { mp_clrPlusMinusBackColor = value; }
        }

        public GRE_BACKGROUNDMODE PlusMinusBackgroundMode
        {
            get { return mp_yPlusMinusBackgroundMode; }
            set
            {
                if (value != GRE_BACKGROUNDMODE.FP_SOLID | value != GRE_BACKGROUNDMODE.FP_TRANSPARENT)
                {
                    value = GRE_BACKGROUNDMODE.FP_SOLID;
                }
                mp_yPlusMinusBackgroundMode = value;
            }
        }
    
		
		public Color PlusMinusBorderColor 
		{
			get { return mp_clrPlusMinusBorderColor; }
			set { mp_clrPlusMinusBorderColor = value; }
		}
    
		
		public Color PlusMinusSignColor 
		{
			get { return mp_clrPlusMinusSignColor; }
			set { mp_clrPlusMinusSignColor = value; }
		}

        internal int Left
        {
            get
            {
                if (mp_oControl.TreeviewColumnIndex == 0)
                {
                    return 0;
                }
                return mp_oControl.Columns.Item(mp_oControl.TreeviewColumnIndex.ToString()).Left;
            }
        }

        internal int Right
        {
            get
            {
                if (mp_oControl.TreeviewColumnIndex == 0)
                {
                    return 0;
                }
                return mp_oControl.Columns.Item(mp_oControl.TreeviewColumnIndex.ToString()).Right;
            }
        }

        internal int LeftTrim
        {
            get
            {
                if (mp_oControl.TreeviewColumnIndex == 0)
                {
                    return 0;
                }
                return mp_oControl.Columns.Item(mp_oControl.TreeviewColumnIndex.ToString()).LeftTrim;
            }
        }

        internal int RightTrim
        {
            get
            {
                if (mp_oControl.TreeviewColumnIndex == 0)
                {
                    return 0;
                }
                return mp_oControl.Columns.Item(mp_oControl.TreeviewColumnIndex.ToString()).RightTrim;
            }
        }

        internal bool mp_bCursorEditTextNode(int X, int Y)
        {
            clsNode oNode;
            clsRow oRow;
            oRow = mp_oControl.Rows.Item(mp_oControl.SelectedRowIndex.ToString());
            oNode = oRow.Node;
            if (oNode.AllowTextEdit == true)
            {
                if (X >= oNode.mp_lTextLeft & X <= oNode.mp_lTextRight)
                {
                    if (Y >= oNode.mp_lTextTop & Y <= oNode.mp_lTextBottom)
                    {
                        mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_IBEAM);
                        return true;
                    }
                }
            }
            mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
            return false;
        }

        internal bool mp_bShowEditTextNode(int X, int Y)
        {
            clsNode oNode;
            clsRow oRow;
            oRow = mp_oControl.Rows.Item(mp_oControl.SelectedRowIndex.ToString());
            oNode = oRow.Node;
            if (oNode.AllowTextEdit == true)
            {
                if (X >= oNode.mp_lTextLeft & X <= oNode.mp_lTextRight)
                {
                    if (Y >= oNode.mp_lTextTop & Y <= oNode.mp_lTextBottom)
                    {
                        mp_oControl.mp_oTextBox.Initialize(mp_oControl.SelectedRowIndex, 0, E_TEXTOBJECTTYPE.TOT_NODE, X, Y);
                        return true;
                    }
                }
            }
            return false;
        }

        public Color ExpandIconForeColor
        {
            get { return mp_clrExpandIconForeColor; }
            set { mp_clrExpandIconForeColor = value; }
        }

        public Color ExpandIconBackColor
        {
            get { return mp_clrExpandIconBackColor; }
            set { mp_clrExpandIconBackColor = value; }
        }

        public Color ExpandIconDropShadowColor
        {
            get { return mp_clrExpandIconDropShadowColor; }
            set { mp_clrExpandIconDropShadowColor = value; }
        }

        public Color CollapseIconForeColor
        {
            get { return mp_clrCollapseIconForeColor; }
            set { mp_clrCollapseIconForeColor = value; }
        }

        public Color CollapseIconDropShadowColor
        {
            get { return mp_clrCollapseIconDropShadowColor; }
            set { mp_clrCollapseIconDropShadowColor = value; }
        }
    
		
		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "Treeview");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("BackColor", ref mp_clrBackColor);
			oXML.ReadProperty("CheckBoxBorderColor", ref mp_clrCheckBoxBorderColor);
            oXML.ReadProperty("CheckBoxBackColor", ref mp_clrCheckBoxBackColor);
            oXML.ReadProperty("CheckBoxBackgroundMode", ref mp_yCheckBoxBackgroundMode);
			oXML.ReadProperty("CheckBoxes", ref mp_bCheckBoxes);
			oXML.ReadProperty("CheckBoxMarkColor", ref mp_clrCheckBoxMarkColor);
			oXML.ReadProperty("ExpansionOnSelection", ref mp_bExpansionOnSelection);
			oXML.ReadProperty("FullColumnSelect", ref mp_bFullColumnSelect);
			oXML.ReadProperty("Images", ref mp_bImages);
			oXML.ReadProperty("Indentation", ref mp_lIndentation);
			oXML.ReadProperty("PathSeparator", ref mp_sPathSeparator);
			oXML.ReadProperty("PlusMinusBorderColor", ref mp_clrPlusMinusBorderColor);
			oXML.ReadProperty("PlusMinusSignColor", ref mp_clrPlusMinusSignColor);
            oXML.ReadProperty("PlusMinusBackColor", ref mp_clrPlusMinusBackColor);
            oXML.ReadProperty("PlusMinusBackgroundMode", ref mp_yPlusMinusBackgroundMode);
            oXML.ReadProperty("TreeviewMode", ref mp_yTreeviewMode);
			oXML.ReadProperty("SelectedBackColor", ref mp_clrSelectedBackColor);
			oXML.ReadProperty("SelectedForeColor", ref mp_clrSelectedForeColor);
			oXML.ReadProperty("TreeLineColor", ref mp_clrTreeLineColor);
			oXML.ReadProperty("TreeLines", ref mp_bTreeLines);
            oXML.ReadProperty("ExpandIconForeColor", ref mp_clrExpandIconForeColor);
            oXML.ReadProperty("ExpandIconBackColor", ref mp_clrExpandIconBackColor);
            oXML.ReadProperty("ExpandIconDropShadowColor", ref mp_clrExpandIconDropShadowColor);
            oXML.ReadProperty("CollapseIconForeColor", ref mp_clrCollapseIconForeColor);
            oXML.ReadProperty("CollapseIconDropShadowColor", ref mp_clrCollapseIconDropShadowColor);
		}
    
		
		public string GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "Treeview");
			oXML.InitializeWriter();
			oXML.WriteProperty("BackColor", mp_clrBackColor);
			oXML.WriteProperty("CheckBoxBorderColor", mp_clrCheckBoxBorderColor);
            oXML.WriteProperty("CheckBoxBackColor", mp_clrCheckBoxBackColor);
            oXML.WriteProperty("CheckBoxBackgroundMode", mp_yCheckBoxBackgroundMode);
			oXML.WriteProperty("CheckBoxes", mp_bCheckBoxes);
			oXML.WriteProperty("CheckBoxMarkColor", mp_clrCheckBoxMarkColor);
			oXML.WriteProperty("ExpansionOnSelection", mp_bExpansionOnSelection);
			oXML.WriteProperty("FullColumnSelect", mp_bFullColumnSelect);
			oXML.WriteProperty("Images", mp_bImages);
			oXML.WriteProperty("Indentation", mp_lIndentation);
			oXML.WriteProperty("PathSeparator", mp_sPathSeparator);
			oXML.WriteProperty("PlusMinusBorderColor", mp_clrPlusMinusBorderColor);
			oXML.WriteProperty("PlusMinusSignColor", mp_clrPlusMinusSignColor);
            oXML.WriteProperty("PlusMinusBackColor", mp_clrPlusMinusBackColor);
            oXML.WriteProperty("PlusMinusBackgroundMode", mp_yPlusMinusBackgroundMode);
            oXML.WriteProperty("TreeviewMode", mp_yTreeviewMode);
			oXML.WriteProperty("SelectedBackColor", mp_clrSelectedBackColor);
			oXML.WriteProperty("SelectedForeColor", mp_clrSelectedForeColor);
			oXML.WriteProperty("TreeLineColor", mp_clrTreeLineColor);
			oXML.WriteProperty("TreeLines", mp_bTreeLines);
            oXML.WriteProperty("ExpandIconForeColor", mp_clrExpandIconForeColor);
            oXML.WriteProperty("ExpandIconBackColor", mp_clrExpandIconBackColor);
            oXML.WriteProperty("ExpandIconDropShadowColor", mp_clrExpandIconDropShadowColor);
            oXML.WriteProperty("CollapseIconForeColor", mp_clrCollapseIconForeColor);
            oXML.WriteProperty("CollapseIconDropShadowColor", mp_clrCollapseIconDropShadowColor);
			return oXML.GetXML();
		}
    
	}
}