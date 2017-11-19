<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="SaleQRCode.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>管理主界面</h1>
    <div class="container">
        <p><strong>消息接口：</strong>https://<%=Request.Url.Host %>/Controllers/WeChat/HandlerIO.ashx</p>
    </div>
</asp:Content>
