<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptRentToBeExpired.aspx.cs" Inherits="MIS_RptRentToBeExpired" Title=" Rent Expired Property" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    List Of  Rent Expired Property
    <asp:UpdatePanel ID="Upp" runat="server">
        <ContentTemplate>
            <table width="100%">
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
 <table width="100%">
    <tr>
        <td valign="top">
            <fieldset id="fieldset1" runat="server" class="FieldSet">
                <table>
                    <tr style="height: 50px">
                        <td colspan="6" align="center">
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Names="Verdana" Font-Size="12px"
                                Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="Label" style="width: 75px">
                            <asp:CheckBox ID="ChkDate" runat="server" CssClass="checkbox" Text=" " AutoPostBack="true" OnCheckedChanged="ChkDate_CheckedChanged" />
                        </td>
                        <td class="Label">
                            From :
                        </td>
                        <td>
                            <asp:TextBox ID="txtFromDate" runat="server" Width="115px" CssClass="TextBox" TabIndex="1"></asp:TextBox>
                            <asp:ImageButton ID="ImageFromDate" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                ImageUrl="~/Images/Icon/DateSelector.png" TabIndex="2" />
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                PopupButtonID="ImageFromDate" TargetControlID="txtFromDate" />
                        </td>
                        <td class="Label">
                            &nbsp; To :
                        </td>
                        <td>
                            <asp:TextBox ID="txtToDate" runat="server" Width="115px" CssClass="TextBox" TabIndex="4"></asp:TextBox>
                            <asp:ImageButton ID="ImageToDate" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                ImageUrl="~/Images/Icon/DateSelector.png" TabIndex="6" />
                            <ajax:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                PopupButtonID="ImageToDate" TargetControlID="txtToDate" />
                        </td>
                    </tr>                   
                    <tr style="height: 50px">
                        <td colspan="6" align="center">
                        </td>
                    </tr>
                </table>
                <fieldset id="FieldSet" class="FieldSet" runat="server">
                    <asp:UpdatePanel ID="UPpANLEsAVE" runat="server">
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <table width="35%">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="center">
                                                    <table align="center" width="35%">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnSearch" runat="server" CssClass="button" TabIndex="41" Text="Show"
                                                                    ValidationGroup="Add"  OnClick="btnSearch_Click" />
                                                                <%-- --%>
                                                            </td>
                                                             <td>
                                                                    <asp:Button ID="BtnPrint" runat="server" CssClass="button" TabIndex="42" Text="Print"
                                                                        ValidationGroup="Add" OnClientClick="aspnetForm.target ='_blank';" OnClick="BtnPrint_Click" />
                                                                </td>
                                                            <td>
                                                                <asp:Button ID="BtnExportDetail" runat="server" CssClass="button" TabIndex="43" Text="Export Detail"
                                                                    ValidationGroup="Add" Width="120px" OnClick="BtnExportDetail_Click"  />
                                                                <%----%>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="BtnCancel" runat="server" CssClass="button" TabIndex="43" Text="Cancel"
                                                                    ValidationGroup="Add" OnClick="btnCancel_Click" />
                                                                <%-- --%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="BtnExportDetail" />
                        </Triggers>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="BtnCancel" />
                        </Triggers>
                    </asp:UpdatePanel>
                </fieldset>
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel_GrdReport" runat="server">
                                <ContentTemplate>
                                    <a name="Navigate">
                                        <div style="overflow: scroll; width: 940px">
                                            <asp:GridView ID="GrdProjectReport" runat="server"  AlternatingRowStyle-CssClass="alt"
                                                AutoGenerateColumns="False" CssClass="mGrid" GridLines="None" PagerStyle-CssClass="pgr"
                                                Width="100%" AllowSorting="true">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Property Name" DataField="Property" SortExpression="Property">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--4--%>
                                                    <asp:BoundField HeaderText="PropertyId" DataField="PropertyId" SortExpression="PropertyId">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Display_None" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="PartyId" DataField="PartyId" SortExpression="PartyId">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Display_None" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="PartyName" DataField="PartyName" SortExpression="PartyName">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="CompanyId" DataField="CompanyId" SortExpression="CompanyId">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Display_None" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="CompanyName" DataField="CompanyName" SortExpression="CompanyName">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                       <asp:BoundField HeaderText="FromDate" DataField="FromDate" SortExpression="FromDate">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>  
                                                       <asp:BoundField HeaderText="ToDate" DataField="ToDate" SortExpression="ToDate">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>                                                     
                                                    <asp:BoundField HeaderText="CollectedDate" DataField="CollectedDate" SortExpression="CollectedDate">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>  
                                                                                                 
                                                    <asp:BoundField HeaderText="RentalAmt" DataField="RentalAmt" SortExpression="RentalAmt">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>   
                                                  <asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Status">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>                                                    
                                                </Columns>
                                                <PagerStyle CssClass="pgr" />
                                                <AlternatingRowStyle CssClass="alt" />
                                            </asp:GridView>
                                        </div>
                                    </a>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    </table>
</asp:Content>
