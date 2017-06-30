<%-- 
-- 
-- Company: 
-- Motto: Talk more to loved ones!
-- Assignment: A book shelf application
-- Deadline: 2012-01-02
-- Programmer: Baran Topal 
-- Solution name: .BookShelfWeb
-- Project name: .BookShelfWeb
-- File name: Search.aspx
-- Status: Finished / TODO search by ISBN
--
--%>

<%@ Page Language="C#" Title=" BookShelfWeb Search" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="BookShelfWeb.Search" MasterPageFile="~/Site.Master" %>

<%@ Register TagPrefix="UC" TagName="CustomSearchControl" Src="Controls/CustomSearchControl.ascx" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <%-- Actually, I did the css styling in ~/Styles/Site.css, yet, to show my knowledge, I also add some css style in the aspx files--%>
    <%-- Normal condition is that I put every css element definition in a css file--%>
    <style type="text/css">
        .style2
        {
            width: 250px;
            height: 73px;
        }
        .style3
        {
            height: 73px;
            width: 517px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 class="headline">
        Search</h1>
    <div>
        <UC:CustomSearchControl ID="CustomSearchControl1" runat="server" />
        <asp:TextBox ID="ResultTextBox" runat="server" Height="282px" TextMode="MultiLine"
            Width="506px">Search Log:</asp:TextBox>
        <br />
    </div>
    <br />
    <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search!" />
    <br />
    <br />
</asp:Content>
