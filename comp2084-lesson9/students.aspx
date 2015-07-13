<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="comp2084_lesson9.students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Students</h1>

    <a href="student.aspx">Add Student</a>

    <asp:GridView runat="server" ID="grdStudents" CssClass="table table-striped table-hover"
         AutoGenerateColumns="false" AllowPaging="true" PageSize="3" OnPageIndexChanging="grdStudents_PageIndexChanging"
         OnRowDeleting="grdStudents_RowDeleting" AllowSorting="true" OnSorting="grdStudents_Sorting"
         DataKeyNames="StudentID">
        <Columns>
            <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
            <asp:BoundField DataField="FirstMidName" HeaderText="First name" />
            <asp:BoundField DataField="LastName" HeaderText="Last name" />
            <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" />
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" DataNavigateUrlFields="StudentID"
                 DataNavigateUrlFormatString="student.aspx?StudentID={0}" />
            <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" HeaderText="Delete" />
        </Columns>
    </asp:GridView>

</asp:Content>
