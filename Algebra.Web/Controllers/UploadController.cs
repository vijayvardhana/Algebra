using Algebra.Core;
using Algebra.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly AppSettings _appVariables;
        private readonly IHttpContextAccessor _httpContext;
        public UploadController(IHostingEnvironment hostingEnvironment, IOptions<AppSettings> options, IHttpContextAccessor httpContextAccessor)
        {
            _hostingEnvironment = hostingEnvironment;
            _appVariables = options.Value;
            _httpContext = httpContextAccessor;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadFilesAsync(List<IFormFile> files)
        {
            var header = _httpContext.HttpContext.Request.Headers;

            string accountNumber = header["__ACNO"];
            if(string.IsNullOrEmpty(accountNumber))
            {
                return NotFound("Account number is missing");
            }

            string nameCollection = header["__NWNM"];

            List<Naming> nameList = Utils.GetObjectList<Naming>(nameCollection, 'o');

            string filePath = _GetFilePath(accountNumber);

            foreach (var file in files)
            {
                string fileName = _GetFileName(file, nameList);
                string fullFilePath = Path.Combine(filePath, fileName);

                if (file.Length <= 0)
                {
                    continue;
                }

                using (var stream = new FileStream(fullFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



        #region private method
        private string _GetFilePath(string _accountNumber)
        {
            string assetFolder = _appVariables.AssetFolder.ToString();
            var assetPath = $"{_hostingEnvironment.WebRootPath}/{assetFolder}";
            var filePath = $"{assetPath}/{_accountNumber}";

            if (!Directory.Exists(assetPath))
            {
                Directory.CreateDirectory(assetPath);
            }

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            return filePath;
        }

        private string _GetFileName(IFormFile file, List<Naming> names)
        {
            string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
            fileName = fileName.Contains("\\")
                    ? fileName.Trim('"').Substring(fileName.LastIndexOf("\\", StringComparison.Ordinal) + 1)
                    : fileName.Trim('"');

            return names
                .Where(x => x.Old == fileName)
                .SingleOrDefault()
                .New;
        }
        #endregion
    }


    public class Naming
    {
        public string Old { get; set; }
        public string New { get; set; }
    }
}
