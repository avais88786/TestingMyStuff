using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using StructureMap.Configuration.DSL;
using OTOMCollapse.Models;
using OTOMCollapse.StubRepository;
using OTOMCollapse.Models.ViewModels;
using OTOMCollapse.Models.RepeatGroups;


namespace OTOMCollapse.DependenyResolver
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(scan =>
            {
                For<ICompanyStatusRepository>().Use<CompanyStatusRepository>();
                For<IRepository<CodeListBase>>().Use<StubLocationRepository>();
            });
        }
    }
}
