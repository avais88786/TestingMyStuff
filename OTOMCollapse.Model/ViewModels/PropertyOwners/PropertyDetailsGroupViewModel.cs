using OTOMCollapse.Infrastructure;
using OTOMCollapse.Models.RepeatGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using OTOMCollapse.Models.Helpers;


namespace OTOMCollapse.Models.ViewModels.PropertyOwners
{
    public class PropertyDetailsGroupViewModel
    {
        public PropertyDetailsGroupViewModel()
        {
            Properties = new List<PropertyRepeatGroup>();

            for (var i = 0; i < this.GetMaxRepeatGroupValueOf(model => model.Properties); i++)
            {
                Properties.Add(new PropertyRepeatGroup());
            }
        }

        [UIHint("PropertyRepeatGroup")]
        [MaximumRepeatGroups(10)]
        public IList<PropertyRepeatGroup> Properties { get; set; }
    }
}
