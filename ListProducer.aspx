<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListProducer.aspx.cs" Inherits="ListProducer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="width:100%;height:auto;">
            <asp:Button style="float:left;" class="btn btn-primary" ID="btnNSX" runat="server" OnClick="btnNSX_Click" Text="Thêm NSX" />
            <asp:DropDownList style="float:left;" ID="TypeSearch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="TypeSearch_SelectedIndexChanged" class="btn btn-default dropdown-toggle btn-filter">
                <asp:ListItem Value="1">Theo mã nhà sản xuất</asp:ListItem>
                <asp:ListItem Value="2">Theo tên nhà sản xuất</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox style="float:left;" ID="txtSearch" runat="server" Height="32px" Width="203px" placeholder="Nhập từ khóa tìm kiếm ..." class="form-control form-large search-input"></asp:TextBox>
            <asp:Button class="btn btn-primary" ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" Height="30px" />
            <br />
        </div>
 
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="2" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" style="margin-top: 36px" DataKeyNames="_id" Height="16px" Width="581px">
            <Columns>
                <asp:BoundField DataField="_id" HeaderText="Mã NSX" >
                <ControlStyle Width="40px" />
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                <HeaderStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="_name" HeaderText="Tên NSX" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="_description" HeaderText="Mô tả" >
                <ControlStyle Width="100px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Sửa">
                    <EditItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Update" ImageUrl="~/image/icons8-Save Close-15.png" />
                        <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Cancel" ImageUrl="~/image/icons8-Minus-15.png" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Edit" ImageUrl="~/image/icons8-Edit-15.png" />
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

