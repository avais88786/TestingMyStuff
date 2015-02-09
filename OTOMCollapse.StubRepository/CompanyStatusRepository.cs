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
        public List<CompanyStatus> GetAll()
        {
            return new List<CompanyStatus>() {new CompanyStatus() 
                                                { CompanyStatusId = 1,
                                                  CompanyStatusText = "Charity"
                                                },
                                              new CompanyStatus()
                                                { CompanyStatusId = 2,
                                                  CompanyStatusText = "Club"
                                                },
                                              new CompanyStatus()
                                                { CompanyStatusId = 3,
                                                  CompanyStatusText = "Company Trading As"
                                                },
                                              new CompanyStatus()
                                                { CompanyStatusId = 4,
                                                  CompanyStatusText = "Limited"
                                                }
                                               };
        }
    }
}
