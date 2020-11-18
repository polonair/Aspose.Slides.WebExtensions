// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System.Drawing;

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
    }
}
