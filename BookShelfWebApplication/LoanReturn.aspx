<%-- 
-- 
-- Company: 
-- Motto: Talk more to loved ones!
-- Assignment: A book shelf application
-- Deadline: 2012-01-02
-- Programmer: Baran Topal 
-- Solution name: .BookShelfWeb
-- Project name: .BookShelfWeb
-- File name: LoanReturn.aspx
-- Status: Finished
--
--%>

<%@ Page Title=" BookShelfWeb Loan&Return Panel" Language="C#" AutoEventWireup="true"
    CodeBehind="LoanReturn.aspx.cs" Inherits="BookShelfWeb.LoanReturn" MasterPageFile="~/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <%-- Actually, I did the css styling in ~/Styles/Site.css, yet, to show my knowledge, I also add some css style in the aspx files--%>
    <%-- Normal condition is that I put every css element definition in a css file--%>
    <script type="text/javascript">
        function ShowModalDialog() {
            var x = $find("ModalExtnd1");
            Page_ClientValidate();
            if (!Page_IsValid)
                x.show();
        }

        function init()
        { document.getElementById('SummaryDiv').style.display = 'none'; }
    </script>
    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />
    <br />
    <h1 class="headline">
        LOAN/RETURN</h1>
    <br />
    <br />
    <asp:Label ID="UserIDLabel" runat="server" Text="User ID"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="UserIDTextBox" runat="server" Height="22px" Width="149px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserIDTextBox"
        Display="Dynamic" ErrorMessage="User id is required.">*User id is required</asp:RequiredFieldValidator>
    <br />
    <br />
    <br />
    <asp:Label ID="BookNameLabel" runat="server" Text="Book Name"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="BookNameTextBox" runat="server" Width="149px" Height="23px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="BookNameTextBox"
        Display="Dynamic" ErrorMessage="Book name is required.">*Book name is required</asp:RequiredFieldValidator>
    <br />
    <br />
    <br />
    <asp:Button ID="LoanButton" runat="server" OnClick="LoanButton_Click" Text="Loan!"
        Width="133px" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="ReturnButton" runat="server" OnClick="ReturnButton_Click" Text="Return!"
        Width="119px" />
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="HiddenLabel" runat="server" Visible="False"></asp:Label>
    <br />
    <br />
    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
        TargetControlID="RequiredFieldValidator1">
    </ajaxToolkit:ValidatorCalloutExtender>
    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
        TargetControlID="RequiredFieldValidator2">
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
    <asp:Label ID="lblHidden" runat="server" CssClass="hidelbl"></asp:Label>
</asp:Content>
