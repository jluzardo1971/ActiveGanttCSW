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
using System.IO;
using System.Xml;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;

namespace AGCSW
{
	internal partial class clsXML
	{
        private ActiveGanttCSWCtl mp_oControl;
		private System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
		private System.Xml.XmlElement oControlElement;
		private System.Xml.XmlElement oFontElement;
        private System.Xml.XmlElement oDateTimeElement;
        private System.Xml.XmlElement oStyleElement;
		private String mp_sObject;
		private PE_LEVEL mp_yLevel;
        private bool mp_bSupportOptional = false;
        private bool mp_bBoolsAreNumeric = false;

        private enum PE_LEVEL
        {
            LVL_CONTROL = 0,
            LVL_FONT = 5,
            LVL_DATETIME = 6,
            LVL_STYLE = 7
        }

        internal bool SupportOptional
        {
            get { return mp_bSupportOptional; }
            set { mp_bSupportOptional = value; }
        }

        internal bool BoolsAreNumeric
        {
            get { return mp_bBoolsAreNumeric; }
            set { mp_bBoolsAreNumeric = value; }
        }

		internal clsXML(ActiveGanttCSWCtl oControl, String sObject)
		{
            mp_oControl = oControl;
			xDoc = new System.Xml.XmlDocument();
			xDoc.PreserveWhitespace = false;
			mp_sObject = sObject;
		}

		~clsXML()
		{
		}

		internal void InitializeWriter()
		{
			xDoc.LoadXml("<" + mp_sObject + "></" + mp_sObject + ">");
			oControlElement = GetDocumentElement(mp_sObject, 0);
			mp_yLevel = PE_LEVEL.LVL_CONTROL;
		}

		internal void InitializeReader()
		{
			oControlElement = GetDocumentElement(mp_sObject, 0);
			mp_yLevel = PE_LEVEL.LVL_CONTROL;
		}

        private System.Xml.XmlElement ParentElement()
        {
            switch (mp_yLevel)
            {
                case PE_LEVEL.LVL_CONTROL:
                    return oControlElement;
                case PE_LEVEL.LVL_FONT:
                    return oFontElement;
                case PE_LEVEL.LVL_DATETIME:
                    return oDateTimeElement;
                case PE_LEVEL.LVL_STYLE:
                    return oStyleElement;
            }
            return null;
        }

        private System.Xml.XmlElement mp_oCreateEmptyDOMElement(String sElementName)
        {
            System.Xml.XmlElement oNodeBuff;
            oNodeBuff = xDoc.CreateElement(sElementName);
            ParentElement().AppendChild(oNodeBuff);
            return oNodeBuff;
        }

        private System.Xml.XmlElement GetDocumentElement(String TagName, int lIndex)
        {
            return (System.Xml.XmlElement)xDoc.GetElementsByTagName(TagName).Item(lIndex);
        }

		internal String GetXML()
		{
			return xDoc.InnerXml;
		}

		internal void SetXML(String sXML)
		{
            if (mp_bSupportOptional == false)
            {
                xDoc.LoadXml(sXML);
            }
            else
            {
                if (sXML.Length > 0)
                {
                    xDoc.LoadXml(sXML);
                }
            }
		}

        internal void WriteXML(String sPath)
        {
            XmlTextWriter oWriter = new XmlTextWriter(sPath, System.Text.Encoding.UTF8);
            oWriter.IndentChar = '\t';
            oWriter.Formatting = Formatting.Indented;
            oWriter.WriteStartDocument();

            xDoc.Save(oWriter);
            oWriter.WriteEndDocument();
            oWriter.Close();
        }

        internal void ReadXML(String sPath)
        {
            xDoc.Load(sPath);
        }

        #region "Collections"

        internal String ReadCollectionObject(int lIndex)
        {
            if (mp_bSupportOptional == false)
            {
                return ParentElement().ChildNodes.Item(lIndex - 1).OuterXml;
            }
            else
            {
                if (ParentElement() == null | lIndex == 0)
                {
                    return "";
                }
                if (ParentElement().ChildNodes.Count > 0)
                {
                    return ParentElement().ChildNodes.Item(lIndex - 1).OuterXml;
                }
                else
                {
                    return "";
                }
            }
        }

