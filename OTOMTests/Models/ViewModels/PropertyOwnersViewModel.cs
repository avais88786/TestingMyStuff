using OTOMTests.Models.RepeatGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTOMTests.Models.ViewModels
{
    public class PropertyOwnersViewModel
    {
        public int PropertyOwnersId;

        public string ProposerName { get; set; }

        public DateTime DatePropertyBuild { get; set; }

        public IEnumerable<PropertyRepeatGroup> Property { get; set; }
    }
}