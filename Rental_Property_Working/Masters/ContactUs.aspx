<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="Masters_ContactUs" Title="Contact Us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" Runat="Server">
<table width="100%">
<tr>
<td >
<iframe width="580" height="600" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.co.in/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=RevoSolution,+Wanwadi,+Pune,+Maharashtra&amp;aq=0&amp;oq=revoso&amp;sll=18.497892,73.845647&amp;sspn=0.108745,0.110378&amp;ie=UTF8&amp;hq=RevoSolution,&amp;hnear=Wanwadi,+Pune,+Maharashtra&amp;ll=18.49125,73.900433&amp;spn=0.007496,0.006295&amp;t=m&amp;output=embed"></iframe><br /><small><a href="https://maps.google.co.in/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=&amp;q=RevoSolution,+Wanwadi,+Pune,+Maharashtra&amp;aq=0&amp;oq=revoso&amp;sll=18.497892,73.845647&amp;sspn=0.108745,0.110378&amp;ie=UTF8&amp;hq=RevoSolution,&amp;hnear=Wanwadi,+Pune,+Maharashtra&amp;ll=18.49125,73.900433&amp;spn=0.007496,0.006295&amp;t=m" style="color:#0000FF;text-align:left">View Larger Map</a></small>
</td>
<td valign="top" align="left">
    <asp:Label ID="Label1" runat="server" Text="Revosolution" CssClass="LabelContact"></asp:Label>
    <br />
    <br />
      <asp:Label ID="Label2" runat="server" Text="SB 504,Sacred World,Wanowrie,Pune 411 040." CssClass="LabelInv"></asp:Label>
        <br />
    <br />
      <asp:Label ID="Label3" runat="server" Text="Tel: +91-020-40055251" CssClass="LabelInv"></asp:Label>
        <br />
    <br />
      <asp:Label ID="Label4" runat="server" Text="Email: revosolutionpune@yahoo.com" CssClass="LabelInv"></asp:Label>
</td>
</tr>
</table>
</asp:Content>

