<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu1.ascx.cs" Inherits="Controls_Menu1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!-- Navigation -->
<link href="../StyleSheet/NewMenuStyle.css" rel="stylesheet" type="text/css" />

<script src="../Jscript/jquery.js" type="text/javascript" />

<script type="text/javascript" src="../Jscript/js.js"></script>

<div id="menu">
    <ul class="menu">
        <%--<li><a href="../Masters/Home.aspx" class="parent"><span>Home</span></a></li>--%>
        <li><a href="../Masters/DashBoard.aspx"><span>Dashboard</span></a></li>
        <li><a href="#" class="parent"><span>Masters</span></a>
            <ul>
                <li><a href="../Masters/UserMaster.aspx">User Master</a></li>
                <li><a href="../Masters/CompanyMaster.aspx">Company Master</a></li>
                <li><a href="../Masters/PartyMaster.aspx">Party Master</a></li>
                   <li><a href="../Masters/FlatType.aspx">Unit Type</a></li>
                
                      <li><a href="../Masters/ExpenseHeadNewMaster.aspx">Expense Head Master</a></li>
                      <li><a href="../Masters/ExpensePartyMaster.aspx">Expense Party Master</a></li>
                      <li><a href="../Masters/CityMaster.aspx">City Master</a></li>
                              <li><a href="../Masters/LocationMaster.aspx">Location Master</a></li>
                                   <li><a href="../Masters/PropertyTypeMaster.aspx">Property Type Master</a></li>
                                    <li><a href="../Masters/PropertySubTypeMaster.aspx">Property Sub Type Master</a></li>
                     <li><a href="../Masters/SalutationMaster.aspx">Salutation Master</a></li>
                           <li><a href="../Masters/TaxMaster.aspx">Tax Master</a></li>
                            
                       <li><a href="../Masters/Property.aspx">Property Master</a></li>
                
            <%--    <li><a href="../Masters/ExpenceHeadMaster.aspx">Expense Head Master</a></li>--%>
            </ul>
        </li>
        <li><a href="#" class="parent"><span>Transactions</span></a>
            <ul>
                <li><a href="../Masters/ProjectConfigurator1.aspx">Property Rental Card</a></li>
                <li><a href="../Transactions/PropertyMaintance.aspx">Property Maintenance</a></li>
                <li><a href="../Transactions/ExpenseRegister.aspx">Expense Register</a></li>
                 <li><a href="../Transactions/ExpenseOutstanding.aspx">Expense Outstanding</a></li>
                <li><a href="../Transactions/ReceiptEntry.aspx">Receipt Voucher</a></li>
                <li><a href="../Transactions/ReceiptForExpOutstanding.aspx">Receipt For Expense Outstanding</a></li>
            </ul>
        </li>
        <li><a href="#" class="parent"><span>Reports</span></a>
            <ul>
                <li><a href="../MIS/RptListOfProperty.aspx">List Of Property</a></li>
                <li><a href="../MIS/RptPropertyOnRent.aspx">List Of Property On Rent</a></li>
                <li><a href="../MIS/RptRentToBeExpired.aspx">Property Rent Expired Details</a></li>
                 <li><a href="../MIS/RptMaintenanceRegister.aspx">Maintenance Register Details</a></li>
                   <li><a href="../MIS/ListOfReceipts.aspx">List Of Receipts</a></li>
                     <li><a href="../MIS/RptExpense.aspx">Expense Register Details</a></li>
                     <li><a href="../MIS/outstanding_reportaspx.aspx">Outstanding Receivable Report</a></li>
            </ul>
        </li>
        <li class="last"><a href="../Masters/ContactUs.aspx"><span>Contact Us</span></a></li>
    </ul>
</div>
