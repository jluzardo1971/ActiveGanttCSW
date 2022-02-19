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

namespace AGCSW
{
    /// <summary>
    /// Interaction logic for fAbout.xaml
    /// </summary>
    internal partial class fAbout : Window
    {
        internal fAbout()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lblRegister_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(lblRegister.Tag.ToString());
        }

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            System.Reflection.Assembly ai = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream oStream = ai.GetManifestResourceStream("AGCSW.AG.bmp");
            BmpBitmapDecoder oDecoder = new BmpBitmapDecoder(oStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None);
            lblTitle1.Content = "ActiveGanttCSW Scheduler Control, Version " + ai.GetName().Version.ToString();
            lblCopyright.Content = "Copyright © 2002-" + System.DateTime.Now.Year.ToString() + ",  The Source Code Store LLC";
            lblURL.Content = "http://www.sourcecodestore.com";
            lblTechnicalSupport.Content = "Technical Support Page";
            lblSales.Content = "sales@sourcecodestore.com";
            lblRegister.Tag = "http://www.sourcecodestore.com/OnlineStore/default.aspx";
            picIcon.Source = oDecoder.Frames[0];
        }

        private void lblURL_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(lblURL.Content.ToString());
        }

        private void lblTechnicalSupport_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.sourcecodestore.com/Support/default.aspx");
        }

        private void lblSales_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:" + lblSales.Content);
        }


    }
}