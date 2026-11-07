namespace DataBindingDemo.ViewModels
{
    public class OneTimeBindingViewModel : BaseViewModel
    {
        private string _oneTimeText = "Это текст OneTime (не обновляется)";
        private string _changingValue = "Начальное значение";

        public string OneTimeText { get => _oneTimeText; set => Set(ref _oneTimeText, value); }
        public string ChangingValue { get => _changingValue; set => Set(ref _changingValue, value); }
        public string OneTimeDisplay => $"Отображаемое значение: {OneTimeText}";
        public string CurrentValueDisplay => $"Текущее значение: {ChangingValue}";
    }
}