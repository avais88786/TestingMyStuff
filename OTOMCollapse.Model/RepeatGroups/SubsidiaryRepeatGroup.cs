using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMCollapse.Models.RepeatGroups
{
    public class SubsidiaryRepeatGroup : RepeatGroupBase,RepeatGroupContainer
    {
        public SubsidiaryRepeatGroup()
        {
            TestRepeatGroups = new List<TestRepeatGroup>();
            for (int i = 0; i < 10; i++)
            {
                TestRepeatGroups.Add(new TestRepeatGroup());
            }
        }

        public string CompanyName { get; set; }

        public string EmployersReferenceNumber { get;set; }

        [UIHint("TestRepeatGroup")]
        public IList<TestRepeatGroup> TestRepeatGroups { get; set; }

        public override RepeatGroupBase RepeatGroupProperty
        {
            get
            {
                return base.RepeatGroupProperty;
            }
            set
            {
                base.RepeatGroupProperty = value;
            }
        }

        public RepeatGroupBase GetProperty(int i)
        {
            return TestRepeatGroups[i].RepeatGroupProperty = TestRepeatGroups[i];

        }
    }
}
