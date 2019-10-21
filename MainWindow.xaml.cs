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
            button_customer.IsEnabled = false;
            button_pet.IsEnabled = true;
        }

        private void button_pet_Click(object sender, RoutedEventArgs e)
        {
            GroupBox1.Visibility = Visibility.Hidden;
            GroupBox2.Visibility = Visibility.Visible;
            button_customer.IsEnabled = true;
            button_pet.IsEnabled = false;
            Grid_PetID_PetManager.IsEnabled = false;
            groupBox_PetDetails.IsEnabled = false;
            groupBox_RegisteredPets.IsEnabled = false;
            groupBox_RoomAssignment.IsEnabled = false;
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

        private void Existing_CustomerManager_Click(object sender, RoutedEventArgs e)
        {
            Existing_CustomerManager.IsEnabled = false;
            New_CustomerManager.IsEnabled = true;
            grp_Box_Main_Cust_ID.IsEnabled = true;
            button_Register_Credentials.IsEnabled = false;
            button_Print.IsEnabled = false;
            button_Save_Credentials.IsEnabled = true;
        }

        private void New_CustomerManager_Click(object sender, RoutedEventArgs e)
        {
            New_CustomerManager.IsEnabled = false;
            Existing_CustomerManager.IsEnabled = true;
            grp_Box_Main_Cust_ID.IsEnabled = false;
            button_Register_Credentials.IsEnabled = true;
            button_Print.IsEnabled = true;
            button_Save_Credentials.IsEnabled = false;
        }

        private void button_New_RegisteredPets_Click(object sender, RoutedEventArgs e)
        {
            comboBo_Pets_RegisteredPets.IsEnabled = false;
            groupBox_PetDetails.IsEnabled = true;
            groupBox_RoomAssignment.IsEnabled = false;
            button_CheckIn_PetDetails.IsEnabled = false;
            button_CheckOut_PetDetails.IsEnabled = false;
            button_Modify_RegisteredPets.IsEnabled = false;
            button_Register_PetDetails.IsEnabled = true;
            button_Back_RegisteredPets.IsEnabled = false;
            button_Back_RegisteredPets.IsEnabled = true;
        }

        private void button_Modify_RegisteredPets_Click(object sender, RoutedEventArgs e)
        {
            groupBox_PetDetails.IsEnabled = true;
            groupBox_RoomAssignment.IsEnabled = false;
            button_CheckIn_PetDetails.IsEnabled = false;
            button_CheckOut_PetDetails.IsEnabled = false;
            button_Back_RegisteredPets.IsEnabled = true;
        }

        private void comboBo_Pets_RegisteredPets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            button_CheckIn_PetDetails.IsEnabled = true;
            button_CheckOut_PetDetails.IsEnabled = true;
            button_Save_PetDetails.IsEnabled = false;
            button_Remove_PetDetails.IsEnabled = false;
            button_Register_PetDetails.IsEnabled = false;
            button_Modify_RegisteredPets.IsEnabled = true;
        }

        private void button_CheckIn_PetDetails_Click(object sender, RoutedEventArgs e)
        {
            groupBox_RoomAssignment.IsEnabled = true;
        }

        private void button_SearchBy_Click(object sender, RoutedEventArgs e)
        {
            if (button_SearchBy.Content.ToString() == "Search by Pet ID")
            {
                button_SearchBy.Content = "Search by Customer ID";
                Grid_CustomerID_PetManager.IsEnabled = false;
                Grid_PetID_PetManager.IsEnabled = true;
            }
            else if (button_SearchBy.Content.ToString() == "Search by Customer ID")
            {
                button_SearchBy.Content = "Search by Pet ID";
                Grid_CustomerID_PetManager.IsEnabled = true;
                Grid_PetID_PetManager.IsEnabled = false;
            }
        }

        private void button_searchID_PetManager_Click(object sender, RoutedEventArgs e)
        {
            if (button_SearchBy.Content.ToString() == "Search by Pet ID")
            {
                //Customer ID
                groupBox_PetDetails.IsEnabled = false;
                groupBox_RegisteredPets.IsEnabled = true;
                groupBox_RoomAssignment.IsEnabled = false;
                button_CheckIn_PetDetails.IsEnabled = true;
                button_CheckOut_PetDetails.IsEnabled = true;
                button_Modify_RegisteredPets.IsEnabled = false;
                comboBo_Pets_RegisteredPets.SelectedItem = null;
                comboBo_Pets_RegisteredPets.IsEnabled = true;
            }
            else if (button_SearchBy.Content.ToString() == "Search by Customer ID")
            {
                //Pet ID
                groupBox_PetDetails.IsEnabled = true;
                groupBox_RegisteredPets.IsEnabled = false;
                groupBox_RoomAssignment.IsEnabled = false;
                button_CheckIn_PetDetails.IsEnabled = false;
                button_CheckOut_PetDetails.IsEnabled = false;
                button_Remove_PetDetails.IsEnabled = false;
                button_Save_PetDetails.IsEnabled = false;
            }
            button_Back_RegisteredPets.IsEnabled = false;
        }

        private void button_clear_PetManager_Click(object sender, RoutedEventArgs e)
        {
            if (button_SearchBy.Content.ToString() == "Search by Pet ID")
            {
                txtbox_CustomerID_PetManager.Text = string.Empty;
            }
            else if (button_SearchBy.Content.ToString() == "Search by Customer ID")
            {
                txtbox_PetID_PetManager.Text = string.Empty;
            }
        }

        private void button_Register_PetDetails_Click(object sender, RoutedEventArgs e)
        {
            button_CheckIn_PetDetails.IsEnabled = true;
            button_CheckOut_PetDetails.IsEnabled = true;
        }

        private void button_Back_RegisteredPets_Click(object sender, RoutedEventArgs e)
        {
            comboBo_Pets_RegisteredPets.IsEnabled = true;
            groupBox_PetDetails.IsEnabled = false;
            groupBox_RoomAssignment.IsEnabled = false;
            if (comboBo_Pets_RegisteredPets.SelectedIndex >= 0)
                button_Modify_RegisteredPets.IsEnabled = true;
            else
                button_Modify_RegisteredPets.IsEnabled = false;
        }
    }
}
