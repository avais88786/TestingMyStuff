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


        public static int MaxRepeatGroupValue<TModel, TType>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TType>> expression,string propertyName)
        {
            //var x = ((MaximumPropertyRepeatGroupsAttribute)expression.Body.Type.GetCustomAttributes(typeof(MaximumPropertyRepeatGroupsAttribute), false).SingleOrDefault()).MaxPRGValue;

            var attr = ((MaximumPropertyRepeatGroupsAttribute)expression.Parameters[0].Type.GetProperty(propertyName).GetCustomAttributes(typeof(MaximumPropertyRepeatGroupsAttribute), false).SingleOrDefault()).MaxPRGValue;
            //expression.
            return attr;
        }
    }
}