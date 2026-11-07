using System.Windows.Input;
using DataBindingDemo.Commands;

namespace DataBindingDemo.ViewModels
{
    public class DefaultBindingViewModel : BaseViewModel
    {
        private string _defaultText = "Текст по умолчанию";
        private string _sliderValue = "50";
        private bool _checkBoxValue = true;

        public string DefaultText { get => _defaultText; set => Set(ref _defaultText, value); }
        public string SliderValue { get => _sliderValue; set { if (Set(ref _sliderValue, value)) OnPropertyChanged(nameof(SliderDisplayText)); } }
        public string SliderDisplayText => $"Значение слайдера: {SliderValue}";
        public bool CheckBoxValue { get => _checkBoxValue; set => Set(ref _checkBoxValue, value); }
        public string CheckBoxStatus => CheckBoxValue ? "Флажок установлен" : "Флажок снят";

        public ICommand UpdateCheckBoxStatusCommand { get; }

        public DefaultBindingViewModel()
        {
            UpdateCheckBoxStatusCommand = new RelayCommand(_ =>
            {
                OnPropertyChanged(nameof(CheckBoxStatus));
                OnPropertyChanged(nameof(SliderDisplayText));
            });
        }
    }
}