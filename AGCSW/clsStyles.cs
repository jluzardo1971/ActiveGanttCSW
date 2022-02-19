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
using System.Windows;
using System.Windows.Media;
using System.Collections;


namespace AGCSW
{
    public class clsStyles : IEnumerable
	{
        private ActiveGanttCSWCtl mp_oControl;
		private clsCollectionBase mp_oCollection;
        internal clsStyle mp_oDefaultControlStyle;
        internal clsStyle mp_oDefaultTaskStyle;
        internal clsStyle mp_oDefaultRowStyle;
        internal clsStyle mp_oDefaultClientAreaStyle;
        internal clsStyle mp_oDefaultCellStyle;
        internal clsStyle mp_oDefaultColumnStyle;
        internal clsStyle mp_oDefaultPercentageStyle;
        internal clsStyle mp_oDefaultPredecessorStyle;
        internal clsStyle mp_oDefaultTimeLineStyle;
        internal clsStyle mp_oDefaultTimeBlockStyle;
        internal clsStyle mp_oDefaultTickMarkAreaStyle;
        internal clsStyle mp_oDefaultSplitterStyle;
        internal clsStyle mp_oDefaultProgressLineStyle;
        internal clsStyle mp_oDefaultNodeStyle;
        internal clsStyle mp_oDefaultTierStyle;
        internal clsStyle mp_oDefaultScrollBarStyle;
        internal clsStyle mp_oDefaultSBSeparatorStyle;
        internal clsStyle mp_oDefaultSBNormalStyle;
        internal clsStyle mp_oDefaultSBPressedStyle;
        internal clsStyle mp_oDefaultSBDisabledStyle;

        internal clsStyles(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            mp_oCollection = new clsCollectionBase(mp_oControl, "Style");

            mp_oDefaultControlStyle = new clsStyle(mp_oControl);
            mp_oDefaultColumnStyle = new clsStyle(mp_oControl);
            mp_oDefaultRowStyle = new clsStyle(mp_oControl);
            mp_oDefaultCellStyle = new clsStyle(mp_oControl);
            mp_oDefaultNodeStyle = new clsStyle(mp_oControl);
            mp_oDefaultSplitterStyle = new clsStyle(mp_oControl);
            mp_oDefaultTaskStyle = new clsStyle(mp_oControl);
            mp_oDefaultPercentageStyle = new clsStyle(mp_oControl);
            mp_oDefaultPredecessorStyle = new clsStyle(mp_oControl);
            mp_oDefaultTimeBlockStyle = new clsStyle(mp_oControl);
            mp_oDefaultProgressLineStyle = new clsStyle(mp_oControl);

            mp_oDefaultClientAreaStyle = new clsStyle(mp_oControl);
            mp_oDefaultTimeLineStyle = new clsStyle(mp_oControl);
            mp_oDefaultTierStyle = new clsStyle(mp_oControl);
            mp_oDefaultTickMarkAreaStyle = new clsStyle(mp_oControl);

            mp_oDefaultScrollBarStyle = new clsStyle(mp_oControl);
            mp_oDefaultSBSeparatorStyle = new clsStyle(mp_oControl);
            mp_oDefaultSBNormalStyle = new clsStyle(mp_oControl);
            mp_oDefaultSBPressedStyle = new clsStyle(mp_oControl);
            mp_oDefaultSBDisabledStyle = new clsStyle(mp_oControl);

            mp_ResetDefaultStyles();

        }

