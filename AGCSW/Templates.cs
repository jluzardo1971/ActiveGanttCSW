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
using System.Windows;

namespace AGCSW
{
    static class Templates
    {

        private class S_ObjectTemplate
        {
            public GRE_BACKGROUNDMODE yBackgroundMode_Tasks = GRE_BACKGROUNDMODE.FP_SOLID;

            public GRE_GRADIENTFILLMODE yGradientFillMode_Tasks = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
            public Color BackColor_T1 = Color.FromArgb(255, 255, 255, 255);
            public Color ForeColor_T1 = Color.FromArgb(255, 0, 0, 0);
            public Color BorderColor_T1 = Color.FromArgb(255, 0, 0, 0);
            public Color StartGradientColor_T1 = Color.FromArgb(255, 255, 0, 0);
            public Color EndGradientColor_T1 = Color.FromArgb(255, 255, 0, 0);
            public GRE_HATCHSTYLE HatchStyle_T1 = GRE_HATCHSTYLE.HS_HORIZONTAL;
            public Color HatchBackColor_T1 = Color.FromArgb(255, 255, 0, 0);

            public Color HatchForeColor_T1 = Color.FromArgb(255, 255, 0, 0);
            public Color BackColor_T2 = Color.FromArgb(255, 255, 255, 255);
            public Color ForeColor_T2 = Color.FromArgb(255, 0, 0, 0);
            public Color BorderColor_T2 = Color.FromArgb(255, 0, 0, 0);
            public Color StartGradientColor_T2 = Color.FromArgb(255, 255, 0, 0);
            public Color EndGradientColor_T2 = Color.FromArgb(255, 255, 0, 0);
            public GRE_HATCHSTYLE HatchStyle_T2 = GRE_HATCHSTYLE.HS_HORIZONTAL;
            public Color HatchBackColor_T2 = Color.FromArgb(255, 255, 0, 0);

            public Color HatchForeColor_T2 = Color.FromArgb(255, 255, 0, 0);
            public Color BackColor_T3 = Color.FromArgb(255, 255, 255, 255);
            public Color ForeColor_T3 = Color.FromArgb(255, 0, 0, 0);
            public Color BorderColor_T3 = Color.FromArgb(255, 0, 0, 0);
            public Color StartGradientColor_T3 = Color.FromArgb(255, 255, 0, 0);
            public Color EndGradientColor_T3 = Color.FromArgb(255, 255, 0, 0);
            public GRE_HATCHSTYLE HatchStyle_T3 = GRE_HATCHSTYLE.HS_HORIZONTAL;
            public Color HatchBackColor_T3 = Color.FromArgb(255, 255, 0, 0);

            public Color HatchForeColor_T3 = Color.FromArgb(255, 255, 0, 0);
            public Color BackColor_T4 = Color.FromArgb(255, 255, 255, 255);
            public Color ForeColor_T4 = Color.FromArgb(255, 0, 0, 0);
            public Color BorderColor_T4 = Color.FromArgb(255, 0, 0, 0);
            public Color StartGradientColor_T4 = Color.FromArgb(255, 255, 0, 0);
            public Color EndGradientColor_T4 = Color.FromArgb(255, 255, 0, 0);
            public GRE_HATCHSTYLE HatchStyle_T4 = GRE_HATCHSTYLE.HS_HORIZONTAL;
            public Color HatchBackColor_T4 = Color.FromArgb(255, 255, 0, 0);
            public Color HatchForeColor_T4 = Color.FromArgb(255, 255, 0, 0);
        }

        public static void g_ApplyTemplate(ActiveGanttCSWCtl oControl, E_CONTROLTEMPLATE yControlTemplate, E_OBJECTTEMPLATE yObjectTemplate)
        {
            oControl.Styles.Clear();
            mp_ControlTemplateSelector(oControl, yControlTemplate);
            mp_ObjectTemplateSelector(oControl, yObjectTemplate);
        }

