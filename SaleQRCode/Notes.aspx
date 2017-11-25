<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Notes.aspx.cs" Inherits="SaleQRCode.Notes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>SunMarket《SaleQRCode》Notes</h1>
    <div class="panel panel-body">
        <p>
            发布后如果.aspx页面报错，把生成模式改为Release就可以了。
        </p>
    </div>
    <div>
        <p><input type="checkbox" name="name"  value="" />选择日期范围统计功能。可以统一成JSON：传递 JSON参数，返回JSON数据格式（可能会比较大？）</p>
        <p><input type="checkbox" name="name" value="" />最后一行有合计显示，并提供导出excel功能。</p>
        <p><input type="checkbox" name="name" value="" />停职后，营销员的关系，是否需要转移到其他营销员头上？</p>
        <p><input type="checkbox" name="name" checked="checked" value="" />实际订单总额（ecs_order_goods）、支付金额（ecs_pay_log）从相关的表中获取</p>
        <p><input type="checkbox" name="name" checked="checked" value="" />统计报表，增加支付状态</p>
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
        
    </div>
</asp:Content>
