// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

namespace Aspose.Slides.WebExtensions.Helpers
{
    public static class SlideHelper
    {
        public static int GetVisibleSlideNumber(ISlide slide)
        {
            int hiddenSlidesCount = 0;
            for (int i = 0; i < slide.SlideNumber; i++)
                if (slide.Presentation.Slides[i].Hidden)
                    hiddenSlidesCount++;

            return slide.SlideNumber - hiddenSlidesCount;
        }
    }
}