        internal string GetCollectionObjectName(int lIndex)
        {
            return ParentElement().ChildNodes.Item(lIndex - 1).Name;
        }

        internal int ReadCollectionCount()
        {
            if (mp_bSupportOptional == false)
            {
                return ParentElement().ChildNodes.Count;
            }
            else
            {
                if (ParentElement() == null)
                {
                    return 0;
                }
                else
                {
                    return ParentElement().ChildNodes.Count;
                }
            }
        }

        #endregion

        #region "XML Objects"

        internal String ReadObject(String sObjectName)
        {
            if (mp_bSupportOptional == false)
            {
                return ParentElement().GetElementsByTagName(sObjectName).Item(0).OuterXml;
            }
            else
            {
                if (ParentElement() == null)
                {
                    return "";
                }
                if (ParentElement().GetElementsByTagName(sObjectName).Count > 0)
                {
                    return ParentElement().GetElementsByTagName(sObjectName).Item(0).OuterXml;
                }
                else
                {
                    return "";
                }
            }
        }

        internal void WriteObject(String sObjectText)
        {
            System.Xml.XmlDocument xDoc1;
            System.Xml.XmlElement oNodeBuff;
            xDoc1 = new System.Xml.XmlDocument();
            xDoc1.LoadXml(sObjectText);
            oNodeBuff = (System.Xml.XmlElement)xDoc.ImportNode(xDoc1.DocumentElement, true);
            ParentElement().AppendChild(oNodeBuff);
        }

        #endregion

        #region "Enumerations"

