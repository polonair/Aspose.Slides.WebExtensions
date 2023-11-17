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
        public class ShapePosition
        {
            public string SlideId { get; set; }
            public string ShapeId { get; set; }
            public int Top { get; set; }
            public int Left { get; set; }
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new ShapePosition() { SlideId = "slide-1", ShapeId = "slide-2147483648-shape-0", Left = 0, Top = 410 };
                    yield return new ShapePosition() { SlideId = "slide-1", ShapeId = "slide-256-shape-1", Left = 37, Top = 149 };
                    yield return new ShapePosition() { SlideId = "slide-1", ShapeId = "slide-256-shape-2", Left = 36, Top = 295 };
                    yield return new ShapePosition() { SlideId = "slide-2", ShapeId = "slide-2147483648-shape-0", Left = 0, Top = 410 };
                    yield return new ShapePosition() { SlideId = "slide-2", ShapeId = "slide-257-shape-3", Left = 37, Top = 17 };
                    yield return new ShapePosition() { SlideId = "slide-2", ShapeId = "slide-257-shape-4", Left = 36, Top = 103 };
                    yield return new ShapePosition() { SlideId = "slide-3", ShapeId = "slide-2147483648-shape-0", Left = 0, Top = 410 };
                    yield return new ShapePosition() { SlideId = "slide-3", ShapeId = "slide-259-shape-5", Left = 188, Top = 32 };
                    yield return new ShapePosition() { SlideId = "slide-3", ShapeId = "slide-259-shape-6", Left = 188, Top = 99 };
                    yield return new ShapePosition() { SlideId = "slide-4", ShapeId = "slide-2147483648-shape-0", Left = 0, Top = 410 };
                    yield return new ShapePosition() { SlideId = "slide-4", ShapeId = "slide-258-shape-7", Left = 41, Top = 21 };
                    yield return new ShapePosition() { SlideId = "slide-4", ShapeId = "slide-258-shape-8", Left = 41, Top = 130 };
                    yield return new ShapePosition() { SlideId = "slide-4", ShapeId = "slide-258-shape-9", Left = 41, Top = 167 };
                    yield return new ShapePosition() { SlideId = "slide-4", ShapeId = "slide-258-shape-10", Left = 358, Top = 130 };
                    yield return new ShapePosition() { SlideId = "slide-4", ShapeId = "slide-258-shape-11", Left = 358, Top = 167 };
                    yield return new ShapePosition() { SlideId = "slide-5", ShapeId = "slide-2147483648-shape-0", Left = 0, Top = 410 };
                }
            }
            public override string ToString()
            {
                return string.Format("Slide='{0}', Id='{1}', Left={2}, Top={3}", SlideId, ShapeId, Left, Top);
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
        [Test]
        public void TestPresCss()
        {
            string pressCssPath = Path.Combine(OutputPath, "pres.css");
            string presCssContent = File.ReadAllText(pressCssPath);
            Match slideMatch = System.Text.RegularExpressions.Regex.Match(presCssContent, "\\.slide[^{]*\\{[^}]+\\}");
            Assert.IsTrue(slideMatch.Success, ".slide not found in pres.css");
            string slideClassStyle = slideMatch.Value;
            Assert.IsTrue(slideClassStyle.Contains("position: relative;"), ".slide in pres.css should have property position equals to relative");
        }
        [Test, TestCaseSource(typeof(ShapePosition), "TestCases")]
        public void TestShapePosition(ShapePosition shapePosition)
        {
            XmlElement root = indexHtml.DocumentElement;
            string shapeXPath = string.Format("//html:div[@id='{0}']/html:div[@id='{1}']", shapePosition.SlideId, shapePosition.ShapeId);
            XmlNode shapeNode = root.SelectSingleNode(shapeXPath, namespaceManager);

            Assert.NotNull(shapeNode, "Shape '{0}' at slide '{1}' not found", shapePosition.ShapeId, shapePosition.SlideId);
            string style = shapeNode.Attributes["style"].Value;
            string left = string.Format("left: {0}px;", shapePosition.Left);
            Assert.IsTrue(style.Contains(left), "Wrong left css property for shape '{0}' at slide '{1}'", shapePosition.ShapeId, shapePosition.SlideId);
            string top = string.Format("top: {0}px;", shapePosition.Top);
            Assert.IsTrue(style.Contains(top), "Wrong top css property for shape '{0}' at slide '{1}'", shapePosition.ShapeId, shapePosition.SlideId);
        }        
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