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
using System.Windows.Media;

namespace AGCSW
{
    public class clsConfiguration
    {

        private ActiveGanttCSWCtl mp_oControl;
        private E_WEEKDAY mp_yFirstDayOfWeek;
        private E_CALENDARWEEKRULES mp_yCalendarWeekRule;
        private bool mp_bISO8601Weeks;
        private Color mp_clrRowHighlightedBackColor;
        private Color mp_clrRowEvenBackColor;
        private Color mp_clrRowOddBackColor;
        private bool mp_bAlternatingRowStyles;
        private Font mp_oDefaultFont;

        internal clsConfiguration(ActiveGanttCSWCtl oControl)
        {
            mp_oControl = oControl;
            mp_yFirstDayOfWeek = E_WEEKDAY.WD_SUNDAY;
            mp_yCalendarWeekRule = E_CALENDARWEEKRULES.CWR_FIRSTDAY;
            mp_bISO8601Weeks = false;
            mp_clrRowHighlightedBackColor = Color.FromArgb(255, 255, 0, 0);
            mp_clrRowEvenBackColor = Color.FromArgb(255, 255, 255, 255);
            mp_clrRowOddBackColor = Color.FromArgb(255, 192, 192, 192);
            mp_bAlternatingRowStyles = false;
            mp_oDefaultFont = new Font("Tahoma", 8);
        }

        public Font DefaultFont
        {
            get { return mp_oDefaultFont; }
            set { mp_oDefaultFont = value; }
        }

        public Color RowHighlightedBackColor
        {
            get { return mp_clrRowHighlightedBackColor; }
            set { mp_clrRowHighlightedBackColor = value; }
        }

        public Color RowEvenBackColor
        {
            get { return mp_clrRowEvenBackColor; }
            set { mp_clrRowEvenBackColor = value; }
        }

        public Color RowOddBackColor
        {
            get { return mp_clrRowOddBackColor; }
            set { mp_clrRowOddBackColor = value; }
        }

        public bool AlternatingRowStyles
        {
            get { return mp_bAlternatingRowStyles; }
            set { mp_bAlternatingRowStyles = value; }
        }

        public E_WEEKDAY FirstDayOfWeek
        {
            get { return mp_yFirstDayOfWeek; }
            set { mp_yFirstDayOfWeek = value; }
        }

        public E_CALENDARWEEKRULES CalendarWeekRule
        {
            get { return mp_yCalendarWeekRule; }
            set { mp_yCalendarWeekRule = value; }
        }

        public bool ISO8601Weeks
        {
            get { return mp_bISO8601Weeks; }
            set { mp_bISO8601Weeks = true; }
        }

