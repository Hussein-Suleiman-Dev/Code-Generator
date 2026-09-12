using SQLCodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLCodeGenerator.Genrator
{
    internal class clsGenrateBLL
    {

        public string GenerateBLL(clsTableInfo table)
        {
            StringBuilder code = new StringBuilder();

            string entityName = table.Name.TrimEnd('s');
            string dtoName = $"{entityName}DTO";
            string dalName = $"cls{entityName}Data";

            code.AppendLine("using System;");
            code.AppendLine("using System.Data;");
            code.AppendLine("using DataAccess;");
            code.AppendLine("using SharedDTO;");
            code.AppendLine();
            code.AppendLine("namespace BusinessLayer");
            code.AppendLine("{");

            code.AppendLine($"    public class cls{entityName}");
            code.AppendLine("    {");

            // Mode
            code.AppendLine(
                "        public enum enMode { Add = 0, Update = 1 }"
            );

            code.AppendLine(
                "        public enMode Mode = enMode.Add;"
            );

            code.AppendLine();

            // Properties
            foreach (clsColumnInfo column in table.Columns)
            {
                code.AppendLine(
                    $"        public {clsGeneratorDTO.GetCSharpType(column.SqlDataType)} {column.Name} {{ get; set; }}"
                );
            }

            code.AppendLine();

            // Constructor
            code.AppendLine($"        public cls{entityName}()");
            code.AppendLine("        {");

            foreach (clsColumnInfo column in table.Columns)
            {
                if (column.IsIdentity)
                {
                    code.AppendLine(
                        $"            this.{column.Name} = -1;"
                    );
                }
                else
                {
                    string defaultValue =
                        GetDefaultValue(column.SqlDataType);

                    code.AppendLine(
                        $"            this.{column.Name} = {defaultValue};"
                    );
                }
            }

            code.AppendLine();
            code.AppendLine("            Mode = enMode.Add;");
            code.AppendLine("        }");

            code.AppendLine();

            // Constructor from DTO
            code.AppendLine(
                $"        private cls{entityName}({dtoName} {entityName}DTO)"
            );

            code.AppendLine("        {");

            foreach (clsColumnInfo column in table.Columns)
            {
                code.AppendLine(
                    $"            this.{column.Name} = {entityName}DTO.{column.Name};"
                );
            }

            code.AppendLine();
            code.AppendLine("            Mode = enMode.Update;");
            code.AppendLine("        }");

            code.AppendLine();

            // ToDTO
            code.AppendLine(
                $"        public {dtoName} ToDTO()"
            );

            code.AppendLine("        {");

            code.AppendLine($"            return new {dtoName}");
            code.AppendLine("            {");

            int propertyCount = table.Columns.Count;
            int currentProperty = 0;

            foreach (clsColumnInfo column in table.Columns)
            {
                currentProperty++;

                code.Append(
                    $"                {column.Name} = this.{column.Name}"
                );

                if (currentProperty < propertyCount)
                    code.AppendLine(",");
                else
                    code.AppendLine();
            }

            code.AppendLine("            };");
            code.AppendLine("        }");

            code.AppendLine();

            // Find
            clsColumnInfo primaryKey = null;

            foreach (clsColumnInfo column in table.Columns)
            {
                if (column.IsPrimaryKey)
                {
                    primaryKey = column;
                    break;
                }
            }

            code.AppendLine(
                $"        public static cls{entityName} Find({clsGeneratorDTO.GetCSharpType(primaryKey.SqlDataType)} {primaryKey.Name})"
            );

            code.AppendLine("        {");

            code.AppendLine(
                $"            {dtoName} {entityName}DTO = {dalName}.Get{entityName}ById({primaryKey.Name});"
            );

            code.AppendLine();

            code.AppendLine(
                $"            if ({entityName}DTO != null)"
            );

            code.AppendLine(
                $"                return new cls{entityName}({entityName}DTO);"
            );

            code.AppendLine("            else");
            code.AppendLine("                return null;");

            code.AppendLine("        }");

            code.AppendLine();

            // Add
            code.AppendLine("        private bool _Add()");
            code.AppendLine("        {");

            code.AppendLine(
                $"            this.{primaryKey.Name} = {dalName}.Add{entityName}(this.ToDTO());"
            );

            code.AppendLine(
                $"            return (this.{primaryKey.Name} != -1);"
            );

            code.AppendLine("        }");

            code.AppendLine();

            // Update
            code.AppendLine("        private bool _Update()");
            code.AppendLine("        {");

            code.AppendLine(
                $"            return {dalName}.Update{entityName}(this.ToDTO());"
            );

            code.AppendLine("        }");

            code.AppendLine();

            // Delete
            code.AppendLine(
                $"        public static bool Delete({ clsGeneratorDTO. GetCSharpType(primaryKey.SqlDataType)} {primaryKey.Name})"
            );

            code.AppendLine("        {");

            code.AppendLine(
                $"            return {dalName}.Delete{entityName}({primaryKey.Name});"
            );

            code.AppendLine("        }");

            code.AppendLine();

            // Save
            code.AppendLine("        public bool Save()");
            code.AppendLine("        {");

            code.AppendLine("            switch (Mode)");
            code.AppendLine("            {");

            code.AppendLine("                case enMode.Add:");

            code.AppendLine("                    if (_Add())");
            code.AppendLine("                    {");

            code.AppendLine("                        Mode = enMode.Update;");
            code.AppendLine("                        return true;");

            code.AppendLine("                    }");

            code.AppendLine();

            code.AppendLine("                    return false;");

            code.AppendLine();

            code.AppendLine("                case enMode.Update:");

            code.AppendLine("                    return _Update();");

            code.AppendLine("            }");

            code.AppendLine();

            code.AppendLine("            return false;");

            code.AppendLine("        }");

            code.AppendLine("    }");
            code.AppendLine("}");

            return code.ToString();
        }
        private string GetDefaultValue(string sqlType)
        {
            switch (sqlType.ToLower())
            {
                case "int":
                    return "0";

                case "bigint":
                    return "0";

                case "smallint":
                    return "0";

                case "tinyint":
                    return "0";

                case "bit":
                    return "false";

                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney":
                case "float":
                case "real":
                    return "0";

                case "datetime":
                case "datetime2":
                case "date":
                case "smalldatetime":
                    return "DateTime.Now";

                case "nvarchar":
                case "varchar":
                case "nchar":
                case "char":
                case "text":
                case "ntext":
                    return "\"\"";

                case "uniqueidentifier":
                    return "Guid.Empty";

                default:
                    return "null";
            }
        }
    }
}
