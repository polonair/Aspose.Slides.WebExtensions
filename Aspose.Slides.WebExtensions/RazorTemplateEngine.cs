// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System;
using System.Collections.Generic;
using Aspose.Slides.Export.Web;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace Aspose.Slides.WebExtensions
{
    public class RazorTemplateEngine : ITemplateEngine
    {
        public RazorTemplateEngine()
        {
            var config = new TemplateServiceConfiguration
            {
                DisableTempFileLocking = false,
                CachingProvider = new DefaultCachingProvider(t => { })
            };
            
            config.Namespaces.Add("System");
            config.Namespaces.Add("System.Drawing");
            config.Namespaces.Add("System.Drawing.Imaging");
            config.Namespaces.Add("Aspose.Slides");
            config.Namespaces.Add("Aspose.Slides.Export.Web");
            config.Namespaces.Add("Aspose.Slides.WebExtensions.Helpers");

            m_razorService = RazorEngineService.Create(config);

            Engine.Razor = m_razorService;

            m_templateTypes = new Dictionary<string, Type>();
        }

        public void AddTemplate(string key, string template, Type modelType)
        {
            try
            {
                if (m_templateTypes.ContainsKey(key))
                    throw new ArgumentException(string.Format("Template \"{0}\" has been added already. Can't add a template with same key twice.", key), "key");

                m_razorService.AddTemplate(key, template);
                m_razorService.Compile(key, modelType);
                m_templateTypes.Add(key, modelType);
            }
            catch (TemplateCompilationException ex)
            {
                string razorErrors = "";
                foreach (var err in ex.CompilerErrors)
                {
                    if (!string.IsNullOrEmpty(razorErrors))
                        razorErrors += Environment.NewLine + Environment.NewLine;

                    razorErrors += string.Format("{0}, line {1} , column {2}", err.ErrorText, err.Line, err.Column);
                }

                throw new Exception(razorErrors);
            }
        }

        public string Compile<TModel>(string key, TModel model)
        {
            Type templateType = null;
            if (!m_templateTypes.TryGetValue(key, out templateType) || !templateType.Equals(model.GetType()))
                throw new ArgumentException(string.Format("Can't find template \"{0}\" for type {1}. Check Input and Output types correspondence.", key, model.GetType().GenericTypeArguments[0].ToString()), "key");

            return m_razorService.Run(key, typeof(TModel), model);
        }

        private readonly IRazorEngineService m_razorService;
        private readonly Dictionary<string, Type> m_templateTypes;
    }
}