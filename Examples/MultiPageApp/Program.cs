using Aspose.Slides;
using Aspose.Slides.Export.Web;
using Aspose.Slides.WebExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ExportBySections();

            Console.WriteLine("HTML export is complete...");
        }

        static void ExportBySections()
        {
            using (Presentation pres = new Presentation("demo-transitions.pptx"))
            {
                const string templatesPath = "templates\\multi-page";
                const string outputPath = "multi-page-by-sections";

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

                // setup folder-by-section folders structure
                foreach (ISection section in pres.Sections)
                {
                    foreach (Slide slide in section.GetSlidesListOfSection())
                    {
                        if (slide.Hidden)
                            continue;

                        string path = Path.Combine(
                            outputPath, section.Name,
                            string.Format("slide{0}.html", slide.SlideNumber));

                        document.Output.Add(path, "slide", slide);
                    }
                }

                // setup rest of the document properties
                document.AddCommonInputOutput(options, templatesPath, outputPath, pres);

                document.AddMultiPageInputTemplates(templatesPath);
                document.Output.Add(Path.Combine(outputPath, "menu.html"), "menu", pres);

                if (!options.EmbedImages)
                {
                    document.AddThumbnailsOutput(document.Global.Get<string>("imagesPath"), pres);
                }

                document.Save();
            }
        }
    }
}
