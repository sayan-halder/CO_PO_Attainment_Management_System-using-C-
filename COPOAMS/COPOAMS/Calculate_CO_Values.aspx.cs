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
    public partial class Calculate_CO_Values : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Lenovo\Documents\COPOAMS_Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            con.Open();
            String sql = "delete from CO_RESULT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();*/
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

        protected void CO_Result()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Lenovo\Documents\COPOAMS_Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                String sql;
                SqlCommand cmd;

                sql = "select count(USN) from CO_CALCULATION where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "' and CO='" + co.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                Int32 countStudent = (Int32)cmd.ExecuteScalar();
                
                sql = "select count(USN) from CO_CALCULATION where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "' and CO='" + co.SelectedItem + "' and TARGET='Y'";
                cmd = new SqlCommand(sql, con);
                Int32 countStudentCO = (Int32)cmd.ExecuteScalar();

                sql = "insert into CO_RESULT (BATCH, SEMESTER, SUBJECT_CODE, CO, TOTAL_STUDENT, TOTAL_CO) values ('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + co.SelectedItem + "','" + countStudent + "','" + countStudentCO + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                
                sql = "update CO_RESULT set PERCENTAGE=(TOTAL_CO * 100) / TOTAL_STUDENT where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "' and CO='" + co.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('AAA: " + countStudent + " BBB: " + countStudentCO + " added successfully.');", true); 
                
                sql = "select TOTAL_STUDENT as [TOTAL STUDENTS], TOTAL_CO as [TOTAL STUDENTS SCORED ABOVE 70% IN THIS CO], PERCENTAGE as [PERCENTAGE] from CO_RESULT where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "' and CO='" + co.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "CO_RESULT");
                GridView2.DataSource = ds;
                GridView2.DataBind();
                GridView2.DataSource = ds.Tables["CO_RESULT"].DefaultView;
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

                sql = "delete from CO_CALCULATION";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                if (String.Equals("5", co.SelectedItem.ToString()))
                {
                    sql = "insert into CO_CALCULATION (BATCH, SEMESTER, SUBJECT_CODE, USN, CO, COUNT_QUESTION, TOTAL_MARKS) select BATCH, SEMESTER, SUBJECT_CODE, USN, CO, count(QUESTION)*10, sum(MARKS)*100 from IA_MARKS where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "' and CO='" + co.SelectedItem + "' and MARKS>-1 group by BATCH, SEMESTER, SUBJECT_CODE, USN, CO";
                }
                else
                {
                    sql = "insert into CO_CALCULATION (BATCH, SEMESTER, SUBJECT_CODE, USN, CO, COUNT_QUESTION, TOTAL_MARKS) select BATCH, SEMESTER, SUBJECT_CODE, USN, CO, count(QUESTION)*8, sum(MARKS)*100 from IA_MARKS where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "' and CO='" + co.SelectedItem + "' and MARKS>-1 group by BATCH, SEMESTER, SUBJECT_CODE, USN, CO";
                    
                }
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "update CO_CALCULATION set PERCENTAGE=TOTAL_MARKS / COUNT_QUESTION";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "update CO_CALCULATION set TARGET = 'Y' where PERCENTAGE >= 70.00";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "update CO_CALCULATION set TARGET = 'N' where PERCENTAGE < 70.00";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "SELECT USN as [USN], PERCENTAGE as [PERCENTAGE], TARGET as [TARGET (Y/N)] FROM CO_CALCULATION where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "' and CO='" + co.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "CO_CALCULATION");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.DataSource = ds.Tables["CO_CALCULATION"].DefaultView;

                CO_Result();
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