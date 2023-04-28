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
    public partial class External_Marks_Result : System.Web.UI.Page
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

                sql = "delete from EXTERNAL_EXAM_RESULT";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "select count(USN) from STUDENT where BATCH='" + batch.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                Int32 countStudent = (Int32)cmd.ExecuteScalar();

                /*float set_percentage = (70 * 100) / countStudent;*/
                sql = "select count(USN) from EXTERNAL_MARKS where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "' and PERCENTAGE>=70.00";
                cmd = new SqlCommand(sql, con);
                Int32 countStudent70 = (Int32)cmd.ExecuteScalar();

                sql = "insert into EXTERNAL_EXAM_RESULT (BATCH, SEMESTER, SUBJECT_CODE, TOTAL_STUDENT, TOTAL_STUDENT70) values ('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + countStudent + "','" + countStudent70 + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "update EXTERNAL_EXAM_RESULT set PERCENTAGE = (TOTAL_STUDENT70 * 100) / TOTAL_STUDENT";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "select TOTAL_STUDENT as [TOTAL STUDENT], TOTAL_STUDENT70 as [TOTAL NUMBER OF STUDENTS SCORED ABOVE 70%], PERCENTAGE as [PERCENTAGE OF STUDENTS IN THE BATCH SCORED ABOVE 70%] from EXTERNAL_EXAM_RESULT where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "EXTERNAL_EXAM_RESULT");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.DataSource = ds.Tables["EXTERNAL_EXAM_RESULT"].DefaultView;
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