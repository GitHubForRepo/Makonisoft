using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FeatureObject
{
    public class Download : IDownload
    {
        private string _filePath { get; set; }
        private Download(string filePath)
        {
            _filePath = filePath;
        }

        public static IDownload Create(string filePath)
        {
            return new Download(filePath);  
        }
        public string Get()
        {
            var fileContent = File.ReadAllText(_filePath);
            return fileContent.Length <=0 ? "No data to show " : fileContent;
        }
    }
}
