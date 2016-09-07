<%@ Page Title="" Language="C#" MasterPageFile="~/web_admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="exit.aspx.cs" Inherits="admin_exit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>是否确定退出后台管理系统</p>
    <asp:Button ID="sure" runat="server" onclick="sure_Click" Text="确定退出" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="cancle" runat="server" Text="取消" onclick="cancle_Click" />
</asp:Content>

