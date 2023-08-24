using HandyControl.Controls;
using MvvmSqlite.BLL;
using MvvmSqlite.Model;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace MvvmSqlite.ViewModels
{
    public class AddDataViewModel : BindableBase
    {
        StudentBLL studentBLL;
        public AddDataViewModel()
        {
            studentBLL = StudentBLL._StudentBLL;
        }
        public ICommand OkCommand
        {
            get => new DelegateCommand(OK);
        }
        public ICommand CancelCommand { get => new DelegateCommand<object>(Cancel); }

        private string name;
        private int id;
        private int age;
        private string sex;
        private string _class;

        public string Name { get => name; set => SetProperty(ref name, value); }
        public int Id { get => id; set => SetProperty(ref id, value); }
        public int Age { get => age; set => SetProperty(ref age, value); }
        public string Sex { get => sex; set => SetProperty(ref sex, value); }
        public string Class { get => _class; set => SetProperty(ref _class, value); }
        public void OK()
        {
            bool result;
            int count = studentBLL.FindAll().Result.Count;
            result = studentBLL.Add(new StudentModel(name = Name, id = count + 1, 
                age = Age, sex = Sex, _class = Class)).Result;
            if (result)
            {
                Growl.Info("添加成功");
                Name = string.Empty;
                Age = 0;
                Sex = string.Empty;
                Class = string.Empty;

            }
        }

        public void Cancel(object obj)
        {
            ((System.Windows.Window)obj).Close();
        }
    }
}
