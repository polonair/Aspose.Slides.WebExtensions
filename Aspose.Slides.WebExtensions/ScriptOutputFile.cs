// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System.IO;
using System.Text;
using Aspose.Slides.Export.Web;

namespace Aspose.Slides.WebExtensions
{
    internal class ScriptOutputFile : OutputFile
    {
        public ScriptOutputFile(string content)
        {
            m_content = content;
        }

        public override void Write(Stream stream)
        {
            byte[] binary = Encoding.UTF8.GetBytes(m_content);
            stream.Write(binary, 0, binary.Length);
        }

        private readonly string m_content;
    }
}