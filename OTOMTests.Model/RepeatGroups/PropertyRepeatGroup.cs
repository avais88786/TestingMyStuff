using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using OTOMTests.Model.RepeatGroups;
using OTOMTests.Infrastructure;

namespace OTOMTests.Models.RepeatGroups
{
    public class PropertyRepeatGroup
    {
        public PropertyRepeatGroup()
        {
            Location = new List<Location>();
        }

        [Editable(false)]
        public int PropertyId { get; set; }

        public int PropertyType { get; set; }

        public decimal PropertyPercentage { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime YearBuilt { get; set; }

        [UIHint("LocationRepeatGroup")]
        [MaximumPropertyRepeatGroups(5)]
        public IList<Location> Location { get; set; }

        [UIHint("Address")]
        public Address Address { get; set; }
    }
}
