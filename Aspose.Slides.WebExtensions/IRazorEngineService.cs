// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System;

namespace Aspose.Slides.WebExtensions
{
    interface IRazorEngineService
    {
        string Run(string key, Type type, object model);
        void AddTemplate(string key, string template);
        void Compile(string key, Type modelType);
    }
}