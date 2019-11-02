<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderLogo.ascx.cs" Inherits="Controls_HeaderLogo" %>

 <!-- Header -->
   <div class="header">
			<div class="top_info">			
				<div class="top_info_right">
					<p><b>Welcome : <asp:Label ID="Label1" runat="server" oninit="Label1_Init" CssClass="LabelLoginName"></asp:Label></b><br />
					Do you want to <a href="../Masters/ChangePassword.aspx">Change Password</a> ? </p>
					<p>Back To <a href="../Masters/HomeNew.aspx">Home</a> or 
					<asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" CssClass="LabelLoginName">Logout</asp:LinkButton>
            </p>			    
				</div>						
				<div class="top_info_left">
				<h2><a href="../Default.aspx" title="Build Time"><span class="green"><br/><span class ="align"></span></a></h2>
					<%--<p><b>17. Sep, 2012</b> - Monday<br />
					Check todays <a href="#">Estimate's</a> or <a href="#">Job Card's</a></p>--%>
				</div>				
			</div>			
			<div class="logo">
			    <a href="javascript:void(0);"><img src="../Images/MasterPages/Revodynamic.png" alt="" title="" /></a>				
			</div>
		</div><!-- /header -->