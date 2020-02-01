using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbRead();
        }

        private static void dbRead()
        {
            string connectionString = "Server=DESKTOP-48F44VT; Database=TheWitcher; Trusted_Connection=True";

            string column = "profession";
            string filter = "Sorceress";
            string queryString =
                $"select * from People where {column} = '{filter}'"; //"where profession = \'Sorceress\'";

            var dataTable = new DataTable(); //holds a vitual table from the above function call

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();

                //create data adapter
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    dataAdapter.Fill(dataTable); //can also use datareader for optimisation

                }

            }
        }
    }
}
