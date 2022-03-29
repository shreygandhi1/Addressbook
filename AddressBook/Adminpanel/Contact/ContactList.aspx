<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AddressBook_Admin_panel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact List</h2>
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
                <asp:HyperLink runat="server" ID="hlAddContact" Text="Add New Contact" CssClass="btn btn-dark" NavigateUrl="~/AddressBook/Adminpanel/Contact/ContactAddEdit.aspx" />
            </div>
            <asp:GridView ID="gvContact" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvContact_RowCommand">
                 <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument= '<%# Eval("ContactID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-primary btn-sm" NavigateUrl='<%#"~/AddressBook/Adminpanel/Contact/ContactAddEdit.aspx?ContactID=" + Eval("ContactID".ToString().Trim()) %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ContactID" HeaderText="ContactID" />
                    <asp:BoundField DataField="CountryID" HeaderText="CountryID" />
                     <asp:BoundField DataField="StateID" HeaderText="StateID" />
                     <asp:BoundField DataField="CityID" HeaderText="CityID" />
                     <asp:BoundField DataField="ContactCategoryID" HeaderText="ContactCategoryID" />
                     <asp:BoundField DataField="ContactName" HeaderText="ContactName" />
                     <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />
                     <asp:BoundField DataField="WhatsAppNo" HeaderText="WhatsAppNo" />
                     <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" />
                     <asp:BoundField DataField="Email" HeaderText="Email" />
                     <asp:BoundField DataField="Age" HeaderText="Age"  />
                     <asp:BoundField DataField="Address" HeaderText="Address" />
                     <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup" />
                     <asp:BoundField DataField="FaceBookID" HeaderText="FaceBookID" />
                     <asp:BoundField DataField="LinkedINID" HeaderText="LinkedINID" />
                    <asp:BoundField DataField="CreationDate" HeaderText="Date" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

