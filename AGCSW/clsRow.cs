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
using System.Windows.Controls;
using System.Windows.Media;


namespace AGCSW
{
	public class clsRow : clsItemBase
	{

        private ActiveGanttCSWCtl mp_oControl;
        public clsNode Node;
        public clsCells Cells;
        private bool mp_bAllowSize;
        private bool mp_bAllowMove;
        private bool mp_bContainer;
        private bool mp_bMergeCells;
        private int mp_lHeight;
        private string mp_sText;
        private Image mp_oImage;
        private string mp_sStyleIndex;
        private clsStyle mp_oStyle;
        private string mp_sClientAreaStyleIndex;
        private clsStyle mp_oClientAreaStyle;
        private string mp_sTag;
        private Object mp_oObjectTag;
        private int mp_lTop;
        private int mp_lBottom;
        private E_CLIENTAREAVISIBILITY mp_yClientAreaVisibility;
        private bool mp_bUseNodeImages;
        private string mp_sImageTag;
        internal int mp_lTextLeft;
        internal int mp_lTextTop;
        internal int mp_lTextRight;
        internal int mp_lTextBottom;
        private bool mp_bAllowTextEdit;
        private bool mp_bHighlighted;

        public clsRow(ActiveGanttCSWCtl oControl)
		{
            mp_oControl = oControl;
			mp_bContainer = true;
			mp_bMergeCells = false;
			mp_lHeight = 40;
			mp_sText = "";
			mp_oImage = null;
			mp_sStyleIndex = "DS_ROW";
			mp_oStyle = mp_oControl.Styles.FItem("DS_ROW");
			mp_sTag = "";
            mp_oObjectTag = null;
            Cells = new clsCells(mp_oControl, this);
			mp_sClientAreaStyleIndex = "DS_CLIENTAREA";
			mp_oClientAreaStyle = mp_oControl.Styles.FItem("DS_CLIENTAREA");
            Node = new clsNode(mp_oControl, this);
			mp_lTop = 0;
			mp_lBottom = 0;
			mp_bUseNodeImages = false;
			mp_bAllowSize = true;
			mp_bAllowMove = true;
            mp_sImageTag = "";
            mp_bAllowTextEdit = false;
            mp_bHighlighted = false;
		}

        public bool Highlighted
        {
            get { return mp_bHighlighted; }
            set { mp_bHighlighted = value; }
        }

        public bool AllowTextEdit
        {
            get { return mp_bAllowTextEdit; }
            set { mp_bAllowTextEdit = value; }
        }
    
		
		public bool AllowMove 
		{
			get { return mp_bAllowMove; }
			set { mp_bAllowMove = value; }
		}
    
		
		public bool AllowSize 
		{
			get { return mp_bAllowSize; }
			set { mp_bAllowSize = value; }
		}
    
		
		public string Key 
		{
			get { return mp_sKey; }
			set { mp_oControl.Rows.oCollection.mp_SetKey(ref mp_sKey, value, SYS_ERRORS.ROWS_SET_KEY); }
		}
    
		
		public bool Container 
		{
			get { return mp_bContainer; }
			set { mp_bContainer = value; }
		}
    
		
		public bool UseNodeImages 
		{
			get { return mp_bUseNodeImages; }
			set { mp_bUseNodeImages = value; }
		}
    
		
		public bool MergeCells 
		{
			get 
			{
                if (mp_oControl.TreeviewColumnIndex != 0)
                {
                    return false;
                }
                else
                {
                    return mp_bMergeCells;
                }
			}
			set { mp_bMergeCells = value; }
		}
    
		
		public int Height 
		{
			get 
			{
				if (Node.Hidden == false) 
				{
					return mp_lHeight;
				}
				else 
				{
					return -1;
				}
			}
			set { mp_lHeight = value; }
		}
    
		
		public string Text 
		{
			get { return mp_sText; }
			set { mp_sText = value; }
		}
    
		
		public Image Image 
		{
			get 
			{
				if (mp_bUseNodeImages == false) 
				{
					return mp_oImage;
				}
				else 
				{
					Image oImage = null;
					if (Node.Expanded == true & Node.Children() > 0 & (Node.ExpandedImage != null)) 
					{
						oImage = Node.ExpandedImage;
					}
					else if (Node.Selected == true & (Node.SelectedImage != null)) 
					{
						oImage = Node.SelectedImage;
					}
					else if ((Node.Image != null)) 
					{
						oImage = Node.Image;
					}
					return oImage;
				}
			}
			set { mp_oImage = value; }
		}
    
		
		public string StyleIndex 
		{
			get 
			{
				if (mp_sStyleIndex == "DS_ROW") 
				{
					return "";
				}
				else 
				{
					return mp_sStyleIndex;
				}
			}
			set 
			{
				value = value.Trim();
                if (value.Length == 0) { value = "DS_ROW"; }
				mp_sStyleIndex = value;
				mp_oStyle = mp_oControl.Styles.FItem(value);
			}
		}
    
		
		public clsStyle Style 
		{
			get { return mp_oStyle; }
		}
    
		
		public string Tag 
		{
			get { return mp_sTag; }
			set { mp_sTag = value; }
		}

