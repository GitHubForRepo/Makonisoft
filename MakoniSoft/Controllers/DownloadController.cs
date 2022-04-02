using FeatureObject;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace MakoniSoft.Controllers
{
    [System.Web.Http.Route("api/Download")]
    [Produces("application/json")]
    [ApiController]
    public class DownloadController : Controller
    {
        private IDownload _download { get; set; }
        public DownloadController(IDownload download)
        {
            _download = download;
        }

        [HttpGet("File")]
        public ContentResult Download()
        {
            return Content(_download.Get());
        }
    }
}
