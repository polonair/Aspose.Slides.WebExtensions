using Aspose.Slides;
using Aspose.Slides.Export.Web;
using Aspose.Slides.WebExtensions;
using NUnit.Framework;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Aspose.Slides.WebExtensions.Tests
{
    [TestFixture]
    public class TestArtificial
    {
        public class SlideTestCase
        {
            public int Number { get; }
            public string ImageFileName { get; }

            public SlideTestCase(int number, string imageFileName)
            {
                this.Number = number;
                this.ImageFileName = imageFileName;
            }
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new SlideTestCase(1, "image0.jpeg");
                    yield return new SlideTestCase(2, "image3.jpeg");
                    yield return new SlideTestCase(3, "image2.jpeg");
                    yield return new SlideTestCase(4, "image3.jpeg");
                    yield return new SlideTestCase(5, "image3.jpeg");
                }
            }
            public override string ToString()
            {
                return string.Format("#{0}, FileName='{1}'", Number, ImageFileName);
            }
        }

        private string TemplatePath = null;
        private string PresentationFilePath = null;
        private string OutputPath = null;
        private string RootDirectory = null;
        private XmlDocument indexHtml;
        private XmlNamespaceManager namespaceManager;

        [OneTimeSetUp]
        public void Setup()
        {
            RootDirectory = TestContext.CurrentContext.TestDirectory;
            PresentationFilePath = Path.Combine(RootDirectory, "TestData", "artificial.pptx");
            TemplatePath = Path.Combine(RootDirectory, "templates", "single-page");
            OutputPath = Path.Combine(RootDirectory, "single-page-artificial-output");

            using (Presentation pres = new Presentation(PresentationFilePath))
            {
                WebDocument document = pres.ToSinglePageWebDocument(TemplatePath, OutputPath);
                document.Save();
            }

            string indexHtmlPath = Path.Combine(OutputPath, "index.html");
            string indexHtmlContent = File.ReadAllText(indexHtmlPath);
            indexHtml = new XmlDocument();
            indexHtml.XmlResolver = null;
            indexHtml.LoadXml(indexHtmlContent);
            namespaceManager = new XmlNamespaceManager(indexHtml.NameTable);
            namespaceManager.AddNamespace("html", "http://www.w3.org/1999/xhtml");
        }
        [Test, TestCaseSource(typeof(SlideTestCase), "TestCases")]
        public void TestSlidesBackground(SlideTestCase slideTestCase)
        {
            XmlElement root = indexHtml.DocumentElement;
            string slideXPath = string.Format("//html:div[@id='slide-{0}']", slideTestCase.Number);
            XmlNode slide = root.SelectSingleNode(slideXPath, namespaceManager);

            string style = slide.Attributes["style"].Value;
            string expected = string.Format("background-image: url('images/{0}');", slideTestCase.ImageFileName);
            Assert.IsTrue(style.Contains(expected), "First slide should have background image {0}", slideTestCase.ImageFileName);
            Assert.IsTrue(style.Contains("background-size: cover;"));
        }
    }
}