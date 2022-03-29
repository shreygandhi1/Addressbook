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

public partial class AddressBook_Admin_panel_ContactCategory_ContactCategoryList : System.Web.UI.Page
{

    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGrideView();
        }
    }
    #endregion Load Event

    #region FillGrideView
    private void FillGrideView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        
        objConn.Open();

        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objConn;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_ContactCategory_SelectAll";
        SqlDataReader objSDR = objCmd.ExecuteReader();
        gvContactCategory.DataSource = objSDR;
        gvContactCategory.DataBind();
        objConn.Close();
    }
    #endregion FillGrideView

    #region RowCommand
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteContactCategory(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion RowCommand

    #region DeleteContactCategory
    private void DeleteContactCategory(SqlInt32 ContactCategoryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        
        objConn.Open();

        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objConn;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_ContactCategory_Delete";
        objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString());
        objCmd.ExecuteNonQuery();
        objConn.Close();
        FillGrideView();
    }
    #endregion DeleteContactCategory

}