        internal void ReadProperty(string sElementName, ref E_BORDERSTYLE yValue)
        {
            yValue = (E_BORDERSTYLE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_BORDERSTYLE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_TEXTPLACEMENT yValue)
        {
            yValue = (E_TEXTPLACEMENT)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_TEXTPLACEMENT yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_PLACEMENT yValue)
        {
            yValue = (E_PLACEMENT)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_PLACEMENT yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_REPORTERRORS yValue)
        {
            yValue = (E_REPORTERRORS)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_REPORTERRORS yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_SCROLLBEHAVIOUR yValue)
        {
            yValue = (E_SCROLLBEHAVIOUR)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_SCROLLBEHAVIOUR yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_STYLEAPPEARANCE yValue)
        {
            yValue = (E_STYLEAPPEARANCE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_STYLEAPPEARANCE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref GRE_BORDERSTYLE yValue)
        {
            yValue = (GRE_BORDERSTYLE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, GRE_BORDERSTYLE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref GRE_PATTERN yValue)
        {
            yValue = (GRE_PATTERN)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, GRE_PATTERN yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref GRE_BUTTONSTYLE yValue)
        {
            yValue = (GRE_BUTTONSTYLE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, GRE_BUTTONSTYLE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref GRE_FIGURETYPE yValue)
        {
            yValue = (GRE_FIGURETYPE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, GRE_FIGURETYPE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref GRE_GRADIENTFILLMODE yValue)
        {
            yValue = (GRE_GRADIENTFILLMODE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, GRE_GRADIENTFILLMODE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref GRE_HORIZONTALALIGNMENT yValue)
        {
            yValue = (GRE_HORIZONTALALIGNMENT)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, GRE_HORIZONTALALIGNMENT yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref GRE_LINEDRAWSTYLE yValue)
        {
            yValue = (GRE_LINEDRAWSTYLE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, GRE_LINEDRAWSTYLE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref GRE_VERTICALALIGNMENT yValue)
        {
            yValue = (GRE_VERTICALALIGNMENT)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, GRE_VERTICALALIGNMENT yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_ADDMODE yValue)
        {
            yValue = (E_ADDMODE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_ADDMODE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_LAYEROBJECTENABLE yValue)
        {
            yValue = (E_LAYEROBJECTENABLE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_LAYEROBJECTENABLE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_TIMEBLOCKBEHAVIOUR yValue)
        {
            yValue = (E_TIMEBLOCKBEHAVIOUR)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_TIMEBLOCKBEHAVIOUR yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_MOVEMENTTYPE yValue)
        {
            yValue = (E_MOVEMENTTYPE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_MOVEMENTTYPE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_CONSTRAINTTYPE yValue)
        {
            yValue = (E_CONSTRAINTTYPE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_CONSTRAINTTYPE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_PROGRESSLINELENGTH yValue)
        {
            yValue = (E_PROGRESSLINELENGTH)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_PROGRESSLINELENGTH yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_PROGRESSLINETYPE yValue)
        {
            yValue = (E_PROGRESSLINETYPE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_PROGRESSLINETYPE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_TICKMARKTYPES yValue)
        {
            yValue = (E_TICKMARKTYPES)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_TICKMARKTYPES yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_TIERPOSITION yValue)
        {
            yValue = (E_TIERPOSITION)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_TIERPOSITION yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_TIERTYPE yValue)
        {
            yValue = (E_TIERTYPE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_TIERTYPE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_CONTROLMODE yValue)
        {
            yValue = (E_CONTROLMODE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_CONTROLMODE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref GRE_BACKGROUNDMODE yValue)
        {
            yValue = (GRE_BACKGROUNDMODE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, GRE_BACKGROUNDMODE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref GRE_HATCHSTYLE yValue)
        {
            yValue = (GRE_HATCHSTYLE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, GRE_HATCHSTYLE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref GRE_FILLMODE yValue)
        {
            yValue = (GRE_FILLMODE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, GRE_FILLMODE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_WEEKDAY yValue)
        {
            yValue = (E_WEEKDAY)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_WEEKDAY yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_TIMEBLOCKTYPE yValue)
        {
            yValue = (E_TIMEBLOCKTYPE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_TIMEBLOCKTYPE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_RECURRINGTYPE yValue)
        {
            yValue = (E_RECURRINGTYPE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_RECURRINGTYPE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_INTERVAL yValue)
        {
            yValue = (E_INTERVAL)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_INTERVAL yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_SPLITTERTYPE yValue)
        {
            yValue = (E_SPLITTERTYPE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_SPLITTERTYPE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_TIERBACKGROUNDMODE yValue)
        {
            yValue = (E_TIERBACKGROUNDMODE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_TIERBACKGROUNDMODE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_SELECTIONRECTANGLEMODE yValue)
        {
            yValue = (E_SELECTIONRECTANGLEMODE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_SELECTIONRECTANGLEMODE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_PREDECESSORMODE yValue)
        {
            yValue = (E_PREDECESSORMODE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_PREDECESSORMODE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_TASKTYPE yValue)
        {
            yValue = (E_TASKTYPE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_TASKTYPE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_TBINTERVALTYPE yValue)
        {
            yValue = (E_TBINTERVALTYPE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_TBINTERVALTYPE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_PROGRESSLINESTYLE yValue)
        {
            yValue = (E_PROGRESSLINESTYLE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_PROGRESSLINESTYLE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_OBJECTSCOPE yValue)
        {
            yValue = (E_OBJECTSCOPE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_OBJECTSCOPE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_CALENDARWEEKRULES yValue)
        {
            yValue = (E_CALENDARWEEKRULES)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_CALENDARWEEKRULES yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        internal void ReadProperty(string sElementName, ref E_TREEVIEWMODE yValue)
        {
            yValue = (E_TREEVIEWMODE)yReadProperty(sElementName, (int)yValue);
        }

        internal void WriteProperty(string sElementName, E_TREEVIEWMODE yValue)
        {
            int lParam = (Int32)yValue;
            WriteProperty(sElementName, lParam);
        }

        #endregion

        #region "Boolean"

        internal void ReadProperty(String sElementName, ref bool bValue)
        {
            if (mp_bSupportOptional == false)
            {
                if (ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText == "false" | ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText == "0")
                {
                    bValue = false;
                }
                else
                {
                    bValue = true;
                }
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().GetElementsByTagName(sElementName).Count > 0)
                {
                    if (ParentElement().GetElementsByTagName(sElementName).Item(0).ParentNode.Name == ParentElement().Name)
                    {
                        if (ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText == "false" | ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText == "0")
                        {
                            bValue = false;
                        }
                        else
                        {
                            bValue = true;
                        }
                    }
                }
            }
        }

        internal void WriteProperty(String sElementName, bool bValue)
        {
            System.Xml.XmlElement oNodeBuff = null;
            oNodeBuff = xDoc.CreateElement(sElementName);
            if (System.Convert.ToBoolean(bValue) == true)
            {
                oNodeBuff.InnerText = "true";
            }
            else
            {
                oNodeBuff.InnerText = "false";
            }
            ParentElement().AppendChild(oNodeBuff);
        }

        #endregion

        #region "Int32"

        internal void ReadProperty(String sElementName, ref int lValue)
        {
            lValue = yReadProperty(sElementName, lValue);
        }

        private int yReadProperty(string v_sNodeName, int yValue)
        {
            if (mp_bSupportOptional == false)
            {
                return System.Convert.ToInt32(ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return yValue;
                }
                if (ParentElement().GetElementsByTagName(v_sNodeName).Count > 0)
                {
                    return System.Convert.ToInt32(ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText);
                }
                else
                {
                    return yValue;
                }
            }

        }

        internal void WriteProperty(String sElementName, int lValue)
        {
            System.Xml.XmlElement oNodeBuff = null;
            oNodeBuff = xDoc.CreateElement(sElementName);
            oNodeBuff.InnerText = lValue.ToString();
            ParentElement().AppendChild(oNodeBuff);
        }

        #endregion

        #region "Int16"

        internal void ReadProperty(String sElementName, ref short iValue)
        {
            if (mp_bSupportOptional == false)
            {
                iValue = System.Convert.ToInt16(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().GetElementsByTagName(sElementName).Count > 0)
                {
                    iValue = System.Convert.ToInt16(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText);
                }
            }
        }

        internal void WriteProperty(String sElementName, short iValue)
        {
            System.Xml.XmlElement oNodeBuff = null;
            oNodeBuff = xDoc.CreateElement(sElementName);
            oNodeBuff.InnerText = iValue.ToString();
            ParentElement().AppendChild(oNodeBuff);
        }

        #endregion

        #region "Single"

        internal void ReadProperty(String sElementName, ref float fValue)
        {
            if (mp_bSupportOptional == false)
            {
                fValue = System.Convert.ToSingle(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().GetElementsByTagName(sElementName).Count > 0)
                {
                    fValue = System.Convert.ToSingle(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText);
                }
            }
        }

        internal void WriteProperty(String sElementName, float fValue)
        {
            System.Xml.XmlElement oNodeBuff = null;
            oNodeBuff = xDoc.CreateElement(sElementName);
            oNodeBuff.InnerText = fValue.ToString();
            ParentElement().AppendChild(oNodeBuff);
        }

        #endregion

        #region "String"

        internal void ReadProperty(String sElementName, ref string sValue)
        {
            if (mp_bSupportOptional == false)
            {
                sValue = ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText;
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().GetElementsByTagName(sElementName).Count > 0)
                {
                    if (ParentElement().GetElementsByTagName(sElementName).Item(0).ParentNode.Name == ParentElement().Name)
                    {
                        sValue = ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText;
                    }
                }
            }
        }

        internal void WriteProperty(String sElementName, string sValue)
        {
            System.Xml.XmlElement oNodeBuff = null;
            oNodeBuff = xDoc.CreateElement(sElementName);
            oNodeBuff.InnerText = sValue.ToString();
            ParentElement().AppendChild(oNodeBuff);
        }

        #endregion

        #region "System.Windows.Media.Color"

        public void ReadProperty(string sElementName, ref System.Windows.Media.Color clrValue)
        {
            long lResult = 0;
            if (mp_bSupportOptional == false)
            {
                lResult = Convert.ToInt32(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().GetElementsByTagName(sElementName).Count > 0)
                {
                    lResult = Convert.ToInt32(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText);
                }
            }
            byte lR = 0;
            byte lG = 0;
            byte lB = 0;
            lB = System.Convert.ToByte(System.Math.Floor((double)lResult / 65536));
            lResult = lResult - (lB * 65536);
            lG = System.Convert.ToByte(System.Math.Floor((double)lResult / 256));
            lResult = lResult - (lG * 256);
            lR = (byte)lResult;
            clrValue = System.Windows.Media.Color.FromArgb(255, lR, lG, lB);
        }

        internal void WriteProperty(String sElementName, System.Windows.Media.Color clrValue)
        {
            System.Xml.XmlElement oNodeBuff = null;
            oNodeBuff = xDoc.CreateElement(sElementName);
            System.Windows.Media.Color clrReturn = clrValue;
            long lResult = (clrReturn.B * 65536) + (clrReturn.G * 256) + clrReturn.R;
            oNodeBuff.InnerText = lResult.ToString();
            ParentElement().AppendChild(oNodeBuff);
        }

        #endregion

        #region "Font"

        internal void ReadProperty(String sElementName, ref Font oFont)
        {
            PE_LEVEL mp_yBackupLevel;
            string sName = "";
            float fSize = 0;
            bool bDummy = false;
            oFontElement = (XmlElement)ParentElement().GetElementsByTagName(sElementName).Item(0);
            mp_yBackupLevel = mp_yLevel;
            mp_yLevel = PE_LEVEL.LVL_FONT;
            ReadProperty("Name", ref sName);
            ReadProperty("Size", ref fSize);
            if (sName == "MS Sans Serif")
            {
                sName = "Microsoft Sans Serif";
            }
            Font oFontBuff = new Font(sName, fSize);
            ReadProperty("Bold", ref bDummy);
            if (bDummy == true)
            {
                oFontBuff.FontWeight = FontWeights.Bold;
            }
            ReadProperty("Italic", ref bDummy);
            if (bDummy == true)
            {
                oFontBuff.FontStyle = FontStyles.Italic;
            }
            ReadProperty("Underline", ref bDummy);
            oFontBuff.Underline = bDummy;
            mp_yLevel = mp_yBackupLevel;
            oFont = oFontBuff;
        }

        internal void WriteProperty(String sElementName, Font oFont)
        {
            PE_LEVEL mp_yBackupLevel;
            oFontElement = mp_oCreateEmptyDOMElement(sElementName);
            mp_yBackupLevel = mp_yLevel;
            mp_yLevel = PE_LEVEL.LVL_FONT;
            WriteProperty("Name", oFont.Name);
            WriteProperty("Size", Globals.g_Replace(System.Convert.ToString(oFont.Size), Globals.g_GetDecimalSeparator(), "."));
            WriteProperty("Bold", oFont.Bold);
            WriteProperty("Italic", oFont.Italic);
            WriteProperty("Underline", oFont.Underline);
            mp_yLevel = mp_yBackupLevel;
        }

        #endregion

        #region "Image"

        internal void ReadProperty(String sElementName, ref Image oImage)
        {
            if (!string.IsNullOrEmpty(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText))
            {
                string data = ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText;
                System.IO.MemoryStream mem = new System.IO.MemoryStream(Convert.FromBase64String(data));
                System.Windows.Media.Imaging.BitmapDecoder oBitmapDecoder = System.Windows.Media.Imaging.BitmapDecoder.Create(mem, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                oImage = new System.Windows.Controls.Image();
                oImage.Source = oBitmapDecoder.Frames[0];
            }
            else
            {
                oImage = null;
            }
        }

        internal void WriteProperty(String sElementName, ref Image oImage)
        {
            string sObjectText = null;
            System.Xml.XmlElement oNodeBuff = null;
            if ((oImage != null))
            {
                System.Xml.XmlDocument xDoc1 = null;
                xDoc1 = new System.Xml.XmlDocument();
                sObjectText = "<" + sElementName + " xmlns:dt=\"urn:schemas-microsoft-com:datatypes\" dt:dt=\"bin.base64\"></" + sElementName + ">";
                xDoc1.LoadXml(sObjectText);
                oNodeBuff = (XmlElement)xDoc.ImportNode(xDoc1.DocumentElement, true);
                System.IO.MemoryStream mem = new System.IO.MemoryStream();
                string data = null;
                System.Windows.Media.Imaging.PngBitmapEncoder oBitmap = new System.Windows.Media.Imaging.PngBitmapEncoder();
                oBitmap.Frames.Add(BitmapFrame.Create((BitmapSource)oImage.Source));
                oBitmap.Save(mem);
                data = Convert.ToBase64String(mem.ToArray());
                oNodeBuff.InnerText = data;
            }
            else
            {
                oNodeBuff = xDoc.CreateElement(sElementName);
            }
            ParentElement().AppendChild(oNodeBuff);
        }

        #endregion

        #region "System.DateTime"

        internal void ReadProperty(String sElementName, ref System.DateTime dtValue)
        {
            if (mp_bSupportOptional == false)
            {
                dtValue = mp_dtGetDateFromXML(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().GetElementsByTagName(sElementName).Count > 0)
                {
                    dtValue = mp_dtGetDateFromXML(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText);
                }
            }
        }

        private System.DateTime mp_dtGetDateFromXML(String sParam)
        {
            System.DateTime dtReturn;
            int lYear = System.Convert.ToInt32(sParam.Substring(0, 4));
            int lMonth = System.Convert.ToInt32(sParam.Substring(5, 2));
            int lDay = System.Convert.ToInt32(sParam.Substring(8, 2));
            int lHours = System.Convert.ToInt32(sParam.Substring(11, 2));
            int lMinutes = System.Convert.ToInt32(sParam.Substring(14, 2));
            int lSeconds = System.Convert.ToInt32(sParam.Substring(17, 2));
            int lMilliseconds = System.Convert.ToInt32(sParam.Substring(20, 3));
            dtReturn = new System.DateTime(lYear, lMonth, lDay, lHours, lMinutes, lSeconds, lMilliseconds);
            return dtReturn;
        }

        private String mp_sGetXMLDateString(System.DateTime dtParam)
        {
            return dtParam.Year.ToString("0000") + "-" + dtParam.Month.ToString("00") + "-" + dtParam.Day.ToString("00") + "T" + dtParam.Hour.ToString("00") + ":" + dtParam.Minute.ToString("00") + ":" + dtParam.Second.ToString("00") + "." + dtParam.Millisecond.ToString("000");
        }

        internal void WriteProperty(String sElementName, System.DateTime dtValue)
        {
            System.Xml.XmlElement oNodeBuff = null;
            oNodeBuff = xDoc.CreateElement(sElementName);
            oNodeBuff.InnerText = mp_sGetXMLDateString(System.Convert.ToDateTime(dtValue));
            ParentElement().AppendChild(oNodeBuff);
        }

        #endregion

        #region "DateTime"

        //internal void ReadProperty(String sElementName, ref DateTime oDate)
        //{
        //    PE_LEVEL mp_yBackupLevel;
        //    oDateTimeElement = (System.Xml.XmlElement)ParentElement().GetElementsByTagName(sElementName).Item(0);
        //    mp_yBackupLevel = mp_yLevel;
        //    mp_yLevel = PE_LEVEL.LVL_DATETIME;
        //    System.DateTime dtDateTime = new System.DateTime(0);
        //    ReadProperty("DateTime", ref dtDateTime);
        //    oDate.DateTimePart = dtDateTime;
        //    mp_yLevel = mp_yBackupLevel;
        //}

        //internal void WriteProperty(String sElementName, DateTime oDate)
        //{
        //    PE_LEVEL mp_yBackupLevel;
        //    mp_yBackupLevel = mp_yLevel;
        //    oDateTimeElement = mp_oCreateEmptyDOMElement(sElementName);
        //    mp_yLevel = PE_LEVEL.LVL_DATETIME;
        //    WriteProperty("DateTime", oDate.DateTimePart);
        //    mp_yLevel = mp_yBackupLevel;
        //}

        #endregion

        #region "Default Styles"

        internal void ReadProperty(string sElementName, ref clsStyle oStyle)
        {
            PE_LEVEL mp_yBackupLevel;
            oStyleElement = (System.Xml.XmlElement)ParentElement().GetElementsByTagName(sElementName).Item(0);
            mp_yBackupLevel = mp_yLevel;
            mp_yLevel = PE_LEVEL.LVL_STYLE;
            oStyle.SetXML(ReadObject("Style"));
            mp_yLevel = mp_yBackupLevel;
        }

        internal void WriteProperty(string sElementName, clsStyle oStyle)
        {
            PE_LEVEL mp_yBackupLevel;
            mp_yBackupLevel = mp_yLevel;
            oStyleElement = mp_oCreateEmptyDOMElement(sElementName);
            mp_yLevel = PE_LEVEL.LVL_STYLE;
            WriteObject(oStyle.GetXML());
            mp_yLevel = mp_yBackupLevel;
        }

        #endregion

	}
}