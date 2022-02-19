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
using System.Windows.Shapes;
using AGCSW;

namespace AGCSWCON
{
    /// <summary>
    /// Interaction logic for fCustomDrawing.xaml
    /// </summary>
    public partial class fCustomDrawing : Window
    {
        public fCustomDrawing()
        {
            InitializeComponent();
            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;

            ActiveGanttCSWCtl1.AboutBox();

            //If you open the form: Styles And Templates -> Available Templates in the main menu (fTemplates.cs)
            //you can preview all available Templates.
            //Or you can also build your own:
            //fMSProject11.cs shows you how to build a Solid Template in the InitializeAG Method.
            //fMSProject14.cs shows you how to build a Gradient Template in the InitializeAG Method.
            ActiveGanttCSWCtl1.ApplyTemplate(E_CONTROLTEMPLATE.STC_CH_HGRAD_BLUE_BELL, E_OBJECTTEMPLATE.STO_VARIATION_1);
            
            int i = 0;
            ActiveGanttCSWCtl1.Columns.Add("Column 1", "", 125, "");
            ActiveGanttCSWCtl1.Columns.Add("Column 2", "", 100, "");
            for (i = 1; i <= 10; i++)
            {
                ActiveGanttCSWCtl1.Rows.Add("K" + i.ToString(), "Row " + i.ToString() + " (Key: " + "K" + i.ToString() + ")", true, true, "");
            }

            ActiveGanttCSWCtl1.CurrentViewObject.TimeLine.Position(new DateTime(2011, 11, 21, 0, 0, 0));
            ActiveGanttCSWCtl1.Tasks.Add("Task 1", "K1", new DateTime(2011, 11, 21, 0, 0, 0), new DateTime(2011, 11, 21, 3, 0, 0), "", "RET1", "");
            ActiveGanttCSWCtl1.Tasks.Add("Task 2", "K2", new DateTime(2011, 11, 21, 1, 0, 0), new DateTime(2011, 11, 21, 4, 0, 0), "", "RET1", "");
            ActiveGanttCSWCtl1.Tasks.Add("Task 3", "K3", new DateTime(2011, 11, 21, 2, 0, 0), new DateTime(2011, 11, 21, 5, 0, 0), "", "RET1", "");

            ActiveGanttCSWCtl1.Redraw();

            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Visible;
        }

        private void ActiveGanttCSWCtl_Draw(object sender, DrawEventArgs e)
        {
            if (e.EventTarget == E_EVENTTARGET.EVT_TASK)
            {
                if (ActiveGanttCSWCtl1.SelectedTaskIndex == e.ObjectIndex)
                {
                    e.CustomDraw = true;
                    clsTask oTask;
                    oTask = ActiveGanttCSWCtl1.Tasks.Item(e.ObjectIndex.ToString());
                    Font oFont = new Font("Arial", 7, FontWeights.Normal);
                    clsTextFlags oTextFlags = new clsTextFlags();
                    oTextFlags.HorizontalAlignment = GRE_HORIZONTALALIGNMENT.HAL_CENTER;
                    oTextFlags.VerticalAlignment = GRE_VERTICALALIGNMENT.VAL_CENTER;
                    Image oImage = new Image();
                    Uri oURI = new Uri("../Images/sampleimage.jpg", UriKind.RelativeOrAbsolute);
                    JpegBitmapDecoder oDecoder = new JpegBitmapDecoder(oURI, BitmapCreateOptions.None, BitmapCacheOption.None);
                    BitmapSource oBitmap = oDecoder.Frames[0];
                    oImage.Source = oBitmap;
                    ActiveGanttCSWCtl1.Drawing.PaintImage(oImage, oTask.Left + 40, oTask.Top + 10, oTask.Left + 64, oTask.Top + 34);
                    ActiveGanttCSWCtl1.Drawing.DrawLine(oTask.Left, ((oTask.Bottom - oTask.Top) / 2) + oTask.Top, oTask.Right, ((oTask.Bottom - oTask.Top) / 2) + oTask.Top, Colors.Green, GRE_LINEDRAWSTYLE.LDS_SOLID, 1);
                    ActiveGanttCSWCtl1.Drawing.DrawRectangle(oTask.Left, oTask.Top, oTask.Left + 10, oTask.Top + 10, Colors.Red, GRE_LINEDRAWSTYLE.LDS_SOLID, 1);
                    ActiveGanttCSWCtl1.Drawing.DrawBorder(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom, Colors.Blue, GRE_LINEDRAWSTYLE.LDS_SOLID, 2);
                    ActiveGanttCSWCtl1.Drawing.DrawAlignedText(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom, oTask.Text + " Is Selected", GRE_HORIZONTALALIGNMENT.HAL_RIGHT, GRE_VERTICALALIGNMENT.VAL_BOTTOM, Colors.Blue, oFont);
                    ActiveGanttCSWCtl1.Drawing.DrawText(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom, "Draw Text", oTextFlags, Colors.Red, oFont);
                }
            }
        }

    }
}