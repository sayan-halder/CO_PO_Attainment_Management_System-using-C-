using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COPOAMS
{
    public partial class Home_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("New_Student.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("New_Subject.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Add_IA_COs.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Server.Transfer("Add_IA_Marks.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Server.Transfer("Calculate_CO_Values.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Server.Transfer("Add_External_Marks.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Server.Transfer("External_Exam_Result.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Server.Transfer("CO_Final_Result_Values.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Server.Transfer("Add_POs_Values.aspx");
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Server.Transfer("Calculate_PO_Values.aspx");
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Server.Transfer("PO_Final_Result_Values.aspx");
        }
    }
}