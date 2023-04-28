using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace COPOAMS
{
    public partial class Show_IA_Marks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                subject_code.Items.Clear();
                subject_code.Items.Add("Select subject code");

                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Lenovo\Documents\COPOAMS_Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                String sql = "select SUBJECT_CODE from SUBJECT where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                subject_code.DataSource = cmd.ExecuteReader();
                subject_code.DataValueField = "SUBJECT_CODE";
                subject_code.DataBind();
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Lenovo\Documents\COPOAMS_Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                String sql = "SELECT USN as [USN], Q1 as [QUESTION 1], Q2 as [QUESTION 2], Q3 as [QUESTION 3], Q4 as [QUESTION 4], Q5 as [QUESTION 5], Q6 as [QUESTION 6], Q7 as [QUESTION 7], Q8 as [QUESTION 8], Q9 as [ASSINGMENT] FROM IAM where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "' and IA_NUMBER='" + ia_number.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "IAM");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.DataSource = ds.Tables["IAM"].DefaultView;
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("Home_Page.aspx");
        }
    }
}