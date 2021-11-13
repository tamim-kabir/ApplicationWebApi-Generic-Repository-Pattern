using ApplicationEntitiesLib.Employee;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DBContexts
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<EmployeeImagesModel> EmployeeImages { get; set; }
    }
}
