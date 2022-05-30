using MVP1.DataLayer;
using MVP1.Model;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MVP1.ViewModel
{
    public class ManageEmployeeViewModel : BindableBase
    {
        private ObservableCollection<EmployeeViewModel> _employees;
        private EmployeeViewModel _selectedEmployee;

        private ICommand _addCommand;
        private ICommand _editCommand;
        private ICommand _removeCommand;

        public ObservableCollection<EmployeeViewModel> Employees
        {
            get => _employees;
            set => SetProperty(ref _employees, value);
        }

        public EmployeeViewModel SelectedEmployee
        {
            get => _selectedEmployee;
            set => SetProperty(ref _selectedEmployee, value);
        }

        public ICommand AddCommand
        {
            get => _addCommand;
            set => SetProperty(ref _addCommand, value);
        }

        public ICommand EditCommand
        {
            get => _editCommand;
            set => SetProperty(ref _editCommand, value);
        }

        public ICommand RemoveCommand
        {
            get => _removeCommand;
            set => SetProperty(ref _removeCommand, value);
        }

        public ManageEmployeeViewModel()
        {
            Employees = new ObservableCollection<EmployeeViewModel>(GetAllEmployees());

            AddCommand = new DelegateCommand(Add);
            EditCommand = new DelegateCommand(Edit);
            RemoveCommand = new DelegateCommand(Remove);
        }

        private void Remove()
        {
            if (SelectedEmployee == null)
            {
                return;
            }

        }

        private void Edit()
        {
            if (SelectedEmployee == null)
            {
                return;
            }

        }

        private void Add()
        {
            // pop up a new window
        }

        private List<EmployeeViewModel> GetAllEmployees()
        {
            var dbContext = new RestaurantDbContext();
            var employeeRepository = new EmployeeRepository(dbContext);

            return employeeRepository
                .GetAllEmployees()
                .Select(ConvertToViewModel)
                .ToList();
        }

        private EmployeeViewModel ConvertToViewModel(Employee arg)
        {
            return new EmployeeViewModel
            {
                Id = arg.Id,
                Name = arg.Name,
                Pin = arg.Pin,
                Type = arg.Type
            };
        }
    }
}
