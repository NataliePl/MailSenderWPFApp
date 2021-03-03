using MailSenderApp.Data;
using MailSenderApp.Models;
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
            //DataContext = new MainWindowViewModel();
            //portsOfMailServer.Add("smtp.gmail.com", 25);
            //portsOfMailServer.Add("smtp.yandex.ru", 25);
            //portsOfMailServer.Add("smtp.mail.ru", 25);
        }

        //private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        //{
        //    Close();
        //}

        //private void ServerComboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{

        //}

        private void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
            if (overflowGrid != null)
            {
                overflowGrid.Visibility = Visibility.Collapsed;
            }
            var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
            if (mainPanelBorder != null)
            {
                mainPanelBorder.Margin = new Thickness();
            }
        }

        

        //private void OnAddServerButtonClick(object sender, RoutedEventArgs e)
        //{

        //}

        //private void LoadDataBtn_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void LoadDataBtn_Click_1(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
