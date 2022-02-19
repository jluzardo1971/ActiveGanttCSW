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
using System.Windows.Controls;
using System.Windows.Shapes;

namespace AGCSW
{
    internal class clsTextBox : System.Windows.Controls.TextBox
    {
        private ActiveGanttCSWCtl mp_oControl;
        private clsColumn mp_oColumn;
        private clsRow mp_oRow;
        private clsCell mp_oCell;
        private clsNode mp_oNode;
        private clsTask mp_oTask;
        private E_TEXTOBJECTTYPE mp_yObjectType;
        private string mp_sText;
        private int mp_lIndex;
        private int mp_lIndex2;
        internal bool mp_bInitialized;

        internal clsTextBox(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            KeyUp += clsTextBox_KeyUp1;
            this.BorderThickness = new Thickness(0, 0, 0, 0);
            
            mp_bInitialized = false;
            this.Padding = new Thickness(0, 0, 0, 0);
            this.Margin = new Thickness(0, 0, 0, 0);
        }

        public new bool Initialized
        {
            get { return mp_bInitialized; }
        }

        internal void Initialize(int lIndex, int lIndex2, E_TEXTOBJECTTYPE yObjectType, int X, int Y)
        {
            mp_yObjectType = yObjectType;
            mp_lIndex = lIndex;
            mp_lIndex2 = lIndex2;
            if (mp_bInitialized == true)
            {
                Terminate();
            }
            mp_oControl.MouseKeyboardEvents.mp_yOperation = E_OPERATION.EO_NONE;
            mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_NORMAL);
            switch (mp_yObjectType)
            {
                case E_TEXTOBJECTTYPE.TOT_COLUMN:
                    mp_oColumn = mp_oControl.Columns.Item(lIndex.ToString());
                    this.FontFamily = new FontFamily(mp_oColumn.Style.Font.FamilyName);
                    this.FontSize = mp_oColumn.Style.Font.WPFFontSize;
                    this.FontWeight = mp_oColumn.Style.Font.FontWeight;
                    this.SetValue(Canvas.LeftProperty, mp_oColumn.mp_lTextLeft);
                    this.SetValue(Canvas.TopProperty, mp_oColumn.mp_lTextTop);
                    this.Width = mp_oColumn.mp_lTextRight - mp_oColumn.mp_lTextLeft + 2;
                    this.Height = mp_oColumn.mp_lTextBottom - mp_oColumn.mp_lTextTop + 2;
                    this.Text = mp_oColumn.Text;
                    this.Background = new SolidColorBrush(mp_oColumn.Style.TextEditBackColor);
                    this.Foreground = new SolidColorBrush(mp_oColumn.Style.TextEditForeColor);
                    break;
                case E_TEXTOBJECTTYPE.TOT_NODE:
                    mp_oRow = mp_oControl.Rows.Item(lIndex.ToString());
                    mp_oNode = mp_oRow.Node;
                    this.FontFamily = new FontFamily(mp_oNode.Style.Font.FamilyName);
                    this.FontSize = mp_oNode.Style.Font.WPFFontSize;
                    this.FontWeight = mp_oNode.Style.Font.FontWeight;
                    this.SetValue(Canvas.LeftProperty, mp_oNode.mp_lTextLeft);
                    this.SetValue(Canvas.TopProperty, mp_oNode.mp_lTextTop);
                    this.Width = mp_oNode.mp_lTextRight - mp_oNode.mp_lTextLeft + 2;
                    this.Height = mp_oNode.mp_lTextBottom - mp_oNode.mp_lTextTop + 2;
                    this.Text = mp_oNode.Text;
                    this.Background = new SolidColorBrush(mp_oNode.Style.TextEditBackColor);
                    this.Foreground = new SolidColorBrush(mp_oNode.Style.TextEditForeColor);
                    break;
                case E_TEXTOBJECTTYPE.TOT_ROW:
                    mp_oRow = mp_oControl.Rows.Item(lIndex.ToString());
                    this.FontFamily = new FontFamily(mp_oRow.Style.Font.FamilyName);
                    this.FontSize = mp_oRow.Style.Font.WPFFontSize;
                    this.FontWeight = mp_oRow.Style.Font.FontWeight;
                    this.SetValue(Canvas.LeftProperty, mp_oRow.mp_lTextLeft);
                    this.SetValue(Canvas.TopProperty, mp_oRow.mp_lTextTop);
                    this.Width = mp_oRow.mp_lTextRight - mp_oRow.mp_lTextLeft + 2;
                    this.Height = mp_oRow.mp_lTextBottom - mp_oRow.mp_lTextTop + 2;
                    this.Text = mp_oRow.Text;
                    this.Background = new SolidColorBrush(mp_oRow.Style.TextEditBackColor);
                    this.Foreground = new SolidColorBrush(mp_oRow.Style.TextEditForeColor);
                    break;
                case E_TEXTOBJECTTYPE.TOT_CELL:
                    mp_oRow = mp_oControl.Rows.Item(lIndex.ToString());
                    mp_oCell = mp_oRow.Cells.Item(lIndex2.ToString());
                    this.FontFamily = new FontFamily(mp_oCell.Style.Font.FamilyName);
                    this.FontSize = mp_oCell.Style.Font.WPFFontSize;
                    this.FontWeight = mp_oCell.Style.Font.FontWeight;
                    this.SetValue(Canvas.LeftProperty, mp_oCell.mp_lTextLeft);
                    this.SetValue(Canvas.TopProperty, mp_oCell.mp_lTextTop);
                    this.Width = mp_oCell.mp_lTextRight - mp_oCell.mp_lTextLeft + 2;
                    this.Height = mp_oCell.mp_lTextBottom - mp_oCell.mp_lTextTop + 2;
                    this.Text = mp_oCell.Text;
                    this.Background = new SolidColorBrush(mp_oCell.Style.TextEditBackColor);
                    this.Foreground = new SolidColorBrush(mp_oCell.Style.TextEditForeColor);
                    break;
                case E_TEXTOBJECTTYPE.TOT_TASK:
                    mp_oTask = mp_oControl.Tasks.Item(lIndex.ToString());
                    this.FontFamily = new FontFamily(mp_oTask.Style.Font.FamilyName);
                    this.FontSize = mp_oTask.Style.Font.WPFFontSize;
                    this.FontWeight = mp_oTask.Style.Font.FontWeight;
                    this.SetValue(Canvas.LeftProperty, mp_oTask.mp_lTextLeft);
                    this.SetValue(Canvas.TopProperty, mp_oTask.mp_lTextTop);
                    this.Width = mp_oTask.mp_lTextRight - mp_oTask.mp_lTextLeft + 2;
                    this.Height = mp_oTask.mp_lTextBottom - mp_oTask.mp_lTextTop + 2;
                    this.Text = mp_oTask.Text;
                    this.Background = new SolidColorBrush(mp_oTask.Style.TextEditBackColor);
                    this.Foreground = new SolidColorBrush(mp_oTask.Style.TextEditForeColor);
                    break;
            }

