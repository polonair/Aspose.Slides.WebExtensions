using Aspose.Slides.Export.Web;
using Aspose.Slides.Export;
using NUnit.Framework;
using System.IO;

namespace Aspose.Slides.WebExtensions.Tests
{
    [TestFixture]
    public class SLIDESNET_43007 
    {
        [Test]
        public void TestSolidFillColorIssue()
        {
            var RootDirectory = Path.GetFullPath(Path.Combine(TestContext.CurrentContext.TestDirectory, "..", "..", ".."));
            var PresentationFilePath1 = Path.Combine(RootDirectory, "TestData", "SLIDESNET-43007-1.pptx");
            var PresentationFilePath2 = Path.Combine(RootDirectory, "TestData", "SLIDESNET-43007-2.pptx");
            var TemplatePath = Path.Combine(RootDirectory, "TestData", "Out", "templates");
            var OutputPath1 = Path.Combine(RootDirectory, "TestData", "Out", "SLIDESNET-43007-1");
            var OutputPath2 = Path.Combine(RootDirectory, "TestData", "Out", "SLIDESNET-43007-2");

            var sourcePath1 = Path.GetFullPath(Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "single-page"));
            var sourcePath2 = Path.GetFullPath(Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "common"));

            Directory.CreateDirectory(OutputPath1);
            Directory.CreateDirectory(OutputPath2);
            Directory.CreateDirectory(TemplatePath);

            foreach (string dirPath in Directory.GetDirectories(sourcePath1, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath1, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath1, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath1, TemplatePath), true);

            foreach (string dirPath in Directory.GetDirectories(sourcePath2, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath2, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath2, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath2, TemplatePath), true);

            Assert.DoesNotThrow(() =>
            {
                using (Presentation pres = new Presentation(PresentationFilePath1))
                {
                    WebDocument document = pres.ToSinglePageWebDocument(
                        new WebDocumentOptions { EmbedImages = true, AnimateShapes = true, AnimateTransitions = true },
                        TemplatePath,
                        OutputPath1);
                    document.Save();
                }
                using (Presentation pres = new Presentation(PresentationFilePath2))
                {
                    WebDocument document = pres.ToSinglePageWebDocument(
                        new WebDocumentOptions { EmbedImages = true, AnimateShapes = true, AnimateTransitions = true },
                        TemplatePath,
                        OutputPath2);
                    document.Save();
                }
            });
        }
    }
}