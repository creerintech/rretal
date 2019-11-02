<%@ Page Title="User Master" Language="C#" MasterPageFile="~/MasterPages/MasterPage_RN.master"
    AutoEventWireup="true" CodeFile="UserMaster.aspx.cs" Inherits="Masters_UserMaster" %>

<%@ Register Assembly="AjaxControlToolKit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <input type="hidden" id="hiddenbox" runat="server" value="" />

    <script type="text/javascript" language="javascript">

function UpdateEquipFunction()
 {

     var value = document.getElementById('<%=txtUser.ClientID%>').value;
     
     if(value == "")
        {
            document.getElementById('<%= hiddenbox.ClientID%>').value = "1";
        }
        else
        {
            if (confirm("Would You Want To Upadte The Record ?") == true) {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "0";
                return false;
            }
            else {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "100";
            }
        }
  }
    function DeleteEquipFunction()
     {

         var value = document.getElementById('<%=txtUser.ClientID%>').value;
             
             if(value == "")
                {
                    document.getElementById('<%= hiddenbox.ClientID%>').value = "1";
                }
                else
                {
                    if (confirm("Would You Want To Delete This Record ?") == true)
                {
                 document.getElementById('<%= hiddenbox.ClientID%>').value="0";
                 return false;
             }
             else {
                 document.getElementById('<%= hiddenbox.ClientID%>').value = "100";
             }
    }
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

    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Search for User :
            <tr>
                <td align="right" class="SubTitle">
                    <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                        Width="292px" AutoPostBack="True" TabIndex="12" OnTextChanged="TxtSearch_TextChanged"></asp:TextBox>
                    <div id="divwidth">
                    </div>
                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtSearch"
                        CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                        ServiceMethod="GetSuggestedRecord" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
                    </ajax:AutoCompleteExtender>
                </td>
            </tr>
            <br />
            <div class="separator" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    Users and Permission
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
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
 <%--   <fieldset id="Fieldset1" runat="server" class="FieldSet" style="width: 99%">--%>
    <asp:UpdatePanel ID="UpEntry" runat="server">
        <ContentTemplate>
            <fieldset id="f1" class="FieldSet" runat="server">
                <table cellspacing="6px" width="100%">                                       
                        <%--<tr>
        <td class="Label">
            User Name :</td>
        <td align="left">
            <asp:TextBox ID="TxtUserName" runat="server" CssClass="TextBox" MaxLength="30" 
                TabIndex="1" Width="275%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtUserName" 
                Display="None" ErrorMessage="User Name is  Required" SetFocusOnError="True" 
                ValidationGroup="Add"></asp:RequiredFieldValidator>
            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" 
                Enabled="True" TargetControlID="Rq1" 
                WarningIconImageUrl="~/Images/Icon/Warning.png">
            </ajax:ValidatorCalloutExtender>
        </td>
          </tr>--%>
                        <tr>
                        <td class="Label" width="13%">User Name :</td>
                        <td colspan="3">
                          <asp:TextBox ID="TxtUserName" runat="server" CssClass="TextBox" MaxLength="30" 
                                    TabIndex="2" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtUserName" 
                                    Display="None" ErrorMessage="User Name is  Required" SetFocusOnError="True" 
                                    ValidationGroup="Add"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" 
                                    Enabled="True" TargetControlID="Rq1" 
                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                </ajax:ValidatorCalloutExtender>
                        </td>
                        </tr>
                        <tr>
                            <td class="Label">
                                Login Name :</td>
                            <td align="left">
                                <asp:TextBox ID="txtUser" runat="server" CssClass="TextBox" MaxLength="30" 
                                    TabIndex="2" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Rq1" runat="server" ControlToValidate="txtUser" 
                                    Display="None" ErrorMessage="Login Name is  Required" SetFocusOnError="True" 
                                    ValidationGroup="Add"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" 
                                    Enabled="True" TargetControlID="Rq1" 
                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                            <td class="Label">
                                Email ID :</td>
                            <td>
                                <asp:TextBox ID="TxtEmailid" runat="server" CssClass="TextBox"  
                                    TabIndex="3" ValidationGroup="Add" Width="150px"></asp:TextBox>
                             <%--   <asp:Label ID="lblEx" runat="server" Text="eg.(abc@gmail.com)"></asp:Label>--%>
                                <asp:RequiredFieldValidator ID="Rq_V2" runat="server" 
                                    ControlToValidate="txtemailid" Display="None" 
                                    ErrorMessage="Email Id is  Required" SetFocusOnError="True" 
                                    ValidationGroup="Add"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RE_V1" runat="server" 
                                    ControlToValidate="txtemailid" Display="None" 
                                    ErrorMessage="Please Enter Valid Email ID" SetFocusOnError="True" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ValidationGroup="Add"></asp:RegularExpressionValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" 
                                    TargetControlID="RE_V1" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:ValidatorCalloutExtender ID="Req_V2_ValidatorCalloutExtender" 
                                    runat="server" TargetControlID="Rq_V2" 
                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="Label">
                                Password :</td>
                            <td align="left">
                                <asp:TextBox ID="txtpassword" runat="server" CssClass="TextBox" MaxLength="30" 
                                    TabIndex="4" TextMode="Password" ValidationGroup="Add" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Rq_V3" runat="server" 
                                    ControlToValidate="txtpassword" Display="None" 
                                    ErrorMessage="Password is  Required" SetFocusOnError="True" 
                                    ValidationGroup="Add"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="Rq_V3_ValidatorCalloutExtender" 
                                    runat="server" TargetControlID="Rq_V3" 
                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                            <td class="Label">
                                Confirm Password :</td>
                            <td>
                                <asp:TextBox ID="txtConfirmpassword" runat="server" CssClass="TextBox" 
                                    MaxLength="30" TabIndex="5" TextMode="Password" ValidationGroup="Add" 
                                    Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Rq_V4" runat="server" 
                                    ControlToValidate="txtConfirmpassword" Display="None" 
                                    ErrorMessage="Password confirmation is required!" SetFocusOnError="True" 
                                    ValidationGroup="Add"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Rc_V1" runat="server" ControlToCompare="txtpassword" 
                                    ControlToValidate="txtConfirmpassword" Display="None" 
                                    ErrorMessage="Your passwords do not match up!" SetFocusOnError="True" 
                                    ValidationGroup="Add"></asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="Rq_V4_ValidatorCalloutExtender" 
                                    runat="server" TargetControlID="Rq_V4" 
                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
                                    TargetControlID="Rc_V1" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="Label">
                                Admin :</td>
                            <td align="left">
                                <asp:RadioButtonList ID="RadioIsAdmin" runat="server" AutoPostBack="True" TabIndex="6"
                                    CssClass="RadioButton" 
                                    OnSelectedIndexChanged="RadioIsAdmin_SelectedIndexChanged" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Value="T">True</asp:ListItem>
                                    <asp:ListItem Value="F">False</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="Label">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                       <%-- <tr>
                        <td class="Label">Project :</td>
                        <td>
                           <asp:CheckBoxList ID="ChkProject" runat="server" RepeatDirection="Vertical" Font-Bold="true" 
                    CssClass="CheckBox"></asp:CheckBoxList>
                        </td>
                        <td>
                        <asp:CustomValidator runat="server" ID="cvmodulelist" ValidationGroup="Add"
                ClientValidationFunction="ValidateModuleList"
                ErrorMessage="Please Select Atleast one Module" >
                </asp:CustomValidator>
                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" 
                    Enabled="True" TargetControlID="cvmodulelist" 
                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                </ajax:ValidatorCalloutExtender>
                        </td>
                        </tr>--%>
                        <tr><td colspan="4"></td></tr>
    
    </table>
    </fieldset>
    <fieldset id="Fieldset2" runat="server" class="FieldSet"  >
    <legend id="Legend1" class="legend" runat="server">&nbsp;&nbsp;Set Permissions&nbsp;&nbsp;</legend>
    <table width="100%">                        
                    <tr>
            <td>
            <asp:Panel ID="PnlUserRight" runat="server"  ScrollBars="Horizontal" Height="400px">                    
                <asp:GridView ID="GridUserRight" runat="server" AutoGenerateColumns="False" Width="98%" 
                    TabIndex="7" onrowdatabound="GridUserRight_RowDataBound" 
                    CssClass="mGrid" GridLines="None" 
                    ondatabound="GridUserRight_DataBound">                                
                                <Columns>
                                    <asp:TemplateField HeaderText="#" Visible="false">                                        
                                        <ItemTemplate>
                                            <asp:Label ID="LblEntryId" runat="server" Text='<%# Eval("#") %>' Width="30px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="All">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="GrdSelectAllHeader" runat="server"                                                  
                                                 AutoPostBack="true" 
                                                oncheckedchanged="GrdSelectAllHeader_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="GrdSelectAll" runat="server" AutoPostBack="true" 
                                                oncheckedchanged="GrdSelectAll_CheckedChanged"/>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sr. No.">                        
                                    <ItemTemplate>
                                    <asp:Label ID="LblSrNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" 
                                    Width="7%" />
                                    </asp:TemplateField>
                                     <asp:BoundField DataField="ModuleId" HeaderText="Module">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" 
                                            Font-Size="Small"  />
                                    </asp:BoundField>
                                   <%-- <asp:BoundField DataField="Project" HeaderText="Project">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" 
                                            Font-Size="Small"  />
                                    </asp:BoundField>--%>
                                    <%--<asp:BoundField DataField="Module" HeaderText="Module">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" 
                                            Font-Size="Small"  />
                                    </asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="Form">
                                        <ItemTemplate>
                                            <asp:Label ID="LblFormName" runat="server" Text='<%# Bind("FormCaption") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Add">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="GrdAddRight" runat="server" 
                                                Checked='<%# Convert.ToBoolean(Eval("AddAuth").ToString()) %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="GrdViewRight" runat="server" AutoPostBack="True" 
                                                Checked='<%# Convert.ToBoolean(Eval("ViewAuth").ToString()) %>' 
                                                oncheckedchanged="GrdViewRight_CheckedChanged" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="GrdEditRight" runat="server" 
                                                Checked='<%# Convert.ToBoolean(Eval("EditAuth").ToString()) %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="GrdDelRight" runat="server" 
                                                Checked='<%# Convert.ToBoolean(Eval("DelAuth").ToString()) %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Print">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="GrdPrintRight" runat="server" 
                                                Checked='<%# Convert.ToBoolean(Eval("PrintAuth").ToString()) %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns> 
                                <PagerStyle CssClass="pgr" />
                                <AlternatingRowStyle CssClass="alt"/>                               
                            </asp:GridView>
                 </asp:Panel></td>
        </tr>
     <tr>
             <td align="center">
                <table align="center" >
                    <tr>
                        <td>
                            <asp:Button ID="BtnUpdate" runat="server" CssClass="button" 
                                 TabIndex="8" Text="Update" 
                                ValidationGroup="Add" onclick="BtnUpdate_Click" />
                            <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" 
                                ConfirmText="Are You Sure, You Want To Update User..! " Enabled="True" 
                                TargetControlID="BtnUpdate">
                            </ajax:ConfirmButtonExtender>
                        </td>
                        <td>
                            <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                                 TabIndex="9" Text="Save" ValidationGroup="Add" onclick="BtnSave_Click" />                            
                        </td>
                         <td>
                                    <asp:Button ID="BtnDelete" runat="server" CssClass="button" Text="Delete" ValidationGroup="Add" TabIndex="10"
                                        OnClick="BtnDelete_Click" />
                                    <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete the Record ..! "
                                        TargetControlID="BtnDelete">
                                    </ajax:ConfirmButtonExtender>
                                </td>
                        <td>
                            <asp:Button ID="BtnCancel" runat="server" CausesValidation="False" 
                                CssClass="button"  TabIndex="11" Text="Cancel" 
                                ValidationGroup="Add" onclick="BtnCancel_Click" />
                        </td>
                    </tr>
                </table>
             </td>
             </tr>  
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
  <%--  </fieldset>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ReportTitle" runat="Server">
    User List
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Report" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel_Report" runat="server">
        <ContentTemplate>
            <table cellspacing="5">
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="height: 400px; overflow: auto; width: 230px;">
                            <asp:Repeater ID="GrdReport" runat="server" OnItemCommand="GrdReport_ItemCommand">
                                <ItemTemplate>
                                    <li id="Menuitem" runat="server">
                                        <asp:LinkButton ID="lbtn_List" CssClass="linkButton" CausesValidation="false" CommandName="Select"
                                            CommandArgument='<%# Eval("#") %>' runat="server" Text='<%# Eval("Name") %>'>
                                        </asp:LinkButton>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