        public Object ObjectTag
        {
            get { return mp_oObjectTag; }
            set { mp_oObjectTag = value; }
        }
    
		
		public string ClientAreaStyleIndex 
		{
			get 
			{
				if (mp_sClientAreaStyleIndex == "DS_CLIENTAREA") 
				{
					return "";
				}
				else 
				{
					return mp_sClientAreaStyleIndex;
				}
			}
			set 
			{
				value = value.Trim();
                if (value.Length == 0) { value = "DS_CLIENTAREA"; }
				mp_sClientAreaStyleIndex = value;
				mp_oClientAreaStyle = mp_oControl.Styles.FItem(value);
			}
		}
    
		
		public clsStyle ClientAreaStyle 
		{
			get { return mp_oClientAreaStyle; }
		}
    
		
		public int Left 
		{
			get { return mp_oControl.mt_LeftMargin; }
		}
    
		
		public int Top 
		{
			get { return mp_lTop; }
		}
    
		internal int f_lTop 
		{
			set { mp_lTop = value; }
		}
    
		
		public int Right 
		{
			get { return mp_oControl.Splitter.Left; }
		}
    
		
		public int Bottom 
		{
			get { return mp_lBottom; }
		}
    
		internal int f_lBottom 
		{
			set { mp_lBottom = value; }
		}
    
		
		public bool Visible 
		{
			get 
			{
				if (mp_yClientAreaVisibility == E_CLIENTAREAVISIBILITY.VS_INSIDEVISIBLEAREA) 
				{
					return true;
				}
				else 
				{
					return false;
				}
			}
		}
    
		internal E_CLIENTAREAVISIBILITY ClientAreaVisibility 
		{
			get { return mp_yClientAreaVisibility; }
			set { mp_yClientAreaVisibility = value; }
		}

        public string ImageTag
        {
            get { return mp_sImageTag; }
            set { mp_sImageTag = value; }
        }

        internal Color f_RowBackColor
        {
            get
            {
                if (Highlighted == true)
                {
                    return mp_oControl.Configuration.RowHighlightedBackColor;
                }
                else
                {
                    if (mp_oControl.Configuration.AlternatingRowStyles == true)
                    {
                        if (Index % 2 == 1)
                        {
                            ////Odd
                            return mp_oControl.Configuration.RowOddBackColor;
                        }
                        else
                        {
                            ////Even
                            return mp_oControl.Configuration.RowEvenBackColor;
                        }
                    }
                    else
                    {
                        return Node.Style.BackColor;
                    }
                }
            }
        }
    
		
		public string GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "Row");
			oXML.InitializeWriter();
			oXML.WriteProperty("AllowMove", mp_bAllowMove);
			oXML.WriteProperty("AllowSize", mp_bAllowSize);
			oXML.WriteProperty("ClientAreaStyleIndex", mp_sClientAreaStyleIndex);
			oXML.WriteProperty("Container", mp_bContainer);
			oXML.WriteProperty("Height", mp_lHeight);
			oXML.WriteProperty("Image", ref mp_oImage);
			oXML.WriteProperty("Key", mp_sKey);
			oXML.WriteProperty("MergeCells", mp_bMergeCells);
			oXML.WriteProperty("StyleIndex", mp_sStyleIndex);
			oXML.WriteProperty("Tag", mp_sTag);
			oXML.WriteProperty("Text", mp_sText);
			oXML.WriteProperty("UseNodeImages", mp_bUseNodeImages);
            oXML.WriteProperty("ImageTag", mp_sImageTag);
            oXML.WriteProperty("AllowTextEdit", mp_bAllowTextEdit);
            oXML.WriteProperty("Highlighted", mp_bHighlighted);
			oXML.WriteObject(Cells.GetXML());
			oXML.WriteObject(Node.GetXML());
			return oXML.GetXML();
		}
    
		
		public void SetXML(string sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "Row");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			oXML.ReadProperty("AllowMove", ref mp_bAllowMove);
			oXML.ReadProperty("AllowSize", ref mp_bAllowSize);
			oXML.ReadProperty("ClientAreaStyleIndex", ref mp_sClientAreaStyleIndex);
			ClientAreaStyleIndex = mp_sClientAreaStyleIndex;
			oXML.ReadProperty("Container", ref mp_bContainer);
			oXML.ReadProperty("Height", ref mp_lHeight);
			oXML.ReadProperty("Image", ref mp_oImage);
			oXML.ReadProperty("Key", ref mp_sKey);
			oXML.ReadProperty("MergeCells", ref mp_bMergeCells);
			oXML.ReadProperty("StyleIndex", ref mp_sStyleIndex);
			StyleIndex = mp_sStyleIndex;
			oXML.ReadProperty("Tag", ref mp_sTag);
			oXML.ReadProperty("Text", ref mp_sText);
			oXML.ReadProperty("UseNodeImages", ref mp_bUseNodeImages);
            oXML.ReadProperty("ImageTag", ref mp_sImageTag);
            oXML.ReadProperty("AllowTextEdit", ref mp_bAllowTextEdit);
            oXML.ReadProperty("Highlighted", ref mp_bHighlighted);
			Cells.SetXML(oXML.ReadObject("Cells"));
			Node.SetXML(oXML.ReadObject("Node"));
		}
    
	}
}