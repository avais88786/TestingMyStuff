using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OTOMCollapse.Infrastructure;
using System.Web.Mvc;
using OTOMCollapse.Infrastructure.Infrastructure;
using System.Collections;
using OTOMCollapse.ViewModels.RepeatGroups;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace OTOMCollapse.ViewModels.PropertyOwners
{
    [Serializable]
    [DataContract()]
    public class PropertyOwnersViewModel : IRepeatGroupContainer
    {
        private Dictionary<string, Type> propertyMapping = new Dictionary<string, Type>() { 
        //{ "StandardQuestionsGroupViewModel", typeof(StandardQuestionsGroupViewModel) },
        //{ "SubsidiaryRepeatGroup", typeof(SubsidiaryRepeatGroup) } ,
        {"TestRepeatGroups",typeof(SubsidiaryRepeatGroup)},
        {"SubsidaryCompanies",typeof(PropertyOwnersViewModel)}
        };

        public PropertyOwnersViewModel()
        {
            SubsidaryCompanies = new List<SubsidiaryRepeatGroup>() { new SubsidiaryRepeatGroup(){CompanyName = "Company Name",EmployersReferenceNumber = "Emp Ref No",Id = 0} };
            //SelectListItem = new List<SelectListItem>() { new SelectListItem() { Text = "asasa", Value = "nfgkjl" }, new SelectListItem() { Text = "asasa2", Value = "nfgkjl2" } };
            //SubsidaryCompanies2 = new SubsidiaryRepeatGroup();
                //, new SubsidiaryRepeatGroup() , new SubsidiaryRepeatGroup(), new SubsidiaryRepeatGroup(), new SubsidiaryRepeatGroup(), new SubsidiaryRepeatGroup(), new SubsidiaryRepeatGroup(), new SubsidiaryRepeatGroup(), new SubsidiaryRepeatGroup(), new SubsidiaryRepeatGroup() };
            //TestRepeatGroups = new List<NestedRepeatGroup>() { new NestedRepeatGroup() };
        }

       // public ConstructionType ConstructionType { get; set; }

        //public List<SelectListItem> SelectListItem { get; set; }

        //[UIHint("SubsidiaryContainer")]
        //public SubsidaryRepeatGroupContainer SubsidaryContainer { get; set; }

        [MaximumRepeatGroups(15)]
        [CustomValidation]
        public List<SubsidiaryRepeatGroup> SubsidaryCompanies { get; set; }

        //[MaximumRepeatGroups(5)]
        //public IList<NestedRepeatGroup> TestRepeatGroups { get; set; }

        #region hidden

        //[UIHint("DeclarationQuestions")]
        //[Display(Name="Declaration Questions")]
        //public DeclarationQuestionsGroupViewModel DeclarationQuestions { get; set; }

        //[UIHint("StandardQuestions")]
        //[Display(Name = "Standard Questions")]
        //public StandardQuestionsGroupViewModel StandardQuestions { get; set; }

        //[Required]
        //public string ProposerName { get; set; }

        //[UIHint("PropertyDetailsQuestions")]
        //[Display(Name="Property Details")]
        //public PropertyDetailsGroupViewModel PropertyDetailsQuestions { get; set; }

        // [UIHint("GeneralCoverQuestions")]
        //[Display(Name="General Covers")]
        //public GeneralCoversGroupViewModel GeneralCoversQuestions { get; set; }

        // [UIHint("ClaimsHistoryQuestions")]
        //[Display(Name = "Claims History")]
        //public ClaimsHistoryGroupViewModel ClaimsHistoryQuestions { get; set; }

        ////[Required]
        //public string CompanyStatus { get; set; }

        //[CodeListName("Trades")]
        //public IList<SelectListItem> CompanyStatuses { get; set; }

        ////[Required]
        //public string Trade { get; set; }

        //[CodeListName("Sprinklers")]
        //public IList<SelectListItem> Trades { get; set; }

        #endregion


        public IRepeatGroupContainer GetRepeatGroupContainerType(string container)
        {
            var type = propertyMapping[container];
            return (IRepeatGroupContainer)Activator.CreateInstance(type);
        }

        public RepeatGroupBase GetPropertyType(string propertyName)
        {
            
            return (RepeatGroupBase)Activator.CreateInstance(this.GetType().GetProperty(propertyName).PropertyType.GetGenericArguments()[0]);
        }

        public List<T> Create<T>(T type)
        {
            return (List<T>)Activator.CreateInstance(typeof(List<T>));
        }

        public string GetTemplateName(string forProperty)
        {
            string templateName = ((UIHintAttribute)this.GetType().GetProperty(forProperty).GetCustomAttributes(typeof(UIHintAttribute), false).FirstOrDefault()).UIHint;

            return templateName;
        }


        public RepeatGroupBase GetPropertyType(Type thisType, string propertyName)
        {
            return null;
        }
    }

    
    [Serializable]
    public class PropertyOwnersViewModelContainer : IValidatableObject
    {
        public PropertyOwnersViewModelContainer()
        {
            PropertyOwnersViewModel = new PropertyOwnersViewModel();
        }

       
        public PropertyOwnersViewModel PropertyOwnersViewModel { get; set; }

       
        public string test { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new HashSet<ValidationResult>();
            bool x = Validator.TryValidateObject(PropertyOwnersViewModel, new ValidationContext(PropertyOwnersViewModel), validationResults, true);
            return validationResults;
        }

       
    }

    public class CustomValidationAttribute : ValidationAttribute
    {
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //     var validationResults = new HashSet<ValidationResult>();
        //     bool y = Validator.TryValidateObject(value, new ValidationContext(value), validationResults, true);

        //     if (!y)
        //     {
        //         return new ValidationResult("taaaaa error");
        //     }

        //     return ValidationResult.Success;
        //}

        public override bool IsValid(object value)
        {
            try
            {


                Type objectType = value.GetType();
                bool isList = false;
                if (value is IList && value.GetType().IsGenericType)
                {
                    objectType = value.GetType().GetGenericArguments()[0];
                    isList = true;
                }

                IEnumerable<PropertyInfo> properties = objectType.
                    GetProperties().Where(p => p.GetCustomAttributes(
                    typeof(ValidationAttribute), true).Count() > 0);
                foreach (PropertyInfo property in properties)
                {
                    // Validate each property.
                    IEnumerable<ValidationAttribute> validationAttributes =
                        property.GetCustomAttributes(typeof(ValidationAttribute),
                        true).Cast<ValidationAttribute>();
                    foreach (ValidationAttribute validationAttribute in
                        validationAttributes)
                    {

                        if (isList)
                        {
                            foreach (var item in (IList)value)
                            {
                                //value = item.GetType().GetProperty(property.Name).GetValue(item);
                                object propertyValue = property.GetValue(item, null);
                                if (!validationAttribute.IsValid(propertyValue))
                                {

                                    // Return false if one value is found to be invalid.
                                    return false;
                                }
                            }
                        }
                        else 
                        { 
                            object propertyValue = property.GetValue(value, null);
                            if (!validationAttribute.IsValid(propertyValue))
                                {
                            
                                    // Return false if one value is found to be invalid.
                                    return false;
                                }
                        }
                    }
                }
            }
            catch { }
            return true;
        }
        // If everything is valid, return true.
        
        }



    //public class SubsidaryRepeatGroupContainer : RepeatGroupContainer
    //{
    //    public SubsidaryRepeatGroupContainer()
    //    {
    //        SubsidiaryCompanies = new List<SubsidiaryRepeatGroup>() { new SubsidiaryRepeatGroup()};
    //    }
    //    [UIHint("SubsidiaryCompanyRepeatGroup")]
    //    [MaximumRepeatGroups(10)]
    //    public IList<SubsidiaryRepeatGroup> SubsidiaryCompanies { get; set; }


    //    public RepeatGroupBase GetPropertyType(string propertyName)
    //    {
    //        return new SubsidiaryRepeatGroup();
    //    }

    //    public string GetTemplateName(string forProperty)
    //    {
    //        return "SubsidiaryCompanyRepeatGroup";
    //    }
    //}
}