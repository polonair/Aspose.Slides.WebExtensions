// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System.Collections.Generic;
using RazorEngineCore;

namespace Aspose.Slides.WebExtensions
{
    public class CompiledTemplate
    {
        public CompiledTemplate(IRazorEngineCompiledTemplate<TemplateBase> templateCompiled, Dictionary<string, IRazorEngineCompiledTemplate<TemplateBase>> partsCompiled)
        {
            m_templateCompiled = templateCompiled;
            m_partsCompiled = partsCompiled;
        }
        public string Run(object model)
        {
            return Run(m_templateCompiled, model);
        }
        public string Run(IRazorEngineCompiledTemplate<TemplateBase> template, object model)
        {
            TemplateBase templateReference = null;
            string result = template.Run(instance =>
            {
                instance.Model = model;
                instance.IncludeCallback = (key, includeModel) => Run(m_partsCompiled[key], includeModel);

                templateReference = instance;
            });
            return result;
        }

        private readonly IRazorEngineCompiledTemplate<TemplateBase> m_templateCompiled;
        private readonly Dictionary<string, IRazorEngineCompiledTemplate<TemplateBase>> m_partsCompiled;
    }
}