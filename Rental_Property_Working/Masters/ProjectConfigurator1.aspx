<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="ProjectConfigurator1.aspx.cs" Inherits="Masters_ProjectConfigurator1"
    Title="Property Rent Card" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <input type="hidden" id="hiddenbox" runat="server" value="" />
    <input type="hidden" id="endreq" value="0" />
    <input type="hidden" id="bodyy" value="0" />
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--Search for Project :
            <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                Width="292px" AutoPostBack="True" TabIndex="137"></asp:TextBox>           
            <div id="divwidth">
            </div>
            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtSearch"
                CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
            </ajax:AutoCompleteExtender>--%>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script language="javascript" type="text/javascript">

        function DeSelectAllOnInnerCheckBox() {
            var cell;
            var Count = 0;
            var grid = document.getElementById("<%= GridDetails.ClientID %>");
            if (grid.rows.length > 0) {
                for (i = 1; i < grid.rows.length; i++) {
                    cell = grid.rows[i].cells[1];
                    if (cell.children[0].children[0].type == "checkbox") {
                        if (cell.children[0].children[0].checked == true) {
                            Count += 1;
                        }
                    }
                }

                cell = grid.rows[0].cells[1];

                if (cell.children[0].children[0].type == "checkbox") {
                    if (Count == grid.rows.length - 1) {
                        if (cell.children[0].children[0].checked == false) {
                            cell.children[0].children[0].checked = true;
                        }
                    }
                    else {
                        if (cell.children[0].children[0].checked == true) {
                            cell.children[0].children[0].checked = false;
                        }
                    }
                }
            }
        }

        function SelectAll(chkbox) {

            var grid = document.getElementById("<%= GridDetails.ClientID %>");
            var cell;

            if (grid.rows.length > 0) {
                if (chkbox.checked == true) {

                    for (i = 1; i < grid.rows.length; i++) {

                        cell = grid.rows[i].cells[1];


                        if (cell.children[0].children[0].type == "checkbox") {
                            cell.children[0].children[0].checked = true;
                        }
                    }
                }
                else {
                    for (i = 1; i < grid.rows.length; i++) {
                        cell = grid.rows[i].cells[0];
                        if (cell.children[0].children[0].type == "checkbox") {
                            cell.children[0].children[0].checked = false;
                        }
                    }
                }
            }
        }
    </script>

    <script type="text/javascript" language="javascript">
        function OnContactSelected(source, eventArgs) {
            var hdnValueID = "<%= hdnValue.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
          
        }
    </script>

    <script language="javascript" type="text/javascript">

        function CalculateAmtAsPerGrid(objGrid) {
             console.log("Hii");
           
            var _GRDGridDetails = document.getElementById("<%= GridDetails.ClientID %>");                    
            var rowIndex = objGrid.offsetParent.parentNode.rowIndex;
            var RentAmt = (_GRDGridDetails.rows[rowIndex].cells[7].childNodes.item(1).value);//11
         console.log("HiiRent",RentAmt);
            
            var GSTPer = (_GRDGridDetails.rows[rowIndex].cells[18].childNodes.item(1).value);//14
             console.log("HiiGst",GSTPer);
            var GSTAmt = (_GRDGridDetails.rows[rowIndex].cells[19].childNodes.item(1).value);//15

            var total = 0;

            if (RentAmt.value == "" || isNaN(RentAmt.value)) {
                RentAmt.value = 0;
            }
            if (GSTPer.value == "" || isNaN(GSTPer.value)) {
                GSTPer.value = 0;
            }
            if (GSTAmt.value == "" || isNaN(GSTAmt.value)) {
                GSTAmt.value = 0;
            }
            total = parseFloat(parseFloat(RentAmt * GSTPer) / 100);
            _GRDGridDetails.rows[rowIndex].cells[19].childNodes.item(1).value = total.toFixed(2);//16
            
            for (var i = 1; i < _GRDGridDetails.rows.length; i++)
             {
                               _GRDGridDetails.rows[rowIndex].cells[20].childNodes.item(1).value = (parseFloat(RentAmt) + parseFloat(_GRDGridDetails.rows[i].cells[19].childNodes.item(1).value));
                            }
            // parseFloat(RentAmt.value) + parseFloat(_GRDGridDetails.rows[rowIndex].cells[18].childNodes.item(1).value) ;
                  
//             for (var i = 1; i < _GRDGridDetails.rows.length; i++) {
//                total = (parseFloat(total) + parseFloat(_GRDGridDetails.rows[i].cells[18].childNodes.item(1).value));//16
//            }
        }           
    </script>

    <script language="javascript" type="text/javascript">

        function ValidateContractor(objGrid) {
            var GrDetails = document.getElementById('<%= GridDetails.ClientID%>');
           
            var rowIndex = objGrid.offsetParent.parentNode.rowIndex;
            for (var i = 1; i < GrDetails.rows.length; i++) {
                if (i != rowIndex)
                 {
                    //alert(GrDetails.rows[i].cells[4].children[0].value);
                    if (GrDetails.rows[i].cells[4].children[0].value == GrDetails.rows[rowIndex].cells[4].children[0].value)
                    {
                   
                    if (GrDetails.rows[i].cells[5].children[0].value == GrDetails.rows[rowIndex].cells[5].children[0].value)
                    {
                        if (GrDetails.rows[i].cells[6].children[0].value == GrDetails.rows[rowIndex].cells[6].children[0].value) 
                        {
                            if (GrDetails.rows[rowIndex].cells[6].children[0].value != 0) 
                            {
                                alert("From Date and To date are already exist");
                                GrDetails.rows[rowIndex].cells[6].children[0].value = 0;
                                break;
                            }
                        }
                    }
                    }
                }
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    Property Rent Card
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <asp:UpdatePanel ID="AjaxPanelUpdateEntry" runat="server">
        <ContentTemplate>
            <table style="width: 100%">
                <tr>
                    <td align="center">
                        <%--    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DynamicLayout="false" DisplayAfter="0">
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
                        </asp:UpdateProgress>--%>
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
                                        PC NO. :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtPCNo" runat="server" CssClass="TextBoxReadOnly" TabIndex="1"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                    <td class="Label">
                                        Property Name :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProjectName" runat="server" Width="250px" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlProjectName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqProjectName" runat="server" ControlToValidate="ddlProjectName"
                                            Display="None" ErrorMessage="Project Name Is Required" SetFocusOnError="True"
                                            ValidationGroup="Add">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="VCEProjectName" runat="server" Enabled="True"
                                            TargetControlID="ReqProjectName" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                        <%--<asp:TextBox ID="txtProjectName" runat="server" CssClass="TextBox" MaxLength="50"
                                            Width="250px" TabIndex="1" AutoComplete="off"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqProjectName" runat="server" ControlToValidate="txtProjectName"
                                            Display="None" ErrorMessage="Project Name Is Required" SetFocusOnError="True"
                                            ValidationGroup="Add">

                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="VCEProjectName" runat="server" Enabled="True"
                                            TargetControlID="ReqProjectName" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Unit No :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUnitNo" runat="server" Width="250px" CssClass="TextBox" Font-Names="Verdana"
                                            OnTextChanged="txtUnitNo_TextChanged" AutoPostBack="true" TabIndex="1"></asp:TextBox>
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
                                    <td class="Display_None">
                                        Unit Type :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlUnit" runat="server" Width="200px" CssClass="Display_None"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" TabIndex="1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Unit Area :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUintArea" runat="server" Width="250px" CssClass="TextBox" Font-Names="Verdana"
                                            TabIndex="1"></asp:TextBox>
                                    </td>
                                    <td class="Label">
                                        Party Name:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPartyName" runat="server" Width="250px" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFVParty" runat="server" ControlToValidate="ddlPartyName"
                                            Display="None" ErrorMessage="Project Name Is Required" SetFocusOnError="True"
                                            ValidationGroup="Add">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                            TargetControlID="RFVParty" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Display_None">
                                        Project Address :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtAddress" runat="server" Width="730px" CssClass="Display_None"
                                            TextMode="MultiLine" Font-Names="Verdana" TabIndex="1"></asp:TextBox>
                                    </td>
                                    <td class="Display_None">
                                        Rent
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRent" runat="server" Width="250px" CssClass="Display_None" Font-Names="Verdana"
                                            TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:UpdatePanel ID="GrdUp" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div style="width: 900px; height: auto; padding: 2px; overflow: scroll; min-height: 100px;">
                                                    <asp:GridView ID="GridDetails" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                        OnRowDataBound="GridDetails_RowDataBound" OnRowDeleting="GridDetails_RowDeleting"
                                                        TabIndex="1">
                                                        <Columns>
                                                            <%-- 0--%>
                                                            <asp:BoundField DataField="#">
                                                                <HeaderStyle CssClass="Display_None" />
                                                                <ItemStyle CssClass="Display_None" />
                                                                <FooterStyle CssClass="Display_None" />
                                                            </asp:BoundField>
                                                            <%-- 1--%>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="GrdSelectAllHeader" runat="server" AutoPostBack="true" CssClass="mycheckBig"
                                                                        onclick="SelectAll(this);" TabIndex="1" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="ChkAllocate" runat="server" TabIndex="1" CssClass="mycheckBig"
                                                                        onclick="DeSelectAllOnInnerCheckBox();" Checked='<%# Convert.ToBoolean(Eval("CHK").ToString()) %>' />
                                                                </ItemTemplate>
                                                                <%--  <HeaderStyle CssClass="Display_None" />
                                                                <ItemStyle CssClass="Display_None" />
                                                                <FooterStyle CssClass="Display_None" />--%>
                                                            </asp:TemplateField>
                                                            <%--2--%>
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgEditLogo" runat="server" CausesValidation="false" CommandArgument="<%#((GridViewRow)Container).RowIndex %>"
                                                                        CommandName="Select" ImageUrl="~/Images/Icon/GridEdit.png" ToolTip="Edit" TabIndex="1"
                                                                        CssClass="Display_None" />
                                                                    <asp:ImageButton ID="ImgDeleteLogo" runat="server" CommandArgument="<%#((GridViewRow)Container).RowIndex %>"
                                                                        CommandName="Delete" ImageUrl="~/Images/Icon/GridDelete.png" ToolTip="Delete"
                                                                        TabIndex="1" />
                                                                    <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete This Record?"
                                                                        TargetControlID="ImgDeleteLogo">
                                                                    </ajax:ConfirmButtonExtender>
                                                                    <asp:Label ID="LblEntryId" runat="server" Text='<%# Eval("#") %>' Width="30px" Visible="false"></asp:Label>
                                                                    <asp:ImageButton ID="ImgAddRrow" runat="server" CssClass="Imagebutton" Height="16px"
                                                                        OnClick="ImgAddRrow_Click" ImageUrl="~/Images/Icon/Gridadd.png" OnClientClick=""
                                                                        TabIndex="1" ToolTip="Add Grid" ValidationGroup="Add" Width="16px" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" Width="60px" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" Width="60px" />
                                                            </asp:TemplateField>
                                                            <%--3--%>
                                                            <asp:TemplateField HeaderText="Sr. No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LblSrNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Width="80px" />
                                                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Font-Bold="true"
                                                                    ForeColor="White" />
                                                            </asp:TemplateField>
                                                            <%--4--%>
                                                            <asp:TemplateField HeaderText="FromDate">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtFromDate" runat="server" Text='<%# Eval("FromDate") %>' TabIndex="1"
                                                                        Width="100px" AutoPostBack="true"></asp:TextBox>
                                                                    <ajax:CalendarExtender ID="CE1" runat="server" Format="dd-MMM-yyyy" PopupButtonID="txtFromDate"
                                                                        TargetControlID="txtFromDate" CssClass="" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <%-- 5--%>
                                                            <asp:TemplateField HeaderText="ToDate">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtToDate" runat="server" Text='<%# Eval("ToDate") %>' TabIndex="1"
                                                                        Width="100px" AutoPostBack="true"></asp:TextBox>
                                                                    <ajax:CalendarExtender ID="CE2" runat="server" Format="dd-MMM-yyyy" PopupButtonID="txtToDate"
                                                                        TargetControlID="txtToDate" CssClass="" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <%-- 6--%>
                                                            <asp:TemplateField HeaderText="Company">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="GrdddlCompany" runat="server" Width="150px" TabIndex="1" OnSelectedIndexChanged="GrdddlCompany_SelectedIndexChanged"
                                                                        AutoPostBack="true" onchange="ValidateContractor(this);">
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="LblGrdddlCompany" runat="server" Text='<%# Eval("CompanyId") %>' CssClass="Display_None"
                                                                        TabIndex="1"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                            <%-- 7--%>
                                                            <asp:TemplateField HeaderText="Rental Amt" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <%-- <asp:TextBox ID="txtRentalAmt" runat="server" Text='<%# Eval("RentalAmt") %>' CssClass="TextBoxNumeric"
                                                                        Width="100px" Height="20px" TabIndex="1" MaxLength="10" onkeyup="CalculateAmtAsPerGrid(this);"></asp:TextBox>
                                                                    <ajax:FilteredTextBoxExtender ID="f1" runat="server" FilterType="Numbers, Custom"
                                                                        ValidChars="." TargetControlID="txtRentalAmt" />--%>
                                                                    <asp:TextBox ID="txtRentalAmt" runat="server" CssClass="TextBoxNumeric" onkeyup="CalculateAmtAsPerGrid(this);"
                                                                        MaxLength="15" Text='<%# Bind("RentalAmt") %>' TextMode="SingleLine" Width="60px"></asp:TextBox>
                                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtenderrate" runat="server" FilterType="Numbers, Custom"
                                                                        ValidChars="." TargetControlID="txtRentalAmt" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <%-- 8--%>
                                                            <asp:TemplateField HeaderText="To Be Collected on">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtCollectedDate" runat="server" Text='<%# Eval("CollectedDate") %>'
                                                                        TabIndex="1" Width="100px" AutoPostBack="true"></asp:TextBox>
                                                                    <ajax:CalendarExtender ID="CE4" runat="server" Format="dd-MMM-yyyy" PopupButtonID="txtCollectedDate"
                                                                        TargetControlID="txtCollectedDate" CssClass="" />
                                                                </ItemTemplate>
                                                              <HeaderStyle CssClass="Display_None" />
                                                                <ItemStyle CssClass="Display_None" />
                                                            </asp:TemplateField>
                                                            <%-- 9--%>
                                                            <asp:TemplateField HeaderText="Deposit Amt" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtDepositAmt" runat="server" Text='<%# Eval("DepositAmt") %>' CssClass="TextBoxNumeric"
                                                                        Width="100px" Height="20px" TabIndex="1" MaxLength="10"></asp:TextBox>
                                                                    <ajax:FilteredTextBoxExtender ID="FBB" runat="server" FilterType="Numbers, Custom"
                                                                        ValidChars="." TargetControlID="txtDepositAmt" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <%-- 10--%>
                                                            <asp:TemplateField HeaderText="PropertyTaxAmt" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPropertyTaxAmt" runat="server" Text='<%# Eval("PropertyTaxAmt") %>'
                                                                        CssClass="TextBoxNumeric" Width="100px" Height="20px" TabIndex="1" MaxLength="10"></asp:TextBox>
                                                                    <ajax:FilteredTextBoxExtender ID="f2" runat="server" FilterType="Numbers, Custom"
                                                                        ValidChars="." TargetControlID="txtPropertyTaxAmt" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <%-- 11--%>
                                                            <asp:TemplateField HeaderText="SocietyMaintenaceAmt" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtSocietyMaintenaceAmt" runat="server" Text='<%# Eval("SocietyMaintenaceAmt") %>'
                                                                        CssClass="TextBoxNumeric" Width="100px" Height="20px" TabIndex="1" MaxLength="10"></asp:TextBox>
                                                                    <ajax:FilteredTextBoxExtender ID="f3" runat="server" FilterType="Numbers, Custom"
                                                                        ValidChars="." TargetControlID="txtSocietyMaintenaceAmt" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <%-- 12--%>
                                                            <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRemark" runat="server" Text='<%# Eval("Remark") %>' CssClass="TextBox"
                                                                        TextMode="MultiLine" Height="20px" Width="180px" TabIndex="1"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
                                                            </asp:TemplateField>
                                                            <%-- 13--%>
                                                            <asp:BoundField DataField="Status" HeaderText="Status">
                                                                <HeaderStyle CssClass="Display_None" />
                                                                <ItemStyle CssClass="Display_None" />
                                                            </asp:BoundField>
                                                            <%-- 14--%>
                                                            <asp:BoundField DataField="CompanyId" HeaderText="CompanyId">
                                                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" CssClass="Display_None" />
                                                                <HeaderStyle Width="10%" HorizontalAlign="Right" CssClass="Display_None" />
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="10%" CssClass="Display_None" />
                                                            </asp:BoundField>
                                                            <%-- 15--%>
                                                            <asp:BoundField DataField="ProRentDtlsId" HeaderText="ProRentDtlsId">
                                                                <HeaderStyle CssClass="Display_None" />
                                                                <ItemStyle CssClass="Display_None" />
                                                            </asp:BoundField>
                                                            <%-- 16--%>
                                                            <asp:BoundField DataField="FlagReceiptType" HeaderText="FlagReceiptType">
                                                                <HeaderStyle CssClass="Display_None" />
                                                                <ItemStyle CssClass="Display_None" />
                                                            </asp:BoundField>
                                                            <%--  17 --%>
                                                            <asp:TemplateField HeaderText="GST %">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="GrdddlGSTPer" runat="server" Width="150px" TabIndex="1" OnSelectedIndexChanged="GrdddlGSTPer_SelectedIndexChanged"
                                                                        AutoPostBack="true" onchange="ValidateContractor(this);">
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="LblGrdddlGSTPer" runat="server" Text='<%# Eval("TaxTemplateID") %>'
                                                                        CssClass="Display_None" TabIndex="1"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <%-- <ItemTemplate>
                                                                    <asp:TextBox ID="GSTPerDetails" runat="server" Text='<%# Eval("GSTPerDetails") %>'
                                                                        Width="100px"></asp:TextBox>
                                                                </ItemTemplate>--%>
                                                            </asp:TemplateField>
                                                            
                                                               <%--  18 --%>
                                                            <asp:TemplateField HeaderText="GST %">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="GSTPerDetails" runat="server" Text='<%# Eval("GSTPerDetails") %>'
                                                                        Width="100px"  onchange="CalculateAmtAsPerGrid(this);"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-- 19--%>
                                                            <asp:TemplateField HeaderText="GSTAmt">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="CGSTAmt" runat="server" Text='<%# Eval("GSTAmt") %>' Width="100px"
                                                                        Enabled="false" CssClass="TextBoxGrid"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <%--  <HeaderStyle CssClass="Display_None" Wrap="False" />
                                                                <ItemStyle CssClass="Display_None" Wrap="False" />
                                                                
                                                                 onkeyup="CalculateAmtAsPerGrid(this);" --%>
                                                            </asp:TemplateField>
                                                            <%-- 19--%>
                                                            <asp:TemplateField HeaderText="Amount">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="TotalAmount" runat="server" Text='<%# Eval("Amount") %>' Width="100px"
                                                                        Enabled="false" CssClass="TextBoxGrid"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <%--  <HeaderStyle CssClass="Display_None" Wrap="False" />
                                                                <ItemStyle CssClass="Display_None" Wrap="False" />--%>
                                                            </asp:TemplateField>
                                                            <%-- 16--%>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgAddRrowButton" runat="server" CssClass="Display_None" Height="16px"
                                                                        ImageUrl="~/Images/Icon/Gridadd.png" OnClientClick="" TabIndex="1" ToolTip="Add Grid"
                                                                        OnClick="ImgAddRrowButton_Click" ValidationGroup="Add" Width="17px" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
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
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" ValidationGroup="Add"
                                                        OnClick="BtnSave_Click" TabIndex="1" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="button" ValidationGroup="Add"
                                                        TabIndex="1" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="False"
                                                        OnClick="BtnCancel_Click" TabIndex="1" />
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
                            Property Rent Card List
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
                                                    Width="350px" AutoPostBack="True" TabIndex="1" OnTextChanged="TxtSearch_TextChanged"></asp:TextBox>
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
                                                    Width="100%" TabIndex="1" OnRowCommand="GrdReport_RowCommand" OnRowDeleting="GrdReport_RowDeleting"
                                                    OnPageIndexChanging="GrdReport_PageIndexChanging">
                                                    <%--  OnDataBound="GrdReport_DataBound" OnRowDataBound="GrdReport_RowDataBound" --%>
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
                                                        <asp:BoundField DataField="PCNo" HeaderText="PC No">
                                                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PropertyName" HeaderText="Property Name">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FlatType" HeaderText="Unit Type">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UnitNo" HeaderText="Unit No">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <%-- <asp:BoundField DataField="Rent" HeaderText="Rent">
                                                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>--%>
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
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
