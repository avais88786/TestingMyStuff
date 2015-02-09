using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using OTOMTests.Model.RepeatGroups;
using OTOMTests.Infrastructure;
using System.Web.Mvc;

namespace OTOMTests.Models.RepeatGroups
{
    public class PropertyRepeatGroup : RepeatGroupBase
    {
        
        public PropertyRepeatGroup()
        {
            Location = new List<Location>();
        }

        public PropertyRepeatGroup(List<SelectListItem> list)
        {
            Location = new List<Location>();
            PropertyLocations = list;
        }

        [Editable(false)]
        public int PropertyId { get; set; }

        public int PropertyType { get; set; }

        public decimal PropertyPercentage { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime YearBuilt { get; set; }

        public IList<int> PropertyLocationId { get; set; }

        public IList<SelectListItem> PropertyLocations { get; set; }

        [UIHint("LocationRepeatGroup")]
        [MaximumPropertyRepeatGroups(5)]
        public IList<Location> Location { get; set; }

        [UIHint("Address")]
        public Address Address { get; set; }
    }

}
