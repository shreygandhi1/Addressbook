using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddressBook_Admin_panel_Contact_ContactList : System.Web.UI.Page
{

    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGrideView();
        }
    }
    #endregion DeleteContactCategory

    #region FillGrideView
    private void FillGrideView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        
        objConn.Open();

        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objConn;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_Contact_SelectAll";
        SqlDataReader objSDR = objCmd.ExecuteReader();
        gvContact.DataSource = objSDR;
        gvContact.DataBind();
        objConn.Close();
    }
    #endregion FillGrideView

    #region RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteContact(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion RowCommand

    #region DeleteContact
    private void DeleteContact(SqlInt32 ContactID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        
        objConn.Open();

        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objConn;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_Contact_Delete";
        objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString());
        objCmd.ExecuteNonQuery();
        objConn.Close();
        FillGrideView();
    }
    #endregion DeleteContact
}