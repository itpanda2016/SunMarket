<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="QRCodeNew.aspx.cs" Inherits="SaleQRCode.QRCodeNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    生成二维码
    <p><%=accessToken %></p>
    <p><%=ticket.ticket %></p>
    <img style="border:1px solid silver;background:#DEDEDE;padding:4px;" src="https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=<%=ticket.ticket %>" alt="AlternateText" />
</asp:Content>
