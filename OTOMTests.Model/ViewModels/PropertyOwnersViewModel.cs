using OTOMTests.Models.RepeatGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OTOMTests.Infrastructure;
using System.Web.Mvc;
using OTOMTests.Model.ViewModels;

namespace OTOMTests.Models.ViewModels
{
    //public class ConstructionType
    //{

    //}

    //public class PropertyOwnersViewModel
    //{
    //    public IList<SelectListItems> ConstructionTypes { get; set; }

    //    @Html.SelectListFor(x => x.ConstructionTypes)

    //    Mapper.CreateMap<PropertyOwnersViewModel,PropertyOwners>()
    //        .ForMember(ConstructionType => constructiontyperepo.GetItem(ConstructionTypes.Selected.Id)); 
    //}

    public class PropertyOwnersViewModel
    {
        public PropertyOwnersViewModel()
        {
            Properties = new List<PropertyRepeatGroup>();
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
        [MaximumPropertyRepeatGroups(15)]
        public IList<PropertyRepeatGroup> Properties { get; set; }

        [UIHint("TestRepeatGroup")]
        [MaximumPropertyRepeatGroups(2)]
        public IEnumerable<TestRepeatGroup> TestProperty { get; set; }


    }
}