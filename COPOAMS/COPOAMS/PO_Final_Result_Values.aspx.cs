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
    public partial class PO_Final_Result_Values : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Lenovo\Documents\COPOAMS_Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                con.Open();
                String sql;
                SqlCommand cmd;

                sql = "insert into PO_BATCH_ATTAINMENT (BATCH, PO1, PO2, PO3, PO4, PO5, PO6, PO7, PO8, PO9, PO10, PO11, PO12) select BATCH, avg(PO1FA), avg(PO2FA), avg(PO3FA), avg(PO4FA), avg(PO5FA), avg(PO6FA), avg(PO7FA), avg(PO8FA), avg(PO9FA), avg(PO10FA), avg(PO11FA), avg(PO12FA) from PO_ATTAINMENT where BATCH='" + batch.SelectedItem + "' group by BATCH";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                /*ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('AAAAAA');", true);*/

                sql = "select PO1, PO2, PO3, PO4, PO5, PO6, PO7, PO8, PO9, PO10, PO11, PO12 from PO_BATCH_ATTAINMENT where BATCH='" + batch.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "PO_BATCH_ATTAINMENT");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.DataSource = ds.Tables["PO_BATCH_ATTAINMENT"].DefaultView;
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