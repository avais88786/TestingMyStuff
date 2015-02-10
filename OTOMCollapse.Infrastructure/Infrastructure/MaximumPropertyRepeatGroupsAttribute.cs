using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OTOMCollapse.Infrastructure
{
    public class MaximumRepeatGroupsAttribute : ValidationAttribute
    {
        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
        }

        public MaximumRepeatGroupsAttribute(int value)
        {
            _value = value;
        }

        protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }
    }
}