        internal void mp_ResetDefaultStyles()
        {
            //// Control
            mp_oDefaultControlStyle.Clear();
            mp_oDefaultControlStyle.Appearance = E_STYLEAPPEARANCE.SA_SUNKEN;
            mp_oDefaultControlStyle.BackColor = Color.FromArgb(255, 255, 255, 255);

            mp_oDefaultColumnStyle.Clear();
            mp_oDefaultColumnStyle.Appearance = E_STYLEAPPEARANCE.SA_RAISED;
            mp_oDefaultColumnStyle.TextAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_BOTTOM;
            mp_oDefaultColumnStyle.TextYMargin = 5;
            mp_oDefaultColumnStyle.Font = mp_oControl.Configuration.DefaultFont.Clone();

            mp_oDefaultRowStyle.Clear();

            mp_oDefaultCellStyle.Clear();
            mp_oDefaultCellStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            mp_oDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            mp_oDefaultCellStyle.BorderColor = Color.FromArgb(255, 128, 128, 128);
            mp_oDefaultCellStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            mp_oDefaultCellStyle.CustomBorderStyle.Top = false;
            mp_oDefaultCellStyle.CustomBorderStyle.Left = false;
            mp_oDefaultCellStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_LEFT;
            mp_oDefaultCellStyle.TextAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_TOP;
            mp_oDefaultCellStyle.TextYMargin = 5;
            mp_oDefaultCellStyle.TextXMargin = 5;
            mp_oDefaultCellStyle.Font = mp_oControl.Configuration.DefaultFont.Clone();
            mp_oDefaultCellStyle.ImageAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_LEFT;
            mp_oDefaultCellStyle.ImageAlignmentVertical = GRE_VERTICALALIGNMENT.VAL_TOP;
            mp_oDefaultCellStyle.ImageXMargin = 0;
            mp_oDefaultCellStyle.ImageYMargin = 0;

            mp_oDefaultNodeStyle.Clear();
            mp_oDefaultNodeStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            mp_oDefaultNodeStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            mp_oDefaultNodeStyle.BorderColor = Color.FromArgb(255, 128, 128, 128);
            mp_oDefaultNodeStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            mp_oDefaultNodeStyle.CustomBorderStyle.Top = false;
            mp_oDefaultNodeStyle.CustomBorderStyle.Left = false;

            mp_oDefaultSplitterStyle.Clear();
            mp_oDefaultSplitterStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            mp_oDefaultSplitterStyle.BackColor = Color.FromArgb(255, 0, 0, 0);

            mp_oDefaultTaskStyle.Clear();
            mp_oDefaultTaskStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND;

            mp_oDefaultPercentageStyle.Clear();
            mp_oDefaultPercentageStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            mp_oDefaultPercentageStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            mp_oDefaultPercentageStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            mp_oDefaultPercentageStyle.OffsetTop = 10;
            mp_oDefaultPercentageStyle.OffsetBottom = 15;
            mp_oDefaultPercentageStyle.BackColor = Color.FromArgb(255, 0, 0, 255);

            mp_oDefaultPredecessorStyle.Clear();

            mp_oDefaultTimeBlockStyle.Clear();
            mp_oDefaultTimeBlockStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            mp_oDefaultTimeBlockStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_HATCH;
            mp_oDefaultTimeBlockStyle.HatchBackColor = Color.FromArgb(255, 255, 255, 255);
            mp_oDefaultTimeBlockStyle.HatchForeColor = Color.FromArgb(255, 128, 128, 128);
            mp_oDefaultTimeBlockStyle.HatchStyle = GRE_HATCHSTYLE.HS_PERCENT50;

            mp_oDefaultProgressLineStyle.Clear();
            mp_oDefaultProgressLineStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            mp_oDefaultProgressLineStyle.BackColor = Color.FromArgb(255, 0, 0, 0);

            //// Views
            mp_oDefaultClientAreaStyle.Clear();
            mp_oDefaultClientAreaStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            mp_oDefaultClientAreaStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_TRANSPARENT;
            mp_oDefaultClientAreaStyle.BorderColor = Color.FromArgb(255, 128, 128, 128);
            mp_oDefaultClientAreaStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            mp_oDefaultClientAreaStyle.CustomBorderStyle.Top = false;
            mp_oDefaultClientAreaStyle.CustomBorderStyle.Left = false;
            mp_oDefaultClientAreaStyle.CustomBorderStyle.Right = false;

            mp_oDefaultTimeLineStyle.Clear();

            mp_oDefaultTierStyle.Clear();
            mp_oDefaultTierStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            mp_oDefaultTierStyle.BorderStyle = GRE_BORDERSTYLE.SBR_NONE;
            mp_oDefaultTierStyle.DrawTextInVisibleArea = true;

            mp_oDefaultTickMarkAreaStyle.Clear();

            //// Scroll Bars
            mp_oDefaultScrollBarStyle.Clear();
            mp_oDefaultScrollBarStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            mp_oDefaultScrollBarStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_HATCH;
            mp_oDefaultScrollBarStyle.HatchStyle = GRE_HATCHSTYLE.HS_PERCENT50;
            mp_oDefaultScrollBarStyle.HatchForeColor = Color.FromArgb(255, 192, 192, 192);
            mp_oDefaultScrollBarStyle.HatchBackColor = Color.FromArgb(255, 255, 255, 255);
            mp_oDefaultScrollBarStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            mp_oDefaultScrollBarStyle.BorderColor = Color.FromArgb(255, 192, 192, 192);

            mp_oDefaultSBSeparatorStyle.Clear();
            mp_oDefaultSBSeparatorStyle.Appearance = E_STYLEAPPEARANCE.SA_RAISED;

            mp_oDefaultSBNormalStyle.Clear();
            mp_oDefaultSBNormalStyle.Appearance = E_STYLEAPPEARANCE.SA_RAISED;

            mp_oDefaultSBPressedStyle.Clear();
            mp_oDefaultSBPressedStyle.Appearance = E_STYLEAPPEARANCE.SA_SUNKEN;

            mp_oDefaultSBDisabledStyle.Clear();
            mp_oDefaultSBDisabledStyle.Appearance = E_STYLEAPPEARANCE.SA_RAISED;
            mp_oDefaultSBDisabledStyle.ScrollBarStyle.ArrowColor = Color.FromArgb(255, 192, 192, 192);
        }

