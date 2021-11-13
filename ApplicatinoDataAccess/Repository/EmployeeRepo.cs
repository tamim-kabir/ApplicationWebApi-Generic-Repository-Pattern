using ApplicationEntitiesLib.Employee;
using CRUD.DBContexts;

namespace ApplicatinoDataAccess.Repository
{
    public class EmployeeRepo : BaseRepo<EmployeeModel, ApplicationDBContext>
    {
        public EmployeeRepo(ApplicationDBContext context):  base(context)
        {
        }

        //Emplement the employee repo code hare


    }
}
