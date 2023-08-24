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
    public class StudentBLL
    {
        ISqlHelper<StudentModel> StudentSql;
        private static StudentBLL studentBLL;
        public StudentBLL()
        {
            StudentSql = new SqlSugarHelper<StudentModel>();
            StudentSql.SetConnectionConfig("DB\\Student", DbType.Sqlite);
            //StudentSql.CodeFirst();
        }

        public static StudentBLL _StudentBLL
        {
            get
            {
                if (studentBLL == null)
                {
                    studentBLL = new StudentBLL();
                }
                return studentBLL;
            }
        }
        public async Task<List<StudentModel>> FindAll()
        {
            return await StudentSql.GetAll();
        }

        public async Task<List<StudentModel>> FindName(string name)
        {
            return await StudentSql.GetByWhere(t => t.Name == name);
        }
        public async Task<List<StudentModel>> FindId(int id)
        {
            return await StudentSql.GetByWhere(t => t.Id == id);
        }
        public async Task<List<StudentModel>> FindSex(string sex)
        {
            return await StudentSql.GetByWhere(t => t.Sex == sex);
        }

        public async Task<bool> Add(StudentModel student)
        {
            return await StudentSql.Add(student);
        }

        public async Task<int> Delete(int id)
        {
            return await StudentSql.DelelteByWhere(t => t.Id == id);
        }

        public async Task<bool> Ademd(string _class,int id)
        {
            return await StudentSql.UpdateDate(s=> new StudentModel() { Class=_class}, t=>t.Id==id);
        }
    }
}
