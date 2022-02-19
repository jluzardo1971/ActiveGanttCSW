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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AGCSWCON
{

    public partial class fMain : Window
    {

        TreeViewItem mp_oParentNode;

        public fMain()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblCopyright.Content = "Copyright ©2002-" + DateTime.Now.Year.ToString() + " The Source Code Store LLC. All Rights Reserved. All trademarks are property of their legal owner.";
            AddTitleNode("AGEX", "ActiveGantt Examples:", 4, 5);
            AddNode("AGEX", "GanttCharts", "Gantt Charts:", 4, 5);

            AddNode("GanttCharts", "WBS", "Work Breakdown Structure (WBS) Project Management Example:", 4, 5);
            AddNode("WBS", "WBSProject", "SQL Server CE 4.0 data source", 2, 2);

            AddNode("GanttCharts", "MSPI", "Microsoft Project Integration Examples:", 4, 5);
            AddNode("MSPI", "Project2003", "Demonstrates how ActiveGantt integrates with MS Project 2003 (using XML Files and the MSP2003 Integration Library)", 2, 2);
            AddNode("MSPI", "Project2007", "Demonstrates how ActiveGantt integrates with MS Project 2007 (using XML Files and the MSP2007 Integration Library)", 2, 2);
            AddNode("MSPI", "Project2010", "Demonstrates how ActiveGantt integrates with MS Project 2010 (using XML Files and the MSP2010 Integration Library)", 2, 2);

            AddNode("AGEX", "Schedules", "Schedules and Rosters:", 4, 5);

            AddNode("Schedules", "VRFC", "Vehicle Rental/Fleet Control Roster Example:", 4, 5);
            AddNode("VRFC", "CarRental", "SQL Server CE 4.0 data source", 2, 2);

            AddNode("AGEX", "TEMPL", "Styles and Templates:", 4, 5);
            AddNode("TEMPL", "Templates", "Available Templates", 2, 2);
            AddNode("TEMPL", "Anakiwa_Blue_Style", "Anakiwa Blue Style without using Templates", 2, 2);
            AddNode("TEMPL", "MSP2003Style", "MS Project 2003 Style without using Templates", 2, 2);
            AddNode("TEMPL", "MSP2007Style", "MS Project 2007 Style without using Templates", 2, 2);
            AddNode("TEMPL", "MSP2010Style", "MS Project 2010 Style without using Templates", 2, 2);
            AddNode("TEMPL", "CRS", "Car Rental Style without using Templates", 2, 2);
            
            AddNode("AGEX", "OTHER", "Other examples:", 4, 5);
            AddNode("OTHER", "FastLoad", "Fast Loading of Row and Task objects", 2, 2);
            AddNode("OTHER", "CustomDrawing", "Custom Drawing", 2, 2);
            AddNode("OTHER", "SortRows", "Sort Rows", 2, 2);
            AddNode("OTHER", "MillisecondInterval", "5 Millisecond Interval View", 2, 2);
            AddNode("OTHER", "CustomTickMarkArea", "Custom TickMarkArea Drawing", 2, 2);
            AddNode("OTHER", "CustomTickMarkText", "Custom TickMark Text Drawing", 2, 2);

            AddNode("OTHER", "TimeBlocks", "TimeBlocks and Duration Tasks:", 4, 5);
            AddNode("TimeBlocks", "RCT_DAY", "Daily Recurrent TimeBlocks", 2, 2);
            AddNode("TimeBlocks", "RCT_WEEK", "Weekly Recurrent TimeBlocks", 2, 2);
            AddNode("TimeBlocks", "RCT_MONTH", "Monthly Recurrent TimeBlocks", 2, 2);
            AddNode("TimeBlocks", "RCT_YEAR", "Yearly Recurrent TimeBlocks", 2, 2);
            AddNode("TimeBlocks", "DurationTasks", "Duration Tasks (can skip over non-working TimeBlock intervals)", 2, 2);

            mp_CollapseNode("TEMPL");
            mp_CollapseNode("OTHER");
        }

        private void mp_CollapseNode(string sKey)
        {
            TreeViewItem oNode;
            oNode = FindNode(sKey);
            oNode.IsExpanded = false;
        }

        private void cmdExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddTitleNode(string sKey, string sText, int ImageIndex, int SelectedImageIndex)
        {
            TreeViewItem oNode = new TreeViewItem();
            oNode.Name = sKey;
            oNode.Header = GetStackPanel(sText, ImageIndex);
            oNode.Tag = sKey;
            oNode.IsExpanded = true;
            TreeView1.Items.Add(oNode);
            mp_oParentNode = oNode;
        }

        private void AddNode(string sParentKey, string sKey, string sText, int ImageIndex, int SelectedImageIndex)
        {
            TreeViewItem oNode = new TreeViewItem();
            TreeViewItem oParentNode;
            oNode.Name = sKey;
            oNode.Header = GetStackPanel(sText, ImageIndex);
            oNode.Tag = sKey;
            oNode.IsExpanded = true;
            oParentNode = FindNode(sParentKey);
            oParentNode.Items.Add(oNode);
        }

        private TreeViewItem FindNode(string sName)
        {
            int i = 0;
            TreeViewItem oReturnTreeViewItem = null;
            for (i = 0; i <= TreeView1.Items.Count - 1; i++)
            {
                TreeViewItem oTreeViewItem = (TreeViewItem)TreeView1.Items[i];
                oReturnTreeViewItem = FindNode_Intermediate(ref oTreeViewItem, sName);
                if ((oReturnTreeViewItem != null))
                {
                    return oReturnTreeViewItem;
                }
                oReturnTreeViewItem = FindNode_Final(ref oTreeViewItem, sName);
                if ((oReturnTreeViewItem != null))
                {
                    return oReturnTreeViewItem;
                }
            }
            return oReturnTreeViewItem;
        }

        private TreeViewItem FindNode_Intermediate(ref TreeViewItem oTreeViewItem, string sName)
        {
            int i = 0;
            TreeViewItem oReturnTreeViewItem = null;
            for (i = 0; i <= oTreeViewItem.Items.Count - 1; i++)
            {
                TreeViewItem oChildTreeViewItem = (TreeViewItem)oTreeViewItem.Items[i];
                oReturnTreeViewItem = FindNode_Intermediate(ref oChildTreeViewItem, sName);
                if ((oReturnTreeViewItem != null))
                {
                    return oReturnTreeViewItem;
                }
            }
            oReturnTreeViewItem = FindNode_Final(ref oTreeViewItem, sName);
            return oReturnTreeViewItem;
        }

        private TreeViewItem FindNode_Final(ref TreeViewItem oTreeViewItem, string sName)
        {
            if (oTreeViewItem.Name == sName)
            {
                return oTreeViewItem;
            }
            return null;
        }

        private StackPanel GetStackPanel(string sText, int ImageIndex)
        {
            StackPanel oStackPanel = new StackPanel();
            Image oImage = new Image();
            TextBlock oTextBlock = new TextBlock();
            oImage.Source = GetImage(ImageIndex);
            oTextBlock.Text = " " + sText;
            oStackPanel.Orientation = Orientation.Horizontal;
            oStackPanel.Children.Add(oImage);
            oStackPanel.Children.Add(oTextBlock);
            return oStackPanel;
        }

        private BitmapSource GetImage(int ImageIndex)
        {
            GifBitmapDecoder oDecoder = new GifBitmapDecoder(GetURI(ImageIndex), BitmapCreateOptions.None, BitmapCacheOption.None);
            BitmapSource oBitmap = oDecoder.Frames[0];
            return oBitmap;
        }

        private Uri GetURI(int ImageIndex)
        {
            Uri oURI = null;
            switch (ImageIndex)
            {
                case 4:
                    //open folder
                    oURI = new Uri("../Images/bfolderopen.gif", UriKind.RelativeOrAbsolute);
                    break;
                case 2:
                    //ActiveGantt
                    oURI = new Uri("../Images/AG.gif", UriKind.RelativeOrAbsolute);
                    break;
                case 3:
                    //Inet
                    oURI = new Uri("../Images/inet.gif", UriKind.RelativeOrAbsolute);
                    break;
                case 6:
                    oURI = new Uri("../Images/onlinedocumentation.gif", UriKind.RelativeOrAbsolute);
                    break;
                case 7:
                    oURI = new Uri("../Images/localCHMdocumentation.gif", UriKind.RelativeOrAbsolute);
                    break;

            }
            return oURI;
        }


        private void TreeView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TreeView1.SelectedItem == null)
            {
                return;
            }
            TreeViewItem oSelectedItem;
            oSelectedItem = (TreeViewItem) TreeView1.SelectedItem;
            string sSelectedTag = oSelectedItem.Tag.ToString();
            switch (sSelectedTag)
            {
                case "WBSProject":
                    {
                        fWBSProject oForm = new fWBSProject();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "CarRental":
                    {
                        fCarRental oForm = new fCarRental();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "Project2003":
                    {
                        fMSProject11 oForm = new fMSProject11();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "Project2007":
                    {
                        fMSProject12 oForm = new fMSProject12();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "Project2010":
                    {
                        fMSProject14 oForm = new fMSProject14();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "CustomDrawing":
                    {
                        fCustomDrawing oForm = new fCustomDrawing();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "FastLoad":
                    {
                        fFastLoading oForm = new fFastLoading();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "SortRows":
                    {
                        fSortRows oForm = new fSortRows();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "MillisecondInterval":
                    {
                        fMillisecondInterval oForm = new fMillisecondInterval();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "DurationTasks":
                    {
                        fDurationTasks oForm = new fDurationTasks();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "RCT_DAY":
                    {
                        fRCT_DAY oForm = new fRCT_DAY();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "RCT_WEEK":
                    {
                        fRCT_WEEK oForm = new fRCT_WEEK();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "RCT_MONTH":
                    {
                        fRCT_MONTH oForm = new fRCT_MONTH();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "RCT_YEAR":
                    {
                        fRCT_YEAR oForm = new fRCT_YEAR();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "CustomTickMarkArea":
                    {
                        fCustomTickMarkAreaDraw oForm = new fCustomTickMarkAreaDraw();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "CustomTickMarkText":
                    {
                        fCustomTickMarkTextDraw oForm = new fCustomTickMarkTextDraw();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "Templates":
                    {
                        fTemplates oForm = new fTemplates();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "Anakiwa_Blue_Style":
                    {
                        fSTL_Anakiwa_Blue oForm = new fSTL_Anakiwa_Blue();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "MSP2003Style":
                    {
                        fSTL_MSP2003 oForm = new fSTL_MSP2003();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "MSP2007Style":
                    {
                        fSTL_MSP2007 oForm = new fSTL_MSP2007();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "MSP2010Style":
                    {
                        fSTL_MSP2010 oForm = new fSTL_MSP2010();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
                case "CRS":
                    {
                        fSTL_CR oForm = new fSTL_CR();
                        this.Cursor = Cursors.Wait;
                        oForm.ShowDialog();
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
            }
        }

    }
}