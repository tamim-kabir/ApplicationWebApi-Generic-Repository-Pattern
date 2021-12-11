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
        [Route("[action]")]
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
                        Img.ImgPath = await UploadFiles(file);
                    }
                    await _frepo.CreateNewRecord(Img);
                }
                return "Employee image saved";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [NonAction]
        public async Task<string> UploadFiles(IFormFile file)
        {
            string[] imageExtension = { ".PNG", ".JPG", ".JPEG", ".JFIF", ".PJPEG", ".PJP", "SVG", ".WEBP ", ".HEIC" };
            string[] FileExtension = { ".pdf", ".docx", ".xlsx", ".zip", ".rar"};
            
            string fileName = new string(Path.GetFileNameWithoutExtension(file.FileName).Take(20).ToArray()).Replace(' ', '-');
            var path = Path.GetExtension(file.FileName);
            fileName += DateTime.Now.ToString("-yy-mm-dd-hh-ss-ff") + path;
            
            //If images
            foreach (var extension in imageExtension)
            {
                if (Path.GetExtension(file.FileName) == extension)
                {
                    var imgPath = Path.Combine(_hostEnv.ContentRootPath, "Images", fileName);
                    using (var fileStream = new FileStream(imgPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return fileName;
                }
            }
            //If File
            foreach(var extension in FileExtension)
            { 
                if (Path.GetExtension(file.FileName) == extension)
                {
                    var filePath = Path.Combine(_hostEnv.ContentRootPath, "File", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return fileName;
                }
            }
            return "Wrong format File type";
        }
    }
}
