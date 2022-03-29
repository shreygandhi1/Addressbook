﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddressBook_Admin_panel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            if (Request.QueryString["StateID"] != null)
            {
                lblmessage.Text = "Edit Mode | StateID = " + Request.QueryString["StateID"].ToString().Trim();
                FillControl(Convert.ToInt32(Request.QueryString["StateID"]));
            }
            else
            {
                lblmessage.Text = "Add Mode";
            }
            
        }
    }
    #endregion Load Event
    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strStateName = SqlString.Null;
        SqlString  strStateCode = SqlString.Null;
        SqlString strCreationDate = SqlString.Null;
        #endregion Local Variable
        try
        {
            #region Server Side Validation
            String strErrorMessage = "";

            if (ddlCountryID.SelectedIndex == 0)
            {
                strErrorMessage += "Select Country<br />";
            }
            if (txtStateName.Text.Trim() == "")
            {
                strErrorMessage += "enter State Name<br />";
            }
            if (strErrorMessage.Trim() != "")
            {
                lblmessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation
            #region Gather Information
            if (ddlCountryID.SelectedIndex > 0)
            {
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            }
            if (txtStateName.Text.Trim() != "")
            {
                strStateName = txtStateName.Text.Trim();
            }
            if (txtStateCode.Text.Trim() != "")
            {
                strStateCode = txtStateCode.Text.Trim();
            }
            if (txtCreationDate.Text.Trim() != "")
            {
                strCreationDate = txtCreationDate.Text.Trim();
            }
            #endregion Gather Information

            #region Set Connection & Command
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateName", strStateName);
            objCmd.Parameters.AddWithValue("@StateCode", strStateCode);
            objCmd.Parameters.AddWithValue("@CreationDate", strCreationDate);
            #endregion Set Connection & Command
            if (Request.QueryString["StateID"] != null)
            {
                #region Update Record
                // edit mode
                objCmd.Parameters.AddWithValue("@StateID", Request.QueryString["StateID"].ToString().Trim());
                objCmd.CommandText = "PK_State_UpdateByPK";
                objCmd.ExecuteNonQuery();
                 Response.Redirect("~/Adminpanel/State/StateList.aspx", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                // Add mode
                objCmd.CommandText = "PR_State_Insert";
                objCmd.ExecuteNonQuery();
                txtStateCode.Text = "";
                txtStateName.Text = "";
                ddlCountryID.SelectedIndex = 0;
                txtCreationDate.Text = "";
                ddlCountryID.Focus();
                lblmessage.Text = "Data Inserted Successfully";
                #endregion Insert Record
            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
        finally
        {
            if(objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Button : Save
    #region FillDropDownList
    private void FillDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        objConn.Open();
        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_Country_SelectForDropDownList";
        SqlDataReader objSDR = objCmd.ExecuteReader();
        if (objSDR.HasRows == true)
        {
            ddlCountryID.DataSource = objSDR;
            ddlCountryID.DataValueField = "CountryID";
            ddlCountryID.DataTextField = "CountryName";
            ddlCountryID.DataBind();
        }
        ddlCountryID.Items.Insert(0, new ListItem("select Country", "-1"));
        objConn.Close();
    }
    #endregion FillDropDownList
    #region FillControl
    private void FillControl(SqlInt32 StateID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectByPK";

            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        txtStateName.Text = objSDR["StateName"].ToString().Trim();
                        txtStateCode.Text = objSDR["StateCode"].ToString().Trim();
                        txtCreationDate.Text = objSDR["CreationDate"].ToString().Trim();
                    }
                    //if (!objSDR["StateCode"].Equals(DBNull.Value))
                    //{
                    //    txtStateCode.Text = objSDR["StateCode"].ToString().Trim();
                    //}
                    //if (!objSDR["CreationDate"].Equals(DBNull.Value))
                    //{
                    //    txtCreationDate.Text = objSDR["CreationDate"].ToString().Trim();
                    //}
                    break;
                }
            }
            else
            {
                lblmessage.Text = "No Data available for the StateID = " + StateID.ToString();
                
            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion FillControl
    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    #endregion Button : Cancel
}