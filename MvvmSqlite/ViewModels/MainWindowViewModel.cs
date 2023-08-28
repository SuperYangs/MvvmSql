using HandyControl.Controls;
using MvvmSqlite.BLL;
using MvvmSqlite.Model;
using MvvmSqlite.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MvvmSqlite.ViewModels
{
    public class MainWindowViewModel : BindableBase, INotifyDataErrorInfo
    {
        private ObservableCollection<StudentModel> gridModelList;
        private string _title = "学生系统";
        private string searchName = string.Empty;
        private string searchSex = string.Empty;
        private StudentBLL studentBLL;


        public MainWindowViewModel()
        {
            studentBLL = StudentBLL._StudentBLL;
            FindAll();
        }


        public ObservableCollection<StudentModel> GridModelList
        {
            get { return gridModelList; }
            set
            {
                SetProperty(ref gridModelList, value);
            }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public string SearchName
        {
            get { return searchName; }
            set
            {
                SetProperty(ref searchName, value);
                if (value == "123")
                {
                    // 异常消息
                    ErrorsContainer.SetErrors("SearchName", new string[] { "输入值无效123" });
                }
                else
                {
                    ErrorsContainer.ClearErrors("SearchName");
                }
            }
        }
        public string SearchSex
        {
            get { return searchSex; }
            set { SetProperty(ref searchSex, value); }
        }


        public ICommand FindAllCommand
        {
            get => new DelegateCommand(FindAll);
        }
        public ICommand FindNameCommand
        {
            get => new DelegateCommand(FindName);
        }
        public ICommand FindSexCommand
        {
            get => new DelegateCommand(FindSex);
        }
        public ICommand AddCommand
        {
            get => new DelegateCommand(AddSingle);
        }

        public ICommand DeleteCommand
        {
            get => new DelegateCommand<int?>(Delete);
        }
        public ICommand AmendCommand
        {
            get => new DelegateCommand<object>(Amend);
        }


        public void FindAll()
        {
            var datas = studentBLL.FindAll();
            GridModelList = new ObservableCollection<StudentModel>(datas.Result);
            Growl.Info($"一共查询到{datas.Result.Count}个学生信息");
        }

        public void FindName()
        {
            var datas = studentBLL.FindName(SearchName);
            GridModelList = new ObservableCollection<StudentModel>(datas.Result);
            Growl.Info($"一共查询到{datas.Result.Count}个名为‘{SearchName}’学生信息");
        }

        public void FindSex()
        {
            var datas = studentBLL.FindSex(SearchSex);
            GridModelList = new ObservableCollection<StudentModel>(datas.Result);
            Growl.Info($"一共查询到{datas.Result.Count}个性别为‘{SearchSex}’学生信息");
        }
        public void AddSingle()
        {
            AddDataView addDataView = new AddDataView();
            addDataView.ShowDialog();
        }

        public void Delete(int? id)
        {
            var student = studentBLL.FindId((int)id);
            if (student.Result.Count == 0)
            {
                Growl.Error("不存在该学生");
                return;
            }
            var r = MessageBox.Show($"确认是否删除学生：{student.Result[0].Name}？", "操作提示", System.Windows.MessageBoxButton.OKCancel);
            if (r == System.Windows.MessageBoxResult.OK)
            {
                var result = studentBLL.Delete((int)id);
                if (result.Result > 0)
                {
                    Growl.Info($"删除学生：{student.Result[0].Name}成功");
                }
                var datas = studentBLL.FindAll();
                GridModelList = new ObservableCollection<StudentModel>(datas.Result);
            }
        }
        public void Amend(object obj) //string _class,int? id
        {
            var value = (object[])obj;
            var result = studentBLL.Ademd(value[0].ToString(), Convert.ToInt32(value[1]));
            if (result.Result)
            {
                Growl.Info($"ID为“{value[1]}”同学的班级修改为“{value[0]}”");
            }
        }

        #region INotifyDataErrorInfo

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public bool HasErrors => ErrorsContainer.HasErrors;
        public IEnumerable GetErrors(string propertyName) => ErrorsContainer.GetErrors(propertyName);

        private ErrorsContainer<string> errorsContainer;

        public ErrorsContainer<string> ErrorsContainer
        {
            get
            {
                if (errorsContainer == null)
                    errorsContainer = new ErrorsContainer<string>((propName) =>
                    {
                        // 异常信息的处理
                        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propName));
                    });

                return errorsContainer;
            }
            set { errorsContainer = value; }
        }

        #endregion

    }
}
