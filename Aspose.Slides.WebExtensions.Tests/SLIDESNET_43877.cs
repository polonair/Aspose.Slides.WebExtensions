using Aspose.Slides.Export.Web;
using NUnit.Framework;
using System;
using System.Linq;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Aspose.Slides.WebExtensions.Tests
{
    [TestFixture]
    public class SLIDESNET_43877
    {
        [OneTimeSetUp]
        public void Setup()
        {
        }
        [Test]
        public void Test_Demo_Transitions()
        {
            var projectPath = "c:\\ASPOSE\\Aspose.Slides.WebExtensions\\Aspose.Slides.WebExtensions.Tests\\";
            var RootDirectory = projectPath;
            var PresentationFilePath = Path.Combine(RootDirectory, "TestData", "SLIDESNET_43877", "demo-transitions.pptx");
            var EthalonPath = Path.Combine(RootDirectory, "TestData", "SLIDESNET_43877", "demo-transitions");
            var TemplatePath = Path.Combine(RootDirectory, "TestData", "Out", "templates");
            var OutputPath = Path.Combine(RootDirectory, "TestData", "Out", "SLIDESNET_43877", "demo-transitions");

            var sourcePath1 = Path.GetFullPath( Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "single-page"));
            var sourcePath2 = Path.GetFullPath( Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "common"));

            Directory.CreateDirectory(OutputPath);
            Directory.CreateDirectory(TemplatePath);

            foreach (string dirPath in Directory.GetDirectories(sourcePath1, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath1, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath1, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath1, TemplatePath), true);

            foreach (string dirPath in Directory.GetDirectories(sourcePath2, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath2, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath2, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath2, TemplatePath), true);

            using (Presentation pres = new Presentation(PresentationFilePath))
            {
                WebDocumentOptions options = new WebDocumentOptions
                {
                    EmbedImages = true
                };
                WebDocument document = pres.ToSinglePageWebDocument(options, TemplatePath, OutputPath);
                document.Save();
            }

            CompareDir(EthalonPath, OutputPath, _ => Regex.Replace(_, "<div class=\"shape\" id=\"slide-280-shape-39\" [^>]+>", ""));
        }


        [Test]
        public void Test_Html5issues()
        {
            var projectPath = "c:\\ASPOSE\\Aspose.Slides.WebExtensions\\Aspose.Slides.WebExtensions.Tests\\";
            var RootDirectory = projectPath;
            var PresentationFilePath = Path.Combine(RootDirectory, "TestData", "SLIDESNET_43877", "html5issues.pptx");
            var EthalonPath = Path.Combine(RootDirectory, "TestData", "SLIDESNET_43877", "html5issues");
            var TemplatePath = Path.Combine(RootDirectory, "TestData", "Out", "templates");
            var OutputPath = Path.Combine(RootDirectory, "TestData", "Out", "SLIDESNET_43877", "html5issues");

            var sourcePath1 = Path.GetFullPath(Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "single-page"));
            var sourcePath2 = Path.GetFullPath(Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "common"));

            Directory.CreateDirectory(OutputPath);
            Directory.CreateDirectory(TemplatePath);

            foreach (string dirPath in Directory.GetDirectories(sourcePath1, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath1, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath1, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath1, TemplatePath), true);

            foreach (string dirPath in Directory.GetDirectories(sourcePath2, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath2, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath2, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath2, TemplatePath), true);

            using (Presentation pres = new Presentation(PresentationFilePath))
            {
                WebDocumentOptions options = new WebDocumentOptions
                {
                    EmbedImages = true
                };
                WebDocument document = pres.ToSinglePageWebDocument(options, TemplatePath, OutputPath);
                document.Save();
            }

            CompareDir(EthalonPath, OutputPath, _ =>
            {
                string content = _;
                content = Regex.Replace(content, "<div class=\"shape\" id=\"slide-277-shape-0\" [^>]+>", "");
                content = Regex.Replace(content, "<div class=\"shape\" id=\"slide-2147483662-shape-19\" [^>]+>", "");
                content = Regex.Replace(content, "<div class=\"shape\" id=\"slide-2147309457-shape-37\" [^>]+>", "");
                content = Regex.Replace(content, "<div class=\"shape\" id=\"slide-2147309457-shape-38\" [^>]+>", "");
                content = Regex.Replace(content, "<div class=\"shape\" id=\"slide-2147309457-shape-51\" [^>]+>", "");
                content = Regex.Replace(content, "<div class=\"shape\" id=\"slide-2147309457-shape-53\" [^>]+>", "");
                return content;
            });
        }


        [Test]
        public void Test_Multilevel_Bullets()
        {
            var projectPath = "c:\\ASPOSE\\Aspose.Slides.WebExtensions\\Aspose.Slides.WebExtensions.Tests\\";
            var RootDirectory = projectPath;
            var PresentationFilePath = Path.Combine(RootDirectory, "TestData", "SLIDESNET_43877", "multilevel-bullets.pptx");
            var EthalonPath = Path.Combine(RootDirectory, "TestData", "SLIDESNET_43877", "multilevel-bullets");
            var TemplatePath = Path.Combine(RootDirectory, "TestData", "Out", "templates");
            var OutputPath = Path.Combine(RootDirectory, "TestData", "Out", "SLIDESNET_43877", "multilevel-bullets");

            var sourcePath1 = Path.GetFullPath(Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "single-page"));
            var sourcePath2 = Path.GetFullPath(Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "common"));

            Directory.CreateDirectory(OutputPath);
            Directory.CreateDirectory(TemplatePath);

            foreach (string dirPath in Directory.GetDirectories(sourcePath1, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath1, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath1, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath1, TemplatePath), true);

            foreach (string dirPath in Directory.GetDirectories(sourcePath2, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath2, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath2, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath2, TemplatePath), true);

            using (Presentation pres = new Presentation(PresentationFilePath))
            {
                WebDocumentOptions options = new WebDocumentOptions
                {
                    EmbedImages = true
                };
                WebDocument document = pres.ToSinglePageWebDocument(options, TemplatePath, OutputPath);
                document.Save();
            }

            CompareDir(EthalonPath, OutputPath, _ => Regex.Replace(_, "<div class=\"shape\" id=\"slide-2147493457-shape-0\" [^>]+>", ""));
        }


        [Test]
        public void Test_Artificial()
        {
            var projectPath = "c:\\ASPOSE\\Aspose.Slides.WebExtensions\\Aspose.Slides.WebExtensions.Tests\\";
            var RootDirectory = projectPath;
            var PresentationFilePath = Path.Combine(RootDirectory, "TestData", "SLIDESNET_43877", "artificial.pptx");
            var EthalonPath = Path.Combine(RootDirectory, "TestData", "SLIDESNET_43877", "artificial");
            var TemplatePath = Path.Combine(RootDirectory, "TestData", "Out", "templates");
            var OutputPath = Path.Combine(RootDirectory, "TestData", "Out", "SLIDESNET_43877", "artificial");

            var sourcePath1 = Path.GetFullPath(Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "single-page"));
            var sourcePath2 = Path.GetFullPath(Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "common"));

            Directory.CreateDirectory(OutputPath);
            Directory.CreateDirectory(TemplatePath);

            foreach (string dirPath in Directory.GetDirectories(sourcePath1, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath1, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath1, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath1, TemplatePath), true);

            foreach (string dirPath in Directory.GetDirectories(sourcePath2, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath2, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath2, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath2, TemplatePath), true);

            using (Presentation pres = new Presentation(PresentationFilePath))
            {
                WebDocumentOptions options = new WebDocumentOptions
                {
                    EmbedImages = true
                };
                WebDocument document = pres.ToSinglePageWebDocument(options, TemplatePath, OutputPath);
                document.Save();
            }

            CompareDir(EthalonPath, OutputPath, _ => _);
        }


        [Test]
        public void Test_SamplePPT1()
        {
            var projectPath = "c:\\ASPOSE\\Aspose.Slides.WebExtensions\\Aspose.Slides.WebExtensions.Tests\\";
            var RootDirectory = projectPath;
            var PresentationFilePath = Path.Combine(RootDirectory, "TestData", "SLIDESNET_43877", "SamplePPT1.ppt");
            var EthalonPath = Path.Combine(RootDirectory, "TestData", "SLIDESNET_43877", "SamplePPT1");
            var TemplatePath = Path.Combine(RootDirectory, "TestData", "Out", "templates");
            var OutputPath = Path.Combine(RootDirectory, "TestData", "Out", "SLIDESNET_43877", "SamplePPT1");

            var sourcePath1 = Path.GetFullPath(Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "single-page"));
            var sourcePath2 = Path.GetFullPath(Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "common"));

            Directory.CreateDirectory(OutputPath);
            Directory.CreateDirectory(TemplatePath);

            foreach (string dirPath in Directory.GetDirectories(sourcePath1, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath1, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath1, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath1, TemplatePath), true);

            foreach (string dirPath in Directory.GetDirectories(sourcePath2, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath2, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath2, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath2, TemplatePath), true);

            using (Presentation pres = new Presentation(PresentationFilePath))
            {
                WebDocumentOptions options = new WebDocumentOptions
                {
                    EmbedImages = true
                };
                WebDocument document = pres.ToSinglePageWebDocument(options, TemplatePath, OutputPath);
                document.Save();
            }

            CompareDir(EthalonPath, OutputPath, _ => Regex.Replace(_, "<div class=\"shape\" id=\"slide-257-shape-6\" [^>]+>", ""));
        }


        [Test]
        public void Test_Table()
        {
            var projectPath = "c:\\ASPOSE\\Aspose.Slides.WebExtensions\\Aspose.Slides.WebExtensions.Tests\\";
            var RootDirectory = projectPath;
            var PresentationFilePath = Path.Combine(RootDirectory, "TestData", "SLIDESNET_43877", "table.pptx");
            var EthalonPath = Path.Combine(RootDirectory, "TestData", "SLIDESNET_43877", "table");
            var TemplatePath = Path.Combine(RootDirectory, "TestData", "Out", "templates");
            var OutputPath = Path.Combine(RootDirectory, "TestData", "Out", "SLIDESNET_43877", "table");

            var sourcePath1 = Path.GetFullPath(Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "single-page"));
            var sourcePath2 = Path.GetFullPath(Path.Combine(RootDirectory, "..", "Aspose.Slides.WebExtensions", "templates", "common"));

            Directory.CreateDirectory(OutputPath);
            Directory.CreateDirectory(TemplatePath);

            foreach (string dirPath in Directory.GetDirectories(sourcePath1, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath1, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath1, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath1, TemplatePath), true);

            foreach (string dirPath in Directory.GetDirectories(sourcePath2, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(sourcePath2, TemplatePath));
            foreach (string newPath in Directory.GetFiles(sourcePath2, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(sourcePath2, TemplatePath), true);

            using (Presentation pres = new Presentation(PresentationFilePath))
            {
                WebDocumentOptions options = new WebDocumentOptions
                {
                    EmbedImages = true
                };
                WebDocument document = pres.ToSinglePageWebDocument(options, TemplatePath, OutputPath);
                document.Save();
            }

            CompareDir(EthalonPath, OutputPath, _ => _);
        }

        private void CompareDir(string ethalonPath, string outputPath, CustomReplacement replacements)
        {
            int cnt = 0;
            string[] actualFiles = Directory.GetFiles(outputPath, "*", SearchOption.AllDirectories);
            string[] ethalonFiles = Directory.GetFiles(ethalonPath, "*", SearchOption.AllDirectories);

            foreach (string actualFile in actualFiles)
            {
                foreach (string ethalonFile in ethalonFiles)
                {
                    if (Path.GetFileName(actualFile) == Path.GetFileName(ethalonFile))
                    {
                        cnt++;
                        CompareFiles(ethalonFile,actualFile, replacements);
                    }
                }
            }
            Assert.AreEqual(ethalonFiles.Length, cnt);
        }
        private void CompareFiles(string ethalonFile, string actualFile, CustomReplacement replacements)
        {
            byte[] ethalon = File.ReadAllBytes(ethalonFile);;
            byte[] actual = File.ReadAllBytes(actualFile);;
            string ext = Path.GetExtension(ethalonFile);
            if (ext == ".html" || ext == ".js" || ext == ".css")
            {
                ethalon = ReadMarkupedFile(ethalonFile, replacements);
                actual = ReadMarkupedFile(actualFile, replacements);
            }
            CompareBytes(ethalon, actual);
        }

        delegate string CustomReplacement(string content);

        private byte[] ReadMarkupedFile(string filename, CustomReplacement replacements)
        {
            string content =  File.ReadAllText(filename);

            content = content.Replace("\r", " ");
            content = content.Replace("\n", " ");
            content = content.Replace("\t", " ");

            while (content.IndexOf("  ") >= 0)
                content = content.Replace("  ", " ");

            content = content.Replace(" <", "<");
            content = content.Replace("> ", ">");
            content = content.Replace("><", ">\n<");

            content = replacements(content);

            //File.WriteAllText(filename + ".tst", content);
            return Encoding.UTF8.GetBytes(content);
        }
        private void CompareBytes(byte[] ethalon,byte[] actual)
        {
            Assert.AreEqual(ethalon.Length, actual.Length);
            for(int i = 0; i< ethalon.Length; i++) 
            {
                Assert.AreEqual(ethalon[i], actual[i], "at position {0}", i);
            }
        }
    }
}