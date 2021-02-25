using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MailSenderApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<String, int> portsOfMailServer = new Dictionary<string, int>();

        public MainWindow()
        {
            InitializeComponent();
            portsOfMailServer.Add("smtp.gmail.com", 25);
            portsOfMailServer.Add("smtp.yandex.ru", 25);
            portsOfMailServer.Add("smtp.mail.ru", 25);
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ServerComboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
