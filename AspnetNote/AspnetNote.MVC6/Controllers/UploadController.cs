using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspnetNote.MVC6.Controllers
{
    public class UploadController : Controller
    {

        private readonly IHostingEnvironment _enviroment;


        public UploadController(IHostingEnvironment environment)
        {
            _enviroment = environment;
        }

        // http://www.ex.com/upload/imageupload
        [HttpPost]
        [Route("api/upload")]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            // # 이미지나 파이을 업로드 할 때 필요한 구성 
            // 1. Path(경로) - 어디에다 저장할지 결정

            var path = Path.Combine(_enviroment.WebRootPath, @"images\upload"); // 1/2/3/4
            // 2. Name(이름) - DateTime, GUID + GUID


            // 파일 이름 image.jpg
            var fileFullName = file.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";

            // 3. Extension(확장자) - jpg, png...txt

            using(var fileStream = new FileStream(Path.Combine(path,fileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                
            }

            return Ok(new { file= "/images/upload/" + fileName, success = true});

                // #  URL 접근 방식
                // ASP.NET - 호스트명/ + api/upload => http://www.ex.comapi/upload
                // ASP.NET - 호스트명/ + /api/upload => http://www.ex.comapi/upload
            }
    }
}