            mp_oControl.f_Canvas().Children.Add(this);
            this.Focus();
            if (this.Text.Length > 0)
            {

            }
            mp_sText = this.Text;
            mp_oControl.TextEditEventArgs.Clear();
            mp_oControl.TextEditEventArgs.ObjectType = mp_yObjectType;
            if (mp_yObjectType == E_TEXTOBJECTTYPE.TOT_CELL)
            {
                mp_oControl.TextEditEventArgs.ParentObjectIndex = mp_lIndex;
                mp_oControl.TextEditEventArgs.ObjectIndex = mp_lIndex2;
            }
            else
            {
                mp_oControl.TextEditEventArgs.ParentObjectIndex = 0;
                mp_oControl.TextEditEventArgs.ObjectIndex = mp_lIndex;
            }
            mp_oControl.TextEditEventArgs.Text = this.Text;
            mp_oControl.FireBeginTextEdit();
            if (mp_oControl.TextEditEventArgs.Text != this.Text)
            {
                this.Text = mp_oControl.TextEditEventArgs.Text;
            }
            mp_bInitialized = true;
        }

        internal void Terminate()
        {
            if (mp_bInitialized == true)
            {
                mp_oControl.TextEditEventArgs.Clear();
                mp_oControl.TextEditEventArgs.ObjectType = mp_yObjectType;
                if (mp_yObjectType == E_TEXTOBJECTTYPE.TOT_CELL)
                {
                    mp_oControl.TextEditEventArgs.ParentObjectIndex = mp_lIndex;
                    mp_oControl.TextEditEventArgs.ObjectIndex = mp_lIndex2;
                }
                else
                {
                    mp_oControl.TextEditEventArgs.ParentObjectIndex = 0;
                    mp_oControl.TextEditEventArgs.ObjectIndex = mp_lIndex;
                }
                mp_oControl.TextEditEventArgs.Text = this.Text;
                mp_oControl.FireEndTextEdit();
            }
            mp_bInitialized = false;
            mp_oControl.f_Canvas().Children.Remove(this);
        }

