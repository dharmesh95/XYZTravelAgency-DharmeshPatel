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
    public partial class DisplayModifyForm : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dharmesh\Documents\XYZ-DharmeshPatel.mdf;Integrated Security=True;Connect Timeout=30";

        public DisplayModifyForm()
        {
            InitializeComponent();
        }

        private void DisplayModifyForm_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                string query = "SELECT * FROM Users";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }

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
            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                string query = "SELECT * FROM Users WHERE RegistrationID='" + textBoxRegID.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    textBoxName.Text = row["Name"].ToString();
                    textBoxAddress.Text = row["Address"].ToString();
                    comboBoxPlan.Text = row["InterestedVacationPlan"].ToString();
                    dateTimePicker.Text = row["Date"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
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

                string sqlString = "UPDATE Users SET Name='"
                    + textBoxName.Text + "',Address='" + textBoxAddress.Text + "',InterestedVacationPlan='"
                    + comboBoxPlan.Text + "',Date='" + dateTimePicker.Text + "' WHERE RegistrationID='" + textBoxRegID.Text + "'";

                SqlCommand insertCommand = new SqlCommand(sqlString, connection);

                int count = insertCommand.ExecuteNonQuery();

                if (count != 0)
                {
                    MessageBox.Show("Row Updated");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DisplayModifyForm_Load(sender, e);
        }
    }
}
