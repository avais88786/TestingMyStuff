﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMCollapse.Models
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
    }
}
