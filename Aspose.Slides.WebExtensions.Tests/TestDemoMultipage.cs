using Aspose.Slides;
using Aspose.Slides.Export.Web;
using Aspose.Slides.WebExtensions;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Aspose.Slides.WebExtensions.Tests
{
    [TestFixture]
    public class TestDemoMultipage
    {
        public class SlideDocument
        {
            public XmlDocument Document { get; }
            public XmlNamespaceManager NsManager { get; }
            public int SlideNumber { get; }
            public string SlidePath { get; }
            public static IEnumerable TestCases
            {
                get
                {
                    for (int i = 1; i <= 9; i++)
                    {
                        yield return new SlideDocument(i);
                    }
                }
            }

            public SlideDocument(int slideNumber)
            {
                string RootDirectory = TestContext.CurrentContext.TestDirectory;
                string OutputPath = Path.Combine(RootDirectory, "multi-page-demo-output");

                SlidePath = Path.Combine(OutputPath, string.Format("slides/slide{0}.html", slideNumber));
                Assert.IsTrue(File.Exists(SlidePath));
                string htmlContent = File.ReadAllText(this.SlidePath);                
                htmlContent = FixVideoTag(htmlContent);

                Document = new XmlDocument();
                Document.XmlResolver = null;
                Document.LoadXml(htmlContent);
                NsManager = new XmlNamespaceManager(this.Document.NameTable);
                NsManager.AddNamespace("html", "http://www.w3.org/1999/xhtml");
                SlideNumber = slideNumber;
            }
            public override string ToString()
            {
                return string.Format("Slide no. {0}, from '{1}'", SlideNumber, SlidePath);
            }
        }

        private string TemplatePath = null;
        private string PresentationFilePath = null;
        private string OutputPath = null;
        private string RootDirectory = null;

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
        }
        static string FixVideoTag(string input)
        {
            input = Regex.Replace(input, "(<video[^>]+) controls>", "$1 controls=\"\">");
            input = Regex.Replace(input, "(<source[^>]+)>", "$1 />");
            return input;
        }

        [Test, TestCaseSource(typeof(SlideDocument), "TestCases")]
        public void TestPrevNavigationButtons(SlideDocument doc)
        {
            XmlElement root = doc.Document.DocumentElement;

            XmlNode prevButtonNode = root.SelectSingleNode("//html:button[@id='PrevSlide']", doc.NsManager);
            Assert.NotNull(prevButtonNode, "'Previous Slide' button not found on slide no. {0}", doc.SlideNumber);
            string onclick = prevButtonNode.Attributes["onclick"].Value;
            if (doc.SlideNumber == 1)
            {
                Assert.AreEqual("", onclick, "OnClick action for 'Previous Slide' button on first slide should be empty");
            }
            else
            {
                string expected = string.Format("location.href='slide{0}.html';", doc.SlideNumber - 1);
                Assert.AreEqual(expected, onclick, "OnClick action for 'Previous Slide' button on slide no. {0} should point to slide no. {1}", doc.SlideNumber, doc.SlideNumber - 1);
            }
        }

        [Test, TestCaseSource(typeof(SlideDocument), "TestCases")]
        public void TestNextNavigationButtons(SlideDocument doc)
        {
            XmlElement root = doc.Document.DocumentElement;

            XmlNode nextButtonNode = root.SelectSingleNode("//html:button[@id='NextSlide']", doc.NsManager);
            Assert.NotNull(nextButtonNode, "'Next Slide' button not found on slide no. {0}", doc.SlideNumber);
            string onclick = nextButtonNode.Attributes["onclick"].Value;
            if (doc.SlideNumber == 9)
            {
                Assert.AreEqual("", onclick, "OnClick action for 'Next Slide' button on last slide should be empty");
            }
            else
            {
                string expected = string.Format("location.href='slide{0}.html';", doc.SlideNumber + 1);
                Assert.AreEqual(expected, onclick, "OnClick action for 'Next Slide' button on slide no. {0} should point to slide no. {1}", doc.SlideNumber, doc.SlideNumber + 1);
            }
        }
    }
}