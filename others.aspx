<%@ Page Title="" Language="C#" MasterPageFile="~/TopFoot.master" AutoEventWireup="true" CodeFile="others.aspx.cs" Inherits="others" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="others.css" rel="stylesheet" type="text/css" />
<script type="application/javascript" src="js/jquery-1.11.3.min.js"></script>
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
<div style="width:1280px;">
    <%-- 中间主要内容--%>
    <div id="main_content">
        <div id="left">
            <%--发布语录--%>
            <div id="tab_menu" style="background-image: url('pictures/downbg.png')">
                        <a href="#">TA的语录</a><a href="#">TA的语录集</a>
                    </div>
            <div id="tab_box">
                    <%--TA的语录--%>
                    <div style="padding:20px 5px; background-image: url('pictures/opacitybg.png'); background-repeat: repeat-y;">
                        <asp:DataList ID="DataListMySentence" runat="server">
                            <ItemTemplate>                                   
                                    <p style="text-indent:30px;line-height:25px;">
                                        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White"  NavigateUrl='<%# String.Format("~/sentence.aspx?id={0}", Eval("Sentence_id"))%>'><asp:Label ID="Label2" runat="server" Text='<%# Eval("info") %>' Width="700px" Font-Size="16pt"></asp:Label></asp:HyperLink></p> 
                                    <p style="float:right;line-height:14px;color:#ccc;">
                                        <span>--</span>       
                                        <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="#CCCCCC"  NavigateUrl='<%# String.Format("~/others.aspx?author={0}",Eval("author")) %>'><asp:Label ID="Label3" runat="server" Text='<%# Eval("author") %>'></asp:Label></asp:HyperLink>
                                        <asp:HyperLink ID="HyperLink3" runat="server" ForeColor="#CCCCCC"  NavigateUrl='<%# String.Format("~/SentenceSet.aspx?id={0}",Eval("book_id")) %>'><asp:Label ID="Label4" runat="server" Text='<%# Eval("title") %>'></asp:Label> </asp:HyperLink> 
                                    </p>
                                    <p style="clear:both;float:right;">
                                        <asp:ImageButton ID="ILoveIt" runat="server" ImageUrl="~/pictures/heart2.png" OnClick="ILoveIt_Click" CommandArgument='<%# Eval("Sentence_id") %>'/><asp:Label ID="lovenum_label_sentence" runat="server"  Text='<%# Eval("numOfFavorite") %>' Font-Size="8pt"></asp:Label>
                                    </p>                                        
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

                    <%--TA的语录集--%>
                    <div style="background-image: url('pictures/opacitybg.png'); background-repeat: repeat-y;padding:20px 40px;">                                               
                        <asp:DataList ID="DataListMyset" runat="server">
                            <ItemTemplate>
                                <table cellpadding="5px">
                                    <tr style="height:40px">
                                        <td rowspan="3"><img src='<%# Eval("head_img") %>' style="height: 180px; width: 120px"></td>
                                        <td colspan="2">
                                            <asp:HyperLink ID="HyperLink4" runat="server" ForeColor="White" NavigateUrl='<%# String.Format("~/SentenceSet.aspx?id={0}",Eval("book_id")) %>'><asp:Label ID="Label1" runat="server" Text='<%# Eval("title") %>' Font-Size="17pt" Width="440px"></asp:Label></asp:HyperLink></td>                                        
                                    </tr>
                                    <tr valign="top"><td colspan="2">
                                                        <%--<span>简介：</span>--%>
                                                        <p style="color:#ccc">
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("simple_intro") %>' Width="540px"></asp:Label>
                                                        </p></td>
                                    </tr>
                                    <tr style="height:30px; color: #cccccc;" >
                                        <td align="right"><asp:Label ID="Label7" runat="server" Text='<%#System.DateTime.Parse(Eval("createTime").ToString()).ToString("dd-MM-yyyy")%>'></asp:Label>
                                             <asp:ImageButton ID="ILoveIt_Set1" runat="server" ImageUrl="~/pictures/heart2.png" OnClick="ILoveIt_Click" CommandArgument='<%# Eval("book_id") %>' />
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
        </div>
        <div id="right">
            <%--个人简介--%>
            <div id="personal">
                <div style="padding-top:30px;height:100px;text-align:center;">
                    <asp:Image ID="user_img" runat="server" Width="80px" Height="80px"/><br/>
                    <asp:Label ID="username_label" runat="server" Text="Label" ForeColor="Black" Font-Size="17pt" Font-Bold="True"></asp:Label>
                </div> 
                <div style="margin-top:20px;"><img src="pictures/border.png" /> </div>              
            </div>
            <div style="background-color:#92b2cb;margin-bottom:130px;">
                 <div class="issuenum" style="float:left">语录集<asp:Label ID="setnum" runat="server" Text="Label"></asp:Label></div>
                 <div class="issuenum" style="float:right">发布<asp:Label ID="sentencenum" runat="server" Text="Label"></asp:Label></div>
            </div>

            <%--猜你感兴趣语录--%>
            <div class="guess">
                <div style="padding:5px 10px">
                    <div style="float:left">猜你感兴趣语录</div>
                    <div style="float:right">
                        <asp:ImageButton ID="updateGuess" runat="server" OnClick="updateGuess_Click" ImageUrl="~/pictures/update.png" />  刷新</div>
                </div>
                <div>
                    <asp:DataList ID="DataListguess1" runat="server">
                        <ItemTemplate>
                            <table cellspacing="9px">
                                <tr>
                                    <td><img src="images/head.png" width="50px" height="50px"/></td>
                                    <td> <asp:HyperLink ID="HyperLink4" runat="server" ForeColor="White" NavigateUrl='<%# String.Format("~/sentence.aspx?id={0}", Eval("Sentence_id"))%>'><asp:Label ID="Label2" runat="server" Text='<%# Eval("info") %>' Font-Size="13pt" Width="180px"></asp:Label></asp:HyperLink></td>
                                    <td align="left"><asp:ImageButton ID="ILoveIt" runat="server" ImageUrl="~/pictures/heart2.png" OnClick="ILoveIt_Click" CommandArgument='<%# Eval("Sentence_id") %>'/><asp:Label ID="lovenum_label_sentence" runat="server"  Text='<%# Eval("numOfFavorite") %>' Font-Size="8pt"></asp:Label></td>
                                </tr>
                            </table>        
                        </ItemTemplate>      
                    </asp:DataList>
                </div>
            </div>
            <%--猜你感兴趣语录集--%>
            <div class="guess" style="margin-bottom:50px;">
                <div style="padding:5px 10px">
                    <div style="float:left">猜你感兴趣语录集</div>
                    <div style="float:right"><asp:ImageButton ID="updateGuess_set" runat="server" OnClick="updateGuess_set_Click" ImageUrl="~/pictures/update.png" />  刷新</div></div>                
                <div>
                    <asp:DataList ID="DataListguess2" runat="server">
                        <ItemTemplate>
                            <div>
                                <span></span>
                            <table cellspacing="10px"">
                                <tr>
                                    <td><img src='<%#Eval("head_img") %>' alt="" width="60px" height="80px"/></td>
                                    <td>
                                        <asp:HyperLink ID="HyperLink6" runat="server" ForeColor="White" NavigateUrl='<%# String.Format("~/SentenceSet.aspx?id={0}",Eval("book_id")) %>'><asp:Label ID="Label3" runat="server" Text='<%# Eval("title") %>' Width="180px" Font-Size="13pt"  Font-Bold="True"></asp:Label></asp:HyperLink>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("simple_intro") %>' Width="160px" Font-Size="11pt"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:ImageButton ID="ILoveIt_Set" runat="server" ImageUrl="~/pictures/heart2.png" OnClick="ILoveIt_Click" CommandArgument='<%# Eval("book_id") %>' />
                                        <asp:Label ID="lovenum_label_set"  runat="server" Font-Size="8pt"  Text='<%# Eval("numOfFavorite") %>'></asp:Label>
                                    </td>
                                </tr>                                                      
                            </table>                               
                            </div>
                        </ItemTemplate>      
                    </asp:DataList>
                </div>
                
            </div>
        </div>

    </div>
    </div>
    </asp:Content>

