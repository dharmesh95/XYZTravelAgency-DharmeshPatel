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

namespace XYZTravelAgency_DharmeshPatel
{
    public partial class RegisterForm : Form
    {
        // string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dharmesh\Documents\XYZ-DharmeshPatel.mdf;Integrated Security=True;Connect Timeout=30";
        string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\John\source\repos\ITE5230_WindowsAppDev\XYZTravelAgency\XYZTravelAgency-DharmeshPatel\Database1.mdf;Integrated Security = True";

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                string query = "SELECT * FROM InterestedVacationPlan";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    comboBoxPlan.Items.Add(row["Name"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Equals("") || textBoxAddress.Text.Equals("") || comboBoxPlan.Text.Equals("") || dateTimePicker.Text.Equals(""))
            {
                MessageBox.Show("Please fill all values");
                return;
            }

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                string sqlString = "INSERT INTO Users (Name, Address, InterestedVacationPlan, Date) VALUES ('"
                    + textBoxName.Text + "','" + textBoxAddress.Text + "','" + comboBoxPlan.Text + "','"
                    + dateTimePicker.Text + "')";

                SqlCommand insertCommand = new SqlCommand(sqlString, connection);

                int count = insertCommand.ExecuteNonQuery();

                if (count != 0)
                {
                    MessageBox.Show("Row inserted");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }
    }
}
