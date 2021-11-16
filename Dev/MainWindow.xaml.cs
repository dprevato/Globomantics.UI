using Globomantics.UI.WPF;
using System.Windows;

namespace Dev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            var theme = Theme.ThemeType == ThemeType.Light ? ThemeType.Dark : ThemeType.Light;

            Theme.LoadThemeType(theme);
        }
    }
}
