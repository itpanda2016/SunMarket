<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CustomerAmount.aspx.cs" Inherits="SaleQRCode.CustomerAmount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--    <%
        if (member.headimgurl != "" && member.subscribe == 1) {
    %>
    <h1>
        <img src="<%=member.headimgurl %>" width="48" alt="Alternate Text" />
        <%=member.nickname %>：消费统计</h1>

    <%
        }
        else {
    %>
    <h1>未选择正确的粉丝信息。<%=member.openid %></h1>
    <%
        }
    %>--%>


    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <div class="panel panel-success">
                <div class="panel panel-heading">用户 <%=member.nickname %> 消费统计</div>
                <div class="panel panel-body">
                    <form method="post" action="CustomerAmount.aspx" class="form-inline">
                        <div class="form-group">
                            <label>订单日期：</label>
                            <input type="datetime" class="form-control" name="startTime" />&nbsp;~&nbsp;
                            <input type="datetime" class="form-control" name="endTime" />
                        </div>
                        <input type="submit" class="btn btn-success" name="btnSubmit" value="查询" />
                    </form>
                </div>
                <table class="table table-bordered">
                    <tr style="font-weight: bold;">
                        <td>订单日期</td>
                        <td>用户编号</td>
                        <td>Openid</td>
                        <td>订单ID</td>
                        <td>订单号</td>
                        <td>订单状态</td>
                        <td>支付状态</td>
                        <td>已支付金额</td>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("ordertime") %></td>
                <td><%# Eval("user_id") %></td>
                <td><%# Eval("openid") %></td>
                <td><%# Eval("order_id") %></td>
                <td><%# Eval("order_sn") %></td>
                <td><%# Eval("订单状态") %></td>
                <td><%# Eval("支付状态") %></td>
                <td><%# Eval("paid_amount") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
         </div>
        </FooterTemplate>
    </asp:Repeater>


</asp:Content>
