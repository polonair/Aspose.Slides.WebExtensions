using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspose.Slides.WebExtensions.Tests
{
    public class TestUtils
    {
        public delegate string CustomReplacement(string content);

        public static void CompareDir(string ethalonPath, string outputPath, CustomReplacement replacements)
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
        private static void CompareFiles(string ethalonFile, string actualFile, CustomReplacement replacements)
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
        private static byte[] ReadMarkupedFile(string filename, CustomReplacement replacements)
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

            //File.WriteAllText(filename + ".tst", content);
            return Encoding.UTF8.GetBytes(content);
        }
        private static void CompareBytes(byte[] ethalon, byte[] actual)
        {
            Assert.AreEqual(ethalon.Length, actual.Length);
            for (int i = 0; i < ethalon.Length; i++)
            {
                Assert.AreEqual(ethalon[i], actual[i], "at position {0}", i);
            }
        }
    }
}