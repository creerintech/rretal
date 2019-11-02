<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="ListOfReceipts.aspx.cs" Inherits="MIS_ListOfReceipts" Title=" List Of Receipts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>

    <script src="../Jscript/gridviewScroll.min.js" type="text/javascript"></script>

    <script type="text/javascript">



        function pageLoad(sender, args) {
            gridviewScroll();

        }
        function gridviewScroll() {

            $('#<%=GridReceiptList.ClientID%>').gridviewScroll({

                width: 1030,

                height: 500,

                startHorizontal: 0,

                wheelstep: 10,

                barhovercolor: "#3399FF",

                barcolor: "#3399FF"



            });

        }        
    </script>

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    List Of Receipts
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
                            Property :
                        </td>
                        <td align="left" class="Label1">
                            <asp:DropDownList ID="ddlProperty" runat="server" CssClass="ComboBox" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlProperty_SelectedIndexChanged" Width="250px" TabIndex="6">
                            </asp:DropDownList>
                        </td>
                        <td class="Label">
                            Party :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlParty" runat="server" CssClass="ComboBox" Width="250px"
                                AutoPostBack="True" TabIndex="7" OnSelectedIndexChanged="ddlParty_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Label">
                            Unit No :
                        </td>
                        <td>
                            <asp:TextBox ID="txtUnitNo" runat="server" AutoPostBack="true" Width="250px" placeholder="Please Enter Unit No...">                                                                                   
                            </asp:TextBox>
                        </td>
                        <td class="Label">
                            Company
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCompany" runat="server" CssClass="ComboBox" Width="250px"
                                AutoPostBack="True" TabIndex="9">
                            </asp:DropDownList>
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
                    <%--  <tr style="height: 10px;">
                        <td align="center" colspan="5">
                            <a href="../Transactions/ReceiptEntry.aspx" target="_blank">Go to Receipt Voucher</a>
                        </td>
                    </tr>--%>
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
                                Height="35px" Width="35px" OnClick="ImgPDF_Click" TabIndex="15" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <asp:GridView ID="GridReceiptList" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridReceiptList_RowDataBound"
                                CssClass="mGrid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                CellPadding="4" ForeColor="Black" AllowPaging="false" PageSize="50" ShowFooter="True"
                                TabIndex="12">
                                <%--   OnPageIndexChanging="GridEnquiry_PageIndexChanging" OnRowDataBound="GridEnquiry_RowDataBound"--%>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%-- <a href='../PrintReport/PrintReports.aspx?ID=<%# Eval("BookingId")%>&amp;Flag=<%="BookingMaster"%>'
                                                    target="_blank" tabindex="136">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icon/B_faintOran.jpeg" ToolTip="Booking Print" />
                                                </a><a href='../PrintReport/PrintReports.aspx?ID=<%# Eval("BookingId")%>&amp;Flag=<%="UnitHolderDetails"%>&amp;PCID=<%# Eval("PCId")%>'
                                                    target="_blank" tabindex="136">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Icon/U_faintreen.jpg" ToolTip="Unit Holder Print" />
                                                </a><a href='../PrintReport/PrintReports.aspx?ID=<%# Eval("BookingId")%>&amp;Flag=<%="UnitHolderRecieptDtls"%>&amp;PCID=<%# Eval("PCId")%>'
                                                    target="_blank" tabindex="136">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icon/UR_faintBlue.jpg" ToolTip="Unit Holder Receipt_Details Print" />--%>
                                            </a>
                                        </ItemTemplate>
                                        <FooterStyle Wrap="True" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSrNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle Wrap="True" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ReceiptDate" HeaderText="Receipt Date">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Font-Bold="true"
                                            ForeColor="White" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Property" HeaderText="Property">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PartyName" HeaderText="PartyName">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UnitNo" HeaderText="Unit No">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Font-Bold="true"
                                            ForeColor="White" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CompanyName" HeaderText="Company">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Font-Bold="true"
                                            ForeColor="White" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ForTheMonth" HeaderText="ForTheMonth">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Font-Bold="true"
                                            ForeColor="White" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VoucherAmt" HeaderText="NetAmount" DataFormatString="{0:N2}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" />
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
