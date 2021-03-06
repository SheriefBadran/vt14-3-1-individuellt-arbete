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
            <asp:HyperLink runat="server" Text="Search business card on company" NavigateUrl="<%$ RouteUrl:routename=SearchBusinessCardByCompany %>" />
        </li>
        <li>            
            <asp:HyperLink ID="HyperLink3" runat="server" Text="List all business cards" NavigateUrl="<%$ RouteUrl:routename=BusinessCardList %>" />
        </li>
    </ul>
</asp:Content>

<%-- FORM SECTION --%>
<asp:Content runat="server" ID="CreateForm" ContentPlaceHolderID="FormContent">
    <h3>Go ahead and upload...</h3>

    <asp:Panel ID="ResponsePanel" CssClass="confirmSuccess" runat="server" Visible="false">
        <p><asp:Literal ID="LiteralSuccess" runat="server" /></p>
    </asp:Panel>

    <asp:ValidationSummary HeaderText="Error!" DisplayMode="BulletList" runat="server" />

    <asp:FormView ID="BusinessC" runat="server" 
        ItemType="BusinessCard.Model.Person"
        InsertMethod="BusinessC_InsertItem"
        DataKeyNames="PersonID"
        DefaultMode="Insert">

        <InsertItemTemplate>
            <p>First name</p>
            <asp:TextBox ID="FirstNameTextBox" Text='<%#:BindItem.FirstName %>' MaxLength="20" runat="server"></asp:TextBox>

            <p>Last name</p>
            <asp:TextBox ID="LastNameTextBox" Text='<%#:BindItem.LastName  %>' MaxLength="20" runat="server"></asp:TextBox>


            <p>Company</p>
            <asp:CheckBoxList ID="CompanyCheckBoxList" runat="server" OnDataBinding="CompanyCheckBoxList_DataBinding" SelectMethod="CompanyCheckBox_GetData" DataTextField="CompanyName" DataValueField="CompanyID" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Table" TextAlign="Left"></asp:CheckBoxList>

            <div class="formItems">
                <asp:Button ID="UploadButton" runat="server" Text="UpLoad" CommandName="Insert" />
            </div>

            <%-- VALIDATION --%>
            <asp:RequiredFieldValidator ControlToValidate="FirstNameTextBox" runat="server" ErrorMessage="First name is required." Display="None"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ControlToValidate="LastNameTextBox" runat="server" ErrorMessage="Last name is required." Display="None"></asp:RequiredFieldValidator>
        </InsertItemTemplate>
    </asp:FormView>

</asp:Content>

