﻿// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides.Export.Web;
using HeyRed.Mime;
using System.Drawing;
using Aspose.Slides.Charts;
using Aspose.Slides.WebExtensions.Helpers;

namespace Aspose.Slides.WebExtensions
{
    public static class PresentationExtensions
    {
        public static WebDocument ToSinglePageWebDocument(
            this Presentation pres,
            string templatesPath,
            string outputPath)
        {
            var options = new WebDocumentOptions
            {
                TemplateEngine = new RazorTemplateEngine(),
                OutputSaver = new FileOutputSaver(),
                EmbedImages = false
            };

            return ToSinglePageWebDocument(pres, options, templatesPath, outputPath);
        }

        public static WebDocument ToMultiPageWebDocument(
            this Presentation pres,
            string templatesPath,
            string outputPath)
        {
            var options = new WebDocumentOptions
            {
                TemplateEngine = new RazorTemplateEngine(),
                OutputSaver = new FileOutputSaver(),
                EmbedImages = false
            };

            return ToMultiPageWebDocument(pres, options, templatesPath, outputPath);
        }

        public static void SetGlobals(WebDocument document, WebDocumentOptions options, string outputPath)
        {
            string imagesPath = Path.Combine(outputPath, "images");
            string fontsPath = Path.Combine(outputPath, "fonts");
            string mediaPath = Path.Combine(outputPath, "media");

            document.Global.Put("slideMargin", 10);
            document.Global.Put("embedImages", options.EmbedImages);
            document.Global.Put("imagesPath", imagesPath);
            document.Global.Put("fontsPath", fontsPath);
            document.Global.Put("mediaPath", mediaPath);
        }

        public static WebDocument ToSinglePageWebDocument(
            this Presentation pres,
            WebDocumentOptions options,
            string templatesPath,
            string outputPath)
        {
            CheckArguments(options, templatesPath, outputPath);


            WebDocument document = new WebDocument(options);

            SetGlobals(document, options, outputPath);
            document.Global.Put("slidesPath", outputPath);
            document.Global.Put("stylesPath", outputPath);

            document.AddCommonInputOutput(options, templatesPath, outputPath, pres);

            return document;
        }

        public static WebDocument ToMultiPageWebDocument(
            this Presentation pres,
            WebDocumentOptions options,
            string templatesPath,
            string outputPath)
        {
            CheckArguments(options, templatesPath, outputPath);

            WebDocument document = new WebDocument(options);

            SetGlobals(document, options, outputPath);

            document.AddCommonInputOutput(options, templatesPath, outputPath, pres);

            string slidesPath = Path.Combine(outputPath, "slides");
            string stylesPath = Path.Combine(outputPath, "styles");

            document.Global.Put("slidesPath", slidesPath);
            document.Global.Put("stylesPath", stylesPath);

            document.AddMultiPageInputTemplates(templatesPath);
            document.AddMultiPageOutputFiles(slidesPath, pres);

            if (!options.EmbedImages)
            {
                document.AddThumbnailsOutput(document.Global.Get<string>("imagesPath"), pres);
            }

            return document;
        }

        private static void CheckArguments(WebDocumentOptions options, string templatesPath, string outputPath)
        {
            if (options == null)
                throw new ArgumentNullException("options");

            if (templatesPath == null)
                throw new ArgumentNullException("templatesPath");

            if (!Directory.Exists(templatesPath))
                throw new ArgumentException("Specified templates path doesn't exist.", "templatesPath");

            if (options.TemplateEngine == null)
                options.TemplateEngine = new RazorTemplateEngine();

            if (options.OutputSaver == null)
                options.OutputSaver = new FileOutputSaver();
        }

        private static void AddCommonInputOutput(this WebDocument document, WebDocumentOptions options, string templatesPath, string outputPath, Presentation pres)
        {
            string stylesPath = document.Global.Get<string>("stylesPath");

            document.Input.AddTemplate<Presentation>("styles-pres", Path.Combine(templatesPath, @"styles\pres.css"));
            document.Input.AddTemplate<MasterSlide>("styles-master", Path.Combine(templatesPath, @"styles\master.css"));

            document.Input.AddTemplate<Presentation>("index", Path.Combine(templatesPath, "index.html"));
            document.Input.AddTemplate<Slide>("slide", Path.Combine(templatesPath, "slide.html"));
            document.Input.AddTemplate<AutoShape>("autoshape", Path.Combine(templatesPath, "autoshape.html"));
            document.Input.AddTemplate<TextFrame>("textframe", Path.Combine(templatesPath, "textframe.html"));
            document.Input.AddTemplate<Paragraph>("paragraph", Path.Combine(templatesPath, "paragraph.html"));
            document.Input.AddTemplate<Paragraph>("bullet", Path.Combine(templatesPath, "bullet.html"));
            document.Input.AddTemplate<Portion>("portion", Path.Combine(templatesPath, "portion.html"));

            document.Input.AddTemplate<VideoFrame>("videoframe", Path.Combine(templatesPath, "videoframe.html"));

            document.Input.AddTemplate<PictureFrame>("pictureframe", Path.Combine(templatesPath, "pictureframe.html"));
            document.Input.AddTemplate<Table>("table", Path.Combine(templatesPath, "table.html"));
            document.Input.AddTemplate<Shape>("shape", Path.Combine(templatesPath, "shape.html"));

            document.Output.Add(Path.Combine(outputPath, "index.html"), "index", pres);
            document.Output.Add(Path.Combine(stylesPath, "pres.css"), "styles-pres", pres);
            document.Output.Add(Path.Combine(stylesPath, "master.css"), "styles-master", (MasterSlide)pres.Masters[0]);

            document.AddEmbeddedFontsOutput(document.Global.Get<string>("fontsPath"), pres);
            document.AddVideoOutput(document.Global.Get<string>("mediaPath"), pres);

            if (!options.EmbedImages)
            {
                string imagesPath = document.Global.Get<string>("imagesPath");
                document.AddImagesOutput(imagesPath, pres);
                document.AddShapeAsImagesOutput<Chart>(imagesPath, pres);
                document.AddShapeAsImagesOutput<SmartArt.SmartArt>(imagesPath, pres);
                document.AddShapeAsImagesOutput<AutoShape>(imagesPath, pres);
                document.AddShapeAsImagesOutput<Connector>(imagesPath, pres);
            }
        }

