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

namespace MSP2003
{
    internal partial class clsXML
    {
        private System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
        private System.Xml.XmlElement oControlElement;
        private System.Xml.XmlElement oFontElement = null;
        private System.Xml.XmlElement oDateTimeElement = null;
        private String mp_sObject;
        private PE_LEVEL mp_yLevel;
        private bool mp_bSupportOptional = false;
        private bool mp_bBoolsAreNumeric = false;

        private enum PE_LEVEL
        {
            LVL_CONTROL = 0,
            LVL_FONT = 5,
            LVL_DATETIME = 6,
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

        internal clsXML(String sObject)
        {
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

        internal System.Xml.XmlDocument GetDocument
        {
            get { return xDoc; }
        }

        internal void AddAttribute(string sName, string sValue)
        {
            XmlAttribute oAttribute = xDoc.CreateAttribute(sName);
            oAttribute.Value = sValue;
            xDoc.DocumentElement.Attributes.Append(oAttribute);
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

        internal int GetFirstCollectionItem(string sItemName)
        {
            int lIndex = 0;
            for (lIndex = 1; lIndex <= ReadCollectionCount(); lIndex++)
            {
                if (ParentElement().ChildNodes.Item(lIndex - 1).Name == sItemName)
                {
                    return lIndex;
                }
            }
            return ReadCollectionCount() + 1;
        }

        internal int GetLastCollectionItem(string sItemName)
        {
            int lIndex = 0;
            for (lIndex = ReadCollectionCount(); lIndex >= 1; lIndex += -1)
            {
                if (ParentElement().ChildNodes.Item(lIndex - 1).Name == sItemName)
                {
                    return lIndex;
                }
            }
            return 0;
        }

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

        internal void ReadProperty(String sElementName, ref int sElementValue)
        {
            sElementValue = lReadProperty(sElementName, sElementValue);
        }

        internal void ReadProperty(String sElementName, ref short sElementValue)
        {
            sElementValue = iReadProperty(sElementName, sElementValue);
        }

        internal void ReadProperty(String sElementName, ref string sElementValue)
        {
            sElementValue = sReadProperty(sElementName, sElementValue);
        }

        internal void ReadProperty(String sElementName, ref bool sElementValue)
        {
            sElementValue = bReadProperty(sElementName, sElementValue);
        }

        internal void ReadProperty(String sElementName, ref System.DateTime sElementValue)
        {
            sElementValue = dtReadProperty(sElementName, sElementValue);
        }

        private int lReadProperty(string v_sNodeName, int sElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                return System.Convert.ToInt32(ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return sElementValue;
                }
                if (ParentElement().GetElementsByTagName(v_sNodeName).Count > 0)
                {
                    return System.Convert.ToInt32(ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText);
                }
                else
                {
                    return sElementValue;
                }
            }
        }

        private short iReadProperty(string v_sNodeName, short sElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                return System.Convert.ToInt16(ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return sElementValue;
                }
                if (ParentElement().GetElementsByTagName(v_sNodeName).Count > 0)
                {
                    return System.Convert.ToInt16(ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText);
                }
                else
                {
                    return sElementValue;
                }
            }
        }

        private string sReadProperty(string v_sNodeName, string sElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                return ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText;
            }
            else
            {
                if (ParentElement() == null)
                {
                    return sElementValue;
                }
                if (ParentElement().GetElementsByTagName(v_sNodeName).Count > 0)
                {
                    if (ParentElement().GetElementsByTagName(v_sNodeName).Item(0).ParentNode.Name == ParentElement().Name)
                    {
                        string sReturn = null;
                        sReturn = ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText;
                        return sReturn;
                    }
                    else
                    {
                        return sElementValue;
                    }
                }
                else
                {
                    return sElementValue;
                }
            }
        }

        private bool bReadProperty(string v_sNodeName, bool bElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                if (ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText == "false" | ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (ParentElement() == null)
                {
                    return bElementValue;
                }
                if (ParentElement().GetElementsByTagName(v_sNodeName).Count > 0)
                {
                    if (ParentElement().GetElementsByTagName(v_sNodeName).Item(0).ParentNode.Name == ParentElement().Name)
                    {
                        if (ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText == "false" | ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText == "0")
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return bElementValue;
                    }
                }
                else
                {
                    return bElementValue;
                }
            }
        }

        private System.DateTime dtReadProperty(string v_sNodeName, System.DateTime dtElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                return mp_dtGetDateFromXML(ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return dtElementValue;
                }
                if (ParentElement().GetElementsByTagName(v_sNodeName).Count > 0)
                {
                    return mp_dtGetDateFromXML(ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText);
                }
                else
                {
                    return dtElementValue;
                }
            }
        }

