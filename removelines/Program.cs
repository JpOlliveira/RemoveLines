using System;
using System.IO;
using System.Linq;

namespace DeleteLine
{
    class Program
    {
        static void Main(string[] args)
        {
            string report = Console.ReadLine()!;
            string basePath = @$"C:\teste\Arquivos\{report}";
            string[] filePaths;
            List<string> _filePathsList = new List<string>();

            int files = Directory.GetFiles(basePath).Length;

            for (int i = 2; i <= files - 1; i++)
            {
                _filePathsList.Add(basePath + (i > 9? @"\" + i +    $"{report.Substring(0,1)} - 0223.txt" : @"\" + i + $"{report.Substring(0, 2)} - 0223.txt"));
            }
            
            filePaths = _filePathsList.ToArray();
            
            string[] lines = filePaths
                .SelectMany(filePath => {
                    string[] fileContents = 
                    File.ReadAllLines(filePath)
                        .Skip(2)
                        .Reverse()
                        .Skip(1)
                        .Reverse()
                        .ToArray();
                    File.Delete(filePath);
                    return fileContents; })
                .ToArray();
            
            File.AppendAllLines(basePath + @$"\{report}.txt", lines);
            Console.WriteLine("Salvo com sucesso tudo junto e misturado \n ass: Paulota");
        }
    }
}