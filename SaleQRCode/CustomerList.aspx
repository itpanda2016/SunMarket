<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="SaleQRCode.CustomerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>粉丝列表</h1>

    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table class="table table-bordered">
                <tr style="font-weight: bold;">
                    <td>编号</td>
                    <td>昵称</td>
                    <td>头像</td>
                    <td>状态</td>
                    <td>营销员编号</td>
                    <td>关注时间</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("id") %></td>
                <td><a href="CustomerAmount.aspx?id=<%# Eval("openid") %>"><%# Eval("nickname") %></a></td>
                <td>
                    <img src="<%# Eval("headimgurl") %>" width="48" /></td>
                <td><%# Eval("状态") %></td>
                <td><%# Eval("saler_id") %></td>
                <td><%# Eval("subscribe_time") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