        private float fReadProperty(string v_sNodeName, float fElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                return System.Convert.ToSingle(ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return fElementValue;
                }
                if (ParentElement().GetElementsByTagName(v_sNodeName).Count > 0)
                {
                    return System.Convert.ToSingle(ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText);
                }
                else
                {
                    return fElementValue;
                }
            }
        }

        private int yReadProperty(string v_sNodeName, int yElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                return System.Convert.ToInt16(ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return yElementValue;
                }
                if (ParentElement().GetElementsByTagName(v_sNodeName).Count > 0)
                {
                    return System.Convert.ToInt16(ParentElement().GetElementsByTagName(v_sNodeName).Item(0).InnerText);
                }
                else
                {
                    return yElementValue;
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
            dtReturn = new System.DateTime(lYear, lMonth, lDay, lHours, lMinutes, lSeconds);
            return dtReturn;
        }

        internal void ReadProperty(String sElementName, ref float sElementValue)
        {
            sElementValue = fReadProperty(sElementName, sElementValue);
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

        internal void WriteProperty(String sElementName, Object sElementValue)
        {
            System.Xml.XmlElement oNodeBuff;
            oNodeBuff = xDoc.CreateElement(sElementName);
            if (sElementValue == null)
            {
                System.Diagnostics.Debug.WriteLine("");
            }
            if (sElementValue.GetType().FullName == "System.DateTime")
            {
                oNodeBuff.InnerText = mp_sGetXMLDateString(System.Convert.ToDateTime(sElementValue));
            }
            else if (sElementValue.GetType().FullName == "System.Boolean")
            {
                if (System.Convert.ToBoolean(sElementValue) == true)
                {
                    if (mp_bBoolsAreNumeric == true)
                    {
                        oNodeBuff.InnerText = "1";
                    }
                    else
                    {
                        oNodeBuff.InnerText = "true";
                    }
                }
                else
                {
                    if (mp_bBoolsAreNumeric == true)
                    {
                        oNodeBuff.InnerText = "0";
                    }
                    else
                    {
                        oNodeBuff.InnerText = "false";
                    }

                }
            }
            else if (sElementValue.GetType().IsEnum == true)
            {
                oNodeBuff.InnerText = System.Convert.ToInt32(sElementValue).ToString();
            }
            else
            {
                oNodeBuff.InnerText = sElementValue.ToString();
            }
            ParentElement().AppendChild(oNodeBuff);
        }

        private String mp_sGetXMLDateString(System.DateTime dtParam)
        {
            return Globals.g_Format(dtParam.Year, "0000") + "-" + Globals.g_Format(dtParam.Month, "00") + "-" + Globals.g_Format(dtParam.Day, "00") + "T" + Globals.g_Format(dtParam.Hour, "00") + ":" + Globals.g_Format(dtParam.Minute, "00") + ":" + Globals.g_Format(dtParam.Second, "00");
        }

        internal void ReadProperty(String sElementName, ref byte sElementValue)
        {
            short yBuff = 0;
            ReadProperty(sElementName, ref yBuff);
            sElementValue = (byte)yBuff;
        }

        //// Microsoft Project Integration

        internal void WriteProperty(string sElementName, int sElementValue)
        {
            System.Xml.XmlElement oNodeBuff = null;
            oNodeBuff = xDoc.CreateElement(sElementName);
            oNodeBuff.InnerText = sElementValue.ToString();
            ParentElement().AppendChild(oNodeBuff);
        }

        internal void WriteProperty(string sElementName, Time sElementValue)
        {
            System.Xml.XmlElement oNodeBuff = null;
            oNodeBuff = xDoc.CreateElement(sElementName);
            oNodeBuff.InnerText = sElementValue.ToString();
            ParentElement().AppendChild(oNodeBuff);
        }

        internal void WriteProperty(string sElementName, Duration sElementValue)
        {
            System.Xml.XmlElement oNodeBuff = null;
            oNodeBuff = xDoc.CreateElement(sElementName);
            oNodeBuff.InnerText = sElementValue.ToString();
            ParentElement().AppendChild(oNodeBuff);
        }

        internal void WriteProperty(string sElementName, decimal sElementValue)
        {
            System.Xml.XmlElement oNodeBuff = null;
            oNodeBuff = xDoc.CreateElement(sElementName);
            oNodeBuff.InnerText = sElementValue.ToString();
            ParentElement().AppendChild(oNodeBuff);
        }

        internal void WriteProperty(string sElementName, float sElementValue)
        {
            System.Xml.XmlElement oNodeBuff = null;
            oNodeBuff = xDoc.CreateElement(sElementName);
            string sReturn = sElementValue.ToString();
            if (sReturn.IndexOf("E") > -1)
            {
                decimal oDecimal = System.Convert.ToDecimal(sElementValue);
                sReturn = oDecimal.ToString();
            }
            oNodeBuff.InnerText = sReturn;
            ParentElement().AppendChild(oNodeBuff);
        }

        internal void ReadProperty(string sElementName, ref Time sElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                sElementValue.FromString(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().GetElementsByTagName(sElementName).Count > 0)
                {
                    sElementValue.FromString(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText);
                }
            }

        }

        internal void ReadProperty(string sElementName, ref Duration sElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                sElementValue.FromString(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().GetElementsByTagName(sElementName).Count > 0)
                {
                    sElementValue.FromString(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText);
                }
            }

        }

        internal void ReadProperty(string sElementName, ref decimal sElementValue)
        {
            if (mp_bSupportOptional == false)
            {
                sElementValue = System.Convert.ToDecimal(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText);
            }
            else
            {
                if (ParentElement() == null)
                {
                    return;
                }
                if (ParentElement().GetElementsByTagName(sElementName).Count > 0)
                {
                    sElementValue = System.Convert.ToDecimal(ParentElement().GetElementsByTagName(sElementName).Item(0).InnerText);
                }
            }
        }
    }
}