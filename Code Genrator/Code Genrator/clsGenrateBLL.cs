using SQLCodeGenerator.Models;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace SQLCodeGenerator.Genrator
{
    internal class clsGenrateBLL
    {
        // =====================================================
        // GENERATE FULL BLL
        // =====================================================

        public static string GenerateBLL(clsTableInfo table)
        {
            StringBuilder code = new StringBuilder();

            string entityName = table.Name.TrimEnd('s');

            clsColumnInfo primaryKey =
                table.Columns.FirstOrDefault(c => c.IsPrimaryKey);

            if (primaryKey == null)
            {
                throw new Exception(
                    "Table '" + table.Name +
                    "' does not have a Primary Key.");
            }

            // =========================
            // HEADER
            // =========================

            GenerateHeader(code);

            // =========================
            // CLASS
            // =========================

            code.AppendLine(
                "    public class cls" + entityName);

            code.AppendLine("    {");
            code.AppendLine();

            // =========================
            // BASIC
            // =========================

            GenerateMode(code);

            GenerateProperties(
                code,
                table);

            GenerateConstructors(
                code,
                table);

            GenerateToDTO(
                code,
                table);

            // =========================
            // FUNCTIONS
            // =========================

            GenerateFind(
                code,
                table);

            GenerateAdd(
                code,
                table);

            GenerateUpdate(
                code,
                table);

            GenerateDelete(
                code,
                table);

            GenerateGetAll(
                code,
                table);

            GenerateSave(
                code);

            // =========================
            // FOOTER
            // =========================

            GenerateFooter(code);

            return code.ToString();
        }


        // =====================================================
        // HEADER
        // =====================================================

        public static void GenerateHeader(StringBuilder code)
        {
            code.AppendLine("using System;");
            code.AppendLine("using System.Data;");
            code.AppendLine("using DataAccess;");
            code.AppendLine("using SharedDTO;");
            code.AppendLine();

            code.AppendLine("namespace BusinessLayer");
            code.AppendLine("{");
            code.AppendLine();
        }


        // =====================================================
        // MODE
        // =====================================================

        public static void GenerateMode(StringBuilder code)
        {
            code.AppendLine(
                "        public enum enMode { Add = 0, Update = 1 }");

            code.AppendLine();

            code.AppendLine(
                "        public enMode Mode = enMode.Add;");

            code.AppendLine();
        }


        // =====================================================
        // PROPERTIES
        // =====================================================

        public static void GenerateProperties( StringBuilder code,clsTableInfo table)
        {
            foreach (clsColumnInfo column in table.Columns)
            {
                code.AppendLine(
                    "        public " +
                    clsGeneratorDTO.GetCSharpType(
                        column.SqlDataType) +
                    " " +
                    column.Name +
                    " { get; set; }");
            }

            code.AppendLine();
        }


        // =====================================================
        // CONSTRUCTORS
        // =====================================================

        public static void GenerateConstructors(StringBuilder code, clsTableInfo table)
        {
            string entityName =
                table.Name.TrimEnd('s');

            // Empty Constructor

            code.AppendLine(
                "        public cls" +
                entityName +
                "()");

            code.AppendLine("        {");

            foreach (clsColumnInfo column in table.Columns)
            {
                if (column.IsIdentity)
                {
                    code.AppendLine(
                        "            this." +
                        column.Name +
                        " = -1;");
                }
                else
                {
                    code.AppendLine(
                        "            this." +
                        column.Name +
                        " = " +
                        GetDefaultValue(
                            column.SqlDataType) +
                        ";");
                }
            }

            code.AppendLine();

            code.AppendLine(
                "            Mode = enMode.Add;");

            code.AppendLine("        }");

            code.AppendLine();


            // Constructor From DTO

            code.AppendLine(
                "        private cls" +
                entityName +
                "(" +
                entityName +
                "DTO " +
                entityName +
                "DTO)");

            code.AppendLine("        {");

            foreach (clsColumnInfo column in table.Columns)
            {
                code.AppendLine(
                    "            this." +
                    column.Name +
                    " = " +
                    entityName +
                    "DTO." +
                    column.Name +
                    ";");
            }

            code.AppendLine();

            code.AppendLine(
                "            Mode = enMode.Update;");

            code.AppendLine("        }");

            code.AppendLine();
        }


        // =====================================================
        // TO DTO
        // =====================================================

        public static void GenerateToDTO( StringBuilder code,clsTableInfo table)
        {
            string entityName =
                table.Name.TrimEnd('s');

            code.AppendLine(
                "        public " +
                entityName +
                "DTO ToDTO()");

            code.AppendLine("        {");

            code.AppendLine(
                "            return new " +
                entityName +
                "DTO");

            code.AppendLine("            {");

            for (int i = 0; i < table.Columns.Count; i++)
            {
                clsColumnInfo column =
                    table.Columns[i];

                string comma =
                    i < table.Columns.Count - 1
                    ? ","
                    : "";

                code.AppendLine(
                    "                " +
                    column.Name +
                    " = this." +
                    column.Name +
                    comma);
            }

            code.AppendLine("            };");
            code.AppendLine("        }");

            code.AppendLine();
        }


        // =====================================================
        // FIND
        // =====================================================

        public static void GenerateFind( StringBuilder code,clsTableInfo table)
        {
            string entityName =
                table.Name.TrimEnd('s');

            clsColumnInfo primaryKey =
                table.Columns.FirstOrDefault(
                    c => c.IsPrimaryKey);

            string primaryKeyType =
                clsGeneratorDTO.GetCSharpType(
                    primaryKey.SqlDataType);

            code.AppendLine(
                "        public static cls" +
                entityName +
                " Find(" +
                primaryKeyType +
                " " +
                primaryKey.Name +
                ")");

            code.AppendLine("        {");

            code.AppendLine(
                "            " +
                entityName +
                "DTO " +
                entityName +
                "DTO = cls" +
                entityName +
                "Data.Get" +
                entityName +
                "ById(" +
                primaryKey.Name +
                ");");

            code.AppendLine();

            code.AppendLine(
                "            if (" +
                entityName +
                "DTO != null)");

            code.AppendLine(
                "                return new cls" +
                entityName +
                "(" +
                entityName +
                "DTO);");

            code.AppendLine();

            code.AppendLine(
                "            return null;");

            code.AppendLine("        }");

            code.AppendLine();
        }


        // =====================================================
        // ADD
        // =====================================================

        public static void GenerateAdd(StringBuilder code,clsTableInfo table)
        {
            string entityName =
                table.Name.TrimEnd('s');

            clsColumnInfo primaryKey =
                table.Columns.FirstOrDefault(
                    c => c.IsPrimaryKey);

            code.AppendLine(
                "        private bool _Add()");

            code.AppendLine("        {");

            code.AppendLine(
                "            this." +
                primaryKey.Name +
                " = cls" +
                entityName +
                "Data.AddNew" +
                entityName +
                "(this.ToDTO());");

            code.AppendLine();

            code.AppendLine(
                "            return (this." +
                primaryKey.Name +
                " != -1);");

            code.AppendLine("        }");

            code.AppendLine();
        }


        // =====================================================
        // UPDATE
        // =====================================================

        public static void GenerateUpdate(StringBuilder code,clsTableInfo table)
        {
            string entityName =
                table.Name.TrimEnd('s');

            code.AppendLine(
                "        private bool _Update()");

            code.AppendLine("        {");

            code.AppendLine(
                "            return cls" +
                entityName +
                "Data.Update" +
                entityName +
                "(this.ToDTO());");

            code.AppendLine("        }");

            code.AppendLine();
        }


        // =====================================================
        // DELETE
        // =====================================================

        public static void GenerateDelete( StringBuilder code, clsTableInfo table)
        {
            string entityName =
                table.Name.TrimEnd('s');

            clsColumnInfo primaryKey =
                table.Columns.FirstOrDefault(
                    c => c.IsPrimaryKey);

            string primaryKeyType =
                clsGeneratorDTO.GetCSharpType(
                    primaryKey.SqlDataType);

            code.AppendLine(
                "        public static bool Delete(" +
                primaryKeyType +
                " " +
                primaryKey.Name +
                ")");

            code.AppendLine("        {");

            code.AppendLine(
                "            return cls" +
                entityName +
                "Data.Delete" +
                entityName +
                "(" +
                primaryKey.Name +
                ");");

            code.AppendLine("        }");

            code.AppendLine();
        }


        // =====================================================
        // GET ALL
        // =====================================================

        public static void GenerateGetAll(StringBuilder code,clsTableInfo table)
        {
            string entityName =
                table.Name.TrimEnd('s');

            code.AppendLine(
                "        public static DataTable GetAll()");

            code.AppendLine("        {");

            code.AppendLine(
                "            return cls" +
                entityName +
                "Data.GetAll" +
                entityName +
                "s();");

            code.AppendLine("        }");

            code.AppendLine();
        }


        // =====================================================
        // SAVE
        // =====================================================

        public static void GenerateSave( StringBuilder code)
        {
            code.AppendLine(
                "        public bool Save()");

            code.AppendLine("        {");

            code.AppendLine(
                "            switch (Mode)");

            code.AppendLine("            {");

            code.AppendLine(
                "                case enMode.Add:");

            code.AppendLine();

            code.AppendLine(
                "                    if (_Add())");

            code.AppendLine("                    {");

            code.AppendLine(
                "                        Mode = enMode.Update;");

            code.AppendLine();

            code.AppendLine(
                "                        return true;");

            code.AppendLine("                    }");

            code.AppendLine();

            code.AppendLine(
                "                    return false;");

            code.AppendLine();

            code.AppendLine(
                "                case enMode.Update:");

            code.AppendLine();

            code.AppendLine(
                "                    return _Update();");

            code.AppendLine("            }");

            code.AppendLine();

            code.AppendLine(
                "            return false;");

            code.AppendLine("        }");

            code.AppendLine();
        }


        // =====================================================
        // CUSTOM BLL
        // =====================================================

        public static void GenerateCustomBLL(clsTableInfo table,string outputPath,bool find,bool add,bool update,bool delete,bool getAll,bool save)
        {
            StringBuilder code =
                new StringBuilder();

            string entityName =
                table.Name.TrimEnd('s');

            clsColumnInfo primaryKey =
                table.Columns.FirstOrDefault(
                    c => c.IsPrimaryKey);

            if (primaryKey == null)
            {
                throw new Exception(
                    "Table '" +
                    table.Name +
                    "' does not have a Primary Key.");
            }

            // =========================
            // HEADER
            // =========================

            GenerateHeader(code);

            // =========================
            // CLASS
            // =========================

            code.AppendLine(
                "    public class cls" +
                entityName);

            code.AppendLine("    {");
            code.AppendLine();

            // =========================
            // BASIC
            // =========================

            GenerateMode(code);

            GenerateProperties(
                code,
                table);

            GenerateConstructors(
                code,
                table);

            GenerateToDTO(
                code,
                table);

         

            if (find)
            {
                GenerateFind(
                    code,
                    table);
            }

            if (add)
            {
                GenerateAdd(
                    code,
                    table);
            }

            if (update)
            {
                GenerateUpdate(
                    code,
                    table);
            }

            if (delete)
            {
                GenerateDelete(
                    code,
                    table);
            }

            if (getAll)
            {
                GenerateGetAll(
                    code,
                    table);
            }

            if (save)
            {
                GenerateSave(
                    code);
            }

            // =========================
            // FOOTER
            // =========================

            GenerateFooter(code);

            // =========================
            // SAVE
            // =========================

            SaveFileBLL(
                table,
                code.ToString(),
                outputPath);
        }


        // =====================================================
        // FOOTER
        // =====================================================

        public static void GenerateFooter(
            StringBuilder code)
        {
            code.AppendLine("    }");
            code.AppendLine("}");
        }


        // =====================================================
        // SAVE FILE
        // =====================================================

        public static void SaveFileBLL( clsTableInfo table, string code, string outputPath)
        {
            string BLLPath =
                Path.Combine(
                    outputPath,
                    "BLL");

            string entityName =
                table.Name;

            Directory.CreateDirectory(
                BLLPath);

            string filePath =
                Path.Combine(
                    BLLPath,
                    "cls" +
                    entityName +
                    ".cs");

            File.WriteAllText(
                filePath,
                code);
        }


        // =====================================================
        // DEFAULT VALUE
        // =====================================================

        private static string GetDefaultValue(
            string sqlType)
        {
            switch (sqlType.ToLower())
            {
                case "int":
                case "bigint":
                case "smallint":
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