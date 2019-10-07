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

namespace PMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginWindow parentWindow;
        LoginDAL usingDal = new LoginDAL();
        public MainWindow(LoginWindow parent, LoginDAL x)
        {
            parentWindow = parent;
            usingDal = x;
            InitializeComponent();
            Loaded += Window_Loaded;
            if (x.EmpPrivelege)
                btn_MainManageUsers.IsEnabled = true;
            else
                btn_MainManageUsers.IsEnabled = false;
        }

        private void button_customer_Click(object sender, RoutedEventArgs e)
        {
            GroupBox1.Visibility = Visibility.Visible;
            GroupBox2.Visibility = Visibility.Hidden;
        }

        private void button_pet_Click(object sender, RoutedEventArgs e)
        {
            GroupBox1.Visibility = Visibility.Hidden;
            GroupBox2.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GroupBox1.Visibility = Visibility.Visible;
            GroupBox2.Visibility = Visibility.Hidden;
        }

        private void Btn_MainLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            parentWindow.Show();
        }

        private void Btn_MainManageUsers_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow(this);
            this.Hide();
            adminWindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parentWindow.Show();
        }
    }
}
