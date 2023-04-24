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
    public partial class Add_IA_COs : System.Web.UI.Page
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
                String sql;
                SqlCommand cmd;
                
                sql = "insert into IA_COS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, QUESTION, CO) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + 1 + "','" + q1.SelectedItem + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "insert into IA_COS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, QUESTION, CO) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + 2 + "','" + q2.SelectedItem + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "insert into IA_COS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, QUESTION, CO) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + 3 + "','" + q3.SelectedItem + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "insert into IA_COS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, QUESTION, CO) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + 4 + "','" + q4.SelectedItem + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "insert into IA_COS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, QUESTION, CO) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + 5 + "','" + q5.SelectedItem + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "insert into IA_COS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, QUESTION, CO) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + 6 + "','" + q6.SelectedItem + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "insert into IA_COS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, QUESTION, CO) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + 7 + "','" + q7.SelectedItem + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "insert into IA_COS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, QUESTION, CO) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + 8 + "','" + q8.SelectedItem + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "insert into IA_COS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, QUESTION, CO) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + 9 + "','" + asgn.SelectedItem + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('COs for IA-" + ia_number.SelectedItem + " added successfully.');window.location ='" + "Add_IA_COs.aspx" + "';", true);
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
            ia_number.SelectedIndex = ia_number.Items.IndexOf(ia_number.Items.FindByValue("Select IA number"));
            q1.SelectedIndex = q1.Items.IndexOf(q1.Items.FindByValue("Select CO number"));
            q2.SelectedIndex = q2.Items.IndexOf(q3.Items.FindByValue("Select CO number"));
            q3.SelectedIndex = q3.Items.IndexOf(q3.Items.FindByValue("Select CO number"));
            q4.SelectedIndex = q4.Items.IndexOf(q4.Items.FindByValue("Select CO number"));
            q5.SelectedIndex = q5.Items.IndexOf(q5.Items.FindByValue("Select CO number"));
            q6.SelectedIndex = q6.Items.IndexOf(q6.Items.FindByValue("Select CO number"));
            q7.SelectedIndex = q7.Items.IndexOf(q7.Items.FindByValue("Select CO number"));
            q8.SelectedIndex = q8.Items.IndexOf(q8.Items.FindByValue("Select CO number"));
            asgn.SelectedIndex = asgn.Items.IndexOf(asgn.Items.FindByValue("Select CO number"));
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Home_Page.aspx");
        }
    }
}