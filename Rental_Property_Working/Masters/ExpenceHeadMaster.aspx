<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="ExpenceHeadMaster.aspx.cs" Inherits="Masters_ExpenceHeadMaster" Title="Expence Head Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />

    <script language="javascript" type="text/javascript">
        function CalculateAlloQtyAmt(objGrid)
         {
            var _GridDetails = document.getElementById('<%= GrdExpencesDetails.ClientID %>');           
            var rowIndex = objGrid.offsetParent.parentNode.rowIndex;
            var Rate = _GridDetails.rows[rowIndex].cells[4].children[0];          
          
            var AlloteQty = _GridDetails.rows[rowIndex].cells[3].children[0];                    
            var AllotAmt = _GridDetails.rows[rowIndex].cells[5].children[0];
            var sum = 0;
          
            
                 AllotAmt.value = parseFloat(Rate.value) * parseFloat(AlloteQty.value).toFixed(2);
                
            _GridDetails.rows[rowIndex].cells[5].children[0].value = parseFloat(AllotAmt.value).toFixed(2);
       
        
        }    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    Expence Head
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
                                        Expence NO :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtEHNo" runat="server" CssClass="TextBoxReadOnly" TabIndex="1"
                                            Width="200px"></asp:TextBox>
                                    </td>
                                    <td class="Label">
                                        Date :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="TextBox" Width="115px" TabIndex="3"></asp:TextBox>
                                        <asp:ImageButton ID="ImageFromDate" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                            ImageUrl="~/Images/Icon/DateSelector.png" TabIndex="4" />
                                        <ajax:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                            PopupButtonID="ImageFromDate" TargetControlID="txtFromDate" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Display_None">
                                        Property Name :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProjectName" runat="server" Width="200px" AutoPostBack="true" CssClass="Display_None">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqProjectName" runat="server" ControlToValidate="ddlProjectName"
                                            Display="None" ErrorMessage="Project Name Is Required" SetFocusOnError="True"
                                            ValidationGroup="Add">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="VCEProjectName" runat="server" Enabled="True"
                                            TargetControlID="ReqProjectName" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                    <td class="Label">
                                    </td>
                                    <td align="left">
                                    </td>
                                </tr>
                            </table>
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <div style="overflow: scroll; width: 840px">
                                            <asp:GridView ID="GrdExpencesDetails" runat="server" AutoGenerateColumns="False" OnRowDataBound="GrdExpencesDetails_RowDataBound"
                                                OnRowDeleting="GrdExpencesDetails_RowDeleting" CaptionAlign="Top" CssClass="mGrid"
                                                DataKeyNames="#" TabIndex="1" Width="95%" ShowFooter="true">
                                                <Columns>
                                                    <%--0--%>
                                                    <asp:BoundField DataField="#">
                                                        <HeaderStyle CssClass="Display_None" />
                                                        <ItemStyle CssClass="Display_None" />
                                                        <FooterStyle CssClass="Display_None" />
                                                    </asp:BoundField>
                                                    <%--1--%>
                                                    <asp:TemplateField HeaderStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgSelectBtn" runat="server" ImageUrl="~/Images/New Icon/ViewRecord.png"
                                                                CommandName="GetRecord" ToolTip="Assingn Qty For Tower Unit " RowIndex='<%# Container.DisplayIndex %>'
                                                                CssClass="Display_None" />
                                                            <asp:ImageButton ID="ImgAddRrow" runat="server" CssClass="Imagebutton" OnClick="ImgAddRrow_Click"
                                                                Height="15px" ImageUrl="~/Images/Icon/Gridadd.png" TabIndex="1" ToolTip="Add New Row"
                                                                ValidationGroup="Add" />
                                                            <asp:ImageButton ID="ImgDeleteLogo" runat="server" CommandArgument="<%#((GridViewRow)Container).RowIndex %>"
                                                                CommandName="Delete" ImageUrl="~/Images/Icon/GridDelete.png" ToolTip="Delete"
                                                                TabIndex="1" />
                                                            <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete This Record?"
                                                                TargetControlID="ImgDeleteLogo">
                                                            </ajax:ConfirmButtonExtender>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                                                    </asp:TemplateField>
                                                    <%--2--%>
                                                    <asp:TemplateField HeaderText="Particular" HeaderStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtParticular" runat="server" Text='<%# Bind("Particular")%>' Width="150px"
                                                                TabIndex="1" CssClass="TextBox">
                                                            </asp:TextBox>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <%--3--%>
                                                    <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="150px">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" Text='<%# Bind("Qty") %>' Width="150px" TabIndex="1"
                                                                onkeyup="CalculateAlloQtyAmt(this);" CssClass="TextBox">
                                                            </asp:TextBox>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <%--4--%>
                                                    <asp:TemplateField HeaderText="Rate" HeaderStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtRate" runat="server" Text='<%# Eval("Rate") %>' Width="100px"
                                                                onkeyup="CalculateAlloQtyAmt(this);" TabIndex="8" CssClass="TextBoxNumeric">
                                                            </asp:TextBox>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"  ForeColor="White" />
                                                        <HeaderStyle Width="10%" HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="10%" />
                                                    </asp:TemplateField>
                                                    <%--5--%>
                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtAmount" runat="server" Text='<%# Bind("Amount") %>' Width="100px"
                                                                TabIndex="1" CssClass="TextBoxNumeric" onkeyup="CalculateAlloQtyAmt(this);">
                                                            </asp:TextBox>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"  ForeColor="White" />
                                                        <HeaderStyle Width="10%" HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="10%" />
                                                    </asp:TemplateField>
                                                    <%--6--%>
                                                    <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtRemark" runat="server" Text='<%# Bind("Remark") %>' Width="150px"
                                                                TabIndex="1" CssClass="TextBox" TextMode="MultiLine">
                                                            </asp:TextBox>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                        <HeaderStyle Width="10%" HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="10%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="pgr" />
                                                <FooterStyle CssClass="ftr" />
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
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" ValidationGroup="Add"
                                                        TabIndex="1" OnClick="BtnSave_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="button" ValidationGroup="Add"
                                                        TabIndex="1" />
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
                            Expences List
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
                                                        <asp:BoundField DataField="ExpenceNo" HeaderText="Expence No">
                                                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ExpenceDate" HeaderText="Expence Date">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Property" HeaderText="Property Name">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Display_None" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
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
