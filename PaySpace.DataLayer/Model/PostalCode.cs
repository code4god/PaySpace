using System;
using System.Collections.Generic;
using System.Text;

namespace PaySpace.DataLayer.Model
{
    public class PostalCode
    {
        public int Id { get; set; }
               
        public string Code { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
