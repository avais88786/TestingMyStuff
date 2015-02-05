using OTOMTests.Models.RepeatGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OTOMTests.Infrastructure;

namespace OTOMTests.Models
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

    public class PropertyOwners
    {
        public PropertyOwners()
        {
            Property = new List<PropertyRepeatGroup>();
        }

       // public ConstructionType ConstructionType { get; set; }

        public int PropertyOwnersId { get; set; }

        public string ProposerName { get; set; }

        

        [UIHint("PropertyRepeatGroup")]
        [MaximumPropertyRepeatGroups(25)]
        public IEnumerable<PropertyRepeatGroup> Property { get; set; }
    }
}