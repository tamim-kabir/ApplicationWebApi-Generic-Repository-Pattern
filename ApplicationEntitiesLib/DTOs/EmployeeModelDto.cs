using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicatinoDataAccess.DTOs
{
    public class EmployeeModelDto
    {
        public int ID { get; set; }
        public string EmpName { get; set; }
        public string Occopation { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
