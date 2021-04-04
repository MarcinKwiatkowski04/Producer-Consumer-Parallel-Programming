using System.Windows;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProducentKonsumentWPF
{
    /// <summary>
    /// interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string connectionString = "Data Source=LAPTOP-564H2LL3;Initial Catalog=PK;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        

        // public static Label prodlabel1;
        public MainWindow()
        {

            InitializeComponent();
            ClearParametersTable();
            
        }

        public void ClearParametersTable()
        {
            connection.Open();

            string queryRemoveParams = "DELETE FROM Parameters";
            SqlCommand cmdRemoveParams = new SqlCommand(queryRemoveParams, connection);
            cmdRemoveParams.ExecuteScalar();

            connection.Close();
        }

        public void FillParameters()
        {
            connection.Open();           
            

            if (inputModeComboBox.SelectedIndex == 0)
            {
                string queryAddParams = "INSERT INTO Parameters(StorageSize, ProgramMode) VALUES (" + Int32.Parse(inputStorageSizeTextBox.Text) + ", 0)";
                SqlCommand cmdAddParams = new SqlCommand(queryAddParams, connection);
                cmdAddParams.ExecuteScalar();
            }
            else if (inputModeComboBox.SelectedIndex == 1)
            {
                string queryAddParams = "INSERT INTO Parameters(StorageSize, ProgramMode) VALUES (" + Int32.Parse(inputStorageSizeTextBox.Text) + ", 1)";
                SqlCommand cmdAddParams = new SqlCommand(queryAddParams, connection);
                cmdAddParams.ExecuteScalar();
            }
            else if (inputModeComboBox.SelectedIndex == 2)
            {
                string queryAddParams = "INSERT INTO Parameters(StorageSize, ProgramMode) VALUES (" + Int32.Parse(inputStorageSizeTextBox.Text) + ", 2)";
                SqlCommand cmdAddParams = new SqlCommand(queryAddParams, connection);
                cmdAddParams.ExecuteScalar();
            }
            else if (inputModeComboBox.SelectedIndex == 3)
            {
                string queryAddParams = "INSERT INTO Parameters(StorageSize, ProgramMode) VALUES (" + Int32.Parse(inputStorageSizeTextBox.Text) + ", 3)";
                SqlCommand cmdAddParams = new SqlCommand(queryAddParams, connection);
                cmdAddParams.ExecuteScalar();
            }

            connection.Close();
        }

        private void inputStorageSizeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(inputStorageSizeTextBox.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                return;
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            FillParameters();
            x1p1kWindow x1p1kWin = new x1p1kWindow();
            JedenProdWieluKons JpWk = new JedenProdWieluKons();
            WieluProd1Kons WpJk = new WieluProd1Kons();
            WieluProdWieluKons WpWk = new WieluProdWieluKons();

            if (inputModeComboBox.SelectedIndex == 0) x1p1kWin.Show();
            else if (inputModeComboBox.SelectedIndex == 1) WpJk.Show();
            else if (inputModeComboBox.SelectedIndex == 2) JpWk.Show();
            else if (inputModeComboBox.SelectedIndex == 3) WpWk.Show();
            this.Close();
        }
    }
        
}
