<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="SalerList.aspx.cs" Inherits="SaleQRCode.SalerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>营销员清单</h1>
    <div class="panel panel-title">
        <p style="font-weight:bold;"><a href="SalerNew.aspx">添加</a></p>
    </div>
    <%
        if (dt != null) {
        %>
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table class="table table-bordered">
                <tr>
                    <td>编号</td>
                    <td>姓名</td>
                    <td>手机号码</td>
                    <td>二维码编号</td>
                    <td>状态</td>
                    <td>编辑</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("id") %></td>
                <td><%# Eval("name") %></td>
                <td><%# Eval("mobile") %></td>
                <td><%# Eval("qrcode_id") %></td>
                <td><%# Eval("状态") %></td>
                <td>
                    <a href="SalerEdit.aspx?id=<%# Eval("id") %>">修改</a>
                    <a href="SalerList.aspx?id=<%# Eval("id") %>" onclick="return confirm('是否确定删除？（不可撤消操作）');">删除</a>
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