		~clsStyles()
		{	
		}

		public int Count 
		{
			get 
			{
				return mp_oCollection.m_lCount();
			}
		}

        public bool ContainsKey(string Key)
        {
            if (Globals.g_IsNumeric(Key))
            {
                mp_oControl.mp_ErrorReport(SYS_ERRORS.STYLES_ADD_1, "Invalid Style object key, key cannot be numeric", "ActiveGanttCSWCtl.Styles.ContainsKey");
                return false;
            }
            return mp_oCollection.m_bDoesKeyExist(Key);
        }

		public clsStyle Item(String Index)
		{
			return (clsStyle) mp_oCollection.m_oItem(Index, SYS_ERRORS.STYLES_ITEM_1, SYS_ERRORS.STYLES_ITEM_2, SYS_ERRORS.STYLES_ITEM_3, SYS_ERRORS.STYLES_ITEM_4);
		}

        public clsStyle Item(int Index)
        {
            return (clsStyle)mp_oCollection.m_oReturnArrayElement(Index);
        }

        internal clsStyle FItem(String Index)
		{

				if (Index == "DS_TASK") 
				{
					return mp_oDefaultTaskStyle;
				}
				else if (Index == "DS_ROW") 
				{
					return mp_oDefaultRowStyle;
				}
				else if (Index == "DS_CLIENTAREA") 
				{
					return mp_oDefaultClientAreaStyle;
				}
				else if (Index == "DS_CELL") 
				{
					return mp_oDefaultCellStyle;
				}
				else if (Index == "DS_COLUMN") 
				{
					return mp_oDefaultColumnStyle;
				}
				else if (Index == "DS_PERCENTAGE") 
				{
					return mp_oDefaultPercentageStyle;
				}
				else if (Index == "DS_PREDECESSOR") 
				{
					return mp_oDefaultPredecessorStyle;
				}
				else if (Index == "DS_TIMELINE") 
				{
					return mp_oDefaultTimeLineStyle;
				}
				else if (Index == "DS_TIMEBLOCK") 
				{
					return mp_oDefaultTimeBlockStyle;
				}
				else if (Index == "DS_TICKMARKAREA") 
				{
					return mp_oDefaultTickMarkAreaStyle;
				}
                else if (Index == "DS_SPLITTER")
                {
                    return mp_oDefaultSplitterStyle;
                }
                else if (Index == "DS_PROGRESSLINE")
                {
                    return mp_oDefaultProgressLineStyle;
                }
                else if (Index == "DS_CONTROL")
                {
                    return mp_oDefaultControlStyle;
                }
                else if (Index == "DS_NODE")
                {
                    return mp_oDefaultNodeStyle;
                }
                else if (Index == "DS_TIER")
                {
                    return mp_oDefaultTierStyle;
                }
                else if (Index == "DS_SCROLLBAR")
                {
                    return mp_oDefaultScrollBarStyle;
                }
                else if (Index == "DS_SB_NORMAL")
                {
                    return mp_oDefaultSBNormalStyle;
                }
                else if (Index == "DS_SB_PRESSED")
                {
                    return mp_oDefaultSBPressedStyle;
                }
                else if (Index == "DS_SB_DISABLED")
                {
                    return mp_oDefaultSBDisabledStyle;
                }
                else if (Index == "DS_SB_SEPARATOR")
                {
                    return mp_oDefaultSBSeparatorStyle;
                }
				else 
				{
					return (clsStyle) mp_oCollection.m_oItem(Index, SYS_ERRORS.STYLES_ITEM_1, SYS_ERRORS.STYLES_ITEM_2, SYS_ERRORS.STYLES_ITEM_3, SYS_ERRORS.STYLES_ITEM_4);
				}
		}

