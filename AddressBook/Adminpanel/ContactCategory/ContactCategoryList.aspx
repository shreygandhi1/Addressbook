<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AddressBook_Admin_panel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>ContactCategory List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblMessage" runat="server" EnableViewState ="false"/>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
             <div>
                <asp:HyperLink runat="server" ID="hlAddContactCategory" Text="Add New Contact Category" CssClass="btn btn-dark" NavigateUrl="~/AddressBook/Adminpanel/ContactCategory/ContactCategoryAddEdit.aspx" />
            </div>
            <asp:GridView ID="gvContactCategory" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvContactCategory_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument= '<%# Eval("ContactCategoryID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-primary btn-sm" NavigateUrl='<%#"~/AddressBook/Adminpanel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID=" + Eval("ContactCategoryID".ToString().Trim()) %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="ContactCategoryID" HeaderText="ContactCategoryID" />
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="Name" />
                    <asp:BoundField DataField="CreationDate" HeaderText="Date" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

