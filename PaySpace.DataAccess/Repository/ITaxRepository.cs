﻿using PaySpace.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaySpace.DataAccess
{
    public interface ITaxRepository
    {
        void Add(Tax tax);
        void Remove(Tax tax);
        void Find(int Id);
    }
}