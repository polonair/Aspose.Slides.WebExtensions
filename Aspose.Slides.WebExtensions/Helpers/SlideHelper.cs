// Copyright (c) 2001-2021 Aspose Pty Ltd. All Rights Reserved.

using System;
using System.Collections.Generic;
using Aspose.Slides.Animation;
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
                result = ((IRevealTransition)slide.SlideShowTransition.Value).ThroughBlack ? "ThroughBlack" : "";
            else if (slide.SlideShowTransition.Type == TransitionType.Split)
                result = ((ISplitTransition)slide.SlideShowTransition.Value).Orientation.ToString();

            return result;
        }

        public static Dictionary<IShape, Tuple<string, string, float, float, string, int>> GetSlidesAnimationCollection(ISlide slide)
        {
            var result = new Dictionary<IShape, Tuple<string, string, float, float, string, int>>();

            int onclickIndex;
            onclickIndex = FillSequenceEffectCollection(slide.LayoutSlide.MasterSlide.Timeline.MainSequence, result, 0);
            onclickIndex = FillSequenceEffectCollection(slide.LayoutSlide.Timeline.MainSequence, result, onclickIndex);
            onclickIndex = FillSequenceEffectCollection(slide.Timeline.MainSequence, result, onclickIndex);
            
            foreach (var sequence in slide.LayoutSlide.MasterSlide.Timeline.InteractiveSequences)
                FillSequenceEffectCollection(sequence, result, -1);
            foreach (var sequence in slide.LayoutSlide.Timeline.InteractiveSequences)
                FillSequenceEffectCollection(sequence, result, -1);
            foreach (var sequence in slide.Timeline.InteractiveSequences)
                FillSequenceEffectCollection(sequence, result, -1);

            return result;
        }

        private static int FillSequenceEffectCollection(ISequence sequence, Dictionary<IShape, Tuple<string, string, float, float, string, int>> shapeEffectsCollection, int onclickIndex)
        {
            float prevDelay = 0;
            float maxPrevDuration = 0;
            
            foreach (var effect in sequence)
            {
                var shape = effect.TargetShape;
                var classType = effect.PresetClassType;
                var type = effect.Type;
                var subType = effect.Subtype;
                var triggerType = effect.Timing.TriggerType;

                var delay = effect.Timing.TriggerDelayTime;

                string targetShapeId = "";

                float duration = 0;
                foreach (var behavior in effect.Behaviors)
                {
                    if (behavior.GetType() == typeof(PropertyEffect) || behavior.GetType() == typeof(FilterEffect))
                    {
                        if (type == EffectType.CenterRevolve || type == EffectType.Bounce) // a crutch...
                        {
                            duration += behavior.Timing.Duration;
                        }
                        else
                        {
                            duration = behavior.Timing.Duration;
                            break;
                        }
                    }
                }

                if (type == EffectType.CenterRevolve || type == EffectType.Bounce) // a crutch...
                    duration /= 2;

                if (triggerType == EffectTriggerType.AfterPrevious)
                {
                    prevDelay += maxPrevDuration;
                    maxPrevDuration = delay + duration;
                }
                else if (triggerType == EffectTriggerType.WithPrevious)
                {
                    maxPrevDuration = Math.Max(maxPrevDuration, delay + duration);
                }
                else // OnClick
                {
                    onclickIndex++;
                    prevDelay = 0;
                    maxPrevDuration = delay + duration;
                }

                if (sequence.TriggerShape != null)
                    targetShapeId = "slide-" + sequence.TriggerShape.Slide.SlideId + "-shape-" + sequence.TriggerShape.UniqueId;
                else
                    targetShapeId = "slide";

                float totalDelay = delay + prevDelay;

                shapeEffectsCollection.Add(shape, new Tuple<string, string, float, float, string, int>(classType.ToString() + type.ToString(), subType.ToString(), duration, totalDelay, targetShapeId, onclickIndex));
            }

            return onclickIndex;
        }
    }
}