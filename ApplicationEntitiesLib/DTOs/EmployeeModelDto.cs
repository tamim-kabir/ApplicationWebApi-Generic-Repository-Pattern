using ApplicationEntitiesLib.Employee;

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
