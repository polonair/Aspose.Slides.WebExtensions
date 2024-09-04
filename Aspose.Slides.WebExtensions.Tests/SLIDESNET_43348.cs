using Aspose.Slides.Export.Web;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Aspose.Slides.WebExtensions.Tests
{
    [TestClass]
    public class SLIDESNET_43348
    {
        [TestMethod]
        public void Test_43348()
        {
            var RootDirectory = Path.GetFullPath("../../../");
            var PresentationFilePath = Path.Combine(RootDirectory, "TestData", "SLIDESNET-43348.ppt");
            var TemplatePath = Path.Combine(RootDirectory, "TestData", "Out", "templates");
            var OutputPath = Path.Combine(RootDirectory, "TestData", "Out", "SLIDESNET_43348");

            var sourcePath1 = Path.GetFullPath(Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "single-page"));
            var sourcePath2 = Path.GetFullPath(Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "common"));

            Directory.CreateDirectory(OutputPath);
            Directory.CreateDirectory(TemplatePath);

            foreach (string dirPath in Directory.GetDirectories(sourcePath1, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath1, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath1, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath1, TemplatePath), true);

            foreach (string dirPath in Directory.GetDirectories(sourcePath2, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath2, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath2, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath2, TemplatePath), true);

            try
            {
                string fileName = PresentationFilePath;
                using (Presentation pres = new Presentation())
                {
                    pres.Slides.RemoveAt(0);
                    using (Presentation source = new Presentation(fileName))
                    {
                        pres.Slides.AddClone(source.Slides[1]);

                        WebDocument document = pres.ToSinglePageWebDocument(
                            new WebDocumentOptions { EmbedImages = true, },
                            TemplatePath,
                            OutputPath);
                        document.Save();
                    }
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception thrown " + e.Message);
            }
        }
    }
}