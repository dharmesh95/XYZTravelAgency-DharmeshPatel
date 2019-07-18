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
    public partial class GroupForm : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dharmesh\Documents\XYZ-DharmeshPatel.mdf;Integrated Security=True;Connect Timeout=30";
        List<string> plans = new List<string>();
        List<string> dates = new List<string>();
        List<User> users = new List<User>();

        public GroupForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            labelGroups.Text = "";
            int size = Convert.ToInt32(numericUpDown1.Value);
            if (numericUpDown1.Value <= 1)
            {
                MessageBox.Show("Please Enter Group Size more than 1");
            }
            else
            {
                for (int i = 0; i < plans.Count; i++)
                {
                    string plan = plans[i];
                    string date = dates[i];
                    try
                    {
                        SqlConnection con = new SqlConnection(connectionString);

                        string query = "SELECT * FROM Users WHERE InterestedVacationPlan='" + plan + "' and Date='" + date + "'";
                        SqlDataAdapter da = new SqlDataAdapter(query, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        users.Clear();
                        foreach (DataRow row in dt.Rows)
                        {
                            users.Add(new User(Convert.ToInt32(row["RegistrationID"]), row["Name"].ToString(), row["Address"].ToString(), row["InterestedVacationPlan"].ToString(), row["Date"].ToString()));
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                    for (int j = 0; j < users.Count; j += size)
                    {
                        String userString = "";

                        try
                        {
                            for (int k = 0; k < size; k++)
                            {
                                userString += users[j+k].regID + " ";
                            }
                            insertGroup(plan, date, userString);
                        }
                        catch (Exception ex)
                        {
                            insertGroup(plan, date, userString);
                        }
                    }

                }
            }
        }

        private void insertGroup(string plan, string date, string userString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                string sqlString = "INSERT INTO GroupInformation (InterestedPackage, Date, Users) VALUES ('"
                    + plan + "','" + date + "','" + userString + "')";

                SqlCommand insertCommand = new SqlCommand(sqlString, connection);

                int count = insertCommand.ExecuteNonQuery();

                if (count != 0)
                {
                    labelGroups.Text += plan + " --- " + date + " --- " + userString;
                    MessageBox.Show("Row inserted");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                string query = "SELECT distinct InterestedVacationPlan, Date FROM Users";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                plans.Clear();
                dates.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    plans.Add(row["InterestedVacationPlan"].ToString());
                    dates.Add(row["Date"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }


        }
    }
}
