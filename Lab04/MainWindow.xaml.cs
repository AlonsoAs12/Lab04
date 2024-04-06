using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Lab04
{
    public partial class MainWindow : Window
    {
        string connectionString = "Data Source=LAB1504-25\\SQLEXPRESS;Initial Catalog=LAB03;Integrated Security=True";

        public MainWindow()
        {
            InitializeComponent();

            LoadData(datagridCategorias, "ListarCategorias");

            LoadData(datagridProveedores, "ListarProveedores");
        }

        private void LoadData(DataGrid datagrid, string storedProcedureName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    SqlCommand command = new SqlCommand(storedProcedureName, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    adapter.SelectCommand = command;

                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    datagrid.ItemsSource = table.DefaultView;

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
