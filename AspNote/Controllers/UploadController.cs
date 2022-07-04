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
        [HttpPost, Route("api/upload")]
        public IActionResult ImageUpload(IFormFile file)
        {
            // var path = Path.Combine("Users/richie/RiderProjects/rabbit/AspNote/wwwroot", @"images/upload");
            string path = Path.Combine(_webHostEnvironment.WebRootPath, @"images/upload");
            var fileName = file.FileName; // orginal file name !
            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }  
            // return Ok(new {file=Path.Combine(path, fileName), success = true });
            return Ok(new {file="/images/upload/" + fileName, success = true });
        }
    }
}