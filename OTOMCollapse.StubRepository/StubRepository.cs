using OTOMCollapse.Models;
using OTOMCollapse.Models.RepeatGroups;
using OTOMCollapse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OTOMCollapse.StubRepository
{
    public class StubLocationRepository : IRepository<CodeListBase>
    {
        public IList<CodeListBase> GetAll()
        {
            //switch (codeListName)
            //{
            //    case ""
            //}

            return new List<CodeListBase>(){
                                        new CodeListBase(){
                                            Id = 1,
                                            Text = "Housing Association",
                                            ABICode = "B566 F60"
                                        },
                                        new CodeListBase(){
                                            Id = 2,
                                            Text = "Property Developer",
                                            ABICode = "B566 H73"
                                        },new CodeListBase(){
                                            Id = 3,
                                            Text = "Property Investment",
                                            ABICode = "B566 27B"
                                        },new CodeListBase(){
                                            Id = 4,
                                            Text = "Property Letting",
                                            ABICode = "B566 H74"
                                        },new CodeListBase(){
                                            Id = 5,
                                            Text = "Property Management",
                                            ABICode = "B566 328"
                                        },new CodeListBase(){
                                            Id = 6,
                                            Text = "Property Owner",
                                            ABICode = "B566 H75"
                                        },new CodeListBase(){
                                            Id = 7,
                                            Text = "Resident Association",
                                            ABICode = "B566 28B"
                                        }
            };
        }

    
    }
}
