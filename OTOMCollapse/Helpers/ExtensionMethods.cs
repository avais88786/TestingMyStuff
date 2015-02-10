using OTOMCollapse.Infrastructure;
using OTOMCollapse.Models.RepeatGroups;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace OTOMCollapse.Helpers
{
    public static class ExtensionMethods
    {
        public static int MaxRepeatGroupValue<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
            Type typee = helper.ViewData.ModelMetadata.ModelType;

            var propertyMetaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            var y = ExpressionHelper.GetExpressionText(expression);
            //var x = ((MaximumPropertyRepeatGroupsAttribute)expression.Body.Type.GetCustomAttributes(typeof(MaximumPropertyRepeatGroupsAttribute), false).SingleOrDefault()).MaxPRGValue;

            var attr = ((MaximumRepeatGroupsAttribute)propertyMetaData.ContainerType.GetProperty(propertyMetaData.PropertyName).GetCustomAttributes(typeof(MaximumRepeatGroupsAttribute), false).SingleOrDefault()).Value;
            //expression.
            return attr;
        }

        public static MvcHtmlString PartialRepeatGroup<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, ViewDataDictionary viewDataDict)
        {
            var propertyMetaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var member = (MemberExpression)expression.Body;
            var value = expression.Compile();

            var x = member.Type.GetGenericArguments()[0]; // Gives underlying item type

            var object1 = Activator.CreateInstance(x); 



            return null;
        }

        public static MvcHtmlString PartialRepeatGroup<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            var member = ((MemberExpression)expression.Body).Member;
            return System.Web.Mvc.Html.PartialExtensions.Partial(htmlHelper, @"Partial\_PartialGenericRepeatGroup",htmlHelper.ViewData.Model, new ViewDataDictionary{{ "RepeatGroupName", member.Name },{"Expression",expression}});
        }

        public static MvcHtmlString EditorForRepeatGroup<TModel>(this HtmlHelper<TModel> htmlHelper, string PropertyNameToInvoke,int index)
        {
            var model = htmlHelper.ViewData.Model;
            var item = Expression.Parameter(model.GetType());
            
            var format = Expression.Constant(index);
            
            var prop = Expression.Property(item, PropertyNameToInvoke);
            var args = new Expression[] { format,prop };
            //prop.
            
            Type type = model.GetType();
            //then lambda
            var lambda =  Expression.Lambda<Func<TModel,string>>(prop,item);


            //System.Web.Mvc.Html.EditorExtensions.EditorFor(htmlHelper,)
            System.Web.Mvc.Html.EditorExtensions.EditorFor(htmlHelper, lambda);
            //System.Web.Mvc.Html.EditorExtensions.EditorFor(htmlHelper,((IList)model.GetType().GetProperty(PropertyNameToInvoke))[index]);
            return null;
        }

       

       // public static void EvaluateExpression<TModel,TVale>(this HtmlHelper<TModel> htmlHelper,Expression<Func<TModel,TVale>> expression)

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