        private static void AddMultiPageInputTemplates(this WebDocument document, string templatesPath)
        {
            document.Input.AddTemplate<Presentation>("menu", Path.Combine(templatesPath, "menu.html"));
        }

        private static void AddMultiPageOutputFiles(this WebDocument document, string outputPath, Presentation pres)
        {
            document.Output.Add(Path.Combine(outputPath, "menu.html"), "menu", pres);

            foreach (Slide slide in pres.Slides)
            {
                if (slide.Hidden)
                    continue;

                document.Output.Add(Path.Combine(outputPath, string.Format("slide{0}.html", slide.SlideNumber)), "slide", slide);
            }
        }

        private static void AddImagesOutput(this WebDocument document, string outputPath, Presentation pres)
        {
            for (int index = 0; index < pres.Images.Count; index++)
            {
                IPPImage image = pres.Images[index];
                string path;
                string ext;

                if (image.ContentType == "image/x-emf"
                    || image.ContentType == "image/x-wmf") //save metafile as PNG to make it supported by various browsers  
                {
                    ext = "png";
                    path = Path.Combine(outputPath, string.Format("image{0}.{1}", index, ext));

                    var bitmap = ImageHelper.MetafileToBitmap(image);
                    document.Output.Add(path, new ThumbnailOutputFile(bitmap), image);

                    continue;
                }

                ext = MimeTypesMap.GetExtension(image.ContentType);
                path = Path.Combine(outputPath, string.Format("image{0}.{1}", index, ext));

                document.Output.Add(path, image);
            }
        }

        private static void AddThumbnailsOutput(this WebDocument document, string outputPath, Presentation pres)
        {
            for (int index = 1; index <= pres.Slides.Count; index++)
            {
                Slide slide = pres.Slides[index - 1] as Slide;
                Bitmap thumbnail = slide.GetThumbnail();

                string path = Path.Combine(outputPath, string.Format("thumbnail{0}.png", index));

                document.Output.Add(path, new ThumbnailOutputFile(thumbnail));
            }
        }


        private static void AddShapeAsImagesOutput<T>(this WebDocument document, string outputPath, Presentation pres)
        {
            List<T> shapes = ShapeHelper.GetListOfShapes<T>(pres);

            uint counter = 0;

            Bitmap thumbnail;

            foreach (var shape in shapes)
            {
                if (shape is AutoShape)
                {
                    //skip ShapeType.Rectangle and ShapeType.NotDefined because there is specific template for these types
                    if ((shape as AutoShape).ShapeType == ShapeType.Rectangle
                        || (shape as AutoShape).ShapeType == ShapeType.NotDefined)
                        continue;
                }

                //Make shape clone -> remove text from the clone -> get image of the clone -> remove the clone. Export text as HTML markup in the template. 
                if (shape is AutoShape && !string.IsNullOrEmpty((shape as AutoShape).TextFrame.Text))
                {
                    IShape clone = pres.Slides[0].Shapes.AddClone(shape as AutoShape);

                    try
                    {
                        (clone as AutoShape).TextFrame.Paragraphs.Clear();
                        thumbnail = clone.GetThumbnail();
                    }
                    finally
                    {
                        pres.Slides[0].Shapes.Remove(clone);
                    }
                }
                else
                {
                    thumbnail = (shape as Shape).GetThumbnail();
                }

                string path = Path.Combine(outputPath, string.Format("{0}{1}.png", typeof(T).Name.ToLower(), counter++));

                document.Output.Add(path, new ThumbnailOutputFile(thumbnail), shape);


            }
        }

        private static void AddEmbeddedFontsOutput(this WebDocument document, string outFontsFolder, Presentation pres)
        {
            IFontData[] embeddedFonts = pres.FontsManager.GetEmbeddedFonts();

            for (int i = 0; i < embeddedFonts.Length; i++)
            {
                string fontFileName = Path.Combine(outFontsFolder, string.Format("{0}.ttf", embeddedFonts[i].FontName));
                document.Output.Add(fontFileName, embeddedFonts[i], FontStyle.Regular);

                //fontFileName = Path.Combine(outFontsFolder, string.Format("{0} {1}.ttf", embeddedFonts[i].FontName, FontStyle.Italic.ToString()));
                //document.Output.Add(fontFileName, embeddedFonts[i], FontStyle.Italic);

                //fontFileName = Path.Combine(outFontsFolder, string.Format("{0} {1}.ttf", embeddedFonts[i].FontName, FontStyle.Bold.ToString()));
                //document.Output.Add(fontFileName, embeddedFonts[i], FontStyle.Bold);
            }
        }

        private static void AddVideoOutput(this WebDocument document, string outputPath, Presentation pres)
        {
            List<VideoFrame> videoFrames = ShapeHelper.GetListOfShapes<VideoFrame>(pres);

            for (int i = 0; i < videoFrames.Count; i++)
            {
                IVideo video = videoFrames[i].EmbeddedVideo;
                string ext = MimeTypesMap.GetExtension(videoFrames[i].EmbeddedVideo.ContentType);
                string path = Path.Combine(outputPath, string.Format("video{0}.{1}", i, ext));

                document.Output.Add(path, video);
            }
        }

    }
}