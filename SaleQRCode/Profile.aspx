<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="SaleQRCode.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>修改密码</h1>
    <form action="/Profile.aspx" method="post">
        <div>
            <label>新密码：</label>
            <p><input type="password" class="form-control" value="" name="newPassword" /></p>
        </div>
        <div>
            <label>确认密码：</label>
            <p><input type="password" class="form-control" value="" name="confirmPassword" /></p>
        </div>
        <input type="submit" value="保存" class="btn btn-primary" name="btnSubmit" />
    </form>
</asp:Content>
