<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AddressBook_Admin_panel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact Add Edit Page</h2>
        </div>
    </div>
     <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblmessage" EnableViewState="false" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-4">
                    Country 
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlCountryID" CssClass="form-select"></asp:DropDownList><br />
                </div>
                <div class="col-md-4">
                    State
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlStateID" CssClass="form-select"></asp:DropDownList><br />
                </div>
                <div class="col-md-4">
                    City
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlCityID" CssClass="form-select"></asp:DropDownList><br />
                </div>
                <div class="col-md-4">
                    Contact Category ID
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlContactCategoryID" CssClass="Form-Control" /><br />
                </div>
                <div class="col-md-4">
                    Contact Name
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtContactName" CssClass="form-control" /><br />
                </div>
                <div class="col-md-4">
                    Contact No
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control" /><br />
                </div>
                <div class="col-md-4">
                    WhatsApp No
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtWhatsappNo" CssClass="form-control" /><br />
                </div>
                <div class="col-md-4">
                    Birth Date
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtBirthDate" CssClass="form-control" /><br />
                </div>
                <div class="col-md-4">
                    Email
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" /><br />
                </div>
                <div class="col-md-4">
                    Age
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtAge" CssClass="form-control" /><br />
                </div>
                 <div class="col-md-4">
                    Address
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" /><br />
                </div>
                <div class="col-md-4">
                    Blood Group
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtBloodGroup" CssClass="form-control" /><br />
                </div>
                <div class="col-md-4">
                    FaceBookID
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtFaceBookID" CssClass="form-control" /><br />
                </div>
                    <div class="col-md-4">
                    LinkedINID
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtLinkedINID" CssClass="form-control" /><br />
                </div>
                <div class="col-md-4">
                    Creation Date
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtCreationDate" CssClass="form-control" /><br />
                </div>
                <div class="col-md-8">
                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-dark btn-sm" OnClick="btnSave_Click"  />
                </div>
                </div>
            </div>
    </div>
</asp:Content>

