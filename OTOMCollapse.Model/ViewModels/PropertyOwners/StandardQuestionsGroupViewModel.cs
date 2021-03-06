﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using OTOMCollapse.Models.RepeatGroups;
using OTOMCollapse.Models.Helpers;
using OTOMCollapse.Infrastructure;

namespace OTOMCollapse.Models.ViewModels.PropertyOwners
{
    public class StandardQuestionsGroupViewModel : RepeatGroupContainer
    {
        public StandardQuestionsGroupViewModel()
        {
            SubsidiaryCompanies = new List<SubsidiaryRepeatGroup>(){new SubsidiaryRepeatGroup()};
        }

        [Range(0,double.MaxValue)]
        public decimal TargetPremium { get; set; }

        public string TradingName { get; set; }

        [UIHint("SubsidiaryCompanyRepeatGroup")]
        [MaximumRepeatGroups(10)]
        public IList<SubsidiaryRepeatGroup> SubsidiaryCompanies { get; set; }

        public override RepeatGroupBase GetProperty(int i)
        {
            return this.SubsidiaryCompanies[i];
        }
    }
}
