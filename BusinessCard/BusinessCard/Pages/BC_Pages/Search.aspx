<%@ Page Title="Find BusinessCard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BusinessCard.Pages.BC_Pages.Update" %>

<%-- HEADER SECTION --%>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <%-- Set in Title attribute at the top of this page. --%>
                <h1><%: Title %>.</h1>
                <%--<h2>Welcome to your business card handler!</h2>--%>
            </hgroup>
        </div>
    </section>
</asp:Content>

<%-- CONTENT SECTION --%>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Handle your business cards:</h3>
    <ul>
        <li>
            <asp:HyperLink ID="HyperLink1" runat="server" Text="Upload business card" NavigateUrl="<%$ RouteUrl:routename=BusinessCardCreate %>" />
        </li>
        <li>
            <asp:HyperLink ID="HyperLink2" runat="server" Text="Search business card on company" NavigateUrl="<%$ RouteUrl:routename=SearchBusinessCardByCompany %>" />
        </li>
        <li>            
            <asp:HyperLink ID="HyperLink3" runat="server" Text="List all business cards" NavigateUrl="<%$ RouteUrl:routename=BusinessCardList %>" />
        </li>
    </ul>
</asp:Content>

<%-- FORM SECTION --%>
<asp:Content runat="server" ID="SearchForm" ContentPlaceHolderID="FormContent">

    <h3>Search a business card...</h3>
    
    <p>Company</p>
    <asp:TextBox ID="CompanyNameTextBox"  MaxLength="20" runat="server" ClientIDMode="Static"></asp:TextBox>


    <%--Text='<%#:BindItem.CompanyName  %>'--%>
    <%-- VALIDATION --%>
    <%-- requiredfieldvalidatior --%>
    <%-- regularexpressionvalidator to prevent bad chars --%>



    <div class="formItems">
        <asp:Button ID="FindButton" runat="server" OnClick="FindButton_Click" Text="Find" />
    </div>

</asp:Content>

