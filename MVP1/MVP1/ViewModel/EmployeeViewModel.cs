using Prism.Mvvm;

namespace MVP1.ViewModel
{
    public class EmployeeViewModel : BindableBase
    {
        private long _id;
        private string _type;
        private string _name;
        private string _pin;

        public long Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
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


        public override string ToString()
        {
            return $"{Id} | {Name} - {Type}";
        }

        public EmployeeViewModel()
        {
        }
    }
}
