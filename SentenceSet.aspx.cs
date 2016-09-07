using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class SentenceSet : System.Web.UI.Page
{
    static PagedDataSource pds = new PagedDataSource();
    static PagedDataSource pds_set = new PagedDataSource();
    static int currentPage_guestSentence = 1;
    static int totalPage_guestSentence = 0;
    static private string book_id = "";
    static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
    private SententceSetDemo setDemo = new SententceSetDemo();
    private User_Info currentUser = new User_Info();
    private string username = "";

    protected void Page_Load(object sender, EventArgs e){
        //User_Info currentUser = new User_Info();
        //获取要打开的个人页面的用户名；
        if (Session["currentUser"] != null)
        {
            username = Session["currentUser"].ToString();
            PacketUserInfo();
        }
       
        if (Request.Params["id"] != null)
        {
            book_id = Request.Params["id"].ToString();
            PacketSentenceSet();
            Lab_title.Text = setDemo.Title;
            bookImage.ImageUrl = setDemo.Head_img;
            labauthor.Text = setDemo.Author;
            simpleTxt.Text = setDemo.Simple_intro;
            Label4.Text = setDemo.NumOfSententce;
            if (setDemo.Share_address.Length > 20)
            {
                shareText.Text = setDemo.Share_address.Substring(0, 20)+".....";
            }
            else
            {
                shareText.Text = setDemo.Share_address;
            }
            
            lovenum_label_sentence.Text = setDemo.NumOfFavorite;
            if ("music".Equals(setDemo.Type)) {
                HyperLink5.NavigateUrl = "MusicPlayer.aspx?song="+setDemo.Share_address;
            }
            else
            {
                HyperLink5.NavigateUrl = setDemo.Share_address;
            }
           
            HyperLink1.NavigateUrl = "~/others.aspx?author=" + setDemo.Author;
        }

        if (!IsPostBack)
        {
            DatalistRelatsentenceBind();
            DataListguess1Bind();
        }
    }

    private void DatalistRelatsentenceBind()
    {
        SqlConnection connection = new SqlConnection(constr);
        if (Convert.ToInt32(setDemo.NumOfSententce) > 0)
        {
        string sql ="select * from SentenceList where book_id='"+setDemo.Book_id+"';";
        
        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
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
            DatalistRelatsentence.DataSource = pds;
            DatalistRelatsentence.DataBind();
            }
        else
        {
            DatalistRelatsentence.DataSource = "";
            DatalistRelatsentence.DataBind();
        }
        connection.Close();
    }

    //Packet User_Info

    private void PacketUserInfo()
    {
        string sql = "select * from Web_User where username='" + username + "';";
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
    //Packet Sentence_info
    private void PacketSentenceSet()
    {
        string sql = "select * from SentenceSet where book_id='" + book_id + "';";
        SqlConnection connection = new SqlConnection(constr);
        connection.Open();
        SqlCommand command1 = new SqlCommand(sql, connection);
        SqlDataReader reader = command1.ExecuteReader();
        if (reader.Read())
        {
            setDemo.Book_id = reader[0].ToString();
            setDemo.Title = reader[1].ToString();
            setDemo.Head_img = reader[2].ToString();
            setDemo.Author = reader[3].ToString();
            setDemo.Type = reader[4].ToString();
            setDemo.Share_address = reader[5].ToString();
            setDemo.NumOfSententce = reader[6].ToString();
            setDemo.NumOfFavorite = reader[7].ToString();
            setDemo.Simple_intro = reader[8].ToString();
        }
        connection.Close();
    }

    protected void lbtnFirst_Click_sentence(object sender, EventArgs e)
    {
        pagenow_sentence.Text = "1";
        DatalistRelatsentenceBind();
    }
    protected void lbtnNext_Click_sentence(object sender, EventArgs e)
    {
        pagenow_sentence.Text = (Convert.ToInt32(pagenow_sentence.Text) + 1).ToString();
        DatalistRelatsentenceBind();

    }
    protected void lbtnUp_Click_sentence(object sender, EventArgs e)
    {
        pagenow_sentence.Text = (Convert.ToInt32(pagenow_sentence.Text) - 1).ToString();
        DatalistRelatsentenceBind();
    }
    protected void lbtnLast_Click_sentence(object sender, EventArgs e)
    {
        pagenow_sentence.Text = totalPage_sentence.Text;
        DatalistRelatsentenceBind();
    }

    //猜的语录
    private void DataListguess1Bind()
    {
        //链接数据库
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


    private void getSplitStrings(List<string> hSet, string p1, string p2)
    {
        string[] loves = p1.Split(new char[]{'$'});
        string[] publishs = p2.Split(new char[] {'$'});
        for (int i = 0; i < loves.Length; i++) {
            if (!"".Equals(loves[i]))
            hSet.Add(loves[i]);
        }
        for (int i = 0; i < publishs.Length; i++)
        {
            if(!"".Equals(publishs[i]))
            hSet.Add(publishs[i]);
        }
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

    class User_Info {
        string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        string head_img;

        public string Head_img
        {
            get { return head_img; }
            set { head_img = value; }
        }
        string love_set;

        public string Love_set
        {
            get { return love_set; }
            set { love_set = value; }
        }
        string love_sentence;

        public string Love_sentence
        {
            get { return love_sentence; }
            set { love_sentence = value; }
        }
        string publish_set;

        public string Publish_set
        {
            get { return publish_set; }
            set { publish_set = value; }
        }
        string publish_sentence;

        public string Publish_sentence
        {
            get { return publish_sentence; }
            set { publish_sentence = value; }
        }
    }

    class SententceSetDemo
    {
        string book_id;

        public string Book_id
        {
            get { return book_id; }
            set { book_id = value; }
        }
        string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        string head_img;

        public string Head_img
        {
            get { return head_img; }
            set { head_img = value; }
        }
        string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        string share_address;

        public string Share_address
        {
            get { return share_address; }
            set { share_address = value; }
        }
        string numOfSententce;

        public string NumOfSententce
        {
            get { return numOfSententce; }
            set { numOfSententce = value; }
        }
        string numOfFavorite;

        public string NumOfFavorite
        {
            get { return numOfFavorite; }
            set { numOfFavorite = value; }
        }
        string simple_intro;

        public string Simple_intro
        {
            get { return simple_intro; }
            set { simple_intro = value; }
        }
    }


    private void getSplitStrings(List<string> list, string p)
    {
        if (p==null) { 
        string[] str = p.Split(new char[] { '$' });

        for (int i = 0; i < str.Length; i++)
        {
            if (!"".Equals(str[i]))
                list.Add(str[i]);
        }
    }
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
                string sql = "update Web_User set " + column_name + "='" + love_str + "' where username='" + currentUser.Username + "';";
                updateDB(sql);
                string sql_query = "";
                if ("love_sentence".Equals(column_name))
                {
                    sql_query = "select numOfFavorite from SentenceList where Sentence_id='" + sentence_id + "';";
                    string numOflove = (Convert.ToInt32(queryItemData(sql_query)) + 1).ToString();
                    string sql_update = "update SentenceList set numOfFavorite='" + numOflove + "' where Sentence_id='" + sentence_id + "';";
                    updateDB(sql_update);
                    PacketUserInfo();
                    PacketSentenceSet();
                    DatalistRelatsentenceBind();
                    DataListguess1Bind();

                }
                else
                {
                    sql_query = "select numOfFavorite from SentenceSet where Sentence_id='" + sentence_id + "';";
                    string numOflove = (Convert.ToInt32(queryItemData(sql_query)) + 1).ToString();
                    string sql_update = "update SentenceList set numOfFavorite='" + numOflove + "' where Sentence_id='" + sentence_id + "';";
                    updateDB(sql_update);
                    PacketUserInfo();
                    PacketSentenceSet();
                    DatalistRelatsentenceBind();
                }
            }
        }
        else
        {
            List<string> list = new List<string>();
            getSplitStrings(list, currentUser.Love_sentence);
            string love_str = dealString(list, sentence_id);
            string sql = "update Web_User set " + column_name + "='" + love_str + "' where username='" + currentUser.Username + "';";
            updateDB(sql);
            string sql_query = "";
            if ("love_sentence".Equals(column_name))
            {
                sql_query = "select numOfFavorite from SentenceList where Sentence_id='" + sentence_id + "';";
                string numOflove = (Convert.ToInt32(queryItemData(sql_query)) - 1).ToString();
                string sql_update = "update SentenceList set numOfFavorite='" + numOflove + "' where Sentence_id='" + sentence_id + "';";
                updateDB(sql_update);
                PacketUserInfo();
                PacketSentenceSet();
                DatalistRelatsentenceBind();
                DataListguess1Bind();
            }
            else
            {
                sql_query = "select numOfFavorite from SentenceSet where book_id='" + sentence_id + "';";
                string numOflove = (Convert.ToInt32(queryItemData(sql_query)) - 1).ToString();
                string sql_update = "update SentenceList set numOfFavorite='" + numOflove + "' where Sentence_id='" + sentence_id + "';";
                updateDB(sql_update);
                PacketUserInfo();
                PacketSentenceSet();
                DatalistRelatsentenceBind();
            }

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

    //执行给定的更新的sql语句，没有返回值；
    private void updateDB(string sql)
    {
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

}