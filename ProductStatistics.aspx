<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductStatistics.aspx.cs" Inherits="ProductStatistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div style="height: 205px">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" class="btn btn-default dropdown-toggle btn-filter">
                <asp:ListItem Value="">Chọn</asp:ListItem>
                <asp:ListItem Value="1">Tổng doanh thu bán theo sản phẩm</asp:ListItem>
                <asp:ListItem Value="2">Tổng doanh thu theo loại sách</asp:ListItem>
                <asp:ListItem Value="3">Tổng doanh thu từng loại sách tháng hiện tại</asp:ListItem>
                <asp:ListItem Value="4">số lượng tồn kho</asp:ListItem>
                <asp:ListItem Value="5">Theo mã khách hàng</asp:ListItem>
                <asp:ListItem Value="6">Theo mã khách hàng</asp:ListItem>
                <asp:ListItem Value="7">Theo mã khách hàng</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="416px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
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
            <br />
        </div>
    </div>
</asp:Content>
