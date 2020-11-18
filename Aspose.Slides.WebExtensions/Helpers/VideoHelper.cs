// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.
using System;
using Aspose.Slides.Export.Web;

namespace Aspose.Slides.WebExtensions.Helpers
{
    public static class VideoHelper
    {

        public static string GetVideoURL<T>(VideoFrame videoFrame, TemplateContext<T> model)
        {
            if (videoFrame == null)
                throw new InvalidOperationException("Parameter videoFrame can't be null");

            var videoSrcPath = model.Output.GetResourcePath(videoFrame.EmbeddedVideo);
            var slidesPath = model.Global.Get<string>("slidesPath");

            string result = ShapeHelper.ConvertPathToRelative(videoSrcPath, slidesPath);
            return result;
        }
    }
}


