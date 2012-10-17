using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileDownloadLab.Models;

namespace FileDownloadLab.Controllers
{
    public class ReportsController : Controller
    {
        private readonly FileList list = new FileList();


        //
        // GET: /Reports/

        public ActionResult Index()
        {
            var results = (from f in list.GetFiles()
                           select f);
            return View(results);
        }


        public ActionResult Download(int id)
        {
            FileData file = (from f in list.GetFiles()
                          where f.FileId == id
                          select f).First();
            string contentType = "application/pdf";
            string nameOnTargetMachine = file.FileName;
            return File(file.FilePath, contentType, nameOnTargetMachine);
        }

    }
}
