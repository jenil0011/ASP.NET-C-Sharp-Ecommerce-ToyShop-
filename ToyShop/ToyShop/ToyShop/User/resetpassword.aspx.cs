using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace ToyShop.User
{
    public partial class resetpassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-I97RBVP8\\SQLEXPRESS;Initial Catalog=ToyShopDB;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            string forgot_otp = Request.QueryString["fotgot_otp"].ToString();
            string email = Request.QueryString["email"].ToString();
            con.Open();
            string checkActivation = "select UserId from [Users] where Email='" + email + "' and fotgot_otp='" + forgot_otp + "'";
            SqlCommand checkCMD = new SqlCommand(checkActivation, con);
            SqlDataReader read = checkCMD.ExecuteReader();
            if (read.Read())
            {
                PlaceHolder1.Visible = true;
                PlaceHolder2.Visible = false;

                con.Close();
            }
            else
            {
                PlaceHolder1.Visible = false;
                PlaceHolder2.Visible = true;
                con.Close();
            }
        }

        protected void resetpwdBtn_Click(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"].ToString();
            if (password.Text.ToString() == confirm_password.Text.ToString())
            {
                con.Open();
                // here, we have removed confirm_password
                string updateAcc = "update [Users] set fotgot_otp=0,Password='" + password.Text.ToString() + "' where Email='" + email + "'";
                SqlCommand cmdUpdate = new SqlCommand(updateAcc, con);
                cmdUpdate.ExecuteNonQuery();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Password Reset Successfully.');", true);
                Response.Redirect("Login.aspx");
                //lblErrorMsg.Text = "Password Reset Sucessfully.";
                //lblErrorMsg.ForeColor = System.Drawing.Color.Green;
                con.Close();
            }
            else
            {
                lblErrorMsg.Text = "Password and Confirm Password is not same.";
                lblErrorMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}