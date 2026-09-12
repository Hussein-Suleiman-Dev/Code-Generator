using SQLCodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLCodeGenerator.Database
{
    internal class clsDatabaseReader
    {
        public static List<string> GetTables()
        {
            List<string> tables = new List<string>();
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tables.Add(reader.GetString(0));
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return tables;

        }

        public static List<clsColumnInfo> GetColumns(string tableName)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select COLUMN_NAME,DATA_TYPE,IS_NULLABLE  from INFORMATION_SCHEMA.COLUMNS
where Table_Name=@TableName
order by ORDINAL_POSITION";


            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TableName", tableName);

            List<clsColumnInfo> columns = new List<clsColumnInfo>();

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    columns.Add(new clsColumnInfo
                    {
                        Name = reader[0].ToString(),
                        SqlDataType = reader[1].ToString(),
                        IsNullable = reader[2].ToString() == "YES"
                    });
                }
reader.Close();

            }
            catch (Exception) { }
            finally { conn.Close(); }
            return columns;
        }

        public static string GetPrimaryKey(string tableName)
        {
            SqlConnection conn = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT COLUMN_NAME
        FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
        WHERE TABLE_NAME = @TableName
        AND CONSTRAINT_NAME LIKE 'PK_%'";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TableName", tableName);

            string primaryKey = "";

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    primaryKey = reader[0].ToString();
                }

                reader.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return primaryKey;
        }
        public static string GetIdentityColumn(string tableName)
        {
            SqlConnection conn = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT c.name
        FROM sys.columns c
        WHERE c.object_id = OBJECT_ID(@TableName)
        AND c.is_identity = 1";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TableName", tableName);

            string identityColumn = "";

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    identityColumn = reader[0].ToString();
                }

                reader.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return identityColumn;
        }
        public static void GetForeignKeys(string tableName, List<clsColumnInfo> columns)
        {
            SqlConnection conn = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT
            fkCol.name AS ColumnName,
            refTable.name AS ReferencedTable,
            refCol.name AS ReferencedColumn
        FROM sys.foreign_keys fk
        INNER JOIN sys.foreign_key_columns fkc
            ON fk.object_id = fkc.constraint_object_id
        INNER JOIN sys.columns fkCol
            ON fkc.parent_object_id = fkCol.object_id
            AND fkc.parent_column_id = fkCol.column_id
        INNER JOIN sys.tables refTable
            ON fkc.referenced_object_id = refTable.object_id
        INNER JOIN sys.columns refCol
            ON fkc.referenced_object_id = refCol.object_id
            AND fkc.referenced_column_id = refCol.column_id
        WHERE fk.parent_object_id = OBJECT_ID(@TableName);";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TableName", tableName);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string columnName = reader["ColumnName"].ToString();

                    clsColumnInfo column = columns
                        .FirstOrDefault(c => c.Name == columnName);

                    if (column != null)
                    {
                        column.ReferencedTable =
                            reader["ReferencedTable"].ToString();

                        column.ReferencedColumn =
                            reader["ReferencedColumn"].ToString();
                    }
                }

                reader.Close();
            }
            finally
            {
                conn.Close();
            }
        }

        public static clsTableInfo GetTableSchema(string TableName)
        { 
        
        clsTableInfo TablInfo= new clsTableInfo();
            TablInfo.Name = TableName;
            TablInfo.Columns=GetColumns(TableName);
            string PrimaryKey = GetPrimaryKey(TableName);
            string IdentityColumn = GetIdentityColumn(TableName);
            foreach (var Column in TablInfo.Columns)
            { 
            if(Column.Name==PrimaryKey)
            {
                Column.IsPrimaryKey=true;
            }
            }
            foreach (var Column in TablInfo.Columns) 
            { if (Column.Name==IdentityColumn)
                
                { Column.IsIdentity=true; } 
            }
            GetForeignKeys(TableName, TablInfo.Columns);
        
            return TablInfo;
        }
        public List<clsTableInfo> GetDatabaseSchema()
        {
            List<clsTableInfo> tablesInfo = new List<clsTableInfo>();

            List<string> tables = GetTables();

            foreach (string tableName in tables)
            {
                clsTableInfo table = new clsTableInfo();

                table.Name = tableName;

                // Get Columns
                table.Columns = GetColumns(tableName);

                // Get Primary Key
                string primaryKey = GetPrimaryKey(tableName);

                foreach (clsColumnInfo column in table.Columns)
                {
                    if (column.Name == primaryKey)
                    {
                        column.IsPrimaryKey = true;
                    }
                }

                // Get Identity
                string identityColumn = GetIdentityColumn(tableName);

                foreach (clsColumnInfo column in table.Columns)
                {
                    if (column.Name == identityColumn)
                    {
                        column.IsIdentity = true;
                    }
                }

                // Get Foreign Keys
                GetForeignKeys(tableName, table.Columns);

                tablesInfo.Add(table);
            }

            return tablesInfo;
        }
    }
}