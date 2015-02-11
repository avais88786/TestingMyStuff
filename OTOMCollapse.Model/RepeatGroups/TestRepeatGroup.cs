using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMCollapse.Models.RepeatGroups
{
    public class TestRepeatGroup : RepeatGroupBase
    {
        public string TestString { get; set; }

        public decimal TestDecimal { get; set; }

        IList<RepeatGroupBase> RepeatGroupBase.repeatGroupBase
        {
            get { throw new NotImplementedException(); }
        }
    }
}
