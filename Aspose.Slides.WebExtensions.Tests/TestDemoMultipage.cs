using Aspose.Slides;
using Aspose.Slides.Export.Web;
using Aspose.Slides.WebExtensions;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Aspose.Slides.WebExtensions.Tests
{
    [TestFixture]
    public class TestDemoMultipage
    {
        private class SlideDocument {
            public XmlDocument Document { get; set; }
            public XmlNamespaceManager NsManager { get; set; }
        }

        private string TemplatePath = null;
        private string PresentationFilePath = null;
        private string OutputPath = null;
        private string RootDirectory = null;
        private Dictionary<string, SlideDocument> SlideDocuments;

        [OneTimeSetUp]
        public void Setup()
        {
            RootDirectory = TestContext.CurrentContext.TestDirectory;
            PresentationFilePath = Path.Combine(RootDirectory, "TestData", "demo.pptx");
            TemplatePath = Path.Combine(RootDirectory, "templates", "multi-page");
            OutputPath = Path.Combine(RootDirectory, "multi-page-demo-output");

            using (Presentation pres = new Presentation(PresentationFilePath))
            {
                WebDocument multiPageDocument = pres.ToMultiPageWebDocument(TemplatePath, OutputPath);
                multiPageDocument.Save();
            }

            SlideDocuments = new Dictionary<string, SlideDocument>();

            List<string> filePaths = new List<string>();
            filePaths.Add("index.html");
            filePaths.Add("menu.html");
            for (int i = 1; i <= 9; i++)
            {
                filePaths.Add(string.Format("slides/slide{0}.html", i));
            }

            foreach (string filePath in filePaths)
            {
                string htmlPath = Path.Combine(OutputPath, filePath);
                string htmlContent = File.ReadAllText(htmlPath);
                htmlContent = FixVideoTag(htmlContent);
                SlideDocument slide = new SlideDocument();
                slide.Document = new XmlDocument();
                slide.Document.XmlResolver = null;
                slide.Document.LoadXml(htmlContent);
                slide.NsManager = new XmlNamespaceManager(slide.Document.NameTable);
                slide.NsManager.AddNamespace("html", "http://www.w3.org/1999/xhtml");
                SlideDocuments.Add(filePath, slide);
            }
        }
        static string FixVideoTag(string input)
        {
            input = Regex.Replace(input, "(<video[^>]+) controls>", "$1 controls=\"\">");
            input = Regex.Replace(input, "(<source[^>]+)>", "$1 />");
            return input;
        }

        [Test]
        public void TestPrevNavigationButtons()
        {
            for (int i = 1; i <= 9; i++)
            {
                string path = string.Format("slides/slide{0}.html", i);
                SlideDocument doc = SlideDocuments[path];
                XmlElement root = doc.Document.DocumentElement;

                XmlNode prevButtonNode = root.SelectSingleNode("//html:button[@id='PrevSlide']", doc.NsManager);
                Assert.NotNull(prevButtonNode, "'Previous Slide' button not found on slide no. {0}", i);
                string onclick = prevButtonNode.Attributes["onclick"].Value;
                if (i == 1)
                {
                    Assert.AreEqual("", onclick, "OnClick action for 'Previous Slide' button on first slide should be empty");
                }
                else
                {
                    string expected = string.Format("location.href='slide{0}.html';", i - 1);
                    Assert.AreEqual(expected, onclick, "OnClick action for 'Previous Slide' button on slide no. {0} should point to slide no. {1}", i, i-1);
                }
            }
        }

        [Test]
        public void TestNextNavigationButtons()
        {
            for (int i = 1; i <= 9; i++)
            {
                string path = string.Format("slides/slide{0}.html", i);
                SlideDocument doc = SlideDocuments[path];
                XmlElement root = doc.Document.DocumentElement;

                XmlNode nextButtonNode = root.SelectSingleNode("//html:button[@id='NextSlide']", doc.NsManager);
                Assert.NotNull(nextButtonNode, "'Next Slide' button not found on slide no. {0}", i);
                string onclick = nextButtonNode.Attributes["onclick"].Value;
                if (i == 9)
                {
                    Assert.AreEqual("", onclick, "OnClick action for 'Next Slide' button on last slide should be empty");
                }
                else
                {
                    string expected = string.Format("location.href='slide{0}.html';", i + 1);
                    Assert.AreEqual(expected, onclick, "OnClick action for 'Next Slide' button on slide no. {0} should point to slide no. {1}", i, i + 1);
                }
            }
        }
    }
}