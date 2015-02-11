using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTOMCollapse.Models.RepeatGroups
{
    public abstract class RepeatGroupBase
    {
        public string TemplateName { get; set; }
        public virtual RepeatGroupBase RepeatGroupProperty { get; set; }
    }
}
