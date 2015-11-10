using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace WaxCylinderDownloader
{
    public class Downloader
    {
        private string url = @"http://cylinders.library.ucsb.edu/download_file.php?";
        private string param1="param1=";
        private string param2="&param2=";
        public void DownloadCylinders(int startid, int endid)
        {
            for (int i = startid; i <= endid; i++)
            {
                using (var client = new WebClient())
                {
                    string param2str = null;
                    var param1str = param1+GetParamValue(i);
                    if (i < 10)
                    {
                         param2str = param2 +"000"+ i;   
                    }
                    if (i >= 10 && i < 100)
                    {
                        param2str = param2 + "00" + i;
                    }
                    if (i >= 100 && i < 1000)
                    {
                        param2str = param2 + "0" + i;
                    }
                    if (i >= 1000)
                    {

                        param2str = param2 + i;

                    }
                    var downloadUrl = url + param1str + param2str;
                    var request = WebRequest.Create(downloadUrl);
                    request.Method = "POST";
                    request.ContentType = "audio/mpeg";
                    var response = request.GetResponse();
                    var responseStream = response.GetResponseStream();
                    var memoryStream = new MemoryStream();
                    var buffer = new byte[4097];

                    do
                    {
                        if (responseStream == null)
                            break;
                        int count = responseStream.Read(buffer, 0, buffer.Length);
                        memoryStream.Write(buffer, 0, count);

                        if (count == 0)
                        {
                            break;
                        }
                    }
                    while (true);

                    byte[] result = memoryStream.ToArray();

                    var fs = new FileStream(@"C:\WaxCylinders\cylinder"+i+".mp3", FileMode.OpenOrCreate, FileAccess.ReadWrite);

                    fs.Write(result, 0, result.Length);

                    fs.Close();
                    memoryStream.Close();
                    if (responseStream != null) responseStream.Close();
                }
            }
        }

        private static string GetParamValue(int i)
        {
            if (i < 1000)
            {
                return "0000";
            }
            if (i>=1000 && i < 2000)
            {
                return "1000";
            }
            if (i>=2000 && i < 3000)
            {
                return "2000";
            }
            if (i>= 3000 && i < 4000)
            {
                return "3000";
            }
            if (i >= 4000 && i < 5000)
            {
                return "4000";
            }
            if (i >= 5000 && i < 6000)
            {
                return "5000";
            }
            if (i >= 6000 && i < 7000)
            {
                return "6000";
            }
            if (i >= 7000 && i < 8000)
            {
                return "7000";
            }
            if (i >= 8000 && i < 9000)
            {
                return "8000";
            }
            if (i >= 9000 && i < 10000)
            {
                return "9000";
            }
            return "0000";
        }
    }
}
