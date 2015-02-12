using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMCollapse.Infrastructure.Infrastructure
{
    public class CodeListNameAttribute : Attribute
    {
        public string CodeListName { get; set; }

        public CodeListNameAttribute(string codeListName)
        {
            CodeListName = codeListName;
        }

    }
}
