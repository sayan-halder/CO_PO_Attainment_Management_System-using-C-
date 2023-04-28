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
    public partial class CO_Final_Result_Values : System.Web.UI.Page
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

        protected void CalculationUniversity()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Lenovo\Documents\COPOAMS_Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                String sql;
                SqlCommand cmd;
                
                for (int i = 1; i <= 5; i++)
                {
                    sql = "insert into CO_FINAL_RESULT (BATCH, SEMESTER, SUBJECT_CODE, CO, CO_TARGET) values ('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + i + "','" + 3 + "')";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
                
                sql = "select PERCENTAGE from EXTERNAL_EXAM_RESULT where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                decimal pct = Convert.ToDecimal(cmd.ExecuteScalar());
                

                if (pct >= 60)
                {
                    sql = "update CO_FINAL_RESULT set ATTAINMENT_LVL_UNIVERSITY = 3 where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
                else if (pct >= 55)
                {
                    sql = "update CO_FINAL_RESULT set ATTAINMENT_LVL_UNIVERSITY = 2 where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
                else if (pct >= 50)
                {
                    sql = "update CO_FINAL_RESULT set ATTAINMENT_LVL_UNIVERSITY = 1 where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    sql = "update CO_FINAL_RESULT set ATTAINMENT_LVL_UNIVERSITY = 0 where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void CalculationIA()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Lenovo\Documents\COPOAMS_Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                String sql;
                SqlCommand cmd;

                for (int i = 1; i <= 5; i++)
                {
                    sql = "select PERCENTAGE from CO_RESULT where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "'and CO='" + i + "'";
                    cmd = new SqlCommand(sql, con);
                    decimal pct = Convert.ToDecimal(cmd.ExecuteScalar());

                    if (pct >= 60)
                    {
                        sql = "update CO_FINAL_RESULT set ATTAINMENT_LVL_IA = 3 where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "'and CO='" + i + "'";
                        cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (pct >= 55)
                    {
                        sql = "update CO_FINAL_RESULT set ATTAINMENT_LVL_IA = 2 where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "'and CO='" + i + "'";
                        cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (pct >= 50)
                    {
                        sql = "update CO_FINAL_RESULT set ATTAINMENT_LVL_IA = 1 where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "'and CO='" + i + "'";
                        cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        sql = "update CO_FINAL_RESULT set ATTAINMENT_LVL_IA = 0 where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "'and CO='" + i + "'";
                        cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                    }

                    sql = "update CO_FINAL_RESULT set OVERALL_ATTAINMENT = ((0.4 * ATTAINMENT_LVL_IA) + (0.6 * ATTAINMENT_LVL_UNIVERSITY)) where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "'and CO='" + i + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
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

                sql = "delete from CO_FINAL_RESULT";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                
                CalculationUniversity();
                
                CalculationIA();

                sql = "select CO as [CO], CO_TARGET as [CO TARGET], ATTAINMENT_LVL_IA as [IA ATTAINMENT LEVEL], ATTAINMENT_LVL_UNIVERSITY as [UNIVERSITY ATTAINMENT LEVEL], OVERALL_ATTAINMENT as [OVERALL ATTAINMENT] from CO_FINAL_RESULT where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "CO_FINAL_RESULT");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.DataSource = ds.Tables["CO_FINAL_RESULT"].DefaultView;
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