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

namespace OTOMCollapse.ViewModels.PropertyOwners
{
    [Serializable]
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
            SubsidaryCompanies = new List<SubsidiaryRepeatGroup>() { new SubsidiaryRepeatGroup() };
            SelectListItem = new SelectListItem() { Text = "asasa", Value = "nfgkjl" };
                //, new SubsidiaryRepeatGroup() , new SubsidiaryRepeatGroup(), new SubsidiaryRepeatGroup(), new SubsidiaryRepeatGroup(), new SubsidiaryRepeatGroup(), new SubsidiaryRepeatGroup(), new SubsidiaryRepeatGroup(), new SubsidiaryRepeatGroup(), new SubsidiaryRepeatGroup() };
            //TestRepeatGroups = new List<NestedRepeatGroup>() { new NestedRepeatGroup() };
        }

       // public ConstructionType ConstructionType { get; set; }

        public SelectListItem SelectListItem { get; set; }

        //[UIHint("SubsidiaryContainer")]
        //public SubsidaryRepeatGroupContainer SubsidaryContainer { get; set; }

        [MaximumRepeatGroups(15)]
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
    }

    public class PropertyOwnersViewModelContainer : IValidatableObject
    {
        public PropertyOwnersViewModelContainer()
        {
            PropertyOwnersViewModel = new PropertyOwnersViewModel();
        }

        [CustomValidation]
        public PropertyOwnersViewModel PropertyOwnersViewModel { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new HashSet<ValidationResult>();
            bool x = Validator.TryValidateObject(this, validationContext, validationResults,true);
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
            IEnumerable<PropertyInfo> properties = value.GetType().
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
                    object propertyValue = property.GetValue(value, null);
                    if (!validationAttribute.IsValid(propertyValue))
                    {
                        // Return false if one value is found to be invalid.
                        return false;
                    }
                }
            }
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