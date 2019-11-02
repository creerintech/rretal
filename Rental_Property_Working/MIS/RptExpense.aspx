<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="RptExpense.aspx.cs" Inherits="MIS_RptExpense" Title="List Of Expense" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" Runat="Server">
<ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" Runat="Server">
 List Of Expense
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
<asp:Content ID="Content3" ContentPlaceHolderID="Body" Runat="Server">
<asp:UpdatePanel ID="UPEntry" runat="server">
        <ContentTemplate>
            <fieldset id="F1" runat="server" class="FieldSet">
                <table width="100%" cellspacing="5">
                    <tr>
                        <td class="Label">
                            <asp:CheckBox ID="ChkFrmDate" runat="server" AutoPostBack="True" CssClass="CheckBox"
                                Text=" From Date :" OnCheckedChanged="ChkFrmDate_CheckedChanged" TabIndex="1" />&nbsp;
                        </td>
                        <td align="left" class="Label1">
                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="TextBox" Width="80px" TabIndex="2"></asp:TextBox>
                            <ajax:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender3" runat="server"
                                Enabled="True" Format="dd-MMM-yyyy" PopupButtonID="ImageButton212" TargetControlID="txtFromDate" />
                            <asp:ImageButton ID="ImageButton212" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                ImageUrl="~/Images/Icon/DateSelector.png" TabIndex="3" />
                            To Date :
                            <asp:TextBox ID="txtToDate" runat="server" CssClass="TextBox" Width="80px" TabIndex="4"></asp:TextBox>
                            <ajax:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender1" runat="server"
                                Enabled="True" Format="dd-MMM-yyyy" PopupButtonID="ImageButton1" TargetControlID="txtToDate" />
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                ImageUrl="~/Images/Icon/DateSelector.png" TabIndex="5" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Label">
                            Expense :
                        </td>
                        <td align="left" class="Label1">
                            <asp:DropDownList ID="ddlExpense" runat="server" CssClass="ComboBox" AutoPostBack="True"
                                Width="250px" TabIndex="6">
                            </asp:DropDownList>
                        </td>
                        <td class="Label">
                         
                        </td>
                        <td>
                          
                        </td>
                    </tr>
                   
                    <tr>
                        <td align="center" colspan="5">
                            <asp:Button ID="BtnShow" runat="server" CssClass="button" TabIndex="11" Text="Show"
                                ToolTip="Show Details" ValidationGroup="Add" OnClick="BtnShow_Click" />
                            <%----%>
                            <asp:Button ID="BtnCancel" runat="server" CssClass="button" TabIndex="12" Text="Cancel"
                                oolTip="Clear The Details" OnClick="BtnCancel_Click" />
                            <%--   --%>
                        </td>
                    </tr>                   
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblCount" runat="server" CssClass="SubTitle"></asp:Label>
                        </td>
                        <td colspan="4" align="right">
                            <asp:ImageButton ID="ImgBtnPrint" runat="server" OnClientClick="javascript:CallPrint('divPrint')"
                                ImageUrl="~/Images/Icon/Print-Icon.png" ToolTip="Print Report" Height="35px"
                                TabIndex="13" />
                            <asp:ImageButton ID="ImgBtnExport" runat="server" ImageUrl="~/Images/Icon/excel-icon.png"
                                ToolTip="Export To Excel" OnClick="ImgBtnExport_Click" Height="35px" TabIndex="14" />
                            <asp:ImageButton ID="ImgPDF" runat="server" ImageUrl="~/Images/Icon/PDF.jpg" ToolTip="PDF"
                                Height="35px" Width="35px"  TabIndex="15" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <asp:GridView ID="GridExpenseList" runat="server" AutoGenerateColumns="False" Width="100%"
                                CssClass="mGrid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                CellPadding="4" ForeColor="Black" AllowPaging="false" PageSize="50" ShowFooter="True"
                                TabIndex="12">
                                <%--   OnPageIndexChanging="GridEnquiry_PageIndexChanging" OnRowDataBound="GridEnquiry_RowDataBound"--%>
                                <Columns>                                  
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSrNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle Wrap="True" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ExpRegNo" HeaderText="Expense No">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ExpenceRegDate" HeaderText="Expense Date">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Font-Bold="true"
                                            ForeColor="White" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="#" HeaderText="ExpenseHdId">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Expense" HeaderText="Expense">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Amount" HeaderText="Amount">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Font-Bold="true"
                                            ForeColor="White" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Remark" HeaderText="Remark">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Font-Bold="true"
                                            ForeColor="White" />
                                    </asp:BoundField>                                    
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                                <FooterStyle CssClass="ftr" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ImgBtnExport" />
            <asp:PostBackTrigger ControlID="ImgPDF" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

