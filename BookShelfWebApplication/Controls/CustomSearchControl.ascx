<%-- 
-- 
-- Company: 
-- Motto: Talk more to loved ones!
-- Assignment: A book shelf application
-- Deadline: 2012-01-02
-- Programmer: Baran Topal 
-- Solution name: .BookShelfWeb
-- Project name: .BookShelfWeb
-- Folder name: Controls
-- File name: CustomSearchControl.ascx
-- Status: Finished
--
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomSearchControl.ascx.cs"
    Inherits="WebApplication1.CustomSearchControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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

<%-- Actually, I did the css styling in ~/Styles/Site.css, yet, to show my knowledge, I also add some css style in the aspx files--%>
<%-- Normal condition is that I put every css element definition in a css file--%>
<style type="text/css">
    .style1
    {
        width: 146px;
    }
</style>

<p>
    Search Key:</p>
<asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SearchTextBox"
    Display="Dynamic" ErrorMessage="Search keyword is required.">*Search keyword is required</asp:RequiredFieldValidator>
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<table style="width: 8%;">
    <tr>
        <td class="style1">
            Search Criteria:
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:DropDownList ID="SearchDropDownList" runat="server">
                <asp:ListItem>Full Name</asp:ListItem>
                <asp:ListItem>Book Name</asp:ListItem>
                <asp:ListItem>ISBN</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
</table>
<br />
<br />
<ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
    TargetControlID="RequiredFieldValidator1">
</ajaxToolkit:ValidatorCalloutExtender>
<ajaxToolkit:ModalPopupExtender ID="ModalExtnd1" runat="server" TargetControlID="lblHidden"
    PopupControlID="SummaryDiv" BackgroundCssClass="popupbg">
</ajaxToolkit:ModalPopupExtender>
<asp:HiddenField ID="lblHidden" runat="server" />
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
            <td>
                <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />
            </td>
            <td>
                <input type="button" value="OK" onclick="$find('ModalExtnd1').hide();" />
            </td>
        </tr>
    </table>
</div>
