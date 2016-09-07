<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MusicPlayer.aspx.cs" Inherits="MusicPlayer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <!-- Quelques styles CSS -->
    <style type="text/css">
        html {
            font-family: "Myriad","Myriad Pro",Georgia,Helvetica,Sans-serif;
            background: url(dewplayer/zdewplayer.jpg) no-repeat bottom right;
            height: 100%;
            padding: 0;
            margin: 0;
        }

        body {
            height: 100%;
            padding: 0;
            margin: 0;
        }

        h1 {
            color: #eee;
            padding-top: 3em;
            padding-bottom: 2em;
            margin: 0;
        }

        #content {
            margin-left: 15%;
            width: 500px;
            text-align: center;
        }

        #hint {
            color: #666;
            margin-left: 15%;
            width: 300px;
            text-align: left;
            margin-top: 3em;
        }
    </style>

    <script src="dewplayer/swfobject.js" type="text/javascript">
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label" ViewStateMode="Disabled" ForeColor="White"></asp:Label>
            <h1>

            <asp:Literal ID="Literal1" runat="server"></asp:Literal>

           
        </div>
    </form>
</body>
</html>
