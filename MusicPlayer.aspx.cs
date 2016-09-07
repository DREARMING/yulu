using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MusicPlayer : System.Web.UI.Page
{
    string mp3 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["song"] != null) {
            mp3 = Request.Params["song"].ToString();
        }
        else
        {
            mp3 = "test1.mp3";
        }
       
        if (!IsPostBack) {
            Data_Binding();
        }
    }

    private void Data_Binding()
    {
        mp3 = "mp3=dewplayer/mp3/" + mp3;
        StringBuilder sb = new StringBuilder();
        sb.Append("<div id='dewplayer_content'>");
        sb.Append("<object data='dewplayer/dewplayer-bubble.swf' width='300' height='65' name='dewplayer' id='dewplayer' type='application/x-shockwave-flash'>");
        sb.Append("<param name='movie' value='dewplayer/dewplayer-bubble.swf' />");
        sb.Append("<param name='flashvars' value='"+ mp3+"'/>");
        sb.Append("<param name='wmode' value='transparent' />");
        sb.Append("</object>");
        sb.Append("</div>");
        Literal1.Text = sb.ToString();
    }
}