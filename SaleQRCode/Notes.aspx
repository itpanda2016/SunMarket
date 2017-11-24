<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Notes.aspx.cs" Inherits="SaleQRCode.Notes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>SunMarket SaleQRCode Notes</h1>
    <div>
        <p>
            <input type="checkbox" name="name" value="" checked="checked" />
            取消关注时，修改状态；
        </p>
        <p>
            <input type="checkbox" name="name" value=""  checked="checked" />
            关注时，如果已存在，则不再新增；如果状态是已关注，也不再修改关联的营销员；
        </p>
        <p>
            <input type="checkbox" name="name" value="" checked="checked" />
            关注时，如果已存在，则不再新增；但状态是未关注，则：修改状态为已关注，并修改关联的营销员ID;
        </p>
        <p>
            <input type="checkbox" name="name" value="" checked="checked" />
            关注时，如果不存在，则直接新增，并修改状态、营销员ID；
        </p>
        <p><input type="checkbox" name="name" value="" />统计所有流水记录，提供选择日期范围统计功能。</p>
        <p><input type="checkbox" name="name" value="" />最后一行有合计显示，并提供导出excel功能。</p>
    </div>
</asp:Content>
