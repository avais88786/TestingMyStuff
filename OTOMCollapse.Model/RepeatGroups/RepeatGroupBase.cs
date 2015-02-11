using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTOMCollapse.Models.RepeatGroups
{
    public interface RepeatGroupBase
    {
        IList<RepeatGroupBase> repeatGroupBase { get;}
    }
}
