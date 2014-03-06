﻿<%@ Page Title="Upload New BusinessCard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="BusinessCard.Pages.BC_Pages.Create" %>

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
            <asp:HyperLink runat="server" Text="Upload business card" NavigateUrl="<%$ RouteUrl:routename=BusinessCardCreate %>" />
        </li>
        <li>
            <asp:HyperLink runat="server" Text="Find business card" NavigateUrl="<%$ RouteUrl:routename=BusinessCardUpdate %>" />
        </li>
        <li>            
            <asp:HyperLink ID="HyperLink3" runat="server" Text="List all business cards" NavigateUrl="<%$ RouteUrl:routename=BusinessCardList %>" />
        </li>
    </ul>
</asp:Content>

<%-- FORM SECTION --%>
<asp:Content runat="server" ID="CreateForm" ContentPlaceHolderID="FormContent">
    <h3>Go ahead and upload...</h3>

    <asp:FormView ID="InsertPerson" runat="server" 
        ItemType="BusinessCard.Model.Person"
        InsertMethod="InsertPerson_InsertItem" 
        DataKeyNames="PersonID"
        DefaultMode="Insert">

        <InsertItemTemplate>
            <p>First name</p>
            <asp:TextBox ID="FirstNameTextBox" Text='<%#:BindItem.FirstName  %>' MaxLength="20" runat="server"></asp:TextBox>

            <%-- VALIDATION --%>
            <%-- requiredfieldvalidator --%>
            <%-- regularexpressionvalidator to prevent bad chars --%>

            <p>Last name</p>
            <asp:TextBox ID="LastNameTextBox" Text='<%#:BindItem.LastName  %>' MaxLength="20" runat="server"></asp:TextBox>

            <%-- VALIDATION --%>
            <%-- requiredfieldvalidator --%>
            <%-- regularexpressionvalidator to prevent bad chars --%>

            <p>Company</p>
            <asp:TextBox ID="CompanyTextBox" MaxLength="40" runat="server"></asp:TextBox>

            <%-- VALIDATION --%>
            <%-- requiredfieldvalidatior --%>
            <%-- regularexpressionvalidator to prevent bad chars --%>


            <p>Convention date</p>
            <asp:TextBox ID="DateTextBox" runat="server"></asp:TextBox>
            <%-- requiredfieldvalidator --%>
            <%-- regularexpressionvalidator to validate given date format --%>

            <div class="formItems">
                <asp:Button ID="UploadButton" runat="server" Text="UpLoad" CommandName="Insert" />
            </div>
        </InsertItemTemplate>
    </asp:FormView>

</asp:Content>

