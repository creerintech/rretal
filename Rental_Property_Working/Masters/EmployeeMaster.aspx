<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage_RN.master" AutoEventWireup="true"
    CodeFile="EmployeeMaster.aspx.cs" Inherits="Masters_EmployeeMaster" Title="Employee Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <input type="hidden" id="hiddenbox" runat="server" value="" />

    <script type="text/javascript" language="javascript">

    function UpdateEquipFunction() {

        var value = document.getElementById('<%=txtEmpName.ClientID%>').value;

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

        var value = document.getElementById('<%=txtEmpName.ClientID%>').value;

        if (value == "") {
            document.getElementById('<%= hiddenbox.ClientID%>').value = "1";
        }
        else {
            if (confirm("Would You like To Delete The Record ?") == true) {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "0";
                return false;
            }
            else {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "100";

            }
        }
    }
    </script>

    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Search for Employee :
            <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                Width="292px" AutoPostBack="True" OnTextChanged="TxtSearch_TextChanged" TabIndex="19">
            </asp:TextBox>
            <div id="divwidth">
            </div>
            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtSearch"
                CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
            </ajax:AutoCompleteExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    Employee Master
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <asp:UpdatePanel ID="AjaxPanelUpdateEntry" runat="server">
        <ContentTemplate>
            <table style="width: 100%">
                <tr>
                    <td align="center">
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                            <ProgressTemplate>
                                <div id="progressBackgroundFilter">
                                </div>
                                <div id="processMessage">
                                    <center>
                                        <span class="SubTitle">Loading....!!! </span>
                                    </center>
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icon/updateprogress.gif" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>
                        <fieldset id="fieldset" runat="server" class="FieldSet">
                            <table width="100%" cellspacing="6">
                                <tr>
                                    <td colspan="4"> <asp:HiddenField ID="hdnFldUsedCnt" runat="server" />
                                                <asp:HiddenField ID="hdnFldId" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Code :
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtEmpCode" runat="server" CssClass="TextBox" MaxLength="15" Width="439px"
                                            TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Name :
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtEmpName" runat="server" CssClass="TextBox" Width="439px" TabIndex="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req_Name" runat="server" ControlToValidate="txtEmpName"
                                            Display="None" ErrorMessage=" Name is  Required" SetFocusOnError="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="VCE_Name" runat="server" Enabled="True" TargetControlID="Req_Name"
                                            WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Address :
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TxtAddress" runat="server" CssClass="TextBox" TextMode="MultiLine"
                                            Width="439px" TabIndex="3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Tel(1) :
                                    </td>
                                    <td width=" 189px">
                                        <asp:TextBox ID="TxtTel1" runat="server" CssClass="TextBox" MaxLength="15" TabIndex="4"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
                                            TargetControlID="TxtTel1">
                                        </ajax:FilteredTextBoxExtender>
                                        <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="False"
                                            TargetControlID="TxtTel1">
                                        </ajax:TextBoxWatermarkExtender>
                                    </td>
                                    <td class="Label" width="12%">
                                        Tel(2) :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtTel2" runat="server" CssClass="TextBox" MaxLength="15" TabIndex="5"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom,Numbers"
                                            TargetControlID="TxtTel2">
                                        </ajax:FilteredTextBoxExtender>
                                        <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="False"
                                            TargetControlID="TxtTel2">
                                        </ajax:TextBoxWatermarkExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Mobile :
                                    </td>
                                    <td width=" 189px">
                                        <asp:TextBox ID="TxtMobile" runat="server" CssClass="TextBox" MaxLength="15" TabIndex="6"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                                            TargetControlID="TxtMobile">
                                        </ajax:FilteredTextBoxExtender>
                                        <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="False"
                                            TargetControlID="TxtMobile">
                                        </ajax:TextBoxWatermarkExtender>
                                    </td>
                                    <td class="Label">
                                        DOB :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDOB" runat="server" CssClass="TextBox" TabIndex="7"></asp:TextBox>
                                        <ajax:CalendarExtender         CssClass="cal_Theme1"     ID="CalDOB" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtDOB"
                                            PopupButtonID="Img_DOB" />
                                        <asp:ImageButton ID="Img_DOB" runat="server" ImageUrl="~/Images/Icon/DateSelector.png"
                                            CausesValidation="False" CssClass="Imagebutton" TabIndex="8" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Email :
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TxtEmail" runat="server" CssClass="TextBox" Width="439px" TabIndex="9"
                                            MaxLength="70"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="Reg" runat="server" ControlToValidate="TxtEmail" ValidationGroup="Add"
                                            Display="None" ErrorMessage="Enter valid email address!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                        </asp:RegularExpressionValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                            TargetControlID="Reg" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        City :
                                    </td>
                                    <td width=" 189px">
                                        <asp:TextBox ID="TxtCity" runat="server" CssClass="TextBox" TabIndex="10"></asp:TextBox>
                                    </td>
                                    <td class="Label">
                                        State :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtState" runat="server" CssClass="TextBox" TabIndex="11"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Pin Code :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtPinCode" runat="server" CssClass="TextBox" TabIndex="12"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers"
                                            TargetControlID="TxtPinCode">
                                        </ajax:FilteredTextBoxExtender>
                                    </td>
                                    <td class="Label" nowrap="nowrap">
                                        Employed On :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDOJ" runat="server" CssClass="TextBox" TabIndex="13"></asp:TextBox>
                                        <ajax:CalendarExtender   CssClass="cal_Theme1"     ID="Cal_DOJ" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtDOJ"
                                            PopupButtonID="Img_DOJ" />
                                        <asp:ImageButton ID="Img_DOJ" runat="server" ImageUrl="~/Images/Icon/DateSelector.png"
                                            CausesValidation="False" CssClass="Imagebutton" TabIndex="14" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Notes :
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TxtNotes" runat="server" CssClass="TextBox" TextMode="MultiLine"
                                            Width="439px" TabIndex="15"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
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
                                                        OnClientClick="UpdateEquipFunction();" OnClick="BtnUpdate_Click" TabIndex="16"/>
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" ValidationGroup="Add"
                                                        OnClick="BtnSave_Click" TabIndex="16"/>
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="button" ValidationGroup="Add"
                                                        OnClientClick="DeleteEquipFunction();" OnClick="BtnDelete_Click" TabIndex="17"/>
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="False"
                                                        OnClick="BtnCancel_Click" TabIndex="18"/>
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
    Employee List
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Report" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <ul id="subnav">
               <div class="scrollableDiv">
                <%--Ul Li Problem Solved repeater--%>
                <asp:Repeater ID="GrdReport" runat="server" OnItemCommand="GrdReport_ItemCommand">
                    <ItemTemplate>
                        <li id="Menuitem" runat="server">
                            <asp:LinkButton ID="lbtn_List" CssClass="linkButton" CausesValidation="false" TabIndex="20" CommandName="Select"
                                CommandArgument='<%# Eval("#") %>' runat="server" Text='<%# Eval("Name") %>'></asp:LinkButton>  <asp:Label ID="lblUsedCnt" runat="server" Visible="false" Text='<%# Eval("UsedCount") %>'></asp:Label>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>                
                </div>
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
