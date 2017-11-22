<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="SaleQRCode.CustomerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>粉丝列表</h1>
    <p>需要把头像、昵称、关注状态显示出来，包括来源二维码、营销员ID、姓名</p>
    <p>正常情况下可直接打开，看到所有的粉丝列表</p>
    <p>或者是通过营销员ID连接进入，查看指定的粉丝列表</p>

    <p>取消unsubscribe事件，更新openid用户的状态为未关注，并清除营销员ID（或者直接删除）</p>
    <p>再次关注时，如果已存在openid，则更新状态、营销员ID</p>

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
