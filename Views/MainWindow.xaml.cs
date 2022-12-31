using System.Windows;
using System.Windows.Input;

namespace PrismPractice.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        private new void MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Dispatcher.InvokeAsync(() => this.TextBox.Focus());
        }
    }
}
