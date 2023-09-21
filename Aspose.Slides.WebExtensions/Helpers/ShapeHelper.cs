// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Slides.Export.Web;

namespace Aspose.Slides.WebExtensions.Helpers
{
    public static class ShapeHelper
    {
        public static string GetShapeAsImageURL<T>(T shape, TemplateContext<T> model)
        {
            if (!(shape is Shape))
            {
                throw new InvalidOperationException("Object of Shape class expected");
            }

            if (model.Global.Get<bool>("embedImages"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Bitmap image = (shape as Shape).GetThumbnail();
                    image.Save(ms, ImageFormat.Png);
                    return "'data:image/png;base64, " + Convert.ToBase64String(ms.ToArray()) + "'";
                }
            }
            else
            {
                var imgSrcPath = "";
                var slidesPath = model.Global.Get<string>("slidesPath");

                try
                {
                    imgSrcPath = model.Output.GetResourcePath(shape as Shape);
                }
                catch (ArgumentException)
                {
                    if (shape is OleObjectFrame && (shape as OleObjectFrame).SubstitutePictureFormat != null && (shape as OleObjectFrame).SubstitutePictureFormat.Picture != null)
                    {
                        imgSrcPath = model.Output.GetResourcePath((shape as OleObjectFrame).SubstitutePictureFormat.Picture.Image);
                    }
                    else
                    {
                        throw;
                    }
                }

                string result = ShapeHelper.ConvertPathToRelative(imgSrcPath, slidesPath);
                return result;
            }
        }
        public static void AddShapesAsImagesOutput(WebDocument document, string outputPath, IPresentation pres)
        {
            uint counter = 0;

            IList<IBaseSlide> masterSlides = new List<IBaseSlide>();
            foreach (Slide slide in pres.Slides)
            {
                foreach (var shape in slide.Shapes)
                    AddShapeToResources(shape, document, outputPath, pres, ref counter);

                if (slide.IsLayoutShapesShown && !masterSlides.Contains(slide.LayoutSlide))
                    masterSlides.Add(slide.LayoutSlide);

                if (slide.IsLayoutMasterShapesShown && !masterSlides.Contains(slide.LayoutSlide.MasterSlide))
                    masterSlides.Add(slide.LayoutSlide.MasterSlide);
            }

            foreach (var master in masterSlides)
            {
                foreach (var shape in master.Shapes)
                    AddShapeToResources(shape, document, outputPath, pres, ref counter);
            }
        }

        private static void AddShapeToResources(IShape shape, WebDocument document, string outputPath, IPresentation pres, ref uint counter)
        {
            if (shape.Hidden)
                return;

            AutoShape autoShape = shape as AutoShape;
            if (autoShape != null && (autoShape.ShapeType == ShapeType.Rectangle || autoShape.ShapeType == ShapeType.NotDefined))
            {
                //skip ShapeType.Rectangle and ShapeType.NotDefined because there is specific template for these types
                return;
            }

            string path;
            IVideoFrame videoFrame = shape as IVideoFrame;
            if (videoFrame != null)
            {
                Video video = (Video)videoFrame.EmbeddedVideo;
                path = Path.Combine(outputPath, string.Format("video{0}.{1}", counter++, video.Extension));

                var outputFile = document.Output.Add(path, video);
                document.Output.BindResource(outputFile, video);

                return;
            }

            if (shape is IPictureFrame)
                return;

            Bitmap thumbnail;
            if (autoShape != null && !string.IsNullOrEmpty(autoShape.TextFrame.Text))
            {
                //Make shape clone -> remove text from the clone -> get image of the clone -> remove the clone. Export text as HTML markup in the template.
                AutoShape clone = (AutoShape)pres.Slides[0].Shapes.AddClone(autoShape);

                try
                {
                    clone.TextFrame.Paragraphs.Clear();
                    thumbnail = clone.GetThumbnail();
                }
                finally
                {
                    pres.Slides[0].Shapes.Remove(clone);
                }
            }
            else if (shape is IConnector)
            {
                thumbnail = shape.GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);
            }
            else
            {
                thumbnail = shape.GetThumbnail();
            }

            path = Path.Combine(outputPath, string.Format("{0}{1}.png", shape.GetType().Name.ToLower(), counter++));

            using (MemoryStream ms = new MemoryStream())
            {
                thumbnail.Save(ms, ImageFormat.Png);
                var outputFile = document.Output.Add(path, ms.ToArray());
                document.Output.BindResource(outputFile, shape);
            }

            thumbnail.Dispose();
        }
        public static string ConvertPathToRelative(string toPath, string fromPath)
        {
            // fixing paths with no root by adding fake root drive letter
            if (!Path.IsPathRooted(toPath))
                toPath = @"C:\" + toPath;
            if (!Path.IsPathRooted(fromPath))
                fromPath = @"C:\" + fromPath;
            if (!fromPath.EndsWith("\\"))
                fromPath += "\\";

            Uri fromUri = new Uri(fromPath);
            Uri toUri = new Uri(toPath);

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);
            string result = Uri.UnescapeDataString(relativeUri.ToString()).Replace('\\', '/');
            return result;
        }

        public static List<T> GetListOfShapes<T>(IPresentation pres)
        {
            List<T> result = new List<T>();

            foreach (var slide in pres.Slides)
            {
                foreach(var item in slide.Shapes) if (item is T) result.Add((T)item);
            }
            
            foreach (var slide in pres.LayoutSlides)
            {
                foreach (var item in slide.Shapes) if (item is T) result.Add((T)item);
            }
            
            foreach (var slide in pres.Masters)
            {
                foreach (var item in slide.Shapes) if (item is T) result.Add((T)item);
            }

            return result;
        }

        public static string GetSubstitutionMarkup(string templateMarkup, IShape shape, Point origin, string animationAttributes)
        {
            return null;
        }
        public static string GetPositionStyle(Shape shape, Point origin)
        {
            int left = (int)shape.X + origin.X;
            int top = (int)shape.Y + origin.Y;
            int width = (int)shape.Width;
            int height = (int)shape.Height;

            if (shape is Connector && height == 0)
            {
                height = (int)(shape as Connector).LineFormat.Width;
            }
            return string.Format("left: {0}px; top: {1}px; width: {2}px; height: {3}px;", left, top, width, height);
        }
    }
}
