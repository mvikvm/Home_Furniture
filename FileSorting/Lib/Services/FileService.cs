using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lib.Services
{
    public class FileService
    {
        public void GetAllFilesWhithDateInName(string path, out int filesCount, out int filesWithDateInName)
        {
            //List<string> resultFiles = new ();
            //var directory = new DirectoryInfo(path);
            //if (!directory.Exists)
            //    throw new ArgumentException(nameof(path));

            //DirectoryInfo[] dirs = directory.GetDirectories();
            int CoutOfFiles = 0;
            var files = GetFilesList(path);
            foreach (var file in files)
            {
                string fileName = file.Name;

                Regex regex = new Regex(@"IMG_\d{8}_\d{6}.jpg");
                Match match = regex.Match(fileName);
                if (match.Success)
                {
                    var date = match.Value.Split("_")[1]+ match.Value.Split("_")[2];
                    var year = int.Parse(date.Substring(0, 4));
                    var mounth = int.Parse(date.Substring(4, 2));
                    var day = int.Parse(date.Substring(6, 2));
                    var hour = int.Parse(date.Substring(8, 2));
                    var min = int.Parse(date.Substring(10, 2));
                    var sec = int.Parse(date.Substring(12, 2));
                    var ddd = date.Trim(".jpg".ToCharArray());
                    var date2 = DateTime.ParseExact(ddd, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                    var datetime = new DateTime(year, mounth, day, hour, min, sec);
                    file.CreationTime = datetime;
                    file.Refresh();
                    CoutOfFiles = CoutOfFiles + 1;
                }
            }
            filesCount = GetAllFilesCount(path);
            filesWithDateInName = CoutOfFiles;
            //return files;
        }

        private int GetAllFilesCount(string path)
        { 
            return GetFilesList(path).Count;
        }

        private static List<FileInfo> GetFilesList(string path)
        {
            List<FileInfo> filesList = new();

            var directory = new DirectoryInfo(path);
            if (!directory.Exists)
            {
                throw new ArgumentException(nameof(path));
            }

            DirectoryInfo[] dirs = directory.GetDirectories();
            if (dirs.Length == 0)
            {
                filesList.AddRange(directory.GetFiles());
                return filesList;
            }
            foreach (var item in dirs)
            {
                    filesList.AddRange(GetFilesList(item.FullName));
            }
            return filesList;
        }
    }
}
