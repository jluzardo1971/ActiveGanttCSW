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
using System.IO.Packaging;
using System.Windows.Xps.Packaging;
using System.IO;


namespace AGCSWCON
{

    public partial class fPrintPreview : Window
    {

        public fPrintDialog mp_oParent;
        private int mp_lColumn;
        private int mp_lRow;
        private int mp_lPage;
        private float mp_fScale;

        public fPrintPreview()
        {
            InitializeComponent();
            mp_fScale = 1f;
            mp_lPage = 1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mp_UpdatePageNumber();

            this.WindowState = System.Windows.WindowState.Maximized;
        }

        protected override void OnRender(DrawingContext oDC)
        {
            oDC.DrawRectangle(Brushes.DarkGray, null, new Rect(0, 0, this.Width, this.Height));
            mp_oParent.mp_oControl.Printer.PreviewPage(oDC, mp_lPage, mp_fScale, 100, 100);
        }

        #region "Functions"

        private void mp_UpdatePageNumber()
        {
            lblPage.Content = "Page " + mp_lPage.ToString() + " of " + mp_oParent.mp_oControl.Printer.Pages;
        }

        #endregion

        private void cmdLeft_Click(object sender, RoutedEventArgs e)
        {
            mp_oParent.mp_oControl.Printer.GetPagePosition(mp_lPage, ref mp_lColumn, ref mp_lRow);
            if (mp_lColumn > 1)
            {
                mp_lColumn = mp_lColumn - 1;
                mp_lPage = mp_oParent.mp_oControl.Printer.GetPageNumber(mp_lColumn, mp_lRow);
                mp_UpdatePageNumber();
                this.InvalidateVisual();
            }
        }

        private void cmdRight_Click(object sender, RoutedEventArgs e)
        {
            mp_oParent.mp_oControl.Printer.GetPagePosition(mp_lPage, ref mp_lColumn, ref mp_lRow);
            if (mp_lColumn < mp_oParent.mp_oControl.Printer.XAxisPages)
            {
                mp_lColumn = mp_lColumn + 1;
                mp_lPage = mp_oParent.mp_oControl.Printer.GetPageNumber(mp_lColumn, mp_lRow);
                mp_UpdatePageNumber();
                this.InvalidateVisual();
            }
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            mp_oParent.mp_oControl.Printer.GetPagePosition(mp_lPage, ref mp_lColumn, ref mp_lRow);
            if (mp_lRow > 1)
            {
                mp_lRow = mp_lRow - 1;
                mp_lPage = mp_oParent.mp_oControl.Printer.GetPageNumber(mp_lColumn, mp_lRow);
                mp_UpdatePageNumber();
                this.InvalidateVisual();
            }
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            mp_oParent.mp_oControl.Printer.GetPagePosition(mp_lPage, ref mp_lColumn, ref mp_lRow);
            if (mp_lRow < mp_oParent.mp_oControl.Printer.YAxisPages)
            {
                mp_lRow = mp_lRow + 1;
                mp_lPage = mp_oParent.mp_oControl.Printer.GetPageNumber(mp_lColumn, mp_lRow);
                mp_UpdatePageNumber();
                this.InvalidateVisual();
            }
        }

        private void cmdZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (mp_fScale < 2f)
            {
                mp_fScale = mp_fScale + 0.1f;
                this.InvalidateVisual();
            }
        }

        private void cmdZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (mp_fScale > 0.1f)
            {
                mp_fScale = mp_fScale - 0.1f;
                this.InvalidateVisual();
            }
        }


    }
}