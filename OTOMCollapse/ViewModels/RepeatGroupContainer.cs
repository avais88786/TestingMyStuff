using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMCollapse.ViewModels
{
    public interface IRepeatGroupContainer
    {
        //string propertyName { get; set; }
        RepeatGroupBase GetPropertyType(string propertyName);
    }
}
