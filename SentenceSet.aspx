<%@ Page Title="" Language="C#" MasterPageFile="~/TopFoot.master" AutoEventWireup="true" CodeFile="SentenceSet.aspx.cs" Inherits="SentenceSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="SentenceSet.css" rel="stylesheet" type="text/css" />
<script type="application/javascript" src="jquery-1.11.3.min.js"></script>
<script type="text/javascript">
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <%-- 中间主要内容--%>
    <div id="main_content">
        <div id="left">
            <%--所选语录--%>            
            <div id="set">
                <asp:Image ID="bookImage" runat="server" Height="290px" Width="205px" ImageUrl="~/pictures/book.png" style="position:absolute"/>
                <div id="info">
                    <div style="margin-bottom:20px;"><asp:Label ID="Lab_title" runat="server" Text="Title" Font-Size="20pt" Font-Bold="True"></asp:Label></div>
                    <div>作者：<asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White"><asp:Label ID="labauthor" runat="server" Text="Label"></asp:Label></asp:HyperLink></div>
                    <div>所属分类：<asp:HyperLink ID="HyperLink2" runat="server" Text="书本" NavigateUrl="~/book.aspx" ForeColor="White"></asp:HyperLink><br /></div>
                    <div>链接分享：<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="shareAddress" ForeColor="White">
                        <asp:Label ID="shareText" runat="server" Text="Label" Width="400px"></asp:Label></asp:HyperLink><br /></div>
               
                    <div style="float:right"><asp:ImageButton ID="ILoveIt_set" runat="server" ImageUrl="~/pictures/heart2.png" OnClick="ILoveIt_Click" CommandArgument='<%# Eval("book_id") %>'/><asp:Label ID="lovenum_label_sentence" runat="server"  Text="Label" Font-Size="8pt"></asp:Label></div>                    
                </div>
                <div id="simple_info">简介：<asp:Label ID="simpleTxt" runat="server" Text="Label" style="line-height:30px;"></asp:Label></div>                 
            </div>
                        
            <%--语录列表--%>
            <div id="relatedsentence">
                <div style="padding:10px 20px; background-image: url('pictures/opacitybg.png');">
                    <img src="pictures/down.png" alt="" width="25px";height="25px"/>
                    <span style="font-size:17pt;color: #FFFFFF;margin-left:40px; font-family: 楷体;">语录列表
                    （<asp:Label ID="Label4" runat="server" Text="3"></asp:Label>）</span>    
                </div>                     
                <div id="relsentcontent">
                    <asp:DataList ID="DatalistRelatsentence" runat="server">
                        <ItemTemplate>
                            <div style="font-size:18pt;font-weight:bold;">“<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# String.Format("~/sentence.aspx?id={0}", Eval("Sentence_id"))%>'
  ForeColor="White" Height="25"><asp:Label ID="Label2" runat="server" Text='<%# Eval("info") %>' Width="700px" Font-Size="16pt"></asp:Label></asp:HyperLink></p> </div>
                            <div style="text-align:right;color:#ccc;margin:15px 0 35px 300px;font-size:15pt;">
                                <asp:HyperLink ID="HyperLink3" runat="server" ForeColor="#CCCCCC" NavigateUrl='<%# String.Format("~/others.aspx?author={0}",Eval("author")) %>'>--<%#Eval("author") %></asp:HyperLink>&nbsp;<%#Eval("title") %></div>
                            <div style="color:#ccc;margin:20px 20px 20px 0;">
                                <span style="float:right;margin-right:10px;"><asp:ImageButton ID="ILoveIt" runat="server" ImageUrl="~/pictures/heart2.png" OnClick="ILoveIt_Click" CommandArgument='<%# Eval("Sentence_id") %>'/>
                                      <asp:Label ID="lovenum_label_set"  runat="server" Font-Size="8pt"  Text='<%# Eval("numOfFavorite") %>'></asp:Label>
                                </span>
                            </div>
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
            </div>                          
                
        </div>

        <div id="right">         
            <%--OnClick="ILoveIt_Click" CommandArgument='<%# Eval("book_id") %>'OnClick="updateGuess_Click" --%>
            <%--每日更新--%>
            <div class="guess">
                <div style="padding:5px 10px">
                    <div style="float:left">最新动态</div>
                    <div style="float:right">
                        <asp:ImageButton ID="updateGuess" runat="server" ImageUrl="~/pictures/update.png" />  刷新
                    </div>
                </div>
             <div style="height:auto;">
                <asp:DataList ID="DataListguess1" runat="server">
                <ItemTemplate>
                    <table width="310px"cellspacing="10px" style="height:50px">
                        <tr>
                            <td align="center"><asp:Image ID="updateImg" runat="server" src="images/head.png" width="50px" height="50px"/></td>
                            <td width="200px"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# String.Format("~/sentence.aspx?id={0}", Eval("Sentence_id"))%>'
  ForeColor="White"><asp:Label ID="Label2" runat="server" Text='<%# Eval("info") %>'></asp:Label></asp:HyperLink></p> </td>
                            <td align="right"><asp:ImageButton ID="ILoveIt" runat="server" ImageUrl="~/pictures/heart2.png" OnClick="ILoveIt_Click" CommandArgument='<%# Eval("Sentence_id") %>'/><asp:Label ID="lovenum_label_sentence" runat="server"  Text='<%# Eval("numOfFavorite") %>' Font-Size="8pt"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                </asp:DataList>

              </div>
           </div>

        </div>
    </div>
 </asp:Content>

