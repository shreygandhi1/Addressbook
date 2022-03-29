using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddressBook_Admin_panel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                lblMessage.Text = "Edit Mode | CountryID = " + Request.QueryString["CountryID"].ToString();
                FillControl(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // SqlString strCountryID = SqlString.Null;
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;
        SqlString strCreationdate = SqlString.Null;
        String strErrorMessage = "";
        #region serverside Validation
        if (txtCountryName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Country Name<br />";

        }
        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion serverside Validation
        SqlConnection objConn = new SqlConnection("data source=LAPTOP-AC8CA939;initial catalog=AddressBook;Integrated Security=True;");
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            strCountryName = txtCountryName.Text.Trim();
            strCountryCode = txtCountryCode.Text.Trim();
            strCreationdate = txtCreationDate.Text.Trim();
            objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);
            objCmd.Parameters.AddWithValue("@CreationDate", strCreationdate);
            if (Request.QueryString["CountryID"] != null)
            {
                // Edit mode
                objCmd.Parameters.AddWithValue("@CountryID", Request.QueryString["CountryID"].ToString().Trim());
                objCmd.CommandText = "PR_Country_UpdateByPK";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AddressBook/AdminPanel/Contact/ContactList.aspx", true);
            }
            else
            {
                // Add mode
                objCmd.CommandText = "PR_Country_Insert";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Data Inserted Successfully";
                //txtCountryID.Text = "";
                txtCountryName.Text = "";
                txtCountryCode.Text = "";
                txtCreationDate.Text = "";
                txtCountryName.Focus();
            }

            
            // strCountryID = txtCountryID.Text.Trim();
            
            // objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            
           
            
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Button : Save


    #region FillControl
    private void FillControl(SqlInt32 CountryID)
    {
        SqlConnection objConn = new SqlConnection("data source=LAPTOP-AC8CA939;initial catalog=AddressBook;Integrated Security=True;");
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectPK";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    
                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }
                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    if (!objSDR["CreationDate"].Equals(DBNull.Value))
                    {
                        txtCreationDate.Text = objSDR["CreationDate"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the CountryID = " + CountryID.ToString();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion FillControl
}

   