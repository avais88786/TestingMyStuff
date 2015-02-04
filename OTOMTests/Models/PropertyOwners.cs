using OTOMTests.Models.RepeatGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OTOMTests.Infrastructure;

namespace OTOMTests.Models
{
    public class PropertyOwners
    {
        public PropertyOwners()
        {
            Property = new List<PropertyRepeatGroup>();
        }

        private int _propertyOwnersId;

        public int PropertyOwnersId
        {
            get { return _propertyOwnersId; }
            set { _propertyOwnersId = value; }
        }

        private string _proposerName;

        public string ProposerName
        {
            get { return _proposerName; }
            set { _proposerName = value; }
        }

        private DateTime _datePropertyBuilt;

        public DateTime DatePropertyBuilt
        {
            get { return _datePropertyBuilt; }
            set { _datePropertyBuilt = value; }
        }

        private IEnumerable<PropertyRepeatGroup> _property;

        [UIHint("PropertyRepeatGroup")]
        [MaximumPropertyRepeatGroups(5)]
        public IEnumerable<PropertyRepeatGroup> Property
        {
            get { return _property; }
            set { _property = value; }
        }

    }
}