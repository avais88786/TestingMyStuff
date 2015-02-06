using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using StructureMap.Configuration.DSL;
using OTOMTests.Models;
using OTOMTests.StubRepository;
using OTOMTests.Model;
using OTOMTests.Model.RepeatGroups;

namespace OTOMTests.DependenyResolver
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(scan =>
            {
                For<ICompanyStatusRepository>().Use<CompanyStatusRepository>();
                For<IRepository<Location>>().Use<StubLocationRepository>();
            });
        }
    }
}
