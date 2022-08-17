// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System;
using System.Drawing;
using Aspose.Slides.Export.Web;

namespace Aspose.Slides.WebExtensions.Helpers
{
    public static class FontHelper
    {
        public static string GetEmbeddedFontUrl(IFontData font, FontStyle style)
        {
            if (style == FontStyle.Regular)
                return string.Format("fonts/{0}.ttf", font.FontName);

            return string.Format("fonts/{0} {1}.ttf", font.FontName, style.ToString());
        }
        public static string SelectFont<T>(IPortionFormatEffectiveData format, TemplateContext<T> model)
        {
            if (model is TemplateContext<Portion> portionTplCtx)
            {
                if (portionTplCtx.Object.PortionFormat.LanguageId == "he-IL")
                {
                    return format.ComplexScriptFont.ToString();
                }
                else return format.LatinFont.ToString();
            }
            return format.LatinFont.ToString();
        }
    }
}
