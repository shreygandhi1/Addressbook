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

public partial class AddressBook_Admin_panel_Country_CountryList : System.Web.UI.Page
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
        try
        {
            
            objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Country_SelectALL]";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvCountry.DataSource = objSDR;
            gvCountry.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
       
        
    }
    #endregion FillGrideView

    #region gvCountry
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteCountry(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion gvCountry

    #region DeleteCountry
    private void DeleteCountry(SqlInt32 CountryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            
            objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_DeletePK";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString());
            objCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
       
        FillGrideView();
    }
    #endregion DeleteCountry
}