using System;
using System.Collections.Generic;
using System.Text;

namespace TIQRI.EMP.ApplicationCore.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
