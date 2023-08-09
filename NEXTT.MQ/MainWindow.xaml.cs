using System.Windows;
using NEXTT.MQ.Connections;

namespace NEXTT.MQ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ConnectionsWindow connectionsWindow = new ConnectionsWindow();
            connectionsWindow.ShowDialog();

        }
    }
}