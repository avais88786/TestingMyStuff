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

        [CodeListName("CompanyStatuses")]
        public IList<SelectListItem> CompanyStatuses { get; set; }

        [Required]
        public string Sprinkler { get; set; }

        [CodeListName("Sprinklers")]
        public IList<SelectListItem> Sprinklers { get; set; }

    }
}