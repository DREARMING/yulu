using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class createSet : System.Web.UI.Page
{
  
    static PagedDataSource pds_set = new PagedDataSource();
    static User_Info currentUser = new User_Info();
    static private string username;
    static int currentPage_guestSentence = 1;
    static int totalPage_guestSentence = 0;
    static public string imgurl = "images/bookset.png";
    static private string uploadMusic = "";
    static  string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();

    protected void Page_Load(object sender, EventArgs e){
        //User_Info currentUser = new User_Info();
        //获取要打开的个人页面的用户名；
        if (Session["currentUser"] != null)
        {
            username = Session["currentUser"].ToString();
        }
        
        if (!IsPostBack)
        {
            DataListguess1Bind();
        }
    }
    


    //猜的语录
    private void DataListguess1Bind() {
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
        pds.PageSize = 4;
        pds.CurrentPageIndex = currentPage_guestSentence - 1;
        totalPage_guestSentence = pds.PageCount;
        DataListguess1.DataSource = pds;
        DataListguess1.DataBind();
        connection.Close();
    }

     
    class User_Info {
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
        public  string publish_sentence;

        public string Publish_sentence
        {
            get { return publish_sentence; }
            set { publish_sentence = value; }
        }
    }


    protected void updateGuess_Click(object sender, ImageClickEventArgs e)
    {
        currentPage_guestSentence += 1;
        if (currentPage_guestSentence > totalPage_guestSentence) {
            currentPage_guestSentence = 1;
        }
        DataListguess1Bind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        bool fileIsValid = false;
        if (this.FileUploadImg.HasFile)
        {
            string fileExtension = System.IO.Path.GetExtension(this.FileUploadImg.FileName.ToLower());
            string[] Extension = new string[]{".png",".jpg",".gif"};
            for (int i = 0; i < Extension.Length; i++) { 
                if (Extension[i].Equals(fileExtension))
                {
                    fileIsValid = true;
                    break;
                }
            }

            if (fileIsValid)
            {
                int bytes = this.FileUploadImg.PostedFile.ContentLength;
                if (bytes <= 10485760)
                {
                    this.FileUploadImg.SaveAs(Server.MapPath("~/images/") + FileUploadImg.FileName);
                    //saveTheImage(FileUpload1.FileName);
                    string url = "images/" + FileUploadImg.FileName;
                    imgurl = url;
                    Response.Write("<script>alert('上传成功')</script>");
                }
                else
                {
                    Response.Write("<script>alert('文件最大为10MB！');</script>");
                    
                }

            }
            else
            {
                Response.Write("<script>alert('文件必须为图片格式');</script>");
            }
        }

    }

    private void saveTheImage(string imgName)
    {
        string sql = "update SentencesSet set head_img='" + imgName + "';";
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString"].ToString();
        SqlConnection connection = new SqlConnection(constr);
        connection.Open();
        SqlCommand command1 = new SqlCommand(sql, connection);
        command1.ExecuteNonQuery();
        connection.Close();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        bool fileIsValid = false;
        if (this.FileUpload1.HasFile)
        {
            string fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName.ToLower());
            string Extension = ".mp3";
                if (Extension.Equals(fileExtension))
                {
                    fileIsValid = true;
                }
                else
                {
                    Response.Write("<script>alert('格式错误，必须为mp3格式');</script>");
                }

            if (fileIsValid)
            {
                int bytes = this.FileUpload1.PostedFile.ContentLength;
                if (bytes <= 10485760)
                {
                    this.FileUpload1.SaveAs(Server.MapPath("~/dewplayer/mp3/") + FileUpload1.FileName);
                    uploadMusic = FileUpload1.FileName;
                }
                else
                {
                    Response.Write("<script>alert('文件最大为10MB！');</script>");

                }

            }
        }
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

    //提交！
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (!"".Equals(TextBox1.Text)) {
            string setTitle = TextBox1.Text;
            string simple_intro = TextBox2.Text;
            string type = RadioButtonList1.SelectedValue.ToString();
            string share_address = "";
            if ("书本".Equals(type) ){
                type = "book";
                share_address = TextBox3.Text;
            }
            else if ("电影".Equals(type)) {
                type = "movie";
                share_address = TextBox4.Text;
            }
            else
            {
                type = "music";
                share_address = uploadMusic;
            }
            string insert_sql = "insert into SentenceSet(title,head_img,author,class,share_address,simple_intro) values('" + setTitle + "','" + imgurl + "','" + username + "','" + type + "','" + share_address + "','" + simple_intro + "');";
            updateDB(insert_sql);
            

            string sql_query = "select publish_set from Web_User where username='"+username+"';";
            string sets = queryItemData(sql_query);
            List<string> list = new List<string>();
            getSplitStrings(list, sets);

            //查询出刚刚才入的bookId;
            string book_id_query = "select book_id from SentenceSet where title='"+setTitle+"' and author='"+username+"';";
            addStringToList(list, queryItemData(book_id_query));
            string sql_set = makeLoveStrng(list);
            string sql_update = "update Web_User set publish_set='" + sql_set + "' where username='" + username + "';";
            updateDB(sql_update);
            Response.Write("<script>alert('发布成功')</script>");
            Response.Redirect("issue.aspx");
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
}