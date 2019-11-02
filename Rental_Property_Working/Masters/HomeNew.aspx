<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage_RN.master" AutoEventWireup="true"
    CodeFile="HomeNew.aspx.cs" Inherits="Masters_HomeNew" Title="Home" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
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
    Dashboard
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
    <%--    <div id="sliderFrame">
        <div id="slider">
            <img src="../jsImgSlider/images/1.png" alt="" />
            <img src="../jsImgSlider/images/2.png" alt="" />
            <img src="../jsImgSlider/images/3.png" alt="" />
        </div>
        <div id="htmlcaption" style="display: none;">
        </div>
    </div>--%>
    <asp:UpdatePanel ID="AjaxPanelUpdateEntry" runat="server">
        <ContentTemplate>
            <%--    <table width="100%">
                <tr>
                    <td>
                        <fieldset id="fieldset" runat="server" class="FieldSet">
                            <table width="100%" cellspacing="6">
                                <tr>
                                    <td colspan="6">
                                        <ajax:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContent1"
                                            FadeTransitions="true" FramesPerSecond="30" HeaderCssClass="accordionHeader"
                                            HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" SuppressHeaderPostbacks="true"
                                            TransitionDuration="220" Width="100%" SelectedIndex="0" AutoSize="None" TabIndex="1">
                                            <Panes>
                                                <ajax:AccordionPane ID="AccordionPane1" runat="server" Width="10%">
                                                    <Header>
                                                        <a class="href">Areas</a></Header>
                                                    <Content>--%>
            <table width="100%">
                <tr>
                    <td colspan="6" align="center">
                        <asp:GridView ID="GridReport" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                            CssClass="mGrid" EmptyDataText="Sorry...! No Records Found...." TabIndex="2"
                            ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr.No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSrno" runat="server" Text='<%#((GridViewRow)Container).RowIndex+1 %>'
                                            CssClass="Label"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <FooterStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Project" DataField="Project">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="15%" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="15%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Total Area" DataField="TotalArea">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="18%" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="18%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="18%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Sold Area" DataField="SoldArea">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="18%" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="18%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="18%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Hold Area" DataField="HoldArea">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="18%" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="18%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="18%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Available Area" DataField="Available">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="18%" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="18%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="18%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="PCId" DataField="PCId">
                                    <HeaderStyle CssClass="Display_None" />
                                    <ItemStyle CssClass="Display_None" />
                                    <FooterStyle CssClass="Display_None" />
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle CssClass="pgr" />
                            <FooterStyle CssClass="ftr" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <%--    </Content>
                                                </ajax:AccordionPane>
                                            </Panes>
                                        </ajax:Accordion>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <ajax:Accordion ID="Accordion2" runat="server" ContentCssClass="accordionContent1"
                                            FadeTransitions="true" FramesPerSecond="30" HeaderCssClass="accordionHeader"
                                            HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" SuppressHeaderPostbacks="true"
                                            TransitionDuration="220" Width="100%" SelectedIndex="0" AutoSize="None">
                                            <Panes>
                                                <ajax:AccordionPane ID="AccordionPane2" runat="server" Width="10%">
                                                    <Header>
                                                        <a class="href">Agreement Values</a></Header>
                                                    <Content>--%>
            <table width="100%">
                <tr>
                    <td colspan="6">
                        <asp:GridView ID="GridReport1" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                            CssClass="mGrid" EmptyDataText="Sorry...! No Records Found...." TabIndex="2"
                            ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr.No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSrno" runat="server" Text='<%#((GridViewRow)Container).RowIndex+1 %>'
                                            CssClass="Label"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <FooterStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Project" DataField="Project">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="15%" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="15%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Sold (Agreement Value)" DataField="SoldAgreementValue">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="24%" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="24%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="24%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Recd (Agreement Value)" DataField="RecdAgreementValue">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="24%" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="24%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="24%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Balance (Agreement Value)" DataField="BalanceAgreementValue">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="24%" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="24%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="24%" />
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle CssClass="pgr" />
                            <FooterStyle CssClass="ftr" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            
            <table width="100%">
                <tr>
                    <td colspan="6">
                        <asp:GridView ID="GridReport2" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                            CssClass="mGrid" EmptyDataText="Sorry...! No Records Found...." TabIndex="2"
                            ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr.No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSrno" runat="server" Text='<%#((GridViewRow)Container).RowIndex+1 %>'
                                            CssClass="Label"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <FooterStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Project" DataField="Project">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="15%" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="15%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Due Till Last Week" DataField="TotalDue_TillLastWeek">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="20%" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="20%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Due This Week" DataField="TotalDue_ThisWeek">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="20%" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="20%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Toal Due" DataField="ToalDue">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="20%" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="20%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="20%" />
                                </asp:BoundField>                              
                                 <asp:BoundField HeaderText="Recd" DataField="TotalRcvd">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="20%" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="20%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="20%" />
                                </asp:BoundField>
                                   <asp:BoundField HeaderText="Balance" DataField="Balance">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="20%" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="20%" />
                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                        Wrap="False" Width="20%" />
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle CssClass="pgr" />
                            <FooterStyle CssClass="ftr" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <%--  </Content>
                                                </ajax:AccordionPane>
                                            </Panes>
                                        </ajax:Accordion>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ReportTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Report" runat="Server">
    <table>
        <tr>
            <td>
                <ul>
                    <li>
                        <img src="../Images/New Icon/icon1.jpeg" height="16px" width="16px" /><a href="../Transactions/BookingForm.aspx"
                            class="linkButtonMenu">Booking Form</a></li>
                    <li>
                        <img src="../Images/New Icon/icon1.jpeg" height="16px" width="16px" /><a href="../Transactions/PaymentFollowUp.aspx"
                            class="linkButtonMenu">Payment Follow Up</a></li>
                    <li>
                        <img src="../Images/New Icon/icon1.jpeg" height="16px" width="16px" /><a href="../MIS/AvailabilityChart.aspx"
                            class="linkButtonMenu">Availability Chart</a></li>
                    <li>
                        <img src="../Images/New Icon/icon1.jpeg" height="16px" width="16px" />
                        <a href="../MIS/OutStandingProjectWise.aspx" class="linkButtonMenu">Project Wise Outstanding
                            Report</a></li>
                    <li>
                        <img src="../Images/New Icon/icon1.jpeg" height="16px" width="16px" />
                        <a href="../MIS/StampDutyReport.aspx" class="linkButtonMenu">Stamp Duty Report</a>
                    </li>
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                <hr width="100%" />
            </td>
        </tr>
        <tr>
            <td id="Tr1" runat="server">
                <asp:Label runat="server" ID="LBLEMP" CssClass="LabelPOP" Text="Please Select Employee"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlEmp" runat="server" CssClass="ComboBox" Width="180px" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlEmp_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <%-- <marquee direction="Up" height="300px" scrollamount="3">--%>
        <tr>
            <td>
                <div>
                    <asp:ListView ID="LstToday" runat="server" ItemPlaceholderID="itemContainer">
                        <LayoutTemplate>
                            <asp:PlaceHolder ID="itemContainer" runat="server" />
                        </LayoutTemplate>
                        <ItemTemplate>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <li class="LabelToday">'<%# Eval("Total")%>' </li>
                        </ItemTemplate>
                    </asp:ListView>
                    <div>
                    </div>
            </td>
        </tr>
        <%--</marquee>--%>
    </table>
</asp:Content>
