using MvvmSqlite.BLL;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MvvmSqlite.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private string _username = "yhh01";
        private string _password;

        public LoginViewModel()
        {
        }
        public string Username { get => _username; set => SetProperty(ref _username, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }
        public ICommand LoginCommand
        {
            get => new DelegateCommand<object>(Login);
        }
        public void Login(object obj)
        {
            if (Username == null || Password == null)
            {
                throw new Exception("请输入账号或者密码！");
            }

            var result= new LoginBLL().Login(new Model.LoginModel() 
            { password = Password, username = Username });
            if(result.Result)
            {
                // 关闭登录窗口，并且 DialogResult返回True；
                (obj as Window).DialogResult = true;
            }
        }
    }
}
