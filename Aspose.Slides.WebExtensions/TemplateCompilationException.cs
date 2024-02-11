// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System.Collections.Generic;
using System;

namespace Aspose.Slides.WebExtensions
{
    class TemplateCompilationException : Exception
    {
        public IEnumerable<CompilerError> CompilerErrors { get; internal set; }
    }
}