<%@ Page Title="" Language="C#" MasterPageFile="~/Pluralsight.master" AutoEventWireup="true" CodeBehind="Registrations.aspx.cs" Inherits="CourseWeb.Registrations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <asp:EntityDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="CourseDAL.PluralsightCoursesWF4Entities" 
        Select="it.[CourseID], it.[StudentName], it.[StudentEmail], it.[SignedIn]" 
        EntityTypeFilter="CourseRegistration"  EntitySetName="CourseRegistrations" 
        Where="it.[CourseID] == @CourseID" 
        ConnectionString="name=PluralsightCoursesWF4Entities" 
        DefaultContainerName="PluralsightCoursesWF4Entities" EnableFlattening="False">
        <WhereParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="CourseID" 
                QueryStringField="CourseID" Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="LinqDataSource1" onrowdatabound="RowDataBound">
        <Columns>
            <asp:BoundField DataField="StudentName" HeaderText="StudentName" 
                ReadOnly="True" SortExpression="StudentName" />
            <asp:BoundField DataField="StudentEmail" HeaderText="StudentEmail" 
                ReadOnly="True" SortExpression="StudentEmail" />
                
            <asp:HyperLinkField 
                DataNavigateUrlFields="StudentName,CourseID" 
                DataNavigateUrlFormatString="SignIn.aspx?StudentName={0}&amp;CourseID={1}" 
                Text="Sign In" />
        </Columns>
    </asp:GridView>

</asp:Content>
