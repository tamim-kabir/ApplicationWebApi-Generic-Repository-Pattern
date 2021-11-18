using ApplicatinoDataAccess.Repository;
using ApplicationEntitiesLib.DTOs;
using ApplicationEntitiesLib.Employee;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : BaseController<EmployeeImagesModel, FileUploadRepo, EmployeeImageDto>
    {
        private readonly IWebHostEnvironment _hostEnv;
        private readonly FileUploadRepo _frepo;

        public FileUploadController(IWebHostEnvironment Web, FileUploadRepo fileUploadRepo, IMapper mapper)
            : base(fileUploadRepo, mapper)
        {
            this._hostEnv = Web;
            this._frepo = fileUploadRepo;

        }

        [HttpPost]
        [Route("/UploadEmpImage")]
        public async Task<string> UploadEmpImage()
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                var Img = new EmployeeImagesModel();
                if (files != null && files.Count > 0)
                {

                    foreach (var file in files)
                    {
                        Img.ImgPath = await UploadImage(file);
                    }
                    await _frepo.SaveChange();
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return "Employee image saved";
        }

        [NonAction]
        public async Task<string> UploadImage(IFormFile imgFile)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imgFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName += DateTime.Now.ToString("yymmddhhssff") + Path.GetExtension(imgFile.FileName);
            var imgPath = Path.Combine(_hostEnv.ContentRootPath, "Images", imageName);

            using (var fileStream = new FileStream(imgPath, FileMode.Create))
            {
                await imgFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}
