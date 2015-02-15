using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTOMCollapse.Models.RepeatGroups
{
    public class TestRepeatGroupNested1 : RepeatGroupBase
    {
        public string TestRepeatGroupNestedProperty1 { get; set; }

        public override RepeatGroupBase RepeatGroupProperty
        {
            get { return this; }
        }
    }
}
