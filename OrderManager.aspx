<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderManager.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    

        <div style="float: left; margin-left: 30px; margin-top: 15px;width:auto">
            <div style="float:left">
            &nbsp;&nbsp;<span>Sắp xếp theo</span>
            <asp:DropDownList ID="SortView" runat="server" class="btn btn-default dropdown-toggle btn-filter" OnSelectedIndexChanged="SortView_SelectedIndexChanged1" AutoPostBack="True" Width="203px">
                <asp:ListItem Value="1">Thời gian</asp:ListItem>
                <asp:ListItem Value="2">Tổng tiền hóa đơn</asp:ListItem>
                <asp:ListItem Value="3">Tình trạng thanh toán</asp:ListItem>
                <asp:ListItem Value="4">Tình trạng đơn hàng</asp:ListItem>
                <asp:ListItem Value="5">Tình trạng vận chuyển</asp:ListItem>
                <asp:ListItem Value="6">--Không--</asp:ListItem>
            </asp:DropDownList>
                </div><br /><br />
          
            <div style="width:100%;height:auto;padding-left:95px;float:right">
            <asp:TextBox style="float:left;" ID="txtSearch" runat="server" Height="32px" Width="203px" placeholder="Nhập từ khóa tìm kiếm ..." class="form-control form-large search-input"></asp:TextBox>
            <asp:DropDownList style="float:left;" ID="TypeSearch" runat="server" AutoPostBack="True" class="btn btn-default dropdown-toggle btn-filter">
                <asp:ListItem Value="1">Theo mã đơn hàng</asp:ListItem>
                <asp:ListItem Value="2">Theo tên khách hàng</asp:ListItem>
            </asp:DropDownList>
            
            <asp:Button class="btn btn-primary" ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" Height="30px" />
            <br />
        </div>

        </div>

        <div style="float:left;margin-left:20px;margin-top:5px;">
            <asp:GridView ID="GridView1" runat="server" Width="950px" AutoGenerateColumns="False" Height="73px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" DataKeyNames="id" HorizontalAlign="Center" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" ShowFooter="True" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="Check All">
                        <FooterTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/image/icons8-Trash-15.png" OnClick="ImageButton1_Click" />
                        </FooterTemplate>
                        <HeaderTemplate>
                            <asp:CheckBox ID="ck_all" runat="server" AutoPostBack="True" OnCheckedChanged="ck_all_CheckedChanged" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="ck_check" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Mã đơn hàng" DataField="id" ReadOnly="True">
                        <FooterStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Tổng đơn hàng" DataField="total_bill" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Hình thức thanh toán">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                                <asp:ListItem Value="1">Tiền mặt</asp:ListItem>
                                <asp:ListItem Value="2">Chuyển khoản ngân hàng</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("content") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Trang thái thanh toán">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                                <asp:ListItem Value="1">Đã thanh toán</asp:ListItem>
                                <asp:ListItem Value="2">Chưa thanh toán</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("status_payment") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Trạng thái vận chuyển">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True">
                                <asp:ListItem Value="1">Đã giao hàng</asp:ListItem>
                                <asp:ListItem Value="2">Chưa giao hàng</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("status_delivery") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="status_bill" HeaderText="Trạng thái" ReadOnly="True" />
                    <asp:BoundField HeaderText="Ngày khởi tạo" DataField="date" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Chi tiết ">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/image/icons8-Eye-15.png" OnClick="ImageButton6_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sửa">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButton4" runat="server" CommandName="Update" ImageUrl="~/image/icons8-Save Close-15.png" />
                            <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Cancel" ImageUrl="~/image/icons8-Cancel-15.png" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Edit" ImageUrl="~/image/icons8-Edit-15.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hủy">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Delete" ImageUrl="~/image/icons8-Minus-15.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />

<RowStyle HorizontalAlign="Center" ForeColor="#000066"></RowStyle>

                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </div>



        <div style="position: absolute; top: 500px; left: 620px;">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="_id_order" ShowFooter="True" Width="600px" Height="106px" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="_id_order" HeaderText="Mã sản phẩm" />
                    <asp:BoundField DataField="_name_product" HeaderText="Tên sản phẩm" />
                    <asp:BoundField DataField="_quantity" HeaderText="Số lượng" />
                    <asp:BoundField DataField="_price" HeaderText="Đơn giá" />
                    <asp:BoundField HeaderText="Thành tiền" DataField="_total" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <PagerTemplate>
                    <asp:Label ID="Label4" runat="server" Text="Thành tiền: "></asp:Label>
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </PagerTemplate>
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>

        </div>
</asp:Content>

