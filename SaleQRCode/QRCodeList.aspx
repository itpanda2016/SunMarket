<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="QRCodeList.aspx.cs" Inherits="SaleQRCode.QRCodeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>二维码清单</h1>
    <p>直接把二维码显示在image控件，右键下载，后面再优化成直接下载</p>
    <%
        if(dt != null) {
            %>
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table class="table table-bordered">
                <tr style="font-weight:bold;">
                    <td>编号</td>
                    <%--<td>Ticket</td>--%>
                    <td>获取图片</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("id") %></td>
                <%--<td><%# Eval("ticket") %></td>--%>
                <td>
                    <a href ="https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=<%# Eval("ticket") %>" target="_blank">查看图片</a>
                    <%--<img style="border:1px solid silver;background:#DEDEDE;padding:4px;" src="https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=<%# Eval("ticket") %>" alt="AlternateText" />--%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <%
        }
        %>
</asp:Content>
