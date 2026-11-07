using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace DataBindingDemo.Views
{
    public partial class TriggersView : UserControl
    {
        public TriggersView()
        {
            InitializeComponent();
            this.Loaded += TriggersView_Loaded;
        }

        private void TriggersView_Loaded(object sender, RoutedEventArgs e)
        {
            SetupPropertyTrigger();
            SetupDataTriggers();
            SetupMultiTrigger();
        }

        private void SetupPropertyTrigger()
        {
            var style = new Style(typeof(Border));

            var trigger = new Trigger
            {
                Property = UIElement.IsMouseOverProperty,
                Value = true
            };
            trigger.Setters.Add(new Setter(
                Control.BackgroundProperty,
                new SolidColorBrush(Color.FromRgb(0x4A, 0x90, 0xD9))));
            trigger.Setters.Add(new Setter(
                FrameworkElement.HeightProperty, 70.0));

            style.Triggers.Add(trigger);
            TriggerBorder.Style = style;
        }

        private void SetupDataTriggers()
        {
            if (ValidatedText == null) return;

            var style = new Style(typeof(TextBlock));

            var errorTrigger = new DataTrigger
            {
                Binding = new Binding("NumericValue"),
                Value = -1
            };
            errorTrigger.Setters.Add(new Setter(
                TextBlock.ForegroundProperty, Brushes.Red));
            style.Triggers.Add(errorTrigger);

            var warningTrigger = new DataTrigger
            {
                Binding = new Binding("NumericValue"),
                Value = 0
            };
            warningTrigger.Setters.Add(new Setter(
                TextBlock.ForegroundProperty, Brushes.Orange));
            style.Triggers.Add(warningTrigger);

            var successTrigger = new DataTrigger
            {
                Binding = new Binding("NumericValue"),
                Value = 100
            };
            successTrigger.Setters.Add(new Setter(
                TextBlock.ForegroundProperty, Brushes.Green));
            style.Triggers.Add(successTrigger);

            ValidatedText.Style = style;
        }

        private void SetupMultiTrigger()
        {
            // Используем прямой подход: подписываемся на события CheckBox
            MultiCheck1.Checked += (s, e) => UpdateMultiTrigger();
            MultiCheck1.Unchecked += (s, e) => UpdateMultiTrigger();
            MultiCheck2.Checked += (s, e) => UpdateMultiTrigger();
            MultiCheck2.Unchecked += (s, e) => UpdateMultiTrigger();
        }

        private void UpdateMultiTrigger()
        {
            if (MultiCheck1.IsChecked == true && MultiCheck2.IsChecked == true)
            {
                MultiTriggerBorder.Background = new SolidColorBrush(Color.FromRgb(0x66, 0xBB, 0x6A));
            }
            else
            {
                MultiTriggerBorder.Background = new SolidColorBrush(Colors.LightGray);
            }
        }
    }
}