using OTOMCollapse.Models.RepeatGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OTOMCollapse.Infrastructure;
using System.Web.Mvc;
using OTOMCollapse.Infrastructure.Infrastructure;

namespace OTOMCollapse.Models.ViewModels.PropertyOwners
{
    public class PropertyOwnersViewModel
    {
        private Dictionary<string, Type> propertyMapping = new Dictionary<string, Type>() { 
        { "StandardQuestionsGroupViewModel", typeof(StandardQuestionsGroupViewModel) },
        { "SubsidiaryRepeatGroup", typeof(SubsidiaryRepeatGroup) } ,
        {"TestRepeatGroup",typeof(TestRepeatGroup)}
        };

        public PropertyOwnersViewModel()
        {
           
            //for (var i = 0; i < x; i++)
            //{
            //    Properties.Add(new PropertyRepeatGroup());
            //}

            DeclarationQuestions = new DeclarationQuestionsGroupViewModel();
            StandardQuestions = new StandardQuestionsGroupViewModel();
            PropertyDetailsQuestions = new PropertyDetailsGroupViewModel();
            GeneralCoversQuestions = new GeneralCoversGroupViewModel();
            ClaimsHistoryQuestions = new ClaimsHistoryGroupViewModel();
        }

       // public ConstructionType ConstructionType { get; set; }

        public int PropertyOwnersId { get; set; }

        [UIHint("DeclarationQuestions")]
        [Display(Name="Declaration Questions")]
        public DeclarationQuestionsGroupViewModel DeclarationQuestions { get; set; }

        [UIHint("StandardQuestions")]
        [Display(Name = "Standard Questions")]
        public StandardQuestionsGroupViewModel StandardQuestions { get; set; }

        [Required]
        public string ProposerName { get; set; }

        [UIHint("PropertyDetailsQuestions")]
        [Display(Name="Property Details")]
        public PropertyDetailsGroupViewModel PropertyDetailsQuestions { get; set; }

         [UIHint("GeneralCoverQuestions")]
        [Display(Name="General Covers")]
        public GeneralCoversGroupViewModel GeneralCoversQuestions { get; set; }

         [UIHint("ClaimsHistoryQuestions")]
        [Display(Name = "Claims History")]
        public ClaimsHistoryGroupViewModel ClaimsHistoryQuestions { get; set; }

        [Required]
        public string CompanyStatus { get; set; }

        [CodeListName("Trades")]
        public IList<SelectListItem> CompanyStatuses { get; set; }

        [Required]
        public string Trade { get; set; }

        [CodeListName("Sprinklers")]
        public IList<SelectListItem> Trades { get; set; }




        public RepeatGroupContainer GetRepeatGroupContainerType(string container)
        {
            var type = propertyMapping[container];
            return (RepeatGroupContainer)Activator.CreateInstance(type);
        }
    }
}