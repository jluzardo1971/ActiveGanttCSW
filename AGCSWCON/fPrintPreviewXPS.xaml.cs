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
using System.Windows.Xps.Packaging;
using System.IO;
using System.IO.Packaging;

namespace AGCSWCON
{
    /// <summary>
    /// Interaction logic for fPrintPreviewXPS.xaml
    /// </summary>
    public partial class fPrintPreviewXPS : Window
    {

        public XpsDocument oXPSDoc;
        public Uri oURI;

        public fPrintPreviewXPS()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;
            DocumentViewer1.Document = oXPSDoc.GetFixedDocumentSequence();
        }

        private void Resize()
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                DocumentViewer1.SetValue(Canvas.TopProperty, System.Convert.ToDouble(0));
                DocumentViewer1.SetValue(Canvas.LeftProperty, System.Convert.ToDouble(0));
                DocumentViewer1.Width = this.Width - 8;
                DocumentViewer1.Height = this.Height - 30;
            }
            else if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                DocumentViewer1.SetValue(Canvas.TopProperty, System.Convert.ToDouble(0));
                DocumentViewer1.SetValue(Canvas.LeftProperty, System.Convert.ToDouble(0));
                DocumentViewer1.Width = SystemParameters.MaximizedPrimaryScreenWidth - 8;
                DocumentViewer1.Height = SystemParameters.MaximizedPrimaryScreenHeight - 30;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Resize();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            Resize();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            PackageStore.RemovePackage(oURI);
            oXPSDoc.Close();
        }
    }
}