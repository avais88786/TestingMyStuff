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
                                            Text = "Dry Charged",
                                            ABICode = "B638 005"
                                        },
                                        new CodeListBase(){
                                            Id = 2,
                                            Text = "Dual Supply",
                                            ABICode = "B638 004"
                                        },new CodeListBase(){
                                            Id = 3,
                                            Text = "Public Mains",
                                            ABICode = "B638 001"
                                        },new CodeListBase(){
                                            Id = 4,
                                            Text = "Pumps & Tanks",
                                            ABICode = "B638 002"
                                        },new CodeListBase(){
                                            Id = 5,
                                            Text = "Single Supply",
                                            ABICode = "B638 003"
                                        }
            };
        }

    
    }
}
