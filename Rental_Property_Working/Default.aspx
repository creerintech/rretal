<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Login"
    Title="Welcome to RevoDynamics" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
  <link rel="icon" href ="Images/MasterPages/Revodynamics-Icon1-large.ico"/> 

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LOGIN</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="StyleSheet/style.css" />
    <link rel="stylesheet" type="text/css" href="StyleSheet/MenuStyle.css" />
    <style type="text/css">
        #mydiv
        {
            position: absolute;
            top: 100px;
            left: 80%;
            width: 41.8em;
            height: 17.6em;
            margin-top: -9em; /*set to a negative number 1/2 of your height*/
            margin-left: -15em; /*set to a negative number 1/2 of your width*/
            border: 0px solid #FFFFFF;
            background-color: #FFFFFF;
        }
        .water
        {
            color: Gray;
        }
        
        .page
         {
           
            background-image:url('Images/Login/bkgimg2.jpg');
            position: relative;
            z-index:1;
            width:960px;
            margin: -5px auto 0px auto;
            min-height:765px;
            
        }
    </style>

    <script type="text/javascript">
        window.history.forward();
        function noBack() { window.history.forward(); }
    </script>

    <script type="text/javascript">
        function changeHashOnLoad() {
            window.location.href += "#";
            setTimeout("changeHashAgain()", "50");
        }

        function changeHashAgain() {
            window.location.href += "1";
        }

        var storedHash = window.location.hash;
        window.setInterval(function() {
            if (window.location.hash != storedHash) {
                window.location.hash = storedHash;
            }
        }, 50);


    </script>

</head>
<body onload="changeHashOnLoad();" style="vertical-align:central;");
    background-attachment: fixed">
    <style type="text/css">
        body
        {
            overflow: hidden;
        }
    </style>
    <%-- <onpageshow="if (event.persisted) noBack();" onunload=""></onpageshow>--%>
    <form id="form1" runat="server">

    <script language="javascript" type="text/javascript">
        function ClickDoneBtn40() {
            var key = window.event.keyCode;
            if (key == 145) {
                var _TxtValue = document.getElementById('<%= LBLSERIALNO.ClientID %>');
                alert(_TxtValue.value);
            }
            else {

            }
        }

        document.send.inputText.onkeypress = function(event) {
            var key = window.event.keyCode;
            if (key == 145) {
                var _TxtValue = document.getElementById('<%= LBLSERIALNO.ClientID %>');
                alert(_TxtValue.value);
            }
            else {

            }
        };
    </script>

    <div class="page">
        <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div id="progressBackgroundFilter">
                </div>
                <div id="processMessage">
                    <center>
                        <span class="SubTitle">Loading....!!! </span>
                    </center>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icon/updateprogress.gif"
                        Height="20px" Width="120px" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <fieldset style="width: 100%; height: 110%; background-repeat: inherit; border: 0px"
            id="FS" runat="server">
            <%--  <div>--%>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        <table border="0" cellpadding="0" cellspacing="8">
                            <tr>
                                <td colspan="3" align="right">
                                    <img src="Images/MasterPages/Revodynamic.png" width="200px" height="90px"></img>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    &nbsp;
                                </td>
                            </tr>
                          
                            <tr>
                                <%--<td class="LabeLog">
                                    User Name :
                                </td>--%>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="TxtUserName" runat="server" Width="200px" CssClass="TextBoxLOGIN"
                                        Height="20px" onkeyup="ClickDoneBtn40();"></asp:TextBox>
                                    <ajax:RoundedCornersExtender ID="RoundedCornersExtender4" runat="server" TargetControlID="TxtUserName"
                                        Corners="All" Radius="8" BorderColor="Gray">
                                    </ajax:RoundedCornersExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtUserName"
                                        Display="None" ErrorMessage="User Name Required" SetFocusOnError="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                        TargetControlID="RequiredFieldValidator1" WarningIconImageUrl="~/Images/Icon/Warning.png"
                                        PopupPosition="BottomRight">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="TxtUserName"
                                        WatermarkText="User Name" WatermarkCssClass="water" />
                                </td>
                            </tr>
                            <tr>
                                <%-- <td class="LabeLog">
                                    Password :
                                </td>--%>
                                <td colspan="3">
                                    <asp:TextBox ID="TxtPass" runat="server" Width="200px" TextMode="Password" Height="20px"
                                        CssClass="TextBoxLOGIN"></asp:TextBox>
                                    <ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="TxtPass"
                                        Corners="All" Radius="8" BorderColor="Gray">
                                    </ajax:RoundedCornersExtender>
                                    <asp:RequiredFieldValidator ID="Req1" runat="server" ControlToValidate="TxtPass"
                                        Display="None" ErrorMessage="Password Required" SetFocusOnError="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                        TargetControlID="Req1" WarningIconImageUrl="~/Images/Icon/Warning.png" PopupPosition="BottomRight">
                                    </ajax:ValidatorCalloutExtender>
                                    <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="TxtPass"
                                        WatermarkText="Password" WatermarkCssClass="water" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabeLog">
                                </td>
                                <td align="right">
                                    <asp:Button ID="BtnLogin" runat="server" Text="Login" ValidationGroup="Add" BorderColor="WhiteSmoke"
                                        BackColor="#000066" EnableTheming="False" ForeColor="White" Height="30px" Width="70px"
                                        Font-Bold="true" OnClick="BtnLogin_Click" />
                                    <ajax:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" TargetControlID="BtnLogin"
                                        Corners="All" Radius="8" BorderColor="Orange">
                                    </ajax:RoundedCornersExtender>
                                </td>
                                <td align="right">
                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" BorderColor="WhiteSmoke"
                                        Font-Bold="true" OnClick="BtnCancel_Click" BackColor="#000066" ForeColor="White"
                                        Height="30px" Width="70px" />
                                    <ajax:RoundedCornersExtender ID="RoundedCornersExtender5" runat="server" TargetControlID="BtnCancel"
                                        Corners="All" Radius="8" BorderColor="Orange">
                                    </ajax:RoundedCornersExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="LabeLog">
                                </td>
                                <td>
                                    <asp:TextBox ID="LBLSERIALNO" runat="server" Enabled="false" CssClass="Display_None"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <%-- </div>--%>
        </fieldset>
        <%--  <ajax:DropShadowExtender ID="dse" runat="server" TargetControlID="FS" Opacity=".6"
            Rounded="true" TrackPosition="true" />
        <ajax:RoundedCornersExtender ID="RoundedCornersExtender6" runat="server" TargetControlID="FS"
            Corners="All" Radius="19" BorderColor="Gray">
        </ajax:RoundedCornersExtender>--%>
    </div>
    
    </form>
</body>
</html>
