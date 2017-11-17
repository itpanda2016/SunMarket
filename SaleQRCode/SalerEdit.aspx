<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="SalerEdit.aspx.cs" Inherits="SaleQRCode.SalerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>修改信息：<%=saler.Name %></h1>
    <form action="SalerEdit.aspx" method="post">
        <div>
            <label>姓名：</label>
            <input type="text" name="salerName" value="<%=saler.Name %>" class="form-control"/>
        </div>
        <div>
            <label>手机号码：</label>
            <input type="number" name="salerMobile" value="<%=saler.Mobile %>" class="form-control"/>
        </div>
        <select name="status">
            <option value="0">正常</option>
            <option value="-1">离职</option>
        </select>
        <div>
            <label>二维码编号：</label>
            <input type="number" name="qrcodeId" value="<%=saler.QRCodeId %>" class="form-control"/>
        </div>
        <input type="hidden" name="id" value="<%=saler.Id %>" />
        <input type="submit" name="btnSubmit" value="保存" />
    </form>
</asp:Content>
