using OTOMCollapse.Infrastructure;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Web.Mvc;


namespace OTOMCollapse.Models.ViewModels.PropertyOwners
{
    //public class PropertyDetailsGroupViewModel : RepeatGroupContainer
    //{
    //    private Dictionary<string, Type> propertyTypeMap = new Dictionary<string, Type>() { { "Properties", typeof(PropertyRepeatGroup) } };

    //    public PropertyDetailsGroupViewModel()
    //    {
    //        Properties = new List<PropertyRepeatGroup>();

    //        for (var i = 0; i < this.GetMaxRepeatGroupValueOf(model => model.Properties); i++)
    //        {
    //            Properties.Add(new PropertyRepeatGroup());
    //        }
    //    }

    //    [UIHint("PropertyRepeatGroup")]
    //    [MaximumRepeatGroups(10)]
    //    public IList<PropertyRepeatGroup> Properties { get; set; }

    //    public RepeatGroupBase GetPropertyType(string propertyName)
    //    {
    //        return (RepeatGroupBase)Activator.CreateInstance(propertyTypeMap[propertyName]);
    //    }


    //    public string GetTemplateName(string forProperty)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
