using HandyControl.Controls;
using MvvmSqlite.BLL;
using MvvmSqlite.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Reflection;
using System.Windows.Input;

namespace MvvmSqlite.ViewModels
{
    public class AddDataViewModel : BindableBase
    {
        StudentBLL studentBLL;
        StudentModel studentModel = new StudentModel();
        public AddDataViewModel()
        {
            studentBLL = StudentBLL._StudentBLL;
        }

        public ICommand OkCommand { get => new DelegateCommand(OK); }
        public ICommand CancelCommand { get => new DelegateCommand<object>(Cancel); }

        public StudentModel StudentModel { get => studentModel; set => SetProperty(ref studentModel, value); }

        public void OK()
        {
            bool result;
            int count = studentBLL.FindAll().Result.Count;
            StudentModel.Id = count + 1;
            result = studentBLL.Add(StudentModel).Result;
            if (result)
            {
                Growl.Info("添加成功");
                ClearProperties(studentModel);
            }
        }

        public void Cancel(object obj)
        {
            ((System.Windows.Window)obj).Close();
        }

        private void ClearProperties(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite)
                {
                    property.SetValue(obj, null);
                }
            }
        }
    }
}
