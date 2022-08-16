using Aspose.Slides;
using Aspose.Slides.Export.Web;
using Aspose.Slides.WebExtensions;
using NUnit.Framework;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Aspose.Slides.WebExtensions.Tests
{
    [TestFixture]
    public class TestMultilevelBullets
    {
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
            PresentationFilePath = Path.Combine(RootDirectory, "TestData", "multilevel-bullets.pptx");
            TemplatePath = Path.Combine(RootDirectory, "templates", "single-page");
            OutputPath = Path.Combine(RootDirectory, "single-page-multilevel-bullets-animated-output");

            using (Presentation pres = new Presentation(PresentationFilePath))
            {
                WebDocumentOptions options = new WebDocumentOptions
                {
                    TemplateEngine = new RazorTemplateEngine(),
                    OutputSaver = new FileOutputSaver(),
                    AnimateTransitions = true
                };

                WebDocument document = pres.ToSinglePageWebDocument(options, TemplatePath, OutputPath);
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
        public void TestSvgDivPathsBlock()
        {
            XmlElement root = indexHtml.DocumentElement;
            XmlNode svg = root.SelectSingleNode("//html:div[@id='svgdivpaths']/html:svg", namespaceManager);

            Assert.IsNotNull(svg);
            string width = svg.Attributes["width"].Value;
            Assert.AreEqual("959.75", width);
            string height = svg.Attributes["height"].Value;
            Assert.AreEqual("540", height);
            string viewbox = svg.Attributes["viewBox"].Value;
            Assert.AreEqual("0 0 959.75 540", viewbox);
        }
        [Test]
        public void TestAnimationJs()
        {
            string animationsJsPath = Path.Combine(OutputPath, "animation.js");
            string animationsJsContent = File.ReadAllText(animationsJsPath);
            Assert.IsTrue(animationsJsContent.Contains("var frameWidth = 959.75;"));
            Assert.IsTrue(animationsJsContent.Contains("var frameHeight = 540;"));
        }
        [Test]
        public void TestPresCss()
        {
            string pressCssPath = Path.Combine(OutputPath, "pres.css");
            string presCssContent = File.ReadAllText(pressCssPath);
            string bgClassStyle = System.Text.RegularExpressions.Regex.Match(presCssContent, "\\.bg[^{]*\\{[^}]+\\}").Value;
            Assert.IsTrue(bgClassStyle.Contains("width: 979.75px;"));
            Assert.IsTrue(bgClassStyle.Contains("height: 560px;"));

            string slideClassStyle = System.Text.RegularExpressions.Regex.Match(presCssContent, "\\.slide[^{]*\\{[^}]+\\}").Value;
            Assert.IsTrue(slideClassStyle.Contains("width: 964.75px;"));
            Assert.IsTrue(slideClassStyle.Contains("height: 545px;"));
        }
    }
}