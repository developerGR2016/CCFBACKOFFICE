using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntranetRosul.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult UploadDocument()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("UploadDocument");
        }
    }
}