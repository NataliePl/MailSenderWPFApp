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
            set => SetValue(TitleProperty, value);
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

        public IEnumerable ItemsList
        {
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


        #region RemoveCommand
        /// <summary> Удаление элемента </summary>
        public static readonly DependencyProperty RemoveItemCommandProperty =
            DependencyProperty.Register(
                nameof(RemoveItemCommand),
                typeof(ICommand),
                typeof(ItemsPanel),
                new PropertyMetadata(default(ICommand)));

        public ICommand RemoveItemCommand
        {
            get => (ICommand)GetValue(RemoveItemCommandProperty);
            set => SetValue(RemoveItemCommandProperty, value);
        }

        #endregion
        
        #region EditCommand
        /// <summary> Удаление элемента </summary>
        public static readonly DependencyProperty EditItemCommandProperty =
            DependencyProperty.Register(
                nameof(EditItemCommand),
                typeof(ICommand),
                typeof(ItemsPanel),
                new PropertyMetadata(default(ICommand)));

        public ICommand EditItemCommand
        {
            get => (ICommand)GetValue(EditItemCommandProperty);
            set => SetValue(EditItemCommandProperty, value);
        }
        #endregion

        #region Выбранный элемент
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                nameof(SelectedItem),
                typeof(object),
                typeof(ItemsPanel),
                new PropertyMetadata(default(object)));

        public object SelectedItem { get => (object)GetValue(SelectedItemProperty); set => SetValue(SelectedItemProperty, value); }
        #endregion


        #region ItemTemplate Шаблон элемента выпадающего списка
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register(
                nameof(DataTemplate),
                typeof(object),
                typeof(ItemsPanel),
                new PropertyMetadata(default(object)));

        public DataTemplate ItemTemplate { get => (DataTemplate)GetValue(ItemTemplateProperty); set => SetValue(ItemTemplateProperty, value); }
        #endregion

        #region string имя отображаемого свойства
        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register(
                nameof(DisplayMemberPath),
                typeof(string),
                typeof(ItemsPanel),
                new PropertyMetadata(default(object)));

        public String DisplayMemberPath { get => (String)GetValue(DisplayMemberPathProperty); set => SetValue(DisplayMemberPathProperty, value); }
        #endregion


        //public ItemsPanel(CommandBinding addServerCommand)
        //{
        //    AddServerCommand = addServerCommand;
        //}
    }
}
