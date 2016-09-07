using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TopFoot : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //获取要打开的个人页面的用户名；
            if (Session["currentUser"] != null)
            {
                HyperLink40.Text = Session["currentUser"].ToString();
                HyperLink40.NavigateUrl = "issue.aspx";
            }else{
                HyperLink40.Text = "登录";
                HyperLink40.NavigateUrl="~/admin/login.aspx";
            }
        }
    }
}
