using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    static String constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //根据给定的查询语句，查询单项数据；
    private string queryItemData(string sql)
    {
        SqlConnection connection = new SqlConnection(constr);
        connection.Open();
        SqlCommand command = new SqlCommand(sql, connection);
        SqlDataReader reader = command.ExecuteReader();
        string str = "";
        if (reader.Read())
        {
            str = reader[0].ToString();
        }
        connection.Close();
        return str;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String name = TextBox1.Text.ToString();
        string sql_query = "select * from Web_User where username='"+name+"';";
        if("".Equals(queryItemData(sql_query))){
            Label1.Text = "此用户名已经存在";
        }

        String password = TextBox2.Text.ToString();
        string sql_insert = "insert into Web_User(username,password) values('" + name + "','" + password + "');";
        updateDB(sql_insert);
        Response.Write("<script>alert('注册成功');</script>");
        Response.Redirect("~/admin/login.aspx");
    }

    //执行给定的sql语句，没有返回值；
    private void updateDB(string sql)
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
        SqlConnection connection = new SqlConnection(constr);
        connection.Open();
        SqlCommand command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }
}