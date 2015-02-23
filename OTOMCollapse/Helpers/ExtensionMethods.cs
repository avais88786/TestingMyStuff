using OTOMCollapse.Infrastructure;
using OTOMCollapse.Models.RepeatGroups;
using OTOMCollapse.Models.ViewModels.PropertyOwners;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace OTOMCollapse.Helpers
{
    public static class ExtensionMethods
    {
        public static void SetHtmlTemplateInfo<TModel>(this HtmlHelper<TModel> htmlHelper,int listIndex)
        {
            int actualindex = 0;
            if (htmlHelper.ViewData.ContainsKey("Index"))
                actualindex = (int)htmlHelper.ViewData["Index"];
            else
                actualindex = listIndex;

            string htmlTemplateFieldPrefix = (string)htmlHelper.ViewData["htmlFieldPrefix"];
            htmlTemplateFieldPrefix = htmlTemplateFieldPrefix.Substring(0, (htmlTemplateFieldPrefix.Length - 3));
            htmlTemplateFieldPrefix = String.Format("{0}[{1}]", htmlTemplateFieldPrefix, actualindex);

            htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix = htmlTemplateFieldPrefix;    
        }

        public static MvcHtmlString BeginListSection<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            int index = 0;
            if (htmlHelper.ViewData.ContainsKey("Index"))
                index = (int)htmlHelper.ViewData["Index"];

            if (index == 0)
            {
                var templateInfo =(string) htmlHelper.ViewData["htmlFieldPrefix"];
                var hiddenIndexTag = new TagBuilder("input");
                hiddenIndexTag.MergeAttribute("name", (templateInfo.Substring(0, (templateInfo.Length - 3))) + ".Index");
                hiddenIndexTag.MergeAttribute("value", index.ToString());
                hiddenIndexTag.Attributes.Add("type", "hidden");
                

                
                
                return MvcHtmlString.Create("<section class=\"listStyle\">" + hiddenIndexTag.ToString(TagRenderMode.SelfClosing));
            }
                
            return null;
        }


        public static MvcHtmlString EndListSection<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            int index = 0;
            if (htmlHelper.ViewData.ContainsKey("Index"))
                index = (int)htmlHelper.ViewData["Index"];

            if (index == 0)
                return MvcHtmlString.Create("</section>");
            return null;
        }



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

        //public static MvcHtmlString EditorForRepeatGroup<TModel>(this HtmlHelper<TModel> htmlHelper, string PropertyNameToInvoke, int index)
        //{
        //    var model = htmlHelper.ViewData.Model;
        //    var item = Expression.Parameter(model.GetType());
        //    var m = Expression.Property(item, PropertyNameToInvoke);

        //    var propertyInfo = model.GetType().GetProperty(PropertyNameToInvoke);
        //   // var prop = Expression.Property(item, propertyInfo, new[] { Expression.Constant(index) });
        //    var args = new Expression[] {Expression.Constant(index)};

            

        //    var y = Expression.MakeIndex(m, typeof(List<PropertyRepeatGroup>).GetProperty("Item"), new[] { Expression.Constant(index) });
            
        //    //prop.
            
        //    Type type = model.GetType();
            
        //    //then lambda
        //    var lambda = Expression.Lambda<Func<PropertyDetailsGroupViewModel, PropertyRepeatGroup>>(y, item);


        //    //System.Web.Mvc.Html.EditorExtensions.EditorFor(htmlHelper,)
        //    //System.Web.Mvc.Html.EditorExtensions.EditorFor(htmlHelper, lambda);
        //    //System.Web.Mvc.Html.EditorExtensions.EditorFor(htmlHelper,((IList)model.GetType().GetProperty(PropertyNameToInvoke))[index]);
        //    return null;
        //}


        public static MvcHtmlString RenderAddMoreButtonFor<TModel,TValue>(this HtmlHelper<TModel> htmlHelper,Expression<Func<TModel,TValue>> expression)
        {
            var hiddenElementTagBuilder = new TagBuilder("input");
            string propertyName = ExpressionHelper.GetExpressionText(expression); //RepeatingGroup
            string containerName = expression.Parameters[0].Type.Name;            //RepeatingGroupContainer
            int maxValue = ((MaximumRepeatGroupsAttribute)((MemberExpression)expression.Body).Member.GetCustomAttribute(typeof(MaximumRepeatGroupsAttribute), false)).Value;
            StringBuilder htmlFieldPrefix = GetHtmlFieldPrefix<TModel>(htmlHelper, propertyName);  //Get HtmlPrefix that should be used for next repeatinggroup

            string currentHtmlFieldPrefix = htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix;
            //int currentIndexTag_Template = currentHtmlFieldPrefix.LastIndexOf('[');
            //int currentIndex = 0;

            //if (currentIndexTag_Template >= 0)
            //    Int32.TryParse(currentHtmlFieldPrefix[currentIndexTag_Template + 1].ToString(), out currentIndex);

            var idPrefix = currentHtmlFieldPrefix.Replace('.', '_');
            idPrefix = idPrefix.Replace('[', '_');
            idPrefix = idPrefix.Replace(']', '_');

            //Could use Regex:
            //Regex pattern = new Regex(@"[.\[\]]");
            //var gggg = pattern.Replace(template, "_");
            
            // Create valid id
            hiddenElementTagBuilder.GenerateId("hidden" + idPrefix + propertyName);

            // Add attributes
            hiddenElementTagBuilder.Attributes.Add("type", "hidden");
            //builder.MergeAttribute("data-container", rpContainer.GetType().Name);
            hiddenElementTagBuilder.MergeAttribute("data-container", containerName);
            
            hiddenElementTagBuilder.MergeAttribute("data-property", propertyName);
            hiddenElementTagBuilder.MergeAttribute("data-maxpossiblevalue", maxValue.ToString());
            hiddenElementTagBuilder.MergeAttribute("data-currentdisplayedrepeatinggroupsonpage", "1");
            hiddenElementTagBuilder.MergeAttribute("data-currentindex", "0");
            hiddenElementTagBuilder.MergeAttribute("data-htmlfieldprefix", htmlFieldPrefix.ToString());
            //builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            // Render tag

            var addButtonTagBuilder = new TagBuilder("input");
            addButtonTagBuilder.GenerateId("add" + idPrefix + propertyName);
            addButtonTagBuilder.Attributes.Add("type", "button");
            addButtonTagBuilder.Attributes.Add("value", "Add");
            addButtonTagBuilder.Attributes.Add("data-hiddenforelementid", "#hidden" + idPrefix + propertyName);
            addButtonTagBuilder.Attributes.Add("data-placeholderelementid", "#RepeatGroupContainer" + idPrefix + propertyName);
            var outputTags = new StringBuilder();
            outputTags.Append(hiddenElementTagBuilder.ToString(TagRenderMode.SelfClosing));
            outputTags.Append(addButtonTagBuilder.ToString(TagRenderMode.SelfClosing));


            return MvcHtmlString.Create(outputTags.ToString());
        }


        public static MvcHtmlString RenderGenericPartialFor<TModel, Tvalue>(this HtmlHelper<TModel> htmlHelper, string partialViewName, TModel model, Expression<Func<TModel, Tvalue>> expression)
        {
            string propertyName = ExpressionHelper.GetExpressionText(expression);
            string containerName = expression.Parameters[0].Type.Name;

            #region adding stuff


            ParameterExpression pe = Expression.Parameter(typeof(TModel), "model");


            var hiddenElementTagBuilder = new TagBuilder("input");
            int maxValue = ((MaximumRepeatGroupsAttribute)((MemberExpression)expression.Body).Member.GetCustomAttribute(typeof(MaximumRepeatGroupsAttribute), false)).Value;

            #endregion

            var compiledExpression = (IList)expression.Compile()(htmlHelper.ViewData.Model);

            StringBuilder htmlFieldPrefix = GetHtmlFieldPrefix<TModel>(htmlHelper, propertyName);
            //htmlFieldPrefix.Append("[0]"); //zeroth index

            string currentHtmlFieldPrefix = htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix;

            var idPrefix = currentHtmlFieldPrefix.Replace('.', '_');
            idPrefix = idPrefix.Replace('[', '_');
            idPrefix = idPrefix.Replace(']', '_');

            //int currentIndexTag_Template = currentHtmlFieldPrefix.LastIndexOf('[');
            //int currentIndex = 0;

            //if (currentIndexTag_Template >= 0)
            //    Int32.TryParse(currentHtmlFieldPrefix[currentIndexTag_Template + 1].ToString(), out currentIndex);

            #region addingStuff

            // Create valid id
            hiddenElementTagBuilder.GenerateId("hidden" + idPrefix + propertyName);

            // Add attributes
            hiddenElementTagBuilder.Attributes.Add("type", "hidden");
            //builder.MergeAttribute("data-container", rpContainer.GetType().Name);
            hiddenElementTagBuilder.MergeAttribute("data-container", containerName);

            hiddenElementTagBuilder.MergeAttribute("data-property", propertyName);
            hiddenElementTagBuilder.MergeAttribute("data-maxpossiblevalue", maxValue.ToString());
            hiddenElementTagBuilder.MergeAttribute("data-currentdisplayedrepeatinggroupsonpage", (compiledExpression == null || compiledExpression.Count == 0) ? "1" : compiledExpression.Count.ToString());
            hiddenElementTagBuilder.MergeAttribute("data-currentindex", compiledExpression == null ? "0" : compiledExpression.Count.ToString());
            hiddenElementTagBuilder.MergeAttribute("data-htmlfieldprefix", htmlFieldPrefix.ToString());
            //builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            // Render tag

            var addButtonTagBuilder = new TagBuilder("input");
            addButtonTagBuilder.GenerateId("add" + idPrefix + propertyName);
            addButtonTagBuilder.Attributes.Add("type", "button");
            addButtonTagBuilder.Attributes.Add("value", "Add");
            addButtonTagBuilder.Attributes.Add("data-hiddenforelementid", "#hidden" + idPrefix + propertyName);
            addButtonTagBuilder.Attributes.Add("data-placeholderelementid", "#RepeatGroupContainer" + idPrefix + propertyName);
            var outputTags = new StringBuilder();
            outputTags.Append(hiddenElementTagBuilder.ToString(TagRenderMode.SelfClosing));
            outputTags.Append(addButtonTagBuilder.ToString(TagRenderMode.SelfClosing));

            #endregion


            var viewData = new ViewDataDictionary(htmlHelper.ViewData)
            {
                TemplateInfo = new TemplateInfo()
                {
                    FormattedModelValue = htmlHelper.ViewData.TemplateInfo.FormattedModelValue,
                    HtmlFieldPrefix = ""
                }
            };

            if (viewData.ContainsKey("idToAppend"))
                viewData.Remove("idToAppend");
            viewData.Add("idToAppend", idPrefix + propertyName);

            if (viewData.ContainsKey("Index"))
                viewData.Remove("Index");
            viewData.Add("Index", 0);

            if (viewData.ContainsKey("htmlFieldPrefix"))
                viewData.Remove("htmlFieldPrefix");
            viewData.Add("htmlFieldPrefix", htmlFieldPrefix.ToString());

            if (viewData.ContainsKey("property"))
                viewData.Remove("property");
            viewData.Add("property", propertyName);

            var outputHtml = new StringBuilder();

            if (compiledExpression == null || compiledExpression.Count == 0)
            {
                string stringHtmlFieldPrefix = String.Format("{0}[{1}]", htmlFieldPrefix.ToString(), 0);
                if (viewData.ContainsKey("htmlFieldPrefix"))
                    viewData.Remove("htmlFieldPrefix");
                viewData.Add("htmlFieldPrefix", stringHtmlFieldPrefix);
                //htmlFieldPrefix.Append("[0]");
                outputHtml.Append(PartialExtensions.Partial(htmlHelper, partialViewName, model, viewData));
            }
            else
            {

                for (int i = 0; i < compiledExpression.Count; i++)
                {
                    string stringHtmlFieldPrefix = String.Format("{0}[{1}]", htmlFieldPrefix.ToString(), i);
                    if (viewData.ContainsKey("htmlFieldPrefix"))
                        viewData.Remove("htmlFieldPrefix");
                    viewData.Add("htmlFieldPrefix", stringHtmlFieldPrefix);

                    if (viewData.ContainsKey("Index"))
                        viewData.Remove("Index");
                    viewData.Add("Index", i);

                    //if (viewData.ContainsKey("htmlFieldPrefix"))
                    //    viewData.Remove("htmlFieldPrefix");
                    //viewData.Add("htmlFieldPrefix", htmlFieldPrefix.ToString());

                    outputHtml.Append(PartialExtensions.Partial(htmlHelper, partialViewName, model, viewData));
                }

                //return MvcHtmlString.Create(outputHtml.ToString());
            }

            outputHtml.Append(outputTags);

            return MvcHtmlString.Create(outputHtml.ToString());

        }


        public static MvcHtmlString RenderGenericPartialFor<TModel>(this HtmlHelper<TModel> htmlHelper, string partialViewName, TModel model)//, Expression<Func<TModel, Tvalue>> expression)
        {
            //string propertyName = ExpressionHelper.GetExpressionText(expression);
            string containerName = htmlHelper.ViewData.Model.GetType().Name;//expression.Parameters[0].Type.Name;

            #region adding stuff

            var hiddenElementTagBuilder = new TagBuilder("input");
            //int maxValue = ((MaximumRepeatGroupsAttribute)((MemberExpression)expression.Body).Member.GetCustomAttribute(typeof(MaximumRepeatGroupsAttribute), false)).Value;
            int maxValue = ((MaximumRepeatGroupsAttribute)(htmlHelper.ViewData.Model.GetType().GetCustomAttribute(typeof(MaximumRepeatGroupsAttribute), false))).Value;

            #endregion

            //var compiledExpression = (IList)expression.Compile()(htmlHelper.ViewData.Model);

            //StringBuilder htmlFieldPrefix = GetHtmlFieldPrefix<TModel>(htmlHelper, propertyName);
            //htmlFieldPrefix.Append("[0]"); //zeroth index

            //string currentHtmlFieldPrefix = htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix;

            //var idPrefix = currentHtmlFieldPrefix.Replace('.', '_');
            //idPrefix = idPrefix.Replace('[', '_');
            //idPrefix = idPrefix.Replace(']', '_');

            //int currentIndexTag_Template = currentHtmlFieldPrefix.LastIndexOf('[');
            //int currentIndex = 0;

            //if (currentIndexTag_Template >= 0)
            //    Int32.TryParse(currentHtmlFieldPrefix[currentIndexTag_Template + 1].ToString(), out currentIndex);

            #region addingStuff
            var Model = htmlHelper.ViewData.Model;
            var Model2 = (IList)Model;
            // Create valid id
            hiddenElementTagBuilder.GenerateId("hidden" + "xyz");

            // Add attributes
            hiddenElementTagBuilder.Attributes.Add("type", "hidden");
            //builder.MergeAttribute("data-container", rpContainer.GetType().Name);
            hiddenElementTagBuilder.MergeAttribute("data-container", containerName);

            //hiddenElementTagBuilder.MergeAttribute("data-property", propertyName);
            hiddenElementTagBuilder.MergeAttribute("data-maxpossiblevalue", maxValue.ToString());
            hiddenElementTagBuilder.MergeAttribute("data-currentdisplayedrepeatinggroupsonpage", (Model == null) ? "1" : Model2.Count.ToString());
            hiddenElementTagBuilder.MergeAttribute("data-currentindex", Model2 == null ? "0" : Model2.Count.ToString());
            //hiddenElementTagBuilder.MergeAttribute("data-htmlfieldprefix", htmlFieldPrefix.ToString());
            //builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            // Render tag

            var addButtonTagBuilder = new TagBuilder("input");
            addButtonTagBuilder.GenerateId("add" + "add");
            addButtonTagBuilder.Attributes.Add("type", "button");
            addButtonTagBuilder.Attributes.Add("value", "Add");
            addButtonTagBuilder.Attributes.Add("data-hiddenforelementid", "#hidden" + "hidde");
            addButtonTagBuilder.Attributes.Add("data-placeholderelementid", "#RepeatGroupContainer" + "rpgs");
            var outputTags = new StringBuilder();
            outputTags.Append(hiddenElementTagBuilder.ToString(TagRenderMode.SelfClosing));
            outputTags.Append(addButtonTagBuilder.ToString(TagRenderMode.SelfClosing));

            #endregion


            //var viewData = new ViewDataDictionary(htmlHelper.ViewData)
            //{
            //    TemplateInfo = new TemplateInfo()
            //    {
            //        FormattedModelValue = htmlHelper.ViewData.TemplateInfo.FormattedModelValue,
            //        HtmlFieldPrefix = ""
            //    }
            //};

            //if (viewData.ContainsKey("idToAppend"))
            //    viewData.Remove("idToAppend");
            //viewData.Add("idToAppend", idPrefix + propertyName);

            //if (viewData.ContainsKey("Index"))
            //    viewData.Remove("Index");
            //viewData.Add("Index", 0);

            //if (viewData.ContainsKey("htmlFieldPrefix"))
            //    viewData.Remove("htmlFieldPrefix");
            //viewData.Add("htmlFieldPrefix", htmlFieldPrefix.ToString());

            //if (viewData.ContainsKey("property"))
            //    viewData.Remove("property");
            //viewData.Add("property", propertyName);

            var outputHtml = new StringBuilder();

            if (Model2 == null || Model2.Count == 0)
            {
                //string stringHtmlFieldPrefix = String.Format("{0}[{1}]", htmlFieldPrefix.ToString(), 0);
                //if (viewData.ContainsKey("htmlFieldPrefix"))
                //    viewData.Remove("htmlFieldPrefix");
                //viewData.Add("htmlFieldPrefix", stringHtmlFieldPrefix);
                ////htmlFieldPrefix.Append("[0]");
                outputHtml.Append(PartialExtensions.Partial(htmlHelper, "Object", model));
            }
            else
            {

                for (int i = 0; i < Model2.Count; i++)
                {
                    //string stringHtmlFieldPrefix = String.Format("{0}[{1}]", htmlFieldPrefix.ToString(), i);
                    //if (viewData.ContainsKey("htmlFieldPrefix"))
                    //    viewData.Remove("htmlFieldPrefix");
                    //viewData.Add("htmlFieldPrefix", stringHtmlFieldPrefix);

                    //if (viewData.ContainsKey("Index"))
                    //    viewData.Remove("Index");
                    //viewData.Add("Index", i);

                    //if (viewData.ContainsKey("htmlFieldPrefix"))
                    //    viewData.Remove("htmlFieldPrefix");
                    //viewData.Add("htmlFieldPrefix", htmlFieldPrefix.ToString());

                    outputHtml.Append(PartialExtensions.Partial(htmlHelper, "Object", model));
                }

                //return MvcHtmlString.Create(outputHtml.ToString());
            }

            outputHtml.Append(outputTags);

            return MvcHtmlString.Create(outputHtml.ToString());

        }


        private static StringBuilder GetHtmlFieldPrefix<TModel>(HtmlHelper<TModel> htmlHelper, string propertyName)
        {
            StringBuilder htmlFieldPrefix = new StringBuilder();
            if (htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix != "")
            {
                htmlFieldPrefix.Append(htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix);
                htmlFieldPrefix.Append(propertyName == "" ? "" : "." + propertyName);
            }
            else
                htmlFieldPrefix.Append(propertyName);
            return htmlFieldPrefix;
        }


        public static MvcHtmlString RenderAddMoreButton<TModel>(this HtmlHelper<TModel> htmlHelper, string propertyName, int? maxValue, bool indexPresent)
        {
           
            StringBuilder htmlFieldPrefix = GetHtmlFieldPrefix<TModel>(htmlHelper, "");  //Get HtmlPrefix that should be used for next repeatinggroup

            string currentHtmlFieldPrefix = htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix;
           

            var idPrefix = currentHtmlFieldPrefix.Replace('.', '_');
            idPrefix = idPrefix.Replace('[', '_');
            idPrefix = idPrefix.Replace(']', '_');

            //Could use Regex:
            //Regex pattern = new Regex(@"[.\[\]]");
            //var gggg = pattern.Replace(template, "_");

            var outputTags = new StringBuilder();

            if (!indexPresent)
            {
                var hiddenElementTagBuilder = new TagBuilder("input");
                // Create valid id
                hiddenElementTagBuilder.GenerateId("hidden" + idPrefix);

                // Add attributes
                hiddenElementTagBuilder.Attributes.Add("type", "hidden");
                //builder.MergeAttribute("data-container", rpContainer.GetType().Name);
                //hiddenElementTagBuilder.MergeAttribute("data-container", containerName);

                hiddenElementTagBuilder.MergeAttribute("data-property", propertyName);
                hiddenElementTagBuilder.MergeAttribute("data-maxpossiblevalue", maxValue.ToString());
                hiddenElementTagBuilder.MergeAttribute("data-currentdisplayedrepeatinggroupsonpage", ((IList)htmlHelper.ViewData.Model).Count.ToString());
                hiddenElementTagBuilder.MergeAttribute("data-currentindex", (((IList)htmlHelper.ViewData.Model).Count - 1).ToString());
                hiddenElementTagBuilder.MergeAttribute("data-htmlfieldprefix", htmlFieldPrefix.ToString());
                //builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

                // Render tag

                var addButtonTagBuilder = new TagBuilder("input");
                addButtonTagBuilder.GenerateId("add" + idPrefix + propertyName);
                addButtonTagBuilder.Attributes.Add("type", "button");
                addButtonTagBuilder.Attributes.Add("value", "Add");
                addButtonTagBuilder.Attributes.Add("data-hiddenforelementid", "#hidden" + idPrefix);
                addButtonTagBuilder.Attributes.Add("data-placeholderelementid", "#RepeatGroupContainer" + idPrefix);

                outputTags.Append(hiddenElementTagBuilder.ToString(TagRenderMode.SelfClosing));
                outputTags.Append(addButtonTagBuilder.ToString(TagRenderMode.SelfClosing));
            }

            return MvcHtmlString.Create(outputTags.ToString());
        }


        public static MvcHtmlString RenderAddMoreButton<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            
            string propertyName = (string)htmlHelper.ViewData["PropertyName"];// ExpressionHelper.GetExpressionText(expression); //RepeatingGroup
            //string containerName = expression.Parameters[0].Type.Name;            //RepeatingGroupContainer

            int? maxValue = null;

            if (htmlHelper.ViewData.ContainsKey("MaxRepeats"))
                maxValue = (int)htmlHelper.ViewData["MaxRepeats"];//  ((MaximumRepeatGroupsAttribute)((MemberExpression)expression.Body).Member.GetCustomAttribute(typeof(MaximumRepeatGroupsAttribute), false)).Value;
            
            bool indexPresent = htmlHelper.ViewData.ContainsKey("Index");

            return RenderAddMoreButton<TModel>(htmlHelper, propertyName, maxValue, indexPresent);

            #region refactored
            //StringBuilder htmlFieldPrefix = GetHtmlFieldPrefix<TModel>(htmlHelper, "");  //Get HtmlPrefix that should be used for next repeatinggroup

            //string currentHtmlFieldPrefix = htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix;
            ////int currentIndexTag_Template = currentHtmlFieldPrefix.LastIndexOf('[');
            ////int currentIndex = 0;

            ////if (currentIndexTag_Template >= 0)
            ////    Int32.TryParse(currentHtmlFieldPrefix[currentIndexTag_Template + 1].ToString(), out currentIndex);

            //var idPrefix = currentHtmlFieldPrefix.Replace('.', '_');
            //idPrefix = idPrefix.Replace('[', '_');
            //idPrefix = idPrefix.Replace(']', '_');

            ////Could use Regex:
            ////Regex pattern = new Regex(@"[.\[\]]");
            ////var gggg = pattern.Replace(template, "_");
            
            //var outputTags = new StringBuilder();

            //if (!htmlHelper.ViewData.ContainsKey("Index"))
            //{
            //    var hiddenElementTagBuilder = new TagBuilder("input");
            //    // Create valid id
            //    hiddenElementTagBuilder.GenerateId("hidden" + idPrefix);

            //    // Add attributes
            //    hiddenElementTagBuilder.Attributes.Add("type", "hidden");
            //    //builder.MergeAttribute("data-container", rpContainer.GetType().Name);
            //    //hiddenElementTagBuilder.MergeAttribute("data-container", containerName);

            //    hiddenElementTagBuilder.MergeAttribute("data-property", propertyName);
            //    hiddenElementTagBuilder.MergeAttribute("data-maxpossiblevalue", maxValue.ToString());
            //    hiddenElementTagBuilder.MergeAttribute("data-currentdisplayedrepeatinggroupsonpage", ((IList)htmlHelper.ViewData.Model).Count.ToString());
            //    hiddenElementTagBuilder.MergeAttribute("data-currentindex", (((IList)htmlHelper.ViewData.Model).Count-1).ToString());
            //    hiddenElementTagBuilder.MergeAttribute("data-htmlfieldprefix", htmlFieldPrefix.ToString());
            //    //builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            //    // Render tag

            //    var addButtonTagBuilder = new TagBuilder("input");
            //    addButtonTagBuilder.GenerateId("add" + idPrefix + propertyName);
            //    addButtonTagBuilder.Attributes.Add("type", "button");
            //    addButtonTagBuilder.Attributes.Add("value", "Add");
            //    addButtonTagBuilder.Attributes.Add("data-hiddenforelementid", "#hidden" + idPrefix);
            //    addButtonTagBuilder.Attributes.Add("data-placeholderelementid", "#RepeatGroupContainer" + idPrefix);
            
            //    outputTags.Append(hiddenElementTagBuilder.ToString(TagRenderMode.SelfClosing));
            //    outputTags.Append(addButtonTagBuilder.ToString(TagRenderMode.SelfClosing));
            //}

            //return MvcHtmlString.Create(outputTags.ToString());
            #endregion
        }


        public static MvcHtmlString NestedEditorFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,Expression<Func<TModel,TValue>> expression,string templateName, string htmlPrefixField)
        {
            string propertyName = ExpressionHelper.GetExpressionText(expression).Substring(4);

            int maxValue = ((MaximumRepeatGroupsAttribute)((MemberExpression)expression.Body).Member.GetCustomAttribute(typeof(MaximumRepeatGroupsAttribute))).Value;

            var viewData = new ViewDataDictionary(htmlHelper.ViewData);


            viewData.Remove("Index");
            viewData.Remove("PropertyName");
            viewData.Remove("MaxRepeats");

            viewData.Add("Test", "Hello");

            viewData.Add("PropertyName", propertyName);
            viewData.Add("MaxRepeats", maxValue);

            if (htmlHelper.ViewData.ContainsKey("PropertyName"))
                htmlHelper.ViewData.Remove("PropertyName");
            htmlHelper.ViewData.Add("PropertyName", propertyName);


            if (htmlHelper.ViewData.ContainsKey("MaxRepeats"))
                htmlHelper.ViewData.Remove("MaxRepeats");
            htmlHelper.ViewData.Add("MaxRepeats", maxValue);

            //htmlHelper.ViewData = viewData;
            //var x = expression.Compile()(htmlHelper.ViewData.Model);
            return EditorExtensions.EditorFor(htmlHelper, expression, templateName, htmlPrefixField);

            
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