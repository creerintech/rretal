<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="DashBoard.aspx.cs" Inherits="Masters_DashBoard" Title="Dashboard" %>

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
    <asp:UpdatePanel ID="AjaxPanelUpdateEntry" runat="server">
        <ContentTemplate>
            <table width="100%">
                <%-- <tr>
                    <td>
                        <a href="../Transactions/BookingForm.aspx" class="linkButtonMenu">Booking Form</a>
                    </td>
                    <td>
                        <a href="../Transactions/PaymentFollowUp.aspx" class="linkButtonMenu">Payment 
                        Follow Up</a> </li>
                    </td>
                    <td>
                        <a href="../MIS/AvailabilityChart.aspx" class="linkButtonMenu">Availability 
                        Chart</a>
                    </td>
                    <td>
                        <a href="../MIS/OutStandingProjectWise.aspx" class="linkButtonMenu">Project Wise 
                        Outstanding Report</a>
                    </td>
                    <td>
                        <a href="../MIS/StampDutyReport.aspx" class="linkButtonMenu">Stamp Duty Report</a>
                    </td>
                </tr>--%>
            </table>
            <div style="height: 20px;">
            </div>
            <div style="overflow: scroll; min-height: 400px; max-height: 500px">
                <table width="100%">
                    <tr>
                        <td colspan="6" align="center">
                            <asp:GridView ID="GridReport" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                                Caption='<table border="1" width="100%" cellpadding="0" cellspacing="0" bgcolor="yellow"><tr><td>Rent To be Collected </td></tr></table>'
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
                                    <asp:TemplateField HeaderText="ShowFileDetails">
                                        <ItemTemplate>
                                            <asp:UpdatePanel ID="UpLnkButtonProp" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="lblButtonprop" runat="server" Text="PropertyMaster" OnClick="DownloadFileProperty"
                                                        TabIndex="1" CommandArgument='<%# Eval("#") %>' OnClientClick="aspnetForm.target ='_blank';"></asp:LinkButton>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="lblButtonprop" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ShowFileDetails">
                                        <ItemTemplate>
                                            <asp:UpdatePanel ID="UpLnkButtonRent" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="lblButtonproprent" runat="server" Text="PropertyrentCard" OnClick="DownloadFileRent"
                                                        TabIndex="1" CommandArgument='<%# Eval("#") %>' OnClientClick="aspnetForm.target ='_blank';"></asp:LinkButton>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="lblButtonproprent" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Property" DataField="Property">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="15%" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="15%" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                            Wrap="False" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Unit Type" DataField="FlatType">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="10%" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Middle"
                                            Wrap="False" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Unit Area" DataField="UnitArea">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="10%" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                            Wrap="False" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Unit No" DataField="UnitNo">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="10%" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                            Wrap="False" Width="10%" />
                                    </asp:BoundField>
                                   <%-- <asp:BoundField HeaderText="CompanyName" DataField="CompanyName">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="18%" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="18%" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Middle"
                                            Wrap="False" Width="18%" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField HeaderText="FromDate" DataField="FromDate">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="10%" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Middle"
                                            Wrap="False" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="ToDate" DataField="ToDate">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="10%" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Middle"
                                            Wrap="False" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Rent" DataField="Rent">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="10%" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                            Wrap="False" Width="10%" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField HeaderText="CollectedDate" DataField="CollectedDate">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="15%" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="15%" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Middle"
                                            Wrap="False" Width="15%" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField HeaderText="Status" DataField="Status">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="18%" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="18%"
                                            ForeColor="Red" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                            Wrap="False" Width="18%" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                                <FooterStyle CssClass="ftr" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="overflow: scroll; min-height: 400px; max-height: 500px">
                <table width="100%">
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="GridReport1" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                                CssClass="mGrid" EmptyDataText="Sorry...! No Records Found...." TabIndex="2"
                                Caption='<table border="1" width="100%" cellpadding="0" cellspacing="0" bgcolor="yellow"><tr><td> Maintenance Works </td></tr></table>'
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
                                    <asp:BoundField HeaderText="PMDate" DataField="PMDate">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="15%" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="15%" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Middle"
                                            Wrap="False" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Property" DataField="Property">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="20%" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                            Wrap="False" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="PartyName" DataField="PartyName">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="15%" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="15%" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Middle"
                                            Wrap="False" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="PartyId" DataField="PartyId">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="24%" CssClass="Display_None" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="24%"
                                            CssClass="Display_None" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Middle"
                                            CssClass="Display_None" Wrap="False" Width="24%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="PropertyId" DataField="PropertyId">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="24%" CssClass="Display_None" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Width="24%"
                                            CssClass="Display_None" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Middle"
                                            CssClass="Display_None" Wrap="False" Width="24%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="PropertyMaintenaceId" DataField="PropertyMaintenaceId">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="24%" CssClass="Display_None" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="24%"
                                            CssClass="Display_None" ForeColor="Red" />
                                        <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Middle"
                                            CssClass="Display_None" Wrap="False" Width="24%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="ShowFileDetails">
                                        <ItemTemplate>
                                            <asp:UpdatePanel ID="UpLnkButton" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="lblButton" runat="server" Text="ShowFileDetails" OnClick="DownloadFile"
                                                        TabIndex="1" CommandArgument='<%# Eval("#") %>' OnClientClick="aspnetForm.target ='_blank';"></asp:LinkButton>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="lblButton" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                                <FooterStyle CssClass="ftr" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
