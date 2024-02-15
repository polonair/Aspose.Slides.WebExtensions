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
    public class TestHtml5Issues
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
            PresentationFilePath = Path.Combine(RootDirectory, "TestData", "html5issues.pptx");
            TemplatePath = Path.Combine(RootDirectory, "templates", "single-page");
            OutputPath = Path.Combine(RootDirectory, "single-page-html5issues-output");

            using (Presentation pres = new Presentation(PresentationFilePath))
            {
                WebDocument document = pres.ToSinglePageWebDocument(new WebDocumentOptions() { EmbedImages = true }, TemplatePath, OutputPath);
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
        public void TestComplexScriptFont()
        {
            XmlElement root = indexHtml.DocumentElement;
            XmlNode span = root.SelectSingleNode("//html:div[@id='slide-277-shape-1']/html:div/html:p/html:span", namespaceManager);

            Assert.IsNotNull(span, "Target portion span not found");
            string style = span.Attributes["style"].Value;
            Assert.IsTrue(style.Contains("font-family: 'Arial';"), "Wrong font set for target portion span");
        }
    }
}