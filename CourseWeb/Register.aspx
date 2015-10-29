<%@ Page Title="" Language="C#" MasterPageFile="~/Pluralsight.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CourseWeb.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div style="text-align:center">
    
    <asp:EntityDataSource ID="courseDataSource" runat="server" 
        ContextTypeName="CourseDAL.PluralsightCoursesWF4Entities" 
        
            Select="it.[Topic], it.[Location], it.[CourseID], it.[StartDate], it.[EndDate]" EntitySetName="Courses" 
        Where="it.[CourseID] == @CourseID" EntityTypeFilter="Course" 
            ConnectionString="name=PluralsightCoursesWF4Entities" 
            DefaultContainerName="PluralsightCoursesWF4Entities" EnableFlattening="False">
        <WhereParameters>
            <asp:QueryStringParameter Name="CourseID" QueryStringField="courseid" 
                Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>
    <asp:DetailsView ID="courseDetailsView" runat="server" AutoGenerateRows="False" 
        DataSourceID="courseDataSource" Height="75px" Width="350px">
        <Fields>
            <asp:BoundField DataField="Topic" HeaderText="Topic" ReadOnly="True" 
                SortExpression="Topic" />
            <asp:BoundField DataField="Location" HeaderText="Location" ReadOnly="True" 
                SortExpression="Location" />
            <asp:BoundField DataField="StartDate" HeaderText="StartDate" ReadOnly="True" 
                SortExpression="StartDate"  DataFormatString="{0:d}"/>
            <asp:BoundField DataField="EndDate" HeaderText="EndDate" ReadOnly="True" 
                SortExpression="EndDate" DataFormatString="{0:d}" />
        </Fields>
    </asp:DetailsView>
    
    <div>&nbsp;</div>
    <div>
        Student name: <asp:TextBox ID="studentName" runat="server"></asp:TextBox><br />
        Student email: <asp:TextBox ID="studentEmail" runat="server"></asp:TextBox>
    </div>
    <div>&nbsp;</div>
    <div class="greenbtn">
        <asp:LinkButton ID="registerButton" runat="server" class="nav2"  
            onclick="registerButton_Click">Register</asp:LinkButton>
    </div>
    <div>
        <asp:Label runat="server" id="responseMessage" EnableViewState="false" />
    </div>
</div>

</asp:Content>
