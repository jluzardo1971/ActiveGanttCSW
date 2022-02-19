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
using System.Data.SqlServerCe;
using System.Data;
using System.IO;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;
using AGCSW;
using System.Windows;
using System.Windows.Media.Imaging;

namespace AGCSWCON
{

    public enum PRG_DIALOGMODE
    {
        DM_ADD = 0,
        DM_EDIT = 1
    }


    static class Globals
    {

        public static int GetTextNum(TextBox oControl, int lDefault)
        {
            string sReturn = null;
            sReturn = oControl.Text;
            if (sReturn.Length == 0)
            {
                return lDefault;
            }
            if (IsNumeric(sReturn) == false)
            {
                return lDefault;
            }
            return System.Convert.ToInt32(sReturn);
        }

        public static string g_GetAppLocation()
        {
            return AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\", "");
        }

        public static string g_ReadFile(string sFullPath, bool bDetectEncoding, System.Text.Encoding oEncoding)
        {
            StreamReader oReader = null;
            if (bDetectEncoding == false)
            {
                if (oEncoding == null)
                {
                    oReader = new StreamReader(sFullPath);
                }
                else
                {
                    oReader = new StreamReader(sFullPath, oEncoding);
                }
            }
            else
            {
                oReader = new StreamReader(sFullPath, true);
            }
            string sReturn = oReader.ReadToEnd();
            oReader.Close();
            return sReturn;
        }

        public static void g_WriteFile(string sFullPath, string sFileContents, System.Text.Encoding oEncoding)
        {
            StreamWriter oWriter = null;
            if (oEncoding == null)
            {
                oWriter = new StreamWriter(sFullPath);
            }
            else
            {
                oWriter = new StreamWriter(sFullPath, false, oEncoding);
            }
            oWriter.Write(sFileContents);
            oWriter.Close();
        }

        public static int GetRnd(int lLowerBound, int lUpperBound)
        {
            System.Random oRnd = null;
            string sGUID = System.Guid.NewGuid().ToString("N").Replace("a", "").Replace("b", "").Replace("c", "").Replace("d", "").Replace("e", "").Replace("f", "");
            int iSeed = System.Convert.ToInt32(sGUID.Substring(0, 5));
            oRnd = new Random(iSeed);
            return oRnd.Next(lLowerBound, lUpperBound);
        }

        public static string g_Format(Decimal dParam, string sFormat)
        {
            return dParam.ToString(sFormat);
        }

        public static string g_GetComboBoxSelectedItem(ComboBox oComboBox, string sColumnName)
        {
            string sReturn = null;
            DataRowView oDataRowView = null;
            oDataRowView = (System.Data.DataRowView)oComboBox.SelectedItem;
            sReturn = oDataRowView[sColumnName].ToString();
            return sReturn;
        }

        public static string g_GenerateRandomName(bool IncludePrefix, SqlCeConnection oConn)
        {
            string sReturn = "";
            SqlCeCommand oCmd = null;
            SqlCeDataReader oReader = null;
            oCmd = new SqlCeCommand("SELECT * FROM tb_First_Names WHERE lID=" + GetRnd(1, 5494).ToString(), oConn);
            oReader = oCmd.ExecuteReader();
            if (oReader.Read() == true)
            {
                if (IncludePrefix == true)
                {
                    if (oReader["sSex"].ToString() == "F")
                    {
                        sReturn = "Ms. ";
                    }
                    else
                    {
                        sReturn = "Mr. ";
                    }
                }
                sReturn = sReturn + oReader["sFirstName"].ToString();
            }
            oReader.Close();
            oCmd = new SqlCeCommand("SELECT * FROM tb_Last_Names WHERE lID=" + GetRnd(1, 88799).ToString(), oConn);
            oReader = oCmd.ExecuteReader();
            if (oReader.Read() == true)
            {
                sReturn = sReturn + " " + oReader["sLastName"].ToString();
            }
            oReader.Close();
            return sReturn;
        }

        public static string g_GenerateRandomAddress(SqlCeConnection oConn)
        {
            string sReturn = "";
            int i = 0;
            int Max = 0;

            Max = GetRnd(1, 3);
            for (i = 1; i <= Max; i++)
            {
                sReturn = sReturn + System.Convert.ToChar(GetRnd(49, 57));
            }

            SqlCeCommand oCmd = null;
            SqlCeDataReader oReader = null;
            oCmd = new SqlCeCommand("SELECT * FROM tb_Last_Names WHERE lID=" + GetRnd(1, 88799).ToString(), oConn);
            oReader = oCmd.ExecuteReader();
            if (oReader.Read() == true)
            {
                sReturn = sReturn + " " + oReader["sLastName"].ToString();
            }
            oReader.Close();
            oCmd = new SqlCeCommand("SELECT * FROM tb_US_Streets WHERE lID=" + GetRnd(1, 538).ToString(), oConn);
            oReader = oCmd.ExecuteReader();
            if (oReader.Read() == true)
            {
                sReturn = sReturn + " " + oReader["sStreetSuffix"].ToString();
            }
            oReader.Close();
            return sReturn;
        }

