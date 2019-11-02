<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage_RN.master" AutoEventWireup="true" CodeFile="CityMaster.aspx.cs" Inherits="Masters_CityMaster" Title="City Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
<input type="hidden" id="hiddenbox" runat="server" value="" />

    <script type="text/javascript" language="javascript">
        function OnContactSelected(source, eventArgs) {

            var hdnValueID = "<%= hdnValue.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
            __doPostBack(hdnValueID, "");
        } 
    </script>
    <ajax:ToolkitScriptManager ID="ToolScriptManager" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div id="progressBackgroundFilter">
                    </div>
                    <div id="processMessage">
                        <center>
                            <span class="SubTitle">Loading....!!! </span>
                        </center>
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icon/updateprogress.gif"
                            Height="20px" Width="120px" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            Search For  City :
            <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                Width="292px" AutoPostBack="True" OnTextChanged="TxtSearch_TextChanged" TabIndex="6">
            </asp:TextBox>
            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtSearch"
                CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
            </ajax:AutoCompleteExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
   City Master
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <asp:UpdatePanel ID="AjaxPanelUpdateEntry" runat="server">
        <ContentTemplate>
            <table style="width: 100%">
                <tr>
                    <td align="center">
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                            <ProgressTemplate>
                                <%-- <div id="progressBackgroundFilter"></div>
               <div id="processMessage">   
               <center><span class="SubTitle">Loading....!!! </span></center>
               <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icon/updateprogress.gif" />                                
             </div>--%>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>
                        <fieldset id="fieldset1" width="90%" runat="server" class="FieldSet">
                            <table width="90%" cellspacing="6">
                                <tr>
                                    <td class="Label">
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        City :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="TxtDepartment" runat="server" CssClass="TextBox" MaxLength="50" TabIndex="1"
                                            Width="90%"></asp:TextBox>
                                              <asp:HiddenField ID="hdnValue" OnValueChanged="hdnValue_ValueChanged" runat="server" />
                                        <div id="div1">
                                        </div>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="Req1" runat="server" ControlToValidate="TxtDepartment"
                                            Display="None" ErrorMessage="City is Required" SetFocusOnError="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                            TargetControlID="Req1" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                             <ajax:AutoCompleteExtender ID="ACE1" runat="server" TargetControlID="TxtDepartment" CompletionInterval="100"
                                            UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                                            ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" OnClientItemSelected="OnContactSelected">
                                        </ajax:AutoCompleteExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td>
                        <fieldset id="fieldset2" runat="server" class="FieldSet">
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <table align="center" width="25%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="button" TabIndex="2"
                                                        ValidationGroup="Add" OnClick="BtnUpdate_Click" />
                                                    <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Would You Like To Update the Record ..! "
                                                        TargetControlID="BtnUpdate">
                                                    </ajax:ConfirmButtonExtender>
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" TabIndex="3"
                                                        ValidationGroup="Add" OnClick="BtnSave_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnDelete" runat="server" CssClass="button" Text="Delete" ValidationGroup="Add"
                                                        OnClick="BtnDelete_Click" TabIndex="4" />
                                                    <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" ConfirmText="Would You Like To Delete The Record ?"
                                                        TargetControlID="BtnDelete">
                                                    </ajax:ConfirmButtonExtender>
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="button" TabIndex="5"
                                                        CausesValidation="False" OnClick="BtnCancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ReportTitle" runat="Server">
    City List
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Report" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="ScrollableDiv_FixHeightWidthForRepeater">
                <ul id="subnav">
                    <%--Ul Li Problem Solved repeater--%>
                    <asp:Repeater ID="GrdReport" runat="server" OnItemCommand="GrdReport_ItemCommand">
                        <ItemTemplate>
                            <li id="Menuitem" runat="server">
                                <asp:LinkButton ID="lbtn_List" CssClass="linkButton" CausesValidation="false" CommandName="Select"
                                    CommandArgument='<%# Eval("#") %>' runat="server" Text='<%# Eval("Name") %>'>
                                </asp:LinkButton>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
