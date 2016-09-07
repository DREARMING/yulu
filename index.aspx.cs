using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class others : System.Web.UI.Page
{

    static PagedDataSource pds_set = new PagedDataSource();
    static User_Info currentUser = new User_Info();
    static private string username;
    static int currentPage_guestSentence = 1;
    static int totalPage_guestSentence = 0;
    static int currentPage_guestSet = 1;
    static int totalPage_guestSet = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        //User_Info currentUser = new User_Info();
        //获取要打开的个人页面的用户名；
       
        if (!IsPostBack)
        {
            if (Session["currentUser"] != null)
            {
                username = Session["currentUser"].ToString();
                HyperLink4.Text = username;
                HyperLink4.NavigateUrl = "~/issue.aspx";
                PacketUserInfo();
            }
            else
            {
                HyperLink4.Text = "登录";
                HyperLink4.NavigateUrl = "~/admin/login.aspx";
            }
            
            DataList1Bind();
            DataList2Bind();
            DataListguess1Bind();
            DataListguess2Bind();
            DataListMysetBind();
        }
    }

    //Packet User_Info

    private void PacketUserInfo()
    {
        string sql = "select * from Web_User where username='" + username + "';";
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
        SqlConnection connection = new SqlConnection(constr);
        connection.Open();
        SqlCommand command1 = new SqlCommand(sql, connection);
        SqlDataReader reader = command1.ExecuteReader();
        if (reader.Read())
        {
            currentUser.Username = reader[1].ToString();
            currentUser.Head_img = reader[3].ToString();
            currentUser.Love_set = reader[4].ToString();
            currentUser.Love_sentence = reader[5].ToString();
            currentUser.Publish_set = reader[6].ToString();
            currentUser.Publish_sentence = reader[7].ToString();
            reader.Close();

            //显示个人相关信息
           // user_img.ImageUrl = currentUser.Head_img;
           // username_label.Text = currentUser.Username;

        }
        connection.Close();
    }

    //最新语录
    private void DataListguess1Bind()
    {
        //链接数据库
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
        SqlConnection connection = new SqlConnection(constr);
        connection.Open();
        string sql_query = "select * from SentenceList order by date desc";
        SqlDataAdapter adapter = new SqlDataAdapter(sql_query, connection);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = ds.Tables[0].DefaultView;
        //允许分页
        pds.AllowPaging = true;
        //每页的数据数
        pds.PageSize = 2;
        pds.CurrentPageIndex = currentPage_guestSentence - 1;
        totalPage_guestSentence = pds.PageCount;
        DataListguess1.DataSource = pds;
        DataListguess1.DataBind();
        connection.Close();
    }

    //经典语录
    private void DataListguess2Bind()
    {
        //链接数据库
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
        SqlConnection connection = new SqlConnection(constr);
        connection.Open();
        string sql_query = "select * from SentenceList order by date desc";
        SqlDataAdapter adapter = new SqlDataAdapter(sql_query, connection);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = ds.Tables[0].DefaultView;
        //允许分页
        pds.AllowPaging = true;
        //每页的数据数
        pds.PageSize = 2;
        pds.CurrentPageIndex = currentPage_guestSet - 1;
        totalPage_guestSet = pds.PageCount;
        DataListguess2.DataSource = pds;
        DataListguess2.DataBind();
        connection.Close();
    }

    //精选，根据被人喜欢的人数来排名
    private void DataListMysetBind()
    {
        //链接数据库
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
        SqlConnection connection = new SqlConnection(constr);
        connection.Open();
        string sql_query = "select * from SentenceSet order by numOfFavorite desc;";
        SqlDataAdapter adapter = new SqlDataAdapter(sql_query, connection);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = ds.Tables[0].DefaultView;

        //允许分页
        pds.AllowPaging = true;
        //每页的数据数
        pds.PageSize = 2;

        pds.CurrentPageIndex = currentPage_guestSentence - 1;
        totalPage_guestSentence = pds.PageCount;

        DataListMyset.DataSource = pds;
        DataListMyset.DataBind();

        connection.Close();
    }

    //最新，根据创建时间来排名
    private void DataList1Bind()
    {
        //链接数据库
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
        SqlConnection connection = new SqlConnection(constr);
        connection.Open();
        string sql_query = "select  * from SentenceSet order by createTime desc;";
        SqlDataAdapter adapter = new SqlDataAdapter(sql_query, connection);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = ds.Tables[0].DefaultView;

        //允许分页
        pds.AllowPaging = true;
        //每页的数据数
        pds.PageSize = 2;
        int current_page = Convert.ToInt32(pagenow.Text);
        pds.CurrentPageIndex = current_page - 1;
        totalPage_set.Text = pds.PageCount.ToString();

        //设置所有点击按钮都可用；
        lbtnfirst.Enabled = true;
        lbtnUp.Enabled = true;
        lbtnNext.Enabled = true;
        lbtnLast.Enabled = true;
        if (current_page == 1)
        {
            lbtnfirst.Enabled = false;
            lbtnUp.Enabled = false;
        }
        if (current_page == Convert.ToInt32(totalPage_set.Text))
        {
            lbtnLast.Enabled = false;
            lbtnNext.Enabled = false;
        }
        DataList1.DataSource = pds;
        DataList1.DataBind();

        connection.Close();
    }


    protected void lbtnFirst_Click(object sender, EventArgs e)
    {
        pagenow.Text = "1";
        DataList1Bind();
    }
    protected void lbtnNext_Click(object sender, EventArgs e)
    {
        pagenow.Text = (Convert.ToInt32(pagenow.Text) + 1).ToString();
        DataList1Bind();

    }
    protected void lbtnUp_Click(object sender, EventArgs e)
    {
        pagenow.Text = (Convert.ToInt32(pagenow.Text) - 1).ToString();
        DataList1Bind();
    }
    protected void lbtnLast_Click(object sender, EventArgs e)
    {
        pagenow.Text = totalPage_set.Text;
        DataList1Bind();
    }

    private void getSplitStrings(List<string> hSet, string p1, string p2)
    {
        string[] loves = p1.Split(new char[] { '$' });
        string[] publishs = p2.Split(new char[] { '$' });
        for (int i = 0; i < loves.Length; i++)
        {
            if (!"".Equals(loves[i]))
                hSet.Add(loves[i]);
        }
        for (int i = 0; i < publishs.Length; i++)
        {
            if (!"".Equals(publishs[i]))
                hSet.Add(publishs[i]);
        }
    }

    //绑定语录
    private void DataList2Bind()
    {
        //链接数据库
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
        SqlConnection connection = new SqlConnection(constr);
        connection.Open();
        string sql_query = "select Top 3 * from SentenceSet order by numOfSentences desc;";
        SqlDataAdapter adapter = new SqlDataAdapter(sql_query, connection);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = ds.Tables[0].DefaultView;
        DataList2.DataSource = pds;
        DataList2.DataBind();

        connection.Close();

    }

    class User_Info
    {
        public string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string head_img;

        public string Head_img
        {
            get { return head_img; }
            set { head_img = value; }
        }
        public string love_set;

        public string Love_set
        {
            get { return love_set; }
            set { love_set = value; }
        }
        public string love_sentence;

        public string Love_sentence
        {
            get { return love_sentence; }
            set { love_sentence = value; }
        }
        public string publish_set;

        public string Publish_set
        {
            get { return publish_set; }
            set { publish_set = value; }
        }
        public string publish_sentence;

        public string Publish_sentence
        {
            get { return publish_sentence; }
            set { publish_sentence = value; }
        }
    }

    private void getSplitStrings(List<string> list, string p)
    {
        string[] str = p.Split(new char[] { '$' });

        for (int i = 0; i < str.Length; i++)
        {
            if (!"".Equals(str[i]))
                list.Add(str[i]);
        }
    }

    //判断当前集合是否含有str字符串，并且返回list中除了str的所有字符串以分隔符$的字符串；
    protected string dealString(List<string> list, string str)
    {
        string sqlStr = "";
        bool isFirstOne = true;
        for (int i = 0; i < list.Count; i++)
        {
            if (!str.Equals(list[i]))
            {
                if (isFirstOne)
                {   //第一个不等于title的不加分隔符号；
                    sqlStr = list[i];
                    isFirstOne = false;
                }
                else
                {
                    sqlStr += "$" + list[i];
                }
            }
        }

        return sqlStr;
    }
 

    protected void updateGuess_Click(object sender, ImageClickEventArgs e)
    {
        currentPage_guestSentence += 1;
        if (currentPage_guestSentence > totalPage_guestSentence)
        {
            currentPage_guestSentence = 1;
        }
        DataListguess1Bind();
    }
    protected void updateGuess_Classical_Click(object sender, ImageClickEventArgs e)
    {
        currentPage_guestSet += 1;
        if (currentPage_guestSet > totalPage_guestSet)
        {
            currentPage_guestSet = 1;
        }
        DataListguess2Bind();
        
    }
    protected void ILoveIt_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton imgBtn = (ImageButton)sender;
        string sentence_id = imgBtn.CommandArgument;
        string cookie = "";
        //用cookie来记录当前用户的操作；
        if (Request.Cookies["sentence" + sentence_id] == null)
        {
            Response.Cookies["sentence" + sentence_id].Value = "first";
            cookie = "first";
        }
        else
        {
            cookie = Request.Cookies["sentence" + sentence_id].Value;
            if ("first".Equals(cookie))
            {
                Response.Cookies["sentence" + sentence_id].Value = "second";
            }
            else
            {
                Response.Cookies["sentence" + sentence_id].Value = "first";
            }
        }

        string column_name = "";
        string _id = imgBtn.ID;
        if ("ILoveIt".Equals(_id))
        {
            column_name = "love_sentence";
        }
        else
        {
            column_name = "love_set";
        }
        if ("first".Equals(cookie))
        {
            //获取love list
            List<string> list = new List<string>();
            getSplitStrings(list, currentUser.Love_sentence);
            //判断sentence_id是否已经存在于喜欢的名单中；
            bool isExist = addStringToList(list, sentence_id);
            if (!isExist)
            {
                string love_str = makeLoveStrng(list);
                string sql = "update Web_User set " + column_name + "='" + love_str + "' where username='" + currentUser.username + "';";
                updateDB(sql);
                string sql_query = "";
                if ("love_sentence".Equals(column_name))
                {
                    sql_query = "select numOfFavorite from SentenceList where Sentence_id='" + sentence_id + "';";
                    string numOflove = (Convert.ToInt32(queryItemData(sql_query)) + 1).ToString();
                    string sql_update = "update SentenceList set numOfFavorite='" + numOflove + "' where Sentence_id='" + sentence_id + "';";
                    updateDB(sql_update);
                    PacketUserInfo();
                    DataList2Bind();
                    DataListguess1Bind();

                }
                else
                {
                    sql_query = "select numOfFavorite from SentenceSet where book_id='" + sentence_id + "';";
                    string numOflove = (Convert.ToInt32(queryItemData(sql_query)) + 1).ToString();
                    string sql_update = "update SentenceList set numOfFavorite='" + numOflove + "' where Sentence_id='" + sentence_id + "';";
                    updateDB(sql_update);
                    PacketUserInfo();
                    DataList1Bind();
                    
                }
            }
        }
        else
        {
            List<string> list = new List<string>();
            getSplitStrings(list, currentUser.Love_sentence);
            string love_str = dealString(list, sentence_id);
            string sql = "update Web_User set " + column_name + "='" + love_str + "' where username='" + currentUser.username + "';";
            updateDB(sql);
            string sql_query = "";
            if ("love_sentence".Equals(column_name))
            {
                sql_query = "select numOfFavorite from SentenceList where Sentence_id='" + sentence_id + "';";
                string numOflove = (Convert.ToInt32(queryItemData(sql_query)) - 1).ToString();
                string sql_update = "update SentenceList set numOfFavorite='" + numOflove + "' where Sentence_id='" + sentence_id + "';";
                updateDB(sql_update);
                PacketUserInfo();
                DataList2Bind();
                DataListguess1Bind();
            }
            else
            {
                sql_query = "select numOfFavorite from SentenceSet where book_id='" + sentence_id + "';";
                string numOflove = (Convert.ToInt32(queryItemData(sql_query)) - 1).ToString();
                string sql_update = "update SentenceList set numOfFavorite='" + numOflove + "' where Sentence_id='" + sentence_id + "';";
                updateDB(sql_update);
                PacketUserInfo();
                DataList1Bind();
               
            }

        }
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

    //根据给定的list，来构造符合数据库格式的的字符串
    private string makeLoveStrng(List<string> list)
    {
        string sql = "";
        if (list.Count > 0)
        {
            sql += list[0];
            for (int i = 1; i < list.Count; i++)
            {
                sql += "$" + list[i];
            }
        }
        return sql;
    }

    //如果指定的字符串在list中含有的话，则不做任何处理，如果没有的话，则添加到list中；
    private bool addStringToList(List<string> list, string str)
    {
        bool isInList = false;
        for (int i = 0; i < list.Count; i++)
        {
            if (str.Equals(list[i]))
            {
                isInList = true;
                break;
            }
        }
        if (!isInList)
        {
            list.Add(str);
        }
        return isInList;
    }


    private string queryItemData(string sql)
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
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
}