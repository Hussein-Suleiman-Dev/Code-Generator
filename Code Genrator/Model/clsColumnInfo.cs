using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLCodeGenerator.Models
{
    internal class clsColumnInfo
    {

        public string Name { get; set; }//Name Column
        public string SqlDataType { get; set; }//Data Type Column
        public bool IsNullable { get; set; }//Does the column allow null values
        public bool IsPrimaryKey { get; set; }//Is the column a primary key
        public bool IsIdentity { get; set; }//it use to No INsert in Add

        public string ReferencedTable { get; set; }
        public string ReferencedColumn { get; set; }
    }
}
