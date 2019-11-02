<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage_RN.master" AutoEventWireup="true" CodeFile="CompanyMaster.aspx.cs" Inherits="Masters_CompanyMaster" Title="Company Master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" Runat="Server">
<input type="hidden" id="hiddenbox" runat="server" value=""/>


    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" >
    <ProgressTemplate>            
    <div id="progressBackgroundFilter"></div>
    <div id="processMessage">   
    <center><span class="SubTitle">Loading....!!! </span></center>
    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icon/updateprogress.gif" Height="20px" Width="120px" />                                
    </div>
    </ProgressTemplate>
    </asp:UpdateProgress>

        Search for Company :
        <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
        Width="292px" AutoPostBack="True" ontextchanged="TxtSearch_TextChanged">
        </asp:TextBox>
        <div id="divwidth"></div>
        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1"   runat="server" 
        TargetControlID="TxtSearch" CompletionInterval="100"                             
        UseContextKey="True" FirstRowSelected ="true" ShowOnlyCurrentWordInCompletionListItem="true"
        ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender"
        CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight">                     
        </ajax:AutoCompleteExtender> 
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Title" Runat="Server">
    Company Master     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" Runat="Server">
    <asp:UpdatePanel ID="AjaxPanelUpdateEntry" runat="server">
    <ContentTemplate>
    <table width="100%">
    <tr>
    <td>
    <fieldset id="fieldset1" width="100%" runat="server" class="FieldSet">
    <table width="100%" cellspacing="6">
        <tr>
            <td class="Label">
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="Label">
                Company Name :
            </td>
            <td colspan="3">
                <asp:TextBox ID="TxtCompanyName" runat="server" CssClass="TextBox" 
                    Width="442px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Req_Name" runat="server" 
                    ControlToValidate="TxtCompanyName" Display="None" 
                    ErrorMessage="Company Name is Required" SetFocusOnError="True" 
                    ValidationGroup="Add">
                </asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender ID="VCE_Name" runat="server" Enabled="True" 
                    TargetControlID="Req_Name" WarningIconImageUrl="~/Images/Icon/Warning.png">
                </ajax:ValidatorCalloutExtender>
            </td>
        </tr>
        
         <tr>
            <td class="Label">
                Abbreviation :
            </td>
            <td colspan="3">
                <asp:TextBox ID="Txtabbreviations" runat="server" CssClass="TextBox" ToolTip="Short Name For Company Which Bind With Transaction Number"
                    MaxLength="50" Width="442px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Txtabbreviations" Display="None" 
                    ErrorMessage="Abbreviations is Required For Generating Code!" SetFocusOnError="True" 
                    ValidationGroup="Add">
                </asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True" 
                    TargetControlID="RequiredFieldValidator1" WarningIconImageUrl="~/Images/Icon/Warning.png">
                </ajax:ValidatorCalloutExtender>
            </td>
        </tr>
        
        
     <tr>
     <td class="Label">
         Address :
     </td>
     <td colspan="3">
      <asp:TextBox ID="TxtAddress" runat="server" CssClass="TextBox" 
       TextMode="MultiLine" Width="442px" Height="20px"></asp:TextBox>
     </td>
     </tr>
     
     <tr>
     <td class="Label">
         Phone No:     
     </td>
     <td colspan="3">
     <asp:TextBox ID="TxtPhoneNo" runat="server" CssClass="TextBox" 
       Width="125px" MaxLength="15"></asp:TextBox>
     <ajax:FilteredTextBoxExtender ID="FTE_Mobile" runat="server" TargetControlID="TxtPhoneNo"
     FilterType="Custom,Numbers" ValidChars="+"></ajax:FilteredTextBoxExtender>
     </td>
     </tr>
     <tr>
     <td class="Label">
         Email ID :
     </td>
     <td colspan="3">
        <asp:TextBox ID="TxtEmail" runat="server" CssClass="TextBox" 
        MaxLength="50" Width="442px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="REV2" runat="server" Display="None" 
        ErrorMessage="Please Enter Valid Email ID..!" ControlToValidate="TxtEmail" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Add">
        </asp:RegularExpressionValidator>
        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" 
        Enabled="True" TargetControlID="REV2" WarningIconImageUrl="~/Images/Icon/Warning.png">
        </ajax:ValidatorCalloutExtender>     
     </td>
     </tr>
     <tr>
     <td class="Label">
         Website :
     </td>
     <td colspan="3">
      <asp:TextBox ID="TxtWebsite" runat="server" CssClass="TextBox" 
        MaxLength="50" Width="442px"></asp:TextBox>
     </td>
     </tr>
     <tr>
     <td class="Label">
         Fax No :
     </td>
     <td>
     <asp:TextBox ID="TxtFaxNo" runat="server" CssClass="TextBox" 
       Width="125px" MaxLength="15"></asp:TextBox>
        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="TxtFaxNo"
     FilterType="Custom,Numbers" ValidChars="+,-"></ajax:FilteredTextBoxExtender>
     </td>
     <td class="Label">
         Tin No :
     </td>
     <td>
     <asp:TextBox ID="TxtTinNo" runat="server" CssClass="TextBox" 
       Width="125px" MaxLength="15"></asp:TextBox>
     </td>
     </tr>
     <tr>
     <td class="Label">
         Vat No :
     </td>
     <td>
     <asp:TextBox ID="TxtVatNo" runat="server" CssClass="TextBox" 
       Width="125px" MaxLength="15"></asp:TextBox>
     </td>
     <td class="Label">
         GSTN No :
     </td>
     <td>
     <asp:TextBox ID="TxtServiceTaxNo" runat="server" CssClass="TextBox" 
       Width="125px" MaxLength="15"></asp:TextBox>
     </td>
     </tr>
     
        <tr>
        <td class="Label">
            Notes:
        </td>
        <td colspan="3">
          <asp:TextBox ID="TxtNoteC" runat="server" CssClass="TextBox" 
          Width="442px" Height="20px" TextMode="MultiLine"></asp:TextBox>
        </td>
        </tr>
         <tr>
         <td colspan="4"></td>
         </tr>
        
    </table>
    </fieldset>
    </td>
    </tr>
    <tr>
    <td>
    <fieldset id="fieldset2" width="100%" runat="server" class="FieldSet">
    
                 <table width="100%">
                 <tr>
                 <td align="center">
                 <table align="center" width="25%">
                 <tr>
                 <td>
                 <asp:Button ID="BtnUpdate" runat="server" CssClass="button"
                 Text="Update" ValidationGroup="Add" onclick="BtnUpdate_Click"/>
                 <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                 ConfirmText="Would You Like To Update The Record ?" TargetControlID="BtnUpdate">
                 </ajax:ConfirmButtonExtender>
                 </td>
                 
                 <td>
                 <asp:Button ID="BtnSave" runat="server" CssClass="button"
                 Text="Save" ValidationGroup="Add" onclick="BtnSave_Click"/>
                 </td>
                
                 <td>
                 <asp:Button ID="BtnDelete" runat="server" CssClass="button"
                 Text="Delete" ValidationGroup="Add" onclick="BtnDelete_Click"/>
                     <ajax:ConfirmButtonExtender ID="ConfirmButtonExteuynder2" runat="server"
                 ConfirmText="Would You Like To Delete The Record ?" TargetControlID="BtnDelete">
                 </ajax:ConfirmButtonExtender>
                 </td>
                 
                 <td>
                 <asp:Button ID="BtnCancel" runat="server" CausesValidation="false"
                 CssClass="button" Text="Cancel" onclick="BtnCancel_Click"/>
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

<asp:Content ID="Content4" ContentPlaceHolderID="ReportTitle" Runat="Server">
    Company List  
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Report" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate >
    <div class="ScrollableDiv_FixHeightWidthForRepeater">
    <ul id="subnav">
            <%--Ul Li Problem Solved repeater--%>
            <asp:Repeater ID="GrdReport" runat="server" 
                onitemcommand="GrdReport_ItemCommand">
            <ItemTemplate>
            <li id="Menuitem" runat="server" >                              
            <asp:LinkButton ID="lbtn_List" CssClass="linkButton" CausesValidation="false"
                CommandName="Select" CommandArgument='<%# Eval("#") %>' runat="server"
                Text='<%# Eval("Name") %>'>
            </asp:LinkButton>
            </li>
            </ItemTemplate>    
            </asp:Repeater>
            </ul>
         </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>

