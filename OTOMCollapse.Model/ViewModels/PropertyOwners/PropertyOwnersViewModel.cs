using OTOMCollapse.Models.RepeatGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OTOMCollapse.Infrastructure;
using System.Web.Mvc;

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

        [UIHint("DeclarationQuestionsTemplate")]
        [Display(Name="Declaration Questions")]
        public DeclarationQuestionsGroupViewModel DeclarationQuestions { get; set; }

        [UIHint("StandardQuestionsTemplate")]
        [Display(Name = "Standard Questions")]
        public StandardQuestionsGroupViewModel StandardQuestions { get; set; }

        [Required]
        public string ProposerName { get; set; }

        [Display(Name="Property Details")]
        public PropertyDetailsGroupViewModel PropertyDetailsQuestions { get; set; }

        [Display(Name="General Covers")]
        public GeneralCoversGroupViewModel GeneralCoversQuestions { get; set; }

        [Display(Name = "Claims History")]
        public ClaimsHistoryGroupViewModel ClaimsHistoryQuestions { get; set; }

        public int CompanyStatus { get; set; }

        public IList<SelectListItem> CompanyStatuses { get; set; }

        public IList<SelectListItem> PropertyLocations { get; set; }

        

    }
}