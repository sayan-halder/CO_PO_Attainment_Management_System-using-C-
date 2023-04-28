using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace COPOAMS
{
    public partial class Home_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = this.BindMenuData(0);
                DynamicMenuControlPopulation(dt, 0, null);
            }
        }

        protected DataTable BindMenuData(int parentmenuId)
        {
            //declaration of variable used  
            DataSet ds = new DataSet();
            DataTable dt;
            DataRow dr;
            DataColumn menu;
            DataColumn pMenu;
            DataColumn title;
            DataColumn description;
            DataColumn URL;

            //create an object of datatable  
            dt = new DataTable();

            //creating column of datatable with datatype  
            menu = new DataColumn("MenuId", Type.GetType("System.Int32"));
            pMenu = new DataColumn("ParentId", Type.GetType("System.Int32"));
            title = new DataColumn("Title", Type.GetType("System.String"));
            description = new DataColumn("Description", Type.GetType("System.String"));
            URL = new DataColumn("URL", Type.GetType("System.String"));

            //bind data table columns in datatable  
            dt.Columns.Add(menu);//1st column  
            dt.Columns.Add(pMenu);//2nd column  
            dt.Columns.Add(title);//3rd column  
            dt.Columns.Add(description);//4th column  
            dt.Columns.Add(URL);//5th column  

            //creating data row and assiging the value to columns of datatable  
            //1st row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 1;
            dr["ParentId"] = 0;
            dr["Title"] = "File";
            dr["Description"] = "";
            dr["URL"] = "";
            dt.Rows.Add(dr);

            //2nd row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 2;
            dr["ParentId"] = 0;
            dr["Title"] = "View";
            dr["Description"] = "";
            dr["URL"] = "";
            dt.Rows.Add(dr);

            //3rd row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 3;
            dr["ParentId"] = 0;
            dr["Title"] = "About";
            dr["Description"] = "About us page";
            dr["URL"] = "";
            dt.Rows.Add(dr);

            //4th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 4;
            dr["ParentId"] = 0;
            dr["Title"] = "Contact Us";
            dr["Description"] = "Contact Us page";
            dr["URL"] = "";
            dt.Rows.Add(dr);

            //5th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 5;
            dr["ParentId"] = 1;
            dr["Title"] = "Log Out";
            dr["Description"] = "";
            dr["URL"] = "";
            dt.Rows.Add(dr);

            //6th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 6;
            dr["ParentId"] = 2;
            dr["Title"] = "Registered Students";
            dr["Description"] = "Display Registered Students";
            dr["URL"] = "~/Show_Students.aspx";
            dt.Rows.Add(dr);

            //7th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 7;
            dr["ParentId"] = 2;
            dr["Title"] = "Registered Subjects";
            dr["Description"] = "Display Registered Subjects";
            dr["URL"] = "~/Show_Subjects.aspx";
            dt.Rows.Add(dr);

            //8th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 8;
            dr["ParentId"] = 2;
            dr["Title"] = "IA COs";
            dr["Description"] = "Display IA COs";
            dr["URL"] = "~/Show_IA_COs.aspx";
            dt.Rows.Add(dr);

            //9th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 9;
            dr["ParentId"] = 2;
            dr["Title"] = "IA Marks";
            dr["Description"] = "Display IA Marks";
            dr["URL"] = "~/Show_IA_Marks.aspx";
            dt.Rows.Add(dr);

            //10th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 10;
            dr["ParentId"] = 2;
            dr["Title"] = "External Marks";
            dr["Description"] = "Display External Marks";
            dr["URL"] = "~/Show_External_Marks.aspx";
            dt.Rows.Add(dr);

            //11th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 11;
            dr["ParentId"] = 2;
            dr["Title"] = "PO Values";
            dr["Description"] = "Display PO Values";
            dr["URL"] = "~/Show_PO_Details.aspx";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            var dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "ParentId='" + parentmenuId + "'";
            DataSet ds1 = new DataSet();
            var newdt = dv.ToTable();
            return newdt;
        }

        protected void DynamicMenuControlPopulation(DataTable dt, int parentMenuId, MenuItem parentMenuItem)
        {
            string currentPage = Path.GetFileName(Request.Url.AbsolutePath);
            foreach (DataRow row in dt.Rows)
            {
                MenuItem menuItem = new MenuItem
                {
                    Value = row["MenuId"].ToString(),
                    Text = row["Title"].ToString(),
                    NavigateUrl = row["URL"].ToString(),
                    Selected = row["URL"].ToString().EndsWith(currentPage, StringComparison.CurrentCultureIgnoreCase)
                };
                if (parentMenuId == 0)
                {
                    Menu1.Items.Add(menuItem);
                    DataTable dtChild = this.BindMenuData(int.Parse(menuItem.Value));
                    DynamicMenuControlPopulation(dtChild, int.Parse(menuItem.Value), menuItem);
                }
                else
                {

                    parentMenuItem.ChildItems.Add(menuItem);
                    DataTable dtChild = this.BindMenuData(int.Parse(menuItem.Value));
                    DynamicMenuControlPopulation(dtChild, int.Parse(menuItem.Value), menuItem);

                }
            }
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