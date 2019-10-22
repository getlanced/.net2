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
        // will change this to groupbox class to prevent spaghetti code
        //Upon Created
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GroupBox1.Visibility = Visibility.Visible;
            GroupBox2.Visibility = Visibility.Hidden;
        }

        //Customer Manager Button
        private void button_customer_Click(object sender, RoutedEventArgs e)
        {
            GroupBox1.Visibility = Visibility.Visible;
            GroupBox2.Visibility = Visibility.Hidden;
            button_customer.IsEnabled = false;
            button_pet.IsEnabled = true;
        }

        //Customer Pet Manager
        private void button_pet_Click(object sender, RoutedEventArgs e)
        {
            GroupBox1.Visibility = Visibility.Hidden;
            GroupBox2.Visibility = Visibility.Visible;

            button_customer.IsEnabled = true;
            button_pet.IsEnabled = false;

            Grid_PetID_PetManager.IsEnabled = false;
            Grid_CustomerID_PetManager.IsEnabled = true;

            button_searchID_PetManager.IsEnabled = true;
            button_clear_PetManager.IsEnabled = false;

            groupBox_PetDetails.IsEnabled = false;
            groupBox_RegisteredPets.IsEnabled = false;
            groupBox_RoomAssignment.IsEnabled = false;
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
            comboBo_Pets_RegisteredPets.SelectedItem = null;
            comboBo_Pets_RegisteredPets.IsEnabled = false;

            groupBox_PetDetails.IsEnabled = true;

            button_Modify_RegisteredPets.IsEnabled = false;
            button_New_RegisteredPets.IsEnabled = false;

            ClearPetDetails();
            button_Save_PetDetails.IsEnabled = false;
            button_Back_RegisteredPets.IsEnabled = true;
            button_CheckIn_PetDetails.IsEnabled = false;
            button_CheckOut_PetDetails.IsEnabled = false;            
            button_Register_PetDetails.IsEnabled = true;            
            button_Remove_PetDetails.IsEnabled = false;
        }

        private void button_Modify_RegisteredPets_Click(object sender, RoutedEventArgs e)
        {
            ClearPetDetails();
            //LoadPetDetails();
            button_New_RegisteredPets.IsEnabled = false;
            comboBo_Pets_RegisteredPets.IsEnabled = false;
            groupBox_PetDetails.IsEnabled = true;
            button_Modify_RegisteredPets.IsEnabled = false;
            button_Back_RegisteredPets.IsEnabled = true;

            if (string.IsNullOrWhiteSpace(textBox_LastCheckIn_PetDetails.Text))
            {
                button_CheckIn_PetDetails.IsEnabled = true;
                button_CheckOut_PetDetails.IsEnabled = false;
            }
            else
            {
                button_CheckIn_PetDetails.IsEnabled = false;
                button_CheckOut_PetDetails.IsEnabled = true;
            }
            button_Register_PetDetails.IsEnabled = false;
            button_Save_PetDetails.IsEnabled = true;
            button_Remove_PetDetails.IsEnabled = true;
        }
        private void button_CheckIn_PetDetails_Click(object sender, RoutedEventArgs e)
        {
            groupBox_PetDetails.IsEnabled = false;
            groupBox_RegisteredPets.IsEnabled = false;
            groupBox_RoomAssignment.IsEnabled = true;
            button_CheckIn_PetDetails.IsEnabled = false;
            button_Back_RoomAssignment.IsEnabled = true;
            radioButton_single_RoomType.IsChecked = true;
        }

        private void button_SearchBy_Click(object sender, RoutedEventArgs e)
        {
            Return2PreviousState();
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
        private void Return2PreviousState()
        {
            txtbox_PetID_PetManager.Clear();
            txtbox_CustomerID_PetManager.Clear();

            groupBox_PetDetails.IsEnabled = false;
            comboBo_Pets_RegisteredPets.SelectedItem = null;

            groupBox_RegisteredPets.IsEnabled = false;
            ClearPetDetails();
            groupBox_RoomAssignment.IsEnabled = false;

            button_clear_PetManager.IsEnabled = false;
            Grid_CustomerID_PetManager.IsEnabled = true;
            Grid_PetID_PetManager.IsEnabled = false;
            button_searchID_PetManager.IsEnabled = true;
            PetManager_DetailsReadabilityMode(1);
        }

        private void ClearPetDetails()
        {
            textBox_PetID_PetDetails.Text = "";
            textBox_Name_PetDetails.Text = "";
            textBox_Breed_PetDetails.Text = "";
            comboBox_Type_PetDetails.SelectedItem = 0;
            comboBox_Gender_PetDetails.SelectedItem = 0;

            textBox_RoomAssigned_PetDetails.Text = "";
            textBox_LastCheckIn_PetDetails.Text = "";
            textBox_LastCheckOut_PetDetails.Text = "";
            textBox_DateRegistered_PetDetails.Text = "";
        }
        private void button_searchID_PetManager_Click(object sender, RoutedEventArgs e)
        {
            Return2PreviousState();
            button_searchID_PetManager.IsEnabled = false;
            button_clear_PetManager.IsEnabled = true;

            if (button_SearchBy.Content.ToString() == "Search by Pet ID")
            {
                //Customer ID 
                groupBox_RegisteredPets.IsEnabled = true;
                groupBox_PetDetails.IsEnabled = false;                
                groupBox_RoomAssignment.IsEnabled = false;

                comboBo_Pets_RegisteredPets.SelectedItem = null;
                button_New_RegisteredPets.IsEnabled = true;
                button_Modify_RegisteredPets.IsEnabled = false;

                
            }
            else if (button_SearchBy.Content.ToString() == "Search by Customer ID")
            {
                //Pet ID
                PetManager_DetailsReadabilityMode(0);
                groupBox_RegisteredPets.IsEnabled = false;
                groupBox_RoomAssignment.IsEnabled = false;

                groupBox_PetDetails.IsEnabled = true;
                button_CheckIn_PetDetails.IsEnabled = false;
                button_CheckOut_PetDetails.IsEnabled = false;
                button_Remove_PetDetails.IsEnabled = false;
                button_Save_PetDetails.IsEnabled = false;
                button_Register_PetDetails.IsEnabled = false;
            }
            button_Modify_RegisteredPets.IsEnabled = true;
            comboBo_Pets_RegisteredPets.IsEnabled = true;
            button_Back_RegisteredPets.IsEnabled = false;
        }

        private void button_clear_PetManager_Click(object sender, RoutedEventArgs e)
        {
            Return2PreviousState();
            if (button_SearchBy.Content.ToString() == "Search by Pet ID")            
                txtbox_CustomerID_PetManager.Text = string.Empty;            
            else if (button_SearchBy.Content.ToString() == "Search by Customer ID")            
                txtbox_PetID_PetManager.Text = string.Empty;
            button_searchID_PetManager.IsEnabled = true;
        }

        private void button_Register_PetDetails_Click(object sender, RoutedEventArgs e)
        {
            groupBox_PetDetails.IsEnabled = false;
            comboBo_Pets_RegisteredPets.IsEnabled = true;
            button_New_RegisteredPets.IsEnabled = true;
            button_Modify_RegisteredPets.IsEnabled = true;
            button_Back_RegisteredPets.IsEnabled = false;
        }

        private void button_Back_RegisteredPets_Click(object sender, RoutedEventArgs e)
        {
            Button_Back_Save_Remove_PetManager();
        }

        private void Button_Back_RoomAssignment_Click(object sender, RoutedEventArgs e)
        {
            groupBox_PetDetails.IsEnabled = true;
            groupBox_RegisteredPets.IsEnabled = true;
            groupBox_RoomAssignment.IsEnabled = false;
            if (string.IsNullOrWhiteSpace(textBox_LastCheckIn_PetDetails.Text))
            {
                button_CheckIn_PetDetails.IsEnabled = true;
                button_CheckOut_PetDetails.IsEnabled = false;
            }
            else
            {
                button_CheckIn_PetDetails.IsEnabled = false;
                button_CheckOut_PetDetails.IsEnabled = true;
            }
        }

        private void PetManager_DetailsReadabilityMode(int mode)
        {
            switch (mode)
            {
                //Read-only
                case 0:
                    textBox_PetID_PetDetails.IsReadOnly = true;
                    textBox_Name_PetDetails.IsReadOnly = true;
                    textBox_Breed_PetDetails.IsReadOnly = true;
                    comboBox_Type_PetDetails.IsEnabled = false;
                    comboBox_Gender_PetDetails.IsEnabled = false;
                    break;
                //Writeable
                case 1:
                    textBox_PetID_PetDetails.IsReadOnly = false;
                    textBox_Name_PetDetails.IsReadOnly = false;
                    textBox_Breed_PetDetails.IsReadOnly = false;
                    comboBox_Type_PetDetails.IsEnabled = true;
                    comboBox_Gender_PetDetails.IsEnabled = true;
                    break;
                default:
                    MessageBox.Show("Readability Mode Invalid");
                    Return2PreviousState();
                    break;
            }            
        }

        private void Button_Back_Save_Remove_PetManager()
        {
            ClearPetDetails();
            if (button_Save_PetDetails.IsEnabled == true && button_Remove_PetDetails.IsEnabled == true)
            {
                button_CheckIn_PetDetails.IsEnabled = false;
                button_CheckOut_PetDetails.IsEnabled = false;
                button_Save_PetDetails.IsEnabled = false;
                button_Remove_PetDetails.IsEnabled = false;
                groupBox_PetDetails.IsEnabled = false;
            }
            else
                button_Register_PetDetails.IsEnabled = false;

            comboBo_Pets_RegisteredPets.IsEnabled = true;
            groupBox_PetDetails.IsEnabled = false;
            groupBox_RegisteredPets.IsEnabled = true;
            button_New_RegisteredPets.IsEnabled = true;
            button_Modify_RegisteredPets.IsEnabled = true;
            button_Back_RegisteredPets.IsEnabled = false;
            button_searchID_PetManager.IsEnabled = true;
            button_clear_PetManager.IsEnabled = true;
        }
        private void Button_Save_PetDetails_Click(object sender, RoutedEventArgs e)
        {
            Button_Back_Save_Remove_PetManager();
        }

        private void Button_Remove_PetDetails_Click(object sender, RoutedEventArgs e)
        {
            Button_Back_Save_Remove_PetManager();
        }

        private void Button_Assign_RoomAssignment_Click(object sender, RoutedEventArgs e)
        {
            Return2PreviousState();
        }

        private void Button_CheckOut_PetDetails_Click(object sender, RoutedEventArgs e)
        {
            Button_Back_Save_Remove_PetManager();
        }

        public void Register()
        {
            CustDetails collect = new CustDetails();

            collect.Cust_FirstName = FirstName.Text;
            collect.Cust_LastName = LastName.Text;
            collect.Cust_Address = tb_CustomerMan_Address.Text;
            if (comboBox.Text == "Male")
            {
                collect.Cust_Gender = "M";
            }
            else
                collect.Cust_Gender = "F";
            
            collect.Cust_Contact_No = long.Parse(Phone.Text);

            CustomerDAL.addCustomer(collect);
        }
        public void ClearCust()
        {
            txtbox_CustomerID_CustomerManager.Text = string.Empty;
            FirstName.Text = string.Empty;
            LastName.Text = string.Empty;
            tb_CustomerMan_Address.Text = string.Empty;
            Phone.Text = string.Empty;
        }
        private void Button_Register_Credentials_Click(object sender, RoutedEventArgs e)
        {
            Register();
            ClearCust();
        }

        private void Button_Clear_Credentials_Click(object sender, RoutedEventArgs e)
        {
            ClearCust();
        }

        private void Button_Save_Credentials_Click(object sender, RoutedEventArgs e)
        {
            CustDetails collect = new CustDetails();
            //prevent errors
            collect.Cust_Id = long.Parse(txtbox_CustomerID_CustomerManager.Text);
            collect.Cust_FirstName = FirstName.Text;
            collect.Cust_LastName = LastName.Text;
            collect.Cust_Address = tb_CustomerMan_Address.Text;
            if (comboBox.SelectedIndex == 0)
                collect.Cust_Gender = "M";
            else if (comboBox.SelectedIndex == 1)
                collect.Cust_Gender = "F";
            else
                MessageBox.Show("Invalid Combo Box Index");

            collect.Cust_Contact_No = long.Parse(Phone.Text);
            CustomerDAL.UpdateCustomer(collect);
            ClearCust();
        }

        private void Enter_CustomerID_Click(object sender, RoutedEventArgs e)
        {
            long id = long.Parse(txtbox_CustomerID_CustomerManager.Text);

            List<CustDetails> cust = new List<CustDetails>();
            cust = CustomerDAL.searchByCustomer(id);
            foreach (CustDetails p in cust)
            {
                FirstName.Text = p.Cust_FirstName;
                LastName.Text = p.Cust_LastName;
                tb_CustomerMan_Address.Text = p.Cust_Address;

                if (p.Cust_Gender == "M")
                {
                    comboBox.SelectedIndex = 0;
                    Phone.Text = p.Cust_Contact_No.ToString();
                }
                else if (p.Cust_Gender == "F")
                {
                    comboBox.SelectedIndex = 1;
                    Phone.Text = p.Cust_Contact_No.ToString();
                }
                else
                    MessageBox.Show("Invalid Gender Detected.");
            }
        }
    }
}
