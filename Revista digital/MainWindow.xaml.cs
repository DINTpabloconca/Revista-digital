using Revista_digital.Vista_Modelo;
using System.Windows;

namespace Revista_digital
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM vm;
        public MainWindow()
        {
            vm = new MainWindowVM();
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
