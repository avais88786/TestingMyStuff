using OTOMCollapse.Infrastructure;
using OTOMCollapse.Models.RepeatGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace OTOMCollapse.Models.ViewModels.PropertyOwners
{
    public class PropertyDetailsGroupViewModel
    {
        public PropertyDetailsGroupViewModel()
        {
            Properties = new List<PropertyRepeatGroup>();

            for (var i = 0; i < 10; i++)
            {
                Properties.Add(new PropertyRepeatGroup());
            }
        }

        [UIHint("PropertyRepeatGroup")]
        [MaximumRepeatGroups(10)]
        public IList<PropertyRepeatGroup> Properties { get; set; }
    }
}
