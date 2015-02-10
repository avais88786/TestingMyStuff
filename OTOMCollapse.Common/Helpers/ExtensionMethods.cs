using OTOMCollapse.Models.RepeatGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMCollapse.Common.Helpers
{
    public class ExtensionMethods
    {
        public static int MaxRepeatGroupValue(this List<PropertyRepeatGroup> repeatingGroup)
        {
            Type type = repeatingGroup.GetType();

            return 1;
        }
    }
}
