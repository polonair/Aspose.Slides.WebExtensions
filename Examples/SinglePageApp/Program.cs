using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export.Web;
using Aspose.Slides.WebExtensions;

namespace SinglePageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ExportDefault();

            Console.WriteLine("HTML export is complete...");
        }

        static void ExportDefault()
        {
            using (Presentation pres = new Presentation("demo.pptx"))
            {
                WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
                document.Save();
            }
        }
        
        static void ExportDefaultAnimated()
        {
            using (Presentation pres = new Presentation("demo-transitions.pptx"))
            {
                WebDocumentOptions options = new WebDocumentOptions
                {
                    TemplateEngine = new RazorTemplateEngine(),  
                    OutputSaver = new FileOutputSaver(),
                    AnimateTransitions = true
                };
                
                WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", @"single-page-animated-output");
                
                document.Save();
            }
        }
        
        static void ExportHelloWorld()
        {
            using (Presentation pres = new Presentation())
            {
                IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
                shape.TextFrame.Text = "Hello World";
                
                WebDocumentOptions options = new WebDocumentOptions
                {
                    TemplateEngine = new RazorTemplateEngine(), // we will use Razor template engine, other template engines can be used by implementing ITemplateEngine  
                    OutputSaver = new FileOutputSaver() // other result savers can be used by implementing IOutputSaver interface
                };
                WebDocument document = new WebDocument(options);

                // add document "input" - what source will be used to generate HTML document
                document.Input
                    .AddTemplate<Presentation>( // template will have Presentation as a "model" object (Model.Object) 
                    "index", // template key - needed by template engine to match an object (Presentation) to the template loaded from disk ("shape-template-hello-world.html")  
                    @"custom-templates\\shape-template-hello-world.html");
                
                // add output - how resulting HTML document will looks like when it will be exported to the disk
                document.Output.Add(
                    "hello-world.html", // output file path
                    "index", // template key that will be used for this file (we set it in a previous statement)  
                    pres); // an actual Model.Object instance 
                
                document.Save();
            }
        }

        static void ExportHelloWorldWithStyles()
        {
            using (Presentation pres = new Presentation())
            {
                IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
                shape.TextFrame.Text = "Hello World";
                
                WebDocumentOptions options = new WebDocumentOptions { TemplateEngine = new RazorTemplateEngine(), OutputSaver = new FileOutputSaver() };
                WebDocument document = new WebDocument(options);

                document.Input.AddTemplate<Presentation>("index", @"custom-templates\shape-template-hello-world.html");
                document.Input.AddTemplate<Presentation>("styles", @"custom-templates\styles\shape-template-hello-world.css");
                document.Output.Add("hello-world.html", "index", pres); 
                document.Output.Add("hello-world.css", "styles", pres);
                
                document.Save();
            }
        }

        static void ExportCustomTableStyles()
        {
            using (Presentation pres = new Presentation("table.pptx"))
            {
                const string templatesPath = "templates\\single-page";
                const string outputPath = "custom-table-styles";
                
                var options = new WebDocumentOptions
                {
                    TemplateEngine = new RazorTemplateEngine(),
                    OutputSaver = new FileOutputSaver(),
                    EmbedImages = false
                };

                // setup global document values
                WebDocument document = new WebDocument(options);
                PresentationExtensions.SetGlobals(document, options, outputPath);
                string slidesPath = Path.Combine(outputPath, "slides");
                string stylesPath = Path.Combine(outputPath, "styles");
                string scriptsPath = Path.Combine(outputPath, "scripts");

                document.Global.Put("slidesPath", slidesPath);
                document.Global.Put("stylesPath", stylesPath);
                document.Global.Put("scriptsPath", scriptsPath);

                // add common structure (except table template)
                ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath);
                
                // add custom table template
                document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
                // add custom table styles
                document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
                document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
                // add custom index - it's just a copy of the standard "index.html", but includes a reference to "table-custom-style.css"
                document.Input.AddTemplate<Presentation>("index", @"custom-templates\index-table-custom-style.html");
                
                document.Save();
            }
        }

        private static void ExportCustomTableStyles_AddCommonStructure(Presentation pres, WebDocument document,
            string templatesPath, string outputPath)
        {
            string stylesPath = document.Global.Get<string>("stylesPath");
            string scriptsPath = document.Global.Get<string>("scriptsPath");
            
            document.Input.AddTemplate<Presentation>("styles-pres", Path.Combine(templatesPath, @"styles\pres.css"));
            document.Input.AddTemplate<MasterSlide>("styles-master", Path.Combine(templatesPath, @"styles\master.css"));
            document.Input.AddTemplate<Presentation>("scripts-animation",
                Path.Combine(templatesPath, @"scripts\animation.js"));

            document.Input.AddTemplate<Slide>("slide", Path.Combine(templatesPath, "slide.html"));
            document.Input.AddTemplate<AutoShape>("autoshape", Path.Combine(templatesPath, "autoshape.html"));
            document.Input.AddTemplate<TextFrame>("textframe", Path.Combine(templatesPath, "textframe.html"));
            document.Input.AddTemplate<Paragraph>("paragraph", Path.Combine(templatesPath, "paragraph.html"));
            document.Input.AddTemplate<Paragraph>("bullet", Path.Combine(templatesPath, "bullet.html"));
            document.Input.AddTemplate<Portion>("portion", Path.Combine(templatesPath, "portion.html"));

            document.Input.AddTemplate<VideoFrame>("videoframe", Path.Combine(templatesPath, "videoframe.html"));

            document.Input.AddTemplate<PictureFrame>("pictureframe", Path.Combine(templatesPath, "pictureframe.html")); ;
            document.Input.AddTemplate<Shape>("shape", Path.Combine(templatesPath, "shape.html"));

            document.Output.Add(Path.Combine(outputPath, "index.html"), "index", pres);
            document.Output.Add(Path.Combine(stylesPath, "pres.css"), "styles-pres", pres);
            document.Output.Add(Path.Combine(stylesPath, "master.css"), "styles-master", (MasterSlide) pres.Masters[0]);
            document.Output.Add(Path.Combine(scriptsPath, "animation.js"), "scripts-animation", pres);

            document.AddEmbeddedFontsOutput(document.Global.Get<string>("fontsPath"), pres);
            document.AddVideoOutput(document.Global.Get<string>("mediaPath"), pres);
            document.AddScriptsOutput(scriptsPath, Path.Combine(templatesPath, @"scripts\jquery-3.5.1.min.js"), "jquery.js");
            document.AddScriptsOutput(scriptsPath, Path.Combine(templatesPath, @"scripts\anime.min.js"), "anime.js");
        }
    }
}
