﻿using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Repository
{
    public interface ISupplierRepository
    {
        void Add(Supplier supplier);

        IList<Supplier> GetAll();

        void Update(Supplier supplier);

        void Delete(Supplier supplier);
    }
}
