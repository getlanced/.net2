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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Btn_LoginLogin_Click(object sender, RoutedEventArgs e)
        {
            int parsedEmpId;
            bool success = int.TryParse(tb_LoginEmpID.Text,out parsedEmpId);
            if (success)
            {
                var dal = new LoginDAL();
                if (dal.VerifyLogin(parsedEmpId, pb_LoginPass.Password.Trim()) == false)
                    MessageBox.Show("Invalid Entry");
                else
                {
                    dal.UpdateLastLogin();
                    var mainWindow = new MainWindow(this, dal);
                    mainWindow.Show();
                    this.Hide();
                }
            }
            else
                MessageBox.Show("Invalid ID");

            tb_LoginEmpID.Clear();
            pb_LoginPass.Clear();
        }

        private void Btn_LoginExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
