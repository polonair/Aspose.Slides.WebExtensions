// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using Aspose.Slides.SlideShow;

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

        public static string GetSlideTransitionDirection(ISlide slide)
        {
            string result = "";

            switch (slide.SlideShowTransition.Type)
            {
                case TransitionType.Push:
                case TransitionType.Cube:
                case TransitionType.Box:
                    result = ((ISideDirectionTransition)slide.SlideShowTransition.Value).Direction.ToString();
                    break;
                case TransitionType.Pull:
                case TransitionType.Cover:
                    result = ((IEightDirectionTransition)slide.SlideShowTransition.Value).Direction.ToString();
                    break;
                case TransitionType.RandomBar:
                    result = ((IOrientationTransition)slide.SlideShowTransition.Value).Direction.ToString();
                    break;
                case TransitionType.Zoom:
                    result = ((IInOutTransition)slide.SlideShowTransition.Value).Direction.ToString();
					break;
                case TransitionType.Gallery:
                case TransitionType.Flip:
                    result = ((ILeftRightDirectionTransition)slide.SlideShowTransition.Value).Direction.ToString();
                    break;
            }

            return result;
        }
    }
}