<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_Old.aspx.cs" Inherits="_Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BuildTime - Login</title>
     <link rel="stylesheet" type="text/css" href="StyleSheet/StyleSheet.css"/>
     <link rel="stylesheet" type="text/css" href="StyleSheet/style.css"/>
    <style type="text/css">
        .style1
        {
            height: 211px;
        }
    </style>
      <%--Logo For WebSite--%>       
    <link rel="icon" href ="Images/Icon/Rupees.png"/> 
    <%--Logo For WebSite--%>  
</head>
<body>
    <form id="form1" runat="server" >
    <div>
     <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <table width="100%">
        <tr>
            <td class="style1" >
                </td>
        </tr>
        <tr>
            <td  align="center" style="height: 114px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" >
            <ProgressTemplate>            
           <%-- <div id="progressBackgroundFilter"></div>
                                <div id="processMessage">   
                                <center><span class="SubTitle">Loading....!!! </span></center>
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icon/updateprogress.gif" />                                
            </div>--%>
            </ProgressTemplate>
            </asp:UpdateProgress>
            <fieldset style="width: 30%; background-image: url('Images/MasterPages/background.jpg');">
            <table  width="100%">
            <tr >
            <td colspan="3">
            <table>
            <tr>
            <td>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Revodynamic.png" />
            </td>
            <td>
            <h1>
                    <span class="green">BUILDTIME</span></h1>
            </td>
            
            </tr>
            </table>
             
                
                <%--<h1>BUILDTIME</h1>--%>
            </td>
            </tr>
            <tr >
            <td > &nbsp;</td>
            <td colspan="2" > &nbsp;</td>
            </tr>
            <tr >
            <td style="padding-left: 9px"><h3> User Name </h3></td>
            <td class="SubTitle" colspan="2"> 
                <h3>
                    Password
                </h3>
                </td>
            </tr>
            <tr >
            <td style="padding-left: 7px" > 
                <asp:TextBox ID="txtUser" runat="server" Width="192px" CssClass="LoginText"></asp:TextBox>
             </td>
            <td colspan="2" > 
                <asp:TextBox ID="txtPass" runat="server" CssClass="LoginText" 
                    TextMode="Password" Width="192px"></asp:TextBox>
                </td>
            </tr>
            <tr >
            <td style="padding-left: 9px" > 
                <asp:RequiredFieldValidator ID="Rqv1" runat="server" 
                    ControlToValidate="txtUser" ErrorMessage="Valid User Name required.!" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            <td colspan="2" > 
                <asp:RequiredFieldValidator ID="Rqv2" runat="server" 
                    ControlToValidate="txtPass" ErrorMessage="Valid Password required.!" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr >
            <td align="right" colspan="3" > 
                <asp:Button ID="btnLogin" runat="server" CssClass="button" 
                    onclick="btnLogin_Click" Text="Login" />
                </td>
            </tr>
            <tr >
            <td > &nbsp;</td>
            <td > &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            </tr>
            </table>
               
            </fieldset>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
