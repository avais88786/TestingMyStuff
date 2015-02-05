using OTOMTests.Models.RepeatGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OTOMTests.Infrastructure;

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
            Property = new List<PropertyRepeatGroup>();
        }

       // public ConstructionType ConstructionType { get; set; }

        public int PropertyOwnersId { get; set; }

        public string ProposerName { get; set; }

        public CompanyStatus CompanyStatus { get; set; }

        [UIHint("PropertyRepeatGroup")]
        [MaximumPropertyRepeatGroups(10)]
        public IEnumerable<PropertyRepeatGroup> Property { get; set; }
    }
}