<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenustripDemobyAnkush.ascx.cs"
    Inherits="Controls_MenustripDemobyAnkush" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<nav>
	<ul>
		<li><a href="../Masters/Home.aspx">Home</a></li>		
		<li><a  href="#">Masters</a>
			<ul>
			 <li><a href="#">Users</a>
			      <ul>
			    <%--  <li><a href="../Masters/EmployeeMaster.aspx">Employee Master</a></li>	
			      <li><a href="../Masters/UserMaster.aspx">User Master</a></li>--%>
			      </ul>
			      </li>
			 <li><a id="A1" href="#" runat="server">Project</a>
		     <ul>
		          <%--<li><a href="../Masters/ProjectType.aspx">Project Type</a></li>
			      <li><a href="../Masters/ProjectSubType.aspx">Project Sub Type</a></li>
			      <li><a href="../Masters/FlatType.aspx">Unit Type</a></li>	
			      <li><a href="../Masters/ProjectStages.aspx">Project Stages</a></li>	
			      <li><a href="../Masters/ProjectConfigurator1.aspx">Project Configurator</a></li>
			      <li><a href="../Masters/FlatLayoutUpload.aspx">Upload Flat Layout</a></li>
                  <li><a href="../Transactions/CompletionCertificateUpdate.aspx">Completion Certificate Update</a></li>--%>
		    </ul>
		    </li>
		  <li><a id="A3" href="#" runat="server">Charges</a>
		  <ul>
		 <%-- <li>
		  <a href="../Transactions/PaymentScheduleTemplate.aspx">Payment Schedule Template</a></li>			
			    <li><a href="../Masters/ChargesGroupMaster.aspx">Charges Group Type</a></li>	
				<li><a href="../Masters/ChargesTypeNew.aspx">Charges Sub Type</a></li>								
				<li><a href="../Masters/ProjectChargeTemplate.aspx">Project Charges Template</a></li>		            
	            <li><a href="../Masters/TaxTemplate.aspx">Tax Template Master</a></li>	--%>
		  </ul>
		  </li>
		    <li><a id="A4" href="#" runat="server">Parking</a>
		  <ul>
		  	<%--<li><a href="../Masters/ParkingTypeMaster.aspx">Parking Type</a></li>
				<li><a href="../Masters/ParkingSubTypeMaster.aspx">Parking Sub Type</a></li>
                <li><a href="../Masters/Parking_config.aspx">Parking Configurator</a></li>			
			    <li><a href="../Masters/ParkingGroupMaster.aspx">Parking Group Master</a></li>	--%>
		  </ul>
		  </li>
		 <li><a id="A5" href="#" runat="server">Customers</a>
		  <ul>
		<%-- <li>
		 <a href="../Masters/Salutation.aspx">Salutation Master</a></li>
				 <li>
				 <a href="../Masters/CustomerMaster.aspx">Customer Master</a></li>	--%>
		  </ul>
		  </li>
		   <%--<li>
		   <a href="../Masters/BrokerMaster.aspx">Broker Master</a></li>	
                <li><a href="../Masters/BankMaster.aspx">Bank Master</a></li>	--%>
				 <li><a id="A2" href="#" runat="server">Documents</a>
		  <ul>
		<%--<li><a href="../Masters/Possession.aspx">Possession</a></li>	
		<li><a href="../Masters/AmenityMaster.aspx">List Of Amenities</a></li>
				<li><a href="../Masters/SpecificationMaster.aspx">List Of Specifications</a></li>
				<li><a href="../Masters/DocumentCheckList.aspx">List Of Document</a></li>--%>
		  </ul>
		  </li>		    				
			<%-- <li><a href="../Masters/FollowUpMaster.aspx">Follow Up Register</a></li>				    
			    <li><a href="../Masters/IssueSubject.aspx">Issue Subject Master</a></li>	
			    <li><a href="../Masters/TermsConditions.aspx">Terms & Condition Master</a></li>	 	
			   --%>
			 
			    
			    
			  
				
			    		
											     
			 	
			
			
		
			
			
				
				
			</ul>
		</li>
		<li><a href="#">Transactions</a>
			<ul>
			<%--	<li><a href="../Transactions/EnquiryForm.aspx">Enquiry Form</a></li>
			<li><a href="../Transactions/FollowUpDetails.aspx">Enquiry Follow Up Details</a></li>
				
			<li><a href="../Transactions/BookingForm.aspx">Booking Form</a></li>          
			<li><a href="../Transactions/ReceiptEntry.aspx">Receipt Voucher</a></li>
		
			<li><a href="../Transactions/DemandLetterGeneration.aspx">Demand Letter Generation</a></li>
			<li><a href="../Transactions/SendEmailSms.aspx">Send Email/Sms</a></li>
			<li><a href="../Transactions/PaymentFollowUp.aspx">Payment Follow Up Details</a></li>
			<li><a href="../Transactions/TaskListNew.aspx">Task List Master</a></li>
			<li><a href="../Transactions/CustomerGrievance.aspx">Customer Grievance Master</a></li>--%>
			
				
			</ul>
		</li>
		
		
		<li><a href="#">Reports</a>
		<ul>
		<%--<li><a href="../MIS/DailyBalanceFIFO.aspx">Daily Balance FIFO</a></li>			
			<li><a href="../MIS/ListOfEnquiries.aspx">List Of Enquiries</a></li>			
			<li><a href="../MIS/FollowUpReport.aspx">Enquiry Follow Up Report</a></li>		
			<li><a href="../MIS/ListOfBooking.aspx">List Of Bookings</a></li>
			<li><a href="../MIS/ListOfCancellations.aspx">List Of Cancellations</a></li>
			<li><a href="../MIS/ListOfReceipts.aspx">List Of Receipts</a></li>
			<li><a href="../MIS/PaymentFollowUp.aspx">Payment Follow Up Report</a></li>
			<li><a href="../MIS/RevenueDetails.aspx">Revenue Details Report</a></li>
			<li><a href="../MIS/MonthlyRevenue.aspx">Monthly Revenue Details Report</a></li>
			<li><a href="../MIS/WIPUpdateHistory.aspx">WIP Update History</a></li>
			<li><a href="../MIS/ListOfDemandLettersGenerated.aspx">List Of Demand Letters Generated</a></li>
			<li><a href="../MIS/CustomerGrievanceReport.aspx">Customer Grievance Report</a></li>
		
			<li><a href="../MIS/InventoryOfUnits.aspx">Inventory of Units</a></li>
			<li><a href="../MIS/InventoryofTower.aspx"> Tower Wise Detailed Report</a></li>
			<li><a href="../MIS/SalesComparision.aspx">Sales Comparision Report</a></li>
			<li><a href="../MIS/AvgSaleReport.aspx">Average Sales Report</a></li>
			<li><a href="../MIS/ProjectComparision.aspx">Project Comparision Report</a></li>
			<li><a href="../MIS/ProjectStatusReport.aspx">Project Status Report</a></li>
			<li><a href="../MIS/TESTREPORT.aspx">Availability Chart</a></li>
			<li><a href="../MIS/ProjectWiseRevenue.aspx">Project Wise Status Report</a></li>
			<li><a href="../MIS/ProjectWiseDemandDue.aspx">Total Revenue Due Project Wise</a></li>
			<li><a href="../MIS/MonthWiseRevenueCollection.aspx">Revenue Per Month Vs Revenue Collection</a></li>--%>
		</ul>
		</li>
	
	    <li><a href="../Masters/ContactUs.aspx">Contact Us</a></li>
		
			
	</ul>
</nav>
