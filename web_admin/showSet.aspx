<%@ Page Title="" Language="C#" MasterPageFile="~/web_admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="showSet.aspx.cs" Inherits="web_admin_showSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
  body{color:white;}
  .setclass td
  {      
      border:1px solid #27a9e3;
      text-align:center;
      } 
      
    .snav td
    {
        width:110px;
        height:50px;
        color:White;
        background-color: #000000;
        }
     .style1
    {
        width:110px;
        height:50px;
        color:White;
        font-weight:400;
        background-color: #000000;
        }
      .style2
    {
        color:#27a9e3;
        }
     .sethead
     {
        height:50px;
        color:White;
        font-weight:bold;
        background-color: #27a9e3;
         } 
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="setclass">
        <table>
            <tr><td colspan="4" class="sethead">语录集分类统计</td></tr>
            <tr class="snav">
                <td></td><td>书本语录</td><td class="style14">电影语录</td><td class="style18">歌曲语录</td>
            </tr>
            <tr>
                <td class="style1">收藏语录数</td>
                <td class="style2"><asp:Label ID="numSent_book" runat="server" Text="Label"></asp:Label></td>
                <td class="style2"><asp:Label ID="numSent_movie" runat="server" Text="Label"></asp:Label></td>
                <td class="style2"><asp:Label ID="numSent_music" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="style1">被喜欢次数</td>
                <td class="style2"><asp:Label ID="beloved_book" runat="server" Text="Label"></asp:Label></td>
                <td class="style2"><asp:Label ID="beloved_movie" runat="server" Text="Label"></asp:Label></td>
                <td class="style2"><asp:Label ID="beloved_music" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="style1">链接分享数</td>
                <td class="style2"><asp:Label ID="share_book" runat="server" Text="Label"></asp:Label></td>
                <td class="style2"><asp:Label ID="share_movie" runat="server" Text="Label"></asp:Label></td>
                <td class="style2"><asp:Label ID="share_music" runat="server" Text="Label"></asp:Label></td>
            </tr>

        </table>
        
    </div>     
</asp:Content>