        private static void mp_ControlTemplateSelector(ActiveGanttCSWCtl oControl, E_CONTROLTEMPLATE yControlTemplate)
        {
            switch (yControlTemplate)
            {
                case E_CONTROLTEMPLATE.STC_CH_SOLID_WHITE:
                    {
                        ControlTemplateSolid oTemplate = new ControlTemplateSolid();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBackColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);
                        oTemplate.TimeBlockBackColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Solid(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_SOLID_DARK_BLUE:
                    {
                        ControlTemplateSolid oTemplate = new ControlTemplateSolid();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBackColor = Color.FromArgb(255, 63, 68, 90);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);
                        oTemplate.TimeBlockBackColor = Color.FromArgb(255, 115, 119, 135);

                        mp_ApplyControlTemplate_Solid(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_SOLID_VIOLET:
                    {
                        ControlTemplateSolid oTemplate = new ControlTemplateSolid();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 93, 71, 139);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBackColor = Color.FromArgb(255, 93, 71, 139);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);
                        oTemplate.TimeBlockBackColor = Color.FromArgb(255, 140, 124, 173);

                        mp_ApplyControlTemplate_Solid(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_SOLID_GREEN:
                    {
                        ControlTemplateSolid oTemplate = new ControlTemplateSolid();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBackColor = Color.FromArgb(255, 105, 152, 105);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 105, 152, 105);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);
                        oTemplate.TimeBlockBackColor = Color.FromArgb(255, 177, 201, 177);

                        mp_ApplyControlTemplate_Solid(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_SOLID_RED:
                    {
                        ControlTemplateSolid oTemplate = new ControlTemplateSolid();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 180, 2, 52);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBackColor = Color.FromArgb(255, 180, 2, 52);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 180, 2, 52);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);
                        oTemplate.TimeBlockBackColor = Color.FromArgb(255, 202, 77, 113);

                        mp_ApplyControlTemplate_Solid(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_SOLID_LIGHT_BLUE:
                    {
                        ControlTemplateSolid oTemplate = new ControlTemplateSolid();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 153, 153, 221);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBackColor = Color.FromArgb(255, 153, 153, 221);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 153, 153, 221);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);
                        oTemplate.TimeBlockBackColor = Color.FromArgb(255, 204, 204, 255);

                        mp_ApplyControlTemplate_Solid(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_SOLID_GREY:
                    {
                        ControlTemplateSolid oTemplate = new ControlTemplateSolid();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBackColor = Color.FromArgb(255, 142, 142, 142);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);
                        oTemplate.TimeBlockBackColor = Color.FromArgb(255, 172, 172, 172);

                        mp_ApplyControlTemplate_Solid(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_SOLID_LIGHT_STEEL_BLUE:
                    {
                        ControlTemplateSolid oTemplate = new ControlTemplateSolid();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 162, 181, 205);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBackColor = Color.FromArgb(255, 162, 181, 205);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 162, 181, 205);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);
                        oTemplate.TimeBlockBackColor = Color.FromArgb(255, 187, 201, 219);

                        mp_ApplyControlTemplate_Solid(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_VGRAD_YELLOW:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 209, 164, 2);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 229, 203, 5);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 189, 167, 4);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_VGRAD_ORANGE:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 202, 116, 38);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 201, 109, 36);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 202, 116, 38);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_VGRAD_RED:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 142, 2, 37);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 230, 230, 230);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 142, 2, 37);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 180, 2, 52);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 142, 2, 37);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_VGRAD_CRIMSON:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 157, 3, 57);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 230, 230, 230);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 157, 3, 57);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 206, 2, 73);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 157, 3, 57);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_VGRAD_MAGENTA:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 171, 4, 96);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 171, 4, 96);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 199, 3, 111);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 171, 4, 96);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_VGRAD_MULBERRY:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 156, 2, 124);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 156, 2, 124);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 191, 3, 150);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 156, 2, 124);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_VGRAD_BLUE_VIOLET:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 112, 52, 197);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 142, 63, 217);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_VGRAD_ANAKIWA_BLUE:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 179, 206, 235);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 161, 193, 232);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_VGRAD_BLUE_BELL:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 150, 166, 191);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 177, 198, 227);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_VGRAD_BLUE:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 0, 102, 153);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 3, 167, 208);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_VGRAD_AERO:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 2, 157, 177);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 3, 199, 211);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_HGRAD_YELLOW:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 209, 164, 2);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 229, 203, 5);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 189, 167, 4);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_HGRAD_ORANGE:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 202, 116, 38);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 201, 109, 36);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 202, 116, 38);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_HGRAD_RED:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 142, 2, 37);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 230, 230, 230);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 142, 2, 37);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 180, 2, 52);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 142, 2, 37);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }
                    break;
                case E_CONTROLTEMPLATE.STC_CH_HGRAD_CRIMSON:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 157, 3, 57);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 230, 230, 230);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 157, 3, 57);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 206, 2, 73);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 157, 3, 57);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_HGRAD_MAGENTA:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 171, 4, 96);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 171, 4, 96);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 199, 3, 111);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 171, 4, 96);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_HGRAD_MULBERRY:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 156, 2, 124);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 156, 2, 124);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 191, 3, 150);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 156, 2, 124);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_HGRAD_BLUE_VIOLET:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 112, 52, 197);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 142, 63, 217);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_HGRAD_ANAKIWA_BLUE:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 179, 206, 235);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 161, 193, 232);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_HGRAD_BLUE_BELL:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 150, 166, 191);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 177, 198, 227);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_HGRAD_BLUE:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 0, 102, 153);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 3, 167, 208);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
                case E_CONTROLTEMPLATE.STC_CH_HGRAD_AERO:
                    {
                        ControlTemplateGradient oTemplate = new ControlTemplateGradient();
                        oTemplate.ControlBorderColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.HeadingBorderColor = Color.FromArgb(255, 197, 206, 216);
                        oTemplate.HeadingForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.RowForeColor = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
                        oTemplate.StartGradientColor = Color.FromArgb(255, 2, 157, 177);
                        oTemplate.EndGradientColor = Color.FromArgb(255, 3, 199, 211);
                        oTemplate.TreeviewColor = Color.FromArgb(255, 100, 145, 204);
                        oTemplate.RowBorderColor = Color.FromArgb(255, 192, 192, 192);

                        mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
                    }

                    break;
            }
        }


        private static void mp_ObjectTemplateSelector(ActiveGanttCSWCtl oControl, E_OBJECTTEMPLATE yObjectTemplate)
        {
            switch (yObjectTemplate)
            {
                case E_OBJECTTEMPLATE.STO_BW_HATCH:
                    {
                        S_ObjectTemplate oTemplate = new S_ObjectTemplate();

                        oTemplate.yBackgroundMode_Tasks = GRE_BACKGROUNDMODE.FP_HATCH;

                        oTemplate.BorderColor_T1 = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HatchStyle_T1 = GRE_HATCHSTYLE.HS_PERCENT50;
                        oTemplate.HatchBackColor_T1 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.HatchForeColor_T1 = Color.FromArgb(255, 0, 0, 0);

                        oTemplate.BorderColor_T2 = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HatchStyle_T2 = GRE_HATCHSTYLE.HS_LIGHTUPWARDDIAGONAL;
                        oTemplate.HatchBackColor_T2 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.HatchForeColor_T2 = Color.FromArgb(255, 0, 0, 0);

                        oTemplate.BorderColor_T3 = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HatchStyle_T3 = GRE_HATCHSTYLE.HS_LIGHTDOWNWARDDIAGONAL;
                        oTemplate.HatchBackColor_T3 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.HatchForeColor_T3 = Color.FromArgb(255, 0, 0, 0);

                        oTemplate.BorderColor_T4 = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.HatchStyle_T4 = GRE_HATCHSTYLE.HS_NARROWVERTICAL;
                        oTemplate.HatchBackColor_T4 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.HatchForeColor_T4 = Color.FromArgb(255, 0, 0, 0);

                        mp_ApplyObjectTemplate(oControl, oTemplate);
                    }
                    break;
                case E_OBJECTTEMPLATE.STO_COLOR_HATCH:
                    {
                        S_ObjectTemplate oTemplate = new S_ObjectTemplate();

                        oTemplate.yBackgroundMode_Tasks = GRE_BACKGROUNDMODE.FP_HATCH;

                        oTemplate.BorderColor_T1 = Color.FromArgb(255, 121, 163, 213);
                        oTemplate.HatchStyle_T1 = GRE_HATCHSTYLE.HS_PERCENT50;
                        oTemplate.HatchBackColor_T1 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.HatchForeColor_T1 = Color.FromArgb(255, 121, 163, 213);

                        oTemplate.BorderColor_T2 = Color.FromArgb(255, 82, 94, 119);
                        oTemplate.HatchStyle_T2 = GRE_HATCHSTYLE.HS_LIGHTUPWARDDIAGONAL;
                        oTemplate.HatchBackColor_T2 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.HatchForeColor_T2 = Color.FromArgb(255, 82, 94, 119);

                        oTemplate.BorderColor_T3 = Color.FromArgb(255, 230, 150, 24);
                        oTemplate.HatchStyle_T3 = GRE_HATCHSTYLE.HS_LIGHTDOWNWARDDIAGONAL;
                        oTemplate.HatchBackColor_T3 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.HatchForeColor_T3 = Color.FromArgb(255, 230, 150, 24);

                        oTemplate.BorderColor_T4 = Color.FromArgb(255, 168, 121, 213);
                        oTemplate.HatchStyle_T4 = GRE_HATCHSTYLE.HS_NARROWVERTICAL;
                        oTemplate.HatchBackColor_T4 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.HatchForeColor_T4 = Color.FromArgb(255, 168, 121, 213);

                        mp_ApplyObjectTemplate(oControl, oTemplate);
                    }

                    break;
                case E_OBJECTTEMPLATE.STO_GREY_SOLID:
                    {
                        S_ObjectTemplate oTemplate = new S_ObjectTemplate();

                        oTemplate.yBackgroundMode_Tasks = GRE_BACKGROUNDMODE.FP_SOLID;

                        oTemplate.BorderColor_T1 = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.BackColor_T1 = Color.FromArgb(255, 200, 200, 200);

                        oTemplate.BorderColor_T2 = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.BackColor_T2 = Color.FromArgb(255, 166, 166, 166);

                        oTemplate.BorderColor_T3 = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.BackColor_T3 = Color.FromArgb(255, 133, 133, 133);

                        oTemplate.BorderColor_T4 = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.BackColor_T4 = Color.FromArgb(255, 100, 100, 100);

                        mp_ApplyObjectTemplate(oControl, oTemplate);
                    }

                    break;
                case E_OBJECTTEMPLATE.STO_COLORS_SOLID:
                    {
                        S_ObjectTemplate oTemplate = new S_ObjectTemplate();

                        oTemplate.yBackgroundMode_Tasks = GRE_BACKGROUNDMODE.FP_SOLID;

                        oTemplate.BackColor_T1 = Color.FromArgb(255, 88, 127, 196);
                        oTemplate.BorderColor_T1 = Color.FromArgb(255, 57, 109, 182);

                        oTemplate.BackColor_T2 = Color.FromArgb(255, 195, 82, 76);
                        oTemplate.BorderColor_T2 = Color.FromArgb(255, 189, 55, 56);

                        oTemplate.BackColor_T3 = Color.FromArgb(255, 145, 105, 168);
                        oTemplate.BorderColor_T3 = Color.FromArgb(255, 82, 44, 103);

                        oTemplate.BackColor_T4 = Color.FromArgb(255, 248, 151, 70);
                        oTemplate.BorderColor_T4 = Color.FromArgb(255, 252, 114, 1);

                        mp_ApplyObjectTemplate(oControl, oTemplate);
                    }

                    break;
                case E_OBJECTTEMPLATE.STO_DEFAULT:
                    {
                        S_ObjectTemplate oTemplate = new S_ObjectTemplate();

                        oTemplate.yBackgroundMode_Tasks = GRE_BACKGROUNDMODE.FP_GRADIENT;
                        oTemplate.yGradientFillMode_Tasks = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
                        oTemplate.BorderColor_T1 = Color.FromArgb(255, 0, 0, 255);
                        oTemplate.StartGradientColor_T1 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.EndGradientColor_T1 = Color.FromArgb(255, 100, 100, 204);
                        oTemplate.BorderColor_T2 = Color.FromArgb(255, 0, 128, 0);
                        oTemplate.StartGradientColor_T2 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.EndGradientColor_T2 = Color.FromArgb(255, 100, 204, 100);
                        oTemplate.BorderColor_T3 = Color.FromArgb(255, 255, 0, 0);
                        oTemplate.StartGradientColor_T3 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.EndGradientColor_T3 = Color.FromArgb(255, 204, 100, 100);
                        oTemplate.BorderColor_T4 = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.StartGradientColor_T4 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.EndGradientColor_T4 = Color.FromArgb(255, 51, 51, 51);

                        mp_ApplyObjectTemplate(oControl, oTemplate);
                    }

                    break;
                case E_OBJECTTEMPLATE.STO_VARIATION_1:
                    {
                        S_ObjectTemplate oTemplate = new S_ObjectTemplate();

                        oTemplate.yBackgroundMode_Tasks = GRE_BACKGROUNDMODE.FP_GRADIENT;
                        oTemplate.yGradientFillMode_Tasks = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
                        oTemplate.BorderColor_T1 = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.ForeColor_T1 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.StartGradientColor_T1 = Color.FromArgb(255, 162, 78, 50);
                        oTemplate.EndGradientColor_T1 = Color.FromArgb(255, 215, 92, 54);
                        oTemplate.BorderColor_T2 = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.ForeColor_T2 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.StartGradientColor_T2 = Color.FromArgb(255, 109, 122, 136);
                        oTemplate.EndGradientColor_T2 = Color.FromArgb(255, 179, 199, 229);
                        oTemplate.BorderColor_T3 = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.ForeColor_T3 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.StartGradientColor_T3 = Color.FromArgb(255, 255, 77, 1);
                        oTemplate.EndGradientColor_T3 = Color.FromArgb(255, 244, 172, 43);
                        oTemplate.BorderColor_T4 = Color.FromArgb(255, 0, 0, 0);
                        oTemplate.StartGradientColor_T4 = Color.FromArgb(255, 255, 255, 255);
                        oTemplate.EndGradientColor_T4 = Color.FromArgb(255, 51, 51, 51);

                        mp_ApplyObjectTemplate(oControl, oTemplate);
                    }
                    break;

            }
        }

        private static void mp_ApplyObjectTemplate(ActiveGanttCSWCtl oControl, S_ObjectTemplate oTemplate)
        {
            clsStyle oStyle = null;

            oStyle = oControl.Configuration.DefaultTaskStyle;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;

            oStyle.BackColor = oTemplate.BackColor_T1;
            oStyle.ForeColor = oTemplate.ForeColor_T1;
            oStyle.BorderColor = oTemplate.BorderColor_T1;

            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 10;
            oStyle.BackgroundMode = oTemplate.yBackgroundMode_Tasks;
            oStyle.HatchStyle = oTemplate.HatchStyle_T1;
            oStyle.HatchBackColor = oTemplate.HatchBackColor_T1;
            oStyle.HatchForeColor = oTemplate.HatchForeColor_T1;
            oStyle.GradientFillMode = oTemplate.yGradientFillMode_Tasks;
            oStyle.StartGradientColor = oTemplate.StartGradientColor_T1;
            oStyle.EndGradientColor = oTemplate.EndGradientColor_T1;
            oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND;
            oStyle.MilestoneStyle.BorderColor = oTemplate.BorderColor_T1;
            oStyle.MilestoneStyle.FillColor = oTemplate.BorderColor_T1;

            oStyle.PredecessorStyle.LineColor = oTemplate.BorderColor_T1;


            oStyle = oControl.Configuration.DefaultTaskStyle.Clone("T1");

            oStyle = oControl.Configuration.DefaultTaskStyle.Clone("T2");
            oStyle.BackColor = oTemplate.BackColor_T2;
            oStyle.ForeColor = oTemplate.ForeColor_T2;
            oStyle.BorderColor = oTemplate.BorderColor_T2;

            oStyle.HatchStyle = oTemplate.HatchStyle_T2;
            oStyle.HatchBackColor = oTemplate.HatchBackColor_T2;
            oStyle.HatchForeColor = oTemplate.HatchForeColor_T2;
            oStyle.StartGradientColor = oTemplate.StartGradientColor_T2;
            oStyle.EndGradientColor = oTemplate.EndGradientColor_T2;
            oStyle.PredecessorStyle.LineColor = oTemplate.BorderColor_T2;
            oStyle.MilestoneStyle.BorderColor = oTemplate.BorderColor_T2;
            oStyle.MilestoneStyle.FillColor = oTemplate.BorderColor_T2;

            oStyle = oControl.Configuration.DefaultTaskStyle.Clone("T3");
            oStyle.BackColor = oTemplate.BackColor_T3;
            oStyle.ForeColor = oTemplate.ForeColor_T3;
            oStyle.BorderColor = oTemplate.BorderColor_T3;

            oStyle.HatchStyle = oTemplate.HatchStyle_T3;
            oStyle.HatchBackColor = oTemplate.HatchBackColor_T3;
            oStyle.HatchForeColor = oTemplate.HatchForeColor_T3;
            oStyle.StartGradientColor = oTemplate.StartGradientColor_T3;
            oStyle.EndGradientColor = oTemplate.EndGradientColor_T3;
            oStyle.PredecessorStyle.LineColor = oTemplate.BorderColor_T3;
            oStyle.MilestoneStyle.BorderColor = oTemplate.BorderColor_T3;
            oStyle.MilestoneStyle.FillColor = oTemplate.BorderColor_T3;

            oStyle = oControl.Configuration.DefaultTaskStyle.Clone("T4");
            oStyle.BackColor = oTemplate.BackColor_T4;
            oStyle.ForeColor = oTemplate.ForeColor_T4;
            oStyle.BorderColor = oTemplate.BorderColor_T4;

            oStyle.HatchStyle = oTemplate.HatchStyle_T4;
            oStyle.HatchBackColor = oTemplate.HatchBackColor_T4;
            oStyle.HatchForeColor = oTemplate.HatchForeColor_T4;
            oStyle.StartGradientColor = oTemplate.StartGradientColor_T4;
            oStyle.EndGradientColor = oTemplate.EndGradientColor_T4;
            oStyle.PredecessorStyle.LineColor = oTemplate.BorderColor_T4;
            oStyle.MilestoneStyle.BorderColor = oTemplate.BorderColor_T4;
            oStyle.MilestoneStyle.FillColor = oTemplate.BorderColor_T4;

            oStyle = oControl.Styles.Item("T1").Clone("TW1");
            oStyle.BorderColor = Color.FromArgb(255, 255, 0, 0);
            oStyle.PredecessorStyle.LineColor = Color.FromArgb(255, 255, 0, 0);

            oStyle = oControl.Styles.Item("T2").Clone("TW2");
            oStyle.BorderColor = Color.FromArgb(255, 255, 0, 0);
            oStyle.PredecessorStyle.LineColor = Color.FromArgb(255, 255, 0, 0);

            oStyle = oControl.Styles.Item("T3").Clone("TW3");
            oStyle.BorderColor = Color.FromArgb(255, 255, 255, 0);
            oStyle.PredecessorStyle.LineColor = Color.FromArgb(255, 255, 0, 0);

            oStyle = oControl.Styles.Item("T4").Clone("TW4");
            oStyle.BorderColor = Color.FromArgb(255, 255, 0, 0);
            oStyle.PredecessorStyle.LineColor = Color.FromArgb(255, 255, 0, 0);

            oStyle = oControl.Styles.Item("T1").Clone("S1");
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TaskStyle.StartShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.EndShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.StartBorderColor = oTemplate.BorderColor_T1;
            oStyle.TaskStyle.StartFillColor = oTemplate.BorderColor_T1;
            oStyle.TaskStyle.EndBorderColor = oTemplate.BorderColor_T1;
            oStyle.TaskStyle.EndFillColor = oTemplate.BorderColor_T1;
            oStyle.FillMode = GRE_FILLMODE.FM_UPPERHALFFILLED;

            oStyle = oControl.Styles.Item("T2").Clone("S2");
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TaskStyle.StartShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.EndShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.StartBorderColor = oTemplate.BorderColor_T2;
            oStyle.TaskStyle.StartFillColor = oTemplate.BorderColor_T2;
            oStyle.TaskStyle.EndBorderColor = oTemplate.BorderColor_T2;
            oStyle.TaskStyle.EndFillColor = oTemplate.BorderColor_T2;
            oStyle.FillMode = GRE_FILLMODE.FM_UPPERHALFFILLED;

            oStyle = oControl.Styles.Item("T3").Clone("S3");
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TaskStyle.StartShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.EndShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.StartBorderColor = oTemplate.BorderColor_T3;
            oStyle.TaskStyle.StartFillColor = oTemplate.BorderColor_T3;
            oStyle.TaskStyle.EndBorderColor = oTemplate.BorderColor_T3;
            oStyle.TaskStyle.EndFillColor = oTemplate.BorderColor_T3;
            oStyle.FillMode = GRE_FILLMODE.FM_UPPERHALFFILLED;

            oStyle = oControl.Styles.Item("T4").Clone("S4");
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.TaskStyle.StartShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.EndShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN;
            oStyle.TaskStyle.StartBorderColor = oTemplate.BorderColor_T4;
            oStyle.TaskStyle.StartFillColor = oTemplate.BorderColor_T4;
            oStyle.TaskStyle.EndBorderColor = oTemplate.BorderColor_T4;
            oStyle.TaskStyle.EndFillColor = oTemplate.BorderColor_T4;
            oStyle.FillMode = GRE_FILLMODE.FM_UPPERHALFFILLED;

            oStyle = oControl.Configuration.DefaultPercentageStyle;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.SelectionRectangleStyle.OffsetTop = 0;
            oStyle.SelectionRectangleStyle.OffsetLeft = 0;
            oStyle.SelectionRectangleStyle.OffsetRight = 0;
            oStyle.SelectionRectangleStyle.OffsetBottom = 0;
            oStyle.OffsetTop = 8;
            oStyle.OffsetBottom = 4;
            oStyle.SelectionRectangleStyle.Visible = true;
            oStyle.TextVisible = false;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = oTemplate.BorderColor_T1;
            oStyle.BorderColor = oTemplate.BorderColor_T1;

            oStyle = oControl.Configuration.DefaultPercentageStyle.Clone("P1");

            oStyle = oControl.Configuration.DefaultPercentageStyle.Clone("P2");
            oStyle.BackColor = oTemplate.BorderColor_T2;
            oStyle.BorderColor = oTemplate.BorderColor_T2;

            oStyle = oControl.Configuration.DefaultPercentageStyle.Clone("P3");
            oStyle.BackColor = oTemplate.BorderColor_T3;
            oStyle.BorderColor = oTemplate.BorderColor_T3;

            oStyle = oControl.Configuration.DefaultPercentageStyle.Clone("P4");
            oStyle.BackColor = oTemplate.BorderColor_T4;
            oStyle.BorderColor = oTemplate.BorderColor_T4;

            oStyle = oControl.Configuration.DefaultPercentageStyle.Clone("SP1");
            oStyle.BackColor = oTemplate.BorderColor_T1;
            oStyle.BorderColor = oTemplate.BorderColor_T1;
            oStyle.OffsetTop = 5;
            oStyle.OffsetBottom = 5;
            oStyle.SelectionRectangleStyle.Visible = false;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;

            oStyle = oStyle.Clone("SP2");
            oStyle.BackColor = oTemplate.BorderColor_T2;
            oStyle.BorderColor = oTemplate.BorderColor_T2;

            oStyle = oStyle.Clone("SP3");
            oStyle.BackColor = oTemplate.BorderColor_T3;
            oStyle.BorderColor = oTemplate.BorderColor_T3;

            oStyle = oStyle.Clone("SP4");
            oStyle.BackColor = oTemplate.BorderColor_T4;
            oStyle.BorderColor = oTemplate.BorderColor_T4;



            oStyle = oControl.Styles.Add("RET1");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = oTemplate.yBackgroundMode_Tasks;
            oStyle.GradientFillMode = oTemplate.yGradientFillMode_Tasks;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.Placement = E_PLACEMENT.PLC_ROWEXTENTSPLACEMENT;
            oStyle.BackColor = oTemplate.BackColor_T1;
            oStyle.ForeColor = oTemplate.ForeColor_T1;
            oStyle.BorderColor = oTemplate.BorderColor_T1;
            oStyle.HatchStyle = oTemplate.HatchStyle_T1;
            oStyle.HatchBackColor = oTemplate.HatchBackColor_T1;
            oStyle.HatchForeColor = oTemplate.HatchForeColor_T1;
            oStyle.StartGradientColor = oTemplate.StartGradientColor_T1;
            oStyle.EndGradientColor = oTemplate.EndGradientColor_T1;
            oStyle.PredecessorStyle.LineColor = oTemplate.BorderColor_T1;
            oStyle.MilestoneStyle.BorderColor = oTemplate.BorderColor_T1;
            oStyle.MilestoneStyle.FillColor = oTemplate.BorderColor_T1;

            oStyle = oControl.Styles.Item("RET1").Clone("RET2");
            oStyle.BackColor = oTemplate.BackColor_T2;
            oStyle.ForeColor = oTemplate.ForeColor_T2;
            oStyle.BorderColor = oTemplate.BorderColor_T2;
            oStyle.HatchStyle = oTemplate.HatchStyle_T2;
            oStyle.HatchBackColor = oTemplate.HatchBackColor_T2;
            oStyle.HatchForeColor = oTemplate.HatchForeColor_T2;
            oStyle.StartGradientColor = oTemplate.StartGradientColor_T2;
            oStyle.EndGradientColor = oTemplate.EndGradientColor_T2;
            oStyle.PredecessorStyle.LineColor = oTemplate.BorderColor_T2;
            oStyle.MilestoneStyle.BorderColor = oTemplate.BorderColor_T2;
            oStyle.MilestoneStyle.FillColor = oTemplate.BorderColor_T2;

            oStyle = oControl.Styles.Item("RET1").Clone("RET3");
            oStyle.BackColor = oTemplate.BackColor_T3;
            oStyle.ForeColor = oTemplate.ForeColor_T3;
            oStyle.BorderColor = oTemplate.BorderColor_T3;
            oStyle.HatchStyle = oTemplate.HatchStyle_T3;
            oStyle.HatchBackColor = oTemplate.HatchBackColor_T3;
            oStyle.HatchForeColor = oTemplate.HatchForeColor_T3;
            oStyle.StartGradientColor = oTemplate.StartGradientColor_T3;
            oStyle.EndGradientColor = oTemplate.EndGradientColor_T3;
            oStyle.PredecessorStyle.LineColor = oTemplate.BorderColor_T3;
            oStyle.MilestoneStyle.BorderColor = oTemplate.BorderColor_T3;
            oStyle.MilestoneStyle.FillColor = oTemplate.BorderColor_T3;

            oStyle = oControl.Styles.Item("RET1").Clone("RET4");
            oStyle.BackColor = oTemplate.BackColor_T4;
            oStyle.ForeColor = oTemplate.ForeColor_T4;
            oStyle.BorderColor = oTemplate.BorderColor_T4;
            oStyle.HatchStyle = oTemplate.HatchStyle_T4;
            oStyle.HatchBackColor = oTemplate.HatchBackColor_T4;
            oStyle.HatchForeColor = oTemplate.HatchForeColor_T4;
            oStyle.StartGradientColor = oTemplate.StartGradientColor_T4;
            oStyle.EndGradientColor = oTemplate.EndGradientColor_T4;
            oStyle.PredecessorStyle.LineColor = oTemplate.BorderColor_T4;
            oStyle.MilestoneStyle.BorderColor = oTemplate.BorderColor_T4;
            oStyle.MilestoneStyle.FillColor = oTemplate.BorderColor_T4;


        }

        public static void g_ApplyTemplate_Gradient(ActiveGanttCSWCtl oControl, ControlTemplateGradient oTemplate, E_OBJECTTEMPLATE yObjectTemplate)
        {
            oControl.Styles.Clear();
            mp_ApplyControlTemplate_Gradient(oControl, oTemplate);
            mp_ObjectTemplateSelector(oControl, yObjectTemplate);
        }

        private static void mp_ApplyControlTemplate_Gradient(ActiveGanttCSWCtl oControl, ControlTemplateGradient oTemplate)
        {
            clsStyle oStyle = null;

            oStyle = oControl.Configuration.DefaultControlStyle;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.BorderColor = oTemplate.ControlBorderColor;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);

            oStyle = oControl.Configuration.DefaultColumnStyle;
            oStyle.Font = new Font(oControl.Configuration.DefaultFont.Name, 8, FontWeights.Bold);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = oTemplate.GradientFillMode;
            oStyle.StartGradientColor = oTemplate.StartGradientColor;
            oStyle.EndGradientColor = oTemplate.EndGradientColor;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Right = true;
            oStyle.CustomBorderStyle.Bottom = true;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.BorderColor = oTemplate.HeadingBorderColor;
            oStyle.ForeColor = oTemplate.HeadingForeColor;

            oStyle = oControl.Configuration.DefaultTimeLineStyle;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_NONE;
            oStyle.GradientFillMode = oTemplate.GradientFillMode;
            oStyle.StartGradientColor = oTemplate.StartGradientColor;
            oStyle.EndGradientColor = oTemplate.EndGradientColor;


            oStyle = oControl.Configuration.DefaultTierStyle;
            oStyle.Font = new Font(oControl.Configuration.DefaultFont.Name, 7, FontWeights.Regular);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            if (oTemplate.GradientFillMode == GRE_GRADIENTFILLMODE.GDT_VERTICAL)
            {
                oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_TRANSPARENT;
            }
            else
            {
                oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
                oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
                oStyle.StartGradientColor = oTemplate.StartGradientColor;
                oStyle.EndGradientColor = oTemplate.EndGradientColor;
            }
            oStyle.CustomBorderStyle.Left = true;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Right = false;
            oStyle.CustomBorderStyle.Bottom = true;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.BorderColor = oTemplate.HeadingBorderColor;
            oStyle.ClipText = false;
            oStyle.ForeColor = oTemplate.HeadingForeColor;
            oControl.CurrentViewObject.TimeLine.TierArea.UpperTier.BackgroundMode = E_TIERBACKGROUNDMODE.ETBGM_STYLE;
            oControl.CurrentViewObject.TimeLine.TierArea.MiddleTier.BackgroundMode = E_TIERBACKGROUNDMODE.ETBGM_STYLE;
            oControl.CurrentViewObject.TimeLine.TierArea.LowerTier.BackgroundMode = E_TIERBACKGROUNDMODE.ETBGM_STYLE;

            oStyle = oControl.Configuration.DefaultTickMarkAreaStyle;
            oStyle.Font = new Font(oControl.Configuration.DefaultFont.Name, 7, FontWeights.Regular);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_TRANSPARENT;
            oStyle.CustomBorderStyle.Left = true;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Right = false;
            oStyle.CustomBorderStyle.Bottom = true;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.BorderColor = oTemplate.HeadingBorderColor;
            oStyle.ForeColor = oTemplate.HeadingForeColor;

            oStyle = oControl.Configuration.DefaultRowStyle;
            oStyle.Font = new Font(oControl.Configuration.DefaultFont.Name, 8, FontWeights.Regular);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.ForeColor = oTemplate.RowForeColor;

            oStyle = oControl.Configuration.DefaultCellStyle;
            oStyle.Font = new Font(oControl.Configuration.DefaultFont.Name, 8, FontWeights.Regular);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.ForeColor = oTemplate.RowForeColor;

            oStyle = oControl.Configuration.DefaultCellStyle.Clone("CL");

            oStyle = oControl.Configuration.DefaultCellStyle.Clone("CR");
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;

            oStyle = oControl.Configuration.DefaultCellStyle.Clone("CH");
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.BorderColor = oTemplate.ControlBorderColor;


            oStyle = oControl.Configuration.DefaultNodeStyle;
            oStyle.Font = new Font(oControl.Configuration.DefaultFont.Name, 8, FontWeights.Regular);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.ForeColor = oTemplate.RowForeColor;

            oStyle = oControl.Configuration.DefaultNodeStyle.Clone("NR");

            oStyle = oControl.Configuration.DefaultNodeStyle.Clone("NB");
            oStyle.Font = new Font(oControl.Configuration.DefaultFont.Name, 8, FontWeights.Bold);

            oStyle = oControl.Configuration.DefaultClientAreaStyle;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.CustomBorderStyle.Right = false;

            oControl.Treeview.PlusMinusBorderColor = oTemplate.TreeviewColor;
            oControl.Treeview.PlusMinusSignColor = oTemplate.TreeviewColor;
            oControl.Treeview.CheckBoxBorderColor = oTemplate.TreeviewColor;
            oControl.Treeview.CheckBoxMarkColor = oTemplate.TreeviewColor;
            oControl.Treeview.TreeLineColor = oTemplate.TreeviewColor;
            oControl.Treeview.CheckBoxBackColor = oTemplate.TreeviewColor;
            oControl.Treeview.PlusMinusBackColor = oTemplate.TreeviewColor;

            oControl.Splitter.Type = E_SPLITTERTYPE.SA_USERDEFINED;
            oControl.Splitter.Width = 1;
            oControl.Splitter.SetColor(1, oTemplate.ControlBorderColor);

            oStyle = oControl.Configuration.DefaultSBSeparatorStyle;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = oTemplate.RowBorderColor;

            oStyle = oControl.Configuration.DefaultScrollBarStyle;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.ScrollBarStyle.ArrowColor = Color.FromArgb(255, 0, 0, 0);

            oStyle = oControl.Styles.Add("AB");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.ScrollBarStyle.ArrowColor = Color.FromArgb(255, 0, 0, 0);

            oStyle = oControl.Styles.Add("TBH");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.EndGradientColor = oTemplate.EndGradientColor;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);

            oStyle = oControl.Styles.Item("TBH").Clone("TBHP");
            oStyle.StartGradientColor = oTemplate.EndGradientColor;
            oStyle.EndGradientColor = Color.FromArgb(255, 255, 255, 255);

            oStyle = oControl.Styles.Add("TBV");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.EndGradientColor = oTemplate.EndGradientColor;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);

            oStyle = oControl.Styles.Item("TBV").Clone("TBVP");
            oStyle.StartGradientColor = oTemplate.EndGradientColor;
            oStyle.EndGradientColor = Color.FromArgb(255, 255, 255, 255);

            oControl.VerticalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "AB";
            oControl.VerticalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "AB";
            oControl.VerticalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "AB";
            oControl.VerticalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "TBV";
            oControl.VerticalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "TBVP";
            oControl.VerticalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "TBV";

            oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "AB";
            oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "AB";
            oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "AB";
            oControl.HorizontalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "TBH";
            oControl.HorizontalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "TBHP";
            oControl.HorizontalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "TBH";

            oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "AB";
            oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "AB";
            oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "AB";
            oControl.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "TBH";
            oControl.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "TBHP";
            oControl.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "TBH";

            clsTimeLine oTimeLine = oControl.CurrentViewObject.TimeLine;

            oTimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "AB";
            oTimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "AB";
            oTimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "AB";
            oTimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "TBH";
            oTimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "TBHP";
            oTimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "TBH";

            oStyle = oControl.Configuration.DefaultTimeBlockStyle;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_NONE;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
            oStyle.StartGradientColor = oTemplate.StartGradientColor;
            oStyle.EndGradientColor = oTemplate.EndGradientColor;
        }

        public static void g_ApplyTemplate_Solid(ActiveGanttCSWCtl oControl, ControlTemplateSolid oTemplate, E_OBJECTTEMPLATE yObjectTemplate)
        {
            oControl.Styles.Clear();
            mp_ApplyControlTemplate_Solid(oControl, oTemplate);
            mp_ObjectTemplateSelector(oControl, yObjectTemplate);
        }

        private static void mp_ApplyControlTemplate_Solid(ActiveGanttCSWCtl oControl, ControlTemplateSolid oTemplate)
        {
            clsStyle oStyle = null;

            oStyle = oControl.Configuration.DefaultControlStyle;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.BorderColor = oTemplate.ControlBorderColor;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);

            oStyle = oControl.Configuration.DefaultColumnStyle;
            oStyle.Font = new Font(oControl.Configuration.DefaultFont.Name, 8, FontWeights.Bold);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = oTemplate.HeadingBackColor;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Right = true;
            oStyle.CustomBorderStyle.Bottom = true;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.BorderColor = oTemplate.HeadingBorderColor;
            oStyle.ForeColor = oTemplate.HeadingForeColor;

            oStyle = oControl.Configuration.DefaultTimeLineStyle;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_NONE;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = oTemplate.HeadingBackColor;


            oStyle = oControl.Configuration.DefaultTierStyle;
            oStyle.Font = new Font(oControl.Configuration.DefaultFont.Name, 7, FontWeights.Regular);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = oTemplate.HeadingBackColor;
            oStyle.CustomBorderStyle.Left = true;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Right = false;
            oStyle.CustomBorderStyle.Bottom = true;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.BorderColor = oTemplate.HeadingBorderColor;
            oStyle.ClipText = false;
            oStyle.ForeColor = oTemplate.HeadingForeColor;
            oControl.CurrentViewObject.TimeLine.TierArea.UpperTier.BackgroundMode = E_TIERBACKGROUNDMODE.ETBGM_STYLE;
            oControl.CurrentViewObject.TimeLine.TierArea.MiddleTier.BackgroundMode = E_TIERBACKGROUNDMODE.ETBGM_STYLE;
            oControl.CurrentViewObject.TimeLine.TierArea.LowerTier.BackgroundMode = E_TIERBACKGROUNDMODE.ETBGM_STYLE;

            oStyle = oControl.Configuration.DefaultTickMarkAreaStyle;
            oStyle.Font = new Font(oControl.Configuration.DefaultFont.Name, 7, FontWeights.Regular);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_TRANSPARENT;
            oStyle.CustomBorderStyle.Left = true;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Right = false;
            oStyle.CustomBorderStyle.Bottom = true;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.BorderColor = oTemplate.HeadingBorderColor;
            oStyle.ForeColor = oTemplate.HeadingForeColor;

            oStyle = oControl.Configuration.DefaultRowStyle;
            oStyle.Font = new Font(oControl.Configuration.DefaultFont.Name, 8, FontWeights.Regular);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.ForeColor = oTemplate.RowForeColor;

            oStyle = oControl.Configuration.DefaultCellStyle;
            oStyle.Font = new Font(oControl.Configuration.DefaultFont.Name, 8, FontWeights.Regular);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.ForeColor = oTemplate.RowForeColor;

            oStyle = oControl.Configuration.DefaultCellStyle.Clone("CL");

            oStyle = oControl.Configuration.DefaultCellStyle.Clone("CR");
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;

            oStyle = oControl.Configuration.DefaultCellStyle.Clone("CH");
            oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT;
            oStyle.BorderColor = oTemplate.ControlBorderColor;


            oStyle = oControl.Configuration.DefaultNodeStyle;
            oStyle.Font = new Font(oControl.Configuration.DefaultFont.Name, 8, FontWeights.Regular);
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.ForeColor = oTemplate.RowForeColor;

            oStyle = oControl.Configuration.DefaultNodeStyle.Clone("NR");

            oStyle = oControl.Configuration.DefaultNodeStyle.Clone("NB");
            oStyle.Font = new Font(oControl.Configuration.DefaultFont.Name, 8, FontWeights.Bold);

            oStyle = oControl.Configuration.DefaultClientAreaStyle;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM;
            oStyle.CustomBorderStyle.Top = false;
            oStyle.CustomBorderStyle.Left = false;
            oStyle.CustomBorderStyle.Right = false;

            oControl.Treeview.PlusMinusBorderColor = oTemplate.TreeviewColor;
            oControl.Treeview.PlusMinusSignColor = oTemplate.TreeviewColor;
            oControl.Treeview.CheckBoxBorderColor = oTemplate.TreeviewColor;
            oControl.Treeview.CheckBoxMarkColor = oTemplate.TreeviewColor;
            oControl.Treeview.TreeLineColor = oTemplate.TreeviewColor;
            oControl.Treeview.CheckBoxBackColor = oTemplate.TreeviewColor;
            oControl.Treeview.PlusMinusBackColor = oTemplate.TreeviewColor;

            oControl.Splitter.Type = E_SPLITTERTYPE.SA_USERDEFINED;
            oControl.Splitter.Width = 1;
            oControl.Splitter.SetColor(1, oTemplate.ControlBorderColor);

            oStyle = oControl.Configuration.DefaultSBSeparatorStyle;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = oTemplate.RowBorderColor;

            oStyle = oControl.Configuration.DefaultScrollBarStyle;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.ScrollBarStyle.ArrowColor = Color.FromArgb(255, 0, 0, 0);

            oStyle = oControl.Styles.Add("AB");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.ScrollBarStyle.ArrowColor = Color.FromArgb(255, 0, 0, 0);

            oStyle = oControl.Styles.Add("TBH");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.EndGradientColor = oTemplate.HeadingBackColor;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);

            oStyle = oControl.Styles.Item("TBH").Clone("TBHP");
            oStyle.StartGradientColor = oTemplate.HeadingBackColor;
            oStyle.EndGradientColor = Color.FromArgb(255, 255, 255, 255);

            oStyle = oControl.Styles.Add("TBV");
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT;
            oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL;
            oStyle.StartGradientColor = Color.FromArgb(255, 255, 255, 255);
            oStyle.EndGradientColor = oTemplate.HeadingBackColor;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE;
            oStyle.BorderColor = oTemplate.RowBorderColor;
            oStyle.BackColor = Color.FromArgb(255, 255, 255, 255);

            oStyle = oControl.Styles.Item("TBV").Clone("TBVP");
            oStyle.StartGradientColor = oTemplate.HeadingBackColor;
            oStyle.EndGradientColor = Color.FromArgb(255, 255, 255, 255);

            oControl.VerticalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "AB";
            oControl.VerticalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "AB";
            oControl.VerticalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "AB";
            oControl.VerticalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "TBV";
            oControl.VerticalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "TBVP";
            oControl.VerticalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "TBV";

            oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "AB";
            oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "AB";
            oControl.HorizontalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "AB";
            oControl.HorizontalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "TBH";
            oControl.HorizontalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "TBHP";
            oControl.HorizontalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "TBH";

            oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "AB";
            oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "AB";
            oControl.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "AB";
            oControl.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "TBH";
            oControl.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "TBHP";
            oControl.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "TBH";

            clsTimeLine oTimeLine = oControl.CurrentViewObject.TimeLine;

            oTimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "AB";
            oTimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "AB";
            oTimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "AB";
            oTimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "TBH";
            oTimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "TBHP";
            oTimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "TBH";

            oStyle = oControl.Configuration.DefaultTimeBlockStyle;
            oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_NONE;
            oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT;
            oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID;
            oStyle.BackColor = oTemplate.TimeBlockBackColor;
        }



    }




}