<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CustomerAmount.aspx.cs" Inherits="SaleQRCode.CustomerAmount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <%
            if (member.headimgurl != "" && member.subscribe == 1) {
        %>
        <img src="<%=member.headimgurl %>" width="48" alt="Alternate Text" />
        <%=member.nickname %>：消费统计

    <%
        }
        else {
            %>
        <p>用户未关注公众号：<%=member.openid %></p>
                <%
        }
    %>
    </h1>
    
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table class="table table-bordered">
                <tr style="font-weight: bold;">
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
                <td><%# Eval("ordertime") %></td>
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
