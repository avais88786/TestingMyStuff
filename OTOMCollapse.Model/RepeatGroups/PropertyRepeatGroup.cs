using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using OTOMCollapse.Infrastructure;
using System.Web.Mvc;
using OTOMCollapse.Models.Helpers;

namespace OTOMCollapse.Models.RepeatGroups
{
    //public class PropertyRepeatGroup : RepeatGroupBase
    //{
        
    //    public PropertyRepeatGroup()
    //    {
    //        Location = new List<SprinklerCodeList>();

    //        for (int i = 0; i < this.GetMaxRepeatGroupValueOf(model => model.Location) ; i++) 
    //        {
    //            Location.Add(new SprinklerCodeList());
    //        }
            
    //    }

    //    public PropertyRepeatGroup(List<SelectListItem> list)
    //    {
    //        Location = new List<SprinklerCodeList>();
    //        PropertyLocations = list;
    //    }

    //    [Editable(false)]
    //    public int PropertyId { get; set; }

    //    public int PropertyType { get; set; }

    //    public decimal PropertyPercentage { get; set; }

    //    public DateTime PurchaseDate { get; set; }

    //    public DateTime YearBuilt { get; set; }

    //    public IList<int> PropertyLocationId { get; set; }

    //    public IList<SelectListItem> PropertyLocations { get; set; }

    //    [UIHint("LocationRepeatGroup")]
    //    [MaximumRepeatGroups(5)]
    //    public IList<SprinklerCodeList> Location { get; set; }

    //    [UIHint("Address")]
    //    public Address Address { get; set; }

    //    public override RepeatGroupBase RepeatGroupProperty
    //    {
    //        get
    //        {
    //            return this;
    //        }
            
    //    }

    //}

}
