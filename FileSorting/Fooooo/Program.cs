using Lib.Services;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

string dirName = @"C:\Learn\";

//var directory = new DirectoryInfo(dirName);
FileService f = new FileService();
f.GetAllFilesWhithDateInName(dirName, out int filesCount, out int filesWithDateInName);
Console.WriteLine(@"Колличество файлов {filesCount}");
Console.WriteLine(@"Колличество файлов с датой в имени {filesWithDateInName}");

//if (directory.Exists)
//{
//    Console.WriteLine("Подкаталоги:");
//    DirectoryInfo[] dirs = directory.GetDirectories();
//    foreach (DirectoryInfo dir in dirs)
//    {
//        Console.WriteLine(dir.FullName);
//    }
//    Console.WriteLine();
//    Console.WriteLine("Файлы:");
//    FileInfo[] files = directory.GetFiles();
//    foreach (FileInfo file in files)
//    {
//        Console.WriteLine(file.FullName);
//    }
//}