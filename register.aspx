<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>注册</title>
    <style type="text/css">        
        canvas{z-index:-1;position:absolute;}
    </style>
    <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="register.css" rel="stylesheet" type="text/css" />
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
        <div>
            <div id="login">
                <div style="width:250px;padding-top:30px;">
                    <span style="font-weight:bold;text-align:left;color:white;font-size:22px;">REGISTER</span>
                </div><br /><br />
                <div style="clear:both;"></div>
                <div id="content">
                    <%--用户名 --%>
                    <asp:TextBox ID="TextBox1" runat="server" Height="25px" Width="220px" Wrap="False" BorderStyle="None" Font-Bold="True">&nbsp;User</asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户名不能为空" ForeColor="#CF0606" Font-Size="10pt" ControlToValidate="TextBox1">
                    </asp:RequiredFieldValidator><br />
                    <%--密码 --%>
                    <asp:TextBox ID="TextBox2" runat="server" Height="25px" Width="220px" Wrap="False" BorderStyle="None" Font-Bold="True">&nbsp;Password</asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="密码不能为空" ForeColor="#CF0606" Font-Size="10pt" ControlToValidate="TextBox2"></asp:RequiredFieldValidator><br />
                    <%--再次密码--%>
                    <asp:TextBox ID="TextBox3" runat="server" Height="25px" Width="220px" Wrap="False" BorderStyle="None" Font-Bold="True">&nbsp;Password Again</asp:TextBox><br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="输入密码不一致" ForeColor="#CF0606" Font-Size="10pt" ControlToValidate="TextBox3" ControlToCompare="TextBox2"></asp:CompareValidator><br/><br/><br />
                    <asp:Button ID="Button1" runat="server" Text="Register" BackColor="#12182c" Font-Bold="True" ForeColor="White" Height="31px" Width="220px" BorderStyle="None" OnClick="Button1_Click" /><br/>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#CF0606"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
