// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System.Collections.Generic;
using RazorEngineCore;

namespace Aspose.Slides.WebExtensions
{
    public class CompiledTemplate
    {
        private readonly IRazorEngineCompiledTemplate<TemplateBase> compiledTemplate;
        private readonly Dictionary<string, IRazorEngineCompiledTemplate<TemplateBase>> compiledParts;

        public CompiledTemplate(IRazorEngineCompiledTemplate<TemplateBase> compiledTemplate, Dictionary<string, IRazorEngineCompiledTemplate<TemplateBase>> compiledParts)
        {
            this.compiledTemplate = compiledTemplate;
            this.compiledParts = compiledParts;
        }

        public string Run(object model)
        {
            return this.Run(this.compiledTemplate, model);
        }

        public string Run(IRazorEngineCompiledTemplate<TemplateBase> template, object model)
        {
            TemplateBase templateReference = null;
            //template.EnableDebugging();
            string result = template.Run(instance =>
            {
                //if (!(model is AnonymousTypeWrapper))
                //{
                //    model = new AnonymousTypeWrapper(model);
                //}

                instance.Model = model;
                instance.IncludeCallback = (key, includeModel) => this.Run(this.compiledParts[key], includeModel);

                templateReference = instance;
            });

            if (templateReference.Layout == null)
            {
                return result;
            }

            return this.compiledParts[templateReference.Layout].Run(instance =>
            {
                //if (!(model is AnonymousTypeWrapper))
                //{
                //    model = new AnonymousTypeWrapper(model);
                //}

                instance.Model = model;
                instance.IncludeCallback = (key, includeModel) => this.Run(this.compiledParts[key], includeModel);
                instance.RenderBodyCallback = () => result;
            });
        }

        public void Save()
        {
            /*
            TODO

            this.compiledTemplate.SaveToFile();
            this.compiledTemplate.SaveToStream();

            foreach (var compiledPart in this.compiledParts)
            {
                compiledPart.Value.SaveToFile();
                compiledPart.Value.SaveToStream();
            }
            */
        }

        public void Load()
        {
            // TODO
        }
    }
}