using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace internal1
{
    public partial class reg1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private const string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Coding\\ASP.Net\\internal1\\App_Data\\Database2.mdf;Integrated Security=True";
        protected void Button1_Click(object sender, EventArgs e)
        {
            String s = "", ext = "", s1 = "";
            if((FileUpload1.HasFile) && (FileUpload1.FileBytes.Length < 1000000))
            {
                s = Path.GetFileName(FileUpload1.FileName);
                ext = Path.GetExtension(FileUpload1.FileName);
                if(ext == ".jpg" || ext == ".jpeg")
                {
                    FileUpload1.SaveAs(Server.MapPath("~/Newfolder1/") + s);
                    Label15.Text = "File Uploaded Succesfully";
                    s1 = "~/NewFolder1" + s;
                }
                else
                {
                    Label15.Text = "File Not Found";
                }
            }
            else
            {
                Label15.Text = "File Not Found";
            }
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sr = "insert into rtable values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + RadioButtonList1.SelectedItem + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + DropDownList1.SelectedItem + "','" + TextBox7.Text + "','" + TextBox9.Text + "','" + TextBox10.Text + "','" + TextBox8.Text  + "','" + s1 + "')";
            SqlCommand cmd = new SqlCommand(sr, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("login1.aspx");
        }
    }
}