        public static void g_GenerateRandomCity(ref string sCityName, ref string sState, ref int ID, SqlCeConnection oConn)
        {
            SqlCeCommand oCmd = null;
            SqlCeDataReader oReader = null;
            oCmd = new SqlCeCommand("SELECT * FROM tb_US_Cities WHERE lID=" + GetRnd(1, 25150).ToString(), oConn);
            oReader = oCmd.ExecuteReader();
            if (oReader.Read() == true)
            {
                sCityName = oReader["sCityName"].ToString();
                sState = oReader["sStateAbr"].ToString();
                ID = (System.Int32)oReader["lID"];
                sCityName = sCityName.Trim();
                sState = sState.Trim();
            }
        }

        public static string g_GenerateRandomPhone(string AreaCode)
        {
            int i = 0;
            string sBuff = "";
            if (string.IsNullOrEmpty(AreaCode))
            {
                for (i = 1; i <= 3; i++)
                {
                    if (i == 1)
                    {
                        sBuff = sBuff + System.Convert.ToChar(GetRnd(49, 57));
                    }
                    else
                    {
                        sBuff = sBuff + System.Convert.ToChar(GetRnd(48, 57));
                    }
                }
                sBuff = "(" + sBuff + ") ";
            }
            else
            {
                sBuff = AreaCode + " ";
            }
            for (i = 1; i <= 3; i++)
            {
                if (i == 1)
                {
                    sBuff = sBuff + System.Convert.ToChar(GetRnd(49, 57));
                }
                else
                {
                    sBuff = sBuff + System.Convert.ToChar(GetRnd(48, 57));
                }
            }
            sBuff = sBuff + "-";
            for (i = 1; i <= 4; i++)
            {
                sBuff = sBuff + System.Convert.ToChar(GetRnd(48, 57));
            }
            return sBuff;
        }

        public static string g_GenerateRandomZIP()
        {
            int i = 0;
            string sBuff = "";
            for (i = 1; i <= 5; i++)
            {
                if (i == 1)
                {
                    sBuff = sBuff + System.Convert.ToChar(GetRnd(49, 57));
                }
                else
                {
                    sBuff = sBuff + System.Convert.ToChar(GetRnd(48, 57));
                }
            }
            return sBuff;
        }

        public static string g_GenerateRandomLicense()
        {
            int i = 0;
            string sBuff = "";
            for (i = 1; i <= 3; i++)
            {
                sBuff = sBuff + System.Convert.ToChar(GetRnd(65, 90));
            }
            sBuff = sBuff + "-";
            for (i = 1; i <= 4; i++)
            {
                sBuff = sBuff + System.Convert.ToChar(GetRnd(48, 57));
            }
            return sBuff;
        }

        private static bool IsNumeric(object value)
        {
            try
            {
                double d = System.Double.Parse(value.ToString(), System.Globalization.NumberStyles.Any);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static DateTime FromDate(System.DateTime dtDate)
        {
            DateTime dtReturn = new DateTime(dtDate.Year, dtDate.Month, dtDate.Day, dtDate.Hour, dtDate.Minute, dtDate.Second);
            return dtReturn;
        }

        public static void InitNumCtrl(IntegerUpDown numCtrl, int lMin, int lMax, int lValue)
        {
            numCtrl.Minimum = lMin;
            numCtrl.Maximum = lMax;
            numCtrl.Value = lValue;
        }

        public static void InitNumCtrl(DecimalUpDown numCtrl, decimal dMin, decimal dMax, decimal dValue, decimal dDelta, int lDecimalPlaces)
        {
            numCtrl.FormatString = "N" + lDecimalPlaces.ToString();
            numCtrl.Minimum = System.Convert.ToDecimal(dMin);
            numCtrl.Maximum = System.Convert.ToDecimal(dMax);
            numCtrl.Value = System.Convert.ToDecimal(dValue);
            numCtrl.Increment = System.Convert.ToDecimal(dDelta);
        }

        public static Image g_GetImage(string sImage)
        {
            BitmapSource oBitmap = new BitmapImage(new Uri(g_GetAppLocation() + sImage));
            Image oReturn = new Image();
            oReturn.Source = oBitmap;
            return oReturn;
        }

        public static BitmapSource g_GetImageSource(string sImage)
        {
            BitmapSource oBitmap = new BitmapImage(new Uri(g_GetAppLocation() + sImage));
            return oBitmap;
        }


    }



}