        private void clsTextBox_KeyUp1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (mp_yObjectType)
            {
                case E_TEXTOBJECTTYPE.TOT_COLUMN:
                    mp_oColumn.Text = this.Text;
                    mp_oControl.ForceRender();
                    this.SetValue(Canvas.LeftProperty, mp_oColumn.mp_lTextLeft);
                    this.SetValue(Canvas.TopProperty, mp_oColumn.mp_lTextTop);
                    this.Width = mp_oColumn.mp_lTextRight - mp_oColumn.mp_lTextLeft + 2;
                    this.Height = mp_oColumn.mp_lTextBottom - mp_oColumn.mp_lTextTop + 2;
                    mp_oControl.Redraw();
                    break;
                case E_TEXTOBJECTTYPE.TOT_NODE:
                    mp_oNode.Text = this.Text;
                    mp_oControl.ForceRender();
                    this.SetValue(Canvas.LeftProperty, mp_oNode.mp_lTextLeft);
                    this.SetValue(Canvas.TopProperty, mp_oNode.mp_lTextTop);
                    this.Width = mp_oNode.mp_lTextRight - mp_oNode.mp_lTextLeft + 2;
                    this.Height = mp_oNode.mp_lTextBottom - mp_oNode.mp_lTextTop + 2;
                    mp_oControl.Redraw();
                    break;
                case E_TEXTOBJECTTYPE.TOT_ROW:
                    mp_oRow.Text = this.Text;
                    mp_oControl.ForceRender();
                    this.SetValue(Canvas.LeftProperty, mp_oRow.mp_lTextLeft);
                    this.SetValue(Canvas.TopProperty, mp_oRow.mp_lTextTop);
                    this.Width = mp_oRow.mp_lTextRight - mp_oRow.mp_lTextLeft + 2;
                    this.Height = mp_oRow.mp_lTextBottom - mp_oRow.mp_lTextTop + 2;
                    mp_oControl.Redraw();
                    break;
                case E_TEXTOBJECTTYPE.TOT_CELL:
                    mp_oCell.Text = this.Text;
                    mp_oControl.ForceRender();
                    this.SetValue(Canvas.LeftProperty, mp_oCell.mp_lTextLeft);
                    this.SetValue(Canvas.TopProperty, mp_oCell.mp_lTextTop);
                    this.Width = mp_oCell.mp_lTextRight - mp_oCell.mp_lTextLeft + 2;
                    this.Height = mp_oCell.mp_lTextBottom - mp_oCell.mp_lTextTop + 2;
                    mp_oControl.Redraw();
                    break;
                case E_TEXTOBJECTTYPE.TOT_TASK:
                    mp_oTask.Text = this.Text;
                    mp_oControl.ForceRender();
                    this.SetValue(Canvas.LeftProperty, mp_oTask.mp_lTextLeft);
                    this.SetValue(Canvas.TopProperty, mp_oTask.mp_lTextTop);
                    this.Width = mp_oTask.mp_lTextRight - mp_oTask.mp_lTextLeft + 2;
                    this.Height = mp_oTask.mp_lTextBottom - mp_oTask.mp_lTextTop + 2;
                    mp_oControl.Redraw();
                    break;
            }
        }

    }
}