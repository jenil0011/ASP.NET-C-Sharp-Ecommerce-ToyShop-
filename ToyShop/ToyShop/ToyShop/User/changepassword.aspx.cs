using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace ToyShop.User
{
    public partial class changepassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-I97RBVP8\\SQLEXPRESS;Initial Catalog=ToyShopDB;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            
        }

        protected void changePwd_Click(object sender, EventArgs e)
        {
            con.Open();
            String cmd = "select UserId from [Users] where Password= '" + oldpassword.Text.ToString() + "' and Email='" + Session["Email"] + "'";
            SqlCommand change_password = new SqlCommand(cmd, con);
            SqlDataReader reade = change_password.ExecuteReader();


            if (reade.Read())
            {
                con.Close();
                if (newpassword.Text.Trim() == confirmpassword.Text.Trim())
                {
                    con.Open();
                    string strUPDT = "update [Users] set Password='" + newpassword.Text.ToString() + "' where Email='" + Session["Email"] + "'";
                    SqlCommand cmdUpdate = new SqlCommand(strUPDT, con);
                    cmdUpdate.ExecuteNonQuery();
                    Response.Redirect("Profile.aspx");
                    con.Close();
                    lblErrorMsg.Text = "Password Changed sucessfully.";
                    lblErrorMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblErrorMsg.Text = "New Password and Confirm Password is Not Same";
                    lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                lblErrorMsg.Text = "Incorrect Old Password.";
                lblErrorMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}