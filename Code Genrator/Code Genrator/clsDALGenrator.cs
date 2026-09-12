using SQLCodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLCodeGenerator.Genrator
{
    internal class clsDALGenrator
    {
        public static string GenerateAddMethod(clsTableInfo table)
        {
            StringBuilder code = new StringBuilder();

            string dtoName = $"cls{table.Name}DTO";
            string entityName = table.Name.TrimEnd('s');

            code.AppendLine(
                $"public static int AddNew{entityName}({dtoName} {entityName})"
            );

            code.AppendLine("{");
            code.AppendLine("    int ID = -1;");
            code.AppendLine();

            code.AppendLine(
                "    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);"
            );

            code.AppendLine();

            code.AppendLine("    string query = @\"");
            code.AppendLine($"        INSERT INTO {table.Name}");
            code.AppendLine("        (");

            int columnCount = 0;

            foreach (clsColumnInfo column in table.Columns)
            {
                if (!column.IsIdentity)
                    columnCount++;
            }

            int currentColumn = 0;

            foreach (clsColumnInfo column in table.Columns)
            {
                if (!column.IsIdentity)
                {
                    currentColumn++;

                    code.Append($"            {column.Name}");

                    if (currentColumn < columnCount)
                        code.AppendLine(",");
                    else
                        code.AppendLine();
                }
            }

            code.AppendLine("        )");
            code.AppendLine("        VALUES");
            code.AppendLine("        (");

            currentColumn = 0;

            foreach (clsColumnInfo column in table.Columns)
            {
                if (!column.IsIdentity)
                {
                    currentColumn++;

                    code.Append($"            @{column.Name}");

                    if (currentColumn < columnCount)
                        code.AppendLine(",");
                    else
                        code.AppendLine();
                }
            }

            code.AppendLine("        );");
            code.AppendLine();
            code.AppendLine("        SELECT SCOPE_IDENTITY();");
            code.AppendLine("    \";");

            code.AppendLine();

            code.AppendLine(
                "    SqlCommand command = new SqlCommand(query, connection);"
            );

            code.AppendLine();

            foreach (clsColumnInfo column in table.Columns)
            {
                if (!column.IsIdentity)
                {
                    code.AppendLine(
                        $"    command.Parameters.AddWithValue(\"@{column.Name}\", {entityName}.{column.Name});"
                    );
                }
            }

            code.AppendLine();

            code.AppendLine("    try");
            code.AppendLine("    {");
            code.AppendLine("        connection.Open();");
            code.AppendLine();
            code.AppendLine("        object result = command.ExecuteScalar();");
            code.AppendLine();
            code.AppendLine("        if (result != null)");
            code.AppendLine("            ID = Convert.ToInt32(result);");
            code.AppendLine("    }");

            code.AppendLine("    catch");
            code.AppendLine("    {");
            code.AppendLine("        throw;");
            code.AppendLine("    }");

            code.AppendLine("    finally");
            code.AppendLine("    {");
            code.AppendLine("        connection.Close();");
            code.AppendLine("    }");

            code.AppendLine();
            code.AppendLine("    return ID;");
            code.AppendLine("}");

            return code.ToString();
        }


        // =========================================================
        // UPDATE
        // =========================================================

        public static string GenerateUpdateMethod(clsTableInfo table)
        {
            StringBuilder code = new StringBuilder();

            string dtoName = $"cls{table.Name}DTO";
            string entityName = table.Name.TrimEnd('s');

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
                $"public static bool Update{entityName}({dtoName} {entityName})"
            );

            code.AppendLine("{");
            code.AppendLine("    int RowsAffected = 0;");
            code.AppendLine();

            code.AppendLine(
                "    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);"
            );

            code.AppendLine();

            code.AppendLine("    string query = @\"");
            code.AppendLine($"        UPDATE {table.Name}");
            code.AppendLine("        SET");

            int updateCount = 0;

            foreach (clsColumnInfo column in table.Columns)
            {
                if (!column.IsPrimaryKey && !column.IsIdentity)
                    updateCount++;
            }

            int currentUpdate = 0;

            foreach (clsColumnInfo column in table.Columns)
            {
                if (!column.IsPrimaryKey && !column.IsIdentity)
                {
                    currentUpdate++;

                    code.Append(
                        $"            {column.Name} = @{column.Name}"
                    );

                    if (currentUpdate < updateCount)
                        code.AppendLine(",");
                    else
                        code.AppendLine();
                }
            }

            code.AppendLine(
                $"        WHERE {primaryKey.Name} = @{primaryKey.Name};"
            );

            code.AppendLine("    \";");

            code.AppendLine();

            code.AppendLine(
                "    SqlCommand command = new SqlCommand(query, connection);"
            );

            code.AppendLine();

            foreach (clsColumnInfo column in table.Columns)
            {
                if (!column.IsIdentity)
                {
                    code.AppendLine(
                        $"    command.Parameters.AddWithValue(\"@{column.Name}\", {entityName}.{column.Name});"
                    );
                }
            }

            code.AppendLine();

            code.AppendLine("    try");
            code.AppendLine("    {");
            code.AppendLine("        connection.Open();");
            code.AppendLine();
            code.AppendLine(
                "        RowsAffected = command.ExecuteNonQuery();"
            );
            code.AppendLine("    }");

            code.AppendLine("    catch");
            code.AppendLine("    {");
            code.AppendLine("        throw;");
            code.AppendLine("    }");

            code.AppendLine("    finally");
            code.AppendLine("    {");
            code.AppendLine("        connection.Close();");
            code.AppendLine("    }");

            code.AppendLine();
            code.AppendLine("    return RowsAffected > 0;");
            code.AppendLine("}");

            return code.ToString();
        }


        // =========================================================
        // DELETE
        // =========================================================

        public static string GenerateDeleteMethod(clsTableInfo table)
        {
            StringBuilder code = new StringBuilder();

            string entityName = table.Name.TrimEnd('s');

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
                $"public static bool Delete{entityName}({clsGeneratorDTO.GetCSharpType(primaryKey.SqlDataType)} {primaryKey.Name})"
            );

            code.AppendLine("{");
            code.AppendLine("    int RowsAffected = 0;");
            code.AppendLine();

            code.AppendLine(
                "    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);"
            );

            code.AppendLine();

            code.AppendLine("    string query = @\"");
            code.AppendLine($"        DELETE FROM {table.Name}");
            code.AppendLine(
                $"        WHERE {primaryKey.Name} = @{primaryKey.Name};"
            );
            code.AppendLine("    \";");

            code.AppendLine();

            code.AppendLine(
                "    SqlCommand command = new SqlCommand(query, connection);"
            );

            code.AppendLine();

            code.AppendLine(
                $"    command.Parameters.AddWithValue(\"@{primaryKey.Name}\", {primaryKey.Name});"
            );

            code.AppendLine();

            code.AppendLine("    try");
            code.AppendLine("    {");
            code.AppendLine("        connection.Open();");
            code.AppendLine();
            code.AppendLine(
                "        RowsAffected = command.ExecuteNonQuery();"
            );
            code.AppendLine("    }");

            code.AppendLine("    catch");
            code.AppendLine("    {");
            code.AppendLine("        throw;");
            code.AppendLine("    }");

            code.AppendLine("    finally");
            code.AppendLine("    {");
            code.AppendLine("        connection.Close();");
            code.AppendLine("    }");

            code.AppendLine();
            code.AppendLine("    return RowsAffected > 0;");
            code.AppendLine("}");

            return code.ToString();
        }


        // =========================================================
        // GET BY ID
        // =========================================================

        public static string GenerateGetByIDMethod(clsTableInfo table)
        {
            StringBuilder code = new StringBuilder();

            string dtoName = $"cls{table.Name}DTO";
            string entityName = table.Name.TrimEnd('s');

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
                $"public static {dtoName} Get{entityName}ByID({clsGeneratorDTO.GetCSharpType(primaryKey.SqlDataType)} {primaryKey.Name})"
            );

            code.AppendLine("{");

            code.AppendLine(
                $"    {dtoName} {entityName} = null;"
            );

            code.AppendLine();

            code.AppendLine(
                "    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);"
            );

            code.AppendLine();

            code.AppendLine("    string query = @\"");
            code.AppendLine(
                $"        SELECT * FROM {table.Name}"
            );
            code.AppendLine(
                $"        WHERE {primaryKey.Name} = @{primaryKey.Name};"
            );
            code.AppendLine("    \";");

            code.AppendLine();

            code.AppendLine(
                "    SqlCommand command = new SqlCommand(query, connection);"
            );

            code.AppendLine();

            code.AppendLine(
                $"    command.Parameters.AddWithValue(\"@{primaryKey.Name}\", {primaryKey.Name});"
            );

            code.AppendLine();

            code.AppendLine("    try");
            code.AppendLine("    {");
            code.AppendLine("        connection.Open();");
            code.AppendLine();

            code.AppendLine(
                "        SqlDataReader reader = command.ExecuteReader();"
            );

            code.AppendLine();

            code.AppendLine("        if (reader.Read())");
            code.AppendLine("        {");

            code.AppendLine(
                $"            {entityName} = new {dtoName}();"
            );

            code.AppendLine();

            foreach (clsColumnInfo column in table.Columns)
            {
                code.AppendLine(
                    $"            {entityName}.{column.Name} = ConvertTo{clsGeneratorDTO.GetCSharpType(column.SqlDataType)}(reader[\"{column.Name}\"]);"
                );
            }

            code.AppendLine("        }");

            code.AppendLine();

            code.AppendLine("        reader.Close();");

            code.AppendLine("    }");

            code.AppendLine("    catch");
            code.AppendLine("    {");
            code.AppendLine("        throw;");
            code.AppendLine("    }");

            code.AppendLine("    finally");
            code.AppendLine("    {");
            code.AppendLine("        connection.Close();");
            code.AppendLine("    }");

            code.AppendLine();

            code.AppendLine($"    return {entityName};");

            code.AppendLine("}");

            return code.ToString();
        }


        // =========================================================
        // GET ALL
        // =========================================================

        public static string GenerateGetAllMethod(clsTableInfo table)
        {
            StringBuilder code = new StringBuilder();

            code.AppendLine($"public static DataTable GetAll{table.Name}()");
            code.AppendLine("{");

            code.AppendLine("    DataTable DataTable = new DataTable();");
            code.AppendLine();

            code.AppendLine(
                "    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);"
            );

            code.AppendLine();

            code.AppendLine("    string query = @\"");
            code.AppendLine($"        SELECT * FROM {table.Name};");
            code.AppendLine("    \";");

            code.AppendLine();

            code.AppendLine(
                "    SqlCommand command = new SqlCommand(query, connection);"
            );

            code.AppendLine();

            code.AppendLine("    try");
            code.AppendLine("    {");

            code.AppendLine("        connection.Open();");
            code.AppendLine();

            code.AppendLine(
                "        SqlDataReader reader = command.ExecuteReader();"
            );

            code.AppendLine();

            code.AppendLine("        if (reader.HasRows)");
            code.AppendLine("        {");

            code.AppendLine("            DataTable.Load(reader);");

            code.AppendLine("        }");

            code.AppendLine();

            code.AppendLine("        reader.Close();");

            code.AppendLine("    }");

            code.AppendLine("    catch");
            code.AppendLine("    {");

            code.AppendLine("        throw;");

            code.AppendLine("    }");

            code.AppendLine("    finally");
            code.AppendLine("    {");

            code.AppendLine("        connection.Close();");

            code.AppendLine("    }");

            code.AppendLine();

            code.AppendLine("    return DataTable;");

            code.AppendLine("}");

            return code.ToString();
        }
        public static string GenerateGetAllMethod(clsTableInfo table,string OutputPath)
        {
            StringBuilder code = new StringBuilder();

            code.AppendLine($"public static DataTable GetAll{table.Name}()");
            code.AppendLine("{");

            code.AppendLine("    DataTable DataTable = new DataTable();");
            code.AppendLine();

            code.AppendLine(
                "    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);"
            );

            code.AppendLine();

            code.AppendLine("    string query = @\"");
            code.AppendLine($"        SELECT * FROM {table.Name};");
            code.AppendLine("    \";");

            code.AppendLine();

            code.AppendLine(
                "    SqlCommand command = new SqlCommand(query, connection);"
            );

            code.AppendLine();

            code.AppendLine("    try");
            code.AppendLine("    {");

            code.AppendLine("        connection.Open();");
            code.AppendLine();

            code.AppendLine(
                "        SqlDataReader reader = command.ExecuteReader();"
            );

            code.AppendLine();

            code.AppendLine("        if (reader.HasRows)");
            code.AppendLine("        {");

            code.AppendLine("            DataTable.Load(reader);");

            code.AppendLine("        }");

            code.AppendLine();

            code.AppendLine("        reader.Close();");

            code.AppendLine("    }");

            code.AppendLine("    catch");
            code.AppendLine("    {");

            code.AppendLine("        throw;");

            code.AppendLine("    }");

            code.AppendLine("    finally");
            code.AppendLine("    {");

            code.AppendLine("        connection.Close();");

            code.AppendLine("    }");

            code.AppendLine();

            code.AppendLine("    return DataTable;");

            code.AppendLine("}");
            string DALPath =
Path.Combine(OutputPath, "DAL");

            Directory.CreateDirectory(DALPath);

            string FilePath =
                Path.Combine(
                    DALPath,
                    "cls" + table.Name + "DataAccess.cs");



            File.WriteAllText(FilePath, code.ToString());
            return code.ToString();
        }
        public static string GenerateDALClass(clsTableInfo table)
        {
            StringBuilder code = new StringBuilder();

            string entityName = table.Name.TrimEnd('s');

            code.AppendLine("using System;");
            code.AppendLine("using System.Data;");
            code.AppendLine("using System.Data.SqlClient;");
            code.AppendLine("using SharedDTO;");
            code.AppendLine();
            code.AppendLine("namespace DataAccess");
            code.AppendLine("{");

            code.AppendLine($"    public class cls{entityName}Data");
            code.AppendLine("    {");

            code.AppendLine();

            // ADD
            code.AppendLine(GenerateAddMethod(table));

            code.AppendLine();

            // UPDATE
            code.AppendLine(GenerateUpdateMethod(table));

            code.AppendLine();

            // DELETE
            code.AppendLine(GenerateDeleteMethod(table));

            code.AppendLine();

            // GET BY ID
            code.AppendLine(GenerateGetByIDMethod(table));

            code.AppendLine();

            // GET ALL
            code.AppendLine(GenerateGetAllMethod(table));

            code.AppendLine();

            code.AppendLine("    }");
            code.AppendLine("}");
        

            return code.ToString();
        }
        public static void SaveFile(
      clsTableInfo table,
      string code,
      string OutputPath)
        {
            string DALPath =
                Path.Combine(OutputPath, "DAL");

            Directory.CreateDirectory(DALPath);

            string entityName =
                table.Name.TrimEnd('s');

            string FilePath =
                Path.Combine(
                    DALPath,
                    "cls" + entityName + "Data.cs");

            StringBuilder finalCode =
                new StringBuilder();

            // HEADER
            finalCode.AppendLine("using System;");
            finalCode.AppendLine("using System.Data;");
            finalCode.AppendLine("using System.Data.SqlClient;");
            finalCode.AppendLine("using SharedDTO;");
            finalCode.AppendLine();

            // NAMESPACE
            finalCode.AppendLine("namespace DataAccess");
            finalCode.AppendLine("{");

            // CLASS
            finalCode.AppendLine(
                "    public class cls" +
                entityName +
                "Data");

            finalCode.AppendLine("    {");

            // METHODS
            finalCode.AppendLine(code);

            // FOOTER
            finalCode.AppendLine("    }");
            finalCode.AppendLine("}");

            File.WriteAllText(
                FilePath,
                finalCode.ToString());
        }
      

    }
}