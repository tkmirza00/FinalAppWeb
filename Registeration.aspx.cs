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
    public partial class Registeration : System.Web.UI.Page
    {
        databaseConnect dataConnect = new databaseConnect();
        
        DataTable myDataTable = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            dataConnect.myConnection = dataConnect.getConnection();
        }

        protected void RegisterClick(object sender, EventArgs e)
        {
            string TempQuery = "insert into userinfo (username,my_password,FirstName,LastName,Gender) VALUES ('" + emailTextbox.Text + "', '" + passwordTextbox.Text + "','" + firstnameTextbox.Text + "','" + lastnameTextbox.Text + "','" + genderTextBox.Text + "')";
            string query = "select username from userInfo where username='" + emailTextbox.Text + "'";
            dataConnect.sCmd = new SqlCommand(TempQuery, dataConnect.myConnection);
            dataConnect.myConnection.Open();
            if (!checkDuplicate(emailTextbox.Text, query))
            {
                dataConnect.sCmd.ExecuteNonQuery();
                dataConnect.myConnection.Dispose();
                Response.Redirect("Login.aspx");
            }
        }
        public bool checkDuplicate(string user,string query)
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
        
    }
}