using OTOMCollapse.Infrastructure;
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
        //private Dictionary<string, Type> propertyTypeMap = new Dictionary<string, Type>() {{ "TestRepeatGroups", typeof(TestRepeatGroup) }};

        public SubsidiaryRepeatGroup()
        {
            TestRepeatGroups = new List<TestRepeatGroup>(){new TestRepeatGroup()};
            //for (int i = 0; i < 10; i++)
            //{
            //    TestRepeatGroups.Add(new TestRepeatGroup());
            //}
        }

        public string CompanyName { get; set; }

        public string EmployersReferenceNumber { get;set; }

        [UIHint("Address")]
        public Address AddressInformation { get; set; }

        [UIHint("TestRepeatGroup")]
        [MaximumRepeatGroups(5)]
        public IList<TestRepeatGroup> TestRepeatGroups { get; set; }

        public RepeatGroupBase GetPropertyType(string propertyName)
        {
            return (RepeatGroupBase)Activator.CreateInstance(this.GetType().GetProperty(propertyName).PropertyType);
        }


        public string GetTemplateName(string forProperty)
        {
            string templateName = ((UIHintAttribute)this.GetType().GetProperty(forProperty).GetCustomAttributes(typeof(UIHintAttribute), false).FirstOrDefault()).UIHint;

            return templateName;
        }

        public override IEnumerable<RepeatGroupBase> RepeatGroupProperty
        {
            get { return new List<SubsidiaryRepeatGroup>(){new SubsidiaryRepeatGroup()}.Cast<RepeatGroupBase>(); }
        }
    }
}
