﻿using OTOMTests.Models.RepeatGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMTests.Model
{
    public class PropertyOwners
    {
        public int PropertyOwnersId { get; set; }

        public string ProposerName { get; set; }

        public int CompanyStatus { get; set; }
        
        public IEnumerable<PropertyRepeatGroup> Property;




    }
}
