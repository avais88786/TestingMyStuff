﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMCollapse.Models.RepeatGroups
{
    public interface IRepeatGroupContainer
    {
        //string propertyName { get; set; }
        RepeatGroupBase GetPropertyType(string propertyName);
    }
}
