namespace PlanTrabajoTII.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using PlanTrabajoTII.Common.Models;
    using PlanTrabajoTII.UIForms.Views;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    public class MainViewModel
    {
        private static MainViewModel instance;

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        public TokenResponse Token { get; set; }
        public LoginViewModel Login { get; set; }
        public ClassroomsViewModel Classrooms { get; set; }

        public ICommand ChrisCommand => new RelayCommand(this.LoadChris);
        public ICommand AdbCommand => new RelayCommand(this.LoadChris);
        public ICommand AddCommand => new RelayCommand(this.LoadChris);

        public MainViewModel()
        {
            instance = this;
            this.LoadMenus();
        }

        private async void LoadChris()
        {
            await App.Navigator.PushAsync(new AboutPage());
        }

        private void LoadMenus()
        {
            var menus = new List<Menu> 
            {
                new Menu
                {
                    Icon = "ic_phonelink_setup",
                    PageName = "SetupPage",
                    Title = "Setup"
                },
                new Menu
                {
                    Icon = "ic_perm_device_information",
                    PageName = "AboutPage",
                    Title = "About"
                },
                new Menu
                {
                    Icon = "ic_exit_to_app",
                    PageName = "LoginPage",
                    Title = "Close session"
                }
            };
            this.Menus = new ObservableCollection<MenuItemViewModel>(menus.Select(m=>new MenuItemViewModel 
            { 
                Icon = m.Icon,
                PageName = m.PageName,
                Title = m.Title
            }).ToList());
        }

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
    }
}