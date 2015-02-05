using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace OTOMTests.Models.RepeatGroups
{
    public class PropertyRepeatGroup
    {
        [Editable(false)]
        public int PropertyId { get; set; }

        public int PropertyType { get; set; }

        public decimal PropertyPercentage { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime YearBuilt { get; set; }

        [UIHint("Address")]
        public Address Address { get; set; }
    }
}
