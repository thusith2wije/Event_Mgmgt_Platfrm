using System;
using System.Collections.Generic;
using System.Text;

namespace TIQRI.EMP.ApplicationCore.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}
