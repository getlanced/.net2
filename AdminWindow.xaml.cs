﻿using System;
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

        private void Btn_AdminSearch_Click(object sender, RoutedEventArgs e)
        {
            if (tb_AdminEmpId.Text == "")
            {
                MessageBox.Show("Please enter Employee ID to search.");
            }
            else
            {
                long searchID = Convert.ToInt64(tb_AdminEmpId.Text);
                AdminDAL aD = new AdminDAL();
                EmpDetails results = aD.SearchByEmpID(searchID);
                tb_AdminFirstName.Text = results.Emp_FirstName;
                tb_AdminLastName.Text = results.Emp_LastName;
                tb_AdminAddLine1.Text = results.Emp_AddLine1;
                tb_AdminAddLine2.Text = results.Emp_AddLine2;
                tb_AdminMobileNo.Text = Convert.ToString(results.Emp_MobileNo);
                tb_AdminHouseNo.Text = Convert.ToString(results.Emp_HouseNo);
                comboBox_AdminGender.SelectedIndex = results.Emp_GenderID;
                tb_AdminPassword.Text = results.Emp_Password;
                comboBox_AdminPrivilege.SelectedIndex = Convert.ToInt32(results.Emp_PrivelegeID);
            }
        }
    }
}
