using System;
using System.Windows.Input;
using DataBindingDemo.Commands;

namespace DataBindingDemo.ViewModels
{
    public class OneWayBindingViewModel : BaseViewModel
    {
        private string _sourceText = "Текст из ViewModel (OneWay)";
        private string _readOnlyDisplay;
        private DateTime _currentTime = DateTime.Now;

        public string SourceText { get => _sourceText; set => Set(ref _sourceText, value); }
        public string ReadOnlyDisplay { get => _readOnlyDisplay; set => Set(ref _readOnlyDisplay, value); }
        public string CurrentTimeDisplay => $"Текущее время: {_currentTime:HH:mm:ss}";

        public ICommand UpdateTimeCommand { get; }
        public ICommand UpdateReadOnlyCommand { get; }

        public OneWayBindingViewModel()
        {
            ReadOnlyDisplay = "Это ReadOnly поле (только для чтения)";

            UpdateTimeCommand = new RelayCommand(_ =>
            {
                _currentTime = DateTime.Now;
                OnPropertyChanged(nameof(CurrentTimeDisplay));
            });

            UpdateReadOnlyCommand = new RelayCommand(_ =>
            {
                ReadOnlyDisplay = $"Обновлено в {DateTime.Now:HH:mm:ss}";
            });
        }
    }
}