using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class web_admin_showSet : System.Web.UI.Page
{
    static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Web_DBConnectionString2"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        queryTheData();
        
    }

    private void queryTheData()
    {
        numSent_book.Text = numOfSet("numOfSentences","book").ToString();

        numSent_movie.Text = numOfSet("numOfSentences","movie").ToString();

        numSent_music.Text = numOfSet("numOfSentences","music").ToString();

        //...............
        beloved_book.Text = numOfSet("numOfFavorite", "book").ToString();
        beloved_movie.Text = numOfSet("numOfFavorite", "movie").ToString();
        beloved_music.Text = numOfSet("numOfFavorite", "music").ToString();


    }

    private int numOfSet(string column,string type)
    {
        int num = 0;
        string sql = "select "+ column +" from SentenceSet where class='" + type + "'";
        SqlConnection connection = new SqlConnection(constr);
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read()) {
            num += Convert.ToInt32(reader[0].ToString());
        }
        return num;
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