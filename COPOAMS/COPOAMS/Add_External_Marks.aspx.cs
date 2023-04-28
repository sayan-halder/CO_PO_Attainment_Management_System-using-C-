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
    public partial class Add_External_Marks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void batch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                usn.Items.Clear();
                usn.Items.Add("Select USN");

                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Lenovo\Documents\COPOAMS_Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                String sql = "select USN from STUDENT where BATCH='" + batch.SelectedItem + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                usn.DataSource = cmd.ExecuteReader();
                usn.DataValueField = "USN";
                usn.DataBind();
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
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
                String sql;
                SqlCommand cmd;
                String pct;

                sql = "insert into EXTERNAL_MARKS (BATCH, SEMESTER, SUBJECT_CODE, USN, MARKS) values ('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + usn.SelectedItem + "','" + marks.Text + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "update EXTERNAL_MARKS set PERCENTAGE = (MARKS * 100) / 100";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "select PERCENTAGE from EXTERNAL_MARKS where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "' and USN='" + usn.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    pct = sdr["PERCENTAGE"].ToString();
                    /*percentage.Text = pct;*/
                    pctg.Text = pct+"%";
                }
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            batch.SelectedIndex = batch.Items.IndexOf(batch.Items.FindByValue("Select batch"));
            semester.SelectedIndex = semester.Items.IndexOf(semester.Items.FindByValue("Select semester number"));
            subject_code.Items.Clear();
            subject_code.Items.Add("Select subject code");
            usn.Items.Clear();
            usn.Items.Add("Select USN");
            marks.Text = "";
            pctg.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Home_Page.aspx");
        }
    }
}