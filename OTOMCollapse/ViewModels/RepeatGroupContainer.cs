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
        RepeatGroupBase GetPropertyType(Type thisType, string propertyName);
    }

    public abstract class RepeatGroupContainer : IRepeatGroupContainer
    {
        public RepeatGroupBase GetPropertyType(Type thisType,string propertyName)
        {
            return (RepeatGroupBase)Activator.CreateInstance(thisType.GetProperty(propertyName).PropertyType.GetGenericArguments()[0]);
        }

        public RepeatGroupBase GetPropertyType(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
