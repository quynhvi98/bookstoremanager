<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerManager.aspx.cs" Inherits="CustomerManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<div style="float: left; margin-left: 20px; margin-top: 15px;">
            <span style="margin-left:20px;">Tìm khách hàng</span>
            <asp:TextBox ID="txtSearch" runat="server" Height="20px" Width="150px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />
            <asp:DropDownList ID="TypeSearch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="TypeSearch_SelectedIndexChanged">
                <asp:ListItem Value="1">Theo mã khách hàng</asp:ListItem>
                <asp:ListItem Value="2">Theo tên khách hàng</asp:ListItem>
                <asp:ListItem Value="3">Theo địa chỉ</asp:ListItem>
                <asp:ListItem Value="4">Theo tổng tiền thanh toán</asp:ListItem>
            </asp:DropDownList>
        </div>--%>
    <div style="width:100%;height:auto;">
            <asp:DropDownList style="float:left;" ID="TypeSearch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="TypeSearch_SelectedIndexChanged" class="btn btn-default dropdown-toggle btn-filter">
                <asp:ListItem Value="1">Theo mã khách hàng</asp:ListItem>
                <asp:ListItem Value="2">Theo tên khách hàng</asp:ListItem>
                <asp:ListItem Value="3">Theo địa chỉ</asp:ListItem>
                <asp:ListItem Value="4">Theo tổng tiền thanh toán</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox style="float:left;" ID="txtSearch" runat="server" Height="32px" Width="203px" placeholder="Nhập từ khóa tìm kiếm ..." class="form-control form-large search-input"></asp:TextBox>
            <asp:Button class="btn btn-primary" ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" Height="30px" />
            <br />
        </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="136px" Width="823px" DataKeyNames="_id" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" PageIndex="10">
        <Columns>
            <asp:BoundField DataField="_id" HeaderText="Mã KH" ReadOnly="True" />
            <asp:BoundField DataField="_email" HeaderText="Email" ReadOnly="True" />
            <asp:BoundField DataField="_user" HeaderText="Tên tài khoản" ReadOnly="True" />
            <asp:BoundField DataField="_name" HeaderText="Tên khách hàng" ReadOnly="True" />
            <asp:BoundField HeaderText="Tổng chi tiêu" DataField="_total_bill" ReadOnly="True" />
            <asp:BoundField DataField="_adddress_full" HeaderText="Địa chỉ" ReadOnly="True" />
            <asp:BoundField HeaderText="Trạng thái" DataField="_status" />
            <asp:TemplateField HeaderText="Mở/khóa TK">
                <EditItemTemplate>
                    <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Update" ImageUrl="~/image/icons8-Edit-15.png" />
                    <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Cancel" ImageUrl="~/image/icons8-Minus-15.png" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/image/icons8-Lock-15.png" CommandName="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
</asp:Content>

