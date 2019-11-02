<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptListOfProperty.aspx.cs" Inherits="MIS_RptListOfProperty" Title="List Of Property" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />

    <script type="text/javascript" language="javascript">
        function OnSerchProjSelected(source, eventArgs) {

            var hdnValueID = "<%= hdvSerchProj.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
          
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    List Of Property Report
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
                        <tr align="center">
                            <td style="width: 100px">
                            </td>
                            <td class="Label" style="width: 100px">
                                Select Property:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtProperty" runat="server" TabIndex="1" Width="200px" placeholder="Enter Property Name"></asp:TextBox>
                                <asp:HiddenField ID="hdvSerchProj" runat="server" />
                                <ajax:AutoCompleteExtender ID="ACEProp" runat="server" TargetControlID="txtProperty"
                                    CompletionInterval="100" UseContextKey="True" FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True"
                                    ServiceMethod="GetAllProjectName" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" OnClientItemSelected="OnSerchProjSelected"
                                    MinimumPrefixLength="1" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </ajax:AutoCompleteExtender>
                            </td>
                            <td class="Label" style="width: 150px">
                            </td>
                            <td align="left">
                            </td>
                            <td style="width: 100px">
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
                                                                        ValidationGroup="Add" OnClick="btnSearch_Click" />
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="BtnPrint" runat="server" CssClass="button" TabIndex="42" Text="Print"
                                                                        ValidationGroup="Add" OnClientClick="aspnetForm.target ='_blank';" OnClick="BtnPrint_Click" />
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="BtnExportDetail" runat="server" CssClass="button" TabIndex="43" Text="Export Detail"
                                                                        ValidationGroup="Add" Width="120px" OnClick="BtnExportDetail_Click" />
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="BtnCancel" runat="server" CssClass="button" TabIndex="43" Text="Cancel"
                                                                        ValidationGroup="Add" OnClick="btnCancel_Click" />
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
                                <%--aspnetForm.target ='_blank'; dosen't work under Update panel so we use postback trigger --%>
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
                                                        <asp:BoundField HeaderText="PropertyAddress" DataField="PropertyAddress" SortExpression="PropertyAddress">
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
                    <table>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <a name="Navigate">
                                            <div style="overflow: scroll; width: 940px">
                                                <asp:GridView ID="GrdProjectDtls" runat="server" AllowPaging="True" AlternatingRowStyle-CssClass="alt"
                                                    AutoGenerateColumns="False" CssClass="mGrid" GridLines="None" PagerStyle-CssClass="pgr"
                                                    Width="100%" AllowSorting="true">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Property Name" DataField="Property" SortExpression="PropertyName">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <%--4--%>
                                                        <asp:BoundField HeaderText="PropertyId" DataField="PropertyId" SortExpression="PropertyId">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Display_None" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="CompanyName" DataField="CompanyName" SortExpression="CompanyName">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="CompanyId" DataField="CompanyId" SortExpression="CompanyId">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="UnitNo" DataField="UnitNo" SortExpression="UnitNo">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="UnitNo" DataField="UnitNo" SortExpression="UnitNo">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="PropertyTaxAmt" DataField="PropertyTaxAmt" SortExpression="PropertyTaxAmt">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="SocietyMaintenaceAmt" DataField="SocietyMaintenaceAmt"
                                                            SortExpression="SocietyMaintenaceAmt">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="UnitArea" DataField="UnitArea" SortExpression="UnitArea">
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
