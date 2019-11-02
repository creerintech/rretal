<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintMIS.aspx.cs" Inherits="Reports_PrintMIS" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <link rel="icon" href ="../Images/MasterPages/Revodynamics-Icon1-large.ico"/> 
    <title>Print MIS</title>

    <script type="text/javascript">
    function fixform() 
    {
        if (opener.document.getElementById("aspnetForm").target != "_blank") return;
        opener.document.getElementById("aspnetForm").target = "";
        opener.document.getElementById("aspnetForm").action = opener.location.href;      
    }
    </script>

</head>
<body onload="fixform();">
    <form id="form1" runat="server">
    <div>
        <center>
            <CR:CrystalReportViewer ID="CRPrint" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="false"
                EnableParameterPrompt="false" ReuseParameterValuesOnRefresh="true"  />
        </center>
    </div>
    </form>
</body>
</html>
