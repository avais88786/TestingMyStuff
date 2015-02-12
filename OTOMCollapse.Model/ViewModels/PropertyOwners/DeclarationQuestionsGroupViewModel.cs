﻿using OTOMCollapse.Infrastructure.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace OTOMCollapse.Models.ViewModels.PropertyOwners
{
    public class DeclarationQuestionsGroupViewModel
    {
        [Display(Name="Do you agree to this question ?")]
        public bool Question1 { get; set; }

        [CodeListName("xyz")]
        [Display(Name = "Do you agree to this question atleast?")]
        public bool Question2 { get; set; }
    }
}
