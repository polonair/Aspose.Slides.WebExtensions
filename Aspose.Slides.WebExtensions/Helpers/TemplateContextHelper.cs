// Copyright (c) 2001-2020 Aspose Pty Ltd. All Rights Reserved.

using Aspose.Slides.Export.Web;
using System.Drawing;
using System.Reflection;

namespace Aspose.Slides.WebExtensions.Helpers
{
    public static class TemplateContextHelper
    {
        //public static SubModel(Model, slide))

        public static TemplateContext<TSubModel> SubModel<TModel, TSubModel>(TemplateContext<TModel> model, TSubModel subModel)
        {
            return model.SubModel(subModel) as TemplateContext<TSubModel>;
        }
    }
}


