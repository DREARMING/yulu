using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_exit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void sure_Click(object sender, EventArgs e)
    {
        Response.Redirect("../index.aspx");
    }
    protected void cancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("main.aspx");
    }
}