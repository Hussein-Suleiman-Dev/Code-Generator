using SQLCodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLCodeGenerator.Genrator
{
    internal class clsGeneratorDTO
    {
        public static  string genrateDTO(clsTableInfo Table,string OutputPath)
        {
            string entityName = Table.Name.TrimEnd('s');
            StringBuilder Code= new StringBuilder();
            Code.AppendLine($"public class {entityName}DTO");
            Code.AppendLine("{");
            foreach (var Column in Table.Columns)
            {
                Code.AppendLine($"public {clsGeneratorDTO.GetCSharpType(Column.SqlDataType)} {Column.Name} {{ get; set; }}");
            }
            Code.AppendLine("}");
            string DTOPath = Path.Combine(OutputPath, "DTO");

            Directory.CreateDirectory(DTOPath);

            string FilePath = Path.Combine(
                DTOPath,
                entityName + "DTO.cs");

            string code = Code.ToString();

            File.WriteAllText(FilePath, code);
            return code;
        }
        public static string GetCSharpType(string sqlType)
        {
            switch (sqlType.ToLower())
            {
                case "int":
                    return "int";

                case "nvarchar":
                case "varchar":
                case "nchar":
                case "char":
                    return "string";

                case "bit":
                    return "bool";

                case "decimal":
                    return "decimal";
                case "date":
                case "datetime":
                case "datetime2":
                    return "DateTime";

                case "bigint":
                    return "long";
                case "tinyint":
                    return "byte";
                default:
                    return "object";
            }
        }

    }
}
