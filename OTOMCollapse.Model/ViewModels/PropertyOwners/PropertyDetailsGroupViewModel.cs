using OTOMCollapse.Infrastructure;
using OTOMCollapse.Models.RepeatGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using OTOMCollapse.Models.Helpers;
using System.Linq.Expressions;
using System.Web.Mvc;


namespace OTOMCollapse.Models.ViewModels.PropertyOwners
{
    public class PropertyDetailsGroupViewModel : RepeatGroupContainer
    {
        public PropertyDetailsGroupViewModel()
        {
            Properties = new List<PropertyRepeatGroup>();

            for (var i = 0; i < this.GetMaxRepeatGroupValueOf(model => model.Properties); i++)
            {
                Properties.Add(new PropertyRepeatGroup());
            }
        }

        [UIHint("PropertyRepeatGroup")]
        [MaximumRepeatGroups(10)]
        public List<PropertyRepeatGroup> Properties { get; set; }

        //public MvcHtmlString test<TModel>(this HtmlHelper<TModel> htmlHelper, Type type)
        //{
        //    var item = Expression.Parameter(typeof(TModel));
        //    var m = Expression.Property(item, "");

        //    //var propertyInfo = model.GetType().GetProperty(PropertyNameToInvoke);
        //    // var prop = Expression.Property(item, propertyInfo, new[] { Expression.Constant(index) });
        //    var args = new Expression[] { Expression.Constant(0) };



        //    var y = Expression.MakeIndex(m, typeof(List<PropertyRepeatGroup>).GetProperty("Item"), new[] { Expression.Constant(0) });

        //    //prop.

        //    //Type type = model.GetType();

        //    //then lambda
        //    var lambda = Expression.Lambda<Func<TModel, PropertyRepeatGroup>>(y, item);


        //    //System.Web.Mvc.Html.EditorExtensions.EditorFor(htmlHelper,)
        //    System.Web.Mvc.Html.EditorExtensions.EditorFor(htmlHelper, lambda);
        //    return null;

        //    //return System.Web.Mvc.Html.EditorExtensions.EditorFor(htmlHelper,null);
        //}


        public override RepeatGroupBase GetProperty(int i)
        {
            return this.Properties[i].RepeatGroupProperty = this.Properties[i];
        }
    }
}
