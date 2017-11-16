<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="QRCodeNew.aspx.cs" Inherits="SaleQRCode.QRCodeNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>添加二维码</h2>
    <p>添加成功后，将跳转到列表界面，根据Ticket来获取二维码图片</p>
    <form action="QRCodeNew.aspx" method="post">
        <%--<div>
            <label>输入添加二维码数量：</label>
            <input type="number" name="qrcode_number" class="form-control" value="1" />
        </div>--%>
        <input type="submit" name="btnSubmit" value="添加" />
    </form>
</asp:Content>
