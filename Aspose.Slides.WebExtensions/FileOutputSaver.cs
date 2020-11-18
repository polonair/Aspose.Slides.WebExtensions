// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System.IO;
using Aspose.Slides.Export.Web;

namespace Aspose.Slides.WebExtensions
{
    public class FileOutputSaver : IOutputSaver
    {
        public void Save(string path, IOutputFile outputFile)
        {
            string dir = Path.GetDirectoryName(path);
            if(dir != "" && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                outputFile.Write(stream);
            }
        }
    }
}