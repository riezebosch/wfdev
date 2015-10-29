<%@ Page Title="" Language="C#" MasterPageFile="~/Pluralsight.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CourseWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

<asp:EntityDataSource
    ID="CourseDS" runat="server" 
        ContextTypeName="CourseDAL.PluralsightCoursesWF4Entities" 
        Select="it.[CourseID], it.[Topic], it.[Location], it.[StartDate], it.[State], it.[WorkflowID]"  
        Where="it.[State] != @Closed &amp;&amp; it.[WorkflowID] != @WorkflowID" 
        EntitySetName="Courses" ConnectionString="name=PluralsightCoursesWF4Entities" 
        DefaultContainerName="PluralsightCoursesWF4Entities" EnableFlattening="False" 
        EntityTypeFilter="Course">
        <WhereParameters>
            <asp:Parameter DefaultValue="3" Name="Closed" Type="Byte" />
            <asp:Parameter DbType="Guid" 
                DefaultValue="00000000-0000-0000-0000-000000000000" Name="WorkflowID" />
        </WhereParameters>
    </asp:EntityDataSource>
    
    <asp:ListView runat="server" ID="courseList" ItemPlaceholderID="placeholder" DataSourceID="CourseDS">
        <LayoutTemplate>
            <table width="100%">
            
                <div id="placeholder" runat="server"></div>
           
            </table>
        </LayoutTemplate>
        <ItemTemplate>
        <tr>
            <td><%# Eval("Topic") %></td>
            <td><%# Eval("Location") %></td>
            <td><%# Eval("StartDate") %></td>
            
            <td runat="server" visible='<%# (byte)Eval("State") == 1 %>'><a href="register.aspx?courseID=<%# Eval("CourseID") %>&wfid=<%# Eval("WorkflowID") %>">Register</a></td>
            
            <td runat="server" visible='<%# (byte)Eval("State") == 2 %>'><a href="registrations.aspx?courseID=<%# Eval("CourseID") %>">View Registrations</a></td>
            
        </tr>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
