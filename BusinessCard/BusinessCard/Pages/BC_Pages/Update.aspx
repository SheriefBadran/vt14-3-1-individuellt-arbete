﻿<%@ Page Title="Update business card" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="BusinessCard.Pages.BC_Pages.Update1" %>

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

    <asp:FormView ID="BusinessCardUpdate" runat="server"
            ItemType="BusinessCard.Model.Person"
            SelectMethod="BusinessCardUpdate_GetItem"
            UpdateMethod ="BusinessCardUpdate_UpdateItem"
            DataKeyNames="PersonID"
            ViewStateMode="Enabled">


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
                            <%--<asp:Literal ID="CompanyNameLiteral" OnDataBinding="CompanyNameLiteral_DataBinding" runat="server" Text='<%#:Item.PersonID  %>'></asp:Literal>--%>
                        </td>
                        <td>
                            <%--<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl='<%# GetRouteUrl("BusinessCardUpdate", new { id = Item.PersonID })  %>' Text='<%# Item.FirstName %>' />--%>
                            <asp:LinkButton runat="server" CommandName="Delete" Text="Delete" CausesValidation="false" />
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Edit" Text="Edit" CausesValidation="false" />
                        </td>
                    </tr>
                </ItemTemplate>

                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="FirstNameTextBox" Text='<%#:BindItem.FirstName %>' MaxLength="20" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="LastNameTextBox" Text='<%#:BindItem.LastName  %>' MaxLength="20" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%--<asp:DropDownList ID="DropDownListUpdate" runat="server" OnDataBinding="CompanyNameLiteral_DataBinding" DataTextField="CompanyName" DataValueField="CompanyID"></asp:DropDownList>--%>
                            <%--<asp:TextBox ID="CompanyNameTextBox" OnDataBinding="CompanyNameTextBox_DataBinding" runat="server" Text='<%#:Item.PersonID  %>'></asp:TextBox>--%>
                            
                        </td>
                        <td>
                            <%-- Command Buttons for Update and Cancel - SET BUTTON VALIDATIONGROUP TO UPDATE --%>
                            <%--<asp:HyperLink ID="HyperLink4" runat="server">HyperLink</asp:HyperLink>--%>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Update" Text="Save" ValidationGroup="update" />
                            <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
                        </td>
                    </tr>
                </EditItemTemplate>
    </asp:FormView>
</asp:Content>
