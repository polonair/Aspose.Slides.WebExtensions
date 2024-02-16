// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System.Collections.Generic;
using System;
using RazorEngineCore;
using System.Linq;
using System.Drawing;
using Aspose.Slides.Export.Web;
using System.Threading;

namespace Aspose.Slides.WebExtensions
{
    class RazorEngineService : IRazorEngineService
    {
        IRazorEngine razorEngine;
        IDictionary<string, string> parts = new Dictionary<string, string>();
        IDictionary<string, IRazorEngineCompiledTemplate<TemplateBase>> cash = new Dictionary<string, IRazorEngineCompiledTemplate<TemplateBase>>();
        internal static IRazorEngineService Create(TemplateServiceConfiguration config)
        {
            return new RazorEngineService();
            //throw new NotImplementedException();
        }

        public RazorEngineService()
        {
            razorEngine = new RazorEngine();
        }

        public void AddTemplate(string key, string template)
        {
            parts.Add(key, template);
        }

        public void Compile(string key, Type modelType)
        {
            //throw new NotImplementedException();
        }
        IRazorEngineCompiledTemplate<TemplateBase> CashCompile(string content)
        {
            IRazorEngineCompiledTemplate<TemplateBase> cmp = null;
            if (cash.TryGetValue(content, out cmp)) return cmp;
            return cash[content] = razorEngine.Compile<TemplateBase>(content, builder =>
            {
                builder.AddUsing("System");
                builder.AddUsing("System.Drawing");
                builder.AddUsing("System.Collections");
                builder.AddUsing("System.Collections.Generic");
                builder.AddUsing("Aspose.Slides");
                builder.AddUsing("Aspose.Slides.Export.Web");
                builder.AddUsing("Aspose.Slides.WebExtensions.Helpers");

                builder.AddAssemblyReference(typeof(Presentation));
                builder.AddAssemblyReference(typeof(SizeF));
                builder.AddAssemblyReference(typeof(FontStyle));
                builder.AddAssemblyReference(typeof(Dictionary<,>));
                builder.AddAssemblyReference(typeof(TemplateContext<>));
                try { builder.AddAssemblyReferenceByName("System.Collections"); }
                catch { }
                builder.AddAssemblyReferenceByName("System.Drawing.Common");
                builder.AddAssemblyReference(GetType());
                //builder.IncludeDebuggingInfo();
            });
        }
        public string Run(string key, Type type, object model)
        {
            var t = new CompiledTemplate(
                CashCompile(parts[key]),
                parts.ToDictionary(k => k.Key, v => CashCompile(v.Value)));

            return t.Run(model);
        }
    }
}