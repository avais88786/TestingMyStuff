using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMCollapse.Models.RepeatGroups
{
    public abstract class RepeatGroupContainer
    {
        public abstract RepeatGroupBase GetProperty(int i);
    }
}
