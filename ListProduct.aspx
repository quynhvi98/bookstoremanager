<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListProduct.aspx.cs" Inherits="ListProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: left; margin-left: 20px; margin-top: 15px; height: auto; width: 100px;">

        <div style="width: 727px">
            <asp:DropDownList ID="TypeSearch" runat="server" AutoPostBack="True" class="btn btn-default dropdown-toggle btn-filter">
                <asp:ListItem Value="1">Theo mã sản phầm</asp:ListItem>
                <asp:ListItem Value="2">Theo tên sản phẩm</asp:ListItem>
                <asp:ListItem Value="3">Theo giá tiền</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtSearch" Style="float: left;" runat="server" Width="223px" placeholder="Nhập từ khóa tìm kiếm ..." class="btn btn-default dropdown-toggle btn-filter"></asp:TextBox>
            &nbsp;<asp:Button ID="btnSearch" class="btn btn-primary" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />

        </div>
    </div>

    <div>
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="ListView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="1043px" AllowPaging="True" OnPageIndexChanging="ListView_PageIndexChanging" Height="403px">
            <Columns>
                <asp:BoundField DataField="_id" HeaderText="Mã SP" />
                <asp:BoundField DataField="_name" HeaderText="Tên sản phẩm" />
                <asp:BoundField DataField="_price" HeaderText="Đơn giá" />
                <asp:BoundField DataField="_status" HeaderText="Tình trạng" />
                <asp:BoundField DataField="NhaXuatBan" HeaderText="Nhà xuất bản" />
                <asp:BoundField DataField="productType" HeaderText="Thể loại" />
                <asp:BoundField DataField="_name_author" HeaderText="Tác giả" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="35px" ImageUrl="~/image/icons8-Eye-15.png" Width="41px" OnClick="ImageButton1_Click1" />
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

    </div>
    <div id="details" style="width: 1000px; height: auto; margin-left: auto; margin-right: auto;">
        <div style="float: left; padding-left: 40px;">
            <p>
                <span>- Mã sản phẩm:</span>
                <asp:Label CssClass="span" ID="Label1" runat="server" Height="20px" Width="300px"></asp:Label>
            </p>
            <br />
            <p>
                <span>- Tên sản phẩm:</span>
                <asp:Label CssClass="span" ID="Label2" runat="server" Height="20px" Width="300px"></asp:Label>
            </p>
            <br />
            <p>
                <span>- Giá bán:</span>
                <asp:Label CssClass="span" ID="Label4" runat="server" Height="20px" Width="300px"></asp:Label>
            </p>
            <br />
            <p>
                <span>- Số lượng:</span>
                <asp:Label CssClass="span" ID="Label5" runat="server" Height="20px" Width="300px"></asp:Label>
            </p>
            <br />
            <p>
                <span>- Khối lượng:</span>
                <asp:Label CssClass="span" ID="Label6" runat="server" Height="20px" Width="300px"></asp:Label>
            </p>
            <br />
            <p>
                <span>- Nội dung:</span>
                <asp:Label CssClass="span" ID="Label7" runat="server" Height="20px" Width="300px"></asp:Label>
            </p>
            <br />
            <p>
                <span>- Trạng thái:</span>
                <asp:Label CssClass="span" ID="Label8" runat="server" Height="20px" Width="300px"></asp:Label>
            </p>
            <br />
            <p>
                <span>- Năm phát hành:</span>
                <asp:Label CssClass="span" ID="Label9" runat="server" Height="20px" Width="300px"></asp:Label>
            </p>
            <br />
            <p>
                <span>- Nhà xuất bản:</span>
                <asp:Label CssClass="span" ID="Label10" runat="server" Height="20px" Width="300px"></asp:Label>
            </p>
            <br />
            <p>
                <span>- Thể loại:</span>
                <asp:Label CssClass="span" ID="Label11" runat="server" Height="20px" Width="300px"></asp:Label>
            </p>
            <br />
            
        </div>
        <div style="float: right; padding-right: 45px">
            <asp:Image ID="Image1" Height="270px" runat="server" />
            <br />
            <br />
            <br />
            <p>
                <span>- Tác giả:</span>
                <asp:Label CssClass="span" ID="Label12" runat="server"></asp:Label>
            </p>
            <br />
            <p>
                <span>- Số trang: </span>
                <asp:Label CssClass="span" ID="Label13" runat="server"></asp:Label>
            </p><br />
            <div style="padding-left:70px">
            <asp:HyperLink ID="HyperLink1" runat="server">CHỈNH SỬA</asp:HyperLink>
                </div>
        </div>

    </div>
    <style type="text/css">
        btn {
            float: right;
        }

        p {
            font-size: 14px;
            line-height: 8px;
            color: #333;
        }

            p > span {
                width: 150px;
                display: inline-block;
            }

        .span {
            display: inline-block;
        }

        table {
            margin-left: 280px;
        }
    </style>
</asp:Content>

