using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace OTOMTests.Model.ViewModels
{
    public class StandardQuestionsGroupViewModel
    {
        [Range(0,double.MaxValue)]
        public decimal TargetPremium { get; set; }

        public string TradingName { get; set; }
    }
}
