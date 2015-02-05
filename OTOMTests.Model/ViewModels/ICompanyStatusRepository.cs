using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMTests.Models
{
    public interface ICompanyStatusRepository
    {
        List<CompanyStatus> GetAll();
    }
}
