using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace FinalApp
{
    public partial class Login : System.Web.UI.Page
    {
        
        databaseConnect dataConnect = new databaseConnect();
        DataTable myDataTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            dataConnect.myConnection = dataConnect.getConnection();
        }

        protected void LoginClick(object sender, EventArgs e)
        {
            string TempQuery = "select * from dbo.tableCredentialData";
            dataConnect.myConnection.Open();
            dataConnect.sCmd = new SqlCommand(TempQuery, dataConnect.myConnection);
            //SqlDataAdapter sda = new SqlDataAdapter(dataConnect.sCmd);
            //sda.Fill(myDataTable);
                string query1 = "select username from userInfo where username='" + emailTextbox.Text + "'";
                string query2 = "select my_Password from userInfo where my_Password='" + passwordTextbox.Text + "'";
            
                bool isUsername = checkDuplicate(emailTextbox.Text,query1);//(row["Username"].ToString() == (emailTextbox.Text).ToString());
                bool isPassword = checkDuplicate(passwordTextbox.Text,query2);//(row["my_Password"].ToString() == (passwordTextbox.Text).ToString());
                dataConnect.myConnection.Dispose();
                if (isUsername && isPassword)
                {
                    Session["Username"] = emailTextbox.Text;
                    Response.Redirect("Game.aspx");
                }
                

            
        }

        public bool checkDuplicate(string user, string query)
        {
            bool ischecked = false;
            SqlCommand check = new SqlCommand(query, dataConnect.myConnection);
            string checkRows = (string)check.ExecuteScalar();
            if (checkRows == user)
            {
                ischecked = true;
            }
            return ischecked;

        }
        protected void RegisterClick(object sender, EventArgs e)
        {
            Response.Redirect("Registeration.aspx");
        }

        

        

      
    }
}