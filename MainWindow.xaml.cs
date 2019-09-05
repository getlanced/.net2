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

namespace DotNet2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        private void button_customer_Click(object sender, RoutedEventArgs e)
        {
            GroupBox1.Visibility = Visibility.Visible;
            GroupBox2.Visibility = Visibility.Hidden;
            GroupBox3.Visibility = Visibility.Hidden;
        }

        private void button_pet_Click(object sender, RoutedEventArgs e)
        {
            GroupBox1.Visibility = Visibility.Hidden;
            GroupBox2.Visibility = Visibility.Visible;
            GroupBox3.Visibility = Visibility.Hidden;
        }

        private void button_room_Click(object sender, RoutedEventArgs e)
        {
            GroupBox1.Visibility = Visibility.Hidden;
            GroupBox2.Visibility = Visibility.Hidden;
            GroupBox3.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GroupBox1.Visibility = Visibility.Visible;
            GroupBox2.Visibility = Visibility.Hidden;
            GroupBox3.Visibility = Visibility.Hidden;
        }

    }
}
