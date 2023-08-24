using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSqlite.Model
{
    public class LoginModel
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string username { get; set; }
        public string password { get; set; }
    }
}
