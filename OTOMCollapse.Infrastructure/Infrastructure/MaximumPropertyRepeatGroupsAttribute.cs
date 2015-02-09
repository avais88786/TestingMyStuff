﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OTOMCollapse.Infrastructure
{
    public class MaximumRepeatGroupsAttribute : ValidationAttribute
    {
        private int _maxPRGValue;
        public int MaxPRGValue
        {
            get
            {
                return _maxPRGValue;
            }
        }

        public MaximumRepeatGroupsAttribute(int value)
        {
            _maxPRGValue = value;
        }

        protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }
    }
}