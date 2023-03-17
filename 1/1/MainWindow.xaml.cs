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

namespace _1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<List<Student>> students = new List<List<Student>>()
        {
            new List<Student>() {},new List<Student>() {},new List<Student>() {},new List<Student>() {},
            new List<Student>() {},new List<Student>() {},new List<Student>() {},new List<Student>() {}
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txbGroup.Text!=null && txbName.Text != null && txbAge.Text != null && txbGroup.Text != null)
            {
                if (null == students[cmbGroup.SelectedIndex].Find(p => p.Имя == txbName.Text && p.Фамилия == txbSur.Text))
                {
                    students[cmbGroup.SelectedIndex].Add(new Student() { Имя = txbName.Text, Фамилия = txbSur.Text, Возраст = int.Parse(txbAge.Text), Группа = txbGroup.Text});
                    txbName.Text = null; txbSur.Text = null; txbAge.Text = null;
                }
            }

            dtgStudent.ItemsSource = null;
            dtgStudent.ItemsSource= students[cmbGroup.SelectedIndex];
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if(txbName2.Text!=null && txbSur2.Text != null && txbAge2.Text != null)
            {
                Student student = students[cmbGroup.SelectedIndex].Find(p => p.Имя == txbName2.Text && p.Фамилия == txbSur2.Text && int.Parse(txbAge2.Text) == p.Возраст && p.Группа == txbGroup.Text);
                
                if (null != student)
                {
                    students[cmbGroup.SelectedIndex].Remove(student);
                    txbName2.Text = null; txbSur2.Text = null;  txbAge2.Text = null;
                }

            }
            dtgStudent.ItemsSource = null;
            dtgStudent.ItemsSource = students[cmbGroup.SelectedIndex];

        }

        private void btnRem_Click(object sender, RoutedEventArgs e)
        {


            if (txbName3.Text != null && txbSur3.Text != null && txbAge3.Text != null)
            {
                Student student = students[cmbGroup.SelectedIndex].Find(p => p.Имя == txbName2.Text && p.Фамилия == txbSur2.Text && int.Parse(txbAge2.Text) == p.Возраст && p.Группа == txbGroup.Text);

                if (null != student)
                {
                    students[cmbGroup.SelectedIndex][students[cmbGroup.SelectedIndex].IndexOf(student)] = new Student
                    {
                        Имя = txbName3.Text, Фамилия = txbSur3.Text, Возраст = int.Parse(txbAge3.Text), Группа=txbGroup.Text 
                    };
                    txbName3.Text = null; txbSur3.Text = null; txbAge3.Text = null;
                }

            }
            dtgStudent.ItemsSource = null;
            dtgStudent.ItemsSource = students[cmbGroup.SelectedIndex];
        }

        private void dtgStudent_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Student student = (Student)dtgStudent.SelectedItem;

            txbName2.Text = student?.Имя;
            txbSur2.Text = student?.Фамилия;
            txbAge2.Text = ""+student?.Возраст;

            txbName3.Text = student?.Имя;
            txbSur3.Text = student?.Фамилия;
            txbAge3.Text = "" + student?.Возраст;
        }

        private void cmbGroup_Selected(object sender, RoutedEventArgs e)
        {
            dtgStudent.ItemsSource = null;
            dtgStudent.ItemsSource = students[cmbGroup.SelectedIndex];

        }

        private void txbAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = (TextBox)sender;

            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
              && (!textBox.Text.Contains(".")
              && textBox.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }

    public class Student
    {
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public int Возраст { get; set; }
        public string Группа { get; set; }
    }
}
