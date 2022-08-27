using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
namespace FinalApp
{
    public partial class Game : System.Web.UI.Page
    {
        
        static databaseConnect dataConnects = new databaseConnect();
        static string my_username;
        protected void Page_Load(object sender, EventArgs e)
        {
            dataConnects.myConnection = dataConnects.getConnection();
            my_username = Session["Username"].ToString();
        }
    
        [WebMethod]
       static public bool UpdateDatabase(int clicks,string WinLose,string Gametime)
        {
     
            int user_id;    
            string TempQuery2="select id from userInfo where username='" +my_username+ "'";
            SqlCommand cmd = new SqlCommand(TempQuery2, dataConnects.myConnection);
            dataConnects.myConnection.Open();
            user_id = Convert.ToInt32(cmd.ExecuteScalar());
            string TempQuery = "insert into Table_Game_Data(my_user_id,currentTime,numberOfClicks,WinLose,GameTime)VALUES ('" + user_id + "','" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "', '" + clicks + "','" + WinLose + "','" + Gametime + "')";
            dataConnects.sCmd = new SqlCommand(TempQuery, dataConnects.myConnection);
                dataConnects.sCmd.ExecuteNonQuery();
                dataConnects.myConnection.Dispose();
              
            
            return true;
        }
       
    }
    
}