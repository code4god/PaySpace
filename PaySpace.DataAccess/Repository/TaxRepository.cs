﻿using PaySpace.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaySpace.DataAccess
{
    public class TaxRepository : ITaxRepository
    {
        private readonly PaySpaceContext _context;
        public TaxRepository(PaySpaceContext paySpaceContext)
        {
            _context = paySpaceContext;
        }
        public void Add(Tax tax)
        {
            _context.Add(tax);
        }

        public void Find(int Id)
        {
            _context.Taxes.Where(x => x.Id == Id);
        }

        public void Remove(Tax tax)
        {
            _context.Remove(tax);
        }
    }
}