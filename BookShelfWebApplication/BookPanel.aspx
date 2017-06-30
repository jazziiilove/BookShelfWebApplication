<%-- 
-- 
-- Company: 
-- Motto: Talk more to loved ones!
-- Assignment: A book shelf application
-- Deadline: 2012-01-02
-- Programmer: Baran Topal 
-- Solution name: .BookShelfWeb
-- Project name: .BookShelfWeb
-- File name: BookPanel.aspx
-- Status: Finished
--
--%>

<%@ Page Title=" BookShelfWeb Book Panel" Language="C#" AutoEventWireup="true"
    CodeBehind="BookPanel.aspx.cs" Inherits="BookShelfWeb.BookPanel1" MasterPageFile="~/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <%-- Adding external javascript code--%>
    <asp:Literal ID="ExternalJS" runat="server"></asp:Literal>
    <% string fileName1 = ResolveUrl("~/Scripts/Rebtel_BookShelfWeb.js"); %>
    <script type="text/javascript">
        ShowModalDialog('Error', 'You have encountered a critical error.', 'error', 2);
    </script>
    <%-- Actually, I did the css styling in ~/Styles/Site.css, yet, to show my knowledge, I also add some css style in the aspx files--%>
    <%-- Normal condition is that I put every css element definition in a css file--%>
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
        .style3
        {
            height: 33px;
        }
        .style4
        {
            width: 548px;
        }
        .hidelbl
        {
            display: none;
        }
        .popupdiv
        {
            background-color: Blue;
            border: solid 1px skyblue;
            width: 250px;
            display: block;
        }
        .popupbg
        {
            background-color: gray;
        }
    </style>
    <script type="text/javascript" src='<%= fileName1 %>'></script>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />
    <h1 class="largerheadline">
        Book Panel</h1>
    <table>
        <tr>
            <td class="style1">
                <asp:Label ID="BookIDLabel" runat="server" Text="Book ID"></asp:Label>
                <br />
                *Book id is required to update and delete!
            </td>
            <td class="style4" rowspan="14">
                <asp:GridView ID="BookGridView" runat="server" AutoGenerateColumns="False" DataSourceID="BookEntityDataSource"
                    Height="272px" Width="540px" AllowPaging="True" AllowSorting="True" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableSortingAndPagingCallbacks="True"
                    DataKeyNames="bookID">
                    <Columns>
                        <asp:BoundField DataField="bookID" HeaderText="bookID" ReadOnly="True" SortExpression="bookID" />
                        <asp:BoundField DataField="isbn" HeaderText="isbn" SortExpression="isbn" />
                        <asp:BoundField DataField="bookName" HeaderText="bookName" SortExpression="bookName" />
                        <asp:BoundField DataField="authorName" HeaderText="authorName" SortExpression="authorName" />
                        <asp:BoundField DataField="userID" HeaderText="userID" SortExpression="userID" NullDisplayText="No user" />
                        <asp:BoundField DataField="bookStatus" HeaderText="bookStatus" SortExpression="bookStatus" />
                    </Columns>
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
                <asp:EntityDataSource ID="BookEntityDataSource" runat="server" ConnectionString="name=BookShelfWebEntities1"
                    DefaultContainerName="BookShelfWebEntities1" EnableDelete="True" EnableFlattening="False"
                    EnableInsert="True" EnableUpdate="True" EntitySetName="Books">
                </asp:EntityDataSource>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:TextBox ID="BookIDTextBox" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ISBNLabel" runat="server" Text="Book ISBN"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="BookISBNTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="BookISBNTextBox"
                    Display="Dynamic" ErrorMessage="BookISBN is required.">*ISBN is required</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="BookNameLabel" runat="server" Text="Book Name"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="BookNameTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="BookNameTextBox"
                    Display="Dynamic" ErrorMessage="Book name is required.">*Book name is required</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="BookAuthorLabel" runat="server" Text="Book Author"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="BookAuthorTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="BookAuthorTextBox"
                    Display="Dynamic" ErrorMessage="Book author is required.">*Book Author is required</asp:RequiredFieldValidator>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <br />
    <asp:CheckBox ID="InsertCheckBox" runat="server" Text="Check to update or delete user"
        onChange="ToggleTextBox();" ClientIDMode="Static" AutoPostBack="True" OnCheckedChanged="InsertCheckBox_CheckedChanged" />
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="HiddenLabel" runat="server" Visible="False"></asp:Label>
    <br />
    <p>
        <asp:Button ID="InsertButton" runat="server" OnClick="InsertButton_Click" Text="Insert!" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="UpdateButton" runat="server"
            OnClick="UpdateButton_Click" Text="Update!" Visible="False" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="DeleteButton" runat="server"
            OnClick="DeleteButton_Click" Text="Delete!" Visible="False" />
        &nbsp;
    </p>
    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
        TargetControlID="RequiredFieldValidator2">
    </ajaxToolkit:ValidatorCalloutExtender>
    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
        TargetControlID="RequiredFieldValidator3">
    </ajaxToolkit:ValidatorCalloutExtender>
    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server"
        TargetControlID="RequiredFieldValidator4">
    </ajaxToolkit:ValidatorCalloutExtender>
    <ajaxToolkit:ModalPopupExtender ID="ModalExtnd1" runat="server" TargetControlID="lblHidden"
        PopupControlID="SummaryDiv" BackgroundCssClass="popupbg">
    </ajaxToolkit:ModalPopupExtender>
    <div id="SummaryDiv" class="popupdiv">
        <table width="100%" style="font-family: 'Trebuchet MS', Tahoma, Verdana;">
            <tr>
                <td bgcolor="skyblue">
                    Errors on this page !
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Names="Arial">
                    </asp:ValidationSummary>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <input type="button" value="OK" onclick="$find('ModalExtnd1').hide();" />
                </td>
            </tr>
        </table>
    </div>
    <asp:Label ID="lblHidden" runat="server" Text="Label" CssClass="hidelbl"></asp:Label>
</asp:Content>
