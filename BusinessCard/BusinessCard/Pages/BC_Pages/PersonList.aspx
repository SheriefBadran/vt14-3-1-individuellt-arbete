﻿<%@ Page Title="View business card list" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonList.aspx.cs" Inherits="BusinessCard.Pages.BC_Pages.PersonList" %>

<%-- HEADER SECTION --%>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <%-- Set in Title attribute at the top of this page. --%>
                <h1><%: Title %>.</h1>
                <%--<h2>Welcome to your business card handler! </h2>--%>
            </hgroup>
        </div>
    </section>
</asp:Content>

<%-- CONTENT SECTION --%>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Handle your business cards:</h3>

    <asp:ValidationSummary HeaderText="Error!" DisplayMode="BulletList" runat="server" />

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

    <asp:Panel ID="ResponsePanel" CssClass="confirmSuccess" runat="server" Visible="false">
        <p><asp:Literal ID="LiteralSuccess" runat="server" /></p>
    </asp:Panel>

    <asp:ListView ID="BusinessCardFormView" runat="server"
            ItemType="BusinessCard.Model.Person"
            SelectMethod="BusinessCardFormView_GetData"
            UpdateMethod="BusinessCardFormView_UpdateItem"
            DeleteMethod="BusinessCardFormView_DeleteItem"
            DataKeyNames="PersonID"
            ViewStateMode="Enabled">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <th>
                                Förnamn
                            </th>
                            <th>
                                Efternamn
                            </th>
                            <th>
                                Företag
                            </th>
                        </tr>

                        <%-- ROWS PLACEHOLDER --%>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>

                <%-- ROW TEMPLATE --%>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Literal ID="FirstNameLiteral" runat="server" Text='<%#: Item.FirstName %>' />
                        </td>
                        <td>
                            <asp:Literal ID="LastNameLiteral" runat="server" Text='<%#: Item.LastName %>' />
                        </td>
                        <td>
                            <asp:Literal ID="CompanyNameLiteral" OnDataBinding="CompanyNameLiteral_DataBinding" runat="server" Text='<%#:Item.PersonID  %>'></asp:Literal>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Delete" Text="Delete" CausesValidation="false" 
                                OnClientClick='<%# String.Format("return confirm(\"Delete {0} {1}?\")", Item.FirstName, Item.LastName) %>'/>
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Edit" Text="Edit" CausesValidation="false" />
                        </td>
                    </tr>
                </ItemTemplate>

                <EmptyDataTemplate>
                    <%-- Message to display when database has no businessCards --%>
                    <table class="grid">
                        <tr>
                            <td>
                                There is no BusinessCards to list!
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>

                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="FirstNameTextBox" Text='<%#:BindItem.FirstName %>' MaxLength="20" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="LastNameTextBox" Text='<%#:BindItem.LastName  %>' MaxLength="20" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Literal ID="CompanyNameLiteral" OnDataBinding="CompanyNameLiteral_DataBinding" runat="server" Text='<%#:Item.PersonID  %>'></asp:Literal>
                            
                        </td>
                        <td>
                            <%-- Command Buttons for Update and Cancel --%>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Save" ValidationGroup="update" />
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
                        </td>
                    </tr>

                    <asp:RequiredFieldValidator ControlToValidate="FirstNameTextBox" runat="server" ErrorMessage="First name is required." Display="None"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ControlToValidate="LastNameTextBox" runat="server" ErrorMessage="Last name is required." Display="None"></asp:RequiredFieldValidator>
                </EditItemTemplate>
    </asp:ListView>
</asp:Content>
