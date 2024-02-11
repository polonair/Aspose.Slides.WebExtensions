// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System.Collections.Generic;
using System;
using RazorEngineCore;
using System.Linq;
using Aspose.Slides.WebExtensions.Helpers;
using System.Drawing;
using Aspose.Slides.Export.Web;

namespace Aspose.Slides.WebExtensions
{
    class TemplateServiceConfiguration
    {
        public bool DisableTempFileLocking { get; internal set; }
        public DefaultCachingProvider CachingProvider { get; internal set; }
        public List<string> Namespaces { get; internal set; } = new List<string>();
    }
}