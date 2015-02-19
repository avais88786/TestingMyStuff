using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenGI.MVC.ModelBinders
{
    public class DataCaptureModelBinder : DefaultModelBinder
    {
        ////protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, System.Type modelType)
        ////{
        ////    ////if (modelType.IsInterface || modelType.IsAbstract)
        ////    ////{
        ////    ////    if (bindingContext.ValueProvider.ContainsKey(bindingContext.ModelName + ".BindingType"))
        ////    ////    {
        ////    ////        modelType = Type.GetType(((string[])bindingContext.ValueProvider[bindingContext.ModelName + ".BindingType"].RawValue)[0]);
        ////    ////    }
        ////    ////}
        ////        return base.CreateModel(controllerContext, bindingContext, modelType);
        ////}

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ModelBindingContext context = new ModelBindingContext(bindingContext);

            var businessLine = controllerContext.RequestContext.HttpContext.Request.Form["BusinessLine"];  // TODO: Get from session

            var item = Activator.CreateInstance(Type.GetType(businessLine));

            // TODO: check this inherits from the correct interface

            Func<object> modelAccessor = () => item;
            context.ModelMetadata = new ModelMetadata(new DataAnnotationsModelMetadataProvider(),
                bindingContext.ModelMetadata.ContainerType, modelAccessor, item.GetType(), bindingContext.ModelName);

            return base.BindModel(controllerContext, context);
        }
    }
}