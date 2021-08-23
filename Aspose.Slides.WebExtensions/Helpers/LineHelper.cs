// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System.Drawing;

namespace Aspose.Slides.WebExtensions.Helpers
{
    public static class LineHelper
    {
        public static string GetLineStyle(ILineFormatEffectiveData lineFormat)
        {
            if (lineFormat.Style != LineStyle.NotDefined && lineFormat.FillFormat.FillType == FillType.Solid)
                return string.Format("{0}px {1} {2}", lineFormat.Width, GetCssLineType(lineFormat.DashStyle), ColorHelper.GetRrbaColorString(lineFormat.FillFormat.SolidFillColor));
            else
                return "";
        }
        
        public static string GetCssLineType(LineDashStyle lineStyle)
        {
            switch (lineStyle)
            {
                case LineDashStyle.Dot:
                case LineDashStyle.SystemDot:
                    return "dotted";
                case LineDashStyle.Dash:
                case LineDashStyle.LargeDash:
                case LineDashStyle.SystemDash:
                    return "dashed";
                default:
                    return "solid";
            }
        }
    }
}