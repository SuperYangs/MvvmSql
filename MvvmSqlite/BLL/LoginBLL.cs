using MvvmSqlite.Model;
using SQL_Tool;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSqlite.BLL
{
    public class LoginBLL
    {
        ISqlHelper<LoginModel> LoginSql;


        public LoginBLL()
        {
            LoginSql = new SqlSugarHelper<LoginModel>();
            LoginSql.SetConnectionConfig("DB\\Login", DbType.Sqlite);
        }
        public async Task<bool> Login(LoginModel login)
        {
            try
            {
                var result = await LoginSql.AnyAsync(t => t.username == login.username && t.password == login.password);
                return result ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool CreateLoginTable()
        {
            LoginSql.CodeFirst();
            return true;
        }
    }
}
