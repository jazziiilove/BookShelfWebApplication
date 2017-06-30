<%-- 
-- 
-- Company: 
-- Motto: Talk more to loved ones!
-- Assignment: A book shelf application
-- Deadline: 2012-01-02
-- Programmer: Baran Topal 
-- Solution name: .BookShelfWeb
-- Project name: .BookShelfWeb
-- File name: UserPanel.aspx
-- Status: Finished
--
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPanel.aspx.cs" Inherits="BookShelfWeb.UserPanel1"
    MasterPageFile="~/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
            width: 455px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <%-- Actually, I did the javascripting in ~/Scripts/Rebtel_BookShelfWeb.js, yet, to show my knowledge, I also add some javascripting in the aspx files--%>
    <%-- Normal condition is that I put every css element definition in a css file--%>
    <script type="text/javascript">
        function ShowModalDialog() {
            var x = $find("ModalExtnd1");
            Page_ClientValidate();
            if (!Page_IsValid)
                x.show();
        }

        function init() {
            document.getElementById('SummaryDiv').style.display = 'none';
        }
    </script>
    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />
    <h1 class="largerheadline">
        User Panel</h1>
    <table>
        <tr>
            <td class="style1">
                <asp:Label ID="UserIDLabel" runat="server" Text="User ID"></asp:Label>
                <br />
                *User id is required to update and delete!
            </td>
            <td class="style4" rowspan="14">
                <asp:GridView ID="UserGridView" runat="server" Height="275px" Width="506px" AutoGenerateColumns="False"
                    DataKeyNames="userID" DataSourceID="UserEntityDataSource" AllowPaging="True"
                    AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                    BorderWidth="1px" CellPadding="3" EnableSortingAndPagingCallbacks="True">
                    <Columns>
                        <asp:BoundField DataField="userID" HeaderText="userID" ReadOnly="True" SortExpression="userID" />
                        <asp:BoundField DataField="fullName" HeaderText="fullName" SortExpression="fullName" />
                        <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                        <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                        <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
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
                <asp:EntityDataSource ID="UserEntityDataSource" runat="server" ConnectionString="name=BookShelfWebEntities1"
                    DefaultContainerName="BookShelfWebEntities1" EnableDelete="True" EnableFlattening="False"
                    EnableInsert="True" EnableUpdate="True" EntitySetName="Users" EntityTypeFilter="User">
                </asp:EntityDataSource>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:TextBox ID="UserIDTextBox" runat="server" ClientIDMode="Static" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="UserNameLabel" runat="server" Text="Full Name"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UserNameTextBox"
                    Display="Dynamic" ErrorMessage="User name is required.">*User name is required</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" ToolTip="Currently, just adding to database!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PasswordTextBox"
                    Display="Dynamic" ErrorMessage="Password is required.">*Password is required</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="VerifyPasswordLabel" runat="server" Text="Verify Password"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="VerifyPasswordTextBox" runat="server" TextMode="Password" ToolTip="Currently, no validation with password field!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="VerifyPasswordTextBox"
                    Display="Dynamic" ErrorMessage="Password  is required.">*Password is required</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="EmailAddressLabel" runat="server" Text="Email Address"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="EmailAddressTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="EmailAddressTextBox"
                    Display="Dynamic" ErrorMessage="Email is required.">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailAddressTextBox"
                    Display="Dynamic" ErrorMessage="Invalid Email address." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="AddressLabel" runat="server" Text="Address"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="AddressTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="AddressTextBox"
                    Display="Dynamic" ErrorMessage="Address is required.">*Address is required</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="CityLabel" runat="server" Text="City"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="CityTextBox"
                    Display="Dynamic" ErrorMessage="City is required.">*City is required</asp:RequiredFieldValidator>
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
    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
        TargetControlID="RequiredFieldValidator2">
    </ajaxToolkit:ValidatorCalloutExtender>
    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server"
        TargetControlID="RequiredFieldValidator3">
    </ajaxToolkit:ValidatorCalloutExtender>
    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server"
        TargetControlID="RequiredFieldValidator4">
    </ajaxToolkit:ValidatorCalloutExtender>
    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server"
        TargetControlID="RequiredFieldValidator5">
    </ajaxToolkit:ValidatorCalloutExtender>
    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server"
        TargetControlID="RegularExpressionValidator1">
    </ajaxToolkit:ValidatorCalloutExtender>
    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server"
        TargetControlID="RequiredFieldValidator7">
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
    <asp:Label ID="lblHidden" runat="server" />
</asp:Content>
