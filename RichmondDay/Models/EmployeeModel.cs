using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RichmondDay.Models
{
    public class EmployeeModel
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public System.Guid emp_id { get; set; }
    
}
}