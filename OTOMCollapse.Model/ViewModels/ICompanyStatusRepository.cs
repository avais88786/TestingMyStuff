using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMCollapse.Models.ViewModels
{
    public interface ICompanyStatusRepository
    {
        List<CodeListBase> GetAll();
    }
}
