using OTOMCollapse.Models;
using OTOMCollapse.Models.RepeatGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OTOMCollapse.StubRepository
{
    public class StubLocationRepository:IRepository<Location>
    {
        public IList<Location> GetAll()
        {
            return new List<Location>(){
                                        new Location(){
                                            Id = 1,
                                            Text = "Airside"
                                        },
                                        new Location(){
                                            Id = 2,
                                            Text = "Arcade"
                                        },new Location(){
                                            Id = 3,
                                            Text = "Below Ground Level"
                                        },new Location(){
                                            Id = 4,
                                            Text = "Block or Residential Flats"
                                        },new Location(){
                                            Id = 5,
                                            Text = "Business Park"
                                        },new Location(){
                                            Id = 6,
                                            Text = "By Door"
                                        },new Location(){
                                            Id = 7,
                                            Text = "Commercial Premises"
                                        }
            };
        }

    
    }
}
