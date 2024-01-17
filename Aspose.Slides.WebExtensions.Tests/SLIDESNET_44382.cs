﻿using Aspose.Slides.Export.Web;
using NUnit.Framework;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Aspose.Slides.WebExtensions.Tests
{
    [TestFixture]
    public class SLIDESNET_44382
    {
        [OneTimeSetUp]
        public void Setup()
        {
        }
        [Test]
        public void Test_44382()
        {
            var RootDirectory = Path.GetFullPath(Path.Combine(TestContext.CurrentContext.TestDirectory, "..", "..", ".."));
            var PresentationFilePath = Path.Combine(RootDirectory, "TestData", "SLIDESNET_44382", "SLIDESNET-44382.pptx");
            var EthalonPath = Path.Combine(RootDirectory, "TestData", "SLIDESNET_44382", "html");
            var TemplatePath = Path.Combine(RootDirectory, "TestData", "Out", "templates");
            var OutputPath = Path.Combine(RootDirectory, "TestData", "Out", "SLIDESNET_44382");

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
                WebDocument document = pres.ToSinglePageWebDocument(
                    new WebDocumentOptions 
                    {
                        EmbedImages = true,
                        AnimateShapes = true,
                        AnimateTransitions = true
                    },
                    TemplatePath,
                    OutputPath);
                document.Save();
            }

            CompareDir(EthalonPath, OutputPath, _ => _ /*Regex.Replace(_, "<div class=\"shape\" id=\"slide-2147483725-shape-0\" [^>]+>", "")*/);
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
                        CompareFiles(ethalonFile, actualFile, replacements);
                    }
                }
            }
            Assert.AreEqual(ethalonFiles.Length, cnt);
        }
        private void CompareFiles(string ethalonFile, string actualFile, CustomReplacement replacements)
        {
            byte[] ethalon = File.ReadAllBytes(ethalonFile); ;
            byte[] actual = File.ReadAllBytes(actualFile); ;
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
            string content = File.ReadAllText(filename);

            content = content.Replace("\r", " ");
            content = content.Replace("\n", " ");
            content = content.Replace("\t", " ");

            while (content.IndexOf("  ") >= 0)
                content = content.Replace("  ", " ");

            content = content.Replace(" <", "<");
            content = content.Replace("> ", ">");
            content = content.Replace("><", ">\n<");

            content = replacements(content);

            File.WriteAllText(filename + ".tst", content);
            return Encoding.UTF8.GetBytes(content);
        }
        private void CompareBytes(byte[] ethalon, byte[] actual)
        {
            //Assert.AreEqual(ethalon.Length, actual.Length);
            for (int i = 0; i < ethalon.Length; i++)
            {
                Assert.AreEqual(ethalon[i], actual[i], "at position {0}", i);
            }
        }
    }
}