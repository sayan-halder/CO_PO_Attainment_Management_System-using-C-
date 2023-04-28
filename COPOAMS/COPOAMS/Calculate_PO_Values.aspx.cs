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
    public partial class Calculate_PO_Values : System.Web.UI.Page
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

        protected void PO_Value()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Lenovo\Documents\COPOAMS_Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                String sql;
                SqlCommand cmd;

                for (int i = 1; i <= 5; i++)
                {
                    sql = "select OVERALL_ATTAINMENT from CO_FINAL_RESULT where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "' and CO='" + i + "'";
                    cmd = new SqlCommand(sql, con);
                    decimal cov = Convert.ToDecimal(cmd.ExecuteScalar());

                    sql = "update PO_DETAILS set COV='" + cov + "' where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "' and CO='" + i + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    sql = "update PO_DETAILS set po1v=po1*cov/3, po2v=po2*cov/3, po3v=po3*cov/3, po4v=po4*cov/3, po5v=po5*cov/3, po6v=po6*cov/3, po7v=po7*cov/3, po8v=po8*cov/3, po9v=po9*cov/3, po10v=po10*cov/3, po11v=po11*cov/3, po12v=po12*cov/3 where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "' and CO='" + i + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void attainment()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Lenovo\Documents\COPOAMS_Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                String sql;
                SqlCommand cmd;

                sql = "insert into PO_ATTAINMENT (BATCH, SEMESTER, SUBJECT_CODE, PO1S, PO2S, PO3S, PO4S, PO5S, PO6S, PO7S, PO8S, PO9S, PO10S, PO11S, PO12S, PO1AS, PO2AS, PO3AS, PO4AS, PO5AS, PO6AS, PO7AS, PO8AS, PO9AS, PO10AS, PO11AS, PO12AS) select BATCH, SEMESTER, SUBJECT_CODE, sum(PO1), sum(PO2), sum(PO3), sum(PO4), sum(PO5), sum(PO6), sum(PO7), sum(PO8), sum(PO9), sum(PO10), sum(PO11), sum(PO12), sum(PO1V), sum(PO2V), sum(PO3V), sum(PO4V), sum(PO5V), sum(PO6V), sum(PO7V), sum(PO8V), sum(PO9V), sum(PO10V), sum(PO11V), sum(PO12V) from PO_DETAILS where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "' group by BATCH, SEMESTER, SUBJECT_CODE";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                Int32 countPO = 0;

                sql = "select count(PO1) from PO_DETAILS where PO1 > 0 and BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                countPO = (Int32)cmd.ExecuteScalar();                
                sql = "update PO_ATTAINMENT set PO1C='" + countPO + "' where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                if (countPO > 0)
                {
                    sql = "update PO_ATTAINMENT set PO1FA = PO1AS / PO1C where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }

                sql = "select count(PO2) from PO_DETAILS where PO2 > 0 and BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                countPO = (Int32)cmd.ExecuteScalar();
                sql = "update PO_ATTAINMENT set PO2C='" + countPO + "' where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                if (countPO > 0)
                {
                    sql = "update PO_ATTAINMENT set PO2FA = PO2AS / PO2C where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }

                sql = "select count(PO3) from PO_DETAILS where PO3 > 0 and BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                countPO = (Int32)cmd.ExecuteScalar();
                sql = "update PO_ATTAINMENT set PO3C='" + countPO + "' where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                if (countPO > 0)
                {
                    sql = "update PO_ATTAINMENT set PO3FA = PO3AS / PO3C where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }

                sql = "select count(PO4) from PO_DETAILS where PO4 > 0 and BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                countPO = (Int32)cmd.ExecuteScalar();
                sql = "update PO_ATTAINMENT set PO4C='" + countPO + "' where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                if (countPO > 0)
                {
                    sql = "update PO_ATTAINMENT set PO4FA = PO4AS / PO4C where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }

                sql = "select count(PO5) from PO_DETAILS where PO5 > 0 and BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                countPO = (Int32)cmd.ExecuteScalar();
                sql = "update PO_ATTAINMENT set PO5C='" + countPO + "' where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                if (countPO > 0)
                {
                    sql = "update PO_ATTAINMENT set PO5FA = PO5AS / PO5C where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }

                sql = "select count(PO6) from PO_DETAILS where PO6 > 0 and BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                countPO = (Int32)cmd.ExecuteScalar();
                sql = "update PO_ATTAINMENT set PO6C='" + countPO + "' where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                if (countPO > 0)
                {
                    sql = "update PO_ATTAINMENT set PO6FA = PO6AS / PO6C where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }

                sql = "select count(PO7) from PO_DETAILS where PO7 > 0 and BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                countPO = (Int32)cmd.ExecuteScalar();
                sql = "update PO_ATTAINMENT set PO7C='" + countPO + "' where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                if (countPO > 0)
                {
                    sql = "update PO_ATTAINMENT set PO7FA = PO7AS / PO7C where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }

                sql = "select count(PO8) from PO_DETAILS where PO8 > 0 and BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                countPO = (Int32)cmd.ExecuteScalar();
                sql = "update PO_ATTAINMENT set PO8C='" + countPO + "' where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                if (countPO > 0)
                {
                    sql = "update PO_ATTAINMENT set PO8FA = PO8AS / PO8C where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }

                sql = "select count(PO9) from PO_DETAILS where PO9 > 0 and BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                countPO = (Int32)cmd.ExecuteScalar();
                sql = "update PO_ATTAINMENT set PO9C='" + countPO + "' where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                if (countPO > 0)
                {
                    sql = "update PO_ATTAINMENT set PO9FA = PO9AS / PO9C where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }

                sql = "select count(PO10) from PO_DETAILS where PO10 > 0 and BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                countPO = (Int32)cmd.ExecuteScalar();
                sql = "update PO_ATTAINMENT set PO10C='" + countPO + "' where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                if (countPO > 0)
                {
                    sql = "update PO_ATTAINMENT set PO10FA = PO10AS / PO10C where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }

                sql = "select count(PO11) from PO_DETAILS where PO11 > 0 and BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                countPO = (Int32)cmd.ExecuteScalar();
                sql = "update PO_ATTAINMENT set PO11C='" + countPO + "' where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                if (countPO > 0)
                {
                    sql = "update PO_ATTAINMENT set PO11FA = PO11AS / PO11C where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }

                sql = "select count(PO12) from PO_DETAILS where PO12 > 0 and BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                countPO = (Int32)cmd.ExecuteScalar();
                sql = "update PO_ATTAINMENT set PO12C='" + countPO + "' where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                if (countPO > 0)
                {
                    sql = "update PO_ATTAINMENT set PO12FA = PO12AS / PO12C where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
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

                PO_Value();

                sql = "delete from PO_ATTAINMENT";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da;
                DataSet ds;

                sql = "select CO as [CO], PO1V as [PO1], PO2V as [PO2], PO3V as [PO3], PO4V as [PO4], PO5V as [PO5], PO6V as [PO6], PO7V as [PO7], PO8V as [PO8], PO9V as [PO9], PO10V as [PO10], PO11V as [PO11], PO12V as [PO12] from PO_DETAILS where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "PO_DETAILS");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.DataSource = ds.Tables["PO_DETAILS"].DefaultView;

                attainment();

                sql = "select PO1FA as [PO1], PO2FA as [PO2], PO3FA as [PO3], PO4FA as [PO4], PO5FA as [PO5], PO6FA as [PO6], PO7FA as [PO7], PO8FA as [PO8], PO9FA as [PO9], PO10FA as [PO10], PO11FA as [PO11], PO12FA as [PO12] from PO_ATTAINMENT where BATCH='" + batch.SelectedItem + "' and SEMESTER='" + semester.SelectedItem + "' and SUBJECT_CODE='" + subject_code.SelectedItem + "'";
                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "PO_ATTAINMENT");
                GridView2.DataSource = ds;
                GridView2.DataBind();
                GridView2.DataSource = ds.Tables["PO_ATTAINMENT"].DefaultView;
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