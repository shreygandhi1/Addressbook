<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="AddressBook_Admin_panel_ContactCategory_ContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Country Add Edit Page</h2>
        </div>
    </div>
     <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
        </div>
    </div>
    <%--<div class="row">
        <div class="col-md-4">
            Contact Category ID
        </div>
         <div class="col-md-4">
             <asp:TextBox runat="server" ID="txtContactCategoryID" CssClass="form-control" />
        </div>
    </div>--%>
    <div class="row">
        
        <div class="col-md-4">
            Contact Category Name
        </div>
         <div class="col-md-8">
             <asp:TextBox runat="server" ID="txtContactCategoryName" CssClass="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            Creation Date
        </div>
         <div class="col-md-8">
             <asp:TextBox runat="server" ID="txtCreationDate" CssClass="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-8">
            <asp:Button runat="server" ID="btnSave" Text ="Save" CssClass="btn btn-dark btn-sm" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>

