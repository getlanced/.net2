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
using System.Windows.Shapes;

namespace PMS
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MainWindow parentWindow;
        public AdminWindow(MainWindow parent)
        {
            parentWindow = parent;
            InitializeComponent();
        }

        private void Btn_AdminExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            parentWindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parentWindow.Show();
        }

        private void Btn_Admin_Existing_Click(object sender, RoutedEventArgs e)
        {
            btn_Admin_New.IsEnabled = true;
            btn_Admin_Existing.IsEnabled = false;
            grp_EmpSearch.IsEnabled = true;
        }

        private void Btn_Admin_New_Click(object sender, RoutedEventArgs e)
        {
            btn_Admin_New.IsEnabled = false;
            btn_Admin_Existing.IsEnabled = true;
            grp_EmpSearch.IsEnabled = false;
        }
    }
}
