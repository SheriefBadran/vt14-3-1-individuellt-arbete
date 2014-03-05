<%@ Page Title="Find BusinessCard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="BusinessCard.Pages.BC_Pages.Update" %>

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
            <a href="#">List all business cards</a>
        </li>
    </ul>
</asp:Content>

<%-- FORM SECTION --%>
<asp:Content runat="server" ID="CreateForm" ContentPlaceHolderID="FormContent">
    <h3>Search a business card...</h3>


    <p>First name</p>
    <asp:TextBox ID="FirstNameTextBox" MaxLength="20" runat="server"></asp:TextBox>

    <%-- VALIDATION --%>
    <%-- requiredfieldvalidator --%>
    <%-- regularexpressionvalidator to prevent bad chars --%>

    <p>Last name</p>
    <asp:TextBox ID="LastNameTextBox" MaxLength="20" runat="server"></asp:TextBox>

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
        <asp:Button ID="FindButton" runat="server" Text="Find" OnClick="FindButton_Click" />
    </div>

    <asp:FormView ID="BusinessCardFormView" runat="server"
        ItemType="BusinessCard.Model.Person"
        SelectMethod="BusinessCardFormView_GetItem"
        UpdateMethod="BusinessCardFormView_UpdateItem"
        DeleteMethod="BusinessCardFormView_DeleteItem"
        DataKeyNames="PersonID">

        <ItemTemplate>
            <tr>
                <td>
                    <asp:Literal ID="FirstNameLiteral" runat="server" Text='<%#: Item.FirstName %>' />
                </td>
                <td>
                    <asp:Literal ID="LastNameLiteral" runat="server" Text='<%#: Item.LastName %>' />
                </td>
                <td class="command">
                        <%-- Command Buttons for update and delete --%>
                    <%--<asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" 
                        OnClientClick='<%# String.Format("return confirm(\"Är du säker på att du vill ta bort kontakten {0} {1}?\")", Item.FirstName, Item.LastName) %>' />
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />--%>
                </td>
            </tr>
        </ItemTemplate>

    </asp:FormView>
</asp:Content>

