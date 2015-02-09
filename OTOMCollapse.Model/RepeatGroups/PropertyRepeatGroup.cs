﻿using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using OTOMCollapse.Infrastructure;
using System.Web.Mvc;

namespace OTOMCollapse.Models.RepeatGroups
{
    public class PropertyRepeatGroup : RepeatGroupBase
    {
        
        public PropertyRepeatGroup()
        {
            Location = new List<Location>();

            for (int i = 0; i < 5; i++) 
            {
                Location.Add(new Location());
            }
        }

        public PropertyRepeatGroup(List<SelectListItem> list)
        {
            Location = new List<Location>();
            PropertyLocations = list;
        }

        [Editable(false)]
        public int PropertyId { get; set; }

        public int PropertyType { get; set; }

        public decimal PropertyPercentage { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime YearBuilt { get; set; }

        public IList<int> PropertyLocationId { get; set; }

        public IList<SelectListItem> PropertyLocations { get; set; }

        [UIHint("LocationRepeatGroup")]
        [MaximumRepeatGroups(5)]
        public IList<Location> Location { get; set; }

        [UIHint("Address")]
        public Address Address { get; set; }
    }

}