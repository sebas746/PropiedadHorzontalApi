using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;
using System.Threading.Tasks;

namespace PropiedadHorizontal.Api.Controllers
{
    /// <summary>
    /// Class for upload and download files.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UploadDownloadFilesController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private const string fileName = "Plantilla_Carga_Masiva_Copropiedades.xlsx";
        
        /// <summary>
        /// UploadDownload controller constructor.
        /// </summary>
        /// <param name="environment">Environment variable.</param>
        public UploadDownloadFilesController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        /// <summary>
        /// Download plantilla for bulk load.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("downloadPlantillaCopropietarios")]
        public async Task<IActionResult> DownloadPlantillaCopropietarios()
        {

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Files");
            var filePath = Path.Combine(uploads, fileName);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), fileName);
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}