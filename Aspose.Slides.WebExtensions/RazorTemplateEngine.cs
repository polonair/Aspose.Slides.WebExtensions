// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using System;
using System.Collections.Generic;
using Aspose.Slides.Export.Web;

namespace Aspose.Slides.WebExtensions
{
    public class RazorTemplateEngine : ITemplateEngine
    {
        public RazorTemplateEngine()
        {
            m_razorService = RazorEngineService.Create();
            m_templateTypes = new Dictionary<string, Type>();
        }
        public void AddTemplate(string key, string template, Type modelType)
        {
            if (m_templateTypes.ContainsKey(key))
                throw new ArgumentException(string.Format("Template \"{0}\" has been added already. Can't add a template with same key twice.", key), "key");

            m_razorService.AddTemplate(key, template);
            m_razorService.Compile(key, modelType);
            m_templateTypes.Add(key, modelType);
        }
        public string Compile(string key, object model)
        {
            Type templateType = null;
            if (!m_templateTypes.TryGetValue(key, out templateType) || !templateType.Equals(model.GetType()))
                throw new ArgumentException(string.Format("Can't find template \"{0}\" for type {1}. Check Input and Output types correspondence.", key, model.GetType().GenericTypeArguments[0].ToString()), "key");

            return m_razorService.Run(key, model.GetType(), model);
        }
        public void AddTemplate(string key, string template) => throw new NotImplementedException();

        private readonly IRazorEngineService m_razorService;
        private readonly Dictionary<string, Type> m_templateTypes;
    }
}