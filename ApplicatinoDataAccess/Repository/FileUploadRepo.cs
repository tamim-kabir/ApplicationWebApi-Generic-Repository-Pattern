using ApplicationEntitiesLib.Employee;
using CRUD.DBContexts;


namespace ApplicatinoDataAccess.Repository
{
    public class FileUploadRepo : BaseRepo<EmployeeImagesModel, ApplicationDBContext>
    {
        public FileUploadRepo(ApplicationDBContext context) : base(context)
        {

        }
    }



}
