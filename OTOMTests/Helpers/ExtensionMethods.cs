using OTOMTests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace OTOMTests.Helpers
{
    public static class ExtensionMethods
    {
        public static int MaxRepeatGroupValue(this HtmlHelper helper, Type type)
        {
            return 1;
        }


        public static int MaxRepeatGroupValue<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
            Type typee = helper.ViewData.ModelMetadata.ModelType;
            var propertyMetaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            //var y = ExpressionHelper.GetExpressionText(expression);
            //var x = ((MaximumPropertyRepeatGroupsAttribute)expression.Body.Type.GetCustomAttributes(typeof(MaximumPropertyRepeatGroupsAttribute), false).SingleOrDefault()).MaxPRGValue;

            var attr = ((MaximumPropertyRepeatGroupsAttribute)propertyMetaData.ContainerType.GetProperty(propertyMetaData.PropertyName).GetCustomAttributes(typeof(MaximumPropertyRepeatGroupsAttribute), false).SingleOrDefault()).MaxPRGValue;
            //expression.
            return attr;
        }


        #region example
        //public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        //{
        //    return LabelFor(html, expression, new RouteValueDictionary(htmlAttributes));
        //}

        //public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        //{
        //    ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
        //    string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
        //    string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
        //    if (String.IsNullOrEmpty(labelText))
        //    {
        //        return MvcHtmlString.Empty;
        //    }

        //    TagBuilder tag = new TagBuilder("label");
        //    tag.MergeAttributes(htmlAttributes);
        //    tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
        //    tag.SetInnerText(labelText);
        //    return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        //}

        #endregion
    }
}