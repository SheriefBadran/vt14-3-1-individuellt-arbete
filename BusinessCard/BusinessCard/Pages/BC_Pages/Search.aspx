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

    <%-- VALIDATION --%>
    <asp:ValidationSummary HeaderText="Error!" DisplayMode="BulletList" runat="server" />
    
    <p><b>on company name</b></p>

    <asp:TextBox ID="CompanyNameTextBox"  MaxLength="40" Columns="40" runat="server" ClientIDMode="Static"></asp:TextBox>

    <div class="formItems">
        <asp:Button ID="FindButton" runat="server" OnClick="FindButton_Click" Text="Find" />
    </div>

    <%-- VALIDATION --%>
    <asp:RequiredFieldValidator  ControlToValidate="CompanyNameTextBox" runat="server" ErrorMessage="Company name is required." Display="None"></asp:RequiredFieldValidator>

    <asp:ListView ID="BusinessCardList" runat="server"
        ItemType="BusinessCard.Model.Person"
        DataKeyNames="PersonID"
        SelectMethod="BusinessCardList_GetData">

                <LayoutTemplate>
                    <table>
                        <tr>
                            <th>
                                Förnamn
                            </th>
                            <th>
                                Efternamn
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
                </ItemTemplate>

    </asp:ListView>

</asp:Content>

