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
using System.Windows.Media;

namespace AGCSW
{
    public class ControlTemplateGradient
    {
        public Color ControlBorderColor = Color.FromArgb(255, 100, 145, 204);
        public Color HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
        public Color HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
        public Color RowForeColor = Color.FromArgb(255, 0, 0, 0);
        public GRE_GRADIENTFILLMODE GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
        public Color StartGradientColor = Color.FromArgb(255, 179, 206, 235);
        public Color EndGradientColor = Color.FromArgb(255, 161, 193, 232);
        public Color TreeviewColor = Color.FromArgb(255, 100, 145, 204);
        public Color RowBorderColor = Color.FromArgb(255, 192, 192, 192);
    }
}