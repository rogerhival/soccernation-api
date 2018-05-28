using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Soccernation.Controllers
{
    [Produces("application/json")]
    [Route("api/Upload")]
    public class UploadController : Controller
    {
        IHostingEnvironment _hostingEnvironment;

        public UploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public string GetFile(string name)
        {
            var folderName = "Uploads";
            var webRootPath = Directory.GetCurrentDirectory();
            var newPath = Path.Combine(webRootPath, folderName);
            var fullPath = Path.Combine(newPath, name);

            if (!System.IO.File.Exists(fullPath))
                return string.Empty;

            using (var stream = new FileStream(fullPath, FileMode.Open))
            {
                var bytes = new byte[stream.Length];
                for (var i = 0; i < stream.Length; i++)
                {
                    bytes[i] = (byte)stream.ReadByte();
                }

                var result = Convert.ToBase64String(bytes);
                return result;
            }
        }

        [HttpPost, DisableRequestSizeLimit]
        public string UploadFile()
        {
            try
            {
                var result = string.Empty;
                var file = Request.Form.Files[0];
                var folderName = "Uploads";
                var webRootPath = Directory.GetCurrentDirectory(); //_hostingEnvironment.WebRootPath;
                var newPath = Path.Combine(webRootPath, folderName);

                if (!Directory.Exists(newPath))
                    Directory.CreateDirectory(newPath);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    result = fileName;
                }
                var fullPathAfterUpload = Path.Combine(newPath, result);
                using (var stream = new FileStream(fullPathAfterUpload, FileMode.Open))
                {
                    var bytes = new byte[stream.Length];
                    for (var i = 0; i < stream.Length; i++)
                    {
                        bytes[i] = (byte)stream.ReadByte();
                    }
                    return Convert.ToBase64String(bytes);
                }
            }
            catch (Exception ex)
            {
                return "Upload failed: " + ex.Message;
            }
        }
    }
}