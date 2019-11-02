<%@ Page Title="Outstanding Receivable Report" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="outstanding_reportaspx.aspx.cs" Inherits="MIS_outstanding_reportaspx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" Runat="Server">
<ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />

   
    
   
     <script type="text/javascript" language="javascript">
        function OnSerchProjSelected(source, eventArgs) {
            var hdnValueID = "<%= hdvSerchProj.ClientID %>";
            document.getElementById(hdnValueID).value = eventArgs.get_value();          
        }
    </script>
    
   
    
     <script type="text/javascript" language="javascript">
        function OnSerchPartySelected(source, eventArgs) {
            var hdnValueID = "<%= hdvSerchParty.ClientID %>";
            document.getElementById(hdnValueID).value = eventArgs.get_value();          
        }
    </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" Runat="Server">
    Outstanding Receivable&nbsp; Report
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
<asp:Content ID="Content3" ContentPlaceHolderID="Body" Runat="Server">
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
                            <asp:CheckBox ID="chkmonth" runat="server" CssClass="checkbox" Text=" " AutoPostBack="true" OnCheckedChanged="chkmonth_CheckedChanged" />
                        </td>


                              <td class="Label">
                            &nbsp;Date UP TO :
                        </td>
                        <td>
                            <asp:TextBox ID="txtformonth" runat="server" Width="115px" CssClass="TextBox" TabIndex="4"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                ImageUrl="~/Images/Icon/DateSelector.png" TabIndex="6" />
                            <ajax:CalendarExtender ID="CalendarExtender3" runat="server" 
                                PopupButtonID="ImageButton1" TargetControlID="txtformonth" DaysModeTitleFormat="MM/dd/yyyy" TodaysDateFormat="MM/dd/yyyy" />
                        </td>
                    </tr>    
                        


                       <tr>
                           <td>

                           </td>
                       </tr>
                          <tr>
                           <td>

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
                          
                            <td class="Label">
                                  Select Party:
                            </td>
                            <td>
                                 <asp:TextBox ID="TxtParty" runat="server" TabIndex="1" Width="200px" placeholder="Enter Party Name"></asp:TextBox>
                                <asp:HiddenField ID="hdvSerchParty" runat="server" />
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtParty"
                                    CompletionInterval="100" UseContextKey="True" FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True"
                                    ServiceMethod="GetAllPartyName" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" OnClientItemSelected="OnSerchPartySelected"
                                    MinimumPrefixLength="1" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </ajax:AutoCompleteExtender>
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
                                                                    <asp:Button ID="btnSearch" runat="server" CssClass="button" TabIndex="41" Text="Show Receivable "
                                                                        ValidationGroup="Add" OnClick="btnSearch_Click"  Width="120px" />
                                                                    <%--  --%>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="BtnExportDetail" runat="server" CssClass="button" TabIndex="43" Text="Export Detail"
                                                                        ValidationGroup="Add" Width="120px" OnClick="BtnExportDetail_Click" />
                                                                    <%----%>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="BtnCancel" runat="server" CssClass="button" TabIndex="43" Text="Cancel"
                                                                        ValidationGroup="Add" OnClick="btnCancel_Click" />
                                                                    <%-- OnClick="btnCancel_Click"--%>
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
                                                     CssClass="mGrid" GridLines="Horizontal" PagerStyle-CssClass="pgr" ShowFooter="true"
                                                    Width="100%" AllowSorting="true"  OnRowDataBound="GrdProjectReport_RowDataBound">
                                                  
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
