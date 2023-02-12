using App3.Services;
using App3.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App3.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        private string _username;
        private string _password;

        private bool _isBusy;
        private bool _result;

        public string Username
        {
            get { return _username; }
            set { _username = value; }

        }

        public string Password { get { return _password; } set { _password = value; } }
        public bool IsBusy { get { return _isBusy;} set { _isBusy = value; } }
        public bool Result { get { return _result; } set { _result = value; } }   
        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy= true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Password);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Success", "User Registered", "OK");
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "User already exists", "OK");
            }
            catch(Exception ex) {
                await Application.Current.MainPage.DisplayAlert("Greska", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Password);
                if (Result)
                {
                    Preferences.Set("Username", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProductView());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Username or Password is invalid", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greska", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
