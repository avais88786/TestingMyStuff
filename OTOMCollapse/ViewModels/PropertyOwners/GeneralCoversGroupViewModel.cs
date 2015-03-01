using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace OTOMCollapse.Models.ViewModels.PropertyOwners
{
    public class GeneralCoversGroupViewModel
    {
        [Display(Name="Do you have any employees?")]
        public bool HasEmployees { get; set; }

        [Display(Name = "Do you require Property Owners Liability Cover?")]
        public bool RequirePropertyOwnersLiabilityCover { get; set; }
    }
}