		internal clsCollectionBase oCollection 
		{
			get 
			{
				return mp_oCollection;
			}
		}



		// ---------------------------------------------------------------------------------------------------------------------
		// Methods
		// ---------------------------------------------------------------------------------------------------------------------

		public clsStyle Add(String Key)
		{
			mp_oCollection.AddMode = true;
            clsStyle oStyle = new clsStyle(mp_oControl);
			Key = Globals.g_Trim(Key);
			oStyle.Key = Key;
			mp_oCollection.m_Add(oStyle, Key, SYS_ERRORS.STYLES_ADD_1, SYS_ERRORS.STYLES_ADD_2, true, SYS_ERRORS.STYLES_ADD_3);
			return oStyle;
		}

        public void Clear()
        {
            int lIndex = 0;
            int lIndex2 = 0;
            clsColumn oColumn;
            clsRow oRow;
            clsCell oCell;
            clsTask oTask;
            clsPredecessor oPredecessor;
            clsTimeBlock oTimeBlock;
            clsPercentage oPercentage;
            clsView oView;

            mp_oControl.StyleIndex = "";
            mp_oControl.Splitter.StyleIndex = "";

            mp_oControl.VerticalScrollBar.ScrollBar.StyleIndex = "";
            mp_oControl.VerticalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "";
            mp_oControl.VerticalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "";
            mp_oControl.VerticalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "";
            mp_oControl.VerticalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "";
            mp_oControl.VerticalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "";
            mp_oControl.VerticalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "";

            mp_oControl.HorizontalScrollBar.ScrollBar.StyleIndex = "";
            mp_oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "";
            mp_oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "";
            mp_oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "";
            mp_oControl.HorizontalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "";
            mp_oControl.HorizontalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "";
            mp_oControl.HorizontalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "";

            mp_oControl.ScrollBarSeparator.StyleIndex = "";

            for (lIndex = 1; lIndex <= mp_oControl.Columns.Count; lIndex++)
            {
                oColumn = (clsColumn)mp_oControl.Columns.oCollection.m_oReturnArrayElement(lIndex);
                oColumn.StyleIndex = "";
            }
            for (lIndex = 1; lIndex <= mp_oControl.Rows.Count; lIndex++)
            {
                oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
                oRow.StyleIndex = "";
                oRow.ClientAreaStyleIndex = "";
                oRow.Node.StyleIndex = "";
                for (lIndex2 = 1; lIndex2 <= oRow.Cells.Count; lIndex2++)
                {
                    oCell = (clsCell)oRow.Cells.oCollection.m_oReturnArrayElement(lIndex2);
                    oCell.StyleIndex = "";
                }
            }
            for (lIndex = 1; lIndex <= mp_oControl.Tasks.Count; lIndex++)
            {
                oTask = (clsTask)mp_oControl.Tasks.oCollection.m_oReturnArrayElement(lIndex);
                oTask.StyleIndex = "";
                oTask.WarningStyleIndex = "";
            }
            for (lIndex = 1; lIndex <= mp_oControl.TimeBlocks.Count; lIndex++)
            {
                oTimeBlock = (clsTimeBlock)mp_oControl.TimeBlocks.oCollection.m_oReturnArrayElement(lIndex);
                oTimeBlock.StyleIndex = "";
            }
            for (lIndex = 1; lIndex <= mp_oControl.Percentages.Count; lIndex++)
            {
                oPercentage = (clsPercentage)mp_oControl.Percentages.oCollection.m_oReturnArrayElement(lIndex);
                oPercentage.StyleIndex = "";
            }
            for (lIndex = 1; lIndex <= mp_oControl.Predecessors.Count; lIndex++)
            {
                oPredecessor = (clsPredecessor)mp_oControl.Predecessors.oCollection.m_oReturnArrayElement(lIndex);
                oPredecessor.StyleIndex = "";
                oPredecessor.WarningStyleIndex = "";
                oPredecessor.SelectedStyleIndex = "";
            }
            for (lIndex = 1; lIndex <= mp_oControl.Views.Count; lIndex++)
            {
                oView = (clsView)mp_oControl.Views.oCollection.m_oReturnArrayElement(lIndex);
                oView.TimeLine.StyleIndex = "";
                oView.TimeLine.TickMarkArea.StyleIndex = "";
                oView.TimeLine.TierArea.UpperTier.StyleIndex = "";
                oView.TimeLine.TierArea.MiddleTier.StyleIndex = "";
                oView.TimeLine.TierArea.LowerTier.StyleIndex = "";
                oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = "";
                oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "";
                oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "";
                oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "";
                oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "";
                oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "";
                oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "";
            }

            mp_oControl.TimeLineScrollBar.ScrollBar.StyleIndex = "";
            mp_oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "";
            mp_oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "";
            mp_oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "";
            mp_oControl.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "";
            mp_oControl.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "";
            mp_oControl.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "";

            oView = mp_oControl.Views.FItem("0");
            oView.TimeLine.StyleIndex = "";
            oView.TimeLine.TickMarkArea.StyleIndex = "";
            oView.TimeLine.TierArea.UpperTier.StyleIndex = "";
            oView.TimeLine.TierArea.MiddleTier.StyleIndex = "";
            oView.TimeLine.TierArea.LowerTier.StyleIndex = "";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = "";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "";
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "";

            mp_oCollection.m_Clear();
            mp_ResetDefaultStyles();
        }

