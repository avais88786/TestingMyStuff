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
            Properties = new List<PropertyRepeatGroup>();

            //for (var i = 0; i < x; i++)
            //{
            //    Properties.Add(new PropertyRepeatGroup());
            //}

            DeclarationQuestions = new DeclarationQuestionsGroupViewModel();
            StandardQuestions = new StandardQuestionsGroupViewModel();
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

        public int CompanyStatus { get; set; }

        public IList<SelectListItem> CompanyStatuses { get; set; }

        public IList<SelectListItem> PropertyLocations { get; set; }

        [UIHint("PropertyRepeatGroup")]
        [MaximumPropertyRepeatGroups(10)]
        public IList<PropertyRepeatGroup> Properties { get; set; }

    }
}