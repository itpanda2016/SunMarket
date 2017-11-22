<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CustomerAmount.aspx.cs" Inherits="SaleQRCode.CustomerAmount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><%=openid %>：消费统计</h1>
    <p>统计所有流水记录，提供选择日期范围统计功能。</p>
    <p>最后一行有合计显示，并提供导出excel功能。</p>
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table class="table table-bordered">
                <tr style="font-weight:bold;">
                    <td>订单日期</td>
                    <td>用户编号</td>
                    <td>Openid</td>
                    <td>订单号</td>
                    <td>订单状态</td>
                    <td>订单总额</td>
                    <td>已支付金额</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("add_time") %></td>
                <td><%# Eval("user_id") %></td>
                <td><%# Eval("openid") %></td>
                <td><%# Eval("order_sn") %></td>
                <td><%# Eval("order_status") %></td>
                <td><%# Eval("order_amount") %></td>
                <td><%# Eval("money_paid") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
