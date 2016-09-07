<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="others" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>首页</title>
 <link href="main.css" rel="stylesheet" type="text/css" />
 <script type="application/javascript" src="../js/jquery-1.11.3.min.js"></script>
   <!--flickerplate所需的包-->
<script src="slide/js/min/jquery-v1.10.2.min.js" type="text/javascript"></script>
<script src="slide/js/min/modernizr-custom-v2.7.1.min.js" type="text/javascript"></script>
<script src="slide/js/min/jquery-finger-v0.1.0.min.js" type="text/javascript"></script>
<link href="slide/css/flickerplate.css" rel="stylesheet" type="text/css" />
<script src="slide/js/flickerplate.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        var menu = $(".navb");
        var i = $(".navb > img");
        var a = $(".navb > a");
        menu.mouseover(function () {
            var index = menu.index(this);
            i.eq(index).css({ "top": "-20px" });
            a.eq(index).css({ "top": "40px" });
        });
        menu.mouseout(function () {
            var index = menu.index(this);
            i.eq(index).css({ "top": "0" });
            a.eq(index).css({ "top": "60px" });
        });
        $('#slide_img').flicker();
    });
</script> 
</head>
<body>
    <form id="form1" runat="server">
    <div id="top_page">
        <div id="slide">
            <div id="slide_img">
                <ul>
                    <li style="background-image: url('./slide/img/slide1.png')">
                        <div class="flick-title">《返老还童》</div>
                        <div class="flick-sub-text">人都是孤独的。但可怕的不是孤独，而是惧怕孤独。</div>
                    </li>
                    <li style="background-image: url('./slide/img/slide2.jpg')">
                        <div class="flick-title">莎士比亚</div>
                        <div class="flick-sub-text">我们的本质，就如同梦一般虚幻不实，而我们渺小的生命，以一场睡眠圆满落幕。</div>                        
                    </li>
                    <li style="background-image: url('./slide/img/slide3.jpg')">
                        <div class="flick-title">李娟《我的阿勒泰》</div>
                        <div class="flick-sub-text">没有月亮，外面漆黑一团。但星空华丽，在世界上半部分兀自狂欢。星空的明亮与大地的黑暗断然分割。</div>
                    </li>
                </ul>              
            </div>
            <div id="nav" style="margin-top:-15px;">
                <ul id="ulnav">
                    <li><a href="book.aspx">书本</a></li>
                    <li><a href="movie.aspx">电影</a></li>
                    <li><a href="music.aspx">歌曲</a></li>
                </ul>
                <div style="margin-top:-15px;">
                    <asp:HyperLink ID="HyperLink4" runat="server"  Text="登录" Font-Names="楷体" Font-Size="14pt" style="margin-right:20px;" ForeColor="White" NavigateUrl="~/admin/login.aspx"></asp:HyperLink>
                    <asp:HyperLink ID="HyperLink7" runat="server"  Text="注册" Font-Names="楷体" Font-Size="14pt" style="margin-right:20px;" ForeColor="White" NavigateUrl="~/register.aspx"></asp:HyperLink>
                </div>
            </div>
       </div>
        <div id="main_nav">
            <span class="navb"><img src="pictures/index_navbg.png" alt=""/><a href="book.aspx">书本</a></span>
            <span class="navb"><img src="pictures/index_navbg.png" alt=""/><a href="movie.aspx">电影</a></span>
            <span class="navb"><img src="pictures/index_navbg.png" alt=""/><a href="music.aspx">歌曲</a></span>
        </div>
    </div>
    <div id="main_content">
        <div id="left">                              
            <div class="box">
                <%--显示4条记录 --%> 
                <div><p style="color:white;font-size:25px;">精选语录集</p></div>                                              
                <asp:DataList ID="DataListMyset" runat="server">
                    <ItemTemplate> 
                        <table cellpadding="10px">
                            <tr style="height:50px">
                                <td rowspan="3" valign="top"><img src='<%# Eval("head_img") %>' style="height: 180px; width: 120px" alt=""></td>
                                <td colspan="2"><asp:HyperLink ID="HyperLink1"  NavigateUrl='<%# String.Format("~/SentenceSet.aspx?id={0}",Eval("book_id")) %>' runat="server" Text='<%# Eval("title") %>' Font-Size="17pt" Width="440px" Font-Bold="True"></asp:HyperLink></td>                                        
                            </tr>
                            <tr valign="top">
                                <td colspan="2">
                                    <%--这里设计的时候是语录集的一条语录，我不知道会不会很麻烦，你自己看着办吧 --%>
                                    <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("simple_intro") %>' Width="540px"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr style="height:30px; color: #cccccc;font-size:12pt;" >
                                <td>收集语录（<%# Eval("numOfSentences") %>）</td>
                                <td align="right" style="font-size:11pt">
                                    <span style="margin-right:15px;"><%#System.DateTime.Parse(Eval("createTime").ToString()).ToString("dd-MM-yyyy")%></span>
                                    <span><asp:ImageButton ID="ILoveIt_Set1" runat="server" ImageUrl="~/pictures/heart2.png" OnClick="ILoveIt_Click" CommandArgument='<%# Eval("book_id") %>' /></span>
                                          <asp:Label ID="lovenum_label_set"  runat="server" Font-Size="8pt"  Text='<%# Eval("numOfFavorite") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>                                        
                    </ItemTemplate>              
                </asp:DataList>                                                                           
            </div>
            <div class="box">
                <%--这里的图片上传的时候就裁切好成圆的  注册有代码--%>
                <div style="margin-bottom:25px;font-size:25px;">名人堂</div>
                <asp:DataList ID="DataList2" runat="server" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <div id="each_famous">
                            <div>
                                <asp:HyperLink ID="HyperLink8" runat="server"  NavigateUrl='<%# String.Format("~/others.aspx?author={0}",Eval("author")) %>' ><asp:Image ID="Image1" runat="server" src='<%# Eval("head_img") %>' Width="120px" Height="150px"/></asp:HyperLink></div>
                            <div><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# String.Format("~/others.aspx?author={0}",Eval("author")) %>' Text='<%# Eval("author") %>'></asp:HyperLink></div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="box">
                <%--显示3条记录--%>
                <div><p style="color:white;font-size:25px;">最新语录集</p></div>  
                 <asp:DataList ID="DataList1" runat="server">
                    <ItemTemplate> 
                        <table cellpadding="4px">
                            <tr style="height:40px">
                                <td rowspan="3" valign="top"><img src='<%# Eval("head_img") %>' style="height: 180px; width: 120px" alt=""></td>
                                <td colspan="2"><asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl='<%# String.Format("~/SentenceSet.aspx?id={0}",Eval("book_id")) %>' Text='<%# Eval("title") %>' Font-Size="17pt" Width="440px" Font-Bold="True"></asp:HyperLink></td>                                        
                            </tr>
                            <tr valign="top">
                                <td colspan="2">
                                    <%--这里设计的时候是语录集的一条语录，我不知道会不会很麻烦，你自己看着办吧 --%>
                                    <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("simple_intro") %>' Width="540px"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr style="height:30px; color: #cccccc;font-size:12pt;" >
                                <td>收集语录（<%# Eval("numOfSentences") %>）</td>
                                <td align="right" style="font-size:11pt">
                                    <span style="margin-right:15px;"><%#System.DateTime.Parse(Eval("createTime").ToString()).ToString("dd-MM-yyyy")%></span>
                                    <span><asp:ImageButton ID="ILoveIt_Set1" runat="server" ImageUrl="~/pictures/heart2.png" OnClick="ILoveIt_Click" CommandArgument='<%# Eval("book_id") %>' /></span>
                                          <asp:Label ID="lovenum_label_set"  runat="server" Font-Size="8pt"  Text='<%# Eval("numOfFavorite") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>                                        
                    </ItemTemplate>              
                </asp:DataList> 
                <%--datalist分页：显示首页，上一页，下一页，当前页，只有当前页，总页数--%>
                <div class="pagenum">
                    <asp:LinkButton ID="lbtnfirst" runat="server" ForeColor="White" OnClick="lbtnFirst_Click">首页</asp:LinkButton>                                                           
                    <asp:LinkButton ID="lbtnUp" runat="server" ForeColor="White" OnClick="lbtnUp_Click">上一页</asp:LinkButton>                                
                    <asp:Label ID="pagenow" runat="server" Text="1"></asp:Label>                                                                                
                    <asp:LinkButton ID="lbtnNext" runat="server" ForeColor="White" OnClick="lbtnNext_Click">下一页</asp:LinkButton>
                    <asp:LinkButton ID="lbtnLast" runat="server" ForeColor="White" OnClick="lbtnLast_Click">尾页</asp:LinkButton>
                    <span>&nbsp;</span>总共<span>&nbsp;</span><asp:Label ID="totalPage_set" runat="server" Text="1"></asp:Label><span>&nbsp;</span><span>页</span>
                </div>
            </div>                                                           
        </div>
        <div id="right">
            <%--最新语录--%>
            <div class="guess">
                <div style="padding:5px 15px">
                    <div style="float:left">最新语录</div>
                    <div style="float:right"><asp:ImageButton ID="updateGuess" runat="server" OnClick="updateGuess_Click" ImageUrl="~/pictures/update.png" />  刷新</div>
                </div>               
                <asp:DataList ID="DataListguess1" runat="server">
                    <ItemTemplate>
                        <table style="width:300px;margin:5px;" cellspacing="10">
                            <tr>
                                <td><asp:Image ID="Image1" runat="server" src="pictures/head.png" Width="45px" Height="45px"/></td>
                                <td><asp:HyperLink ID="HyperLink6" runat="server" Text='<%# Eval("info") %>'  NavigateUrl='<%# String.Format("~/sentence.aspx?id={0}", Eval("Sentence_id"))%>' Font-Size="12pt"></asp:HyperLink></td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right"><asp:HyperLink ID="HyperLink5" runat="server" Text='<%# Eval("title") %>' ForeColor="#cccccc" Font-Size="10pt"></asp:HyperLink></td>
                            </tr>
                        </table>
                        <div></div>        
                    </ItemTemplate>      
                </asp:DataList>               
            </div>
            <%--经典语录--%>
            <div class="guess">
                <div style="padding:5px 15px">
                    <div style="float:left">经典语录</div>
                    <div style="float:right"><asp:ImageButton ID="ImageButton2" runat="server" OnClick="updateGuess_Classical_Click" ImageUrl="~/pictures/update.png" />  刷新</div>
                </div>               
                <asp:DataList ID="DataListguess2" runat="server">
                    <ItemTemplate>
                        <table cellspacing="10" style="width:300px;margin:5px;">
                            <tr>
                                <td><asp:Image ID="Image1" runat="server" src="pictures/head.png" Width="45px" Height="45px"/></td>
                                <td><asp:HyperLink ID="HyperLink6" runat="server"  NavigateUrl='<%# String.Format("~/sentence.aspx?id={0}", Eval("Sentence_id"))%>' Text='<%# Eval("info") %>' Font-Size="12pt"></asp:HyperLink></td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right"><asp:HyperLink ID="HyperLink5" runat="server" Text='<%# Eval("title") %>' ForeColor="#cccccc" Font-Size="10pt"></asp:HyperLink></td>
                            </tr>
                        </table>
                        <div></div>        
                    </ItemTemplate>      
                </asp:DataList>               
            </div>
        </div>

    </div>
    <div id="foot"><br /><br />
            <ul id="footnav">
                <li><a href="#">书本语录集</a></li>
                <li><a href="#">电影语录集</a></li>
                <li><a href="#">歌曲语录集</a></li>               
            </ul><br />
            <div style="margin:40px;clear:both;">版权所有 © 2016</div>
        </div>
    </form>
</body>
</html>
