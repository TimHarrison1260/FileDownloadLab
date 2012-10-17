using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Hosting;

namespace FileDownloadLab.Models
{
    public class FileList
    {
        public  List<FileData> GetFiles()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/Files"));

            int id = 0;
            List<FileData> results = new List<FileData>();

            foreach (var fileInfo in dirInfo.GetFiles())
            {
                FileData fileData = new FileData();
                fileData.FileId = ++id;
                fileData.FileName = fileInfo.Name;
                fileData.FilePath = fileInfo.FullName;
                results.Add(fileData);
            }

            return results;
        }
    }
}