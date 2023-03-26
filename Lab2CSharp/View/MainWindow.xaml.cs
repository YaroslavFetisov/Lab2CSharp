using Lab2CSharp.ViewModel;
using System.Windows;

namespace Lab2CSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new PersonViewModel();
            InitializeComponent();
        }
    }
}
