<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook/Content/AddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AddressBook_Admin_panel_State_StateList" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
     <div class="row">
        <div class="col-md-12">
            <h2>State List</h2>
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
                <asp:HyperLink runat="server" ID="hlAddState" Text="Add New State" CssClass="btn btn-dark" NavigateUrl="~/AddressBook/Adminpanel/State/StateAddEdit.aspx" />
            </div>
            <div>
                 <asp:GridView ID="gvState" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvState_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument= '<%# Eval("StateID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-primary btn-sm" NavigateUrl='<%#"~/AddressBook/Adminpanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID").ToString().Trim() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="StateID" HeaderText="ID" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                    <asp:BoundField DataField ="StateName" HeaderText="State" />
                    <asp:BoundField DataField="StateCode" HeaderText="StateCode" />
                    <asp:BoundField DataField="CreationDate" HeaderText="Date" />
                </Columns>
            </asp:GridView>
            </div>
           
        </div>
    </div>
</asp:Content>

