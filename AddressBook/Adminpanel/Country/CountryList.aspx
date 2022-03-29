<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AddressBook_Admin_panel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Country List</h2>
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
                <asp:HyperLink runat="server" ID="hlAddCountry" Text="Add New Country" CssClass="btn btn-dark" NavigateUrl="~/AddressBook/Adminpanel/Country/CountryAddEdit.aspx" />
            </div>
            </div>
        </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="gvCountry" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand">
                 <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument= '<%# Eval("CountryID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-primary btn-sm" NavigateUrl='<%#"~/AddressBook/Adminpanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID".ToString().Trim()) %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CountryID" HeaderText="ID" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                    <asp:BoundField DataField ="CountryCode" HeaderText="Code" />
                    <asp:BoundField DataField="CreationDate" HeaderText="Date" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

