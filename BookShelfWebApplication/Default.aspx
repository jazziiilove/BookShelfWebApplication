<%-- 
-- 
-- Company: 
-- Motto: Talk more to loved ones!
-- Assignment: A book shelf application
-- Deadline: 2012-01-02
-- Programmer: Baran Topal 
-- Solution name: .BookShelfWeb
-- Project name: .BookShelfWeb
-- File name: Default.aspx
-- Status: Finished
--
--%>

<%@ Page Title=" BookShelfWeb Home" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookShelfWeb._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <%-- Actually, I did the css styling in ~/Styles/Site.css, yet, to show my knowledge, I also add some css style in the aspx files--%>
    <%-- Normal condition is that I put every css element definition in a css file--%>
    <style type="text/css">
        .style1
        {
            margin-left: 40px;
            width: 221px;
        }
        .style2
        {
            width: 240px;
        }
        .style3
        {
            width: 215px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Panel ID="StartPanel" runat="server">
        <h1 class="headline">
            </h1>
        <p class="smallheadline">
            <br />
            started in Stockholm, Sweden in May of 2006 and is currently the world’s second
            largest mobile VoIP (Voice Over IP) company.
        </p>
        <p class="customparagraph">
            Just as our name suggests, we were founded with one very specific goal in mind,
            which was, and still is, to rebel and fundamentally disrupt the telecommunications
            industry as we know it. We wanted to create an honest and transparent service that
            focused on doing one thing very well: to make it dead simple for people living in
            all corners of the world to speak with the loved ones in their lives without having
            to file for personal bankruptcy (sad but true).
        </p>
        <p>
            We wanted to make it free (or super cheap) and accessible, whenever and wherever
            you feel the urge to hear the voice of someone you love. 4 years, 13 million users,
            1,000,000,000 minutes and a 98% customer approval rating later, we’ve made it a
            fair bit on our journey, but still have a long way to go. With new technologies
            creating new possibilities for cheaper international and domestic communication,
            text as well as voice based, we see ourselves as a service in a constant state of
            progression. Some might say we’re in the business of international calling, but
            we like to say we’re in the business of nurturing relationships. Your relationships.
        </p>
        <p>
            Regardless if they span continents, or just a block down the street. Since we started
            out, we’ve made great mobile apps for&nbsp;iPhone,&nbsp;Android,&nbsp;BlackBerry&nbsp;anddesktop
            PCs. They might be different from the service we had back in 2006, but they all
            rest on our most important pillars; great quality at the lowest possible prices.
        </p>
        <p>
            Think it sounds like something you want to be a part of? In that case,&nbsp;we’d
            love to hear from you. Lastly, in case you wondered,  is funded by two very
            reputable venture capital firms;Index Ventures&nbsp;and&nbsp;Balderton Capital.
            They’ve worked with companies such as Skype, Betfair, MySQL, Yelp and Twitter. Safe
            to say, we’re in good company.
        </p>
        <div style="margin-left: 400px">
            <asp:Button ID="ClickButton" runat="server" OnClick="ClickButton_Click" Text="Click!" />
        </div>
    </asp:Panel>
    <div align="center">
        <asp:Panel ID="BookShelfPanel" runat="server" Visible="False">
            <h2 align="center">
                CLICK ON THE BUTTONS FOR FUNCTIONALITIES</h2>
            <br />
            <br />
            <table style="width: 100%;">
                <tr>
                    <td class="style1">
                        <asp:Button ID="ListUserButton" runat="server" Text="List Users in the system!" OnClick="ListUserButton_Click" />
                    </td>
                    <td class="style2">
                        <asp:Button ID="ListBookButton" runat="server" Text="List Books in the system!" Width="205px"
                            OnClick="ListBookButton_Click" Style="margin-left: 0px" />
                    </td>
                    <td class="style3">
                        <asp:Button ID="LoanBookButton" runat="server" Text="List Loaned Books!" Width="143px"
                            OnClick="LoanBookButton_Click" />
                    </td>
                    <td>
                        <asp:Button ID="ReturnBookButton" runat="server" Text="List Returned Books!" Width="131px"
                            OnClick="ReturnBookButton_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <asp:GridView ID="ListGridView" runat="server" CellPadding="3" Width="356px" OnRowCreated="UserGridView_RowCreated"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </asp:Panel>
        &nbsp;&nbsp;&nbsp;
    </div>
</asp:Content>
