<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">        
        canvas{z-index:-1;position:absolute;}
    </style>
    <link href="../style.css" rel="stylesheet" type="text/css" />
    <link href="../login.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="../js/Particleground.js" type="text/javascript"></script> 
    <script type="text/javascript">
        $(document).ready(function () {
            //粒子背景特效
            $('body').particleground({
                dotColor: '#cccccc',
                lineColor: '#cccccc'
            }); 
        });
</script>
</head>
<body>
    <form id="form1" runat="server">
            <div id="login">
                <div style="width:250px;padding-top:30px;">
                    <span style="font-weight:bold;text-align:left;color:white;font-size:22px;">LOGIN</span>
                </div><br /><br />
                <div style="clear:both;"></div>
                <div id="content">
                    <asp:TextBox ID="TextBox1" runat="server" Height="25px" Width="220px" Wrap="False" BorderStyle="None" Font-Bold="True">&nbsp;User</asp:TextBox><br /><br />
                    <asp:TextBox ID="TextBox2" runat="server" Height="25px" Width="220px" 
                        Wrap="False" BorderStyle="None" Font-Bold="True">&nbsp;Password</asp:TextBox><br /><br />                   
                    <%--验证码--%>
                    <div id="validator">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                            <Services>
                                <asp:ServiceReference Path="../RandomService.asmx"/>
                            </Services>                            
                        </asp:ScriptManager>                        
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" BorderStyle="None" Font-Bold="True"  Width="100px" Height="31px" style="float:left;"></asp:TextBox>
                                <asp:Button ID="compare" runat="server" Text="获取验证码"  BackColor="#12182c" 
                                    Font-Bold="True" ForeColor="White" Height="31px" Width="100px"  
                                    style="float:right;" BorderStyle="None" onclick="compare_Click"/>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br /><br />
                    </div><br />
                    <asp:Button ID="Button1" runat="server" Text="Login" BackColor="#12182c" Font-Bold="True" ForeColor="White" Height="31px" Width="220px" BorderStyle="None" OnClick="Button1_Click" /><br/><br/>
                    <a href="../register.aspx">Register</a><br />
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#CF0606"></asp:Label><br />
                </div>
            </div>
    </form>
</body>
</html>
