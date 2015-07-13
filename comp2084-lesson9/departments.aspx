<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="departments.aspx.cs" Inherits="comp2084_lesson9.departments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Departments</h1>


    <a href="department-details.aspx">Add Department</a>


    <asp:GridView runat="server" ID="grdDepartments" CssClass="table table-striped table-hover" 
        AutoGenerateColumns="false" AllowPaging="true" PageSize="2" OnPageIndexChanging="grdDepartments_PageIndexChanging" 
         OnRowDeleting="grdDepartments_RowDeleting" DataKeyNames="DepartmentID" >
        <Columns>

            <asp:BoundField DataField="DepartmentID" HeaderText="ID" Visible="false" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Budget" HeaderText="Budget" DataFormatString="{0:c}"/>
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" DataNavigateUrlFields="DepartmentID" 
                DataNavigateUrlFormatString="department-details.aspx?DepartmentID={0}" />
            <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" HeaderText="Delete"/>

        </Columns>

    </asp:GridView>

</asp:Content>
