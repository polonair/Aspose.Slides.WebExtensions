// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using Aspose.Slides.Export.Web;
using System.Drawing;
using System.Linq;

namespace Aspose.Slides.WebExtensions.Helpers
{
    public static class FillHelper
    {
        public static string GetFillStyle<T>(IFillFormatEffectiveData format, TemplateContext<T> model)
        {
            string result = "";
            switch (format.FillType)
            {
                case FillType.Solid:
                    result = string.Format("background-color: {0};", ColorTranslator.ToHtml(format.SolidFillColor));
                    break;
                case FillType.Picture:
                    result = string.Format("background-image: url(\"{0}\");", ImageHelper.GetImageURL(format.PictureFillFormat.Picture.Image, model));
                    break;
                case FillType.Gradient:
                    result = string.Format("background: {0};", FillHelper.GetGradientFill(format.GradientFormat));
                    break;
                case FillType.Pattern:
                    result = string.Format("background: url(\"{0}\") repeat;", PatternGenerator.GetPatternImage(format.PatternFormat.PatternStyle, format.PatternFormat.ForeColor, format.PatternFormat.BackColor));
                    break;
            }

            return result;
        }

        private static string GetGradientFill(IGradientFormatEffectiveData format)
        {
            string result = "";
            string gradStops = "";
            foreach (var gradStop in format.GradientStops.ToList().OrderBy(stop => stop.Position))
            {
                gradStops += string.Format(", {0}", ColorTranslator.ToHtml(gradStop.Color));
                if (gradStop.Position > 0 && gradStop.Position < 1)
                {
                    gradStops += string.Format(" {0}%", gradStop.Position * 100);
                }
            }

            if (format.GradientShape == GradientShape.Linear)
            {
                result = string.Format("linear-gradient({0}deg{1})", format.LinearGradientAngle + 90, gradStops);
            }
            else if (format.GradientShape == GradientShape.Radial)
            {
                string centerPosition = "";
                switch (format.GradientDirection)
                {
                    case GradientDirection.FromCorner1:
                        centerPosition = "top left";
                        break;
                    case GradientDirection.FromCorner2:
                        centerPosition = "top right";
                        break;
                    case GradientDirection.FromCorner3:
                        centerPosition = "bottom left";
                        break;
                    case GradientDirection.FromCorner4:
                        centerPosition = "bottom right";
                        break;
                    default:
                        centerPosition = "center";
                        break;
                }

                result = string.Format("radial-gradient(circle at {0}{1})", centerPosition, gradStops);
            }

            return result;
        }
    }
}