<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="SalerNew.aspx.cs" Inherits="SaleQRCode.SalerNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>新增营销员</h1>
    <form action="SalerNew.aspx" method="post">
        <div>
            <label>姓名</label>
            <input type="text" name="salerName" value="" />
        </div>
        <div>
            <label>手机号码</label>
            <input type="number" name="salerMobile" value="" />
        </div>
        <div>
            <label>二维码编号</label>
            <input type="number" name="qrcodeId" value="" />
        </div>
        <input type="submit" name="btnSubmit" value="保存" />
    </form>

</asp:Content>
