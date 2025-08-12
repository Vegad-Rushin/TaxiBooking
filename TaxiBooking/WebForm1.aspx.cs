using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TaxiBooking
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        String s = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con; // Connection
        SqlDataAdapter da; // Container
        DataSet ds; // runtime container
        SqlCommand cmd; // insert, update, delete

        protected void Page_Load(object sender, EventArgs e)
        {
            getcon();
        }

        void getcon()
        {
            con = new SqlConnection(s);
            con.Open();
        }

        void clear()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            getcon();

            cmd = new SqlCommand("INSERT INTO taxiBooking (Name,Email, Phone, FromDestination, ToDestination) VALUES ('" + txtName.Text + "', '" + txtEmail.Text + "', '" + txtPhone.Text + "','" + fromDestination.SelectedValue + "', '" + toDestination.SelectedValue + "')", con);
            cmd.ExecuteNonQuery();
            clear();
            con.Close();
        }
    }
}