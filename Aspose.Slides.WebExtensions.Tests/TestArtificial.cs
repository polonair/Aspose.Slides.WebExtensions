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
    public class TestArtificial
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
        public void TestSlidesBackground()
        {
            XmlElement root = indexHtml.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//html:div[@class='slide master-bg']", namespaceManager);

            Assert.AreEqual(5, nodes.Count, "Document should contain 5 slides");

            string id = nodes[0].Attributes["id"].Value;
            Assert.AreEqual("slide-1", id);
            string style = nodes[0].Attributes["style"].Value;
            Assert.IsTrue(style.Contains("background-image: url('images/image0.jpeg');"), "First slide should have background image image0.jpeg");
            Assert.IsTrue(style.Contains("background-size: cover;"));

            id = nodes[1].Attributes["id"].Value;
            Assert.AreEqual("slide-2", id);
            style = nodes[1].Attributes["style"].Value;
            Assert.IsTrue(style.Contains("background-image: url('images/image3.jpeg');"), "Second slide should have background image image3.jpeg");
            Assert.IsTrue(style.Contains("background-size: cover;"));

            id = nodes[2].Attributes["id"].Value;
            Assert.AreEqual("slide-3", id);
            style = nodes[2].Attributes["style"].Value;
            Assert.IsTrue(style.Contains("background-image: url('images/image2.jpeg');"), "Third slide should have background image image2.jpeg");
            Assert.IsTrue(style.Contains("background-size: cover;"));

            id = nodes[3].Attributes["id"].Value;
            Assert.AreEqual("slide-4", id);
            style = nodes[3].Attributes["style"].Value;
            Assert.IsTrue(style.Contains("background-image: url('images/image3.jpeg');"), "Fourth slide should have background image image3.jpeg");
            Assert.IsTrue(style.Contains("background-size: cover;"));

            id = nodes[4].Attributes["id"].Value;
            Assert.AreEqual("slide-5", id);
            style = nodes[4].Attributes["style"].Value;
            Assert.IsTrue(style.Contains("background-image: url('images/image3.jpeg');"), "Fifth slide should have background image image3.jpeg");
            Assert.IsTrue(style.Contains("background-size: cover;"));
        }
    }
}