// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System;

namespace Aspose.Slides.WebExtensions
{
    class DefaultCachingProvider
    {
        public DefaultCachingProvider(Action<object> value)
        {
            Value = value;
        }

        public Action<object> Value { get; }
    }
}