using Core.Utilities.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadsController : ControllerBase
    {
        public static IWebHostEnvironment _environment;

        public UploadsController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public class FileUpload
        {
            public IFormFile files { get; set; }
        }
        [HttpGet("delete")]
        public IResult DeleteUploads(string Position)
        {
            var path = Path.Combine("E:\\argon-dashboard-angular-master\\src\\media\\Image\\" + Position);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return new SuccessResult();

            }
            return new ErrorResult(path+" Dosyası silinemedi");
        }

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<string> OnPostUploadAsync(string Position)
        {
            var Path="";
            var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                if (!Directory.Exists("E:\\argon-dashboard-angular-master\\src\\media\\Image\\"+Position+"\\"))
                {
                    Directory.CreateDirectory("E:\\argon-dashboard-angular-master\\src\\media\\Image\\" + Position+"\\");
                }
                Random rnd = new Random();
                Path = Position + "\\" + rnd.Next(10000, 99999) + file.FileName;
                var filePath = "E:\\argon-dashboard-angular-master\\src\\media\\Image\\" + Path;
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            return Path;
        }
        [HttpPost("multiple-upload")]
        [Consumes("multipart/form-data")]
        public async Task<Array> OnPostUpload(string Position)
        {
            var file = Request.Form.Files;
            string[] Path = new string[file.Count];
            if (file.Count>0)
            {
                if (!Directory.Exists("E:\\argon-dashboard-angular-master\\src\\media\\Image\\" + Position + "\\"))
                {
                    Directory.CreateDirectory("E:\\argon-dashboard-angular-master\\src\\media\\Image\\" + Position + "\\");
                }
                for (int i = 0; i < file.Count; i++)
                {
                    Random rnd = new Random();
                    Path[i] = Position + "\\" + rnd.Next(10000, 99999)+file[i].FileName;
                    var filePath = "E:\\argon-dashboard-angular-master\\src\\media\\Image\\" + Path[i];
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file[i].CopyToAsync(stream);
                    }
                }
            }
            return Path;
        }
    }
}
