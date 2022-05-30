using MVP1.DataLayer;
using MVP1.Model;
using MVP1.Views;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace MVP1.ViewModel
{
    public class UpsertEmployeeViewModel : BindableBase
    {
        private string _type;
        private string _name;
        private string _pin;
        private int _index;

        private EmployeeViewModel _editedEmployeeViewModel;

        private ICommand _saveCommand;

        public int Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }

        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Pin
        {
            get => _pin;
            set => SetProperty(ref _pin, value);
        }

        public EmployeeViewModel EditedEmployeeViewModel
        {
            get => _editedEmployeeViewModel;
            set => SetProperty(ref _editedEmployeeViewModel, value);
        }

        public UpsertEmployeeWindow Window { get; }

        public ICommand SaveCommand
        {
            get => _saveCommand;
            set => SetProperty(ref _saveCommand, value);
        }

        public UpsertEmployeeViewModel(
            EmployeeViewModel employeeViewModel,
            UpsertEmployeeWindow window)
        {
            EditedEmployeeViewModel = employeeViewModel;
            Window = window;
            SaveCommand = new DelegateCommand(Save);

            if(EditedEmployeeViewModel != null)
            {
                Name = EditedEmployeeViewModel.Name;
                Type = EditedEmployeeViewModel.Type;
                Pin = EditedEmployeeViewModel.Pin;
            }
        }

        private void Save()
        {
            Type = ((Enums.EmployeeType)Index).ToString();

            if (EditedEmployeeViewModel == null)
            {
                EditedEmployeeViewModel = new EmployeeViewModel
                {
                    Name = Name,
                    Pin = Pin,
                    Type = Type
                };

                var model = Convert(EditedEmployeeViewModel);

                Add(model);
            }
            else
            {
                EditedEmployeeViewModel.Name = Name;
                EditedEmployeeViewModel.Pin = Pin;
                EditedEmployeeViewModel.Type = Type;

                var model = Convert(EditedEmployeeViewModel);

                Update(model);
            }

            Window.Close();
        }

        private void Update(Employee employee)
        {
            var dbContext = new RestaurantDbContext();
            var employeeRepository = new EmployeeRepository(dbContext);

            employeeRepository.Update(employee);
        }

        private void Add(Employee employee)
        {
            var dbContext = new RestaurantDbContext();
            var employeeRepository = new EmployeeRepository(dbContext);
            employeeRepository.Add(employee);
        }

        private Employee Convert(EmployeeViewModel employeeViewModel)
        {
            return new Employee
            {
                Id = employeeViewModel.Id,
                Name = employeeViewModel.Name,
                Type = employeeViewModel.Type,
                Pin = employeeViewModel.Pin
            };
        }
    }
}
