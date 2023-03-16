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

namespace _2._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public List<Person> peoples = new List<Person>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var p = new Person()
            {
                name = txbName.Text, age = int.Parse(txbAge.Text)
            };
            peoples.Add(p);

            lbxEmploy.Items.Add(p.name + " " + p.age);

            dtGrid.ItemsSource = null;

            dtGrid.ItemsSource = peoples;
        }

        private void txbAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }

    public class Person
    {
        public string name { get; set; }

        public int age { get; set; }
    }
}
