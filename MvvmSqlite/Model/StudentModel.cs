using Prism.Mvvm;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSqlite.Model
{
    public class StudentModel:BindableBase
    {
        private string name;
        private int id;
        private int age;
        private string sex;
        private string _class;
        public StudentModel()
        {

        }
        public StudentModel(string name, int id, int age, string sex, string _class)
        {
            Name = name;
            Id = id;
            Age = age;
            Sex = sex;
            Class = _class;
        }

        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }
        [SugarColumn(IsPrimaryKey = true, IsNullable = false)]
        public int Id
        {
            get { return id; }
            set
            {
                SetProperty(ref id, value);
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                RaisePropertyChanged();
            }
        }
        public string Sex
        {
            get { return sex; }
            set
            {
                SetProperty(ref sex, value);
            }
        }
        public string Class
        {
            get { return _class; }
            set
            {
                SetProperty(ref _class, value);
            }
        }
    }
}
