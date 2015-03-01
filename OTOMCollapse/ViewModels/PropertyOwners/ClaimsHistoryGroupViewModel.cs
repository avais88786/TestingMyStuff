using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace OTOMCollapse.Models.ViewModels.PropertyOwners
{
    public class ClaimsHistoryGroupViewModel
    {
        [Display(Name="Have there been any losses or incidents giving rise to losses in the last 5 years?")]
        public bool LossesIn5Years { get; set; }
    }
}
