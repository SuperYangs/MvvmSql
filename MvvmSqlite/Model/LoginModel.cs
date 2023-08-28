using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSqlite.Model
{
    public class LoginModel: ValidatableModel
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string username { get; set; } = "yhh01";
        public string password { get; set; }

    }
}
