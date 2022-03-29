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

public partial class AddressBook_Admin_panel_State_StateList : System.Web.UI.Page
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
        objCmd.CommandText = "PR_State_SelectAll";
        SqlDataReader objSDR = objCmd.ExecuteReader();
        gvState.DataSource = objSDR;
        gvState.DataBind();
        objConn.Close();
    }
    #endregion FillGrideView

    #region rowCommand
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteState(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        
    }
    #endregion rowCommand

    #region DeleteState
    private void DeleteState(SqlInt32 StateID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        objConn.Open();

        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objConn;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_State_DeleteByPK";
        objCmd.Parameters.AddWithValue("@StateID", StateID.ToString());
        objCmd.ExecuteNonQuery();
        objConn.Close();
        FillGrideView();
    }
    #endregion DeleteState
}