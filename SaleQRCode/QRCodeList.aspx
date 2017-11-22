<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="QRCodeList.aspx.cs" Inherits="SaleQRCode.QRCodeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>二维码清单</h1>
    <p>
        <input type="checkbox" name="name" value="" /> 未绑定营销员，不允许查看二维码图片。</p>
    <p>
        <input type="checkbox" name="name" value="" /> 列表上添加关联营销员功能。</p>
    <div class="panel panel-title">
        <p style="font-weight:bold;"><a href="QRCodeNew.aspx">添加</a></p>
    </div>
    <%
        if(dt != null) {
            %>
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table class="table table-bordered">
                <tr style="font-weight:bold;">
                    <td>编号</td>
                    <%--<td>Ticket</td>--%>
                    <td>营销员编号</td>
                    <td>营销员姓名</td>
                    <td>获取图片</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("id") %></td>
                <%--<td><%# Eval("ticket") %></td>--%>
                <td><%# Eval("saler_id") %></td>
                <td><%# Eval("saler_name") %></td>
                <td>
                    <%# Eval("ticket") %>
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