        public void Remove(string Index)
        {
            string sRIndex = "";
            string sRKey = "";
            mp_oCollection.m_GetKeyAndIndex(Index, ref sRKey, ref sRIndex);
            int lIndex = 0;
            int lIndex2 = 0;
            clsColumn oColumn;
            clsRow oRow;
            clsCell oCell;
            clsTask oTask;
            clsPredecessor oPredecessor;
            clsTimeBlock oTimeBlock;
            clsPercentage oPercentage;
            clsView oView;

            mp_oControl.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.StyleIndex);
            mp_oControl.Splitter.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.Splitter.StyleIndex);

            mp_oControl.VerticalScrollBar.ScrollBar.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.VerticalScrollBar.ScrollBar.StyleIndex);
            mp_oControl.VerticalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.VerticalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex);
            mp_oControl.VerticalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.VerticalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex);
            mp_oControl.VerticalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.VerticalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex);
            mp_oControl.VerticalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.VerticalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex);
            mp_oControl.VerticalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.VerticalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex);
            mp_oControl.VerticalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.VerticalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex);

            mp_oControl.HorizontalScrollBar.ScrollBar.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.HorizontalScrollBar.ScrollBar.StyleIndex);
            mp_oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex);
            mp_oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex);
            mp_oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex);
            mp_oControl.HorizontalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.HorizontalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex);
            mp_oControl.HorizontalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.HorizontalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex);
            mp_oControl.HorizontalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.HorizontalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex);

            mp_oControl.ScrollBarSeparator.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.ScrollBarSeparator.StyleIndex);

            for (lIndex = 1; lIndex <= mp_oControl.Columns.Count; lIndex++)
            {
                oColumn = (clsColumn)mp_oControl.Columns.oCollection.m_oReturnArrayElement(lIndex);
                oColumn.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oColumn.StyleIndex);
            }
            for (lIndex = 1; lIndex <= mp_oControl.Rows.Count; lIndex++)
            {
                oRow = (clsRow)mp_oControl.Rows.oCollection.m_oReturnArrayElement(lIndex);
                oRow.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oRow.StyleIndex);
                oRow.ClientAreaStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oRow.ClientAreaStyleIndex);
                oRow.Node.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oRow.Node.StyleIndex);
                for (lIndex2 = 1; lIndex2 <= oRow.Cells.Count; lIndex2++)
                {
                    oCell = (clsCell)oRow.Cells.oCollection.m_oReturnArrayElement(lIndex2);
                    oCell.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oCell.StyleIndex);
                }
            }
            for (lIndex = 1; lIndex <= mp_oControl.Tasks.Count; lIndex++)
            {
                oTask = (clsTask)mp_oControl.Tasks.oCollection.m_oReturnArrayElement(lIndex);
                oTask.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oTask.StyleIndex);
                oTask.WarningStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oTask.WarningStyleIndex);
            }
            for (lIndex = 1; lIndex <= mp_oControl.Predecessors.Count; lIndex++)
            {
                oPredecessor = (clsPredecessor)mp_oControl.Predecessors.oCollection.m_oReturnArrayElement(lIndex);
                oPredecessor.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oPredecessor.StyleIndex);
                oPredecessor.WarningStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oPredecessor.WarningStyleIndex);
                oPredecessor.SelectedStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oPredecessor.SelectedStyleIndex);
            }
            for (lIndex = 1; lIndex <= mp_oControl.TimeBlocks.Count; lIndex++)
            {
                oTimeBlock = (clsTimeBlock)mp_oControl.TimeBlocks.oCollection.m_oReturnArrayElement(lIndex);
                oTimeBlock.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oTimeBlock.StyleIndex);
            }
            for (lIndex = 1; lIndex <= mp_oControl.Percentages.Count; lIndex++)
            {
                oPercentage = (clsPercentage)mp_oControl.Percentages.oCollection.m_oReturnArrayElement(lIndex);
                oPercentage.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oPercentage.StyleIndex);
            }
            for (lIndex = 1; lIndex <= mp_oControl.Views.Count; lIndex++)
            {
                oView = (clsView)mp_oControl.Views.oCollection.m_oReturnArrayElement(lIndex);
                oView.TimeLine.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.StyleIndex);
                oView.TimeLine.TickMarkArea.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TickMarkArea.StyleIndex);
                oView.TimeLine.TierArea.UpperTier.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TierArea.UpperTier.StyleIndex);
                oView.TimeLine.TierArea.MiddleTier.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TierArea.MiddleTier.StyleIndex);
                oView.TimeLine.TierArea.LowerTier.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TierArea.LowerTier.StyleIndex);
                oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex);
                oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex);
                oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex);
                oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex);
                oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex);
                oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex);
                oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex);
            }

            mp_oControl.TimeLineScrollBar.ScrollBar.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.TimeLineScrollBar.ScrollBar.StyleIndex);
            mp_oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex);
            mp_oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex);
            mp_oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex);
            mp_oControl.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex);
            mp_oControl.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex);
            mp_oControl.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, mp_oControl.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex);


            oView = mp_oControl.Views.FItem("0");
            oView.TimeLine.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.StyleIndex);
            oView.TimeLine.TickMarkArea.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TickMarkArea.StyleIndex);
            oView.TimeLine.TierArea.UpperTier.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TierArea.UpperTier.StyleIndex);
            oView.TimeLine.TierArea.MiddleTier.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TierArea.MiddleTier.StyleIndex);
            oView.TimeLine.TierArea.LowerTier.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TierArea.LowerTier.StyleIndex);
            oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex);
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex);
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex);
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex);
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex);
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex);
            oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = mp_GetNewStyleIndex(sRKey, sRIndex, oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex);

            mp_oCollection.m_Remove(Index, SYS_ERRORS.STYLES_REMOVE_1, SYS_ERRORS.STYLES_REMOVE_2, SYS_ERRORS.STYLES_REMOVE_3, SYS_ERRORS.STYLES_REMOVE_4);
        }

        private string mp_GetNewStyleIndex(string sKey, string sIndex, string sStyleIndex)
        {
            if (sIndex == sStyleIndex)
            {
                return "";
            }
            if (sKey == sStyleIndex)
            {
                return "";
            }
            return sStyleIndex;
        }

		public String GetXML()
		{
			int lIndex;
			clsStyle oStyle;
			clsXML oXML = new clsXML(mp_oControl, "Styles");
			oXML.InitializeWriter();
			for (lIndex = 1;lIndex <= Count;lIndex++) 
			{
				oStyle = (clsStyle) mp_oCollection.m_oReturnArrayElement(lIndex);
				oXML.WriteObject(oStyle.GetXML());
			}
			return oXML.GetXML();
		}

		public void SetXML(String sXML)
		{
			int lIndex;
			clsXML oXML = new clsXML(mp_oControl, "Styles");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			mp_oCollection.m_Clear();
			for (lIndex = 1;lIndex <= oXML.ReadCollectionCount();lIndex++) 
			{
                clsStyle oStyle = new clsStyle(mp_oControl);
				oStyle.SetXML(oXML.ReadCollectionObject(lIndex));
				mp_oCollection.AddMode = true;
				mp_oCollection.m_Add(oStyle, oStyle.Key, SYS_ERRORS.STYLES_ADD_1, SYS_ERRORS.STYLES_ADD_2, true, SYS_ERRORS.STYLES_ADD_3);
				oStyle = null;
			}
		}

        public IEnumerator GetEnumerator()
        {
            return mp_oCollection.mp_aoCollection.GetEnumerator();
        }

	}
}