<%@ Page Title="View business card list" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonList.aspx.cs" Inherits="BusinessCard.Pages.BC_Pages.PersonList" %>

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
            <asp:HyperLink ID="HyperLink2" runat="server" Text="Find business card" NavigateUrl="<%$ RouteUrl:routename=BusinessCardUpdate %>" />
        </li>
        <li>            
            <asp:HyperLink ID="HyperLink3" runat="server" Text="List all business cards" NavigateUrl="<%$ RouteUrl:routename=BusinessCardList %>" />
        </li>
    </ul>

    <asp:ListView ID="BusinessCardFormView" runat="server"
            ItemType="BusinessCard.Model.Person"
            SelectMethod="BusinessCardFormView_GetData"
            UpdateMethod="BusinessCardFormView_UpdateItem"
            DeleteMethod="BusinessCardFormView_DeleteItem"
            DataKeyNames="PersonID">
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
                    </tr>
                </ItemTemplate>
    </asp:ListView>
</asp:Content>
