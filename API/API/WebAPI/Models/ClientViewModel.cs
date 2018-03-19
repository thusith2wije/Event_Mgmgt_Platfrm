using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIQRI.EMP.WebAPI.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}
