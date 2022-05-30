using MVP1.DataLayer;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;
using System.Windows.Input;

namespace MVP1.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private string _username;
        private string _pin;
        private ICommand _loginCommand;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Pin
        {
            get => _pin;
            set => SetProperty(ref _pin, value);
        }

        public ICommand LoginCommand
        {
            get => _loginCommand;
            set => SetProperty(ref _loginCommand, value);
        }

        public MainViewModel()
        {
            LoginCommand = new DelegateCommand(Login);
        }

        private void Login()
        {
            var dbContext = new RestaurantDbContext();
            var employeeRepository = new EmployeeRepository(dbContext);

            var employee = employeeRepository.GetEmployeeByNameAndPin(Username, Pin);
            if (employee == null)
            {
                MessageBox.Show("Credentiale invalide!");
            }
            else
            {
                MessageBox.Show($"Buna {employee.Name}!");
                // deschizi alta fereastra
            }
        }
    }
}
