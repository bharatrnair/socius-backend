using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using testing_app.Infrastructure;

namespace testing_app.Controllers
{
    [Authenticate]
    public class FileUploadController : ApiController
    {
        public IHttpActionResult Post()
        {
            var httpRequest = HttpContext.Current.Request;
            if(httpRequest.Files.Count > 0)
            {
                var fileNameList = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    Random rnd = new Random();
                    string fileName = Convert.ToString(rnd.Next()) + postedFile.FileName;
                    var filePath = HttpContext.Current.Server.MapPath("~/Public/" + fileName);
                    postedFile.SaveAs(filePath);
                    fileNameList.Add("/Public/" + fileName);
                }
                return Ok(fileNameList);
            }
            else
            {
               return BadRequest();
            }
        }
    }
}
