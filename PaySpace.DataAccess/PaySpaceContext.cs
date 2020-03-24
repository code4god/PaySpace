﻿using Microsoft.EntityFrameworkCore;
using PaySpace.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.DataAccess
{
    public class PaySpaceContext : DbContext
    {
        public PaySpaceContext(DbContextOptions<PaySpaceContext> options) 
            : base(options) 
        { 
        
        }

        public DbSet<Tax> Taxes { get; set; }
       

    }
}
