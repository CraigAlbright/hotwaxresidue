using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCylinderDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            var dler = new Downloader();
            dler.DownloadCylinders(9833,9833);
        }
    }
}
