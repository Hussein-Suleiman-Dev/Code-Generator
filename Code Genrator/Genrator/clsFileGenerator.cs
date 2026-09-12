using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLCodeGenerator.Genrator
{
    internal class clsFileGenerator
    {
        public void CreateDirectories(string outputPath)
        {
            Directory.CreateDirectory(outputPath);

            Directory.CreateDirectory(
                Path.Combine(outputPath, "DTO")  );

            Directory.CreateDirectory(
                Path.Combine(outputPath, "DAL")
            );

            Directory.CreateDirectory(
                Path.Combine(outputPath, "BLL")
            );
        }


        public void SaveCodeToFile(string folderPath, string fileName, string code)
        {
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName);

            File.WriteAllText(filePath, code);
        }



    }
}
