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
                case TransitionType.Pan:
                case TransitionType.Orbit:
                case TransitionType.Rotate:
                case TransitionType.Wipe:
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
                case TransitionType.Warp:
                    result = ((IInOutTransition)slide.SlideShowTransition.Value).Direction.ToString();
                    break;
                case TransitionType.Flythrough:
                    result = ((IFlyThroughTransition)slide.SlideShowTransition.Value).Direction.ToString();
                    break;
                case TransitionType.Reveal:
                    result = ((IRevealTransition)slide.SlideShowTransition.Value).Direction.ToString();
                    break;
                case TransitionType.Split:
                    result = ((ISplitTransition)slide.SlideShowTransition.Value).Direction.ToString();
                    break;
                case TransitionType.Gallery:
                case TransitionType.Flip:
                case TransitionType.Conveyor:
                case TransitionType.Switch:
                case TransitionType.Ferris:
                    result = ((ILeftRightDirectionTransition)slide.SlideShowTransition.Value).Direction.ToString();
                    break;
                case TransitionType.Comb:
                    result = ((IOrientationTransition)slide.SlideShowTransition.Value).Direction.ToString();
                    break;
            }

            return result;
        }

        public static string GetSlideTransitionExtraData(ISlide slide)
        {
            string result = "";

            if (slide.SlideShowTransition.Type == TransitionType.Flythrough)
                result = ((IFlyThroughTransition)slide.SlideShowTransition.Value).HasBounce ? "HasBounce" : "";
            else if (slide.SlideShowTransition.Type == TransitionType.Reveal)
                result = ((IRevealTransition)slide.SlideShowTransition.Value).ThroughBlack? "ThroughBlack" : "";
            else if (slide.SlideShowTransition.Type == TransitionType.Split)
                result = ((ISplitTransition)slide.SlideShowTransition.Value).Orientation.ToString();

            return result;
        }
    }
}