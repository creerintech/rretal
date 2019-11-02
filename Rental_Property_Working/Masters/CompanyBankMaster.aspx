<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage_RN.master" AutoEventWireup="true"
    CodeFile="CompanyBankMaster.aspx.cs" Inherits="Masters_Aminity" Title="Company Bank Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <input type="hidden" id="hiddenbox" runat="server" value="" />

    <script type="text/javascript" language="javascript">

function UpdateEquipFunction()
 {

     var value = document.getElementById('<%=ddlProject.ClientID%>').value;
     
     if(value == "")
        {
            document.getElementById('<%= hiddenbox.ClientID%>').value = "1";
        }
        else
        {
            if (confirm("Are you sure you want to Update?") == true) {
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

             var value = document.getElementById('<%=ddlProject.ClientID%>').value;
             
             if(value == "")
                {
                    document.getElementById('<%= hiddenbox.ClientID%>').value = "1";
                }
                else
                {
                if(confirm("Are you sure you want to Delete?")==true)
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

    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Search For Project :
            <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                Width="292px" AutoPostBack="True" OnTextChanged="TxtSearch_TextChanged">
            </asp:TextBox>
            <div id="divwidth">
            </div>
            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtSearch"
                CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
            </ajax:AutoCompleteExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    Company Bank Details
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <asp:UpdatePanel ID="AjaxPanelUpdateEntry" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
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
             <asp:RequiredFieldValidator ID="Req1" runat="server"
            ControlToValidate="ddlProject" Display="None"
            ErrorMessage="Project Is Required" SetFocusOnError="True" 
            ValidationGroup="Add" InitialValue="0">
            </asp:RequiredFieldValidator>
            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
            Enabled="True" TargetControlID="Req1"
            WarningIconImageUrl="~/Images/Icon/Warning.png">
            </ajax:ValidatorCalloutExtender>
            
            </td>
            <td align="left">
            </td>
            <td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ControlToValidate="ddlCompany" Display="None"
            ErrorMessage="Project Is Required" SetFocusOnError="True" 
            ValidationGroup="AddGrid" InitialValue="0">
            </asp:RequiredFieldValidator>
            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
            Enabled="True" TargetControlID="RequiredFieldValidator1"
            WarningIconImageUrl="~/Images/Icon/Warning.png">
            </ajax:ValidatorCalloutExtender>
            </td>
                <td>
                </td>
              
        </tr>
        <tr>
            <td class="Label">
                Project :
            </td>
            
            <td align="left" >
                <asp:DropDownList ID="ddlProject" runat="server" Width="200px" 
                    CssClass="ComboBox" AutoPostBack="True" 
                    onselectedindexchanged="ddlProject_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td></td>
            <td></td>
          
        </tr>
        
        <tr>
         
           <td  class="Label">
                Company :
           
            </td>
            <td>
            <asp:DropDownList ID="ddlCompany" runat="server" Width="200px" 
                    CssClass="ComboBox">
                </asp:DropDownList>
            </td>
               <td class="Label" style="height: 24px">
                Type :</td>
            <td align="left">                                                                       
                <asp:DropDownList ID="ddlType" runat="server" CssClass="ComboBox" 
                    Width="200px">
                     <asp:ListItem Value="0">--Select Type--</asp:ListItem>
                    <asp:ListItem Value="1">Primary</asp:ListItem>
                    <asp:ListItem Value="2">Secondary</asp:ListItem>
                    <asp:ListItem Value="3">Other</asp:ListItem> 
                </asp:DropDownList>                                                                       
            </td>
       </tr>
       <tr>
           <td class="Label" >
               Bank :</td>
           <td align="left" colspan="3" >
               <asp:TextBox ID="txtBank" runat="server" Width="515px"></asp:TextBox>
           </td>
          
       </tr>
       <tr>
           <td class="Label">
               Branch :</td>
           <td align="left" >
           <asp:TextBox ID="txtBranch" runat="server" Width="200px"></asp:TextBox>
               </td>
                <td class="Label">
               A/C No. :</td>
           <td align="left" >
           <asp:TextBox ID="txtAcountNo" runat="server" Width="200px"></asp:TextBox>
               </td>
       </tr>
          <tr>
           <td class="Label" nowrap="nowrap">
               RTGS No. :</td>
           <td align="left" >
           <asp:TextBox ID="txtRTGSNo" runat="server" Width="200px"></asp:TextBox>
               </td>
                <td class="Label">
               Cheque Drawn :</td>
           <td align="left" >
           <asp:TextBox ID="txtCheque" runat="server" Width="200px"></asp:TextBox>
              <asp:ImageButton ID="ImgAddCompany" runat="server" CssClass="Imagebutton" 
                    Height="16px" ImageUrl="~/Images/Icon/Gridadd.png" ToolTip="Add Grid" 
                    ValidationGroup="AddGrid" Width="16px" onclick="ImgAddCompany_Click" />
               </td>
       </tr>
       <tr>
       
           <td colspan="4" align="center">
           <div class="scrollableDiv1">
            <asp:GridView ID="GridDetails" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                BorderStyle="None" BorderWidth="1px" CssClass="mGrid" Font-Bold="False" ForeColor="Black"
                                                GridLines="Horizontal" OnRowCommand="GridDetails_RowCommand" OnRowDeleting="GridDetails_RowDeleting" TabIndex="10">
            
                                        <%--    <RowStyle CssClass="grdRow" />--%>
                                            <Columns>
                                                <asp:TemplateField HeaderText="#" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrid" runat="server" Text='<%# Eval("#") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                      <asp:ImageButton ID="ImageGridEdit" runat="server" CommandArgument="<%#((GridViewRow)Container).RowIndex %>"
                                                                CommandName="SelectGrid" ImageUrl="~/Images/Icon/GridEdit.png" ToolTip="Edit" />
                                                            <asp:ImageButton ID="ImageBtnDelete" runat="server" CommandArgument='<%#Eval("#") %>'
                                                                CommandName="Delete" OnClientClick="DeleteEquipFunction();" ImageUrl="~/Images/Icon/GridDelete.png"
                                                                ToolTip="Delete" />
                                                  
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                  <asp:BoundField HeaderText="ProjectCompanyId" DataField="ProjectCompanyId">
                                                        <HeaderStyle Wrap="false" CssClass="Display_None" />
                                                        <ItemStyle Wrap="false" CssClass="Display_None" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Company" DataField="Company">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                                    </asp:BoundField>
                                                      <asp:BoundField HeaderText="BankTypeId" DataField="BankTypeId">
                                                        <HeaderStyle Wrap="false" CssClass="Display_None" />
                                                        <ItemStyle Wrap="false" CssClass="Display_None" />
                                                    </asp:BoundField>
                                                         <asp:BoundField HeaderText="Type" DataField="BankType">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                                    </asp:BoundField>
                                                            <asp:BoundField HeaderText="Bank" DataField="BankName">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                                    </asp:BoundField>
                                                            <asp:BoundField HeaderText="Branch" DataField="Branch">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                                    </asp:BoundField>
                                                           <asp:BoundField HeaderText="Account No" DataField="AccountNo">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                                    </asp:BoundField>
                                                      <asp:BoundField HeaderText="RTGS No" DataField="RTGSNo">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Cheque Drawn" DataField="ChequeDrawnAccName">
                                                        <HeaderStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle"  />
                                                    </asp:BoundField>
                                           
                                            </Columns>
                                            <%--<FooterStyle CssClass="grdFooter" />
                                            <PagerStyle CssClass="gPageing" />
                                            <HeaderStyle CssClass="grdHeader" />--%>
                                        </asp:GridView>
            </div>
               </td>
          
       </tr>
        
        
        </table>
               </fieldset>
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
            <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="button"
            ValidationGroup="Add" onclick="BtnUpdate_Click" OnClientClick="UpdateEquipFunction();"/>
           <%-- <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
            ConfirmText="Would You Want To Upadte The Record ?" 
            TargetControlID="BtnUpdate">
            </ajax:ConfirmButtonExtender> --%>
            </td>
            
            <td>
            <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button"
            ValidationGroup="Add" onclick="BtnSave_Click" />
            </td>
            
            <td>
            <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="button"
            ValidationGroup="Add" OnClientClick="DeleteEquipFunction();" onclick="BtnDelete_Click" />
        
            </td> 
            
            <td>
            <asp:Button ID="BtnCancel" runat="server" Text="Cancel"
            CssClass="button" CausesValidation="False" onclick="BtnCancel_Click"/>
            </td>
            
        </tr>
                 
                 
               
                  </table>
                 </td>
                 </tr>
                 </table>
   </fieldset>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ReportTitle" runat="Server">
    Project List
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Report" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <ul id="subnav">
                <%--Ul Li Problem Solved repeater--%>
                <asp:Repeater ID="GrdReport" runat="server" OnItemCommand="GrdReport_ItemCommand">
                    <ItemTemplate>
                        <li id="Menuitem" runat="server">
                            <asp:LinkButton ID="lbtn_List" CssClass="linkButton" CausesValidation="false" CommandName="Select"
                                CommandArgument='<%# Eval("#") %>' runat="server" Text='<%# Eval("Name") %>'></asp:LinkButton>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
