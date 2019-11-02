<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="ExpenseRegister.aspx.cs" Inherits="Transactions_ExpenseRegister" Title="Expense Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />

    <script type="text/javascript" language="javascript">
        function OnContactSelected(source, eventArgs) {
            var hdnValueID = "<%= hdnValue.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
          
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    Expense Register
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <asp:UpdatePanel ID="AjaxPanelUpdateEntry" runat="server">
        <ContentTemplate>
            <table style="width: 100%">
                <tr>
                    <td align="center">
                        <div>
                            <asp:UpdateProgress ID="UpdateProgress" runat="server">
                                <ProgressTemplate>
                                    <asp:Image ID="Image1" ImageUrl="~/Images/Icon/waiting.gif" AlternateText="Processing"
                                        runat="server" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <ajax:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
                                PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" />
                        </div>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>
                        <fieldset id="fieldset" runat="server" class="FieldSet">
                            <table width="100%" cellspacing="6">
                                <tr>
                                    <td class="Label">
                                    </td>
                                    <td align="left" colspan="2">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Expense NO :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtExpenseNo" runat="server" CssClass="TextBoxReadOnly" TabIndex="1"
                                            Width="200px"></asp:TextBox>
                                    </td>
                                    <td class="Label">
                                        Date :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="TextBox" Width="115px" TabIndex="1"></asp:TextBox>
                                        <asp:ImageButton ID="ImageFromDate" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                            ImageUrl="~/Images/Icon/DateSelector.png" TabIndex="1" />
                                        <ajax:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                            PopupButtonID="ImageFromDate" TargetControlID="txtFromDate" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Property Name:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPropertyName" runat="server" Width="200px" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqPropertyName" runat="server" ControlToValidate="ddlPropertyName"
                                            Display="None" ErrorMessage="Property Name Is Required" SetFocusOnError="True"
                                            ValidationGroup="Add">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                            TargetControlID="ReqPropertyName" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                    <td class="Label">
                                        Unit No :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtUnitNo" runat="server" CssClass="TextBox" TabIndex="1" Width="140px"></asp:TextBox>
                                        <asp:HiddenField ID="hdnValue" runat="server" />
                                        <asp:RequiredFieldValidator ID="Req_BuildingName" runat="server" ControlToValidate="txtUnitNo"
                                            Display="None" ErrorMessage="Unit no is Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                            TargetControlID="Req_BuildingName" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                        <ajax:AutoCompleteExtender ID="ACE1" runat="server" TargetControlID="txtUnitNo" CompletionInterval="100"
                                            UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                                            ServiceMethod="GetCompletionListUnitNo" CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                            OnClientItemSelected="OnContactSelected" MinimumPrefixLength="1">
                                        </ajax:AutoCompleteExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Expense Head:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlExpenseName" runat="server" Width="200px" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqProjectName" runat="server" ControlToValidate="ddlExpenseName"
                                            Display="None" ErrorMessage="Expense Head Is Required" SetFocusOnError="True"
                                            ValidationGroup="Add">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="VCEProjectName" runat="server" Enabled="True"
                                            TargetControlID="ReqProjectName" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                    <td class="Label">
                                        Amount :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtExpAmount" runat="server" CssClass="TextBoxNumeric" TabIndex="1"
                                            Width="140px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Remark :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRemark" runat="server" CssClass="TextBox" TabIndex="1" TextMode="MultiLine"
                                            Width="200px"></asp:TextBox>
                                        <asp:ImageButton ID="ImgAddRrow" runat="server" ImageUrl="~/Images/Icon/Gridadd.png"
                                            TabIndex="1" ToolTip="Add Grid" ValidationGroup="AddGrid" OnClick="ImgAddRrow_Click" />
                                    </td>
                                    <%-- <td class="Label">
                                    </td>
                                    <td align="left">--%>
                                    <%-- </td>--%>
                                </tr>
                            </table>
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <div style="overflow: scroll; width: 840px">
                                            <asp:GridView ID="GrdExpDtls" runat="server" AutoGenerateColumns="False" CaptionAlign="Top"
                                                CssClass="mGrid" DataKeyNames="#" TabIndex="1" Width="100%" OnRowCommand="GrdExpDtls_RowCommand"
                                                OnRowDeleting="GrdExpDtls_RowDeleting">
                                                <Columns>
                                                    <%--0--%>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnEdit" runat="server" CausesValidation="false" CommandArgument="<%#((GridViewRow)Container).RowIndex %>"
                                                                CommandName="SelectDtls" ImageUrl="~/Images/Icon/GridEdit.png" ToolTip="Edit"
                                                                TabIndex="1" />
                                                            <asp:ImageButton ID="ImgBtnDelete" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                                                CommandArgument='<%# Eval("#") %>' CommandName="Delete" ImageUrl="../Images/Icon/GridDelete.png"
                                                                TabIndex="1" ToolTip="Delete Record" />
                                                            <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete The Record..!"
                                                                TargetControlID="ImgBtnDelete">
                                                            </ajax:ConfirmButtonExtender>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="#">
                                                        <HeaderStyle CssClass="Display_None" />
                                                        <ItemStyle CssClass="Display_None" />
                                                        <FooterStyle CssClass="Display_None" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ExpenseHdId" HeaderText="ExpenseHdId">
                                                        <HeaderStyle CssClass="Display_None" />
                                                        <ItemStyle CssClass="Display_None" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Expense" DataField="Expense">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Left" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Amount" DataField="Amount">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Left" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Remark" DataField="Remark">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Left" />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <PagerStyle CssClass="pgr" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <ajax:RoundedCornersExtender ID="RCE2" runat="server" TargetControlID="fieldset"
                            Color="Black" Enabled="True" BorderColor="Black" Radius="10">
                        </ajax:RoundedCornersExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        <fieldset id="fieldset1" runat="server" class="FieldSet">
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <table align="center" width="25%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="button" ValidationGroup="Add"
                                                        TabIndex="1" OnClick="BtnUpdate_Click" />
                                                    <%--   --%>
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" ValidationGroup="Add"
                                                        TabIndex="1" OnClick="BtnSave_Click" />
                                                    <%--  --%>
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="button" ValidationGroup="Add"
                                                        TabIndex="1" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="False"
                                                        OnClick="BtnCancel_Click" TabIndex="1" />
                                                    <%--    --%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <ajax:RoundedCornersExtender ID="RCE" runat="server" TargetControlID="fieldset1"
                            Color="Black" Enabled="True" BorderColor="Black" Radius="10">
                        </ajax:RoundedCornersExtender>
                    </td>
                </tr>
            </table>
            <table style="vertical-align: middle;" width="100%">
                <tr>
                    <td>
                        <div class="SectionSeperator">
                            Expense Reister List
                        </div>
                    </td>
                </tr>
            </table>
            <table style="vertical-align: middle;" width="100%">
                <tr>
                    <td>
                        <div class="GridSection">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 100px;">
                                                <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                                                    Width="350px" AutoPostBack="True" TabIndex="1"></asp:TextBox>
                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtSearch"
                                                    CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                                                    ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
                                                </ajax:AutoCompleteExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GrdReport" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                                    CssClass="mGrid" GridLines="None" PagerStyle-CssClass="pgr" DataKeyNames="#"
                                                    Width="100%" TabIndex="1" OnRowCommand="GrdReport_RowCommand" OnRowDeleting="GrdReport_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnEdit" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                                                    CommandArgument='<%# Eval("#") %>' CommandName="Select" ImageUrl="../Images/Icon/GridEdit.png"
                                                                    TabIndex="1" ToolTip="Edit Record" />
                                                                <asp:ImageButton ID="ImgBtnDelete" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                                                    CommandArgument='<%# Eval("#") %>' CommandName="Delete" ImageUrl="../Images/Icon/GridDelete.png"
                                                                    TabIndex="1" ToolTip="Delete Record" />
                                                                <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete The Record..!"
                                                                    TargetControlID="ImgBtnDelete">
                                                                </ajax:ConfirmButtonExtender>
                                                            </ItemTemplate>
                                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sr. No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblSrNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Width="5%" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ExpRegNo" HeaderText="ExpRegNo">
                                                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ExpenceRegDate" HeaderText="ExpenceRegDate">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <PagerStyle CssClass="pgr" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
