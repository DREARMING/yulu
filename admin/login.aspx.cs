using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    private Boolean flag = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["currentUser"] != null) {
            TextBox1.Text = Session["currentUser"].ToString();
            if (Session["password"] != null)
            {
                TextBox2.Text = Session["password"].ToString();
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text.Equals(compare.Text))
        {
            flag = true;
        }
        else if ("".Equals(TextBox3.Text))
        {
            Label1.Text = "验证码不能为空";
            return;
        }
        else
        {
            Label1.Text = "验证码错误";
            return;
        }
        String name = TextBox1.Text.ToString();
        String password = TextBox2.Text.ToString();


        String str = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();

        String sql = "select id from Web_User where username='" + name + "' and password='" + password + "';";

        SqlConnection connection = new SqlConnection(str);
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        if (reader.Read()&& flag)
        {
                 Session["currentUser"] = TextBox1.Text;
                 Session["password"] = TextBox2.Text;
                 FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, false);     //保存用户的用户名，并跳转到原来要登陆的页面，获取这个值是Page.User.Identity.Name  
                 Response.Write("<script>alert('登陆成功');</script>");
                 Response.Redirect("~/index.aspx");
            
        }
        else
        {
            Label1.Text = "用户名或密码错误！";
        }
        reader.Close();
        connection.Close();
    }
    protected void compare_Click(object sender, EventArgs e)
    {
        compare.Text = RandomService.GetRaom().ToString();
        
    }
}