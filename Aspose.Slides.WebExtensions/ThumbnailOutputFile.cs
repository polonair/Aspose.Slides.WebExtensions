// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System.Drawing;
using System.IO;
using Aspose.Slides.Export.Web;

namespace Aspose.Slides.WebExtensions
{
    internal class ThumbnailOutputFile : OutputFile
    {
        public ThumbnailOutputFile(Image thumbnail)
        {
            m_thumbnail = thumbnail;
        }

        public override void Write(Stream stream)
        {
            m_thumbnail.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        }

        private readonly Image m_thumbnail;
    }
}