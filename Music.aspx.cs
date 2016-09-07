using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class book : System.Web.UI.Page
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
        if (Request.Params["currentUser"] != null)
        {

        }
        username = "宝宝";
        if (!IsPostBack)
        {
            PacketUserInfo();
            DataList1Bind(currentUser);
            DataList2Bind(currentUser);
            DataListguess1Bind();
            DataListguess2Bind();
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
        }
        connection.Close();
    }

    //猜的语录
    private void DataListguess1Bind()
    {
        //链接数据库
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
        SqlConnection connection = new SqlConnection(constr);
        connection.Open();
        string sql_query = "select * from SentenceList";
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

    private void DataListguess2Bind()
    {
        //链接数据库
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
        SqlConnection connection = new SqlConnection(constr);
        connection.Open();
        string sql_query = "select * from SentenceSet";
        SqlDataAdapter adapter = new SqlDataAdapter(sql_query, connection);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = ds.Tables[0].DefaultView;
        //允许分页
        pds.AllowPaging = true;
        //每页的数据数
        pds.PageSize = 1;
        pds.CurrentPageIndex = currentPage_guestSet - 1;
        totalPage_guestSet = pds.PageCount;

        connection.Close();
    }

    //绑定语录集
    private void DataList1Bind(User_Info currentUser)
    {

        //链接数据库
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
        SqlConnection connection = new SqlConnection(constr);
        connection.Open();

        //查询语录集数据；
        List<string> list_SentenceSet = new List<string>();
        getSplitStrings(list_SentenceSet, currentUser.Love_set, currentUser.Publish_set);

        if (list_SentenceSet.Count != 0)
        {
            //构造查询语录集的字符串
            string query_set = "select * from SentenceSet where ";

            for (int i = 0; i < list_SentenceSet.Count; i++)
            {
                if (i == 0)
                {
                    query_set += "title='" + list_SentenceSet[i] + "'";
                }
                else
                {
                    query_set += " or title='" + list_SentenceSet[i] + "'";
                }
            }
            query_set += ";";


            SqlDataAdapter adapter = new SqlDataAdapter(query_set, connection);
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
        }
       
        connection.Close();
    }

    protected void lbtnFirst_Click(object sender, EventArgs e)
    {
        pagenow.Text = "1";
        DataList1Bind(currentUser);
    }
    protected void lbtnNext_Click(object sender, EventArgs e)
    {
        pagenow.Text = (Convert.ToInt32(pagenow.Text) + 1).ToString();
        DataList1Bind(currentUser);

    }
    protected void lbtnUp_Click(object sender, EventArgs e)
    {
        pagenow.Text = (Convert.ToInt32(pagenow.Text) - 1).ToString();
        DataList1Bind(currentUser);
    }
    protected void lbtnLast_Click(object sender, EventArgs e)
    {
        pagenow.Text = totalPage_set.Text;
        DataList1Bind(currentUser);
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
    private void DataList2Bind(User_Info currentUser)
    {

        //链接数据库
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
        SqlConnection connection = new SqlConnection(constr);
        connection.Open();

        //查询语录数据；
        List<string> list_Sentence = new List<string>();
        getSplitStrings(list_Sentence, currentUser.Love_sentence, currentUser.Publish_sentence);

        if (list_Sentence.Count != 0)
        {
            //构造查询语录集的字符串
            string query_setence = "select * from SentenceList where ";

            for (int i = 0; i < list_Sentence.Count; i++)
            {
                if (i == 0)
                {
                    query_setence += "Sentence_id='" + list_Sentence[i] + "'";
                }
                else
                {
                    query_setence += " or Sentence_id='" + list_Sentence[i] + "'";
                }
            }
            query_setence += ";";


            SqlDataAdapter adapter = new SqlDataAdapter(query_setence, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            PagedDataSource pds = new PagedDataSource();

            pds.DataSource = ds.Tables[0].DefaultView;
            //允许分页
            pds.AllowPaging = true;
            //每页的数据数
            pds.PageSize = 2;
            int current_page = Convert.ToInt32(pagenow_sentence.Text);
            pds.CurrentPageIndex = current_page - 1;
            totalPage_sentence.Text = pds.PageCount.ToString();

            //设置所有点击按钮都可用；
            lbtnfirst_sentence.Enabled = true;
            lbtnUp_sentence.Enabled = true;
            lbtnNext_sentence.Enabled = true;
            lbtnLast_sentence.Enabled = true;
            if (current_page == 1)
            {
                lbtnfirst_sentence.Enabled = false;
                lbtnUp_sentence.Enabled = false;
            }
            if (current_page == Convert.ToInt32(totalPage_sentence.Text))
            {
                lbtnLast_sentence.Enabled = false;
                lbtnNext_sentence.Enabled = false;
            }
           // DataListMySentence.DataSource = pds;
            //DataListMySentence.DataBind();
        }
        else
        {
            //DataListMySentence.DataSource = "";
           // DataListMySentence.DataBind();
        }
        connection.Close();
    }

    protected void lbtnFirst_Click_sentence(object sender, EventArgs e)
    {
        pagenow_sentence.Text = "1";
        DataList2Bind(currentUser);
    }
    protected void lbtnNext_Click_sentence(object sender, EventArgs e)
    {
        pagenow_sentence.Text = (Convert.ToInt32(pagenow_sentence.Text) + 1).ToString();
        DataList2Bind(currentUser);

    }
    protected void lbtnUp_Click_sentence(object sender, EventArgs e)
    {
        pagenow_sentence.Text = (Convert.ToInt32(pagenow_sentence.Text) - 1).ToString();
        DataList2Bind(currentUser);
    }
    protected void lbtnLast_Click_sentence(object sender, EventArgs e)
    {
        pagenow_sentence.Text = totalPage_sentence.Text;
        DataList2Bind(currentUser);
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

    //Delete_Set_Click
    //1. 获取从imagebutton传过来的参数，要删除的语录集的名字
    //2.判断当前用户的喜欢语录是否有这个语录集名字，有，返回排除掉这个语录集名字的字符串，然后进行数据库更新操作；没有，不做任何操作；
    //3.判断当前用户的发布语录是否有这个语录集名字，有，返回排除掉这个语录集名字的字符串，然后进行数据库更新操作；没有，不做任何操作；
    //4.进行语录集数据绑定；

    protected void Delete_Set_Click(object sender, ImageClickEventArgs e)
    {
        //获取ImageButton传过来的参数title
        ImageButton imgBtn = (ImageButton)sender;
        string del_set = imgBtn.CommandArgument;


        //封装当前用户的喜欢语录集；
        List<string> list_SentenceSet_love = new List<string>();
        getSplitStrings(list_SentenceSet_love, currentUser.Love_set);

        if (list_SentenceSet_love.Count > 0)
        {
            string love_str = dealString(list_SentenceSet_love, del_set);
            //更新操作；
            string sql_love_str = "update Web_User set love_set='" + love_str + "' where username='" + currentUser.Username + "';";
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            SqlCommand command1 = new SqlCommand(sql_love_str, connection);
            command1.ExecuteNonQuery();
            connection.Close();
        }
        //封装当前用户发布的语录集；
        List<string> list_SentenceSet_Publish = new List<string>();
        getSplitStrings(list_SentenceSet_Publish, currentUser.Publish_set);

        if (list_SentenceSet_Publish.Count > 0)
        {
            string publsh_str = dealString(list_SentenceSet_Publish, del_set);
            //更新操作；
            string sql_publish_str = "update Web_User set publish_set='" + publsh_str + "' where username='" + currentUser.Username + "';";
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            SqlCommand command1 = new SqlCommand(sql_publish_str, connection);
            command1.ExecuteNonQuery();
            connection.Close();
        }

        //封装更改后的用户的信息；
        PacketUserInfo();
        DataList1Bind(currentUser);
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
    protected void Delete_Sentence_Click(object sender, ImageClickEventArgs e)
    {
        //获取ImageButton传过来的参数title
        ImageButton imgBtn = (ImageButton)sender;
        string del_set = imgBtn.CommandArgument;


        //封装当前用户的喜欢语录集；
        List<string> list_Sentence_love = new List<string>();
        getSplitStrings(list_Sentence_love, currentUser.Love_sentence);

        if (list_Sentence_love.Count > 0)
        {
            string love_str = dealString(list_Sentence_love, del_set);
            //更新操作；
            string sql_love_str = "update Web_User set love_sentence='" + love_str + "' where username='" + currentUser.Username + "';";
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            SqlCommand command1 = new SqlCommand(sql_love_str, connection);
            command1.ExecuteNonQuery();
            connection.Close();
        }
        //封装当前用户发布的语录集；
        List<string> list_Sentence_Publish = new List<string>();
        getSplitStrings(list_Sentence_Publish, currentUser.Publish_sentence);

        if (list_Sentence_Publish.Count > 0)
        {
            string publsh_str = dealString(list_Sentence_Publish, del_set);
            //更新操作；
            string sql_publish_str = "update Web_User set publish_sentence='" + publsh_str + "' where username='" + currentUser.Username + "';";
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            SqlCommand command1 = new SqlCommand(sql_publish_str, connection);
            command1.ExecuteNonQuery();
            connection.Close();
        }

        //封装更改后的用户的信息；
        PacketUserInfo();
        DataList2Bind(currentUser);
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
    protected void updateGuess_set_Click(object sender, ImageClickEventArgs e)
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
                    DataList2Bind(currentUser);
                    DataListguess1Bind();

                }
                else
                {
                    sql_query = "select numOfFavorite from SentenceSet where Sentence_id='" + sentence_id + "';";
                    string numOflove = (Convert.ToInt32(queryItemData(sql_query)) + 1).ToString();
                    string sql_update = "update SentenceList set numOfFavorite='" + numOflove + "' where Sentence_id='" + sentence_id + "';";
                    updateDB(sql_update);
                    PacketUserInfo();
                    DataList1Bind(currentUser);
                    DataListguess2Bind();
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
                DataList2Bind(currentUser);
                DataListguess1Bind();
            }
            else
            {
                sql_query = "select numOfFavorite from SentenceSet where book_id='" + sentence_id + "';";
                string numOflove = (Convert.ToInt32(queryItemData(sql_query)) - 1).ToString();
                string sql_update = "update SentenceList set numOfFavorite='" + numOflove + "' where Sentence_id='" + sentence_id + "';";
                updateDB(sql_update);
                PacketUserInfo();
                DataList1Bind(currentUser);
                DataListguess2Bind();
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