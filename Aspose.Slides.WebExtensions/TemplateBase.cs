// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System;
using RazorEngineCore;

namespace Aspose.Slides.WebExtensions
{
    public class TemplateBase : RazorEngineTemplateBase
    {
        class RawContent
        {
            public object Value { get; set; }

            public RawContent(object value)
            {
                Value = value;
            }
        }

        public Func<string, object, string> IncludeCallback { get; set; }
        public Func<string> RenderBodyCallback { get; set; }
        public string Layout { get; set; }

        public string Include(string key, object model = null)
        {
            return this.IncludeCallback(key, model);
        }
        public string RenderBody()
        {
            return this.RenderBodyCallback();
        }
        public object Raw(object value)
        {
            return new RawContent(value);
        }
        public override void Write(object obj = null)
        {
            //object value = obj is RawContent rawContent
            //    ? rawContent.Value
            //    : System.Web.HttpUtility.HtmlEncode(obj);
            //
            //base.Write(value);
            object value = obj is RawContent rawContent
                ? rawContent.Value
                : obj;
            
            base.Write(value);
        }

        public override void WriteAttributeValue(string prefix, int prefixOffset, object value, int valueOffset, int valueLength, bool isLiteral)
        {
            value = value is RawContent rawContent
                ? rawContent.Value
                : value?.ToString();
            
            base.WriteAttributeValue(prefix, prefixOffset, value, valueOffset, valueLength, isLiteral);
        }
    }
}