        public clsStyle DefaultControlStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultControlStyle; }
        }


        public clsStyle DefaultTaskStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultTaskStyle; }
        }

        public clsStyle DefaultRowStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultRowStyle; }
        }

        public clsStyle DefaultClientAreaStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultClientAreaStyle; }
        }

        public clsStyle DefaultCellStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultCellStyle; }
        }

        public clsStyle DefaultColumnStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultColumnStyle; }
        }

        public clsStyle DefaultPercentageStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultPercentageStyle; }
        }

        public clsStyle DefaultPredecessorStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultPredecessorStyle; }
        }

        public clsStyle DefaultTimeLineStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultTimeLineStyle; }
        }

        public clsStyle DefaultTimeBlockStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultTimeBlockStyle; }
        }

        public clsStyle DefaultTickMarkAreaStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultTickMarkAreaStyle; }
        }

        public clsStyle DefaultSplitterStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultSplitterStyle; }
        }

        public clsStyle DefaultProgressLineStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultProgressLineStyle; }
        }

        public clsStyle DefaultNodeStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultNodeStyle; }
        }

        public clsStyle DefaultTierStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultTierStyle; }
        }

        public clsStyle DefaultScrollBarStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultScrollBarStyle; }
        }

        public clsStyle DefaultSBSeparatorStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultSBSeparatorStyle; }
        }

        public clsStyle DefaultSBNormalStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultSBNormalStyle; }
        }

        public clsStyle DefaultSBPressedStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultSBPressedStyle; }
        }

        public clsStyle DefaultSBDisabledStyle
        {
            get { return mp_oControl.Styles.mp_oDefaultSBDisabledStyle; }
        }

        public string GetXML()
        {
            clsXML oXML = new clsXML(mp_oControl, "Configuration");
            oXML.InitializeWriter();
            oXML.WriteProperty("FirstDayOfWeek", mp_yFirstDayOfWeek);
            oXML.WriteProperty("CalendarWeekRule", mp_yCalendarWeekRule);
            oXML.WriteProperty("ISO8601Weeks", mp_bISO8601Weeks);
            oXML.WriteProperty("RowHighlightedBackColor", mp_clrRowHighlightedBackColor);
            oXML.WriteProperty("AlternatingRowStyles", mp_bAlternatingRowStyles);
            oXML.WriteProperty("RowOddBackColor", mp_clrRowOddBackColor);
            oXML.WriteProperty("RowEvenBackColor", mp_clrRowEvenBackColor);
            oXML.WriteProperty("DefaultFont", mp_oDefaultFont);
            oXML.WriteProperty("DefaultControlStyle", mp_oControl.Styles.mp_oDefaultControlStyle);
            oXML.WriteProperty("DefaultTaskStyle", mp_oControl.Styles.mp_oDefaultTaskStyle);
            oXML.WriteProperty("DefaultRowStyle", mp_oControl.Styles.mp_oDefaultRowStyle);
            oXML.WriteProperty("DefaultClientAreaStyle", mp_oControl.Styles.mp_oDefaultClientAreaStyle);
            oXML.WriteProperty("DefaultCellStyle", mp_oControl.Styles.mp_oDefaultCellStyle);
            oXML.WriteProperty("DefaultColumnStyle", mp_oControl.Styles.mp_oDefaultColumnStyle);
            oXML.WriteProperty("DefaultPercentageStyle", mp_oControl.Styles.mp_oDefaultPercentageStyle);
            oXML.WriteProperty("DefaultPredecessorStyle", mp_oControl.Styles.mp_oDefaultPredecessorStyle);
            oXML.WriteProperty("DefaultTimeLineStyle", mp_oControl.Styles.mp_oDefaultTimeLineStyle);
            oXML.WriteProperty("DefaultTimeBlockStyle", mp_oControl.Styles.mp_oDefaultTimeBlockStyle);
            oXML.WriteProperty("DefaultTickMarkAreaStyle", mp_oControl.Styles.mp_oDefaultTickMarkAreaStyle);
            oXML.WriteProperty("DefaultSplitterStyle", mp_oControl.Styles.mp_oDefaultSplitterStyle);
            oXML.WriteProperty("DefaultProgressLineStyle", mp_oControl.Styles.mp_oDefaultProgressLineStyle);
            oXML.WriteProperty("DefaultNodeStyle", mp_oControl.Styles.mp_oDefaultNodeStyle);
            oXML.WriteProperty("DefaultTierStyle", mp_oControl.Styles.mp_oDefaultTierStyle);
            oXML.WriteProperty("DefaultScrollBarStyle", mp_oControl.Styles.mp_oDefaultScrollBarStyle);
            oXML.WriteProperty("DefaultSBSeparatorStyle", mp_oControl.Styles.mp_oDefaultSBSeparatorStyle);
            oXML.WriteProperty("DefaultSBNormalStyle", mp_oControl.Styles.mp_oDefaultSBNormalStyle);
            oXML.WriteProperty("DefaultSBPressedStyle", mp_oControl.Styles.mp_oDefaultSBPressedStyle);
            oXML.WriteProperty("DefaultSBDisabledStyle", mp_oControl.Styles.mp_oDefaultSBDisabledStyle);

            return oXML.GetXML();
        }

        public void SetXML(string sXML)
        {
            clsXML oXML = new clsXML(mp_oControl, "Configuration");
            oXML.SetXML(sXML);
            oXML.InitializeReader();
            oXML.ReadProperty("FirstDayOfWeek", ref mp_yFirstDayOfWeek);
            oXML.ReadProperty("CalendarWeekRule", ref mp_yCalendarWeekRule);
            oXML.ReadProperty("ISO8601Weeks", ref mp_bISO8601Weeks);
            oXML.ReadProperty("RowHighlightedBackColor", ref mp_clrRowHighlightedBackColor);
            oXML.ReadProperty("AlternatingRowStyles", ref mp_bAlternatingRowStyles);
            oXML.ReadProperty("RowOddBackColor", ref mp_clrRowOddBackColor);
            oXML.ReadProperty("RowEvenBackColor", ref mp_clrRowEvenBackColor);
            oXML.ReadProperty("DefaultFont", ref mp_oDefaultFont);
            oXML.ReadProperty("DefaultControlStyle", ref mp_oControl.Styles.mp_oDefaultControlStyle);
            oXML.ReadProperty("DefaultTaskStyle", ref mp_oControl.Styles.mp_oDefaultTaskStyle);
            oXML.ReadProperty("DefaultRowStyle", ref mp_oControl.Styles.mp_oDefaultRowStyle);
            oXML.ReadProperty("DefaultClientAreaStyle", ref mp_oControl.Styles.mp_oDefaultClientAreaStyle);
            oXML.ReadProperty("DefaultCellStyle", ref mp_oControl.Styles.mp_oDefaultCellStyle);
            oXML.ReadProperty("DefaultColumnStyle", ref mp_oControl.Styles.mp_oDefaultColumnStyle);
            oXML.ReadProperty("DefaultPercentageStyle", ref mp_oControl.Styles.mp_oDefaultPercentageStyle);
            oXML.ReadProperty("DefaultPredecessorStyle", ref mp_oControl.Styles.mp_oDefaultPredecessorStyle);
            oXML.ReadProperty("DefaultTimeLineStyle", ref mp_oControl.Styles.mp_oDefaultTimeLineStyle);
            oXML.ReadProperty("DefaultTimeBlockStyle", ref mp_oControl.Styles.mp_oDefaultTimeBlockStyle);
            oXML.ReadProperty("DefaultTickMarkAreaStyle", ref mp_oControl.Styles.mp_oDefaultTickMarkAreaStyle);
            oXML.ReadProperty("DefaultSplitterStyle", ref mp_oControl.Styles.mp_oDefaultSplitterStyle);
            oXML.ReadProperty("DefaultProgressLineStyle", ref mp_oControl.Styles.mp_oDefaultProgressLineStyle);
            oXML.ReadProperty("DefaultNodeStyle", ref mp_oControl.Styles.mp_oDefaultNodeStyle);
            oXML.ReadProperty("DefaultTierStyle", ref mp_oControl.Styles.mp_oDefaultTierStyle);
            oXML.ReadProperty("DefaultScrollBarStyle", ref mp_oControl.Styles.mp_oDefaultScrollBarStyle);
            oXML.ReadProperty("DefaultSBSeparatorStyle", ref mp_oControl.Styles.mp_oDefaultSBSeparatorStyle);
            oXML.ReadProperty("DefaultSBNormalStyle", ref mp_oControl.Styles.mp_oDefaultSBNormalStyle);
            oXML.ReadProperty("DefaultSBPressedStyle", ref mp_oControl.Styles.mp_oDefaultSBPressedStyle);
            oXML.ReadProperty("DefaultSBDisabledStyle", ref mp_oControl.Styles.mp_oDefaultSBDisabledStyle);
        }

    }
}