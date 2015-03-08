using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

using OTOMCollapse.Infrastructure;

namespace OTOMCollapse.Models.ViewModels.PropertyOwners
{
    //public class StandardQuestionsGroupViewModel : RepeatGroupContainer
    //{
    //    //private Dictionary<string, Type> propertyTypeMap = new Dictionary<string, Type>() { 
    //    //{ "SubsidiaryCompanies", typeof(SubsidiaryRepeatGroup) }, 
    //    //{ "TestRepeatGroups", typeof(TestRepeatGroup) } 
    //    //};

    //    //public StandardQuestionsGroupViewModel()
    //    //{
    //    //    SubsidiaryCompanies = new List<SubsidiaryRepeatGroup>();
    //    //    //for (int i=0;i< this.GetMaxRepeatGroupValueOf(model => model.SubsidiaryCompanies); i++)
    //    //    //{
    //    //    //    SubsidiaryCompanies.Add(new SubsidiaryRepeatGroup());
    //    //    //}
            
    //    //}

    //    //[Range(0,double.MaxValue)]
    //    //public decimal TargetPremium { get; set; }

    //    //public string TradingName { get; set; }

    //    //[UIHint("SubsidiaryCompanyRepeatGroup")]
    //    //[MaximumRepeatGroups(10)]
    //    //public IList<SubsidiaryRepeatGroup> SubsidiaryCompanies { get; set; }


    //    //[UIHint("TestRepeatGroup")]
    //    //[MaximumRepeatGroups(5)]
    //    //public IList<TestRepeatGroup> TestRepeatGroups { get; set; }

    //    //public RepeatGroupBase GetPropertyType(string propertyName)
    //    //{
    //    //    return (RepeatGroupBase)Activator.CreateInstance(this.GetType().GetProperty(propertyName).PropertyType.GetGenericArguments()[0]);
    //    //    //return (RepeatGroupBase)Activator.CreateInstance(propertyTypeMap[propertyName]);
    //    //}


    //    //public string GetTemplateName(string forProperty)
    //    //{
    //    //    string templateName = ((UIHintAttribute)this.GetType().GetProperty(forProperty).GetCustomAttributes(typeof(UIHintAttribute), false).FirstOrDefault()).UIHint;

    //    //    return templateName;
    //    //}
    //}
}
