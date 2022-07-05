using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace AspNote.Controllers
{
    public class UploadController : Controller
    {
        // private readonly IHostEnvironment _hostEnvironment;
        private readonly IWebHostEnvironment _webHostEnvironment;

        // public UploadController(IHostEnvironment hostEnvironment)
        // {
        //     _hostEnvironment = hostEnvironment;
        // }
        public UploadController(IWebHostEnvironment webHostEnvironment)  
        {
            _webHostEnvironment = webHostEnvironment;
        }
           

        // http://www.example.com/Upload/ImageUpload 
        // http://www.example.com/api/upload
        [HttpPost, Route("note/api/upload")]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            // /Users/richie/RiderProjects/rabbit/AspNote/wwwroot/images/upload
            // var path = Path.Combine("Users/richie/RiderProjects/rabbit/AspNote/wwwroot", @"images/upload");
            var path = Path.Combine(_webHostEnvironment.WebRootPath, @"images/upload");
            var fileFullName = file.FileName.Split('.'); // orginal file name !
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";
            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }  
            // return Ok(new {file= .Combine(path, fileName), success = true });
            return Ok(new {file="/images/upload/" + fileName, success = true });
        }
    }
}  