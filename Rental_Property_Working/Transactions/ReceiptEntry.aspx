<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReceiptEntry.aspx.cs" Inherits="Transactions_ReceiptEntry" Title="Receipt Voucher" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <input type="hidden" id="HiddenTxtDebit" runat="server" value="0" />
    <input type="hidden" id="hiddenbox" runat="server" value="" />
    <%--<script type="text/javascript" language="javascript">

        function AdjustAmount()
        {
        var _txtDrAmt = document.getElementById('<%= txtDrAmt.ClientID %>');   
        var _txtCrAmt = document.getElementById('<%= txtCrAmt.ClientID %>');   
        var _TxtTotalDebit = document.getElementById('<%= TxtTotalDebit.ClientID %>');   
        var _TxtTotalCredit = document.getElementById('<%= TxtTotalCredit.ClientID %>');       
        
        var DebitAmt=0,CreditAmt=0,TotalDebit=0,TotalCredit=0;    
        
        if(_txtCrAmt.value != "") CreditAmt=_txtCrAmt.value; 
        
        _txtDrAmt.value=parseFloat(CreditAmt).toFixed(2);
        _TxtTotalDebit.value=parseFloat(CreditAmt).toFixed(2);
        _TxtTotalCredit.value=parseFloat(CreditAmt).toFixed(2);
        NumbertoWord();
        }


        function UpdateEquipFunction() {

        var value = document.getElementById('<%=txtVoucherNo.ClientID%>').value;

        if (value == "") {
            document.getElementById('<%= hiddenbox.ClientID%>').value = "1";
        }
        else {
            if (confirm("Would You Want To Upadte The Record ?") == true) {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "0";
                return false;
            }
            else {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "100";

            }
        }
    }

    function DeleteEquipFunction() {

        var value = document.getElementById('<%=txtVoucherNo.ClientID%>').value;

        if (value == "") {
            document.getElementById('<%= hiddenbox.ClientID%>').value = "1";
        }
        else {
            if (confirm("Would You like To Delete The Record ?") == true) {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "0";
                return false;
            }
            else {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "100";

            }
        }
    }
    </script>

    <script type="text/javascript" language="javascript">

  //Number to word

	function NumbertoWord()
	 {
    var junkVal="";
     document.getElementById('<%=txtAmtInWrds.ClientID%>').value="";
    junkVal= document.getElementById('<%=txtCrAmt.ClientID%>').value;    
  
    val=junkVal;
   junkVal=Math.floor(junkVal);

    var obStr=new String(junkVal);

    numReversed=obStr.split("");

    actnumber=numReversed.reverse();

    if(Number(junkVal) >=0)
    {
        //do nothing

    }
    else{

        alert('wrong Number cannot be converted');
        return false;
    }
    if(Number(junkVal)==0){

        document.getElementById('container').innerHTML=obStr+''+'Rupees Zero Only';
        return false;
    }
    if(actnumber.length>9){
        alert('Oops!!!! the Number is too big to covertes');

        return false;
    }

 

    var iWords=["Zero", " One", " Two", " Three", " Four", " Five", " Six", " Seven", " Eight", " Nine"];

    var ePlace=['Ten', ' Eleven', ' Twelve', ' Thirteen', ' Fourteen', ' Fifteen', ' Sixteen', ' Seventeen', ' Eighteen', ' Nineteen'];

    var tensPlace=['dummy', ' Ten', ' Twenty', ' Thirty', ' Forty', ' Fifty', ' Sixty', ' Seventy', ' Eighty', ' Ninety' ];

 

    var iWordsLength=numReversed.length;

    var totalWords="";

    var inWords=new Array();

    var finalWord="";

    j=0;

    for(i=0; i<iWordsLength; i++){

        switch(i)

        {

        case 0:

            if(actnumber[i]==0 || actnumber[i+1]==1 ) {

                inWords[j]='';

            }

            else {

                inWords[j]=iWords[actnumber[i]];

            }

            inWords[j]=inWords[j]+' Only';

            break;

        case 1:

            tens_complication();

            break;

        case 2:

            if(actnumber[i]==0) {

                inWords[j]='';

            }

            else if(actnumber[i-1]!=0 && actnumber[i-2]!=0) {

                inWords[j]=iWords[actnumber[i]]+' Hundred and';

            }

            else {

                inWords[j]=iWords[actnumber[i]]+' Hundred';

            }

            break;

        case 3:

            if(actnumber[i]==0 || actnumber[i+1]==1) {

                inWords[j]='';

            }

            else {

                inWords[j]=iWords[actnumber[i]];

            }

            if(actnumber[i+1] != 0 || actnumber[i] > 0){

                inWords[j]=inWords[j]+" Thousand";

            }

            break;

        case 4:

            tens_complication();

            break;

        case 5:

            if(actnumber[i]==0 || actnumber[i+1]==1) {

                inWords[j]='';

            }

            else {

                inWords[j]=iWords[actnumber[i]];

            }

            if(actnumber[i+1] != 0 || actnumber[i] > 0){

                inWords[j]=inWords[j]+" Lakh";

            }

            break;

        case 6:

            tens_complication();

            break;

        case 7:

            if(actnumber[i]==0 || actnumber[i+1]==1 ){

                inWords[j]='';

            }

            else {

                inWords[j]=iWords[actnumber[i]];

            }

            inWords[j]=inWords[j]+" Crore";

            break;

        case 8:

            tens_complication();

            break;

        default:

            break;

        }

        j++;

    }
 

    function tens_complication() {

        if(actnumber[i]==0) {

            inWords[j]='';

        }

        else if(actnumber[i]==1) {

            inWords[j]=ePlace[actnumber[i-1]];
        }

        else {

            inWords[j]=tensPlace[actnumber[i]];

        }
    }

    inWords.reverse();

    for(i=0; i<inWords.length; i++) {
        finalWord+=inWords[i];

    }
 document.getElementById('<%=txtAmtInWrds.ClientID%>').value=finalWord;
}
    </script>--%>
    <%--<script type="text/javascript" language="javascript">
        function OnContactSelected(source, eventArgs) {

            var hdnValueID = "<%= hdnValue.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
            __doPostBack(hdnValueID, "");
        } 
    </script>--%>

    <script type="text/javascript" language="javascript">
    
    function Calcuate_NetTotal() 
    {
     var PaidAmount = document.getElementById('<%= txtPaidAmount.ClientID%>');
            var Amount = document.getElementById('<%= txtAmount.ClientID%>');
            var RemAmt = document.getElementById('<%= txtRemAmt.ClientID%>');
              var CalRemAmt = document.getElementById('<%= txtRemAmountCal.ClientID%>');
             var total = 0;
              
                
         
            
             if (PaidAmount.value == "" || isNaN(PaidAmount.value)) {
                PaidAmount.value = 0;
            }
            
            if (Amount.value == "" || isNaN(Amount.value)) {
               Amount.value = 0;
           }
           
            if (RemAmt.value == "" || isNaN(RemAmt.value)) {
                RemAmt.value = 0;
            }
            
            if (CalRemAmt.value == "" || isNaN(CalRemAmt.value)) {
                CalRemAmt.value = 0;
            }
                        
            if (CalRemAmt.value != "" && Amount.value != "") 
            {           
               console.log(PaidAmount.value,"Hii1");
                console.log(RemAmt.value,"Hii2");
                console.log(Amount.value,"Hii3");
                
             if(parseFloat(Amount.value) <= parseFloat(CalRemAmt.value))
            {
               if (document.getElementById('<%= txtAmount.ClientID%>').value !=0) 
                 {
                 console.log(RemAmt.value,"gggg");
                 console.log(Amount.value,"rtrtretrt2");
                 total = parseFloat(parseFloat(CalRemAmt.value) - parseFloat(Amount.value)).toFixed(2); 
                 console.log(total,"TTT");  
                }
            else
                {
                total=0;
                 }                                 
            } 
            
             else
            {
             alert("You Can Not Enter Greater Than Outstanding Amount");
             RemAmt.value=CalRemAmt.value;  
             Amount.value=0;
                 
            }
           // document.getElementById('<%= txtRemAmt.ClientID%>').value =total;
            }
           
           
              document.getElementById('<%= txtRemAmt.ClientID%>').value =total;
            
            
            
            paisa_conver();
    }
    
    </script>

    <script type="text/javascript" language="javascript">
        function test_skill() {
            var junkVal = document.getElementById('<% =txtAmount.ClientID %>').value;
           
            var sessionHundred = '<%= Session["Hundred"] %>';
           
            junkVal = Math.floor(junkVal);
            var obStr = new String(junkVal);
            numReversed = obStr.split("");
            actnumber = numReversed.reverse();

            if (Number(junkVal) >= 0) {
                //do nothing
            }
            else {
                alert('wrong Number cannot be converted');
                return false;
            }
            if (Number(junkVal) == 0) {
                document.getElementById('<%=txtAmtinWord.ClientID %>').value = obStr + '' + 'Rupees Zero Only';
                return false;
            }
            if (actnumber.length > 9) {
                alert('Oops!!!! the Number is too big to covertes');
                return false;
            }

            var iWords = ["Zero", " One", " Two", " Three", " Four", " Five", " Six", " Seven", " Eight", " Nine"];
            var ePlace = ['Ten', ' Eleven', ' Twelve', ' Thirteen', ' Fourteen', ' Fifteen', ' Sixteen', ' Seventeen', ' Eighteen', ' Nineteen'];
            var tensPlace = ['dummy', ' Ten', ' Twenty', ' Thirty', ' Forty', ' Fifty', ' Sixty', ' Seventy', ' Eighty', ' Ninety'];

            var iWordsLength = numReversed.length;
            var totalWords = "";
            var inWords = new Array();
            var finalWord = "";
            j = 0;
            for (i = 0; i < iWordsLength; i++) {
                switch (i) {

                    case 0:
                        if (actnumber[i] == 0 || actnumber[i + 1] == 1) {
                            inWords[j] = '';
                        }
                        else {
                            inWords[j] = iWords[actnumber[i]];
                        }
                        inWords[j] = inWords[j];
                        break;
                    case 1:
                        tens_complication();
                        break;
                    case 2:
                        if (actnumber[i] == 0) {
                            inWords[j] = '';
                        }
                        else if (actnumber[i - 1] != 0 && actnumber[i - 2] != 0) {
                            inWords[j] = iWords[actnumber[i]] + ' Hundred and';
                        }
                        else {
                            inWords[j] = iWords[actnumber[i]] + ' Hundred';
                        }
                        break;
                    case 3:
                        if (actnumber[i] == 0 || actnumber[i + 1] == 1) {
                            inWords[j] = '';
                        }
                        else {
                            inWords[j] = iWords[actnumber[i]];
                        }
                        if (actnumber[i + 1] != 0 || actnumber[i] > 0) {
                            inWords[j] = inWords[j] + " Thousand";
                        }
                        break;
                    case 4:
                        tens_complication();
                        break;
                    case 5:
                        if (actnumber[i] == 0 || actnumber[i + 1] == 1) {
                            inWords[j] = '';
                        }
                        else {
                            inWords[j] = iWords[actnumber[i]];
                        }
                        if (actnumber[i + 1] != 0 || actnumber[i] > 0) {
                            inWords[j] = inWords[j] + " Lakh";
                        }
                        break;
                    case 6:
                        tens_complication();
                        break;
                    case 7:
                        if (actnumber[i] == 0 || actnumber[i + 1] == 1) {
                            inWords[j] = '';
                        }
                       else
                        {
                          inWords[j] = iWords[actnumber[i]];
                        }

                        inWords[j] = inWords[j] + " Crore";

                        break;
                    case 8:
                        tens_complication();
                        break;
                    default:
                        break;

                }
                j++;
            }

            function tens_complication() {
                if (actnumber[i] == 0) {
                    inWords[j] = '';
                }
                else if (actnumber[i] == 1) {

                    inWords[j] = ePlace[actnumber[i - 1]];
                }
                else {
                    inWords[j] = tensPlace[actnumber[i]];
                }
            }

            inWords.reverse();

            for (i = 0; i < inWords.length; i++) {
                
                finalWord += inWords[i];
               
            }
           
            return finalWord + " " + sessionHundred;
            
        }

        function paisa_conver() {
           
            var val = document.getElementById("<%= txtAmount.ClientID %>").value;
            var sessionValue = '<%= Session["DecimalPlaces"] %>';

            
            
            if (isNaN(val) || val == "" || parseInt(val) == 0) {
                document.getElementById('<%=txtAmtinWord.ClientID %>').value = "0";
            }
            else {
                var finalWord1 = test_skill();

                var finalWord2;

                if (val.indexOf('.') != -1) {
                    val = val.substring(val.indexOf('.') + 1, val.length);
             
                    document.getElementById("<%= HiddenTxtDebit.ClientID %>").value = val;
                    if (parseInt(val) == 0)
                    {
                        finalWord2 = " zero only ";
                    }
                    else {
                        if (val.length == 0) {

                            finalWord2 = " zero only ";
                        }
                        else {

                            finalWord2 = NumbertoWord() + " only ";

                        }
                    }
                }
                else
                {
                    finalWord2 = " zero only ";
                }
               
                document.getElementById('<%=txtAmtinWord.ClientID %>').value = finalWord1 + " and " + finalWord2;
            }
            
          
            
        }
        
       
    </script>

    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Search for Party :
            <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                Width="292px" AutoPostBack="True" OnTextChanged="TxtSearch_TextChanged">
              <%-- --%>
            </asp:TextBox>
            <div id="divwidth">
            </div>
            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtSearch"
                CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" MinimumPrefixLength="2">
            </ajax:AutoCompleteExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    Receipt Voucher
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <asp:UpdatePanel ID="uPanel" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <fieldset id="fieldset" runat="server" class="FieldSet">
                            <table width="100%" cellspacing="6">
                                <tr>
                                    <td class="Label">
                                        Voucher No :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVoucherNo" runat="server" CssClass="TextBox" Width="180px"></asp:TextBox>
                                    </td>
                                    <td class="Label">
                                        Date :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="TextBox" Width="180px" TabIndex="1"></asp:TextBox>
                                        <ajax:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                            TargetControlID="txtDate" PopupButtonID="ImageValid" />
                                        <asp:ImageButton ID="ImageValid" runat="server" ImageUrl="~/Images/Icon/DateSelector.png"
                                            CausesValidation="False" CssClass="Imagebutton" />
                                    </td>
                                </tr>
                                <%--<tr>
                    <td colspan="4">
                        <fieldset id="Fieldset1" class="FieldSet" runat="server">
                            <table width="100%">
                                <tr>
                                    <td width="20%">
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblCredit" runat="server" Text="Amount" CssClass="LabelBold"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td align="right">
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>--%>
                                <tr>
                                    <td class="Label" nowrap="nowrap" style="height: 22px">
                                        Property Name(Debit) :
                                    </td>
                                    <td style="height: 22px">
                                        <asp:DropDownList ID="ddlPROPERTYTo" runat="server" CssClass="ComboBox" Width="250px"
                                            OnSelectedIndexChanged="ddlPROPERTYTo_SelectedIndexChanged" AutoPostBack="true"
                                            TabIndex="4">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        <%--  <asp:TextBox ID="txtCrAmt" runat="server" CssClass="TextBoxNumeric" Width="150px"
                                onkeyup="AdjustAmount();" TabIndex="3"></asp:TextBox>--%>
                                        Received From(Credit) :
                                    </td>
                                    <td style="height: 22px">
                                        <asp:DropDownList ID="ddlReceivedFrom" runat="server" CssClass="ComboBox" Width="250px"
                                            OnSelectedIndexChanged="ddlReceivedFrom_SelectedIndexChanged" AutoPostBack="true"
                                            TabIndex="2">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label" width="100px">
                                        For The Month Of :
                                    </td>
                                    <td style="width: 377px">
                                        <asp:TextBox ID="txtMonthDate" runat="server" CssClass="TextBox" TabIndex="8" OnTextChanged="txtMonthDate_TextChanged"
                                            AutoPostBack="true"></asp:TextBox>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                            ImageUrl="~/Images/Icon/DateSelector.png" />
                                        <ajax:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender3" runat="server"
                                            Format="MMMM-yyyy" PopupButtonID="ImageButton1" TargetControlID="txtMonthDate"
                                            Enabled="True" />
                                        <%-- <asp:RequiredFieldValidator ID="ReqChequeDate" runat="server" ControlToValidate="txtMonthDate"
                            Display="None" ErrorMessage="Cheque Date Is Required" SetFocusOnError="True"
                            ValidationGroup="Add">
                        </asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="VCEChequeDate" runat="server" Enabled="True" TargetControlID="ReqChequeDate"
                            WarningIconImageUrl="~/Images/Icon/Warning.png">
                        </ajax:ValidatorCalloutExtender>--%>
                                        <asp:TextBox ID="txtUnitNO" runat="server" CssClass="Display_None" TabIndex="7" Width="250px"></asp:TextBox>
                                    </td>
                                    <td class="Label">
                                        Amount :
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtPaidAmount" runat="server" CssClass="TextBox" Width="160px" TabIndex="5"
                                            AutoPostBack="True" onKeyUp="paisa_conver();"></asp:TextBox>
                                        <%--&nbsp;<asp:Label ID="LblPaidAmt" CssClass="Label" Text="Amount In Words : " runat="server"></asp:Label>
                        <asp:TextBox
                            ID="txtPaidAmt" runat="server" BorderStyle="None" Font-Size="11px" Width="586px"
                            Enabled="false"></asp:TextBox>
                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPaidAmount"
                            ValidChars="." FilterMode="ValidChars" FilterType="Custom,Numbers">
                        </ajax:FilteredTextBoxExtender>--%>
                                        <asp:RequiredFieldValidator ID="RequpaidAmount" runat="server" ControlToValidate="txtPaidAmount"
                                            Display="None" ErrorMessage="Amount Is Required" SetFocusOnError="True" ValidationGroup="Add">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                            TargetControlID="RequpaidAmount" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <td class="Label">
                                    Paid Amount :
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtAmount" runat="server" CssClass="TextBox" Width="160px" TabIndex="5"
                                        OnTextChanged="txtAmount_TextChanged" AutoPostBack="True" onKeyUp="Calcuate_NetTotal();"></asp:TextBox>
                                    &nbsp;
                                    <asp:Label ID="lll" CssClass="Label" Text="Amount In Words : " runat="server"></asp:Label>
                                    <asp:TextBox ID="txtAmtinWord" runat="server" BorderStyle="None" Font-Size="11px"
                                        Width="586px" Enabled="false"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="FTPAmount" runat="server" TargetControlID="txtAmount"
                                        ValidChars="." FilterMode="ValidChars" FilterType="Custom,Numbers">
                                    </ajax:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="RequAmount" runat="server" ControlToValidate="txtAmount"
                                        Display="None" ErrorMessage="Amount Is Required" SetFocusOnError="True" ValidationGroup="Add">
                                    </asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                        TargetControlID="RequAmount" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                    </ajax:ValidatorCalloutExtender>
                                </td>
                                <tr>
                                    <td class="Label" nowrap="nowrap">
                                        Remaing Amount :
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtRemAmt" runat="server" CssClass="TextBox" Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        For :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNarration" CssClass="TextBox" runat="server" TextMode="MultiLine"
                                            Width="250px" TabIndex="6"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtRemAmountCal" runat="server" CssClass="display_none" Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="Display_None">
                                        <asp:Label ID="l1" Text="Total Amount : " runat="server" Font-Bold="true" Font-Size="14px"></asp:Label>
                                        <asp:TextBox ID="txtDiffAmt" Font-Size="14px" ForeColor="Blue" Font-Bold="true" ReadOnly="true"
                                            runat="server" AutoPostBack="true" Height="30px" Width="192px"></asp:TextBox>&nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <ajax:RoundedCornersExtender ID="RCE2" runat="server" TargetControlID="fieldset"
                            Color="Black" Enabled="True" BorderColor="Black" Radius="10">
                        </ajax:RoundedCornersExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <fieldset id="fieldset1" runat="server" class="FieldSet">
                            <table width="100%" align="center">
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="button" ValidationGroup="Add"
                                            TabIndex="22" OnClick="BtnUpdate_Click" />
                                        <%-- OnClick="BtnUpdate_Click"--%>
                                        <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" ValidationGroup="Add"
                                            TabIndex="22" OnClick="BtnSave_Click" />
                                        <%-- --%>
                                        <asp:Button ID="BtnPrint" runat="server" CssClass="button" OnClientClick="aspnetForm.target ='_blank';"
                                            TabIndex="23" Text="Print" ValidationGroup="Add" Visible="false" />
                                        <%--  OnClick="BtnPrint_Click"--%>
                                        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="False"
                                            TabIndex="24" />
                                        <%-- OnClick="BtnCancel_Click"--%>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <ajax:RoundedCornersExtender ID="RCE" runat="server" TargetControlID="fieldset1"
                            Color="Black" Enabled="True" BorderColor="Black" Radius="10">
                        </ajax:RoundedCornersExtender>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel_GrdReport" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GrdReport" runat="server" AllowPaging="True" AlternatingRowStyle-CssClass="alt"
                                    AutoGenerateColumns="False" CssClass="mGrid" GridLines="None" PagerStyle-CssClass="pgr"
                                    Width="100%" OnRowCommand="GrdReport_RowCommand" OnRowDeleting="GrdReport_RowDeleting"
                                    OnPageIndexChanging="GrdReport_PageIndexChanging">
                                    <%--OnRowCommand="GrdReport_RowCommand" OnRowDeleting="GrdReport_RowDeleting"
                                    OnPageIndexChanging="GrdReport_PageIndexChanging"
                                    OnRowDataBound="GrdReport_RowDataBound"--%>
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnEdit" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                                    CommandArgument='<%# Eval("#") %>' CommandName="Select" ImageUrl="~/Images/Icon/GridEdit.png"
                                                    TabIndex="62" ToolTip="Edit Record" />
                                                <asp:ImageButton ID="ImgBtnDelete" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                                    CommandArgument='<%# Eval("#") %>' CommandName="Delete" ImageUrl="~/Images/Icon/GridDelete.png"
                                                    TabIndex="62" ToolTip="Delete Record" />
                                                <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete This Record?"
                                                    TargetControlID="ImgBtnDelete">
                                                </ajax:ConfirmButtonExtender>
                                                <a href='../PrintReport/PrintReports.aspx?ID=<%# Eval("#")%>&amp;Flag=<%="ReceiptMaster"%>'
                                                    target="_blank">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icon/GridPrint.png" TabIndex="62"
                                                        ToolTip="Print Receipt" />
                                                </a>
                                                <%--  <asp:ImageButton ID="ImgNMail" runat="server" CommandArgument='<%# Eval("#") %>'
                                                                    CommandName="MailPO" ImageUrl="~/Images/Icon/Email-Blue.jpg" ToolTip="Mail Receipt" />--%>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("#") %>'
                                                    CommandName="Email" CssClass="Imagebutton" ImageUrl="~/Images/Icon/Grid-e-mail.png"
                                                    TabIndex="1" ToolTip="Email Receipt" />
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="LblSrNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Width="7%" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Receipt No" DataField="ReceiptNo">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="ReceiptDate" DataField="ReceiptDate">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="PartyName" DataField="PartyName">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="PartyEmailId" DataField="Email">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Property" DataField="Property">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="UnitNo" DataField="UnitNo">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="ForTheMonth" DataField="ForTheMonth">
                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="VoucherAmt" DataField="VoucherAmt">
                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
