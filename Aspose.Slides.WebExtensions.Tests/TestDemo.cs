using Aspose.Slides;
using Aspose.Slides.Export.Web;
using Aspose.Slides.WebExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Aspose.Slides.WebExtensions.Tests
{
    [TestClass]
    public class TestDemo
    {
        private static string TemplatePath = null;
        private static string PresentationFilePath = null;
        private static string OutputPath = null;
        private static string RootDirectory = null;
        private static XmlDocument indexHtml;
        private static XmlNamespaceManager namespaceManager;

        //[ClassInitialize]
        static TestDemo()
        {
            RootDirectory = Path.GetFullPath(".");
            PresentationFilePath = Path.Combine(RootDirectory, "TestData", "demo.pptx");
            TemplatePath = Path.Combine(RootDirectory, "templates", "single-page");
            OutputPath = Path.Combine(RootDirectory, "single-page-demo-output");

            using (Presentation pres = new Presentation(PresentationFilePath))
            {
                WebDocument document = pres.ToSinglePageWebDocument(TemplatePath, OutputPath);
                document.Save();
            }

            string indexHtmlPath = Path.Combine(OutputPath, "index.html");
            string indexHtmlContent = File.ReadAllText(indexHtmlPath);
            indexHtmlContent = FixVideoTag(indexHtmlContent);
            indexHtml = new XmlDocument();
            indexHtml.XmlResolver = null;
            indexHtml.LoadXml(indexHtmlContent);
            namespaceManager = new XmlNamespaceManager(indexHtml.NameTable);
            namespaceManager.AddNamespace("html", "http://www.w3.org/1999/xhtml");
        }
        static string FixVideoTag(string input)
        {
            input = Regex.Replace(input, "(<video[^>]+) controls>", "$1 controls=\"\">");
            input = Regex.Replace(input, "(<source[^>]+)>", "$1 />");
            return input;
        }

        [TestMethod]
        public void TestHeadlineConnector()
        {
            XmlElement root = indexHtml.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//html:div[@id='slide-2147483660-shape-1']", namespaceManager);

            Assert.AreEqual(9, nodes.Count);
            foreach(XmlNode node in nodes)
            {
                string style = node.Attributes["style"].Value;
                Assert.IsTrue(style.Contains("height: 2px"), "Headline connector's div block should be 2px high");
            }
        }
        [TestMethod]
        public void TestLinkTextColor()
        {
            XmlElement root = indexHtml.DocumentElement;
            XmlNodeList links = root.SelectNodes("//html:div[@id='slide-282-shape-77']/html:div/html:p/html:a/html:span", namespaceManager);

            Assert.AreEqual(3, links.Count);
            foreach (XmlNode node in links)
            {
                string style = node.Attributes["style"].Value;
                Assert.IsTrue(style.Contains("color: rgba(5, 99, 193, 1);"), "Link text color should be 'rgba(5, 99, 193, 1)'");
                Assert.IsTrue(style.Contains("text-decoration: underline solid rgba(5, 99, 193, 1);"), "Link text decoration should be 'underline solid rgba(5, 99, 193, 1)'");
            }
        }
    }
}