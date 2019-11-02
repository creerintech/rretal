<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage_RN.master" AutoEventWireup="true" CodeFile="Property.aspx.cs" Inherits="Masters_Property" Title="Property Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <input type="hidden" id="hiddenbox" runat="server" value="" />
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>

    <style type="text/css">
        .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
    </style>

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
        prm.add_beginRequest(BeginRequestHandler);
        // Raised after an asynchronous postback is finished and control has been returned to the browser.
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            //Shows the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.show();
            }
        }

        function EndRequestHandler(sender, args) {
            //Hide the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.hide();
            }
        }
    </script>

    <script type="text/javascript" language="javascript">

        function UpdateEquipFunction() {

            var value = document.getElementById('<%=txtProperty.ClientID%>').value;

            if (value == "") {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "1";
            }
            else {
                if (confirm("Would You Want To Upadte The Record ?") == true) {
                    document.getElementById('<%= hiddenbox.ClientID%>').value = "0";
                    return false;
                }
                else {
                    document.getElementById('<%= hiddenbox.ClientID%>').value = "100";
                }
            }
        }
        function DeleteEquipFunction() {

            var value = document.getElementById('<%=txtProperty.ClientID%>').value;

            if (value == "") {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "1";
            }
            else {
                if (confirm("Would You Want To Delete This Record ?") == true) {
                    document.getElementById('<%= hiddenbox.ClientID%>').value = "0";
                    return false;
                }
                else {
                    document.getElementById('<%= hiddenbox.ClientID%>').value = "100";
                }
            }
        }
    </script>

   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="text-align: right; margin-right: 10px;">
                Search for Property :
                <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                    Width="292px" AutoPostBack="True" TabIndex="5" OnTextChanged="TxtSearch_TextChanged" ></asp:TextBox>
                <div id="divwidth">
                </div>
                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtSearch"
                    CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                    ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
                </ajax:AutoCompleteExtender>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    Property Master
    <asp:UpdatePanel ID="Upp" runat="server">
        <ContentTemplate>
            <table width="90%">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <asp:UpdatePanel ID="AjaxPanelUpdateEntry" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <fieldset id="fieldset1" width="100%" runat="server" class="FieldSet">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <table width="100%" cellspacing="6">
                                        <tr>
                                            <td class="Label">
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hdnFldUsedCnt" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Label" style="height: 24px">
                                                Property :
                                            </td>
                                            <td style="height: 24px">
                                                <asp:TextBox ID="txtProperty" runat="server" CssClass="TextBox" Width="200px" TabIndex="1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Req1" runat="server" ControlToValidate="txtProperty"
                                                    Display="None" ErrorMessage="Enter Property Text" SetFocusOnError="True" ValidationGroup="Add">
                                                </asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                    TargetControlID="Req1" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                </ajax:ValidatorCalloutExtender>
                                            </td>
                                            <td class="Label">
                                                Company:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCompany" runat="server" Width="200px" AutoPostBack="true" TabIndex="1">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="ReqProjectName" runat="server" ControlToValidate="ddlCompany"
                                                    Display="None" ErrorMessage="Company Name Is Required" SetFocusOnError="True"
                                                    ValidationGroup="Add">
                                                </asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="VCEProjectName" runat="server" Enabled="True"
                                                    TargetControlID="ReqProjectName" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                </ajax:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Label" style="height: 24px">
                                                Property Address :
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtPropertyAddress" runat="server" CssClass="TextBox" TextMode="MultiLine"
                                                    Width="200px" TabIndex="1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                          <td class="Label" style="height: 24px">
                                                Property Type :
                                            </td>
                                            <td style="height: 24px">
                                              <asp:DropDownList ID="ddlProprtyType" runat="server" Width="200px" AutoPostBack="true" TabIndex="1"  OnSelectedIndexChanged="ddlProprtyType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="ReqPropertyName" runat="server" ControlToValidate="ddlProprtyType"
                                                    Display="None" ErrorMessage="Proprty Type Name Is Required" SetFocusOnError="True"
                                                    ValidationGroup="Add">
                                                </asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="VCPT" runat="server" Enabled="True"
                                                    TargetControlID="ReqPropertyName" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                </ajax:ValidatorCalloutExtender>
                                            </td>
                                            <td class="Label">
                                                Property Sub Type:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPropertySubType" runat="server" Width="200px" AutoPostBack="true" TabIndex="1">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="ReqPropertySubType" runat="server" ControlToValidate="ddlPropertySubType"
                                                    Display="None" ErrorMessage="Property SubType Name Is Required" SetFocusOnError="True"
                                                    ValidationGroup="Add">
                                                </asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="VCEPST" runat="server" Enabled="True"
                                                    TargetControlID="ReqPropertySubType" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                </ajax:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                         <tr>
                                          <td class="Label" style="height: 24px">
                                                City :
                                            </td>
                                            <td style="height: 24px">
                                              <asp:DropDownList ID="ddlCity" runat="server" Width="200px" AutoPostBack="true" TabIndex="1"  OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="ReqCity" runat="server" ControlToValidate="ddlCity"
                                                    Display="None" ErrorMessage="City Name Is Required" SetFocusOnError="True"
                                                    ValidationGroup="Add">
                                                </asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="VCity" runat="server" Enabled="True"
                                                    TargetControlID="ReqCity" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                </ajax:ValidatorCalloutExtender>
                                            </td>
                                            <td class="Label">
                                                Location:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlLocation" runat="server" Width="200px" AutoPostBack="true" TabIndex="1">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="ReqLocation" runat="server" ControlToValidate="ddlLocation"
                                                    Display="None" ErrorMessage="Location Is Required" SetFocusOnError="True"
                                                    ValidationGroup="Add">
                                                </asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="VCELocation" runat="server" Enabled="True"
                                                    TargetControlID="ReqLocation" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                </ajax:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td>
                        <fieldset id="fieldset4" runat="server" class="FieldSet">
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <table align="center" width="25%">
                                            <tr>
                                                <table width="100%" cellspacing="6">
                                                    <tr>
                                                        <td class="Label">
                                                        </td>
                                                        <td>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Label" style="height: 24px">
                                                            Unit Type :
                                                        </td>
                                                        <td style="height: 24px">
                                                            <asp:DropDownList ID="ddlUnitType" runat="server" Width="200px" AutoPostBack="true" TabIndex="1">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlUnitType"
                                                                Display="None" ErrorMessage="Unit Type Is Required" SetFocusOnError="True"
                                                                ValidationGroup="Add">
                                                            </asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator2" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                            </ajax:ValidatorCalloutExtender>
                                                        </td>
                                                        <td class="Label">
                                                            Unit No:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtUnitNo" runat="server" CssClass="TextBox" Width="200px" TabIndex="1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Label">
                                                            Area(sqf) :
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAreaSqf" runat="server" CssClass="TextBox" Width="200px" TabIndex="1"></asp:TextBox>
                                                        </td>
                                                        <td class="Label">
                                                            Property Tax Amt:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPropertytaxAmt" runat="server" CssClass="TextBox" Width="200px"
                                                                TabIndex="1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Label">
                                                            Society Maint Amt :
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSocietyMAmt" runat="server" CssClass="TextBox" Width="200px"
                                                                TabIndex="1"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="ImgAddGrid" runat="server" ImageUrl="~/Images/Icon/Gridadd.png" TabIndex="1"
                                                                ToolTip="Add Grid" ValidationGroup="AddGrid" OnClick="ImgAddGrid_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>
                                                                    <table width="100%" cellspacing="10">
                                                                        <tr>
                                                                            <td>
                                                                                <div style="overflow: scroll; width: 600px;">
                                                                                    <asp:GridView ID="GridDetails" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                                                        BorderStyle="None" BorderWidth="1px" CssClass="mGrid" Font-Bold="False" ForeColor="Black"
                                                                                        TabIndex="1" GridLines="Horizontal" OnRowCommand="GridDetails_RowCommand" OnRowDeleting="GridDetails_RowDeleting">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="#" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="LblEntryId" runat="server" Text='<% #Eval("#") %>' />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:ImageButton ID="ImageGridEdit" runat="server" CausesValidation="false" CommandArgument="<%#((GridViewRow)Container).RowIndex %>"
                                                                                                        CommandName="SelectGrid" ImageUrl="~/Images/Icon/GridEdit.png" ToolTip="Edit"  TabIndex="1"/>
                                                                                                    <asp:ImageButton ID="ImageBtnDelete" runat="server" CommandArgument='<%#Eval("#") %>'
                                                                                                        CommandName="Delete" ImageUrl="~/Images/Icon/GridDelete.png" ToolTip="Delete"  TabIndex="1"/>
                                                                                                    <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete This Record?"
                                                                                                        TargetControlID="ImageBtnDelete">
                                                                                                    </ajax:ConfirmButtonExtender>
                                                                                                </ItemTemplate>
                                                                                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                <HeaderStyle Wrap="false" />
                                                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="FlatTypeId" HeaderText="FlatTypeId">
                                                                                                <HeaderStyle CssClass="Display_None" />
                                                                                                <ItemStyle CssClass="Display_None" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField HeaderText="Unit Type" DataField="FlatType">
                                                                                                <HeaderStyle Wrap="false" HorizontalAlign="Left" />
                                                                                                <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField HeaderText="Unit No" DataField="UnitNo">
                                                                                                <HeaderStyle Wrap="false"  HorizontalAlign="Left"/>
                                                                                                <ItemStyle Wrap="false"  HorizontalAlign="Left"/>
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField HeaderText="UnitArea" DataField="UnitArea">
                                                                                                <HeaderStyle Wrap="false"  HorizontalAlign="Right"/>
                                                                                                <ItemStyle Wrap="false"  HorizontalAlign="Right"/>
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField HeaderText="Property Tax Amt" DataField="PropTaxAmt">
                                                                                                <HeaderStyle Wrap="false"  HorizontalAlign="Right"/>
                                                                                                <ItemStyle Wrap="false"  HorizontalAlign="Right"/>
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField HeaderText="Society Maintenace Amt" DataField="SMAmt">
                                                                                                <HeaderStyle Wrap="false"  HorizontalAlign="Right"/>
                                                                                                <ItemStyle Wrap="false"  HorizontalAlign="Right"/>
                                                                                            </asp:BoundField>                                                                                           
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                
                
                <tr>
                    <td>
                        <fieldset id="fieldset3" runat="server" class="FieldSet">
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <table align="center" width="25%">
                                            <tr>
                                                <table width="100%" cellspacing="6">
                                                    <tr>
                                                        <td class="Label">
                                                        </td>
                                                        <td>
                                                            <asp:HiddenField ID="HiddenField2" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Label" style="height: 24px">
                                                            Expense Head :
                                                        </td>
                                                        <td style="height: 24px">
                                                            <asp:DropDownList ID="ddlExpenseHead" runat="server" Width="200px" AutoPostBack="true" TabIndex="1">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlExpenseHead"
                                                                Display="None" ErrorMessage="Expense Head Required" SetFocusOnError="True"
                                                                ValidationGroup="Add">
                                                            </asp:RequiredFieldValidator>
                                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator1" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                            </ajax:ValidatorCalloutExtender>
                                                        </td>
                                                        <td class="Label">
                                                            Amount :
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtExpAmount" runat="server" CssClass="TextBox" Width="200px" TabIndex="1"></asp:TextBox>
                                                             
                                                            <asp:ImageButton ID="ImgProExpDtlsAdd" runat="server" ImageUrl="~/Images/Icon/Gridadd.png" TabIndex="1"
                                                                ToolTip="Add Grid" ValidationGroup="AddGrid" OnClick="ImgProExpDtlsAdd_Click" />
                                                       
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td colspan="4">
                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                <ContentTemplate>
                                                                    <table width="100%" cellspacing="10">
                                                                        <tr>
                                                                            <td>
                                                                                <div style="overflow: scroll; width: 600px;">
                                                                                    <asp:GridView ID="GrdProExpDtls" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                                                        BorderStyle="None" BorderWidth="1px" CssClass="mGrid" Font-Bold="False" ForeColor="Black"
                                                                                        TabIndex="1" GridLines="Horizontal" OnRowCommand="GrdProExpDtls_RowCommand" OnRowDeleting="GrdProExpDtls_RowDeleting" >
                                                                                      <%-- --%>
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="#" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="LblEntryId" runat="server" Text='<% #Eval("#") %>' />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:ImageButton ID="ImageGridEdit" runat="server" CausesValidation="false" CommandArgument="<%#((GridViewRow)Container).RowIndex %>"
                                                                                                        CommandName="SelectGrid" ImageUrl="~/Images/Icon/GridEdit.png" ToolTip="Edit"  TabIndex="1"/>
                                                                                                    <asp:ImageButton ID="ImageBtnDelete" runat="server" CommandArgument='<%#Eval("#") %>'
                                                                                                        CommandName="Delete" ImageUrl="~/Images/Icon/GridDelete.png" ToolTip="Delete"  TabIndex="1"/>
                                                                                                    <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete This Record?"
                                                                                                        TargetControlID="ImageBtnDelete">
                                                                                                    </ajax:ConfirmButtonExtender>
                                                                                                </ItemTemplate>
                                                                                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                <HeaderStyle Wrap="false" />
                                                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="ExpenseHdId" HeaderText="ExpenseHdId">
                                                                                                <HeaderStyle CssClass="Display_None" />
                                                                                                <ItemStyle CssClass="Display_None" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField HeaderText="Expense" DataField="Expense">
                                                                                                <HeaderStyle Wrap="false" HorizontalAlign="Left" />
                                                                                                <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField HeaderText="Amount" DataField="Amount">
                                                                                                <HeaderStyle Wrap="false"  HorizontalAlign="Left"/>
                                                                                                <ItemStyle Wrap="false"  HorizontalAlign="Left"/>
                                                                                            </asp:BoundField>                                                                                                                                                                           
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr id="TrGrid" runat="server" visible="false">
                    <td>
                        <div class="scrollableDiv">
                        </div>
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
                                                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="button" ValidationGroup="Add"
                                                        TabIndex="1" OnClick="BtnUpdate_Click" OnClientClick="UpdateEquipFunction();" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" ValidationGroup="Add"
                                                        TabIndex="1" OnClick="BtnSave_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="button" ValidationGroup="Add"
                                                        OnClientClick="DeleteEquipFunction();" TabIndex="1" OnClick="BtnDelete_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="False"
                                                        TabIndex="1" OnClick="BtnCancel_Click" />
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
    Property List
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Report" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <ul id="subnav">
                <%--Ul Li Problem Solved repeater--%>
                <asp:Repeater ID="GrdReport" runat="server" OnItemCommand="GrdReport_ItemCommand">
                    <ItemTemplate>
                        <li id="Menuitem" runat="server">
                            <asp:LinkButton ID="lbtn_List" CssClass="linkButton" CausesValidation="false" CommandName="Select"
                                CommandArgument='<%# Eval("#") %>' runat="server" Text='<%# Eval("Property") %>'
                                TabIndex="6"></asp:LinkButton>
                            <asp:Label ID="lblUsedCnt" runat="server" Visible="false" Text='<%# Eval("UsedCount") %>'></asp:Label>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
