using OTOMCollapse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMCollapse.StubRepository
{
    public class CompanyStatusRepository:ICompanyStatusRepository
    {
        public List<CodeListBase> GetAll()
        {
            return new List<CodeListBase>() {new CodeListBase() 
                                                { Id = 1,
                                                  Text = "Charity",
                                                  ABICode = "B646 009"
                                                },
                                              new CodeListBase()
                                                { Id = 2,
                                                  Text = "Club",
                                                  ABICode = "B646 010"
                                                },
                                              new CodeListBase()
                                                { Id = 3,
                                                  Text = "Company Trading As",
                                                  ABICode = "B646 013"
                                                },
                                              new CodeListBase()
                                                { Id = 4,
                                                  Text = "Individual Trading As",
                                                  ABICode = "B646 014"
                                                },
                                              new CodeListBase()
                                                { Id = 5,
                                                  Text = "Limited",
                                                  ABICode = "B646 001"
                                                },
                                              new CodeListBase()
                                                { Id = 6,
                                                  Text = "Limited Liability Partnership",
                                                  ABICode = "B646 011"
                                                },
                                              new CodeListBase()
                                                { Id = 7,
                                                  Text = "Partnership",
                                                  ABICode = "B646 002"
                                                },
                                              new CodeListBase()
                                                { Id = 8,
                                                  Text = "Private Unlimited",
                                                  ABICode = "B646 018"
                                                },
                                              new CodeListBase()
                                                { Id = 9,
                                                  Text = "Public Limited",
                                                  ABICode = "B646 004"
                                                },
                                              new CodeListBase()
                                                { Id = 10,
                                                  Text = "Religious Organisation",
                                                  ABICode = "B646 005"
                                                },
                                              new CodeListBase()
                                                { Id = 11,
                                                  Text = "Society",
                                                  ABICode = "B646 007"
                                                },
                                              new CodeListBase()
                                                { Id = 12,
                                                  Text = "Sole Proprietor",
                                                  ABICode = "B646 003"
                                                }
                                               };
        }
    }
}
