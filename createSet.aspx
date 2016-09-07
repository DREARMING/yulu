<%@ Page Title="" Language="C#" MasterPageFile="~/TopFoot.master" AutoEventWireup="true" CodeFile="createSet.aspx.cs" Inherits="createSet" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="createSet.css" rel="stylesheet" type="text/css" />
<script type="application/javascript" src="js/jquery-1.11.3.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        var rbl = $("input:radio");
        var share = $("#share > div");
        var booktop = $("#topImg");
        for (var i = 0; i < rbl.length; i++) {
            if (rbl[i].checked) {
                share.eq(i).show().siblings().hide();
                if (i == 0) $("#topImg").attr("src", "images/bookset.png");
                if (i == 1) booktop.attr("src", "images/movieset.png");
                if (i == 2) booktop.attr("src", "images/musicset.png"); 
            }
        }
    });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="width:1280px;">
    <%-- 中间主要内容--%>
    <div id="main_content">
        <div id="left">
            <div style="padding:10px 20px; background-image: url('pictures/opacitybgcol.png');">
                 <img src="pictures/down.png" alt="" width="25px";height="25px"/>
                 <span style="margin-left:40px; ">创建语录集</span>
            </div>                     
            <div id="createSet">
                 <div id="createContent">
                    <div>标题：<asp:TextBox ID="TextBox1" runat="server" style="background-color:#04223a;" BorderStyle="None" Height="35px" Width="220px" ForeColor="White"></asp:TextBox></div>
                    <div id="alongclass">
                        <div style="float:left;">所属类别：</div>
                            <div style="float:right;margin-right:180px;"><asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                            RepeatDirection="Horizontal"
                            AutoPostBack="True" CellSpacing="10" >
                            <asp:ListItem Selected="True">书本</asp:ListItem>  <asp:ListItem>电影</asp:ListItem>  <asp:ListItem>歌曲</asp:ListItem></asp:RadioButtonList>
                         </div>
                    </div>
                    <div style="padding-right:90px;">

                         <div style="float:left;">
                               <span style="vertical-align:top;">封面：</span><span><img src='<%=imgurl %>' alt="sorry" width="125" height="150" /></span>
                        </div>
                       
                        <div style="float:right;">
                            <div style="font-size:12pt;margin:20px 0 40px 10px;">最佳尺寸：300*300 px<br />支持JPG、JPEG、GIF,大小不超过1MB </div>
                            <div>
                                <asp:FileUpload ID="FileUploadImg"  runat="server" BackColor="#04223A" ForeColor="White" Height="40px" Width="200px" />
                                <asp:Button ID="Button1" runat="server" Text="上传" BorderStyle="None"  Height="35px" 
                                    Font-Names="楷体" Font-Size="14pt" ForeColor="White" 
                                    style="background-image:url('pictures/btnbg.png')" BackColor="#19A7CF" 
                                     OnClick="Button1_Click"/>
                            </div>
                            
                        </div> 
                           

                    </div>                        
                    <div style="clear:both;margin:270px 0 40px 0"><span style="vertical-align:top;">简介：</span><asp:TextBox ID="TextBox2" runat="server" style="background-color:#04223a;" BorderStyle="None" Height="125px" Width="445px" ForeColor="White" TextMode="MultiLine"></asp:TextBox></div>
                    <div id="share" style="position:relative;">
                        <div style="position:absolute;z-index:1;display:none;">书籍购买链接：<asp:TextBox ID="TextBox3" runat="server" style="background-color:#04223a;" BorderStyle="None" Height="35px" Width="350px" ForeColor="White"></asp:TextBox></div>
                        <div style="position:absolute;z-index:2;display:none;">电影观看链接：<asp:TextBox ID="TextBox4" runat="server" style="background-color:#04223a;" BorderStyle="None" Height="35px" Width="350px" ForeColor="White"></asp:TextBox></div>
                        <div style="position:absolute;z-index:3;display:none;">上传歌曲(仅限MP3)：
                            <asp:FileUpload ID="FileUpload1" runat="server" BackColor="#04223A" ForeColor="White" Height="40px" Width="250px" /> 
                            <asp:Button ID="Button3" runat="server" Text="上传" BorderStyle="None"  Height="35px" 
                                    Font-Names="楷体" Font-Size="14pt" ForeColor="White" 
                                    style="background-image:url('pictures/btnbg.png')" BackColor="#19A7CF" 
                                     OnClick="Button3_Click"/>
                        </div>
                    </div>
                    <div style="text-align:right;margin:130px 90px 0 0;"><asp:Button ID="Button2" runat="server" Text="创建" BackColor="#04223A" ForeColor="White" BorderStyle="None" Width="100px" Height="50px" Font-Size="18pt" Font-Names="楷体" Font-Bold="True" OnClick="Button2_Click" /></div>
                 </div>                
            </div>                                     
        </div>
        <div id="right">
            <%--最新动态--%>
            <div class="guess">
                <div style="padding:5px 10px">
                    <div style="float:left">最新动态</div>
                    <div style="float:right">
                        <asp:ImageButton ID="updateGuess" runat="server" OnClick="updateGuess_Click" ImageUrl="~/pictures/update.png" />  刷新
                    </div>
                </div>
             <div style="height:500px;">
                <asp:DataList ID="DataListguess1" runat="server">
                <ItemTemplate>
                    <table width="280px"cellspacing="10px" style="height:50px">
                        <tr>
                            <td align="center"><asp:Image ID="updateImg" runat="server" src="images/head.png" width="50px" height="50px"/></td>
                            <td><%# Eval("info") %>'</td>
                        </tr>
                    </table>
                </ItemTemplate>
                </asp:DataList>
              </div>
           </div>
        </div>
    </div>
</div>
</asp:Content>

