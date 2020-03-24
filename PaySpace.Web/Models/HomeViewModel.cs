﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySpace.Web.Models
{
    public class HomeViewModel
    {
        public decimal Income { get; set; }
        public decimal Amount { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<PostalCode> PostalCodes { get; set; }
    }

    public class PostalCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
    }
}