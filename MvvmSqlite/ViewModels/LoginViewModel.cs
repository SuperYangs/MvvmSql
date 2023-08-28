using HandyControl.Controls;
using MvvmSqlite.BLL;
using MvvmSqlite.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Window = System.Windows.Window;

namespace MvvmSqlite.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private LoginModel loginModel = new LoginModel();
        public LoginViewModel()
        {
        }
        
        public LoginModel LoginModel
        {
            get => loginModel;
            set
            {
                SetProperty(ref loginModel, value);
            }
        }
        public ICommand LoginCommand
        {
            get => new DelegateCommand<object>(Login);
        }

        public void Login(object obj)
        {
            if (string.IsNullOrEmpty(LoginModel.username) || string.IsNullOrEmpty(LoginModel.password))
            {
                Growl.Error($"请输入账号或者密码");
                return;
            }

            var result = new LoginBLL().Login(LoginModel);
            if (!result.Result)
            {
                Growl.Error($"账号或者密码输入错误");
                return;
            }
            // 关闭登录窗口，并且 DialogResult返回True；
            (obj as Window).DialogResult = true;
        }
    }
}
