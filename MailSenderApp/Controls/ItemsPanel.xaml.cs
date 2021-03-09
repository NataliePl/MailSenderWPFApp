using MailSenderApp.Infrastructure;
using System;
using System.Collections;
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

namespace MailSenderApp.Controls
{
    /// <summary>
    /// Interaction logic for ItemsPanel.xaml
    /// </summary>
    public partial class ItemsPanel
    {
        public static readonly DependencyProperty TitleProperty = 
            DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(ItemsPanel),
            new PropertyMetadata(default(string)));
        //Свойство зависимости
        public string Title 
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty,value);
        }
        public ItemsPanel()
        {
            InitializeComponent();
            
        }


        public static readonly DependencyProperty ItemsListProperty =
           DependencyProperty.Register(
           nameof(ItemsList),
           typeof(IEnumerable),
           typeof(ItemsPanel),
           new PropertyMetadata(null));

        public IEnumerable ItemsList {
            get => (IEnumerable)GetValue(ItemsListProperty);
            
            set => SetValue(ItemsListProperty, value);
        }

        public ICommand AddCommand { get; set; }

        public static readonly DependencyProperty AddCommandProperty =
           DependencyProperty.Register(
           nameof(AddCommand),
           typeof(ICommand),
           typeof(ItemsPanel),
           new PropertyMetadata(null));

        

        //public ItemsPanel(CommandBinding addServerCommand)
        //{
        //    AddServerCommand = addServerCommand;
        //}
    }
}
