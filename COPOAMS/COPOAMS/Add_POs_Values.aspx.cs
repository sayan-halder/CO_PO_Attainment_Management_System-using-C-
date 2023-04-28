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
    public partial class Add_POs_Values : System.Web.UI.Page
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
                String sql = "insert into PO_DETAILS (BATCH, SEMESTER, SUBJECT_CODE, CO, PO1, PO2, PO3, PO4, PO5, PO6, PO7, PO8, PO9, PO10, PO11, PO12) values ('" + batch.SelectedItem + "','" + semester.SelectedItem + "','" + subject_code.SelectedItem + "','" + co.SelectedItem + "','" + po1.SelectedItem + "','" + po2.SelectedItem + "','" + po3.SelectedItem + "','" + po4.SelectedItem + "','" + po5.SelectedItem + "','" + po6.SelectedItem + "','" + po7.SelectedItem + "','" + po8.SelectedItem + "','" + po9.SelectedItem + "','" + po10.SelectedItem + "','" + po11.SelectedItem + "','" + po12.SelectedItem + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('POs for CO-" + co.SelectedItem + " added successfully.');window.location ='" + "Add_POs_Values.aspx" + "';", true);
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
            co.SelectedIndex = co.Items.IndexOf(co.Items.FindByValue("Select CO number"));
            po1.SelectedIndex = po1.Items.IndexOf(po1.Items.FindByValue("Select PO number"));
            po2.SelectedIndex = po2.Items.IndexOf(po2.Items.FindByValue("Select PO number"));
            po3.SelectedIndex = po3.Items.IndexOf(po3.Items.FindByValue("Select PO number"));
            po4.SelectedIndex = po4.Items.IndexOf(po4.Items.FindByValue("Select PO number"));
            po5.SelectedIndex = po5.Items.IndexOf(po5.Items.FindByValue("Select PO number"));
            po6.SelectedIndex = po6.Items.IndexOf(po6.Items.FindByValue("Select PO number"));
            po7.SelectedIndex = po7.Items.IndexOf(po7.Items.FindByValue("Select PO number"));
            po8.SelectedIndex = po8.Items.IndexOf(po8.Items.FindByValue("Select PO number"));
            po9.SelectedIndex = po9.Items.IndexOf(po9.Items.FindByValue("Select PO number"));
            po10.SelectedIndex = po10.Items.IndexOf(po10.Items.FindByValue("Select PO number"));
            po11.SelectedIndex = po11.Items.IndexOf(po11.Items.FindByValue("Select PO number"));
            po12.SelectedIndex = po12.Items.IndexOf(po12.Items.FindByValue("Select PO number"));
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Home_Page.aspx");
        }
    }
}