<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AddressBook_Admin_panel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>City List</h2>
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
                <asp:HyperLink runat="server" ID="hlAddCity" Text="Add New City" CssClass="btn btn-dark" NavigateUrl="~/AddressBook/Adminpanel/City/CityAddEdit.aspx" />
            </div>
            </div>
        </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="gvCity" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvCity_RowCommand" >
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument= '<%# Eval("CityID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-primary btn-sm" NavigateUrl='<%#"~/AddressBook/Adminpanel/City/CityAddEdit.aspx?CityID=" + Eval("CityID".ToString().Trim())%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CityID" HeaderText="CityID" />
                    <asp:BoundField DataField="StateID" HeaderText="StateID" />
                    <asp:BoundField DataField="CityName" HeaderText="Name" />
                    <asp:BoundField DataField ="STDCode" HeaderText="Code" />
                    <asp:BoundField DataField="PinCode" HeaderText="PinCode" />
                    <asp:BoundField DataField="CreationDate" HeaderText="Date" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

