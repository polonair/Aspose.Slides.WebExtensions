// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System;
using RazorEngineCore;

namespace Aspose.Slides.WebExtensions
{
    public class TemplateBase : RazorEngineTemplateBase
    {
        class RawTemplateContent
        {
            public object Value { get; set; }

            public RawTemplateContent(object value)
            {
                Value = value;
            }
        }

        public Func<string, object, string> IncludeCallback { get; set; }

        public string Include(string key, object model = null)
        {
            return IncludeCallback(key, model);
        }
        public object Raw(object value)
        {
            return new RawTemplateContent(value);
        }
        public override void Write(object obj = null)
        {
            object value = obj is RawTemplateContent rawContent
                ? rawContent.Value
                : obj;

            base.Write(value);
        }
        public override void WriteAttributeValue(string prefix, int prefixOffset, object value, int valueOffset, int valueLength, bool isLiteral)
        {
            value = value is RawTemplateContent rawContent
                ? rawContent.Value
                : value?.ToString();

            base.WriteAttributeValue(prefix, prefixOffset, value, valueOffset, valueLength, isLiteral);
        }
    }
}