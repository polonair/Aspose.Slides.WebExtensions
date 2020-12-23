using System;
using Aspose.Slides;
using Aspose.Slides.Export.Web;
using Aspose.Slides.WebExtensions;

namespace SinglePageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new License().SetLicense(@"c:\bin\aspose\git\slides-net\src\test\bin\Debug\Aspose.Total.Product.Family.lic");

            using (Presentation pres = new Presentation("demo.pptx"))
            {
                WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page",
                    @"single-page-output");
                document.Save();
            }

            Console.WriteLine("HTML export is complete...");
        }
    }
}
