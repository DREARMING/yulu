<%@ Page Title="" Language="C#" MasterPageFile="~/TopFoot.master" AutoEventWireup="true" CodeFile="music.aspx.cs" Inherits="book" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="bookmm.css" rel="stylesheet" type="text/css" />
<script src="js/jquery-1.11.3.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        var menu = $("#tab_menu a");
        menu.mouseover(function () {
            var index = menu.index(this);            
            var box = $("#tab_box > div");
            box.eq(index).show().siblings().hide();

        });
    });
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- 中间主要内容--%>
    <div id="main_content">
        <div id="left">
            <div id="tab_menu">
                <div style="padding:10px 40px; background-image: url('pictures/opacitybg.png');">
                    <img src="pictures/down.png" alt="" width="25px";height="25px"/>
                    <span >歌曲语录集</span><span><a href="#">最新</a>   <a href="#">最热</a></span>
                </div>
            </div>                                               
        <div id="tab_box">
            <%--最热----%>
            <div style="padding:20px 30px;background-image: url('pictures/opacitybg.png');background-repeat: repeat-y;">
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="4" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <table cellpadding="3" style="width:190px;height:160px;">
                            <tr><td valign="top"><asp:ImageButton ID="ImageButton1" runat="server" src='<%#Eval("head_img") %>' Width="125px" Height="180px"/></td></tr>
                            <tr><td><asp:HyperLink ID="HyperLink1" runat="server" Font-Size="13pt"><%#Eval("title")%></asp:HyperLink></td></tr>
                            <tr>
                                <td style="font-size:12pt;">收集语录（<%#Eval("numOfSentences") %>）
                                    <asp:ImageButton ID="ILoveIt" runat="server" ImageUrl="~/pictures/heart2.png" /><asp:Label ID="lovenum_label_sentence" runat="server"  Text='<%# Eval("numOfFavorite") %>' Font-Size="8pt"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <div class="pagenum">
                    <asp:LinkButton ID="lbtnfirst_sentence" runat="server" ForeColor="White" OnClick="lbtnFirst_Click_sentence">首页</asp:LinkButton>                                                           
                    <asp:LinkButton ID="lbtnUp_sentence" runat="server" ForeColor="White" OnClick="lbtnUp_Click_sentence">上一页</asp:LinkButton>
                    <asp:Label ID="pagenow_sentence" runat="server" Text="1"></asp:Label>                                                                                
                    <asp:LinkButton ID="lbtnNext_sentence" runat="server" ForeColor="White" OnClick="lbtnNext_Click_sentence">下一页</asp:LinkButton>
                    <asp:LinkButton ID="lbtnLast_sentence" runat="server" ForeColor="White" OnClick="lbtnLast_Click_sentence">尾页</asp:LinkButton>
                    <span>&nbsp;</span>总共<span>&nbsp;</span><asp:Label ID="totalPage_sentence" runat="server" Text="1"></asp:Label><span>&nbsp;</span><span>页</span>
                </div>           
            </div>

            <%--最新--%>
            <div style="padding:20px 30px;background-image: url('pictures/opacitybg.png');background-repeat: repeat-y;">
                <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource2" 
                    RepeatColumns="4" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <table cellpadding="3" style="width:190px;height:160px;">
                            <tr><td valign="top"><asp:ImageButton ID="ImageButton1" runat="server" src='<%#Eval("head_img") %>' Width="125px" Height="180px"/></td></tr>
                            <tr><td><asp:HyperLink ID="HyperLink1" runat="server" Font-Size="13pt"><%#Eval("title")%></asp:HyperLink></td></tr>
                            <tr>
                                <td style="font-size:12pt;">收集语录（<%#Eval("numOfSentences") %>）
                                    <asp:ImageButton ID="ILoveIt" runat="server" ImageUrl="~/pictures/heart2.png" /><asp:Label ID="lovenum_label_sentence" runat="server"  Text='<%# Eval("numOfFavorite") %>' Font-Size="8pt"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <div class="pagenum">
                    <asp:LinkButton ID="lbtnfirst" runat="server" ForeColor="White" OnClick="lbtnFirst_Click_sentence">首页</asp:LinkButton>                                                           
                    <asp:LinkButton ID="lbtnUp" runat="server" ForeColor="White" OnClick="lbtnUp_Click_sentence">上一页</asp:LinkButton>
                    <asp:Label ID="pagenow" runat="server" Text="1"></asp:Label>                                                                                
                    <asp:LinkButton ID="lbtnNext" runat="server" ForeColor="White" OnClick="lbtnNext_Click_sentence">下一页</asp:LinkButton>
                    <asp:LinkButton ID="lbtnLast" runat="server" ForeColor="White" OnClick="lbtnLast_Click_sentence">尾页</asp:LinkButton>
                    <span>&nbsp;</span>总共<span>&nbsp;</span><asp:Label ID="totalPage_set" runat="server" Text="1"></asp:Label><span>&nbsp;</span><span>页</span>
                </div>           
            </div>
        </div>
        </div>
                                       
        <div id="right">
            <%--书籍语录动态--%>
            <div class="booksentence">
                <div style="padding:5px 10px;font-size:14pt;font-weight:bold;">
                    <div style="float:left">歌曲语录动态</div>
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
                            <td><%# Eval("info") %></td>
                            <td><asp:ImageButton ID="ILoveIt" runat="server" ImageUrl="~/pictures/heart2.png" /><asp:Label ID="lovenum_label_sentence" runat="server"  Text='<%# Eval("numOfFavorite") %>' Font-Size="8pt"></asp:Label></td>
                        </tr>
                    </table>
                </ItemTemplate>
                </asp:DataList>
              </div>
           </div>
        </div>
</div>    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Web_DBConnectionString %>"             
            SelectCommand="SELECT * FROM [SentenceSet] WHERE ([class] = @class) ORDER BY [createTime] DESC, [numOfFavorite] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="music" Name="class" Type="String" />
        </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Web_DBConnectionString %>" 
            SelectCommand="SELECT * FROM [SentenceSet] WHERE ([class] = @class) ORDER BY [numOfFavorite] DESC, [numOfSentences] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="music" Name="class" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

</asp:Content>

