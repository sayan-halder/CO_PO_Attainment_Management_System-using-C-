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
    public partial class Add_IA_Marks : System.Web.UI.Page
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

        protected void Show_Marks()
        {
            try
            {
                int mk1 = 0, mk2 = 0, mk3 = 0, mk4 = 0, mk5 = 0, mk6 = 0, mk7 = 0, mk8 = 0, mk9 = 0;

                if (String.Equals("Not Attempted", q1.SelectedItem.ToString()))
                    mk1 = -1;
                else
                    mk1 = Int32.Parse(q1.SelectedItem.ToString());

                if (String.Equals("Not Attempted", q2.SelectedItem.ToString()))
                    mk2 = -1;
                else
                    mk2 = Int32.Parse(q1.SelectedItem.ToString());

                if (String.Equals("Not Attempted", q3.SelectedItem.ToString()))
                    mk3 = -1;
                else
                    mk3 = Int32.Parse(q1.SelectedItem.ToString());

                if (String.Equals("Not Attempted", q4.SelectedItem.ToString()))
                    mk4 = -1;
                else
                    mk4 = Int32.Parse(q1.SelectedItem.ToString());

                if (String.Equals("Not Attempted", q5.SelectedItem.ToString()))
                    mk5 = -1;
                else
                    mk5 = Int32.Parse(q1.SelectedItem.ToString());

                if (String.Equals("Not Attempted", q6.SelectedItem.ToString()))
                    mk6 = -1;
                else
                    mk6 = Int32.Parse(q1.SelectedItem.ToString());

                if (String.Equals("Not Attempted", q7.SelectedItem.ToString()))
                    mk7 = -1;
                else
                    mk7 = Int32.Parse(q1.SelectedItem.ToString());

                if (String.Equals("Not Attempted", q8.SelectedItem.ToString()))
                    mk8 = -1;
                else
                    mk8 = Int32.Parse(q1.SelectedItem.ToString());

                if (String.Equals("Not Attempted", asgn.SelectedItem.ToString()))
                    mk9 = -1;
                else
                    mk9 = Int32.Parse(q1.SelectedItem.ToString());

                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Lenovo\Documents\COPOAMS_Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                String sql = "insert into IAM(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, USN, Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + usn.SelectedItem + "','" + mk1 + "','" + mk2 + "','" + mk3 + "','" + mk4 + "','" + mk5 + "','" + mk6 + "','" + mk7 + "','" + mk8 + "','" + mk9 + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected int fetchCOValue(int q)
        {
            int co = 0;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Lenovo\Documents\COPOAMS_Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                String sql = "select CO from IA_COS where BATCH='" + batch.SelectedItem + "'and SEMESTER='" + semester.SelectedItem + "'and SUBJECT_CODE='" + subject_code.SelectedItem + "'and IA_NUMBER='" + ia_number.SelectedItem + "'and QUESTION='" + q + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    co = Convert.ToInt32(sdr["CO"]);
                }
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
            return co;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int co = 0, mk = 0;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Lenovo\Documents\COPOAMS_Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                String sql;
                SqlCommand cmd;

                co = fetchCOValue(1);
                if(String.Equals("Not Attempted", q1.SelectedItem.ToString()))
                    mk = -1;
                else
                    mk = Int32.Parse(q1.SelectedItem.ToString());
                sql = "insert into IA_MARKS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, USN, QUESTION, CO, MARKS) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + usn.SelectedItem + "','" + 1 + "','" + co + "','" + mk + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                co = fetchCOValue(2);
                if(String.Equals("Not Attempted", q2.SelectedItem.ToString()))
                    mk = -1;
                else
                    mk = Int32.Parse(q2.SelectedItem.ToString());
                sql = "insert into IA_MARKS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, USN, QUESTION, CO, MARKS) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + usn.SelectedItem + "','" + 2 + "','" + co + "','" + mk + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                co = fetchCOValue(3);
                if(String.Equals("Not Attempted", q3.SelectedItem.ToString()))
                    mk = -1;
                else
                    mk = Int32.Parse(q3.SelectedItem.ToString());
                sql = "insert into IA_MARKS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, USN, QUESTION, CO, MARKS) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + usn.SelectedItem + "','" + 3 + "','" + co + "','" + mk + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                co = fetchCOValue(4);
                if(String.Equals("Not Attempted", q4.SelectedItem.ToString()))
                    mk = -1;
                else
                    mk = Int32.Parse(q4.SelectedItem.ToString());
                sql = "insert into IA_MARKS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, USN, QUESTION, CO, MARKS) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + usn.SelectedItem + "','" + 4 + "','" + co + "','" + mk + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                co = fetchCOValue(5);
                if(String.Equals("Not Attempted", q5.SelectedItem.ToString()))
                    mk = -1;
                else
                    mk = Int32.Parse(q5.SelectedItem.ToString());
                sql = "insert into IA_MARKS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, USN, QUESTION, CO, MARKS) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + usn.SelectedItem + "','" + 5 + "','" + co + "','" + mk + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                co = fetchCOValue(6);
                if(String.Equals("Not Attempted", q6.SelectedItem.ToString()))
                    mk = -1;
                else
                    mk = Int32.Parse(q6.SelectedItem.ToString());
                sql = "insert into IA_MARKS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, USN, QUESTION, CO, MARKS) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + usn.SelectedItem + "','" + 6 + "','" + co + "','" + mk + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                co = fetchCOValue(7);
                if(String.Equals("Not Attempted", q7.SelectedItem.ToString()))
                    mk = -1;
                else
                    mk = Int32.Parse(q7.SelectedItem.ToString());
                sql = "insert into IA_MARKS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, USN, QUESTION, CO, MARKS) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + usn.SelectedItem + "','" + 7 + "','" + co + "','" + mk + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                co = fetchCOValue(8);
                if(String.Equals("Not Attempted", q8.SelectedItem.ToString()))
                    mk = -1;
                else
                    mk = Int32.Parse(q8.SelectedItem.ToString());
                sql = "insert into IA_MARKS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, USN, QUESTION, CO, MARKS) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + usn.SelectedItem + "','" + 8 + "','" + co + "','" + mk + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                co = fetchCOValue(9);
                if(String.Equals("Not Attempted", asgn.SelectedItem.ToString()))
                    mk = -1;
                else
                    mk = Int32.Parse(asgn.SelectedItem.ToString());
                sql = "insert into IA_MARKS(BATCH, SEMESTER, SUBJECT_CODE, IA_NUMBER, USN, QUESTION, CO, MARKS) values('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + ia_number.SelectedItem + "','" + usn.SelectedItem + "','" + 9 + "','" + co + "','" + mk + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                Show_Marks();

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Marks for USN-" + usn.SelectedItem + " for IA-" + ia_number.SelectedItem + " added successfully.');window.location ='" + "Add_IA_MARKS.aspx" + "';", true);
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
            ia_number.SelectedIndex = ia_number.Items.IndexOf(ia_number.Items.FindByValue("Select IA number"));
            q1.SelectedIndex = q1.Items.IndexOf(q1.Items.FindByValue("Select marks"));
            q2.SelectedIndex = q2.Items.IndexOf(q3.Items.FindByValue("Select marks"));
            q3.SelectedIndex = q3.Items.IndexOf(q3.Items.FindByValue("Select marks"));
            q4.SelectedIndex = q4.Items.IndexOf(q4.Items.FindByValue("Select marks"));
            q5.SelectedIndex = q5.Items.IndexOf(q5.Items.FindByValue("Select marks"));
            q6.SelectedIndex = q6.Items.IndexOf(q6.Items.FindByValue("Select marks"));
            q7.SelectedIndex = q7.Items.IndexOf(q7.Items.FindByValue("Select marks"));
            q8.SelectedIndex = q8.Items.IndexOf(q8.Items.FindByValue("Select marks"));
            asgn.SelectedIndex = asgn.Items.IndexOf(asgn.Items.FindByValue("Select marks"));
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Home_Page.aspx");
        }
    }
}