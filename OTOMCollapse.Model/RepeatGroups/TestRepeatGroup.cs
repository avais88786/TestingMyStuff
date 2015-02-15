using OTOMCollapse.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMCollapse.Models.RepeatGroups
{
    public class TestRepeatGroup : RepeatGroupBase,RepeatGroupContainer
    {
        public TestRepeatGroup()
        {
            TestRepeatGroupsNested1 = new List<TestRepeatGroupNested1>();
        }
        
        public string TestString { get; set; }

        public decimal TestDecimal { get; set; }

        [UIHint("TestRepeatGroupsNested1")]
        [MaximumRepeatGroups(3)]
        public IList<TestRepeatGroupNested1> TestRepeatGroupsNested1 { get; set; }

        public override RepeatGroupBase RepeatGroupProperty
        {
            get
            {
                return this;
            }
        }

        public RepeatGroupBase GetPropertyType(string propertyName)
        {
            return new TestRepeatGroupNested1();
        }

        public string GetTemplateName(string forProperty)
        {
            return "TestRepeatGroupsNested1";
        }
    }
}
