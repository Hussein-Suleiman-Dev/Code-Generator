using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLCodeGenerator.Models
{
    internal class clsTableInfo
    {
        public string Name { get; set; }
        public List<clsColumnInfo> Columns { get; set; } = new List<clsColumnInfo>();
    }
}
