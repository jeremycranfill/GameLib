﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Data
{

    public interface IUnitOfWork
    {
        Task Complete();
    }
}
