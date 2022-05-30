using MVP1.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace MVP1.ViewModel
{
    public class AdminViewModel : BindableBase
    {
        private ICommand _manageProductsCommand;
        private ICommand _manageEmployeesCommand;
        private ICommand _manageTablesCommand;

        public ICommand ManageProductsCommand
        {
            get => _manageProductsCommand;
            set => SetProperty(ref _manageProductsCommand, value);
        }

        public ICommand ManageEmployeesCommand
        {
            get => _manageEmployeesCommand;
            set => SetProperty(ref _manageEmployeesCommand, value);
        }

        public ICommand ManageTablesCommand
        {
            get => _manageTablesCommand;
            set => SetProperty(ref _manageTablesCommand, value);
        }

        public AdminViewModel()
        {
            ManageEmployeesCommand = new DelegateCommand(OpenEmployees);
            ManageProductsCommand = new DelegateCommand(OpenProducts);
            ManageTablesCommand = new DelegateCommand(OpenTables);
        }

        private void OpenTables()
        {
        }

        private void OpenProducts()
        {
        }

        private void OpenEmployees()
        {
            var employeesWindow = new ManageEmployeeWindow
            {
                DataContext = new ManageEmployeeViewModel()
            };

            employeesWindow.ShowDialog();
        }
    }
}
