using System;
using System.Windows.Input;
using DataBindingDemo.Commands;

namespace DataBindingDemo.ViewModels
{
    public class TwoWayBindingViewModel : BaseViewModel
    {
        private string _lostFocusText = "Изменение по потере фокуса";
        private string _propertyChangedText = "Изменение при каждом вводе";
        private string _explicitText = "Явное обновление";
        private int _age = 25;
        private DateTime _selectedDate = DateTime.Today;

        public string LostFocusText { get => _lostFocusText; set => Set(ref _lostFocusText, value); }
        public string PropertyChangedText { get => _propertyChangedText; set => Set(ref _propertyChangedText, value); }
        public string ExplicitText { get => _explicitText; set => Set(ref _explicitText, value); }
        public int Age { get => _age; set { if (value >= 0 && value <= 150) Set(ref _age, value); } }
        public DateTime SelectedDate { get => _selectedDate; set => Set(ref _selectedDate, value); }

        public ICommand ExplicitUpdateCommand { get; }

        public TwoWayBindingViewModel()
        {
            ExplicitUpdateCommand = new RelayCommand(_ => OnPropertyChanged(nameof(ExplicitText)));
        }
    }
}