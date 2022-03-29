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

public partial class AddressBook_Admin_panel_City_CityList : System.Web.UI.Page
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
    try { 
        
        objConn.Open();

        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objConn;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[dbo].[PR_City_SelectAll]";
        SqlDataReader objSDR = objCmd.ExecuteReader();
        gvCity.DataSource = objSDR;
        gvCity.DataBind();
        objConn.Close();
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

    #region rowCommand
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteCity(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion rowCommand

    #region DeleteCity
    private void DeleteCity(SqlInt32 CityID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try { 
        objConn.Open();

        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objConn;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_City_DeleteByPK";
        objCmd.Parameters.AddWithValue("@CityID", CityID.ToString());
        objCmd.ExecuteNonQuery();
        objConn.Close();
        FillGrideView();
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
    #endregion DeleteCity
}