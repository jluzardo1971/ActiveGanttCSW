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
    /// Interaction logic for fCustomTickMarkAreaDraw.xaml
    /// </summary>
    public partial class fCustomTickMarkAreaDraw : Window
    {
        public fCustomTickMarkAreaDraw()
        {
            InitializeComponent();
            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;

            //If you open the form: Styles And Templates -> Available Templates in the main menu (fTemplates.cs)
            //you can preview all available Templates.
            //Or you can also build your own:
            //fMSProject11.cs shows you how to build a Solid Template in the InitializeAG Method.
            //fMSProject14.cs shows you how to build a Gradient Template in the InitializeAG Method.
            ActiveGanttCSWCtl1.ApplyTemplate(E_CONTROLTEMPLATE.STC_CH_VGRAD_ANAKIWA_BLUE, E_OBJECTTEMPLATE.STO_DEFAULT);

            ActiveGanttCSWCtl1.Visibility = System.Windows.Visibility.Visible;
        }

        private void ActiveGanttCSWCtl1_CustomTickMarkAreaDraw(object sender, AGCSW.CustomTickMarkAreaDrawEventArgs e)
        {
            e.Graphics.DrawRectangle(new SolidColorBrush(Colors.GhostWhite), null, new System.Windows.Rect(e.Left, e.Top, e.Right - e.Left, e.Bottom - e.Top));
            e.CustomDraw = true;
        }

        private void ActiveGanttCSWCtl1_CustomTickMarkDraw(object sender, AGCSW.CustomTickMarkAreaDrawEventArgs e)
        {
            int y1 = (e.Bottom - e.Top) / 4;
            switch (e.oTickMark.TickMarkType)
            {
                case AGCSW.E_TICKMARKTYPES.TLT_BIG:
                    e.Graphics.DrawLine(new Pen(new SolidColorBrush(Colors.Red), 1), new Point(e.X, e.Top), new Point(e.X, e.Bottom));
                    break;
                case AGCSW.E_TICKMARKTYPES.TLT_MEDIUM:
                    e.Graphics.DrawLine(new Pen(new SolidColorBrush(Colors.Green), 1), new Point(e.X, e.Top + y1), new Point(e.X, e.Bottom));
                    break;
                case AGCSW.E_TICKMARKTYPES.TLT_SMALL:
                    e.Graphics.DrawLine(new Pen(new SolidColorBrush(Colors.Blue), 1), new Point(e.X, e.Top + (2 * y1)), new Point(e.X, e.Bottom));
                    break;
            }
            e.CustomDraw = true;
        }
    }
}