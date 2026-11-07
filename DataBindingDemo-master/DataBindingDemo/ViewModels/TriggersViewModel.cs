using System.Windows.Input;
using DataBindingDemo.Commands;

namespace DataBindingDemo.ViewModels
{
    public class TriggersViewModel : BaseViewModel
    {
        private bool _isChecked;
        private string _statusText = "Статус: нормально";
        private int _numericValue = 50;
        private string _validationMessage;

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (Set(ref _isChecked, value))
                    StatusText = value ? "Статус: активно" : "Статус: неактивно";
            }
        }

        public string StatusText { get => _statusText; set => Set(ref _statusText, value); }

        public int NumericValue
        {
            get => _numericValue;
            set
            {
                if (Set(ref _numericValue, value))
                {
                    ValidationMessage = value < 0 ? "Значение не может быть отрицательным!" :
                                       value > 100 ? "Значение не может быть больше 100!" :
                                       value == 0 ? "Значение равно нулю" :
                                       "Значение в допустимом диапазоне";
                }
            }
        }

        public string ValidationMessage { get => _validationMessage; set => Set(ref _validationMessage, value); }

        public ICommand ToggleCheckedCommand { get; }
        public ICommand ResetValueCommand { get; }

        public TriggersViewModel()
        {
            ValidationMessage = "Значение в допустимом диапазоне";

            ToggleCheckedCommand = new RelayCommand(_ => IsChecked = !IsChecked);
            ResetValueCommand = new RelayCommand(_ => NumericValue = 50);
        }
    }
}