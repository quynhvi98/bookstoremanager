<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddProducer.aspx.cs" Inherits="AddProducer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 437px; margin-left: 50px; margin-top: 10px; height: auto; float: left;">
        <asp:Label ID="Label2" runat="server" Text="Tên NSX"></asp:Label>
        <asp:TextBox CssClass="form-control" ID="txtProducerName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="txtProducerName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vui lòng nhập tên nhà sản xuất"></asp:RequiredFieldValidator>
        <asp:Label ID="Label3" runat="server" Text="Mô tả"></asp:Label><br />
        <asp:TextBox CssClass="form-control" ID="txtProducerDescription" runat="server"></asp:TextBox>
        <br />
        <asp:Button class="btn btn-primary" ID="btnAddProducer" runat="server" OnClick="btnAddProducer_Click" Text="Thêm NSX" />
    </div>
</asp:Content>

